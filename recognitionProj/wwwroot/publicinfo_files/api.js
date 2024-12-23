// File: publicinfo_files/api.js

document.addEventListener('DOMContentLoaded', function () {
    const publicInfoForm = document.getElementById('publicInfoForm');

    if (!publicInfoForm) return; // Safety check if the form isn't found

    publicInfoForm.addEventListener('submit', async function (event) {
        event.preventDefault(); // Prevent default form submission (page reload)

        // Gather all field values
        const insID = parseInt(document.getElementById('InsID').value) || 0;
        const insName = document.getElementById('InsName').value || '';
        const provider = document.getElementById('Provider').value || '';
        const startDate = document.getElementById('StartDate').value || '';
        const sDateT = document.getElementById('SDateT').value || '';
        const sDateNT = document.getElementById('SDateNT').value || '';

        const supervisorIDValue = document.getElementById('SupervisorID').value;
        const supervisorID = supervisorIDValue ? parseInt(supervisorIDValue) : null;
        const supervisor = document.getElementById('Supervisor').value || '';

        const preName = document.getElementById('PreName').value || '';
        const preDegree = document.getElementById('PreDegree').value || '';
        const preMajor = document.getElementById('PreMajor').value || '';

        const postal = document.getElementById('Postal').value || '';
        const phone = document.getElementById('Phone').value || '';
        const fax = document.getElementById('Fax').value || '';
        const email = document.getElementById('Email').value || '';
        const website = document.getElementById('Website').value || '';

        const vision = document.getElementById('Vision').value || '';
        const mission = document.getElementById('Mission').value || '';
        const goals = document.getElementById('Goals').value || '';
        const insValues = document.getElementById('InsValues').value || '';
        const lastEditDate = document.getElementById('LastEditDate').value || '';

        // These are DateOnly in your C# model, so we pass them as standard yyyy-MM-dd strings
        const entryDate = document.getElementById('EntryDate').value || '';
        const country = document.getElementById('Country').value || '';
        const city = document.getElementById('City').value || '';
        const address = document.getElementById('Address').value || '';
        const creationDate = document.getElementById('CreationDate').value || '';
        const studentAcceptanceDate = document.getElementById('StudentAcceptanceDate').value || '';
        const otherInfo = document.getElementById('OtherInfo').value || '';

        // Prepare the object matching your PublicInfo class structure
        const publicInfo = {
            insID,
            insName,
            provider,
            startDate,
            sDateT,
            sDateNT,
            supervisorID,
            supervisor,
            preName,
            preDegree,
            preMajor,
            postal,
            phone,
            fax,
            email,
            website,
            vision,
            mission,
            goals,
            insValues,
            lastEditDate,
            entryDate,             // string in "yyyy-MM-dd" format
            country,
            city,
            address,
            creationDate,          // string in "yyyy-MM-dd" format
            studentAcceptanceDate, // string in "yyyy-MM-dd" format
            otherInfo
        };

        // Debug: see the data before sending
        console.log("publicInfo to be sent:", publicInfo);

        try {
            // Make the POST request
            const rawResponse = await fetch('/api/publicinfo/save', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(publicInfo)
            });

            // Log the raw response to see status, headers, etc.
            console.log("Raw fetch response:", rawResponse);

            if (!rawResponse.ok) {
                // Attempt to parse the JSON error response
                const errorData = await rawResponse.json();
                console.error('Error saving PublicInfo:', errorData);
                alert(`Error: ${errorData.message || 'Unable to save public information.'}`);
                return;
            }

            // Parse the success response
            const result = await rawResponse.json();
            console.log("Parsed JSON response:", result);

            // Show success message
            alert(`Success: ${result.message}`);

            // Optionally reset or redirect
            // publicInfoForm.reset();

        } catch (error) {
            console.error('Network error or server not reachable:', error);
            alert(`Network error: ${error.message}`);
        }
    });
});
