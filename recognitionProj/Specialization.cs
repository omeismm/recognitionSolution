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
        private int InternshipHrs;//tadreeb
        private int GradProjectHrs;
        private Teacher[] teachers;
        public Specialization(string name, string eduLevel, int totalHours, int uniReqCourseHrs, int colReqCourseHrs, int specReqCourseHrsTheory, int specReqCourseHrsPractical, int freeCourseHrs, int internshipHrs, int gradProjectHrs, Teacher[] teachers)
        {
            Name = name;
            EduLevel = eduLevel;
            TotalHours = totalHours;
            UniReqCourseHrs = uniReqCourseHrs;
            ColReqCourseHrs = colReqCourseHrs;
            SpecReqCourseHrsTheory = specReqCourseHrsTheory;
            SpecReqCourseHrsPractical = specReqCourseHrsPractical;
            FreeCourseHrs = freeCourseHrs;
            InternshipHrs = internshipHrs;
            GradProjectHrs = gradProjectHrs;
            this.teachers = teachers;
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

        public int GetInternshipHrs()
        {
            return InternshipHrs;
        }
        public void SetInternshipHrs(int internshipHrs)
        {
            InternshipHrs = internshipHrs;
        }
        public int GetGradProjectHrs()
        {
            return GradProjectHrs;
        }
        public void SetGradProjectHrs(int gradProjectHrs)
        {
            GradProjectHrs = gradProjectHrs;
        }
        public Teacher[] GetTeachers()
        {
            return teachers;
        }
        public void SetTeachers(Teacher[] teachers)
        {
            this.teachers = teachers;
        }
        public void AddTeacher(Teacher teacher)
        {
            Teacher[] newTeachers = new Teacher[teachers.Length + 1];
            for (int i = 0; i < teachers.Length; i++)
            {
                newTeachers[i] = teachers[i];
            }
            newTeachers[teachers.Length] = teacher;
            teachers = newTeachers;
        }
        public void RemoveTeacher(Teacher teacher)
        {
            Teacher[] newTeachers = new Teacher[teachers.Length - 1];
            int j = 0;
            for (int i = 0; i < teachers.Length; i++)
            {
                if (teachers[i] != teacher)
                {
                    newTeachers[j] = teachers[i];
                    j++;
                }
            }
            teachers = newTeachers;
        }
        
    }
}
