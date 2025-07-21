// constants
const toggle = document.getElementById('mode-toggle');
const icon = toggle.querySelector('i');
const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;

// user preference
document.body.classList.add(prefersDark ? 'dark-mode' : 'light-mode');
if (document.body.classList.contains('dark-mode')) {
  icon.classList.remove('nf-md-weather_night');
  icon.classList.add('nf-oct-sun');
}
else {
  icon.classList.remove('nf-oct-sun');
  icon.classList.add('nf-md-weather_night');
}

// dark mode - light mode toggle
toggle.addEventListener('click', () => {
  document.body.classList.toggle('dark-mode');

  if (document.body.classList.contains('dark-mode')) {
    icon.classList.remove('nf-md-weather_night');
    icon.classList.add('nf-oct-sun');
  }
  else {
    icon.classList.remove('nf-oct-sun');
    icon.classList.add('nf-md-weather_night');
  }
});
