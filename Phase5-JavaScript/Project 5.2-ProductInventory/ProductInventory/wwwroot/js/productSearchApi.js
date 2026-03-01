document.addEventListener("DOMContentLoaded", async function () {
    const searchInput = document.querySelector("#productSearchApi");
  

    searchInput.addEventListener("input", async function () {
        const productsTable = document.querySelector("#tableId");
        const query = searchInput.value;

        const response = await fetch("/api/products/search?query=" + query);
        const products = await response.json();

        let html = "";
        if (products.length === 0) {
            html = "<tr><td colspan='5'>No products found.</td></tr>";
        }
        else

        {
            products.forEach(function (product) {
            console.log(product);
          
            html += `<tr style="${product.stock < 5 ? 'background-color:yellow;' : ''}">
                <td>${product.name}</td>
                <td>${product.price}</td>
                <td>${product.stock}</td>
                <td>${product.categoryId}</td>
                <td>
                    <a href="/Product/Edit/${product.id}">Edit</a> |
                    <a href="/Product/Delete/${product.id}">Delete</a>
                </td>
            </tr>`;
            });
        }
        productsTable.innerHTML = html;
    });
});
