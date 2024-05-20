using System;
using SetLibrary;
using SetLibrary.Collections;
using SetLibrary.Generic;
using SetLibrary.Objects_Sets;
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
            LawOfSetTheory();
            TestObjectsConverter();
            TestIndexingWithObject();
            //Console.ReadKey();
        }//Main
        private static void TestIndexingWithObject()
        {
            Console.Clear();
            Console.WriteLine("Test Indexing with objects.");
            Console.WriteLine("============================");
            Console.WriteLine("Note that the object being used is an Animal. An animal can be a Dog or a Cat. An animal has a Name and TypeOfAnimal.");
            Console.WriteLine("A dog has an extra property called Breed and a Cat has an extra property called Color.");
            Console.WriteLine("The sorting happens on the Name of the animal.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Creating the set.
            Console.WriteLine("Creating the animal set.");
            Console.WriteLine("========================");
            Console.WriteLine();
            SetExtractionSettings<Animal> settings = new SetExtractionSettings<Animal>(",", " ", new Animal());
            string setString = "{Cat Luna Black,Cat Baiely White,Cat Coco White,Cat Lola White,Dog Bella Bulldog,{Dog Molly Dachshund,Dog Bella Poodle},{Dog Molly Dachshund,Dog Bella Poodle},{{Dog Sammy Poodle}},Cat Baiely White,Dog Luna Beagle}";
            ICSet<Animal> setOfAnimals = new ObjectSet<Animal>(setString,settings);

            //Display output
            Console.WriteLine("The original set string was : \n----> {0}\n",setString);
            Console.WriteLine("The evaluated set string will be : \n----> {0}\n", setOfAnimals);

            Console.WriteLine();
            Console.WriteLine("Testing indexing.");
            Console.WriteLine("=================");

            Element<Animal> animal = setOfAnimals.GetElementByIndex(4);
            Console.WriteLine("Animal at index 4");
            Console.WriteLine("Animal          : {0}", animal.Value);
            Console.WriteLine("Is in the root  : {0}", animal.IsInRoot);
            Console.WriteLine("Nesting level   : {0}", animal.NestedLevel);
            Console.WriteLine("Was found       : {0}", animal.ElementFound);
            Console.WriteLine();
            animal = setOfAnimals.GetElementByIndex(5);
            Console.WriteLine("Animal at index 5");
            Console.WriteLine("Animal          : {0}", animal.Value);
            Console.WriteLine("Is in the root  : {0}", animal.IsInRoot);
            Console.WriteLine("Nesting level   : {0}", animal.NestedLevel);
            Console.WriteLine("Was found       : {0}", animal.ElementFound);
            Console.WriteLine();
            animal = setOfAnimals.GetElementByIndex(6);
            Console.WriteLine("Animal at index 6");
            Console.WriteLine("Animal          : {0}", animal.Value);
            Console.WriteLine("Is in the root  : {0}", animal.IsInRoot);
            Console.WriteLine("Nesting level   : {0}", animal.NestedLevel);
            Console.WriteLine("Was found       : {0}", animal.ElementFound);
            Console.WriteLine();
            animal = setOfAnimals.GetElementByIndex(7);
            Console.WriteLine("Animal at index 7");
            Console.WriteLine("Animal          : {0}", animal.Value);
            Console.WriteLine("Is in the root  : {0}", animal.IsInRoot);
            Console.WriteLine("Nesting level   : {0}", animal.NestedLevel);
            Console.WriteLine("Was found       : {0}", animal.ElementFound);
            Console.WriteLine();
            animal = setOfAnimals.GetElementByIndex(15);
            Console.WriteLine("Animal at index 15");
            Console.WriteLine("Animal          : {0}", animal.Value);
            Console.WriteLine("Is in the root  : {0}", animal.IsInRoot);
            Console.WriteLine("Nesting level   : {0}", animal.NestedLevel);
            Console.WriteLine("Was found       : {0}", animal.ElementFound);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            AnyKey();
        }//TestIndexingWithObject
        private static void TestObjectsConverter()
        {
            Console.Clear();
            Console.WriteLine("TESTING Object Set with a Person Model");
            Console.WriteLine("=======================================");
            Console.WriteLine("Note : The person model has two field which are First Name and Last name, The sorting happens based on first name.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            SetExtractionSettings<Person> settings = new SetExtractionSettings<Person>(",", " ", new Person());

            //Expression 01
            Console.WriteLine("Expression 01 : ");
            string expression = "{Phiwokwakhe Khathwane,Phiwokwakhe Khathwane,Phiwokwakhe Khathwane,Anabel Hillson,Anabel Bananna,Lesbary Mathew,William Shakesphere,{Muton Sugar,Henry MacDonald,{}}}";
            ICSet<Person> setPeople = new ObjectSet<Person>(expression,settings);
            Console.WriteLine("The original set expression was :");
            Console.WriteLine("   "+ expression);
            Console.WriteLine();
            Console.WriteLine("The evaluated string is : ");
            Console.WriteLine("   " + setPeople);
            Console.WriteLine();
            Console.WriteLine("The first person on the set will be : " + setPeople.FindFirstRootElement());
            Console.WriteLine("The first sub set of people will be : " + setPeople.GetSubSetElementByIndex(0));
            Console.WriteLine("Person on index 2 on root will be   : " + setPeople.GetRootElementByIndex(2));
            Console.WriteLine();
            Console.WriteLine();

            //Expression 02
            Console.WriteLine("Expression 02 : ");
            expression = "{{John Doe,Alice Cooper},{Bob Marley,Carol Johnson,Jane Smith},{David Lee,Susan Adams},{Michael Jordan,Sarah Parker,Thomas Edison}, {Emily Watson,Christopher Brown}}";
            setPeople = new ObjectSet<Person>(expression, settings);
            Console.WriteLine("The original set expression was :");
            Console.WriteLine("   " + expression);
            Console.WriteLine();
            Console.WriteLine("The evaluated string is : ");
            Console.WriteLine("   " + setPeople);
            Console.WriteLine();
            Console.WriteLine("The first person on the set will be : " + setPeople.FindFirstRootElement());
            Console.WriteLine("The first sub set of people will be : " + setPeople.GetSubSetElementByIndex(0));
            Console.WriteLine("Person on index 2 on root will be   : " + setPeople.GetRootElementByIndex(2));
            Console.WriteLine();
            Console.WriteLine();


            //Expression 03
            Console.WriteLine("Expression 03 : ");
            expression = "{{John Doe, {}}, {Jane Smith, {Bob Marley, {}, Carol Johnson}}, {}, {David Lee, {Susan Adams, {Michael Jordan, Sarah Parker}, Thomas Edison}}, {Emily Watson, {Christopher Brown}}}";
            setPeople = new ObjectSet<Person>(expression, settings);
            Console.WriteLine("The original set expression was :");
            Console.WriteLine("   " + expression);
            Console.WriteLine();
            Console.WriteLine("The evaluated string is : ");
            Console.WriteLine("   " + setPeople);
            Console.WriteLine();
            Console.WriteLine("The first person on the set will be : " + setPeople.FindFirstRootElement());
            Console.WriteLine("The first sub set of people will be : " + setPeople.GetSubSetElementByIndex(0));
            Console.WriteLine("Person on index 2 on root will be   : " + setPeople.GetRootElementByIndex(2));
            Console.WriteLine();
            Console.WriteLine();
            //string expression3 = "{{John Doe, Alice Cooper}, Bob Marley, Carol Johnson, Jane Smith, David Lee, {Susan Adams, Michael Jordan, Sarah Parker, Thomas Edison}, Robert Smith, {Laura Davis, {Emily Watson, {Christopher Brown, Emma Thompson}}}}";

            //Expression 04
            Console.WriteLine("Expression 04 : ");
            expression = "{{John Doe, Alice Cooper}, Bob Marley, Carol Johnson, Jane Smith, David Lee, {Susan Adams, Michael Jordan, Sarah Parker, Thomas Edison}, Robert Smith, {Laura Davis, {Emily Watson, {Christopher Brown, Emma Thompson}}}}";
            setPeople = new ObjectSet<Person>(expression, settings);
            Console.WriteLine("The original set expression was :");
            Console.WriteLine("   " + expression);
            Console.WriteLine();
            Console.WriteLine("The evaluated string is : ");
            Console.WriteLine("   " + setPeople);
            Console.WriteLine();
            Console.WriteLine("The first person on the set will be : " + setPeople.FindFirstRootElement());
            Console.WriteLine("The first sub set of people will be : " + setPeople.GetSubSetElementByIndex(0));
            Console.WriteLine("Person on index 2 on root will be   : " + setPeople.GetRootElementByIndex(2));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("End of the line!!!");
            Console.WriteLine();
            AnyKey();
        }//TestObjectsConverter
        private static void TestSetOperations()
        {
            Console.Clear();
            //For a generic sts
            Console.WriteLine("Testing set operations with a generic set class");
            Console.WriteLine("=================================================");
            Console.WriteLine("Note : A generic set of intergers is being used");
            Console.WriteLine();
            Console.WriteLine();
            SetExtractionSettings<int> settings = new SetExtractionSettings<int>(",");
            int padding = 30;
            string expression = "{2,6,1,73,10,15,{8,6,{3},{7,5}}}";
            ICSet<int> setA = new GenericSet<int>(expression,settings);
            Console.WriteLine("The orginial expression was".PadRight(padding) + " : " + expression);
            Console.WriteLine("Set A will be".PadRight(padding) + " : " + setA.ToString());

            Console.WriteLine();
            expression = "{5,{5,6,{2}},{8,{6}},2}";
            ICSet<int> setB = new GenericSet<int>(expression, settings);
            Console.WriteLine("The orginial expression was".PadRight(padding) + " : " + expression);
            Console.WriteLine("Set B will be".PadRight(padding) + " : " + setB.ToString());

            Console.WriteLine();
            ICSet<int> universal = setA.Union(setB);
            Console.WriteLine("Universal set will be".PadRight(padding) + " : " + universal.ToString());

            Console.WriteLine();
            Console.WriteLine();

            //Now the set operations


            //Difference
            Console.WriteLine("Difference : ");
            ICSet<int> differenceA = setA.Difference(setB);
            Console.WriteLine("setA - setB".PadRight(padding) + " : " + differenceA.ToString());
            Console.WriteLine();

            ICSet<int> differenceB = setB.Difference(setA);
            Console.WriteLine("setB - setA".PadRight(padding) + " : " + differenceB.ToString());
            Console.WriteLine();

            ICSet<int> differenceAA = setA.Difference(setA);
            Console.WriteLine("setA - setA".PadRight(padding) + " : " + differenceAA.ToString());
            Console.WriteLine();

            //Union
            Console.WriteLine("Union : ");
            ICSet<int> union = setA.Union(setB);
            Console.WriteLine("setA union set B".PadRight(padding) + " : " + union.ToString());
            Console.WriteLine();


            //Intersection
            Console.WriteLine("Intersection : ");
            //A and B
            ICSet<int> intersectionA = setA.Intersection(setB);
            Console.WriteLine("SetA intersect SetB".PadRight(padding) + " : " + intersectionA.ToString());
            Console.WriteLine();

            //B and A
            ICSet<int> intersectionB = setB.Intersection(setA);
            Console.WriteLine("SetB intersect SetA".PadRight(padding) + " : " + intersectionB.ToString());
            Console.WriteLine();

            ICSet<int> intersectionC = universal.Intersection(setA);
            Console.WriteLine("Universal intersect SetA".PadRight(padding) + " : " + intersectionC.ToString());
            Console.WriteLine("From the above result we expect to set SetA itself.");
            Console.WriteLine();
            //Complement
            Console.WriteLine("Complement : ");
            ICSet<int> complement1 = setA.Complement(setB, out bool isUniversal);
            Console.WriteLine("Set A complement Set B");
            if (!isUniversal)
            {
                Console.WriteLine("setB is not universal to setA".PadRight(padding) );
            }
            else
                Console.WriteLine("Complement of setA from setB".PadRight(padding) + " : " + complement1.ToString());

            Console.WriteLine();

            ICSet<int> complement2 = setA.Complement(universal, out isUniversal);
            Console.WriteLine("Universal complement Set B");
            if (!isUniversal)
            {
                Console.WriteLine("Set A is not subset of the universal set".PadRight(padding) + " : " + complement2.ToString());
            }
            else
                Console.WriteLine("Complement of setA from setB".PadRight(padding) + " : " + complement2.ToString());

            Console.WriteLine();
            AnyKey();
           }//TestSetOperations
        private static void LawOfSetTheory()
        {
            //Clear console window
            Console.Clear();
            //Display infor to user.
            Console.WriteLine("  TESTING Laws Of Set Theory");
            Console.WriteLine("  ===========================");
            Console.WriteLine("  Note : A generic set of intergers is being used.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Create the sttings
            var settings = new SetExtractionSettings<int>(",");

            Console.WriteLine("  Creating the set");
            Console.WriteLine("  ================");
            //Create the universal set
            Console.WriteLine("  Universal Set :::::");
            string uniex_ = "{17,16,16,4,68,1,1,16,4,{12,6,8,6,{8,9,{}}},5,9,4,3,{},{6,8},{6,8,6,8},9,7,3,17,{19,6,19},{6,6,6}}";
            ICSet<int> universal = new GenericSet<int>(uniex_, settings);
            Console.WriteLine("  The original string for the universal set will be : ");
            Console.WriteLine("  ---> {0}", uniex_);
            Console.WriteLine("  The evaluated set string will be : ");
            Console.WriteLine("  ---> {0}", universal);
            Console.WriteLine();
            Console.WriteLine();


            //Empty Set
            Console.WriteLine("  Empty Set :::::");
            string emptyex_ = "{}";
            ICSet<int> emptySet = new GenericSet<int>(emptyex_, settings);
            Console.WriteLine("  The original string of set C will be : ");
            Console.WriteLine("  ---> {0}", emptyex_);
            Console.WriteLine("  The evaluated set string will be : ");
            Console.WriteLine("  ---> {0}", emptySet);
            Console.WriteLine();
            Console.WriteLine();

            //Create set A
            Console.WriteLine("  Set A :::::");
            string setAex_ = "{17,17,68,4,{6,6,6},{6,6,6}}";
            ICSet<int> setA = new GenericSet<int>(setAex_, settings);
            Console.WriteLine("  The original string of set A will be : ");
            Console.WriteLine("  ---> {0}", setAex_);
            Console.WriteLine("  The evaluated set string will be : ");
            Console.WriteLine("  ---> {0}", setA);
            Console.WriteLine();
            Console.WriteLine();

            
            //Create set B
            Console.WriteLine("  Set B :::::");
            string setBex_ = "{5,9,4,3,{},{6,8}}";
            ICSet<int> setB = new GenericSet<int>(setBex_, settings);
            Console.WriteLine("  The original string of set B will be : ");
            Console.WriteLine("  ---> {0}", setBex_);
            Console.WriteLine("  The evaluated set string will be : ");
            Console.WriteLine("  ---> {0}", setB);
            Console.WriteLine();
            Console.WriteLine();

            //Create set C
            Console.WriteLine("  Set C :::::");
            string setCex_ = "{{},{6,8},{6,8,6,8},9,7,3,17,{19,6,19},{6,6,6}}";
            ICSet<int> setC = new GenericSet<int>(setCex_, settings);
            Console.WriteLine("  The original string of set C will be : ");
            Console.WriteLine("  ---> {0}", setCex_);
            Console.WriteLine("  The evaluated set string will be : ");
            Console.WriteLine("  ---> {0}", setC);
            Console.WriteLine();
            Console.WriteLine();


            //Set laws
            Console.WriteLine("  SET LAWS");
            Console.WriteLine("  ===========");
            Console.WriteLine();
            Console.WriteLine();
            //Cummutativity
            Console.WriteLine("  Cummutative law :" );
            Console.WriteLine("  ================");
            Console.WriteLine("  A U B = B U A");
            ICSet<int> cummutativeA = setA.Union(setB);
            Console.WriteLine("     A U B :");
            Console.WriteLine("  ---> {0}", cummutativeA);
            ICSet<int> cummutativeB = setB.Union(setA);
            Console.WriteLine("     B U A :");
            Console.WriteLine("  ---> {0}", cummutativeB);
            Console.WriteLine();
            Console.WriteLine();

            //Associative
            Console.WriteLine("  Associative Laws : ");
            Console.WriteLine("  ====================");
            Console.WriteLine("  * 1: A U ( B U C ) = ( A U B) U C ::");
            Console.WriteLine("     A U ( B U C ) : ");
            ICSet<int> leftUnions = setA.Union(setB.Union(setC));
            Console.WriteLine("  ---> {0}", leftUnions);
            Console.WriteLine("     ( A U B) U C : ");
            ICSet<int> rightUnions = (setA.Union(setB)).Union(setC);
            Console.WriteLine("  ---> {0}", rightUnions);

            Console.WriteLine();
            Console.WriteLine($"  * 2 : A \u2229  ( B \u2229 C ) = (A \u2229 B) \u2229 C ::");
            Console.WriteLine("     A \u2229  ( B \u2229 C ) : ");
            ICSet<int> leftintersection = setA.Intersection(setB.Intersection(setC));
            Console.WriteLine("  ---> {0}", leftintersection);
            Console.WriteLine("     (A \u2229 B) \u2229 C : ");
            ICSet<int> rightintersection = (setA.Intersection(setB)).Intersection(setC);
            Console.WriteLine("  ---> {0}", rightintersection);
            Console.WriteLine();
            Console.WriteLine();

            //Distributivity
            Console.WriteLine("  Distributive Law : ");
            Console.WriteLine("  ====================");
            Console.WriteLine("  * 1 : A U ( B \u2229 C ) = ( A U B ) \u2229 ( A U C) ::");
            Console.WriteLine("     A U ( B \u2229 C )");
            ICSet<int> leftdisA = setA.Union(setB.Intersection(setC));
            Console.WriteLine("  ---> {0}", leftdisA);            
            Console.WriteLine("     ( A U B ) \u2229 ( A U C)");
            ICSet<int> rightdisA = (setA.Union(setB)).Intersection(setA.Union(setC));
            Console.WriteLine("  ---> {0}", rightdisA);
            Console.WriteLine();

            Console.WriteLine("  * 2 : A \u2229 ( B U C ) = ( A \u2229 B ) U ( A \u2229 C) ::");
            Console.WriteLine("     A \u2229 ( B U C )");
            ICSet<int> leftdisB = setA.Intersection(setB.Union(setC));
            Console.WriteLine("  ---> {0}", leftdisB);
            Console.WriteLine("     ( A \u2229 B ) U ( A \u2229 C)");
            ICSet<int> rightdisB = (setA.Intersection(setB)).Union(setA.Intersection(setC));
            Console.WriteLine("  ---> {0}", rightdisB);
            Console.WriteLine();
            Console.WriteLine();

            //Double Complement
            Console.WriteLine("  Double complement : ");
            Console.WriteLine("  =====================");
            Console.WriteLine("  ~(~A) = A ::");
            Console.WriteLine("     ~(~A)");
            ICSet<int> complementleft = setA.Complement(universal, out _).Complement(universal, out _);//universal.Difference(universal.Difference(setA));
            Console.WriteLine("  ---> {0}", complementleft);
            Console.WriteLine("     A");
            ICSet<int> complementright = setA;
            Console.WriteLine("  ---> {0}", complementright);
            Console.WriteLine();
            Console.WriteLine();

            //Demorgan's Laws
            Console.WriteLine("  DeMorgan's Law : ");
            Console.WriteLine("  ==================");
            Console.WriteLine("  * 1 : ~( A U B ) = ~A \u2229 ~B ::");
            Console.WriteLine("     ~( A U B )");
            ICSet<int> DeMorgRight1 = (setA.Union(setB)).Complement(universal, out _);
            Console.WriteLine("  ---> {0}", DeMorgRight1);
            Console.WriteLine("     ~A \u2229 ~B");
            ICSet<int> DeMorgLeft1 = setA.Complement(universal, out _).Intersection(setB.Complement(universal, out _));
            Console.WriteLine("  ---> {0}", DeMorgLeft1);
            Console.WriteLine();

            Console.WriteLine("  * 2 : ~( A \u2229 B ) = ~A U ~B ::");
            Console.WriteLine("     ~( A U B )");
            ICSet<int> DeMorgRight2 = (setA.Intersection(setB)).Complement(universal, out _);
            Console.WriteLine("  ---> {0}", DeMorgRight2);
            Console.WriteLine("     ~A \u2229 ~B");
            ICSet<int> DeMorgLeft2 = setA.Complement(universal, out _).Union(setB.Complement(universal, out _));
            Console.WriteLine("  ---> {0}", DeMorgLeft2);
            Console.WriteLine();
            Console.WriteLine();

            //Identity
            Console.WriteLine("  Identity : ");
            Console.WriteLine("  ============");
            Console.WriteLine("  * 1 : \u2205 U A = A ::");
            Console.WriteLine("     \u2205 U A");
            ICSet<int> identity1left = emptySet.Union(setA);//universal.Difference(universal.Difference(setA));
            Console.WriteLine("  ---> {0}", identity1left);
            Console.WriteLine("     A");
            ICSet<int> identity1right = setA;
            Console.WriteLine("  ---> {0}", identity1right);
            Console.WriteLine();

            Console.WriteLine("  * 2 : Uni \u2229 A = A ::");
            Console.WriteLine("     Uni \u2229 A");
            ICSet<int> identity2left = universal.Intersection(setA);//universal.Difference(universal.Difference(setA));
            Console.WriteLine("  ---> {0}", identity2left);
            Console.WriteLine("     A");
            ICSet<int> identity2right = setA;
            Console.WriteLine("  ---> {0}", identity2right);
            Console.WriteLine();
            Console.WriteLine();


            //Idempotence
            Console.WriteLine("  Idempotence : ");
            Console.WriteLine("  ============");
            Console.WriteLine("  * 1 : A U A = A ::");
            Console.WriteLine("     A U A ");
            ICSet<int> idompleft1 = setA.Union(setA);//universal.Difference(universal.Difference(setA));
            Console.WriteLine("  ---> {0}", idompleft1);
            Console.WriteLine("     A");
            ICSet<int> idompleright1 = setA;
            Console.WriteLine("  ---> {0}", idompleright1);
            Console.WriteLine();

            Console.WriteLine("  * 2 : A \u2229 A = A ::");
            Console.WriteLine("     A \u2229 A");
            ICSet<int> idompleft2 = setA.Intersection(setA);//universal.Difference(universal.Difference(setA));
            Console.WriteLine("  ---> {0}", idompleft2);
            Console.WriteLine("     A");
            ICSet<int> idompright2 = setA;
            Console.WriteLine("  ---> {0}", idompright2);
            Console.WriteLine();
            Console.WriteLine();


            //Idempotence
            Console.WriteLine("  Dominance : ");
            Console.WriteLine("  ============");
            Console.WriteLine("  * 1 : A U Univeral = Univeral ::");
            Console.WriteLine("     A U Univeral ");
            ICSet<int> domileft1 = setA.Union(universal);//universal.Difference(universal.Difference(setA));
            Console.WriteLine("  ---> {0}", domileft1);
            Console.WriteLine("     Univeral");
            ICSet<int> domiright1 = universal;
            Console.WriteLine("  ---> {0}", domiright1);
            Console.WriteLine();

            Console.WriteLine("  * 2 : A \u2229 \u2205 = \u2205 ::");
            Console.WriteLine("     A \u2229 \u2205");
            ICSet<int> domileft2 = setA.Intersection(emptySet);//universal.Difference(universal.Difference(setA));
            Console.WriteLine("  ---> {0}", domileft2);
            Console.WriteLine("     \u2205");
            ICSet<int> domiright2 = emptySet;
            Console.WriteLine("  ---> {0}", domiright2);
            Console.WriteLine();
            Console.WriteLine();

            AnyKey();

            //Set equalities
            Console.WriteLine("  Testing set operations with a generic set class");
            Console.WriteLine("  =================================================");
            Console.WriteLine("  Note : A generic set of intergers is being used");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  Arguments that prove logical equivalences can be directly translated into arguments that prove set equalities.");
            Console.WriteLine();
            Console.WriteLine("  Set Equalities of note :");
            Console.WriteLine("  1. A - B =  A \u2229 ~B");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("  2. A \u2206 B =  ( A U B ) - ( A \u2229 B )");
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine();
            Console.WriteLine("  Recall that : ");
            Console.WriteLine("  Universal set = : {0}", universal);
            Console.WriteLine("  Set A = : {0}", setA);
            Console.WriteLine("  Set B = : {0}", setB);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("  1. A - B =  A \u2229 ~B");
            Console.WriteLine("     A - B");
            ICSet<int> left1 = setA.Difference(setB);
            Console.WriteLine("  ---> {0}", left1);
            Console.WriteLine("     A \u2229 ~B");
            ICSet<int> right1 = setA.Intersection(setB.Complement(universal, out _));
            Console.WriteLine("  ---> {0}", right1);
            Console.WriteLine();
            Console.WriteLine();

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("  2. A \u2206 B =  ( A U B ) - ( A \u2229 B )");
            Console.WriteLine("     A \u2206 B");
            Console.OutputEncoding = System.Text.Encoding.Default;
            //ISet<int> left2 = setA.Difference(setB);
            Console.WriteLine("  ---> {0}", "To be implemented......");
            Console.WriteLine("     ( A U B ) - ( A \u2229 B )");
            ICSet<int> right2 = (setA.Union(setB).Difference(setA.Intersection(setB)));
            Console.WriteLine("  ---> {0}", right2);
            AnyKey();
        }//TestSetLaws
        private static void TestISetTree()
        {
            Console.Clear();
            Console.WriteLine("  TESTING the set tree");
            Console.WriteLine("  =====================");
            Console.WriteLine("  Note : A non-generic set of strings is being used, thus the sorting may be in-accurate with numbers");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Test CSet
            string expression = "{2,{9,8},{16,17,8},{8,8,9,8,8},{8,8},{8,8}}";
            ICSet<string> set = new CSet(expression);
            ISetTree<string> tree = set[3];
            Console.WriteLine("  The expression is :  {0} ", expression);
            Console.WriteLine("  The element string will be  :  {0} ", set.ElementString);
            Console.WriteLine("  The cardinality will be : {0}  ", set.Cardinality);
            Console.WriteLine("  The set/element in index {0} is {1} ", 3, set[3]);
            set.RemoveElement(tree);
            Console.WriteLine("  Removed the following tree : {0}", tree);
            Console.WriteLine("  The element string will be  :  {0} ", set.ElementString);
            Console.WriteLine("  The cardinality will be : {0}  ", set.Cardinality);
            set.RemoveElement("2");
            Console.WriteLine("  Remove the following element : \"2\"");
            Console.WriteLine("  The element string will be  :  {0} ", set.ElementString);
            Console.WriteLine("  The cardinality will be : {0}  ", set.Cardinality);
            tree.AddSubSetTree(SetExtraction.Extract("{2,6,7}",set.Settings));
            tree.AddSubSetTree(SetExtraction.Extract("{2,2}",set.Settings));
            set.AddElement(tree);
            Console.WriteLine("  Added the following element: {0}", tree);
            Console.WriteLine("  The element string will be  :  {0} ", set.ElementString);

            Console.WriteLine();
            AnyKey();
        }//TestISetTree
        private static void TestCSet()
        {
            Console.Clear();
            Console.WriteLine("  TESTING CSet : Non-Generic set");
            Console.WriteLine("  ===============================");
            Console.WriteLine();
            Console.WriteLine("  Note :The sorting may not be acurate because it does a string sorting!");
            Console.WriteLine();
            Console.WriteLine();

            string expression = "{1,{2,{5,{6,6,7,{6},{6}}},{7}},{8}}";
            Console.WriteLine("  The expression is : " + expression);
            CSet set = new CSet(expression);
            Console.WriteLine("  The element string will be : " + set.ElementString);
            Console.WriteLine("  The cardinality will be : " + set.Cardinality);

            expression = "{{{{{{{{6}}}}}}}}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("  The element string will be : " + set.ElementString);
            Console.WriteLine("  The cardinality will be : " + set.Cardinality);

            expression = "{5,5,3,{6,{5,8},{5,3},5,6},{6,{5,8},{5,3},5,6},7}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("  The element string will be : " + set.ElementString);
            Console.WriteLine("  The cardinality will be : " + set.Cardinality);

            expression = "{5,2,1,0}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("  The element string will be : " + set.ElementString);
            Console.WriteLine("  The cardinality will be : " + set.Cardinality);

            expression = "{ 8, 7, 5, 2, 14, 1, { 5, 8, 9, 6, 33 } }";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("  The element string will be : " + set.ElementString);
            Console.WriteLine("  The cardinality will be : " + set.Cardinality);

            expression = "{5,5,3,{6,{5,8},5,6},7}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  The expression is : " + expression);
            set = new CSet(expression);
            Console.WriteLine("  The element string will be : " + set.ElementString);
            Console.WriteLine("  The cardinality will be : " + set.Cardinality);
            
            Console.WriteLine();
            AnyKey();
        }//TestCSet
        private static void TestGenericSetWithNumbers()
        {
            Console.Clear();
            Console.WriteLine("  Test Generic set : Using intagers");
            Console.WriteLine("  =================================");
            Console.WriteLine("  Note that the integers are seperated by a comma (\",\")");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            SetExtractionSettings<int> settings = new SetExtractionSettings<int>(",");

            string expression = "{5,5,3,{6,{5,8},{5,3},5,6},{6,{5,8},{5,3},5,6},7}";
            Console.WriteLine("  The expression is : " + expression);
            GenericSet<int> set = new GenericSet<int>(expression, settings);
            Console.WriteLine("  The element string will be : " + set.ElementString);
            Console.WriteLine("  The cardinality will be : " + set.Cardinality);

            expression = "{{{{{{{{6}}}}}}}}";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  The expression is : " + expression);
            set = new GenericSet<int>(expression, settings);
            Console.WriteLine("  The element string will be : " + set.ElementString);
            Console.WriteLine("  The cardinality will be : " + set.Cardinality);

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
            AnyKey();
        }//TestGenericSetWithNumbers
        private static void AnyKey()
        {
            Console.Write("Press any key to continue.........");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\x1b[3J");//This sequence removes the whole content of the console. (But it only works reliable if the clear command is called first)
            Console.Clear();
        }//AnyKey
    }//class
}//namespace