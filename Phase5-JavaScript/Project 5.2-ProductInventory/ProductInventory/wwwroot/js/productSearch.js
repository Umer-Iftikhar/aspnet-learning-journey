
document.addEventListener("DOMContentLoaded", async function () {
    const searchInput = document.querySelector("#productSearch");
    const productsTable = document.querySelector("#searchResults");

    searchInput.addEventListener("input", async function () {
        console.log("typing detected");
        const query = searchInput.value;
        console.log("query: '" + query + "'");

        const response = await fetch("/Product/Search?query=" + query);
        const html = await response.text();
        productsTable.innerHTML = html;
    });
});