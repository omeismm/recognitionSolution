namespace recognitionProj
{
    public class University
    {
        private string Name;
 
        private int studentCount;
        private Teacher[] teachers;
        private Specialization[] specializations; // Array of specializations

        public University(string name, int studentCount, Teacher[] teachers, Specialization[] specializations)
        {
            Name = name;
            
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

        public Specialization[] GetSpecializations()
        {
            return specializations;
        }

        public void SetSpecializations(Specialization[] specializations)
        {
            this.specializations = specializations;
        }
        public void AddSpecialization(Specialization specialization)
        {
            Specialization[] newSpecializations = new Specialization[specializations.Length + 1];
            for (int i = 0; i < specializations.Length; i++)
            {
                newSpecializations[i] = specializations[i];
            }
            newSpecializations[specializations.Length] = specialization;
            specializations = newSpecializations;
        }
        public void RemoveSpecialization(Specialization specialization)
        {
            Specialization[] newSpecializations = new Specialization[specializations.Length - 1];
            int j = 0;
            for (int i = 0; i < specializations.Length; i++)
            {
                if (specializations[i] != specialization)
                {
                    newSpecializations[j] = specializations[i];
                    j++;
                }
            }
            specializations = newSpecializations;
        }
    }
}
