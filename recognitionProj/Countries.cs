using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;

namespace recognitionProj
{
    public class Countries // todo controller and db handler
    {
        private int _countryNO;
        private string _countryNameAR;
        private string _countryNameEN;

        // Constructor
        public Countries(int countryNO, string countryNameAR, string countryNameEN)
        {
            _countryNO = countryNO;
            _countryNameAR = countryNameAR;
            _countryNameEN = countryNameEN;
        }

        // Properties
        public int CountryNO
        {
            get => _countryNO;
            set => _countryNO = value;
        }

        public string CountryNameAR
        {
            get => _countryNameAR;
            set => _countryNameAR = value;
        }

        public string CountryNameEN
        {
            get => _countryNameEN;
            set => _countryNameEN = value;
        }
    }
}
