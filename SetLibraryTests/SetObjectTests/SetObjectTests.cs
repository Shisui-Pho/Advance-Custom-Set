using System.Linq;
using Xunit;
using SetLibrary;
using SetLibrary.Generic;
namespace SetLibraryTests.SetObjectTests
{
    using SetLibrary.Objects_Sets;
    using Xunit;

    public class SetObjectsTests
    {
        private SetExtractionSettings<Person> settings;

        public SetObjectsTests()
        {
            settings = new SetExtractionSettings<Person>(",", " ", new Person());
        }

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
        }

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
        }

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
        }

        [Fact]
        public void GetSubSetElementByIndex_ReturnsSubsetAtIndex()
        {
            // Arrange
            var set = new SetObjects<Person>("{{John Doe, Alice Cooper}, {Bob Marley, Carol Johnson}}", settings);
            var expectedSubset = new SetObjects<Person>("{Bob Marley, Carol Johnson}", settings);

            // Act
            var subset = set.GetSubSetElementByIndex(1);

            // Assert
            Assert.Equal(expectedSubset.ToString(), subset.ToString());
        }

        [Fact]
        public void GetRootElementByIndex_ReturnsElementAtIndex()
        {
            // Arrange
            var set = new SetObjects<Person>("{{John Doe, Alice Cooper}, {Bob Marley, Carol Johnson}}", settings);
            var expectedPerson = new Person("John", "Doe");

            // Act
            var person = set.GetRootElementByIndex(0);

            // Assert
            Assert.Equal(expectedPerson, person);
        }
    }

}
