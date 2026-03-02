document.addEventListener("DOMContentLoaded", function () {
    const addButton = document.getElementById('addIngredient');
    const container = document.getElementById('ingredientList');

    // 1. Handle "Remove" for the first (existing) row and any future rows
    container.addEventListener('click', function (e) {
        if (e.target.classList.contains('remove-btn')) {
            // Don't delete if it's the only input left (optional)
            if (container.querySelectorAll('.input-group').length > 1) {
                e.target.closest('.input-group').remove();
                reIndexIngredients();
            } else {
                alert("A recipe needs at least one ingredient!");
            }
        }
    });

    // 2. Handle "Add"
    addButton.addEventListener('click', function () {
        const index = container.querySelectorAll('.input-group').length;

        const group = document.createElement('div');
        group.className = 'input-group mb-2';

        // The Remove button is created right here in the string:
        group.innerHTML = `
            <input type="text" name="Ingredients[${index}]" class="form-control" placeholder="Enter ingredient..." />
            <button type="button" class="btn btn-outline-danger remove-btn">Remove</button>
        `;

        container.appendChild(group);
    });

    // 3. Keep the Ingredients[n] indices sequential
    function reIndexIngredients() {
        const inputs = container.querySelectorAll('input');
        inputs.forEach((input, i) => {
            input.name = `Ingredients[${i}]`;
        });
    }
});