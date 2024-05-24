using SetLibrary.Collections;
using SetLibrary;
using SetLibrary.Generic;
using Xunit;
using SetLibrary.Operations;
using System;

namespace SetLibraryTests.SetCollectionTests
{
    public class SetCollectionTests
    {
        private static readonly SetExtractionSettings<int> settings = new SetExtractionSettings<int>(",");



        [Fact]
        public void Count_ReturnsZero_WhenCollectionIsEmpty()
        {
            // Arrange
            var setCollection = new SetCollection<int>();

            // Act
            int count = setCollection.Count;

            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void Add_IncrementsCount_WhenAddingNewSet()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1, 2, 3 }", settings);

            // Act
            setCollection.Add(set);

            // Assert
            Assert.Equal(1, setCollection.Count);
        }

        [Fact]
        public void Remove_DecrementsCount_WhenRemovingSet()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1, 2, 3 }",settings );
            setCollection.Add(set);

            // Act
            setCollection.Remove(set);

            // Assert
            Assert.Equal(0, setCollection.Count);
        }
        [Fact]
        public void Count_ReturnsZero_WhenCollectionIsEmpty2()
        {
            // Arrange
            var setCollection = new SetCollection<int>();

            // Act
            int count = setCollection.Count;

            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void Add_IncrementsCount_WhenAddingNewSet2()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}", settings);

            // Act
            setCollection.Add(set);

            // Assert
            Assert.Equal(1, setCollection.Count);
        }

        [Fact]
        public void Remove_DecrementsCount_WhenRemovingSet2()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}", settings);
            setCollection.Add(set);

            // Act
            setCollection.Remove(set);

            // Assert
            Assert.Equal(0, setCollection.Count);
        }

        [Fact]
        public void Add_SetsUniqueNames_WhenAddingSets()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set1 = new GenericSet<int>("{1,2,3}", settings);
            var set2 = new GenericSet<int>("{4,5,6}", settings);

            // Act
            setCollection.Add(set1);
            setCollection.Add(set2);

            // Assert
            Assert.NotEqual(setCollection.GetSetByIndex(0).Name, setCollection.GetSetByIndex(1).Name);
        }

        [Fact]
        public void Add_IncrementsNameCorrectly_WhenAddingMultipleSets()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set1 = new GenericSet<int>("{1,2,3}", settings);
            var set2 = new GenericSet<int>("{4,5,6}", settings);

            // Act
            setCollection.Add(set1);
            setCollection.Add(set2);

            // Assert
            Assert.Equal("A", setCollection.GetSetByIndex(0).Name);
            Assert.Equal("B", setCollection.GetSetByIndex(1).Name);
        }

        [Fact]
        public void Remove_UpdatesNames_WhenRemovingSet()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set1 = new GenericSet<int>("{1,2,3}", settings);
            var set2 = new GenericSet<int>("{4,5,6}", settings);
            setCollection.Add(set1);
            setCollection.Add(set2);

            // Act
            setCollection.Remove(set1);

            // Assert
            Assert.Equal("B", setCollection.GetSetByIndex(0).Name);
        }
        [Fact]
        public void Count_ReturnsZero_WhenCollectionIsEmpty3()
        {
            // Arrange
            var setCollection = new SetCollection<int>();

            // Act
            int count = setCollection.Count;

            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void Add_IncrementsCount_WhenAddingNewSet3()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}", settings);

            // Act
            setCollection.Add(set);

            // Assert
            Assert.Equal(1, setCollection.Count);
        }

        [Fact]
        public void Remove_DecrementsCount_WhenRemovingSet3()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}", settings);
            setCollection.Add(set);

            // Act
            setCollection.Remove(set);

            // Assert
            Assert.Equal(0, setCollection.Count);
        }

        [Fact]
        public void FindSetByName_ReturnsSet_WhenNameExists()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}", settings);
            setCollection.Add(set);

            // Act
            var foundSet = setCollection.FindSetByName("A");

            // Assert
            Assert.NotNull(foundSet);
            Assert.Equal(set.ElementString, foundSet.ElementString);
            Assert.Equal(set.Cardinality, foundSet.Cardinality);
        }

        [Fact]
        public void FindSetByName_ReturnsNull_WhenNameDoesNotExist()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}", settings);
            setCollection.Add(set);

            // Act
            var foundSet = setCollection.FindSetByName("B");

            // Assert
            Assert.Null(foundSet);
        }

        [Fact]
        public void GetSetByIndex_ReturnsSet_WhenIndexExists()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}", settings);
            setCollection.Add(set);

            // Act
            var foundSet = setCollection.GetSetByIndex(0);

            // Assert
            Assert.NotNull(foundSet);
            Assert.Equal(set.ElementString, foundSet.ElementString);
            Assert.Equal(set.Cardinality, foundSet.Cardinality);
        }

        [Fact]
        public void GetSetByIndex_ThrowsIndexOutOfRangeException_WhenIndexIsInvalid()
        {
            // Arrange
            var setCollection = new SetCollection<int>();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => setCollection.GetSetByIndex(0));
        }

        [Fact]
        public void Count_ReturnsZero_WhenCollectionIsEmpty_New()
        {
            // Arrange
            var setCollection = new SetCollection<int>();

            // Act
            int count = setCollection.Count;

            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void Add_IncrementsCount_WhenAddingNewSet_New()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}",settings);

            // Act
            setCollection.Add(set);

            // Assert
            Assert.Equal(1, setCollection.Count);
        }

        [Fact]
        public void Remove_DecrementsCount_WhenRemovingSet_New()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}",settings);
            setCollection.Add(set);

            // Act
            setCollection.Remove(set);

            // Assert
            Assert.Equal(0, setCollection.Count);
        }

        [Fact]
        public void FindSetByName_ReturnsSet_WhenNameExists_New()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}",settings);
            setCollection.Add(set);

            // Act
            var foundSet = setCollection.FindSetByName("A");

            // Assert
            Assert.NotNull(foundSet);
            Assert.Equal(set.ElementString, foundSet.ElementString);
            Assert.Equal(set.Cardinality, foundSet.Cardinality);
        }

        [Fact]
        public void FindSetByName_ReturnsNull_WhenNameDoesNotExist_New()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}",settings);
            setCollection.Add(set);

            // Act
            var foundSet = setCollection.FindSetByName("B");

            // Assert
            Assert.Null(foundSet);
        }

        [Fact]
        public void GetSetByIndex_ReturnsSet_WhenIndexExists_New()
        {
            // Arrange
            var setCollection = new SetCollection<int>();
            var set = new GenericSet<int>("{1,2,3}",settings);
            setCollection.Add(set);

            // Act
            var foundSet = setCollection.GetSetByIndex(0);

            // Assert
            Assert.NotNull(foundSet);
            Assert.Equal(set.ElementString, foundSet.ElementString);
            Assert.Equal(set.Cardinality, foundSet.Cardinality);
        }

        [Fact]
        public void GetSetByIndex_ThrowsIndexOutOfRangeException_WhenIndexIsInvalid_New()
        {
            // Arrange
            var setCollection = new SetCollection<int>();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => setCollection.GetSetByIndex(0));
        }

    }//CLASS
}//NAMESPACE
