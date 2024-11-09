namespace recognitionProj
{
    public class AdmissionRules //todo controller and db handler
    {
        private int _insID;
        private string _admissionRule;
        private string _admissionDegree;

        public AdmissionRules(int insID, string admissionRule, string admissionDegree)
        {
            _insID = insID;
            _admissionRule = admissionRule;
            _admissionDegree = admissionDegree;
        }

        public int InsID
        {
            get => _insID;
            set => _insID = value;
        }

        public string AdmissionRule
        {
            get => _admissionRule;
            set => _admissionRule = value;
        }

        public string AdmissionDegree
        {
            get => _admissionDegree;
            set => _admissionDegree = value;
        }
    }
}
