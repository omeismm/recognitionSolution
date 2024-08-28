namespace recognitionProj
{
    public class Library
    {
        private string _name;
        private int _booksPerCourse;//must be at least 5 books per course
        private int _duplicateBooks;//must be at least 2 duplicate books per title
        private int _uniqueBooks;//must be at least 50 unique books per course
        private bool _hasJournals;//true if the library has one journal at least for the specialization, false otherwise
        private bool _hasBasicBooks;//true if the library has basic books like dictionaries, encyclopedias for the specialization, false otherwise
        private bool _hasOpenEndedCourses;//true if the library has open ended courses for the specialization, false otherwise
        private bool _hasEBooks;//true if the library has eBooks for the specialization, false otherwise

        public Library(string name, int booksPerCourse, int duplicateBooks, int uniqueBooks, bool hasJournals, bool hasBasicBooks, bool hasOpenEndedCourses, bool hasEBooks)
        {
            _name = name;
            _booksPerCourse = booksPerCourse;
            _duplicateBooks = duplicateBooks;
            _uniqueBooks = uniqueBooks;
            _hasJournals = hasJournals;
            _hasBasicBooks = hasBasicBooks;
            _hasOpenEndedCourses = hasOpenEndedCourses;
            _hasEBooks = hasEBooks;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int BooksPerCourse
        {
            get { return _booksPerCourse; }
            set { _booksPerCourse = value; }
        }

        public int DuplicateBooks
        {
            get { return _duplicateBooks; }
            set { _duplicateBooks = value; }
        }

        public int UniqueBooks
        {
            get { return _uniqueBooks; }
            set { _uniqueBooks = value; }
        }

        public bool HasJournals
        {
            get { return _hasJournals; }
            set { _hasJournals = value; }
        }

        public bool HasBasicBooks
        {
            get { return _hasBasicBooks; }
            set { _hasBasicBooks = value; }
        }

        public bool HasOpenEndedCourses
        {
            get { return _hasOpenEndedCourses; }
            set { _hasOpenEndedCourses = value; }
        }

        public bool HasEBooks
        {
            get { return _hasEBooks; }
            set { _hasEBooks = value; }
        }

        public override string ToString()
        {
            return _name;
        }


    }
}
