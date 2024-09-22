namespace recognitionProj
{
    public class Lab//this also is for workshops or special labs
    {
        private string _name;
        private string _type;//lab or workshop or special lab
        private Teacher[] _teachers;
        private int _numOfAllStudentsInAllLabs;
        private int _numOfStudentsPerLab;
        private double _area;
        private int _numOfComputers;
        private bool _isPrepared;
        private bool _hasSafetyEquipment;

        public Lab(string name, string type ,Teacher[] teachers, int numOfAllStudentsInAllLabs, int numOfStudentsPerLab, double area, int numOfComputers, bool isPrepared, bool hasSafetyEquipment)
        {
            _name = name;
            _type = type;
            _teachers = teachers;
            _numOfAllStudentsInAllLabs = numOfAllStudentsInAllLabs;
            _numOfStudentsPerLab = numOfStudentsPerLab;
            _area = area;
            _numOfComputers = numOfComputers;
            _isPrepared = isPrepared;
            _hasSafetyEquipment = hasSafetyEquipment;
        }
       
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Teacher[] Teachers
        {
            get { return _teachers; }
            set { _teachers = value; }
        }

        public int NumOfAllStudentsInAllLabs
        {
            get { return _numOfAllStudentsInAllLabs; }
            set { _numOfAllStudentsInAllLabs = value; }
        }
        
        public int NumOfStudentsPerLab
            {
            get { return _numOfStudentsPerLab; }
            set { _numOfStudentsPerLab = value; }
        }

        public double Area
            {
            get { return _area; }
            set { _area = value; }
        }

        public int NumOfComputers
            {
            get { return _numOfComputers; }
            set { _numOfComputers = value; }
        }

        public bool IsPrepared
            {
            get { return _isPrepared; }
            set { _isPrepared = value; }
        }

        public bool HasSafetyEquipment
            {
            get { return _hasSafetyEquipment; }
            set { _hasSafetyEquipment = value; }
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

        public override string ToString()
        {
            return _name;
        }
    }
}
