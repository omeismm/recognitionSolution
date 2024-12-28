document.getElementById('HighDiplomaForm').addEventListener('submit', async function (e) {
    e.preventDefault(); // Prevent the default form submission

    // Gather the form data into an object
    const formData = new FormData(this);
    let object = {};
    formData.forEach((value, key) => {
        object[key] = value;
    });

    // Send as JSON since [FromBody] expects JSON
    const response = await fetch('/api/specialization/save', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(object)
    });

    if (response.ok) {
        const jsonResponse = await response.json();
        console.log(jsonResponse);

        // Show a popup with an emoji indicating the color
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

        alert(message);
    } else {
        console.error('Error submitting form');
        alert('Error submitting form because of' + response.statusText);
    }
});
document.getElementById('DoctorateForm').addEventListener('submit', async function (e) {
    e.preventDefault(); // Prevent the default form submission

    // Gather the form data into an object
    const formData = new FormData(this);
    let object = {};
    formData.forEach((value, key) => {
        object[key] = value;
    });

    // Send as JSON since [FromBody] expects JSON
    const response = await fetch('/api/specialization/save', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(object)
    });

    if (response.ok) {
        const jsonResponse = await response.json();
        console.log(jsonResponse);

        // Show a popup with an emoji indicating the color
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

        alert(message);
    } else {
        console.error('Error submitting form');
        alert('Error submitting form because of' + response.statusText);
    }
});

