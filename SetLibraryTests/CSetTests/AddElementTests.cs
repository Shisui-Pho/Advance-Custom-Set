using System.Linq;
using Xunit;
using SetLibrary;
using SetLibrary.Generic;
namespace SetLibraryTests.CSetTests
{
    public class AddElementTests
    {
        private CSet testSet;
        public AddElementTests()
        {
            // Initialize testSet if needed before each test
            testSet = new CSet("{1,2,3}");
            //settings = new SetExtractionSettings<string>(",");
        }

        [Fact]
        public void TestAddSingleElement()
        {
            testSet.AddElement("4");
            Assert.True(testSet.Contains("4"));
        }//TestAddSingleElement
        [Fact]
        public void TestAddSingleCetTree()
        {
            
        }//TestAddSingleCetTree
        [Fact]
        public void TestAddElementAlreadyExists()
        {
            // Adding an element that already exists should not change the set
            testSet.AddElement("3");
            Assert.True(testSet.Contains("3"));
        }//TestAddElementAlreadyExists

        [Fact]
        public void TestAddElementWithBraces()
        {
            testSet.AddElement("{6,6,5,4,5,6}");
            Assert.False(testSet.Contains("4"));
            Assert.False(testSet.Contains("5"));
            Assert.False(testSet.Contains("6"));
            Assert.True(testSet.Contains("{4,5,6}"));
        }//TestAddElementWithBraces

        [Fact]
        public void TestAddElementWithSubset()
        {
            testSet.AddElement("{4,5}");
            Assert.False(testSet.Contains("4"));
            Assert.False(testSet.Contains("5"));
        }//TestAddElementWithSubset
    }//class
}//namespace
