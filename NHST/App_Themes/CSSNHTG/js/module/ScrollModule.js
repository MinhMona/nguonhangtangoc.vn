export default function ScrollModule () {
  const header = document.getElementById("header");
  const mainNav = document.getElementById("main-nav");
  const truckCar = document.querySelector(".truck-animation");

  window.addEventListener("scroll", () => {
    if (scrollY > 160) {
      header.classList.add("hidden");
      truckCar.classList.add("move");
    } 
    
    if (screenY < 150) {
      header.classList.remove("hidden");
      truckCar.classList.remove("move")
    }
  });

  
}