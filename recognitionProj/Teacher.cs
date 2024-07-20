namespace recognitionProj
{
    public class Teacher
    {
        private string Name;
        private string EduLevel; //bsc, msc, phd, etc...
        private string JobTitle;//professor, assistant professor, lecturer, etc...
        private bool FullTime; //yes for fulltime, no for no
        private Specialization[] SpecializationPracticalExperience; // what subjects the teacher has practical experience in
        private bool SameField;//yes if all certificates from bsc to phd are in the same field, no if not
        private bool DiverseCert;//yes if certificates are from different places, no if not
        private bool FivePointFive;//teacher requirements point number 5.5
        private bool Jordanian;//yes if jordanian, no if not
        private float ContractLength;//contract length in years
        public Teacher(string name, string eduLevel, string jobTitle, bool fullTime, Specialization[] specializationPracticalExperience, bool sameField, bool fivePointFive, bool jordanian, float contractLength)
        {
            Name = name;
            EduLevel = eduLevel;
            JobTitle = jobTitle;
            FullTime = fullTime;
            SpecializationPracticalExperience = specializationPracticalExperience;
            SameField = sameField;
            FivePointFive = fivePointFive;
            Jordanian = jordanian;
            ContractLength = contractLength;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetEduLevel()
        {
            return EduLevel;
        }

        public void SetEduLevel(string eduLevel)
        {
            EduLevel = eduLevel;
        }

        public bool GetFullTime()
        {
            return FullTime;
        }

        public void SetFullTime(bool fullTime)
        {
            FullTime = fullTime;
        }
        public Specialization[] GetSpecializationPracticalExperience()
        {
            return SpecializationPracticalExperience;
        }
        public void SetSpecializationPracticalExperience(Specialization[] specializationPracticalExperience)
        {
            SpecializationPracticalExperience = specializationPracticalExperience;
        }
        public void AddSpecializationPracticalExperience(Specialization specialization)
        {
            Specialization[] newSpecializations = new Specialization[SpecializationPracticalExperience.Length + 1];
            for (int i = 0; i < SpecializationPracticalExperience.Length; i++)
            {
                newSpecializations[i] = SpecializationPracticalExperience[i];
            }
            newSpecializations[SpecializationPracticalExperience.Length] = specialization;
            SpecializationPracticalExperience = newSpecializations;
        }
        public void RemoveSpecializationPracticalExperience(Specialization specialization)
        {
            Specialization[] newSpecializations = new Specialization[SpecializationPracticalExperience.Length - 1];
            int j = 0;
            for (int i = 0; i < SpecializationPracticalExperience.Length; i++)
            {
                if (SpecializationPracticalExperience[i] != specialization)
                {
                    newSpecializations[j] = SpecializationPracticalExperience[i];
                    j++;
                }
            }
            SpecializationPracticalExperience = newSpecializations;
        }
        public bool GetSameField()
        {
            return SameField;
        }
        public void SetSameField(bool sameField)
        {
            SameField = sameField;
        }
        public bool GetFivePointFive()
        {
            return FivePointFive;
        }
        public void SetFivePointFive(bool fivePointFive)
        {
            FivePointFive = fivePointFive;
        }
        public bool GetJordanian()
        {
            return Jordanian;
        }
        public void SetJordanian(bool jordanian)
        {
            Jordanian = jordanian;
        }
        public float GetContractLength()
        {
            return ContractLength;
        }
        public void SetContractLength(float contractLength)
        {
            ContractLength = contractLength;
        }

    }
}
