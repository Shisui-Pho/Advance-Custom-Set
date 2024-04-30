using System.Collections.Generic;
using SetLibrary;
using SetLibrary.Generic;
using Xunit;
namespace SetLibraryTests
{
    public class SortAndRemoveDuplicatesTests
    {
        [Fact]
        public void SortAndRemoveDuplicates_Integers()
        {
            // Arrange
            string rootElements = "3 1 2 1 5 4 3";
            SetExtractionSettings<int> settings = new SetExtractionSettings<int>(" ");

            // Act
            List<int> result = SetExtraction.SortAndRemoveDuplicates(rootElements, settings);

            // Assert
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, result);
        }//SortAndRemoveDuplicates_Integers

        [Fact]
        public void SortAndRemoveDuplicates_Strings()
        {
            // Arrange
            string rootElements = "apple orange banana orange pear";
            SetExtractionSettings<string> settings = new SetExtractionSettings<string>(" ");

            // Act
            var result = SetExtraction.SortAndRemoveDuplicates(rootElements, settings);

            // Assert
            Assert.Equal(new List<string> { "apple", "banana", "orange", "pear" }, result);
        }//SortAndRemoveDuplicates_Strings
        [Fact]
        public void SortAndRemoveDuplicates_EmptyInput()
        {
            // Arrange
            string rootElements = "";
            SetExtractionSettings<int> settings = new SetExtractionSettings<int>(" ");

            // Act
            var result = SetExtraction.SortAndRemoveDuplicates(rootElements, settings);

            // Assert
            Assert.Empty(result);
        }//SortAndRemoveDuplicates_EmptyInput
    }//class
}//namespace
