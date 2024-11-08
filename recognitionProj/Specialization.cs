namespace recognitionProj
{
    public class Specialization
    {
        // Private fields corresponding to the SQL table
        private int _insId; // معرف الكيان (Primary Key)
        private string _type; // نوع الكيان
        private int _numStu; // عدد الطلاب
        private int _numFreeTeachers; // عدد المدرسين المتفرغين (Full-Time Teachers)
        private int _numPartTimeTeachers; // عدد المدرسين غير المتفرغين (Part-Time Teachers)
        private int _numProf; // عدد الأساتذة (Professors)
        private int _numAssociative; // عدد الأساتذة المشاركين (Associate Professors)
        private int _numAssistant; // عدد الأساتذة المساعدين (Assistant Professors)
        private int _numMusharek; // عدد المشاركين (Musharek Professors)
        private int _numMusa3ed; // عدد المساعدين (Musa3ed Professors)
        private int _numberLecturers; // عدد المدرسين (Lecturers)
        private int _numAssisLecturer; // عدد المدرسين المساعدين (Assistant Lecturers)
        private int _numOtherTeachers; // عدد المدرسين الآخرين (Other Teachers)
        private string _specAttachName; // اسم المرفق
        private string _specAttachDesc; // وصف المرفق

        // Constructor
        public Specialization(int insId, string type, int numStu, int numFreeTeachers, int numPartTimeTeachers,
                              int numProf, int numAssociative, int numAssistant, int numMusharek, int numMusa3ed,
                              int numberLecturers, int numAssisLecturer, int numOtherTeachers,
                              string specAttachName, string specAttachDesc)
        {
            _insId = insId;
            _type = type;
            _numStu = numStu;
            _numFreeTeachers = numFreeTeachers;
            _numPartTimeTeachers = numPartTimeTeachers;
            _numProf = numProf;
            _numAssociative = numAssociative;
            _numAssistant = numAssistant;
            _numMusharek = numMusharek;
            _numMusa3ed = numMusa3ed;
            _numberLecturers = numberLecturers;
            _numAssisLecturer = numAssisLecturer;
            _numOtherTeachers = numOtherTeachers;
            _specAttachName = specAttachName;
            _specAttachDesc = specAttachDesc;
        }

        // Properties
        public int InsID { get => _insId; set => _insId = value; } // معرف الكيان
        public string Type { get => _type; set => _type = value; } // نوع الكيان
        public int NumStu { get => _numStu; set => _numStu = value; } // عدد الطلاب
        public int NumFreeTeachers { get => _numFreeTeachers; set => _numFreeTeachers = value; } // عدد المدرسين المتفرغين
        public int NumPartTimeTeachers { get => _numPartTimeTeachers; set => _numPartTimeTeachers = value; } // عدد المدرسين غير المتفرغين
        public int NumProf { get => _numProf; set => _numProf = value; } // عدد الأساتذة
        public int NumAssociative { get => _numAssociative; set => _numAssociative = value; } // عدد الأساتذة المشاركين
        public int NumAssistant { get => _numAssistant; set => _numAssistant = value; } // عدد الأساتذة المساعدين
        public int NumMusharek { get => _numMusharek; set => _numMusharek = value; } // عدد المشاركين
        public int NumMusa3ed { get => _numMusa3ed; set => _numMusa3ed = value; } // عدد المساعدين
        public int NumberLecturers { get => _numberLecturers; set => _numberLecturers = value; } // عدد المدرسين
        public int NumAssisLecturer { get => _numAssisLecturer; set => _numAssisLecturer = value; } // عدد المدرسين المساعدين
        public int NumOtherTeachers { get => _numOtherTeachers; set => _numOtherTeachers = value; } // عدد المدرسين الآخرين
        public string SpecAttachName { get => _specAttachName; set => _specAttachName = value; } // اسم المرفق
        public string SpecAttachDesc { get => _specAttachDesc; set => _specAttachDesc = value; } // وصف المرفق

        // ToString method for debugging or display purposes
        public override string ToString()
        {
            return $"{_type} {_numStu} {_numFreeTeachers} {_numPartTimeTeachers} {_numProf} {_numAssociative} " +
                   $"{_numAssistant} {_numMusharek} {_numMusa3ed} {_numberLecturers} {_numAssisLecturer} " +
                   $"{_numOtherTeachers} {_specAttachName} {_specAttachDesc}";
        }
    }
}
