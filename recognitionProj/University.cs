namespace recognitionProj
{
    public class University
    {
        private string _name;

        private int _studentCount;
        private Teacher[] _teachers;
        private Specialization[] _specializations; // Array of specializations
        private Lab[] _labs; // Array of labs
        private SubjectRoom[] _subjectRooms; // Array of subject rooms
        private Library[] _library;
        private bool _isPrepared;//article 12 requirements in pdf 222222
        private string _presidentName;
        private bool _recgonized;//true if the university is recognized by the ministry of higher education, false otherwise
        private AcceptanceRecord[] _acceptanceRecords;// Array of acceptance records
        private bool _outstandingFees;//true if the university has outstanding fees, false otherwise (غرامات مالية)
        public University(string name, int studentCount, Teacher[] teachers, Specialization[] specializations, Lab[] labs, SubjectRoom[] subjectRooms, Library[] library, bool isPrepared, string presidentName, bool recgonized, AcceptanceRecord[] acceptanceRecords , bool outstandingFees)
        {
            _name = name;
            _studentCount = studentCount;
            _teachers = teachers;
            _specializations = specializations;
            _labs = labs;
            _subjectRooms = subjectRooms;
            _library = library;
            _isPrepared = isPrepared;
            _presidentName = presidentName;
            _recgonized = recgonized;
            _acceptanceRecords = acceptanceRecords;
            _outstandingFees = outstandingFees;
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

        public Lab[] Labs
        {
            get { return _labs; }
            set { _labs = value; }
        }

        public void AddLab(Lab lab)
        {
            Lab[] newLabs = new Lab[_labs.Length + 1];
            for (int i = 0; i < _labs.Length; i++)
            {
                newLabs[i] = _labs[i];
            }
            newLabs[_labs.Length] = lab;
            _labs = newLabs;
        }

        public void RemoveLab(Lab lab)
        {
            Lab[] newLabs = _labs;
            for (int i = 0; i < _labs.Length; i++)
            {
                if (_labs[i] == lab)
                {
                    newLabs = new Lab[_labs.Length - 1];
                    for (int j = 0; j < i; j++)
                    {
                        newLabs[j] = _labs[j];
                    }
                    for (int j = i; j < _labs.Length - 1; j++)
                    {
                        newLabs[j] = _labs[j + 1];
                    }
                    break;
                }
            }
            _labs = newLabs;
        }

        public SubjectRoom[] SubjectRooms
        {
            get { return _subjectRooms; }
            set { _subjectRooms = value; }
        }

        public SubjectRoom[] GetSubjectRooms() {
            return _subjectRooms;
        }

        public void AddSubjectRoom(SubjectRoom subjectRoom)
        {
            SubjectRoom[] newSubjectRooms = new SubjectRoom[_subjectRooms.Length + 1];
            for (int i = 0; i < _subjectRooms.Length; i++)
            {
                newSubjectRooms[i] = _subjectRooms[i];
            }
            newSubjectRooms[_subjectRooms.Length] = subjectRoom;
            _subjectRooms = newSubjectRooms;
        }

        public void RemoveSubjectRoom(SubjectRoom subjectRoom)
        {
            SubjectRoom[] newSubjectRooms = new SubjectRoom[_subjectRooms.Length - 1];
            int j = 0;
            for (int i = 0; i < _subjectRooms.Length; i++)
            {
                if (_subjectRooms[i] != subjectRoom)
                {
                    newSubjectRooms[j] = _subjectRooms[i];
                    j++;
                }
            }
            _subjectRooms = newSubjectRooms;
        }

        public Library[] Library
        {
            get { return _library; }
            set { _library = value; }
        }

        public void AddLibrary(Library library)
        {
            Library[] newLibrary = new Library[_library.Length + 1];
            for (int i = 0; i < _library.Length; i++)
            {
                newLibrary[i] = _library[i];
            }
            newLibrary[_library.Length] = library;
            _library = newLibrary;
        }

        public void RemoveLibrary(Library library) {
            Library[] newLibrary = _library;
            for (int i = 0; i < _library.Length; i++)
            {
                if (_library[i] == library)
                {
                    newLibrary = new Library[_library.Length - 1];
                    for (int j = 0; j < i; j++)
                    {
                        newLibrary[j] = _library[j];
                    }
                    for (int j = i; j < _library.Length - 1; j++)
                    {
                        newLibrary[j] = _library[j + 1];
                    }
                    break;
                }
            }
            _library = newLibrary;
        }

        public bool IsPrepared
        {
            get { return _isPrepared; }
            set { _isPrepared = value; }
        }

        public string PresidentName
        {
            get { return _presidentName; }
            set { _presidentName = value; }
        }

        public bool recgonized
        {
            get { return _recgonized; }
            set { _recgonized = value; }
        }

        public AcceptanceRecord[] AcceptanceRecords
        {
            get { return _acceptanceRecords; }
            set { _acceptanceRecords = value; }
        }

        public void AddAcceptanceRecord(AcceptanceRecord acceptanceRecord)
        {
            AcceptanceRecord[] newAcceptanceRecords = new AcceptanceRecord[_acceptanceRecords.Length + 1];
            for (int i = 0; i < _acceptanceRecords.Length; i++)
            {
                newAcceptanceRecords[i] = _acceptanceRecords[i];
            }
            newAcceptanceRecords[_acceptanceRecords.Length] = acceptanceRecord;
            _acceptanceRecords = newAcceptanceRecords;
        }

        public void RemoveAcceptanceRecord(AcceptanceRecord acceptanceRecord)
        {
            AcceptanceRecord[] newAcceptanceRecords = new AcceptanceRecord[_acceptanceRecords.Length - 1];
            int j = 0;
            for (int i = 0; i < _acceptanceRecords.Length; i++)
            {
                if (_acceptanceRecords[i] != acceptanceRecord)
                {
                    newAcceptanceRecords[j] = _acceptanceRecords[i];
                    j++;
                }
            }
            _acceptanceRecords = newAcceptanceRecords;
        }

        public bool OutstandingFees
        {
            get { return _outstandingFees; }
            set { _outstandingFees = value; }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
