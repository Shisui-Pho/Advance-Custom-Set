using SetLibrary;
using SetLibrary.Generic;
namespace SetLibraryTests.SetObjectTests
{
    using SetLibrary.Objects_Sets;
    using System;
    using Xunit;

    public class SetObjectsTests
    {
        private SetExtractionSettings<Person> settings;

        public SetObjectsTests()
        {
            settings = new SetExtractionSettings<Person>(",", " ", new Person());
        }//ctor 01

        [Fact]
        public void Contains_ReturnsTrue_WhenPersonExistsInSet()
        {
            // Arrange
            var set = new SetObjects<Person>("{John Doe, Alice Cooper, Bob Marley}", settings);
            var personToFind = new Person("John", "Doe");

            // Act
            bool result = set.Contains(personToFind);

            // Assert
            Assert.True(result);
        }//Contains_ReturnsTrue_WhenPersonExistsInSet

        [Fact]
        public void MergeWith_CombinesTwoSetsCorrectly()
        {
            // Arrange
            var setA = new SetObjects<Person>("{John Doe, Alice Cooper}", settings);
            var setB = new SetObjects<Person>("{Bob Marley, Carol Johnson}", settings);
            var expectedResult = new SetObjects<Person>("{John Doe, Alice Cooper, Bob Marley, Carol Johnson}", settings);

            // Act
            var mergedSet = setA.MergeWith(setB);

            // Assert
            Assert.Equal(expectedResult.ToString(), mergedSet.ToString());
        }//MergeWith_CombinesTwoSetsCorrectly

        [Fact]
        public void FindFirstRootElement_ReturnsFirstPersonInSet()
        {
            // Arrange
            var set = new SetObjects<Person>("{John Doe, Alice Cooper, Bob Marley}", settings);
            var expectedPerson = new Person("Alice", "Cooper");

            // Act
            var firstPerson = set.FindFirstRootElement();

            // Assert
            Assert.Equal(expectedPerson, firstPerson);
        }//FindFirstRootElement_ReturnsFirstPersonInSet

        [Fact]
        public void GetSubSetElementByIndex_ReturnsSubsetAtIndex()
        {
            // Arrange
            var set = new SetObjects<Person>("{{John Doe, Alice Cooper}, {Bob Marley, Carol Johnson}}", settings);
            var expectedSubset = new SetObjects<Person>("{Bob Marley,Carol Johnson}", settings);

            // Act
            var subset = set.GetSubSetElementByIndex(1);

            // Assert
            Assert.Equal(expectedSubset.ToString(), subset.ToString());
        }//GetSubSetElementByIndex_ReturnsSubsetAtIndex

        [Fact]
        public void GetRootElementByIndex_ReturnsElementAtIndex()
        {
            // Arrange
            var set = new SetObjects<Person>("{{John Doe, Alice Cooper}, {Bob Marley, Carol Johnson}}", settings);
            var expectedPerson = default(Person);//new Person("John", "Doe");

            // Act
            var person = set.GetRootElementByIndex(0);

            // Assert
            Assert.Equal(expectedPerson, person);
        }//GetRootElementByIndex_ReturnsElementAtIndex
        [Fact]
        public void Constructor_CreatesEmptySet_WhenGivenEmptyString()
        {
            // Arrange
            var emptyExpression = "{}";

            // Act
            var set = new SetObjects<Person>(emptyExpression, settings);

            // Assert
            Assert.Equal("{\u2205}", set.ToString());
        }//Constructor_CreatesEmptySet_WhenGivenEmptyString

        [Fact]
        public void MergeWith_ReturnsEmptySet_WhenBothSetsAreEmpty()
        {
            // Arrange
            var setA = new SetObjects<Person>("{}", settings);
            var setB = new SetObjects<Person>("{}", settings);

            // Act
            var mergedSet = setA.MergeWith(setB);

            // Assert
            Assert.Equal("{\u2205}", mergedSet.ToString());
        }//MergeWith_ReturnsEmptySet_WhenBothSetsAreEmpty

