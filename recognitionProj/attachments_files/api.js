document.getElementById('teacherHighDiplomaForm').addEventListener('submit', async function (e) {
    e.preventDefault(); // Prevent the default form submission

    // Gather the form data
    const formData = new FormData(this);

    // Convert formData to a plain object if needed
    // Or send directly if the API accepts form-data
    // For JSON, you'd convert formData to a JS object and then to JSON.
    let object = {};
    formData.forEach((value, key) => { object[key] = value });

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
        // Update the page as needed without leaving it
    } else {
        console.error('Error submitting form');
    }
});