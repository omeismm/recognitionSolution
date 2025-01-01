document.addEventListener('DOMContentLoaded', () => {
    const institutionId = localStorage.getItem('InsID');
    if (!institutionId) {
        console.warn("No Institution ID found. Redirecting to login...");
        window.location.href = "/login.html";
        return;
    }

    const fileUploadForm = document.querySelector('.form-container');
    fileUploadForm.addEventListener('submit', async (e) => {
        e.preventDefault(); // Prevent the default form submission

        const formData = new FormData(fileUploadForm); // Collect all form data
        try {
            const response = await fetch('/api/generalinfo/upload_all', {
                method: 'POST',
                body: formData,
                headers: {
                    'InstitutionID': institutionId,
                },
            });

            if (response.ok) {
                const result = await response.json();
                alert('Files uploaded successfully!');
                console.log(result);
            } else {
                const error = await response.json();
                alert(`Error: ${error.message}`);
            }
        } catch (error) {
            console.error('Error uploading files:', error);
            alert('An error occurred while uploading files. Please try again.');
        }
    });
});
