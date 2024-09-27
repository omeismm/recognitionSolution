using Newtonsoft.Json;

namespace recognitionProj;

public class AcceptanceRecord //this is to record the acceptance or decline of the university with the reason
{
    private bool _isAccepted;/// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private DateOnly _date;//date of record
    private List<string> _reason;//reason of acceptance or decline. if it is declined because of fees and the university applies again, their application will be delayed by one semester (article 16 of pdf 22222)

    public AcceptanceRecord(bool isAccepted, DateOnly date, List<string> reason)
    {
        _isAccepted = isAccepted;
        _date = date;
        _reason = reason;
    }

    public AcceptanceRecord(string json) // constructor from a JSON input
    {
        //todo using newtonsoft package
    }




    public bool IsAccepted
    {
        get => _isAccepted;
        set => _isAccepted = value;
    }

    public DateOnly Date
    {
        get => _date;
        set => _date = value;
    }

    public List<string> Reason
    {
        get => _reason;
        set => _reason = value;
    }

 

    public override string ToString()
    {
        return _isAccepted + " on " + _date + " because " + string.Join(", ", _reason);
    }

    
}
