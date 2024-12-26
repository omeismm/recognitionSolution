// File: login_files/api.js

document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('loginForm');
    if (!loginForm) return;

    loginForm.addEventListener('submit', async function (event) {
        event.preventDefault();

        const email = document.getElementById('email').value.trim();
        const password = document.getElementById('password').value;
        const verificationCode = document.getElementById('verificationCode').value.trim();

        // Optional: basic front-end validation
        if (!email || !password || !verificationCode) {
            showError("Email, password, and verification code cannot be empty.");
            return;
        }

        try {
            const response = await fetch('/api/users/login', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ email, password, verificationCode })
            });

            if (!response.ok) {
                // If status = 401 => Unauthorized, or 400 => BadRequest
                const errorData = await response.json();
                showError(errorData.message || "Login failed.");
                return;
            }

            const data = await response.json();
            if (!data.success) {
                showError(data.message || "Login failed.");
                return;
            }

            // success => data.insID, data.insName, etc.
            console.log("Login success:", data);

            // Store insID and other relevant data in localStorage (or sessionStorage) to share across pages
            localStorage.setItem('InsID', data.insID);
            localStorage.setItem('InsName', data.insName);
            localStorage.setItem('Clearance', data.clearance);
            localStorage.setItem('Speciality', data.speciality);
            localStorage.setItem('InsCountry', data.insCountry);
            localStorage.setItem('Verified', data.verified);

            // Redirect to Public Info or wherever
            window.location.href = "/publicinfo.html";
        }
        catch (err) {
            console.error("Network or server error:", err);
            showError("Cannot connect to the server. Please try again.");
        }
    });

    function showError(msg) {
        const loginError = document.getElementById('loginError');
        loginError.style.display = 'block';
        loginError.innerText = msg;
    }
});