        [Fact]
        public void MergeWith_ReturnsOriginalSet_WhenOtherSetIsEmpty()
        {
            // Arrange
            var setA = new SetObjects<Person>("{John Doe, Alice Cooper}", settings);
            var emptySet = new SetObjects<Person>("{}", settings);

            // Act
            var mergedSet = setA.MergeWith(emptySet);

            // Assert
            Assert.Equal(setA.ToString(), mergedSet.ToString());
        }//MergeWith_ReturnsOriginalSet_WhenOtherSetIsEmpty

        [Fact]
        public void MergeWith_ReturnsOtherSet_WhenOriginalSetIsEmpty()
        {
            // Arrange
            var emptySet = new SetObjects<Person>("{}", settings);
            var setB = new SetObjects<Person>("{Bob Marley, Carol Johnson}", settings);

            // Act
            var mergedSet = emptySet.MergeWith(setB);

            // Assert
            Assert.Equal(setB.ToString(), mergedSet.ToString());
        }

        [Fact]
        public void GetSubSetElementByIndex_ReturnsNull_WhenIndexIsOutOfRange()
        {
            // Arrange
            var set = new SetObjects<Person>("{John Doe, Alice Cooper, Bob Marley}", settings);
            var outOfRangeIndex = 3;

            // Act
            var subset = set.GetSubSetElementByIndex(outOfRangeIndex);

            // Assert
            Assert.Null(subset);
        }//GetSubSetElementByIndex_ReturnsNull_WhenIndexIsOutOfRange
        [Fact]
        public void ToString_ReturnsStringRepresentationOfSet()
        {
            // Arrange
            var set = new SetObjects<Person>("{John Doe, Alice Cooper, Bob Marley}", settings);
            var expectedString = "{Alice Cooper,Bob Marley,John Doe}";

            // Act
            var result = set.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }//ToString_ReturnsStringRepresentationOfSet

        [Fact]
        public void Constructor_ThrowsArgumentException_WhenGivenNullSettings()
        {
            // Arrange
            SetExtractionSettings<Person> nullSettings = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new SetObjects<Person>("{John Doe, Alice Cooper}", nullSettings));
        }//Constructor_ThrowsArgumentException_WhenGivenNullSettings

        [Fact]
        public void Contains_ReturnsFalse_WhenPersonDoesNotExistInSet()
        {
            // Arrange
            var set = new SetObjects<Person>("{John Doe, Alice Cooper, Bob Marley}", settings);
            var personNotInSet = new Person("Michael", "Jackson");

            // Act
            bool result = set.Contains(personNotInSet);

            // Assert
            Assert.False(result);
        }//Contains_ReturnsFalse_WhenPersonDoesNotExistInSet

        [Fact]
        public void MergeWith_ReturnsNewSetWithMergedElements_WhenMergingNonEmptySets()
        {
            // Arrange
            var setA = new SetObjects<Person>("{John Doe, Alice Cooper}", settings);
            var setB = new SetObjects<Person>("{Bob Marley, Carol Johnson}", settings);
            var expectedSet = new SetObjects<Person>("{John Doe, Alice Cooper, Bob Marley, Carol Johnson}", settings);

            // Act
            var mergedSet = setA.MergeWith(setB);

            // Assert
            Assert.Equal(expectedSet.ToString(), mergedSet.ToString());
        }//MergeWith_ReturnsNewSetWithMergedElements_WhenMergingNonEmptySets

        [Fact]
        public void MergeWith_ReturnsOriginalSet_WhenMergingWithEmptySet()
        {
            // Arrange
            var nonEmptySet = new SetObjects<Person>("{John Doe, Alice Cooper}", settings);
            var emptySet = new SetObjects<Person>("{}", settings);

            // Act
            var mergedSet = nonEmptySet.MergeWith(emptySet);

            // Assert
            Assert.Equal(nonEmptySet.ToString(), mergedSet.ToString());
        }//MergeWith_ReturnsOriginalSet_WhenMergingWithEmptySet
    }//class
}//namespace
