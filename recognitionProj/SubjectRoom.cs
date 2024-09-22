namespace recognitionProj
{
    public class SubjectRoom//this is the class for the rooms inside the uni
    {
        private string _name;
        private double _area;
        private int _numOfChairs;

        public SubjectRoom(string name, double area, int numOfChairs)
        {
            _name = name;
            _area = area;
            _numOfChairs = numOfChairs;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public int NumOfChairs
        {
            get { return _numOfChairs; }
            set { _numOfChairs = value; }
        }

        public override string ToString()
        {
            return _name + " with " + _area + " area and " + _numOfChairs + " chairs";
        }
    }
}
