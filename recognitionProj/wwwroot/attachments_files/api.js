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
        console.log("Fetching files for Institution ID:", institutionId);
        try {
            const response = await fetch('/api/attachments/list', {
                headers: { 'InstitutionID': institutionId },
            });

            if (!response.ok) {
                console.error('Failed to fetch files. Status:', response.status, response.statusText);
                return;
            }

            const data = await response.json();
            console.log("Files received from server:", data);

            filesTableBody.innerHTML = "";

            if (!data.files || data.files.length === 0) {
                console.warn("No files found for Institution ID:", institutionId);
                filesTableBody.innerHTML = "<tr><td colspan='6'>No Data Found!</td></tr>";
                return;
            }

            data.files.forEach((file, index) => {
                console.log(`Processing file #${index + 1}:`, file);

                const fileName = file.Name || "Unknown";
                const subject = file.Subject || "N/A";
                const path = file.Path || "#";

                const tr = document.createElement('tr');
                tr.innerHTML = `
                    <td>${index + 1}</td>
                    <td>${subject}</td>
                    <td>${fileName}</td>
                    <td><a href="${path}" target="_blank">View</a></td>
                    <td><a href="${path}" download>Download</a></td>
                    <td><button data-file="${path}" class="delete-btn btn btn-danger btn-sm">Delete</button></td>
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

        console.log("Uploading file...");
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
                const result = await response.json();
                console.log("File uploaded successfully:", result);
                alert('File uploaded successfully!');
                loadFiles();
            } else {
                const error = await response.json();
                console.error('Error uploading file:', error);
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
            console.log("Deleting file:", filePath);

            try {
                const response = await fetch(`/api/attachments/delete?filePath=${encodeURIComponent(filePath)}`, {
                    method: 'DELETE',
                });

                if (response.ok) {
                    console.log("File deleted successfully:", filePath);
                    alert('File deleted successfully!');
                    loadFiles();
                } else {
                    const error = await response.json();
                    console.error('Error deleting file:', error);
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
