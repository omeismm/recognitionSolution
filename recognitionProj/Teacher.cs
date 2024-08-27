namespace recognitionProj
{
    public class Teacher
    {
        private string _name; // Teacher's name
        private string _eduLevel; // Education level (e.g. BSc, MSc, PhD)
        private string _jobTitle; // Job title (e.g. Professor, Assistant Professor, Lecturer)
        private bool _fullTime; // Full-time status (true for full-time, false for part-time)
        private SpecializationWithExperience[] _specializationPracticalExperience; // Array of specializations the teacher has practical experience in with the years of experience
        private bool _sameField; // Indicates if all certificates are in the same field (true if yes, false if no)
        private bool _diverseCert; // Indicates if certificates are from different places (true if yes, false if no)
        private bool _fivePointFive; // Teacher requirements point number 5.5 in pdf 222222
        private bool _jordanian; // Indicates if the teacher is Jordanian (true if yes, false if no)
        private float _contractLength; // Contract length in years
        private bool _equivalence; // Indicates if the teacher has an equivalence certificate (true if yes, false if no) (7.6 in pdf)
        private int _numOfResearches; // Number of researches the teacher has published

        public Teacher(string name, string eduLevel, string jobTitle, bool fullTime, SpecializationWithExperience[] specializationPracticalExperience, bool sameField, bool fivePointFive, bool jordanian, float contractLength, int numOfResearches, bool equivalence)
        {
            _name = name;
            _eduLevel = eduLevel;
            _jobTitle = jobTitle;
            _fullTime = fullTime;
            _specializationPracticalExperience = specializationPracticalExperience;
            _sameField = sameField;
            _fivePointFive = fivePointFive;
            _jordanian = jordanian;
            _contractLength = contractLength;
            _numOfResearches = numOfResearches;
            _equivalence = equivalence;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string EduLevel
        {
            get { return _eduLevel; }
            set { _eduLevel = value; }
        }

        public string JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

        public bool FullTime
        {
            get { return _fullTime; }
            set { _fullTime = value; }
        }

        public SpecializationWithExperience[] SpecializationPracticalExperience
        {
            get { return _specializationPracticalExperience; }
            set { _specializationPracticalExperience = value; }
        }

        public bool SameField
        {
            get { return _sameField; }
            set { _sameField = value; }
        }

        public bool DiverseCert
        {
            get { return _diverseCert; }
            set { _diverseCert = value; }
        }

        public bool FivePointFive
        {
            get { return _fivePointFive; }
            set { _fivePointFive = value; }
        }

        public bool Jordanian
        {
            get { return _jordanian; }
            set { _jordanian = value; }
        }

        public float ContractLength
        {
            get { return _contractLength; }
            set { _contractLength = value; }
        }

        public void AddSpecializationPracticalExperience(SpecializationWithExperience specialization)
        {
            SpecializationWithExperience[] newSpecializations = new SpecializationWithExperience[_specializationPracticalExperience.Length + 1];
            for (int i = 0; i < _specializationPracticalExperience.Length; i++)
            {
                newSpecializations[i] = _specializationPracticalExperience[i];
            }
            newSpecializations[_specializationPracticalExperience.Length] = specialization;
            _specializationPracticalExperience = newSpecializations;
        }

        public void RemoveSpecializationPracticalExperience(SpecializationWithExperience specialization)
        {
            SpecializationWithExperience[] newSpecializations = new SpecializationWithExperience[_specializationPracticalExperience.Length - 1];
            int j = 0;
            for (int i = 0; i < _specializationPracticalExperience.Length; i++)
            {
                if (_specializationPracticalExperience[i] != specialization)
                {
                    newSpecializations[j] = _specializationPracticalExperience[i];
                    j++;
                }
            }
            _specializationPracticalExperience = newSpecializations;
        }

        public int NumOfResearches
        {
            get { return _numOfResearches; }
            set { _numOfResearches = value; }
        }

        public bool Equivalence
        {
            get { return _equivalence; }
            set { _equivalence = value; }
        }
    }

    
    
}
