using System.Collections.Generic;

namespace Advanced_Sets.Set
{
    public class CSetTree
    {
        public string RootElement { get; private set; }
        public List<CSetTree> SubSets { get; private set; }
        public int Cardinality { get; private set; }
        public CSetTree(string rootElement, int cardinality = 0)
        {
            SubSets = new List<CSetTree>();
            this.RootElement = rootElement;
            this.Cardinality = cardinality;
        }//ctor 01 
        public CSetTree(string rootElement,List<CSetTree> SubSets, int cardinality = 0)
            : this(rootElement,cardinality)
        {
            this.SubSets = SubSets;
        }//ctor 02
        public void AddSubSetTree(CSetTree tree)
        {
            SubSets.Add(tree);
            Cardinality++;
        }//AddSubTree
    }//CTRee
}//namespace