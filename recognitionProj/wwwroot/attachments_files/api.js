document.getElementById('teacherHighDiplomaForm').addEventListener('submit', async function (e) {
    e.preventDefault(); // Prevent the default form submission

    // Gather the form data
    const formData = new FormData(this);

    // Send the formData directly
    const response = await fetch('/api/specialization/save', {
        method: 'POST',
        body: formData
        // No need to set headers, fetch will handle Content-Type for multipart/form-data
    });

    if (response.ok) {
        const jsonResponse = await response.json();
        console.log(jsonResponse);
        // Update the page as needed without leaving it
    } else {
        console.error('Error submitting form');
    }
});
