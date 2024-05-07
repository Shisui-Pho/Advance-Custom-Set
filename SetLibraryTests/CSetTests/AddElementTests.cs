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
        public void TestAddElementAlreadyExists()
        {
            // Adding an element that already exists should not change the set
            testSet.AddElement("3");
            Assert.True(testSet.Contains("3"));
        }//TestAddElementAlreadyExists

        [Fact]
        public void TestAddElementWithBraces()
        {
            Assert.False(testSet.Contains("4"));
            Assert.False(testSet.Contains("5"));
            Assert.False(testSet.Contains("6"));
        }//TestAddElementWithBraces
    }//class
}//namespace
