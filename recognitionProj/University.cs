namespace recognitionProj
{
    public class University
    {
        private string _name;

        private int _studentCount;
        private Teacher[] _teachers;
        private Specialization[] _specializations; // Array of specializations

        public University(string name, int studentCount, Teacher[] teachers, Specialization[] specializations)
        {
            _name = name;
            _studentCount = studentCount;
            _teachers = teachers;
            _specializations = specializations;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int StudentCount
        {
            get { return _studentCount; }
            set { _studentCount = value; }
        }

        public Teacher[] Teachers
        {
            get { return _teachers; }
            set { _teachers = value; }
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

        public Specialization[] Specializations
        {
            get { return _specializations; }
            set { _specializations = value; }
        }

        public void AddSpecialization(Specialization specialization)
        {
            Specialization[] newSpecializations = new Specialization[_specializations.Length + 1];
            for (int i = 0; i < _specializations.Length; i++)
            {
                newSpecializations[i] = _specializations[i];
            }
            newSpecializations[_specializations.Length] = specialization;
            _specializations = newSpecializations;
        }

        public void RemoveSpecialization(Specialization specialization)
        {
            Specialization[] newSpecializations = new Specialization[_specializations.Length - 1];
            int j = 0;
            for (int i = 0; i < _specializations.Length; i++)
            {
                if (_specializations[i] != specialization)
                {
                    newSpecializations[j] = _specializations[i];
                    j++;
                }
            }
            _specializations = newSpecializations;
        }
    }
}
