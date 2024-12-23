// File: library_files/api.js

document.addEventListener('DOMContentLoaded', function () {
    const libraryForm = document.getElementById('libraryForm');

    if (!libraryForm) return; // Safety check if the form doesn't exist

    libraryForm.addEventListener('submit', async function (event) {
        event.preventDefault(); // Prevent default form submission (page reload)

        // 1. Collect all field values
        const insIDValue = document.getElementById('InsID').value;
        const insID = insIDValue ? parseInt(insIDValue) : 0; // Required; default to 0 if blank

        // Optional numeric fields → convert to int or null
        const areaValue = document.getElementById('Area').value;
        const area = areaValue ? parseInt(areaValue) : null;

        const capacityValue = document.getElementById('Capacity').value;
        const capacity = capacityValue ? parseInt(capacityValue) : null;

        const arBooksValue = document.getElementById('ArBooks').value;
        const arBooks = arBooksValue ? parseInt(arBooksValue) : null;

        const enBooksValue = document.getElementById('EnBooks').value;
        const enBooks = enBooksValue ? parseInt(enBooksValue) : null;

        const papersValue = document.getElementById('Papers').value;
        const papers = papersValue ? parseInt(papersValue) : null;

        const eBooksValue = document.getElementById('EBooks').value;
        const eBooks = eBooksValue ? parseInt(eBooksValue) : null;

        const eSubscriptionValue = document.getElementById('ESubscription').value;
        const eSubscription = eSubscriptionValue ? parseInt(eSubscriptionValue) : null;

        // 2. Create the object matching the C# Library model
        const libraryInfo = {
            insID,
            area,
            capacity,
            arBooks,
            enBooks,
            papers,
            eBooks,
            eSubscription
        };

        // Debug: log the data in the console before sending
        console.log("libraryInfo to be sent:", libraryInfo);

        try {
            // 3. Send a POST request to the API endpoint
            const rawResponse = await fetch('/api/library/save', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(libraryInfo)
            });

            // 4. Log the raw fetch response (status, headers, etc.)
            console.log("Raw fetch response:", rawResponse);

            if (!rawResponse.ok) {
                // Attempt to parse JSON error details
                const errorData = await rawResponse.json();
                console.error('Error saving library info:', errorData);
                alert(`Error: ${errorData.message || 'Unable to save library information.'}`);
                return;
            }

            // 5. Parse the successful response
            const result = await rawResponse.json();
            console.log("Parsed JSON response:", result);

            // 6. Show success message
            alert(`Success: ${result.message}`);

            // Optional: reset the form or redirect
            // libraryForm.reset();

        } catch (error) {
            // Network or server unreachable
            console.error('Network error or server not reachable:', error);
            alert(`Network error: ${error.message}`);
        }
    });
});
