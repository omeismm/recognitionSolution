document.getElementById('teacherHighDiplomaForm').addEventListener('submit', async function (e) {
    e.preventDefault(); // Prevent the default form submission

    const formData = new FormData(this);

    const response = await fetch('/api/specialization/save', {
        method: 'POST',
        body: formData
    });

    if (response.ok) {
        const jsonResponse = await response.json();
        console.log(jsonResponse);

        // Show a popup with the corresponding color
        let message;
        switch (jsonResponse.color) {
            case 0:
                message = "🔴 The ratio result is RED";
                break;
            case 1:
                message = "🟠 The ratio result is ORANGE";
                break;
            case 2:
                message = "🟢 The ratio result is GREEN";
                break;
            default:
                message = "⚪ No color determined";
                break;
        }

        alert(message); // Display the popup
    } else {
        console.error('Error submitting form');
        alert('Error submitting form');
    }
});
