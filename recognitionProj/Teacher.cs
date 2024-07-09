namespace recognitionProj
{
    public class Teacher
    {
        private string Name;
        private string EduLevel; //bsc, msc, phd, etc...
        private bool FullTime; //yes for fulltime, no for no

        public Teacher(string name, string eduLevel, bool fullTime)
        {
            Name = name;
            EduLevel = eduLevel;
            FullTime = fullTime;
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
    }
}
