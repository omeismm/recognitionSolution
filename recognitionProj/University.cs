namespace recognitionProj;

public class University
{
    private string _name;
    private DateOnly _entryDate;
    private string _supervisor;
    private string _country;
    private string _city;
    private string _address;
    private string _website;
    private DateOnly _creationDate;
    private DateOnly _studentAcceptanceDate;
    private DateOnly _startDate;
    private string _type;
    private string _language;
    private string _educationType;
    private string[] _availableDegrees;
    private string _hoursSystem;
    private string[] _faculties;//this might be unnecesary
    private int _arwuRank;
    private int _theRank;
    private int _qsRank;
    private string _otherRank;
    private int _numOfScopusResearches;
    private int _scopusFrom;
    private int _scopusTo;
    private string _infrastructure;
    private string _otherInfo;
    private AcceptanceRecord[] _acceptanceRecords;
    private SuggestionRecord[] _suggestionRecords;
    private Specialization[] _specializations;//i added this even though its not on the readme
    private bool _accepted;

    public University(string name, DateOnly entryDate, string supervisor, string country, string city, string address, string website, DateOnly creationDate, DateOnly studentAcceptanceDate, DateOnly startDate, string type, string language, string educationType, string[] availableDegrees, string hoursSystem, string[] faculties, int arwuRank, int theRank, int qsRank, string otherRank, int numOfScopusResearches, int scopusFrom, int scopusTo, string infrastructure, string otherInfo, AcceptanceRecord[] acceptanceRecords, SuggestionRecord[] suggestionRecords, Specialization[] specializations , bool accepted)
    {
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
