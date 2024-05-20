using System;
using SetLibrary;
using SetLibrary.Generic;
using SetLibrary.Operations;
using SetLibrary.Objects_Sets;
using Xunit;
using System.Collections.Generic;

namespace SetLibraryTests.CSetTests
{
    public class SubSetsTests
    {
        private SetLibrary.ICSet<string> testSet;
        private ISetTree<string> subset;
        public SubSetsTests()
        {
            //Create an empty set
            testSet = new CSet();

            //Add a sub set
            subset = new CSetTree<string>(new List<string>());
            subset.AddElement("{5,6,{9,5},6}");
            testSet.AddElement(subset);

        }//namespace
        [Fact]
        public void TestSetShouldBeEmpty()
        {
            testSet.RemoveElement(subset);
            Assert.Equal(0, testSet.Cardinality);
            Assert.Equal("{\u2205}", testSet.ElementString);
        }//TestSetShouldBeEmpty
       [Fact]
        public void TestAddSingleSubSet()
        {
            ISetTree<string> subset = new CSetTree<string>
                (new List<string>(){ "5","6","6","5"});

            testSet.AddElement(subset);
            testSet.AddElement("4");
            Assert.True(testSet.Contains("4"));
            Assert.True(testSet.Contains(subset));
        }//TestAddSingleElement
        [Fact]
        public void TestAddSingleCetTree()
        {
            ISetTree<string> subset = new CSetTree<string>
                        (new List<string>() { "5", "6", "6", "5" });

            //Add the sub set
            testSet.AddElement(subset);

            //Add another element in the root
            testSet.AddElement("4");

            //Remove the subset
            testSet.RemoveElement(subset);
            Assert.True(testSet.Contains("4"));
            Assert.False(testSet.Contains(subset));
        }//TestAddSingleCetTree
        
        [Fact]
        public void TestRemoveSubSetFromSet()
        {
            ISetTree<string> subset = new CSetTree<string>
                        (new List<string>() { "5", "6", "6", "5" });

            bool removed = testSet.RemoveElement(subset);
            Assert.False(removed);
        }//TestRemoveSubSetFromSet

        [Fact]
        public void TestSetContainmentWithSubsets()
        {
            testSet.AddElement(subset);
            Assert.True(testSet.Contains(subset));
            Assert.False(testSet.Contains("{3,2,{5,9}}"));
            Assert.False(testSet.Contains("{{5,9}}"));
            Assert.False(testSet.Contains("{5,9}"));
            Assert.False(testSet.Contains("{5,6}"));
            subset.AddElement("9");
            Assert.True(testSet.Contains(subset));
        }//TestAddElementWithBraces

        [Fact]
        public void TestAddElementWithSubset()
        {
            
        }//TestAddElementWithSubset
    }//namespace
}//class