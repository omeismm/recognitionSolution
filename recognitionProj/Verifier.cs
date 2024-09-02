namespace recognitionProj
{
    public class Verifier//this class takes the university object and verivies everything in it
    {
        private University _uni;
        private string[] _message;
        public Verifier(University uni)
        {
            _uni = uni;
            _message[0] = "Please run the verifier"; 
        }
        public string[] Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public University Uni
        {
            get { return _uni; }
            set { _uni = value; }
        }
    }
}
