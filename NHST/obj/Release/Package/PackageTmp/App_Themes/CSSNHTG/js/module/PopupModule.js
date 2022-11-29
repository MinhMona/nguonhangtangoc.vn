
export default function PopupModule() {
  const humbergerBtn = document.querySelector(".hamburger-btn");
  const mainMenu = document.querySelector(".main-menu");
  const overlay = document.querySelector(".overlay");
  const notify = document.getElementById("notify");
  const arrowDonw = document.querySelector(".arrow-down");
  const contactTable = document.querySelector(".fw-map .contacts-info");

  if (humbergerBtn) {
    humbergerBtn.addEventListener("click", () => {
      humbergerBtn.classList.add("active");
      mainMenu.classList.add("active");
    });
  }

  if (overlay) {
    overlay.addEventListener("click", () => {
      humbergerBtn.classList.remove("active");
      mainMenu.classList.remove("active");
    });
  }

  if (arrowDonw) {
    arrowDonw.addEventListener("click", () => {
      contactTable.classList.toggle("active");
    })
  }

  window.addEventListener("load", () => {
    if (notify) {
      // setTimeout(() => {
      //   notify.classList.add("active");
      // }, 1700);

      notify.querySelector(".overlay").addEventListener("click", (e) => {
        notify.classList.remove("active");
      });
      notify.querySelector("i").addEventListener("click", (e) => {
        notify.classList.remove("active");
      });
    }
  });
}
