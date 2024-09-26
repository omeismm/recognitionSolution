using System.Text.Json;

namespace recognitionProj
{
    public class SuggestionRecord
    {
        private DateOnly _date;
        private string _suggestion;

        public SuggestionRecord(DateOnly date, string suggestion)
        {
            _date = date;
            _suggestion = suggestion;
        }

        public SuggestionRecord(string json) // constructor from a JSON input
        {
            var jsonDoc = JsonDocument.Parse(json); // Parse the JSON string
            var root = jsonDoc.RootElement;

            // Parsing the DateOnly as a string and then converting to DateOnly
            _date = DateOnly.Parse(root.GetProperty("date").GetString());
            _suggestion = root.GetProperty("suggestion").GetString();
        }

        public DateOnly Date
        {
            get => _date;
            set => _date = value;
        }

        public string Suggestion
        {
            get => _suggestion;
            set => _suggestion = value;
        }

        public string ToJson() // Converts the object to a JSON string
        {
            var jsonString = JsonSerializer.Serialize(new
            {
                date = _date.ToString("yyyy-MM-dd"), // Formatting DateOnly to a string
                suggestion = _suggestion
            });
            return jsonString;
        }

        public override string ToString()
        {
            return _date + " " + _suggestion;
        }
    }
}