﻿namespace recognitionProj
{
    public class AcademicInfo
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

        public AcademicInfo(int insID, int? insTypeID, string insType, int? highEduRec, int? qualityDeptRec,
                            string studyLangCitizen, string studyLangInter, int? jointClass, string studySystem,
                            int? minHours, int? maxHours, string researchScopus, string researchOthers,
                            int? practicing, int? studyAttendance, int? studentsMove, string studyAttendanceDesc,
                            string studentsMoveDesc, int? distanceLearning, int? maxHoursDL, int? maxYearsDL,
                            int? maxSemsDL, int? diploma, int? diplomaTest, int? hoursPercentage)
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