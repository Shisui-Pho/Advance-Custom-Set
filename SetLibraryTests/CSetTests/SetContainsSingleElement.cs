using System.Linq;
using Xunit;
using SetLibrary;
namespace SetLibraryTests.CSetTests
{
    public class SetContainsSingleElement
    {
        private CSet testSetNoNesting;
        private CSet testSetWithNestedElements;
        public SetContainsSingleElement()
        {
            // Initialize testSet if needed before each test
            testSetNoNesting = new CSet("{1,2,3}");
            testSetWithNestedElements = new CSet("{5,5,3,{6,{5,8},{5,3},5,6},{6,{5,8},{5,3},5,6},7}");
        }//ctor
        [Fact]
        public void TestContainsSingleElement()
        {
            Assert.True(testSetNoNesting.Contains("1"));
        }//TestContainsSingleElement
        [Fact]
        public void TestContainsMultipleElements()
        {
            //         //"{3,5,7,{5,6,{3,5},{5,8}}}"
            Assert.True(testSetNoNesting.Contains("2"));
            Assert.True(testSetNoNesting.Contains("3"));
        }//TestContainsMultipleElements
        [Fact]
        public void TestContainsNonExistentElement()
        {
            Assert.False(testSetNoNesting.Contains("4"));
        }//TestContainsNonExistentElement
        [Fact]
        public void TestContainsWithBraces()
        {
            Assert.False(testSetNoNesting.Contains("{1,2,3}"));
        }//TestContainsWithBraces
        [Fact]
        public void TestContainsWithSubset()
        {
            Assert.True(testSetWithNestedElements.Contains("{5,6,{5,8},{3,5}}"));
        }//TestContainsWithSubset
        [Fact]
        public void TestContainsWithSubsetNotPresent()
        {
            ////"{3,5,7,{5,6,{3,5},{5,8}}}"
            Assert.False(testSetNoNesting.Contains("{4,5}"));
            Assert.False(testSetWithNestedElements.Contains("{4,5}"));
        }//TestContainsWithSubsetNotPresent
        [Fact]
        public void TestContainsWithWrongNestingDegree()
        {
            Assert.False(testSetWithNestedElements.Contains("{3,5}"));
            Assert.False(testSetWithNestedElements.Contains("{5,8}"));
        }//TestContainsWithWrongNestingDegree
        [Fact]
        public void TestContainsWithInvalidInput()
        {
            Assert.False(testSetNoNesting.Contains("invalid"));
            Assert.False(testSetWithNestedElements.Contains("invalid"));
        }//TestContainsWithInvalidInput
    }//class
}//namespace
