/* PARENT & CHILD MODALS:
           1) Parent = { backdrop: 'static' } so it won’t close on outside click
           2) Child = { backdrop: false } so it doesn’t hide the parent
           3) Then wire up open/close logic
        */

// ============ Parent Modals ============
const bachelorParentModal = new bootstrap.Modal(document.getElementById('bachelorParentModal'), {
    backdrop: 'static',
    keyboard: false
});
const highDiplomaParentModal = new bootstrap.Modal(document.getElementById('highDiplomaParentModal'), {
    backdrop: 'static',
    keyboard: false
});
const mastersParentModal = new bootstrap.Modal(document.getElementById('mastersParentModal'), {
    backdrop: 'static',
    keyboard: false
});
const medicalParentModal = new bootstrap.Modal(document.getElementById('medicalParentModal'), {
    backdrop: 'static',
    keyboard: false
});

const phdParentModal = new bootstrap.Modal(document.getElementById('phdParentModal'), {
    backdrop: 'static',
    keyboard: false
});

// ============ Child Modals ============
const scientificBscModal = new bootstrap.Modal(document.getElementById('scientificBscModal'), {
    backdrop: false,
    keyboard: false
});
const humanitarianBscModal = new bootstrap.Modal(document.getElementById('humanitarianBscModal'), {
    backdrop: false,
    keyboard: false
});
const scientificPracticalBscModal = new bootstrap.Modal(document.getElementById('scientificPracticalBscModal'), {
    backdrop: false,
    keyboard: false
});
const humanitarianPracticalBscModal = new bootstrap.Modal(document.getElementById('humanitarianPracticalBscModal'), {
    backdrop: false,
    keyboard: false
});
const highDiplomaModal = new bootstrap.Modal(document.getElementById('highDiplomaModal'), {
    backdrop: false,
    keyboard: false
});
const scientificMasterModal = new bootstrap.Modal(document.getElementById('scientificMasterModal'), {
    backdrop: false,
    keyboard: false
});
const humanitarianMasterModal = new bootstrap.Modal(document.getElementById('humanitarianMasterModal'), {
    backdrop: false,
    keyboard: false
});
const scientificPracticalMasterModal = new bootstrap.Modal(document.getElementById('scientificPracticalMasterModal'), {
    backdrop: false,
    keyboard: false
});
const mainMedicalModal = new bootstrap.Modal(document.getElementById('mainMedicalModal'), {
    backdrop: false,
    keyboard: false
});
const residencyModal = new bootstrap.Modal(document.getElementById('residencyModal'), {
    backdrop: false,
    keyboard: false
});
const phdModal = new bootstrap.Modal(document.getElementById('phdModal'), {
    backdrop: false,
    keyboard: false
});

// ============ OPEN PARENT MODALS ============
document.getElementById('openBachelorBtn').addEventListener('click', () => {
    bachelorParentModal.show();
});
document.getElementById('openHighDiplomaBtn').addEventListener('click', () => {
    highDiplomaParentModal.show();
});
document.getElementById('openMastersBtn').addEventListener('click', () => {
    mastersParentModal.show();
});
document.getElementById('openMedicalBtn').addEventListener('click', () => {
    medicalParentModal.show();
});

document.getElementById('openPhdBtn').addEventListener('click', () => {
    phdParentModal.show();
});

// ============ CLOSE PARENT MODALS (X) ============
document.querySelector('.bachelorParentClose').addEventListener('click', () => {
    bachelorParentModal.hide();
});
document.querySelector('.highDiplomaParentClose').addEventListener('click', () => {
    highDiplomaParentModal.hide();
});
document.querySelector('.mastersParentClose').addEventListener('click', () => {
    mastersParentModal.hide();
});
document.querySelector('.medicalParentClose').addEventListener('click', () => {
    medicalParentModal.hide();
});

document.querySelector('.phdParentClose').addEventListener('click', () => {
    phdParentModal.hide();
});

// ============ OPEN CHILD MODALS FROM PARENT BUTTONS ============
// Bachelor
document.getElementById('openScientificBscBtn').addEventListener('click', () => {
    scientificBscModal.show();
});
document.getElementById('openHumanitarianBscBtn').addEventListener('click', () => {
    humanitarianBscModal.show();
});
document.getElementById('openScientificPracticalBscBtn').addEventListener('click', () => {
    scientificPracticalBscModal.show();
});
document.getElementById('openHumanitarianPracticalBscBtn').addEventListener('click', () => {
    humanitarianPracticalBscModal.show();
});

