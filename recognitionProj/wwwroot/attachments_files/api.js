document.addEventListener('DOMContentLoaded', () => {
    const institutionId = localStorage.getItem('InsID');
    if (!institutionId) {
        console.warn("No Institution ID found. Redirecting to login...");
        window.location.href = "/login.html";
        return;
    }

    const fileUploadForm = document.getElementById('fileUploadForm');
    const filesTableBody = document.querySelector('table.FilesGRD tbody');

    /**
     * Fetch and display the list of uploaded files.
     */
    const loadFiles = async () => {
        try {
            const response = await fetch('/api/attachments/list', {
                headers: { 'InstitutionID': institutionId },
            });

            if (!response.ok) {
                console.error('Failed to fetch files:', response.statusText);
                return;
            }

            const data = await response.json();
            filesTableBody.innerHTML = "";

            if (!data.files || data.files.length === 0) {
                filesTableBody.innerHTML = "<tr><td colspan='6'>No Data Found!</td></tr>";
                return;
            }

            data.files.forEach((file, index) => {
                const tr = document.createElement('tr');
                tr.innerHTML = `
                    <td>${index + 1}</td>
                    <td>${file.Subject || 'N/A'}</td>
                    <td>${file.Name}</td>
                    <td><a href="${file.Path}" target="_blank">View</a></td>
                    <td><a href="${file.Path}" download>Download</a></td>
                    <td><button data-file="${file.Path}" class="delete-btn btn btn-danger btn-sm">Delete</button></td>
                `;
                filesTableBody.appendChild(tr);
            });
        } catch (error) {
            console.error('Error loading files:', error);
        }
    };

    /**
     * Handle file upload.
     */
    fileUploadForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        const formData = new FormData(fileUploadForm);
        try {
            const response = await fetch('/api/attachments/upload', {
                method: 'POST',
                body: formData,
                headers: {
                    'InstitutionID': institutionId,
                },
            });

            if (response.ok) {
                alert('File uploaded successfully!');
                loadFiles();
            } else {
                const error = await response.json();
                alert(`Error uploading file: ${error.message}`);
            }
        } catch (error) {
            console.error('Error uploading file:', error);
        }
    });

    /**
     * Handle file deletion.
     */
    filesTableBody.addEventListener('click', async (e) => {
        if (e.target.classList.contains('delete-btn')) {
            const filePath = e.target.dataset.file;
            try {
                const response = await fetch(`/api/attachments/delete?filePath=${encodeURIComponent(filePath)}`, {
                    method: 'DELETE',
                });

                if (response.ok) {
                    alert('File deleted successfully!');
                    loadFiles();
                } else {
                    const error = await response.json();
                    alert(`Error deleting file: ${error.message}`);
                }
            } catch (error) {
                console.error('Error deleting file:', error);
            }
        }
    });

    // Initial load of files.
    loadFiles();
});
