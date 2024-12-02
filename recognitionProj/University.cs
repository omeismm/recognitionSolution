namespace recognitionProj;

public class University//todo delete this class or maybe keep it as reference to look at the fields
{
    private int _id; // Mapped to _insID in both AcademicInfo and PublicInfo
    private string _name; // Mapped to _insName in PublicInfo
    private DateOnly _entryDate; // Mapped to _entryDate in PublicInfo
    private string _supervisor; // Mapped to _supervisor in PublicInfo
    private string _country; // Mapped to _country in PublicInfo
    private string _city; // Mapped to _city in PublicInfo
    private string _address; // Mapped to _address in PublicInfo
    private string _website; // Mapped to _website in PublicInfo
    private DateOnly _creationDate; // Mapped to _creationDate in PublicInfo
    private DateOnly _studentAcceptanceDate; // Mapped to _studentAcceptanceDate in PublicInfo
    private DateOnly _startDate; // Mapped to _startDate in PublicInfo
    private string _type; // Mapped to _insType in AcademicInfo
    private string _language; // Mapped to _studyLangCitizen and _studyLangInter in AcademicInfo
    private string _educationType; // Mapped to _educationType in AcademicInfo
    private string[] _availableDegrees; // Mapped to _availableDegrees in AcademicInfo
    private string _hoursSystem; // Mapped to _studySystem in AcademicInfo
    private string[] _faculties; // Mapped to _faculties in AcademicInfo
    private int _arwuRank; // Mapped to _arwuRank in AcademicInfo
    private int _theRank; // Mapped to _theRank in AcademicInfo
    private int _qsRank; // Mapped to _qsRank in AcademicInfo
    private string _otherRank; // Mapped to _otherRank in AcademicInfo
    private int _numOfScopusResearches; // Mapped to _numOfScopusResearches in AcademicInfo
    private int _scopusFrom; // Mapped to _scopusFrom in AcademicInfo
    private int _scopusTo; // Mapped to _scopusTo in AcademicInfo
    private string _infrastructure; // Mapped to _infrastructure in AcademicInfo
    private string _otherInfo; // Mapped to _otherInfo in PublicInfo
    private AcceptanceRecord[] _acceptanceRecords; // Mapped to _acceptanceRecords in AcademicInfo
    private SuggestionRecord[] _suggestionRecords; // Deleted as per comment in University class
    private Specialization[] _specializations; // deleted because in the database it is a separate table that is linked by institution id
    private bool _accepted; // Mapped to _accepted in AcademicInfo


public University(int id,string name, DateOnly entryDate, string supervisor, string country, string city, string address, string website, DateOnly creationDate, DateOnly studentAcceptanceDate, DateOnly startDate, string type, string language, string educationType, string[] availableDegrees, string hoursSystem, string[] faculties, int arwuRank, int theRank, int qsRank, string otherRank, int numOfScopusResearches, int scopusFrom, int scopusTo, string infrastructure, string otherInfo, AcceptanceRecord[] acceptanceRecords, SuggestionRecord[] suggestionRecords, Specialization[] specializations , bool accepted)
    {
        _id = id;
        _name = name;
        _entryDate = entryDate;
        _supervisor = supervisor;
        _country = country;
        _city = city;
        _address = address;
        _website = website;
        _creationDate = creationDate;
        _studentAcceptanceDate = studentAcceptanceDate;
        _startDate = startDate;
        _type = type;
        _language = language;
        _educationType = educationType;
        _availableDegrees = availableDegrees;
        _hoursSystem = hoursSystem;
        _faculties = faculties;
        _arwuRank = arwuRank;
        _theRank = theRank;
        _qsRank = qsRank;
        _otherRank = otherRank;
        _numOfScopusResearches = numOfScopusResearches;
        _scopusFrom = scopusFrom;
        _scopusTo = scopusTo;
        _infrastructure = infrastructure;
        _otherInfo = otherInfo;
        _acceptanceRecords = acceptanceRecords;
        _suggestionRecords = suggestionRecords;
        _specializations = specializations;
        _accepted = accepted;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public DateOnly EntryDate
    {
        get => _entryDate;
        set => _entryDate = value;
    }

    public string Supervisor
    {
        get => _supervisor;
        set => _supervisor = value;
    }

    public string Country
    {
        get => _country;
        set => _country = value;
    }

    public string City
    {
        get => _city;
        set => _city = value;
    }

    public string Address
    {
        get => _address;
        set => _address = value;
    }

    public string Website
    {
        get => _website;
        set => _website = value;
    }

    public DateOnly CreationDate
    {
        get => _creationDate;
        set => _creationDate = value;
    }

    public DateOnly StudentAcceptanceDate
    {
        get => _studentAcceptanceDate;
        set => _studentAcceptanceDate = value;
    }

    public DateOnly StartDate
    {
        get => _startDate;
        set => _startDate = value;
    }

    public string Type
    {
        get => _type;
        set => _type = value;
    }

    public string Language
    {
        get => _language;
        set => _language = value;
    }

    public string EducationType
    {
        get => _educationType;
        set => _educationType = value;
    }

    public string[] AvailableDegrees
    {
        get => _availableDegrees;
        set => _availableDegrees = value;
    }

    public string HoursSystem
    {
        get => _hoursSystem;
        set => _hoursSystem = value;
    }

    public string[] Faculties
    {
        get => _faculties;
        set => _faculties = value;
    }

    public int ARWURank
    {
        get => _arwuRank;
        set => _arwuRank = value;
    }

    public int THERank
    {
        get => _theRank;
        set => _theRank = value;
    }

    public int QSRank
    {
        get => _qsRank;
        set => _qsRank = value;
    }

    public string OtherRank
    {
        get => _otherRank;
        set => _otherRank = value;
    }

    public int NumOfScopusResearches
    {
        get => _numOfScopusResearches;
        set => _numOfScopusResearches = value;
    }

    public int ScopusFrom
    {
        get => _scopusFrom;
        set => _scopusFrom = value;
    }

    public int ScopusTo
    {
        get => _scopusTo;
        set => _scopusTo = value;
    }

    public string Infrastructure
    {
        get => _infrastructure;
        set => _infrastructure = value;
    }

    public string OtherInfo
    {
        get => _otherInfo;
        set => _otherInfo = value;
    }

    public AcceptanceRecord[] AcceptanceRecords
    {
        get => _acceptanceRecords;
        set => _acceptanceRecords = value;
    }

    public SuggestionRecord[] SuggestionRecords
    {
        get => _suggestionRecords;
        set => _suggestionRecords = value;
    }

    public Specialization[] Specializations
    {
        get => _specializations;
        set => _specializations = value;
    }

    public bool Accepted
    {
        get => _accepted;
        set => _accepted = value;
    }

    public override string ToString()
    {
        return _name;
    }
}
