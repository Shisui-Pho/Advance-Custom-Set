using System;
using SetLibrary;
using SetLibrary.Generic;
namespace Advanced_Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expressionA = "{7,2,9,1,7,8,{3,1,2}}";
            string expressionB = "{8,6,1,{{1,1}}}";

            ISet<string> setA = new CSet(expressionA);
            ISet<string> setB = new CSet(expressionB);

            ISet<string> merged = setA.MergeWith(setB);
            Console.ReadLine();
        }//Main
        private static void TestISetTree()
        {
            //Test CSet
            string expression = "{2,{9,8},{16,17,8},{8,8,9,8,8},{8,8},{8,8}}";
            ISet<string> set = new CSet(expression);
            ISetTree<string> tree = set[3];
            Console.WriteLine("The expression is :  {0} ", expression);
            Console.WriteLine("The element string will be  :  {0} ", set.ElementString);
            Console.WriteLine("The cardinality will be : {0}  ", set.Cardinality);
            Console.WriteLine("The set/element in index {0} is {1} ", 3, set[3]);
            set.RemoveElement(tree);
            Console.WriteLine("Removed the following tree : {0}", tree);
            Console.WriteLine("The element string will be  :  {0} ", set.ElementString);
            set.RemoveElement("2");
            Console.WriteLine("Remove the following element : \"2\"");
            Console.WriteLine("The element string will be  :  {0} ", set.ElementString);
            tree.AddElement("{2,6,7}");
            tree.AddElement("{2,2}");
            set.AddElement(tree);
            Console.WriteLine("Added the following element: {0}", tree);
            Console.WriteLine("The element string will be  :  {0} ", set.ElementString);
            //TestCSet();
            //TestGenericSetWithNumbers();
        }//TestISetTree
        private static void TestCSet()
        {
            Console.WriteLine("TESTING CSet : Non-Generic set");
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.WriteLine("Please note that the sorting may not be acurate because it does a string sorting!");
            Console.WriteLine();
            Console.WriteLine();

            string expression = "{1,{2,{5,{6,6,7,{6},{6}}},{7}},{8}}";
            Console.WriteLine("The expression is : " + expression);
            CSet set = new CSet(expression);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{{{{{{{{6}}}}}}}}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{5,5,3,{6,{5,8},{5,3},5,6},{6,{5,8},{5,3},5,6},7}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{5,2,1,0}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{ 8, 7, 5, 2, 14, 1, { 5, 8, 9, 6, 33 } }";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{5,5,3,{6,{5,8},5,6},7}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Finnished!!!");
            Console.Write("Press any key to see the generic set(with integers : generic version of the above data).......");
            Console.ReadLine();
            Console.Clear();
        }//TestCSet
        private static void TestGenericSetWithNumbers()
        {
            Console.WriteLine("Test Generic set : Using intagers");
            Console.WriteLine("=================================");
            Console.WriteLine("Note that the integers are seperated by a comma (\",\")");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string expression = "{5,5,3,{6,{5,8},{5,3},5,6},{6,{5,8},{5,3},5,6},7}";
            Console.WriteLine("The expression is : " + expression);
            GenericSet<int> set = new GenericSet<int>(expression, ',');
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{{{{{{{{6}}}}}}}}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, ',');
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{1,{2,{5},{7}},{8}}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, ',');
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{5,2,1,0}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, ',');
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{ 8, 7, 5, 2, 14, 1, { 5, 8, 9, 6, 33 } }";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, ',');
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{5,5,3,{6,{5,8},5,6},7}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, ',');
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Finnished!!!");
            Console.Write("Press any key to see the generic set.......");
            Console.ReadLine();
        }//TestGenericSetWithNumbers
        private static void TestGenericSetWithObjects()
        {

        }//TestGenericSetWithObjects
    }//class
}//namespace