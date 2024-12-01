namespace recognitionProj
{
    public class AcademicInfo// todo controller and db handler
    {
        private int _insID;
        private int? _insTypeID;
        private string _insType;
        private int? _highEduRec;
        private int? _qualityDeptRec;
        private string _studyLangCitizen;
        private string _studyLangInter;
        private int? _jointClass;
        private string _studySystem;
        private int? _minHours;
        private int? _maxHours;
        private string _researchScopus;
        private string _researchOthers;
        private int? _practicing;
        private int? _studyAttendance;
        private int? _studentsMove;
        private string _studyAttendanceDesc;
        private string _studentsMoveDesc;
        private int? _distanceLearning;
        private int? _maxHoursDL;
        private int? _maxYearsDL;
        private int? _maxSemsDL;
        private int? _diploma;
        private int? _diplomaTest;
        private int? _hoursPercentage;
        //from here on are the new fields that are based on the university class but
        //todo make sure to add the new fields to the db handler and the controller and the database

        private string _educationType;

        public string EducationType
        {
            get => _educationType;
            set => _educationType = value;
        }
        private string[] _availableDegrees;

        public string[] AvailableDegrees
        {
            get => _availableDegrees;
            set => _availableDegrees = value;
        }
        private string[] _faculties;

        public string[] Faculties
        {
            get => _faculties;
            set => _faculties = value;
        }
        private int _arwuRank;

        public int ARWURank
        {
            get => _arwuRank;
            set => _arwuRank = value;
        }
        private int _theRank;

        public int THERank
        {
            get => _theRank;
            set => _theRank = value;
        }
        private int _qsRank;

        public int QSRank
        {
            get => _qsRank;
            set => _qsRank = value;
        }
        private string _otherRank;

        public string OtherRank
        {
            get => _otherRank;
            set => _otherRank = value;
        }
        private int _numOfScopusResearches;

        public int NumOfScopusResearches
        {
            get => _numOfScopusResearches;
            set => _numOfScopusResearches = value;
        }
        private int _scopusFrom;

        public int ScopusFrom
        {
            get => _scopusFrom;
            set => _scopusFrom = value;
        }
        private int _scopusTo;

        public int ScopusTo
        {
            get => _scopusTo;
            set => _scopusTo = value;
        }
        private string _infrastructure;

        public string Infrastructure
        {
            get => _infrastructure;
            set => _infrastructure = value;
        }
        private Specialization[] _specializations;

        public Specialization[] Specializations
        {
            get => _specializations;
            set => _specializations = value;
        }
        private bool _accepted;

        public bool Accepted
        {
            get => _accepted;
            set => _accepted = value;
        }


        public AcademicInfo(int insID, int? insTypeID, string insType, int? highEduRec, int? qualityDeptRec,
                            string studyLangCitizen, string studyLangInter, int? jointClass, string studySystem,
                            int? minHours, int? maxHours, string researchScopus, string researchOthers,
                            int? practicing, int? studyAttendance, int? studentsMove, string studyAttendanceDesc,
                            string studentsMoveDesc, int? distanceLearning, int? maxHoursDL, int? maxYearsDL,
                            int? maxSemsDL, int? diploma, int? diplomaTest, int? hoursPercentage, string educationType, string[] availableDegrees, string[] faculties,
                    int arwuRank, int theRank, int qsRank, string otherRank, int numOfScopusResearches,
                    int scopusFrom, int scopusTo, string infrastructure, Specialization[] specializations, bool accepted)
        {
            _insID = insID;
            _insTypeID = insTypeID;
            _insType = insType;
            _highEduRec = highEduRec;
            _qualityDeptRec = qualityDeptRec;
            _studyLangCitizen = studyLangCitizen;
            _studyLangInter = studyLangInter;
            _jointClass = jointClass;
            _studySystem = studySystem;
            _minHours = minHours;
            _maxHours = maxHours;
            _researchScopus = researchScopus;
            _researchOthers = researchOthers;
            _practicing = practicing;
            _studyAttendance = studyAttendance;
            _studentsMove = studentsMove;
            _studyAttendanceDesc = studyAttendanceDesc;
            _studentsMoveDesc = studentsMoveDesc;
            _distanceLearning = distanceLearning;
            _maxHoursDL = maxHoursDL;
            _maxYearsDL = maxYearsDL;
            _maxSemsDL = maxSemsDL;
            _diploma = diploma;
            _diplomaTest = diplomaTest;
            _hoursPercentage = hoursPercentage;
            // Existing assignments...
            //todo make sure to add the new fields to the db handler and the controller and the database

            _educationType = educationType;
            _availableDegrees = availableDegrees;
            _faculties = faculties;
            _arwuRank = arwuRank;
            _theRank = theRank;
            _qsRank = qsRank;
            _otherRank = otherRank;
            _numOfScopusResearches = numOfScopusResearches;
            _scopusFrom = scopusFrom;
            _scopusTo = scopusTo;
            _infrastructure = infrastructure;
            _specializations = specializations;
            _accepted = accepted;
        }

        public int InsID
        {
            get => _insID;
            set => _insID = value;
        }
        public int? InsTypeID
        {
            get => _insTypeID;
            set => _insTypeID = value;
        }
        public string InsType
        {
            get => _insType;
            set => _insType = value;
        }
        public int? HighEdu_Rec
        {
            get => _highEduRec;
            set => _highEduRec = value;
        }
        public int? QualityDept_Rec
        {
            get => _qualityDeptRec;
            set => _qualityDeptRec = value;
        }
        public string StudyLangCitizen
        {
            get => _studyLangCitizen;
            set => _studyLangCitizen = value;
        }
        public string StudyLangInter
        {
            get => _studyLangInter;
            set => _studyLangInter = value;
        }
        public int? JointClass
        {
            get => _jointClass;
            set => _jointClass = value;
        }
        public string StudySystem
        {
            get => _studySystem;
            set => _studySystem = value;
        }
        public int? MinHours
        {
            get => _minHours;
            set => _minHours = value;
        }
        public int? MaxHours
        {
            get => _maxHours;
            set => _maxHours = value;
        }
        public string ResearchScopus
        {
            get => _researchScopus;
            set => _researchScopus = value;
        }
        public string ResearchOthers
        {
            get => _researchOthers;
            set => _researchOthers = value;
        }
        public int? Practicing
        {
            get => _practicing;
            set => _practicing = value;
        }
        public int? StudyAttendance
        {
            get => _studyAttendance;
            set => _studyAttendance = value;
        }
        public int? StudentsMove
        {
            get => _studentsMove;
            set => _studentsMove = value;
        }
        public string StudyAttendanceDesc
        {
            get => _studyAttendanceDesc;
            set => _studyAttendanceDesc = value;
        }
        public string StudentsMoveDesc
        {
            get => _studentsMoveDesc;
            set => _studentsMoveDesc = value;
        }
        public int? DistanceLearning
        {
            get => _distanceLearning;
            set => _distanceLearning = value;
        }
        public int? MaxHoursDL
        {
            get => _maxHoursDL;
            set => _maxHoursDL = value;
        }
        public int? MaxYearsDL
        {
            get => _maxYearsDL;
            set => _maxYearsDL = value;
        }
        public int? MaxSemsDL
        {
            get => _maxSemsDL;
            set => _maxSemsDL = value;
        }
        public int? Diploma
        {
            get => _diploma;
            set => _diploma = value;
        }
        public int? DiplomaTest
        {
            get => _diplomaTest;
            set => _diplomaTest = value;
        }
        public int? HoursPercentage
        {
            get => _hoursPercentage;
            set => _hoursPercentage = value;
        }
    }
}
