namespace recognitionProj
{
    public class Specialization
    {
        private string Name;
        private string EduLevel;//msc/bsc/phd etc...
        private int TotalHours;
        private int UniReqCourseHrs;//mutatalabat eljam3a
        private int ColReqCourseHrs;//mutatalabat elkuliyah
        private int SpecReqCourseHrsTheory;//mutatalabat elta5assos elnadhari
        private int SpecReqCourseHrsPractical;//mutatalabat elta5'assos el3amali
        private int FreeCourseHrs;//mawad 5ora

        public Specialization(string name, string eduLevel, int totalHours, int uniReqCourseHrs, int colReqCourseHrs, int specReqCourseHrsTheory, int specReqCourseHrsPractical, int freeCourseHrs)
        {
            Name = name;
            EduLevel = eduLevel;
            TotalHours = totalHours;
            UniReqCourseHrs = uniReqCourseHrs;
            ColReqCourseHrs = colReqCourseHrs;
            SpecReqCourseHrsTheory = specReqCourseHrsTheory;
            SpecReqCourseHrsPractical = specReqCourseHrsPractical;
            FreeCourseHrs = freeCourseHrs;
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

        public int GetTotalHours()
        {
            return TotalHours;
        }

        public void SetTotalHours(int totalHours)
        {
            TotalHours = totalHours;
        }

        public int GetUniReqCourseHrs()
        {
            return UniReqCourseHrs;
        }

        public void SetUniReqCourseHrs(int uniReqCourseHrs)
        {
            UniReqCourseHrs = uniReqCourseHrs;
        }

        public int GetColReqCourseHrs()
        {
            return ColReqCourseHrs;
        }

        public void SetColReqCourseHrs(int colReqCourseHrs)
        {
            ColReqCourseHrs = colReqCourseHrs;
        }

        public int GetSpecReqCourseHrsTheory()
        {
            return SpecReqCourseHrsTheory;
        }

        public void SetSpecReqCourseHrsTheory(int specReqCourseHrsTheory)
        {
            SpecReqCourseHrsTheory = specReqCourseHrsTheory;
        }

        public int GetSpecReqCourseHrsPractical()
        {
            return SpecReqCourseHrsPractical;
        }

        public void SetSpecReqCourseHrsPractical(int specReqCourseHrsPractical)
        {
            SpecReqCourseHrsPractical = specReqCourseHrsPractical;
        }

        public int GetFreeCourseHrs()
        {
            return FreeCourseHrs;
        }

        public void SetFreeCourseHrs(int freeCourseHrs)
        {
            FreeCourseHrs = freeCourseHrs;
        }
    }
}
