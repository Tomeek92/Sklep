
function toggleCheck(id, currentState) {
    var productElement = document.getElementById('product-' + id);

    var newState = !JSON.parse(currentState);
    productElement.style.textDecoration = newState ? 'line-through' : 'none';

    fetch('/ShoppingList/ToggleCheck', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
        },
        body: JSON.stringify({ id: id })
    }).then(response => {
        if (!response.ok) {
            console.error('Toggle failed');
            // Reverse the UI change if the request fails
            productElement.style.textDecoration = currentState ? 'line-through' : 'none';
        }
    }).catch(error => {
        console.error('Error:', error);
        // Reverse the UI change if the request fails
        productElement.style.textDecoration = currentState ? 'line-through' : 'none';
    });
}
