using System.Linq;
using Xunit;
using SetLibrary.Generic;
using SetLibrary;
namespace SetLibraryTests.GenericSetTests
{
    using Xunit;

    public class GenericSetTests
    {
        [Fact]
        public void TestInitialization()
        {
            // Arrange
            SetExtractionSettings<int> settings = new SetExtractionSettings<int>(",");
            string expression = "{1,2,3,4}";

            // Act
            GenericSet<int> set = new GenericSet<int>(expression, settings);

            // Assert
            Assert.Equal(expression, set.ElementString);
            Assert.Equal(4, set.Cardinality);
        }//TestInitialization

        [Fact]
        public void TestElementContainment()
        {
            // Arrange
            SetExtractionSettings<int> settings = new SetExtractionSettings<int>(",");
            string expression = "{1,2,3,4}";
            GenericSet<int> set = new GenericSet<int>(expression, settings);

            // Act & Assert
            Assert.True(set.Contains(2));
            Assert.False(set.Contains(5));
        }//TestElementContainment

        [Fact]
        public void TestSetOperations()
        {
            // Arrange
            SetExtractionSettings<int> settings = new SetExtractionSettings<int>(",");
            string expressionA = "{1,2,3,4}";
            string expressionB = "{3,4,5,6}";
            GenericSet<int> setA = new GenericSet<int>(expressionA, settings);
            GenericSet<int> setB = new GenericSet<int>(expressionB, settings);

            // Act
            ISet<int> union = setA + setB;
            ISet<int> difference = setA - setB;

            // Assert
            Assert.Equal("{1,2,3,4,5,6}", union.ToString());
            Assert.Equal("{1,2}", difference.ToString());
        }//TestSetOperations
    }//class
}//namespace
