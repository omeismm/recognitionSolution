using Microsoft.AspNetCore.Http.HttpResults;

namespace recognitionProj
{
    public class Pictures // todo controller and db handler
    {
        private int _insID;
        private int _attachID;  // Identity column
        private string _attachName;
        private string _attachDesc;

        // Constructor
        public Pictures(int insID, int attachID, string attachName, string attachDesc)
        {
            _insID = insID;
            _attachID = attachID;
            _attachName = attachName;
            _attachDesc = attachDesc;
        }

        // Properties
        public int InsID
        {
            get => _insID;
            set => _insID = value;
        }

        public int AttachID
        {
            get => _attachID;
            set => _attachID = value;
        }

        public string AttachName
        {
            get => _attachName;
            set => _attachName = value;
        }

        public string AttachDesc
        {
            get => _attachDesc;
            set => _attachDesc = value;
        }
    }
}
