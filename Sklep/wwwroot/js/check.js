
    function toggleCheck(description) {
        var productElement = document.getElementById('product-' + description);
    if (productElement.style.textDecorationLine === 'line-through') {
        productElement.style.textDecorationLine = 'none';
        } else {
        productElement.style.textDecorationLine = 'line-through';
        }
    }
