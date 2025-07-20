/* Page Countdown */
document.addEventListener('DOMContentLoaded', () => {
  const timer = document.getElementById('timer');
  const releaseDate = new Date('2026-06-12T00:00:00'); // target date right here bud

  function updateCountdown() {
    const now = new Date(); // new Date("wtf")
    const distance = releaseDate - now;

    if (distance <= 0) {
      timer.textContent = "Released!";
      return;
    }

    const days = Math.floor(distance / (1000 * 60 * 60 * 24));
    const hours = Math.floor((distance / (1000 * 60 * 60)) % 24);
    const minutes = Math.floor((distance / (1000 * 60)) % 60);
    const seconds = Math.floor((distance / 1000) % 60);

    timer.textContent = `${days}d ${hours}h ${minutes}m ${seconds}s`;
  }

  setInterval(updateCountdown, 1000);
});
