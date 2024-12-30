document.addEventListener('DOMContentLoaded', () => {
    // 1. Get the Institution ID from localStorage
    const institutionId = localStorage.getItem('InsID');
    if (!institutionId) {
        console.warn("No Institution ID found. Redirecting to login...");
        window.location.href = "/login.html";
        return;
    }

    // 2. Select relevant DOM elements
    const fileUploadForm = document.getElementById('fileUploadForm');
    const filesTableBody = document.querySelector('table.FilesGRD tbody');

    /**
     * 3. Fetch the list of files from the server
     *    /api/infrastructurepics/list
     *    The server will return JSON with an array of files, each having:
     *       {
     *         Name: "FileName.pdf", 
     *         Subject: "Subject from file name", 
     *         Path: "/uploads/{institutionId}/infrastructurepics/FileName.pdf",
     *         DeletePath: "/api/infrastructurepics/delete?filePath=/uploads/{institutionId}/infrastructurepics/FileName.pdf"
     *       }
     */
    async function loadFiles() {
        try {
            const response = await fetch('/api/infrastructurepics/list', {
                headers: { 'InstitutionID': institutionId },
            });
            if (!response.ok) {
                console.error('Failed to fetch files:', response.statusText);
                return;
            }

            const data = await response.json();
            filesTableBody.innerHTML = "";

            // If there are no files, show "No Data Found!"
            if (!data.files || data.files.length === 0) {
                filesTableBody.innerHTML = "<tr><td colspan='6'>No Data Found!</td></tr>";
                return;
            }

            // 4. For each file in the response, build a table row
            data.files.forEach((file, index) => {
                /*
                  Each file object has:
                    file.Name       => "01_CH1 - Control Systems Basics, tst.pdf"
                    file.Subject    => "tst"  (extracted from filename)
                    file.Path       => "/uploads/9999/infrastructurepics/01_CH1 - Control Systems Basics, tst.pdf"
                    file.DeletePath => "/api/infrastructurepics/delete?filePath=/uploads/9999/infrastructurepics/01_CH1 - Control Systems Basics, tst.pdf"
                */
                const fileName = file.name || "Unknown";
                const subject = file.subject || "N/A";
                const viewOrDownloadURL = file.path || "#";
                const deleteURL = file.deletePath || "#";

                // Create a new row
                const tr = document.createElement('tr');
                tr.innerHTML = `
                    <td>${index + 1}</td>
                    <td>${subject}</td>
                    <td>${fileName}</td>
                    <!-- "View" opens the file URL in a new tab -->
                    <td><a href="${viewOrDownloadURL}" target="_blank">View</a></td>
                    <!-- "Download" uses the same URL but triggers a download -->
                    <td><a href="${viewOrDownloadURL}" download>Download</a></td>
                    <!-- "Delete" button sends DELETE to file.DeletePath -->
                    <td>
                      <button data-file="${deleteURL}" class="delete-btn btn btn-danger btn-sm">
                        Delete
                      </button>
                    </td>
                `;
                filesTableBody.appendChild(tr);
            });
        } catch (error) {
            console.error('Error loading files:', error);
        }
    }

    /**
     * 5. Handle file uploads
     *    POST /api/infrastructurepics/upload
     *    with the file and subject in FormData
     */
    fileUploadForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const formData = new FormData(fileUploadForm);

        try {
            const response = await fetch('/api/infrastructurepics/upload', {
                method: 'POST',
                body: formData,
                headers: {
                    'InstitutionID': institutionId,
                },
            });

            if (response.ok) {
                alert('File uploaded successfully!');
                // Reload the file list to show the new file
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
     * 6. Handle file deletion clicks
     *    DELETE /api/infrastructurepics/delete?filePath=...
     */
    filesTableBody.addEventListener('click', async (e) => {
        if (e.target.classList.contains('delete-btn')) {
            const deletePath = e.target.dataset.file; // e.g. "/api/infrastructurepics/delete?filePath=/uploads/9999/infrastructurepics/SomeFile.pdf"
            console.log("Attempting to DELETE file at:", deletePath);

            try {
                const response = await fetch(deletePath, { method: 'DELETE' });
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

    // 7. Load the files for the first time
    loadFiles();
});
