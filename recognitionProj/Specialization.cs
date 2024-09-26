using System.Text.Json;

namespace recognitionProj;

public class Specialization
{
    private string _name;
    private string _type;
    private int _numOfStudents;
    private int _numOfFreeTeachers;
    private int _numOfOstadh;
    private int _numOfMusharek;
    private int _numOfOstadhMusa3ed;
    private int _numberOfLecturers;
    private int _numOfMudaresMusa3ed;
    private int _numOfOtherTeachers;

    public Specialization(string name, string type, int numOfStudents, int numOfFreeTeachers, int numOfOstadh, int numOfMusharek, int numOfOstadhMusa3ed, int numberOfLecturers, int numOfMudaresMusa3ed, int numOfOtherTeachers)
    {
        _name = name;
        _type = type;
        _numOfStudents = numOfStudents;
        _numOfFreeTeachers = numOfFreeTeachers;
        _numOfOstadh = numOfOstadh;
        _numOfMusharek = numOfMusharek;
        _numOfOstadhMusa3ed = numOfOstadhMusa3ed;
        _numberOfLecturers = numberOfLecturers;
        _numOfMudaresMusa3ed = numOfMudaresMusa3ed;
        _numOfOtherTeachers = numOfOtherTeachers;
    }

    public Specialization(string json) // constructor from a JSON input
    {
        var jsonDoc = JsonDocument.Parse(json); // Parse the JSON string
        var root = jsonDoc.RootElement;

        _name = root.GetProperty("name").GetString();
        _type = root.GetProperty("type").GetString();
        _numOfStudents = root.GetProperty("numOfStudents").GetInt32();
        _numOfFreeTeachers = root.GetProperty("numOfFreeTeachers").GetInt32();
        _numOfOstadh = root.GetProperty("numOfOstadh").GetInt32();
        _numOfMusharek = root.GetProperty("numOfMusharek").GetInt32();
        _numOfOstadhMusa3ed = root.GetProperty("numOfOstadhMusa3ed").GetInt32();
        _numberOfLecturers = root.GetProperty("numberOfLecturers").GetInt32();
        _numOfMudaresMusa3ed = root.GetProperty("numOfMudaresMusa3ed").GetInt32();
        _numOfOtherTeachers = root.GetProperty("numOfOtherTeachers").GetInt32();
    }


    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Type
    {
        get => _type;
        set => _type = value;
    }

    public int NumOfStudents
    {
        get => _numOfStudents;
        set => _numOfStudents = value;
    }

    public int NumOfFreeTeachers
    {
        get => _numOfFreeTeachers;
        set => _numOfFreeTeachers = value;
    }

    public int NumOfOstadh
    {
        get => _numOfOstadh;
        set => _numOfOstadh = value;
    }

    public int NumOfMusharek
    {
        get => _numOfMusharek;
        set => _numOfMusharek = value;
    }

    public int NumOfOstadhMusa3ed
    {
        get => _numOfOstadhMusa3ed;
        set => _numOfOstadhMusa3ed = value;
    }

    public int NumberOfLecturers
    {
        get => _numberOfLecturers;
        set => _numberOfLecturers = value;
    }

    public int NumOfMudaresMusa3ed
    {
        get => _numOfMudaresMusa3ed;
        set => _numOfMudaresMusa3ed = value;
    }

    public int NumOfOtherTeachers
    {
        get => _numOfOtherTeachers;
        set => _numOfOtherTeachers = value;
    }

    public string ToJson() // Converts the object to a JSON string
    {
        var jsonString = JsonSerializer.Serialize(new
        {
            name = _name,
            type = _type,
            numOfStudents = _numOfStudents,
            numOfFreeTeachers = _numOfFreeTeachers,
            numOfOstadh = _numOfOstadh,
            numOfMusharek = _numOfMusharek,
            numOfOstadhMusa3ed = _numOfOstadhMusa3ed,
            numberOfLecturers = _numberOfLecturers,
            numOfMudaresMusa3ed = _numOfMudaresMusa3ed,
            numOfOtherTeachers = _numOfOtherTeachers
        });

        return jsonString; // Return the serialized JSON string
    }

    public override string ToString()
    {
        return _name + " is a " + _type + " specialization with " + _numOfStudents + " students, " + _numOfFreeTeachers + " free teachers, " + _numOfOstadh + " Ostadh, " + _numOfMusharek + " Musharek, " + _numOfOstadhMusa3ed + " Ostadh Musa3ed, " + _numberOfLecturers + " lecturers, " + _numOfMudaresMusa3ed + " Mudares Musa3ed, and " + _numOfOtherTeachers + " other teachers.";
    }
}
