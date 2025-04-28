 /*
  *    _                 
  *   /_\    _ __   _ __ 
  *  / _ \  | '_ \ | '_ \
  * /_/ \_\ | .__/ | .__/
  *         |_|    |_|   
  *         
  * MIT License * MF366
  *         
  */


// Avalonia
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;


namespace WriterSharp
{

    public partial class App : Application
    {

        public override void Initialize()
        {

            AvaloniaXamlLoader.Load(this);

        }

        public override void OnFrameworkInitializationCompleted()

        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {

                desktop.MainWindow = new MainWindow();

            }

            base.OnFrameworkInitializationCompleted();

        }

    }

}
