
    async function updateHighDiplomaColor() {
        try {
            // Fetch the specialization data by type
            const response = await fetch('/api/specialization/get-by-type/High Diploma');
    if (!response.ok) {
                // No specialization found yet or an error occurred
                return;
            }

    const data = await response.json();

            // Assuming the first returned specialization is the one we want
            if (data.length > 0) {
                const specialization = data[0];
    // specialization.Color holds 0,1,2
    let colorVal = specialization.color;
    const indicator = document.getElementById('highDiplomaColorIndicator');

    // Set the background color based on the value
    switch (colorVal) {
                    case 0:
    indicator.style.backgroundColor = 'red';
    break;
    case 1:
    indicator.style.backgroundColor = 'orange';
    break;
    case 2:
    indicator.style.backgroundColor = 'green';
    break;
    default:
    indicator.style.backgroundColor = 'transparent';
    break;
                }
            }
        } catch (error) {
        console.error('Error fetching specialization data:', error);
        }
    }

    // Call this function after the page loads or after form submission
    document.addEventListener('DOMContentLoaded', updateHighDiplomaColor);

// If you want to update the color indicator after the form submission:
// 1. Add an event listener to the form 'submit' event.
// 2. After submitting (and presumably after processing), call updateHighDiplomaColor again.
// But since the main code runs in a loop (as per your Program.cs), you might adjust the timing as needed.