// High Diploma
document.getElementById('openHighDiplomaFormBtn').addEventListener('click', () => {
    highDiplomaModal.show();
});

// Masters
document.getElementById('openScientificMasterBtn').addEventListener('click', () => {
    scientificMasterModal.show();
});
document.getElementById('openHumanitarianMasterBtn').addEventListener('click', () => {
    humanitarianMasterModal.show();
});
document.getElementById('openScientificPracticalMasterBtn').addEventListener('click', () => {
    scientificPracticalMasterModal.show();
});

// Medical
document.getElementById('openMainMedicalBtn').addEventListener('click', () => {
    mainMedicalModal.show();
});

// Residency
document.getElementById('openResidencyBtn2').addEventListener('click', () => {
    residencyModal.show();
});

// PhD
document.getElementById('openPhdFormBtn').addEventListener('click', () => {
    phdModal.show();
});

// ============ CLOSE CHILD MODALS (X) ============
document.querySelector('.scientificBscClose').addEventListener('click', () => {
    scientificBscModal.hide();
});
document.querySelector('.humanitarianBscClose').addEventListener('click', () => {
    humanitarianBscModal.hide();
});
document.querySelector('.scientificPracticalBscClose').addEventListener('click', () => {
    scientificPracticalBscModal.hide();
});
document.querySelector('.humanitarianPracticalBscClose').addEventListener('click', () => {
    humanitarianPracticalBscModal.hide();
});
document.querySelector('.highDiplomaClose').addEventListener('click', () => {
    highDiplomaModal.hide();
});
document.querySelector('.scientificMasterClose').addEventListener('click', () => {
    scientificMasterModal.hide();
});
document.querySelector('.humanitarianMasterClose').addEventListener('click', () => {
    humanitarianMasterModal.hide();
});
document.querySelector('.scientificPracticalMasterClose').addEventListener('click', () => {
    scientificPracticalMasterModal.hide();
});
document.querySelector('.mainMedicalClose').addEventListener('click', () => {
    mainMedicalModal.hide();
});
document.querySelector('.residencyClose').addEventListener('click', () => {
    residencyModal.hide();
});
document.querySelector('.phdClose').addEventListener('click', () => {
    phdModal.hide();
});

// ============ FORM SUBMISSIONS (Prevent default, then hide child) ============
document.getElementById('ScientificBachelorForm').addEventListener('submit', (e) => {
    e.preventDefault();
    // handle your logic ...
    scientificBscModal.hide();
});
document.getElementById('HumanitarianBachelorRatioForm').addEventListener('submit', (e) => {
    e.preventDefault();
    humanitarianBscModal.hide();
});
document.getElementById('ScientificPracticalBachelorForm').addEventListener('submit', (e) => {
    e.preventDefault();
    scientificPracticalBscModal.hide();
});
document.getElementById('HumnamitarianPracticalBachelorForm').addEventListener('submit', (e) => {
    e.preventDefault();
    humanitarianPracticalBscModal.hide();
});
document.getElementById('HighDiplomaForm').addEventListener('submit', (e) => {
    e.preventDefault();
    highDiplomaModal.hide();
});
document.getElementById('ScientificMastersForm').addEventListener('submit', (e) => {
    e.preventDefault();
    scientificMasterModal.hide();
});
document.getElementById('HumanitarianMastersForm').addEventListener('submit', (e) => {
    e.preventDefault();
    humanitarianMasterModal.hide();
});
document.getElementById('ScientificPracticalMastersForm').addEventListener('submit', (e) => {
    e.preventDefault();
    scientificPracticalMasterModal.hide();
});
document.getElementById('MainMedicalForm').addEventListener('submit', (e) => {
    e.preventDefault();
    mainMedicalModal.hide();
});
document.getElementById('ResidencyForm').addEventListener('submit', (e) => {
    e.preventDefault();
    residencyModal.hide();
});
document.getElementById('DoctorateForm').addEventListener('submit', (e) => {
    e.preventDefault();
    phdModal.hide();
});