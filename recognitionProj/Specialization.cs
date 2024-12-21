namespace recognitionProj
{
    public class Specialization
    {
        // Private fields corresponding to the SQL table BACKING FIELDS
        private int _insId; // معرف الكيان (Primary Key)
        private string _type; // نوع الكيان
        private int _numStu; // عدد الطلاب
        private int _numProf; // عدد الأساتذة المتفرغين (Professors)
        private int _numAssociative; // عدد الأساتذة المشاركين (Associate Professors)
        private int _numAssistant; // عدد الأساتذة المساعدين (Assistant Professors)
        private int? _numProfPractice; // الاستاذ الممارس للتخصصات التطبيقية 
        private int _numberLecturers; // عدد المدرسين (Lecturers)
        private int _numAssisLecturer; // عدد المدرسين المساعدين (Assistant Lecturers)
        private int _numOtherTeachers; // عدد المدرسين الآخرين (Other Teachers)
        private string? _specAttachName; // اسم المرفق
        private string? _specAttachDesc; // وصف المرفق
        private int _color;
        private int _numPhdHolders;
        private int? _practicalHours;
        private int? _theoreticalHours;

        // Constructor
        public Specialization(int insId, string type, int numStu,
                              int numProf, int numAssociative, int numAssistant, int? numProfPractice,
                              int numberLecturers, int numAssisLecturer, int numOtherTeachers,
                              string? specAttachName, string? specAttachDesc, int color, int numPhdHolders, int? practicalHours, int? theoreticalHours)
        {
            _insId = insId;
            _type = type;
            _numStu = numStu;
            _numProf = numProf;
            _numAssociative = numAssociative;
            _numAssistant = numAssistant;
            _numberLecturers = numberLecturers;
            _numAssisLecturer = numAssisLecturer;
            _numProfPractice = numProfPractice;
            _numOtherTeachers = numOtherTeachers;
            _specAttachName = specAttachName;
            _specAttachDesc = specAttachDesc;
            _color = color;
            _numPhdHolders = numPhdHolders;
            _practicalHours = practicalHours;
            _theoreticalHours = theoreticalHours;
        }
        public Specialization() { }
        

        // Properties
        public int InsID { get => _insId; set => _insId = value; } // معرف الكيان
        public string Type { get => _type; set => _type = value; } // نوع الكيان
        public int NumStu { get => _numStu; set => _numStu = value; } // عدد الطلاب
        //public int NumFreeProf { get => _numFreeProf; set => _numFreeProf = value; } // عدد المدرسين المتفرغين
        //public int NumPartTimeProf { get => _numPartTimeProf; set => _numPartTimeProf = value; } // عدد المدرسين غير المتفرغين
        public int NumProf { get => _numProf; set => _numProf = value; } // عدد الأساتذة
        public int NumAssociative { get => _numAssociative; set => _numAssociative = value; } // عدد الأساتذة المشاركين
        public int NumAssistant { get => _numAssistant; set => _numAssistant = value; } // عدد الأساتذة المساعدين
        public int? NumProfPractice { get => _numProfPractice; set => _numProfPractice = value; }
        //public int NumMusharek { get => _numMusharek; set => _numMusharek = value; } // عدد المشاركين
        //public int NumMusa3ed { get => _numMusa3ed; set => _numMusa3ed = value; } // عدد المساعدين
        public int NumberLecturers { get => _numberLecturers; set => _numberLecturers = value; } // عدد المدرسين
        public int NumAssisLecturer { get => _numAssisLecturer; set => _numAssisLecturer = value; } // عدد المدرسين المساعدين
        public int NumOtherTeachers { get => _numOtherTeachers; set => _numOtherTeachers = value; } // عدد المدرسين الآخرين
        public string? SpecAttachName { get => _specAttachName; set => _specAttachName = value; } // اسم المرفق
        public string? SpecAttachDesc { get => _specAttachDesc; set => _specAttachDesc = value; } // وصف المرفق

        public int NumPhdHolders { get => _numPhdHolders; set => _numPhdHolders = value; }
        public int? PracticalHours { get => _practicalHours; set => _practicalHours = value; }

        public int? TheoreticalHours { get => _theoreticalHours; set => _theoreticalHours = value; }
        public int Color { get => _color; set => _color = value; }
        // ToString method for debugging or display purposes
        public override string ToString()
        {
            return $"{_type} {_numStu} {_numProf} {_numAssociative} " +
                   $"{_numAssistant} {_numProfPractice} {_numberLecturers} {_numAssisLecturer} " +
                   $"{_numOtherTeachers} {_specAttachName} {_specAttachDesc} {_color} {_numPhdHolders} {_practicalHours} {_theoreticalHours}";
        }
    }
}
//{_numMusharek} {_numMusa3ed}