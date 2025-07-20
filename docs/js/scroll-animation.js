// Animation for scroll ig
const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
      if (entry.isIntersecting) {
        entry.target.classList.add('scrolled-in');
      }
    });
  }, {
    threshold: 0.5
  });

  document.querySelectorAll('.under-construction').forEach(card => {
    observer.observe(card);
  });
