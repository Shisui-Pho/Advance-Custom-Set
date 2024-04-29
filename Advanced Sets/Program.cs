using System;
using SetLibrary;
using SetLibrary.Generic;
using SetLibrary.Operations;

namespace Advanced_Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCSet();
            TestGenericSetWithNumbers();
            TestISetTree();
            TestSetOperations();
            Console.ReadKey();
        }//Main
        private static void TestSetOperations()
        {
            Console.Clear();
            //For a generic sts
            Console.WriteLine("Testing set operations with a generic set class");
            Console.WriteLine("=================================================");
            Console.WriteLine();
            SetExtractionSettings<int> settings = new SetExtractionSettings<int>(",");
            int padding = 30;
            string expression = "{2,6,1,73,10,15,{8,6,{3},{7,5}}}";
            ISet<int> setA = new GenericSet<int>(expression,settings);
            Console.WriteLine("The orginial expression was".PadRight(padding) + " : " + expression);
            Console.WriteLine("Set A will be".PadRight(padding) + " : " + setA.ToString());

            Console.WriteLine();
            expression = "{5,{5,6,{2}},{8,{6}},2}";
            ISet<int> setB = new GenericSet<int>(expression, settings);
            Console.WriteLine("The orginial expression was".PadRight(padding) + " : " + expression);
            Console.WriteLine("Set B will be".PadRight(padding) + " : " + setB.ToString());

            Console.WriteLine();
            ISet<int> universal = setA.Union(setB);
            Console.WriteLine("Universal set will be".PadRight(padding) + " : " + universal.ToString());

            Console.WriteLine();
            Console.WriteLine();

            //Now the set operations


            //Difference
            Console.WriteLine("Difference : ");
            ISet<int> differenceA = setA.Difference(setB);
            Console.WriteLine("setA - setB".PadRight(padding) + " : " + differenceA.ToString());
            Console.WriteLine();

            ISet<int> differenceB = setB.Difference(setA);
            Console.WriteLine("setB - setA".PadRight(padding) + " : " + differenceB.ToString());
            Console.WriteLine();

            ISet<int> differenceAA = setA.Difference(setA);
            Console.WriteLine("setA - setA".PadRight(padding) + " : " + differenceAA.ToString());
            Console.WriteLine();

            //Union
            Console.WriteLine("Union : ");
            ISet<int> union = setA.Union(setB);
            Console.WriteLine("setA union set B".PadRight(padding) + " : " + union.ToString());
            Console.WriteLine();

            //Complement
            Console.WriteLine("Complement : ");
            ISet<int> complement1 = setA.Complement(setB, out bool isUniversal);
            Console.WriteLine("Set A complement Set B");
            if (!isUniversal)
            {
                Console.WriteLine("setB is not universal to setA".PadRight(padding) + " : " + complement1.ToString());
            }
            else
                Console.WriteLine("Complement of setA from setB".PadRight(padding) + " : " + complement1.ToString());
            
            Console.WriteLine();

            var a = setA.Complement(union, out isUniversal);

            ISet<int> complement2 = setA.Complement(universal, out isUniversal);
            Console.WriteLine("Universal complement Set B");
            if (!isUniversal)
            {
                Console.WriteLine("Set A is not subset of the universal set".PadRight(padding) + " : " + complement2.ToString());
            }
            else
                Console.WriteLine("Complement of setA from setB".PadRight(padding) + " : " + complement2.ToString());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press any key to move on to the next test.......");
            //Console.ReadKey();
        }//TestSetOperations
        private static void TestISetTree()
        {
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("Test Generic set : Using intagers");
            Console.WriteLine("=================================");
            Console.WriteLine("Note that the integers are seperated by a comma (\",\")");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            SetExtractionSettings<int> settings = new SetExtractionSettings<int>(",");

            string expression = "{5,5,3,{6,{5,8},{5,3},5,6},{6,{5,8},{5,3},5,6},7}";
            Console.WriteLine("The expression is : " + expression);
            GenericSet<int> set = new GenericSet<int>(expression, settings);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{{{{{{{{6}}}}}}}}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, settings);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{1,{2,{5},{7}},{8}}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, settings);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{5,2,1,0}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, settings);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{ 8, 7, 5, 2, 14, 1, { 5, 8, 9, 6, 33 } }";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, settings);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            expression = "{5,5,3,{6,{5,8},5,6},7}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The expression is : " + expression);
            set = new GenericSet<int>(expression, settings);
            Console.WriteLine("The element string will be : " + set.ElementString);
            Console.WriteLine("The cardinality will be : " + set.Cardinality);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Finnished!!!");
            Console.Write("Press any key to see the generic set.......");
            Console.ReadLine();
        }//TestGenericSetWithNumbers
        private static void TestSettingsGenericSet()
        {

        }//TestSettingsGenericSet
    }//class
}//namespace