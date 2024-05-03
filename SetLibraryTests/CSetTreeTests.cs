using SetLibrary;
using SetLibrary.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SetLibraryTests
{
    public class CSetTreeTests
    {
        [Fact]
        public void ConstructorWithRootElements_DefaultSettings_CreatesInstance()
        {
            // Arrange
            var rootElements = new List<int> { 1, 2, 3 };

            // Act
            var setTree = new CSetTree<int>(rootElements);

            // Assert
            Assert.NotNull(setTree);
            Assert.Equal(rootElements.Count, setTree.Cardinality);
            Assert.Equal(0, setTree.NumberOfSubsets);
        }//ConstructorWithRootElements_DefaultSettings_CreatesInstance

        [Fact]
        public void AddSubSetTree_NewTree_AddsToSubsets()
        {
            // Arrange
            var rootElements = new List<int> { 1, 2, 3 };
            var setTree = new CSetTree<int>(rootElements);
            var newTree = new CSetTree<int>(new List<int> { 4, 5 });

            // Act
            setTree.AddSubSetTree(newTree);

            // Assert
            Assert.Equal(1, setTree.NumberOfSubsets);
            Assert.Equal(4, setTree.Cardinality);
        }//AddSubSetTree_NewTree_AddsToSubsets

        [Fact]
        public void RemoveElement_TreeExists_RemovesFromRoot()
        {
            // Arrange
            var rootElements = new List<int> { 1, 2, 3 };
            var setTree = new CSetTree<int>(rootElements);

            // Act
            setTree.RemoveElement(2);

            // Assert
            Assert.Equal(2, setTree.Cardinality);
            Assert.DoesNotContain(2, setTree);
        }//RemoveElement_TreeExists_RemovesFromRoot

        [Fact]
        public void IndexOf_ExistingElement_ReturnsIndex()
        {
            // Arrange
            var rootElements = new List<int> { 1, 2, 3 };
            var setTree = new CSetTree<int>(rootElements);

            // Act
            var index = setTree.IndexOf(2);

            // Assert
            Assert.Equal(1, index);
        }//IndexOf_ExistingElement_ReturnsIndex

        [Fact]
        public void ToString_EmptySet_ReturnsEmptyBraces()
        {
            // Arrange
            var setTree = new CSetTree<int>(new List<int>());

            // Act
            var result = setTree.ToString();

            // Assert
            Assert.Equal("{\u2205}", result);
        }//ToString_EmptySet_ReturnsEmptyBraces
        [Fact]
        public void ConstructorWithRootElementsAndSettings_CreatesInstance()
        {
            // Arrange
            var rootElements = new List<int> { 1, 2, 3 };
            var settings = new SetExtractionSettings<int>(",");

            // Act
            var setTree = new CSetTree<int>(rootElements, settings);

            // Assert
            Assert.NotNull(setTree);
            Assert.Equal(rootElements.Count, setTree.Cardinality);
        }//ConstructorWithRootElementsAndSettings_CreatesInstance

        [Fact]
        public void AddElement_NewElement_AddsToRoot()
        {
            // Arrange
            var setTree = new CSetTree<int>(new List<int> { 1, 2, 3 });

            // Act
            setTree.AddElement(4);

            // Assert
            Assert.Equal(4, setTree.Cardinality);
            Assert.Contains(4, setTree);
        }//AddElement_NewElement_AddsToRoot

        [Fact]
        public void RemoveElement_TreeExists_RemovesFromSubsets()
        {
            // Arrange
            var rootElements = new List<int> { 1, 2, 3 };
            var subsetElements = new List<int> { 4, 5 };
            var setTree = new CSetTree<int>(rootElements);
            var subsetTree = new CSetTree<int>(subsetElements);
            setTree.AddSubSetTree(subsetTree);

            // Act
            setTree.RemoveElement(subsetTree);

            // Assert
            Assert.Equal(3, setTree.Cardinality);
            Assert.DoesNotContain(subsetTree, setTree.GetSubsetsEnumarator());
        }//RemoveElement_TreeExists_RemovesFromSubsets

        [Fact]
        public void GetSubsetsEnumarator_EmptySet_ReturnsEmptyEnumerator()
        {
            // Arrange
            var setTree = new CSetTree<int>(new List<int>());

            // Act
            var enumerator = setTree.GetSubsetsEnumarator();

            // Assert
            Assert.Empty(enumerator);
        }//GetSubsetsEnumarator_EmptySet_ReturnsEmptyEnumerator

        [Fact]
        public void ToString_NestedSets_ReturnsCorrectString()
        {
            // Arrange
            var setTree = new CSetTree<int>(new List<int> { 1, 2, 3 });
            var subsetTree = new CSetTree<int>(new List<int> { 4, 5 });
            setTree.AddSubSetTree(subsetTree);

            // Act
            var result = setTree.ToString();

            // Assert
            Assert.Equal("{1,2,3,{4,5}}", result);
        }//ToString_NestedSets_ReturnsCorrectString

       [Fact]
        public void ConstructorWithUnorderedRootElementsAndSettings_CreatesInstance()
        {
            // Arrange
            var rootElements = new List<string> { "banana", "apple", "orange" };
            var settings = new SetExtractionSettings<string>(";", "|", "missing");

            // Act
            var setTree = new CSetTree<string>(rootElements, settings);

            // Assert
            Assert.NotNull(setTree);
            Assert.Equal(rootElements.Count, setTree.Cardinality);
        }//ConstructorWithUnorderedRootElementsAndSettings_CreatesInstance

        [Fact]
        public void AddElement_NewElement_AddsToRoot2()
        {
            // Arrange
            var setTree = new CSetTree<string>(new List<string> { "banana", "apple", "orange" });

            // Act
            setTree.AddElement("grape");

            // Assert
            Assert.Equal(4, setTree.Cardinality);
            Assert.Contains("grape", setTree);
        }//AddElement_NewElement_AddsToRoot2

        [Fact]
        public void RemoveElement_TreeExists_RemovesFromSubsets2()
        {
            // Arrange
            var rootElements = new List<string> { "banana", "apple", "orange" };
            var subsetElements = new List<string> { "grape", "melon" };
            var setTree = new CSetTree<string>(rootElements);
            var subsetTree = new CSetTree<string>(subsetElements);
            setTree.AddSubSetTree(subsetTree);

            // Act
            setTree.RemoveElement(subsetTree);

            // Assert
            Assert.Equal(3, setTree.Cardinality);
            Assert.DoesNotContain(subsetTree, setTree.GetSubsetsEnumarator());
        }//RemoveElement_TreeExists_RemovesFromSubsets2

        [Fact]
        public void GetSubsetsEnumarator_EmptySet_ReturnsEmptyEnumerator2()
        {
            // Arrange
            var setTree = new CSetTree<int>(new List<int>());

            // Act
            var enumerator = setTree.GetSubsetsEnumarator();

            // Assert
            Assert.Empty(enumerator);
        }//GetSubsetsEnumarator_EmptySet_ReturnsEmptyEnumerator2

        [Fact]
        public void ToString_NestedSets_ReturnsCorrectString2()
        {
            // Arrange
            var settings = new SetExtractionSettings<string>(";");
            var setTree = new CSetTree<string>(new List<string> { "banana", "apple", "orange" },settings);
            var subsetTree = new CSetTree<string>(new List<string> { "grape", "melon" },settings);
            setTree.AddSubSetTree(subsetTree);

            // Act
            var result = setTree.ToString();

            // Assert
            Assert.Equal("{apple;banana;orange;{grape;melon}}", result);
        }//ToString_NestedSets_ReturnsCorrectString2

        [Fact]
        public void ConstructorWithEmptyRootElementsAndSettings_CreatesEmptyInstance()
        {
            // Arrange
            var rootElements = new List<int>();
            var settings = new SetExtractionSettings<int>(";", "|", -1);

            // Act
            var setTree = new CSetTree<int>(rootElements, settings);

            // Assert
            Assert.NotNull(setTree);
            Assert.Equal("{\u2205}",setTree.ToString());
        }//ConstructorWithEmptyRootElementsAndSettings_CreatesEmptyInstance

        [Fact]
        public void AddSubSetTree_TreeWithDuplicateElements_AddsToSubsets()
        {
            // Arrange
            var rootElements = new List<int> { 1, 2, 3 };
            var duplicateElements = new List<int> { 3, 4, 5 };
            var setTree = new CSetTree<int>(rootElements);
            var duplicateTree = new CSetTree<int>(duplicateElements);

            // Act
            setTree.AddSubSetTree(duplicateTree);

            // Assert
            Assert.Equal(4, setTree.Cardinality);
            Assert.True(setTree.Contains(3));
            Assert.False(setTree.Contains(4));
            Assert.False(setTree.Contains(5));
        }//AddSubSetTree_TreeWithDuplicateElements_AddsToSubsets

        [Fact]
        public void RemoveElement_ElementNotInTree_ReturnsFalse()
        {
            // Arrange
            var setTree = new CSetTree<string>(new List<string> { "dog", "cat", "bird" });

            // Act
            var result = setTree.RemoveElement("fish");

            // Assert
            Assert.False(result);
        }//RemoveElement_ElementNotInTree_ReturnsFalse

        [Fact]
        public void IndexOf_EmptyTree_ReturnsNegativeOne()
        {
            // Arrange
            var setTree = new CSetTree<double>(new List<double>());

            // Act
            var index = setTree.IndexOf(1.5);

            // Assert
            Assert.Equal(-1, index);
        }//IndexOf_EmptyTree_ReturnsNegativeOne

        [Fact]
        public void ToString_SingleElementWithBraces_ReturnsCorrectString()
        {
            // Arrange
            var setTree = new CSetTree<char>(new List<char> { 'A' });

            // Act
            var result = setTree.ToString();

            // Assert
            Assert.Equal("{A}", result);
        }//ToString_SingleElementWithBraces_ReturnsCorrectString
    }//class
}//namespace