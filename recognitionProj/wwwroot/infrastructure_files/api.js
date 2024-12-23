// File: infrastructure_files/api.js

document.addEventListener('DOMContentLoaded', function () {
    const infrastructureForm = document.getElementById('infrastructureForm');
    if (!infrastructureForm) return; // Safety check if the form doesn't exist on the page

    infrastructureForm.addEventListener('submit', async function (event) {
        event.preventDefault(); // Prevent the default form submission (page reload)

        // 1. Gather all field values from the form
        const insIDValue = document.getElementById('InsID').value;
        const insID = insIDValue ? parseInt(insIDValue) : 0; // Required field, default 0 if blank

        // Optional numeric fields; default to null if blank
        const areaValue = document.getElementById('Area').value;
        const area = areaValue ? parseInt(areaValue) : null;

        const sitesValue = document.getElementById('Sites').value;
        const sites = sitesValue ? parseInt(sitesValue) : null;

        const terrValue = document.getElementById('Terr').value;
        const terr = terrValue ? parseInt(terrValue) : null;

        const hallsValue = document.getElementById('Halls').value;
        const halls = hallsValue ? parseInt(hallsValue) : null;

        const libraryValue = document.getElementById('Library').value;
        const library = libraryValue ? parseInt(libraryValue) : null;

        // Optional string fields
        const labsAttach = document.getElementById('LabsAttach').value || '';
        const build = document.getElementById('Build').value || '';

        // 2. Prepare an object matching the C# Infrastructure model
        const infrastructureInfo = {
            insID,
            area,
            sites,
            terr,
            halls,
            library,
            labsAttach,
            build
        };

        // Debug: Log the object to the console before sending
        console.log("infrastructureInfo to be sent:", infrastructureInfo);

        try {
            // 3. Send a POST request to the API endpoint
            const rawResponse = await fetch('/api/infrastructure/save', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(infrastructureInfo)
            });

            // 4. Log the raw response to see status, headers, etc.
            console.log("Raw fetch response:", rawResponse);

            if (!rawResponse.ok) {
                // Attempt to parse and show the error response
                const errorData = await rawResponse.json();
                console.error('Error saving Infrastructure info:', errorData);
                alert(`Error: ${errorData.message || 'Unable to save infrastructure information.'}`);
                return;
            }

            // 5. Parse the success response
            const result = await rawResponse.json();
            console.log("Parsed JSON response:", result);

            // 6. Display success message
            alert(`Success: ${result.message}`);

            // Optionally reset the form or navigate away
            // infrastructureForm.reset();
        } catch (error) {
            // Network or server unreachable
            console.error('Network error or server not reachable:', error);
            alert(`Network error: ${error.message}`);
        }
    });
});
