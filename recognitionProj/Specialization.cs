namespace recognitionProj
{
    public class Specialization
    {
        private string _name;
        private string _eduLevel;//bsc, msc, phd, etc...
        private int _totalHours;//professor, assistant professor, lecturer, etc...
        private int _uniReqCourseHrs;//mutatalabat eljam3a
        private int _colReqCourseHrs;//mutatalabat elkuliyah
        private int _specReqCourseHrsTheory;//mutatalabat elta5'assos elnazari
        private int _specReqCourseHrsPractical;//mutatalabat elta5'assos el3amali
        private int _freeCourseHrs;//mawad 5ora
        private int _internshipHrs;//tadreeb
        private int _gradProjectHrs;
        private Teacher[] _teachers;
        private int _numOfStudents;
        private bool _scientific;//true for scientific specialization, false for humanitarian
        private bool _hasSpecialException;//if the specialization has exceptiopns for the type of teachers allowed to teach
        public Specialization(string name, string eduLevel, int totalHours, int uniReqCourseHrs, int colReqCourseHrs, int specReqCourseHrsTheory, int specReqCourseHrsPractical, int freeCourseHrs, int internshipHrs, int gradProjectHrs, Teacher[] teachers, int numOfStudents, bool scientific, bool hasSpecialException)
        {
            _name = name;
            _eduLevel = eduLevel;
            _totalHours = totalHours;
            _uniReqCourseHrs = uniReqCourseHrs;
            _colReqCourseHrs = colReqCourseHrs;
            _specReqCourseHrsTheory = specReqCourseHrsTheory;
            _specReqCourseHrsPractical = specReqCourseHrsPractical;
            _freeCourseHrs = freeCourseHrs;
            _internshipHrs = internshipHrs;
            _gradProjectHrs = gradProjectHrs;
            _teachers = teachers;
            _numOfStudents = numOfStudents;
            _scientific = scientific;
            _hasSpecialException = hasSpecialException;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string EduLevel
        {
            get => _eduLevel;
            set => _eduLevel = value;
        }

        public int TotalHours
        {
            get => _totalHours;
            set => _totalHours = value;
        }

        public int UniReqCourseHrs
        {
            get => _uniReqCourseHrs;
            set => _uniReqCourseHrs = value;
        }

        public int ColReqCourseHrs
        {
            get => _colReqCourseHrs;
            set => _colReqCourseHrs = value;
        }

        public int SpecReqCourseHrsTheory
        {
            get => _specReqCourseHrsTheory;
            set => _specReqCourseHrsTheory = value;
        }

        public int SpecReqCourseHrsPractical
        {
            get => _specReqCourseHrsPractical;
            set => _specReqCourseHrsPractical = value;
        }

        public int FreeCourseHrs
        {
            get => _freeCourseHrs;
            set => _freeCourseHrs = value;
        }

        public int InternshipHrs
        {
            get => _internshipHrs;
            set => _internshipHrs = value;
        }

        public int GradProjectHrs
        {
            get => _gradProjectHrs;
            set => _gradProjectHrs = value;
        }

        public Teacher[] Teachers
        {
            get => _teachers;
            set => _teachers = value;
        }

        public void AddTeacher(Teacher teacher)
        {
            Teacher[] newTeachers = new Teacher[_teachers.Length + 1];
            for (int i = 0; i < _teachers.Length; i++)
            {
                newTeachers[i] = _teachers[i];
            }
            newTeachers[_teachers.Length] = teacher;
            _teachers = newTeachers;
        }

        public void RemoveTeacher(Teacher teacher)
        {
            Teacher[] newTeachers = new Teacher[_teachers.Length - 1];
            int j = 0;
            for (int i = 0; i < _teachers.Length; i++)
            {
                if (_teachers[i] != teacher)
                {
                    newTeachers[j] = _teachers[i];
                    j++;
                }
            }
            _teachers = newTeachers;
        }

        public int NumOfStudents
        {
            get => _numOfStudents;
            set => _numOfStudents = value;
        }

        public bool Scientific
        {
            get => _scientific;
            set => _scientific = value;
        }

        public bool HasSpecialException
        {
            get => _hasSpecialException;
            set => _hasSpecialException = value;
        }
        public override string ToString()
        {
            return _name;
        }

    }
}
