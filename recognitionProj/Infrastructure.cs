using Microsoft.AspNetCore.Http.HttpResults;

namespace recognitionProj
{
    public class Infrastructure // todo controller and db handler
    {
        private int _insID;
        private int? _area;
        private int? _sites;
        private int? _terr;
        private int? _halls;
        private int? _library;
        private string _labsAttach;
        private string _build;

        // Constructor
        public Infrastructure(int insID, int? area, int? sites, int? terr, int? halls, int? library, string labsAttach, string build)
        {
            _insID = insID;
            _area = area;
            _sites = sites;
            _terr = terr;
            _halls = halls;
            _library = library;
            _labsAttach = labsAttach;
            _build = build;
        }

        // Properties
        public int InsID
        {
            get => _insID;
            set => _insID = value;
        }

        public int? Area
        {
            get => _area;
            set => _area = value;
        }

        public int? Sites
        {
            get => _sites;
            set => _sites = value;
        }

        public int? Terr
        {
            get => _terr;
            set => _terr = value;
        }

        public int? Halls
        {
            get => _halls;
            set => _halls = value;
        }

        public int? Library
        {
            get => _library;
            set => _library = value;
        }

        public string LabsAttach
        {
            get => _labsAttach;
            set => _labsAttach = value;
        }

        public string Build
        {
            get => _build;
            set => _build = value;
        }
    }
}
