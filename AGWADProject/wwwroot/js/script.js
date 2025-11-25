function toggleFilters() {
  let searchBox = document.getElementById("searchBox");
  let extraFilters = document.getElementById("extraFilters");

  if (searchBox.classList.contains("expanded")) {
      searchBox.classList.remove("expanded");
      extraFilters.classList.remove("visible");
  } else {
      searchBox.classList.add("expanded");
      extraFilters.classList.add("visible");
  }
}