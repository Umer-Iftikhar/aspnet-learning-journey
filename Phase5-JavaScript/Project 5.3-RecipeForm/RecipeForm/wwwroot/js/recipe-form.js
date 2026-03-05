

document.addEventListener("DOMContentLoaded", function () {
    const container = document.getElementById('ingredientList');
    const addButton = document.querySelector("#addIngredient");

    //Defining reindexing logic
    function reindexIngredients() {
        const inputs = container.querySelectorAll('.input-group input');
        inputs.forEach((input, index) => {
            input.name = `Ingredients[${index}]`;
        });
    }


    //Add ingredients handler
    addButton.addEventListener('click', function () {
        const firstGroup = container.querySelector('.input-group');
        const clonedGroup = firstGroup.cloneNode(true);
        const clonedInput = clonedGroup.querySelector('input');
        clonedInput.value = '';
        
        const currentIndex = container.querySelectorAll('.input-group').length;
        clonedInput.name = `Ingredients[${currentIndex}]`;
        container.appendChild(clonedGroup);
        reindexIngredients();
    });

    //Remove ingredients handler
    container.addEventListener('click', function (event) {
        if (event.target.classList.contains('remove-btn')) {
            const parentDiv = event.target.closest('.input-group');
            parentDiv.remove();
            reindexIngredients();
        }
    });
});