using Microsoft.AspNetCore.Http.HttpResults;

namespace recognitionProj
{
    public class Library // todo controller and db handler
    {
        private int _insID;
        private int? _area;
        private int? _capacity;
        private int? _arBooks;
        private int? _enBooks;
        private int? _papers;
        private int? _eBooks;
        private int? _eSubscription;

        // Constructor
        public Library(int insID, int? area, int? capacity, int? arBooks, int? enBooks, int? papers, int? eBooks, int? eSubscription)
        {
            _insID = insID;
            _area = area;
            _capacity = capacity;
            _arBooks = arBooks;
            _enBooks = enBooks;
            _papers = papers;
            _eBooks = eBooks;
            _eSubscription = eSubscription;
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

        public int? Capacity
        {
            get => _capacity;
            set => _capacity = value;
        }

        public int? ArBooks
        {
            get => _arBooks;
            set => _arBooks = value;
        }

        public int? EnBooks
        {
            get => _enBooks;
            set => _enBooks = value;
        }

        public int? Papers
        {
            get => _papers;
            set => _papers = value;
        }

        public int? EBooks
        {
            get => _eBooks;
            set => _eBooks = value;
        }

        public int? ESubscription
        {
            get => _eSubscription;
            set => _eSubscription = value;
        }
    }
}
