// File: academicinfo_files/api.js

document.addEventListener('DOMContentLoaded', function () {
    const academicInfoForm = document.getElementById('academicInfoForm');

    if (!academicInfoForm) return; // Safety check

    academicInfoForm.addEventListener('submit', async function (event) {
        event.preventDefault(); // Prevent the default form submission

        // Gather form field values
        const insID = parseInt(document.getElementById('InsID').value) || 0;
        const insTypeID = parseInt(document.getElementById('InsTypeID').value) || null;
        const insType = document.getElementById('InsType').value || '';
        const highEduRec = parseInt(document.getElementById('HighEdu_Rec').value) || null;
        const qualityDeptRec = parseInt(document.getElementById('QualityDept_Rec').value) || null;
        const studyLangCitizen = document.getElementById('StudyLangCitizen').value || '';
        const studyLangInter = document.getElementById('StudyLangInter').value || '';
        const jointClass = parseInt(document.getElementById('JointClass').value) || null;
        const studySystem = document.getElementById('StudySystem').value || '';
        const minHours = parseInt(document.getElementById('MinHours').value) || null;
        const maxHours = parseInt(document.getElementById('MaxHours').value) || null;
        const researchScopus = document.getElementById('ResearchScopus').value || '';
        const researchOthers = document.getElementById('ResearchOthers').value || '';
        const practicing = parseInt(document.getElementById('Practicing').value) || null;
        const studyAttendance = parseInt(document.getElementById('StudyAttendance').value) || null;
        const studentsMove = parseInt(document.getElementById('StudentsMove').value) || null;
        const studyAttendanceDesc = document.getElementById('StudyAttendanceDesc').value || '';
        const studentsMoveDesc = document.getElementById('StudentsMoveDesc').value || '';
        const distanceLearning = parseInt(document.getElementById('DistanceLearning').value) || null;
        const maxHoursDL = parseInt(document.getElementById('MaxHoursDL').value) || null;
        const maxYearsDL = parseInt(document.getElementById('MaxYearsDL').value) || null;
        const maxSemsDL = parseInt(document.getElementById('MaxSemsDL').value) || null;
        const diploma = parseInt(document.getElementById('Diploma').value) || null;
        const diplomaTest = parseInt(document.getElementById('DiplomaTest').value) || null;
        const hoursPercentage = parseInt(document.getElementById('HoursPercentage').value) || null;
        const educationType = document.getElementById('EducationType').value || '';

        // Split text fields (AvailableDegrees, Faculties) into arrays
        const availableDegreesText = document.getElementById('AvailableDegrees').value || '';
        const availableDegrees = availableDegreesText
            .split(',')
            .map(deg => deg.trim())
            .filter(deg => deg.length > 0);

        const facultiesText = document.getElementById('Faculties').value || '';
        const faculties = facultiesText
            .split(',')
            .map(fac => fac.trim())
            .filter(fac => fac.length > 0);

        const arwuRank = parseInt(document.getElementById('ARWURank').value) || 0;
        const theRank = parseInt(document.getElementById('THERank').value) || 0;
        const qsRank = parseInt(document.getElementById('QSRank').value) || 0;
        const otherRank = document.getElementById('OtherRank').value || '';
        const numOfScopusResearches = parseInt(document.getElementById('NumOfScopusResearches').value) || 0;

        // Convert "2024-01-15" -> 20240115 to match the model's int field for ScopusFrom/ScopusTo
        let scopusFromString = document.getElementById('ScopusFrom').value;
        let scopusFrom = 0;
        if (scopusFromString) {
            scopusFrom = parseInt(scopusFromString.replace(/-/g, ''));
            if (isNaN(scopusFrom)) scopusFrom = 0;
        }

        let scopusToString = document.getElementById('ScopusTo').value;
        let scopusTo = 0;
        if (scopusToString) {
            scopusTo = parseInt(scopusToString.replace(/-/g, ''));
            if (isNaN(scopusTo)) scopusTo = 0;
        }

        const infrastructure = document.getElementById('Infrastructure').value || '';

        // Checkbox is disabled, so user can't change it. Adjust logic if needed.
        const accepted = document.getElementById('Accepted').checked;

        // Prepare the object to send in the POST request
        const academicInfo = {
            insID,
            insTypeID,
            insType,
            highEdu_Rec: highEduRec,
            qualityDept_Rec: qualityDeptRec,
            studyLangCitizen,
            studyLangInter,
            jointClass,
            studySystem,
            minHours,
            maxHours,
            researchScopus,
            researchOthers,
            practicing,
            studyAttendance,
            studentsMove,
            studyAttendanceDesc,
            studentsMoveDesc,
            distanceLearning,
            maxHoursDL,
            maxYearsDL,
            maxSemsDL,
            diploma,
            diplomaTest,
            hoursPercentage,
            educationType,
            availableDegrees,
            faculties,
            arwuRank,
            theRank,
            qsRank,
            otherRank,
            numOfScopusResearches,
            scopusFrom,
            scopusTo,
            infrastructure,
            accepted
        };

        // Debug: check the data in the console before sending
        console.log("academicInfo to be sent:", academicInfo);

        try {
            // Make the POST request
            const rawResponse = await fetch('/api/academicinfo/save', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(academicInfo)
            });

            // Log the full response object to the console
            console.log("Raw fetch response:", rawResponse);

            if (!rawResponse.ok) {
                // Attempt to parse the error response
                const errorData = await rawResponse.json();
                console.error('Error saving AcademicInfo:', errorData);
                alert(`Error: ${errorData.message || 'Unable to save academic information.'}`);
                return;
            }

            // Parse the successful response as JSON
            const result = await rawResponse.json();
            // Log the parsed JSON response
            console.log("Parsed JSON response:", result);

            alert(`Success: ${result.message}`);

            // Optionally reset the form or navigate away
            // academicInfoForm.reset();

        } catch (error) {
            console.error('Network error or server not reachable:', error);
            alert(`Network error: ${error.message}`);
        }
    });
});
