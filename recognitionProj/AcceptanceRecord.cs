namespace recognitionProj
{
    public class AcceptanceRecord //this is to record the acceptance or decline of the university with the reason
    {
        private bool _isAccepted;
        private DateOnly _date;//date of record
        private string _reason;//reason of acceptance or decline. if it is declined because of fees and the university applies again, their application will be delayed by one semester (article 16 of pdf 22222)

        public AcceptanceRecord(bool isAccepted, DateOnly date, string reason)
        {
            _isAccepted = isAccepted;
            _date = date;
            _reason = reason;
        }

        public bool IsAccepted
        {
            get { return _isAccepted; }
            set { _isAccepted = value; }
        }

        public DateOnly Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        public override string ToString()
        {
            return _isAccepted + " on " + _date + " because " + _reason;
        }
    }
}
