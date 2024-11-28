using Microsoft.AspNetCore.Http.HttpResults;

namespace recognitionProj
{
    public class Users // todo controller and db handler
    {
        private int _insID;
        private string _insName;
        private string _insCountry;
        private string _email;
        private string _password;
        private string _verificationCode;
        private int? _verified;
        private int _clearance;//0 for university, 1 for supervisor, 2 for master admin
        private string _speciality;//to distribute the supervisors to the universities

        // Constructor
        public Users(int insID, string insName, string insCountry, string email, string password, string verificationCode, int? verified, int clearance, string speciality)
        {
            _insID = insID;
            _insName = insName;
            _insCountry = insCountry;
            _email = email;
            _password = password;
            _verificationCode = verificationCode;
            _verified = verified;
            _clearance = clearance;
            _speciality = speciality;
        }
        

        // Properties
        public int InsID
        {
            get => _insID;
            set => _insID = value;
        }

        public string InsName
        {
            get => _insName;
            set => _insName = value;
        }

        public string InsCountry
        {
            get => _insCountry;
            set => _insCountry = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string VerificationCode
        {
            get => _verificationCode;
            set => _verificationCode = value;
        }

        public int? Verified
        {
            get => _verified;
            set => _verified = value;
        }
        public int Clearance
        {
            get => _clearance;
            set => _clearance = value;
        }
        public string Speciality
        {
            get => _speciality;
            set => _speciality = value;
        }
    }
}
