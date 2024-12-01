namespace recognitionProj
{
    public class PublicInfo//todo: the database saving function and controller
    {
        private int _insID;
        private string _insName;
        private string _provider;
        private string _startDate;
        private string _sDateT;
        private string _sDateNT;
        private int? _supervisorID;  // Can be null, so use int?
        private string _supervisor;
        private string _preName;
        private string _preDegree;
        private string _preMajor;
        private string _postal;
        private string _phone;
        private string _fax;
        private string _email;
        private string _website;
        private string _vision;
        private string _mission;
        private string _goals;
        private string _insValues;
        private string _lastEditDate;
        //from here on are the new fields that are based on the university class but
        //todo make sure to add the new fields to the db handler and the controller and the database
        private DateOnly _entryDate;

        public DateOnly EntryDate
        {
            get => _entryDate;
            set => _entryDate = value;
        }
        private string _country;

        public string Country
        {
            get => _country;
            set => _country = value;
        }
        private string _city;

        public string City
        {
            get => _city;
            set => _city = value;
        }
        private string _address;

        public string Address
        {
            get => _address;
            set => _address = value;
        }
        private DateOnly _creationDate;

        public DateOnly CreationDate
        {
            get => _creationDate;
            set => _creationDate = value;
        }
        private DateOnly _studentAcceptanceDate;

        public DateOnly StudentAcceptanceDate
        {
            get => _studentAcceptanceDate;
            set => _studentAcceptanceDate = value;
        }
        private string _otherInfo;

        public string OtherInfo
        {
            get => _otherInfo;
            set => _otherInfo = value;
        }

        public PublicInfo(int insID, string insName, string provider, string startDate, string sDateT, string sDateNT,
                          int? supervisorID, string supervisor, string preName, string preDegree, string preMajor,
                          string postal, string phone, string fax, string email, string website, string vision,
                          string mission, string goals, string insValues, string lastEditDate, DateOnly entryDate, string country, string city, string address,
                  DateOnly creationDate, DateOnly studentAcceptanceDate, string otherInfo)
        {
            _insID = insID;
            _insName = insName;
            _provider = provider;
            _startDate = startDate;
            _sDateT = sDateT;
            _sDateNT = sDateNT;
            _supervisorID = supervisorID;
            _supervisor = supervisor;
            _preName = preName;
            _preDegree = preDegree;
            _preMajor = preMajor;
            _postal = postal;
            _phone = phone;
            _fax = fax;
            _email = email;
            _website = website;
            _vision = vision;
            _mission = mission;
            _goals = goals;
            _insValues = insValues;
            _lastEditDate = lastEditDate;
            // Existing assignments...
            //todo add the new fields to the db handler and the controller and the database
            _entryDate = entryDate;
            _country = country;
            _city = city;
            _address = address;
            _creationDate = creationDate;
            _studentAcceptanceDate = studentAcceptanceDate;
            _otherInfo = otherInfo;
        }

        public int InsID
        {
            get => _insID;
            set => _insID = value;
        }

        public string InsName
        {
            get => _insName;
            set => _insName = value;
        }

        public string Provider
        {
            get => _provider;
            set => _provider = value;
        }

        public string StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public string SDateT
        {
            get => _sDateT;
            set => _sDateT = value;
        }

        public string SDateNT
        {
            get => _sDateNT;
            set => _sDateNT = value;
        }

        public int? SupervisorID
        {
            get => _supervisorID;
            set => _supervisorID = value;
        }

        public string Supervisor
        {
            get => _supervisor;
            set => _supervisor = value;
        }

        public string PreName
        {
            get => _preName;
            set => _preName = value;
        }

        public string PreDegree
        {
            get => _preDegree;
            set => _preDegree = value;
        }

        public string PreMajor
        {
            get => _preMajor;
            set => _preMajor = value;
        }

        public string Postal
        {
            get => _postal;
            set => _postal = value;
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public string Fax
        {
            get => _fax;
            set => _fax = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Website
        {
            get => _website;
            set => _website = value;
        }

        public string Vision
        {
            get => _vision;
            set => _vision = value;
        }

        public string Mission
        {
            get => _mission;
            set => _mission = value;
        }

        public string Goals
        {
            get => _goals;
            set => _goals = value;
        }

        public string InsValues
        {
            get => _insValues;
            set => _insValues = value;
        }

        public string LastEditDate
        {
            get => _lastEditDate;
            set => _lastEditDate = value;
        }
    }
}
