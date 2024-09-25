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

        public override string ToString()
        {
            return _date + " " + _suggestion;
        }
    }
}