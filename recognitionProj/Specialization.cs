using Newtonsoft.Json;

namespace recognitionProj;

public class Specialization
{
    private string _name;
    private string _type;
    private int _numOfStudents;
    private int _numOfFullTimeTeachers;//mutafare3'
    private int _numOfPartTimeTeachers;//not mutafare3'
    private int _numOfOstadh;
    private int _numOfMusharek;
    private int _numOfOstadhMusa3ed;
    private int _numberOfLecturers;
    private int _numOfMudaresMusa3ed;
    private int _numOfOtherTeachers;

    public Specialization(string name, string type, int numOfStudents, int numOfFullTimeTeachers,int numOfPartTimeTeachers , int numOfOstadh, int numOfMusharek, int numOfOstadhMusa3ed, int numberOfLecturers, int numOfMudaresMusa3ed, int numOfOtherTeachers)
    {
        _name = name;
        _type = type;
        _numOfStudents = numOfStudents;
        _numOfFullTimeTeachers = numOfFullTimeTeachers;
        _numOfPartTimeTeachers = numOfPartTimeTeachers;
        _numOfOstadh = numOfOstadh;
        _numOfMusharek = numOfMusharek;
        _numOfOstadhMusa3ed = numOfOstadhMusa3ed;
        _numberOfLecturers = numberOfLecturers;
        _numOfMudaresMusa3ed = numOfMudaresMusa3ed;
        _numOfOtherTeachers = numOfOtherTeachers;
    }

    //public Specialization(string json) // constructor from a JSON input
    //
        //todo using newtonsoft package (unnecessary)
    //}


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

    public int NumOfFullTimeTeachers
    {
        get => _numOfFullTimeTeachers;
        set => _numOfFullTimeTeachers = value;
    }

    public int NumOfPartTimeTeachers
    {
        get => _numOfPartTimeTeachers;
        set => _numOfPartTimeTeachers = value;
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

 

    public override string ToString()
    {
        return _name + " is a " + _type + " specialization with " + _numOfStudents + " students, " + _numOfFullTimeTeachers + " free teachers, " + _numOfOstadh + " Ostadh, " + _numOfMusharek + " Musharek, " + _numOfOstadhMusa3ed + " Ostadh Musa3ed, " + _numberOfLecturers + " lecturers, " + _numOfMudaresMusa3ed + " Mudares Musa3ed, and " + _numOfOtherTeachers + " other teachers.";
    }
}
