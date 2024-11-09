using Microsoft.AspNetCore.Http.HttpResults;

namespace recognitionProj
{
    public class StudyDuration // todo controller and db handler
    {
        private int _insID;
        private string _diplomaDegreeMIN;
        private string _diplomaMIN;
        private string _bscDegreeMIN;
        private string _bscMIN;
        private string _higherDiplomaDegreeMIN;
        private string _higherDiplomaMIN;
        private string _masterDegreeMIN;
        private string _masterMIN;
        private string _phdDegreeMIN;
        private string _phdMIN;

        // Constructor
        public StudyDuration(int insID, string diplomaDegreeMIN, string diplomaMIN, string bscDegreeMIN, string bscMIN,
                             string higherDiplomaDegreeMIN, string higherDiplomaMIN, string masterDegreeMIN,
                             string masterMIN, string phdDegreeMIN, string phdMIN)
        {
            _insID = insID;
            _diplomaDegreeMIN = diplomaDegreeMIN;
            _diplomaMIN = diplomaMIN;
            _bscDegreeMIN = bscDegreeMIN;
            _bscMIN = bscMIN;
            _higherDiplomaDegreeMIN = higherDiplomaDegreeMIN;
            _higherDiplomaMIN = higherDiplomaMIN;
            _masterDegreeMIN = masterDegreeMIN;
            _masterMIN = masterMIN;
            _phdDegreeMIN = phdDegreeMIN;
            _phdMIN = phdMIN;
        }

        // Properties
        public int InsID
        {
            get => _insID;
            set => _insID = value;
        }

        public string DiplomaDegreeMIN
        {
            get => _diplomaDegreeMIN;
            set => _diplomaDegreeMIN = value;
        }

        public string DiplomaMIN
        {
            get => _diplomaMIN;
            set => _diplomaMIN = value;
        }

        public string BSCDegreeMIN
        {
            get => _bscDegreeMIN;
            set => _bscDegreeMIN = value;
        }

        public string BSCMIN
        {
            get => _bscMIN;
            set => _bscMIN = value;
        }

        public string HigherDiplomaDegreeMIN
        {
            get => _higherDiplomaDegreeMIN;
            set => _higherDiplomaDegreeMIN = value;
        }

        public string HigherDiplomaMIN
        {
            get => _higherDiplomaMIN;
            set => _higherDiplomaMIN = value;
        }

        public string MasterDegreeMIN
        {
            get => _masterDegreeMIN;
            set => _masterDegreeMIN = value;
        }

        public string MasterMIN
        {
            get => _masterMIN;
            set => _masterMIN = value;
        }

        public string PhDDegreeMIN
        {
            get => _phdDegreeMIN;
            set => _phdDegreeMIN = value;
        }

        public string PhDMIN
        {
            get => _phdMIN;
            set => _phdMIN = value;
        }
    }
}
