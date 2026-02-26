// This wrapper ensures the HTML is fully loaded first
document.addEventListener('DOMContentLoaded', () => {

    const checkboxes = document.querySelectorAll('input[type="checkbox"]');

    checkboxes.forEach(checkbox => {
        checkbox.addEventListener('change', async function () {
            const toDoId = this.dataset.id;
            const isChecked = this.checked;

            try {
                const response = await fetch(`/Todo/ToggleCompletion/${toDoId}`, { method: 'POST' });

                if (response.ok) {
                    const data = await response.json();

                    const statusSpan = document.querySelector(`span[data-id="${toDoId}"]`);
                    if (statusSpan) {
                        statusSpan.innerText = isChecked ? "Completed" : "Pending";
                    }

                    showFadingMessage(data.message || "Updated!");
                }
            } catch (error) {
                console.error("ERROR: ", error);
                this.checked = !isChecked;
            }
        });
    });
});

function showFadingMessage(text) {
    const msgBox = document.getElementById('status-message');
    if (!msgBox) return; 

    msgBox.innerText = text;
    msgBox.classList.add('show');

    setTimeout(() => {
        msgBox.classList.remove('show');
    }, 2000);
}