namespace recognitionProj
{
    public class Specialization
    {
        private string _name;
        private string _type;
        private int _numOfStudents;
        private int _numOfFullTimeTeachers;
        private int _numOfPartTimeTeachers;
        private int _numOfOstadh;
        private int _numOfOstadhMusharek;
        private int _numOfOstadhMusa3ed;
        private int _numOfMusharek;
        private int _numOfMusa3ed;
        private int _numberOfLecturers;
        private int _numOfMudaresMusa3ed;
        private int _numOfMudares;
        private int _numOfOtherTeachers;

        // New fields for file upload
        private string _specAttachName;
        private string _specAttachDesc;

        public Specialization(string name, string type, int numOfStudents, int numOfFullTimeTeachers, int numOfPartTimeTeachers,
                              int numOfOstadh, int numOfOstadhMusharek, int numOfOstadhMusa3ed, int numOfMusharek, int numOfMusa3ed,
                              int numberOfLecturers, int numOfMudaresMusa3ed, int numOfMudares, int numOfOtherTeachers,
                              string specAttachName, string specAttachDesc)
        {
            _name = name;
            _type = type;
            _numOfStudents = numOfStudents;
            _numOfFullTimeTeachers = numOfFullTimeTeachers;
            _numOfPartTimeTeachers = numOfPartTimeTeachers;
            _numOfOstadh = numOfOstadh;
            _numOfOstadhMusharek = numOfOstadhMusharek;
            _numOfOstadhMusa3ed = numOfOstadhMusa3ed;
            _numOfMusharek = numOfMusharek;
            _numOfMusa3ed = numOfMusa3ed;
            _numberOfLecturers = numberOfLecturers;
            _numOfMudaresMusa3ed = numOfMudaresMusa3ed;
            _numOfMudares = numOfMudares;
            _numOfOtherTeachers = numOfOtherTeachers;
            _specAttachName = specAttachName;
            _specAttachDesc = specAttachDesc;
        }

        // Properties for existing fields
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
        public int NumOfStudents { get => _numOfStudents; set => _numOfStudents = value; }
        public int NumOfFullTimeTeachers { get => _numOfFullTimeTeachers; set => _numOfFullTimeTeachers = value; }
        public int NumOfPartTimeTeachers { get => _numOfPartTimeTeachers; set => _numOfPartTimeTeachers = value; }
        public int NumOfOstadh { get => _numOfOstadh; set => _numOfOstadh = value; }
        public int NumOfOstadhMusharek { get => _numOfOstadhMusharek; set => _numOfOstadhMusharek = value; }
        public int NumOfOstadhMusa3ed { get => _numOfOstadhMusa3ed; set => _numOfOstadhMusa3ed = value; }
        public int NumOfMusharek { get => _numOfMusharek; set => _numOfMusharek = value; }
        public int NumOfMusa3ed { get => _numOfMusa3ed; set => _numOfMusa3ed = value; }
        public int NumberOfLecturers { get => _numberOfLecturers; set => _numberOfLecturers = value; }
        public int NumOfMudaresMusa3ed { get => _numOfMudaresMusa3ed; set => _numOfMudaresMusa3ed = value; }
        public int NumOfMudares { get => _numOfMudares; set => _numOfMudares = value; }
        public int NumOfOtherTeachers { get => _numOfOtherTeachers; set => _numOfOtherTeachers = value; }

        // Properties for the new fields
        public string SpecAttachName { get => _specAttachName; set => _specAttachName = value; }
        public string SpecAttachDesc { get => _specAttachDesc; set => _specAttachDesc = value; }

        // ToString method
        public override string ToString()
        {
            return $"{_name} {_type} {_numOfStudents} {_numOfFullTimeTeachers} {_numOfPartTimeTeachers} " +
                   $"{_numOfOstadh} {_numOfMusharek} {_numOfMusa3ed} {_numberOfLecturers} {_numOfMudaresMusa3ed} " +
                   $"{_numOfMudares} {_numOfOtherTeachers} {_specAttachName} {_specAttachDesc}";
        }
    }
}
