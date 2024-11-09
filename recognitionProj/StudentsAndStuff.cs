using Microsoft.AspNetCore.Http.HttpResults;

namespace recognitionProj
{
    public class StudentsAndStuff // todo controller and db handler
    {
        private int _insID;
        private int? _studentCitizen;
        private int? _studentInter;
        private int? _studentJordan;
        private int? _studentOverall;
        private int? _staffProfessor;
        private int? _staffCoProfessor;
        private int? _staffAssistantProfessor;
        private int? _staffLabSupervisor;
        private int? _staffResearcher;
        private int? _staffTeacher;
        private int? _staffTeacherAssistant;
        private int? _staffOthers;

        // Constructor
        public StudentsAndStuff(int insID, int? studentCitizen, int? studentInter, int? studentJordan, int? studentOverall,
                                int? staffProfessor, int? staffCoProfessor, int? staffAssistantProfessor,
                                int? staffLabSupervisor, int? staffResearcher, int? staffTeacher,
                                int? staffTeacherAssistant, int? staffOthers)
        {
            _insID = insID;
            _studentCitizen = studentCitizen;
            _studentInter = studentInter;
            _studentJordan = studentJordan;
            _studentOverall = studentOverall;
            _staffProfessor = staffProfessor;
            _staffCoProfessor = staffCoProfessor;
            _staffAssistantProfessor = staffAssistantProfessor;
            _staffLabSupervisor = staffLabSupervisor;
            _staffResearcher = staffResearcher;
            _staffTeacher = staffTeacher;
            _staffTeacherAssistant = staffTeacherAssistant;
            _staffOthers = staffOthers;
        }

        // Properties
        public int InsID
        {
            get => _insID;
            set => _insID = value;
        }

        public int? StudentCitizen
        {
            get => _studentCitizen;
            set => _studentCitizen = value;
        }

        public int? StudentInter
        {
            get => _studentInter;
            set => _studentInter = value;
        }

        public int? StudentJordan
        {
            get => _studentJordan;
            set => _studentJordan = value;
        }

        public int? StudentOverall
        {
            get => _studentOverall;
            set => _studentOverall = value;
        }

        public int? StaffProfessor
        {
            get => _staffProfessor;
            set => _staffProfessor = value;
        }

        public int? StaffCoProfessor
        {
            get => _staffCoProfessor;
            set => _staffCoProfessor = value;
        }

        public int? StaffAssistantProfessor
        {
            get => _staffAssistantProfessor;
            set => _staffAssistantProfessor = value;
        }

        public int? StaffLabSupervisor
        {
            get => _staffLabSupervisor;
            set => _staffLabSupervisor = value;
        }

        public int? StaffResearcher
        {
            get => _staffResearcher;
            set => _staffResearcher = value;
        }

        public int? StaffTeacher
        {
            get => _staffTeacher;
            set => _staffTeacher = value;
        }

        public int? StaffTeacherAssistant
        {
            get => _staffTeacherAssistant;
            set => _staffTeacherAssistant = value;
        }

        public int? StaffOthers
        {
            get => _staffOthers;
            set => _staffOthers = value;
        }
    }
}
