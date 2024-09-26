using System.Text.Json;

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
        var jsonDoc = JsonDocument.Parse(json); // Parse the JSON string
        var root = jsonDoc.RootElement;

        _isAccepted = root.GetProperty("isAccepted").GetBoolean(); // Extract isAccepted from the JSON
        _date = DateOnly.Parse(root.GetProperty("date").GetString()); // Extract and parse the date
        _reason = new List<string>();

        // Extract the array of reasons
        foreach (var reason in root.GetProperty("reason").EnumerateArray())
        {
            _reason.Add(reason.GetString());
        }
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

    public string ToJson() // Converts the object to a JSON string
    {
        var jsonString = JsonSerializer.Serialize(new
        {
            isAccepted = _isAccepted,
            date = _date.ToString("yyyy-MM-dd"), // Convert DateOnly to string
            reason = _reason
        });

        return jsonString; // Return the serialized JSON
    }

    public override string ToString()
    {
        return _isAccepted + " on " + _date + " because " + string.Join(", ", _reason);
    }

    
}
