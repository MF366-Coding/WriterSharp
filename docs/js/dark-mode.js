// User preference
const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
document.body.classList.add(prefersDark ? 'dark-mode' : 'light-mode');

// dark mode - light mode toggle
const toggle = document.getElementById('mode-toggle');
toggle.addEventListener('click', () => {
  document.body.classList.toggle('dark-mode');
});
