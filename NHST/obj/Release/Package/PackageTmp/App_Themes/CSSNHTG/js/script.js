// import PopupModule from "./module/PopupModule.js";
// import ScrollModule from "./module/ScrollModule.js";

const afterDOMLoaded = () => {
  PopupModule();
  ScrollModule();
}
// afterDOMLoaded();
if (document.readyState === "loading") {
  document.addEventListener("DOMContentLoaded", afterDOMLoaded);
} else {
  afterDOMLoaded();
}