"""
md_to_devlog.py
-------------------
This is a script that is able to turn a Markdown file to a devlog
in the form of an HTML file from a template.

License: Unlicensed
"""


# [*] Imports
from datetime import date as dateclass
from markdown import markdown


# [*] Constants
METADATA_LINES_NUM = 8
DATE_SEPARATOR = '-'
DEFAULT_HERO_BACKGROUND: str = ''
DATE_FORMAT = "%d/%m/%Y"
HERO_BACKGROUND_SELECTOR = " alt-bg"
EXISTING_HERO_BACKGROUNDS: tuple[int, int, int] = (2, 3, 4)


# [*] Functions
def _get_attributes(markdown_contents: str)-> dict[str, str | list[str]]:
    lines: list[str] = markdown_contents.split('\n')
    
    if len(lines) < METADATA_LINES_NUM:
        print(f"Metadata must be {METADATA_LINES_NUM} lines long.")
    
    return {
        "title": lines[0].rstrip(),
        "date": lines[1].rstrip().split(DATE_SEPARATOR),
        "id": lines[2].rstrip(),
        "hero-background": lines[3].rstrip(),
        "quote": lines[4].rstrip(),
        "quote-author": lines[5].rstrip(),
        "main-tag": lines[6].rstrip(),
        "alt-tag": lines[7].rstrip()
    }


def convert_markdown_to_html(template: str, markdown_content: str) -> str:
    """
    convert_markdown_to_html
    ------------
    Converts a devlog in Markdown format to HTML.

    :param str template: The template to use
    :param str markdown_content: The markdown to convert
    :return str: The devlog, in HTML format
    """
    
    attrs: dict[str, str | list[str]] = _get_attributes(markdown_content)
    
    title: str = attrs['title']
    unique_id: int = int(attrs['id'])
    hero_background: int = int(attrs['hero-background'])
    date: dateclass = dateclass(int(attrs['date'][2]), int(attrs['date'][1]), int(attrs['date'][0]))
    quote: str = attrs['quote']
    quote_author: str = attrs['quote-author']
    tags: tuple[str, str] = (attrs['main-tag'], attrs['alt-tag'])
    
    if hero_background not in EXISTING_HERO_BACKGROUNDS:
        hero_background = 1
    
    html: str = markdown('\n'.join(markdown_content.split('\n')[METADATA_LINES_NUM:]))
    
    # [i] template stuff
    devlog = template.replace(
        "$(DEVLOGTITLE)", title
    ).replace(
        "$(DEVLOGID)", str(unique_id)
    ).replace(
        "$(DEVLOGDATE)", date.strftime(DATE_FORMAT)
    ).replace(
        "$(DEVLOGHERO)", f"{HERO_BACKGROUND_SELECTOR}{hero_background}" if hero_background != 1 else DEFAULT_HERO_BACKGROUND
    ).replace(
        "$(DEVLOGQUOTE)", quote
    ).replace(
        "$(DEVLOGQUOTEAUTHOR)", quote_author
    ).replace(
        "$(DEVLOGTAG1)", tags[0]
    ).replace(
        "$(DEVLOGTAG2)", tags[1]
    ).replace(
        "$(DEVLOG)", html
    )
    
    return devlog


# [*] Entry Point
if __name__ == '__main__':
    template_path: str = input("Template: ")
    devlog_path: str = input("Devlog: ")
    out_path: str = input("Output: ")
        
    with open(out_path, "w", encoding="utf-8") as of:
        with open(devlog_path, "r", encoding="utf-8") as df:
            with open(template_path, "r", encoding="utf-8") as tf:
                of.write(convert_markdown_to_html(tf.read(), df.read()))
                
    print("Done! Don't forget to manually review the devlog output.")
