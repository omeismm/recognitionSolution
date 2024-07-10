namespace recognitionProj
{
    public class University
    {
        private string Name;
        private string Type; // medical or engineer or humanitarian etc..
        private int studentCount;
        private Teacher[] teachers;
        private Specialization[] specializations; // Array of specializations

        public University(string name, string type, int studentCount, Teacher[] teachers, Specialization[] specializations)
        {
            Name = name;
            Type = type;
            this.studentCount = studentCount;
            this.teachers = teachers;
            this.specializations = specializations;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetType()
        {
            return Type;
        }

        public void SetType(string type)
        {
            Type = type;
        }

        public int GetStudentCount()
        {
            return studentCount;
        }

        public void SetStudentCount(int count)
        {
            studentCount = count;
        }

        public Teacher[] GetTeachers()
        {
            return teachers;
        }

        public void SetTeachers(Teacher[] teachers)
        {
            this.teachers = teachers;
        }

        public Specialization[] GetSpecializations()
        {
            return specializations;
        }

        public void SetSpecializations(Specialization[] specializations)
        {
            this.specializations = specializations;
        }
    }
}
