namespace SetLibrary
{
    public struct Set
    {
        public string Name { get; private set; }
        public string ElementString { get; private set; }
        public int Cardinality { get; private set; }
        internal Set(string name, string set, int Cardinality)
        {
            this.Name = name;
            this.ElementString = set;
            this.Cardinality = Cardinality;
        }//ctor
    }//structure
}//namespace