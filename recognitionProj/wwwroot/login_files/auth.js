// File: login_files/auth.js

document.addEventListener('DOMContentLoaded', () => {
    // 1. Check if InsID exists in localStorage
    const storedInsID = localStorage.getItem('InsID');
    if (!storedInsID) {
        // If no InsID is found, redirect to login
        console.warn("No InsID found in localStorage. Redirecting to login...");
        window.location.href = "/login.html";
        return; // Stop further execution
    }

    // 2. If the page has an InsID field, set its value
    const insIDField = document.getElementById('InsID');
    if (insIDField) {
        insIDField.value = storedInsID;
    }

    // 3. Attach logout handler
    const logoutLink = document.getElementById('lnkLogout');
    if (logoutLink) {
        logoutLink.addEventListener('click', function (e) {
            e.preventDefault();
            // Clear all stored data
            localStorage.removeItem('InsID');
            localStorage.removeItem('InsName');
            localStorage.removeItem('Clearance');
            localStorage.removeItem('Speciality');
            localStorage.removeItem('InsCountry');
            localStorage.removeItem('Verified');

            // Redirect to login page
            window.location.href = "/login.html";
        });
    }
});
