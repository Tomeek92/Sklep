document.getElementById('addForm').addEventListener('submit', function (event) {
    var plannedDateInput = document.getElementById('PlannedDate');
    var plannedDate = new Date(plannedDateInput.value);
    var today = new Date();

    // Ustawienie godziny na 00:00:00, aby porównywać tylko datę
    today.setHours(0, 0, 0, 0);

    if (plannedDate < today) {
        event.preventDefault(); // Zatrzymuje wysłanie formularza
        document.getElementById('dateError').textContent = 'Data nie może być z przeszłości!';
    } else {
        document.getElementById('dateError').textContent = '';
    }
});
