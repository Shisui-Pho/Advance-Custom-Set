using SetLibrary;
using Xunit;
namespace SetLibraryTests.CSetTests
{
    public class SetTests
    {
        [Theory]
        [InlineData("{9,8,1,2,5,6,1,2}", "{1,2,5,6,8,9}")]
        [InlineData("{3,2,5,1,2}","{1,2,3,5}")]
        [InlineData("{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}","{1}")]
        [InlineData("{6,0,1,2,9,0,6}","{0,1,2,6,9}")]
        [InlineData("{3,1,3}","{1,3}")]
        [InlineData("{5,6,6,6,2}","{2,5,6}")]
        public void ElementStringsWithoutNestedSetsTest(string elementString, string expectedString)
        {
            //Create the new set objec
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expectedString, set.ElementString);
        }//ElementStringsWithoutNestedSetsTest
        
        [Theory]
        [InlineData("{9,8,1,2,5,6,1,2}", 6)]
        [InlineData("{3,2,5,1,2}", 4)]
        [InlineData("{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}", 1)]
        [InlineData("{6,0,1,2,9,0,6}", 5)]
        [InlineData("{3,1,3}", 2)]
        [InlineData("{5,6,6,6,2}", 3)]
        public void ElementStringsWithoutNestedSetsCardinalityTest(string elementString, int expectedCardinality)
        {
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expectedCardinality, set.Cardinality);
        }//ElementStringsWithoutNestedSetsCardinalityTest

        [Theory]
        [InlineData("{5,2,6,{8,6}}","{2,5,6,{6,8}}")]
        [InlineData("{2,{8,1,9},3}","{2,3,{1,8,9}}")]
        [InlineData("{{5,2},2,6,2}","{2,6,{2,5}}")]
        [InlineData("{9,{2,0},8}","{8,9,{0,2}}")]
        [InlineData("{1,1,1,{3,5,4,2,5,2,2},8,4,1,2,5,4}","{1,2,4,5,8,{2,3,4,5}}")]
        [InlineData("{6,6,{6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},6}","{6,{6}}")]
        [InlineData("{1,0,1,0,1,0,1,{0,1,0,1,0,1},0,1}","{0,1,{0,1}}")]
        public void ElementStringWithDegreeOneNestingLevelTest(string elementString, string expectedSetString)
        {
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expectedSetString, set.ElementString);
        }//ElementStringWithDegreeOneNestingLevelTest

        [Theory]
        [InlineData("{5,2,6,{8,6}}", 4)]
        [InlineData("{2,{8,1,9},3}", 3)]
        [InlineData("{{5,2},2,6,2}", 3)]
        [InlineData("{9,{2,0},8}",3)]
        [InlineData("{1,1,1,{3,5,4,2,5,2,2},8,4,1,2,5,4}", 6)]
        [InlineData("{6,6,{6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},6}", 2)]
        [InlineData("{1,0,1,0,1,0,1,{0,1,0,1,0,1},0,1}", 3)]
        public void ElementStringWithDegreeOneNestingLevelTestCardinality(string elementString, int expectedCardinality)
        {
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expectedCardinality, set.Cardinality);
        }//ElementStringWithDegreeOneNestingLevelTestCardinality

        [Theory]
        [InlineData("{{2,{5,5,{6}}}}","{{2,{5,{6}}}}")]
        [InlineData("{2,{6,6,{8,2,{10,10},2},1},0}","{0,2,{1,6,{2,8,{10}}}}")]
        [InlineData("{8,{6,6,{8,8,{9,9,{5,5,5,5,5,5,5,5,5,5,5,5,5}}}}}","{8,{6,{8,{9,{5}}}}}")]
        [InlineData("{1,{1,{1,{1,{1}}}}}", "{1,{1,{1,{1,{1}}}}}")]
        [InlineData("{3,6,6,{9,4,{3,2},1},0}","{0,3,6,{1,4,9,{2,3}}}")]
        [InlineData("{{{{{{{{6,6,5}}}}}}}}", "{{{{{{{{5,6}}}}}}}}")]
        [InlineData("{3,2,{1,{6,6},6}}","{2,3,{1,6,{6}}}")]
        public void ElementStringWithOneDegreeNestingLevelIncludingSubSets(string elementString, string expextedElementString)
        {
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expextedElementString, set.ElementString);
        }//ElementStringWithOneDegreeNestingLevelIncludingSubSets

        [Theory]
        [InlineData("{{2,{5,5,{6}}}}",1)]
        [InlineData("{2,{6,6,{8,2,{10,10},2},1},0}", 3)]
        [InlineData("{8,{6,6,{8,8,{9,9,{5,5,5,5,5,5,5,5,5,5,5,5,5}}}}}", 2)]
        [InlineData("{1,{1,{1,{1,{1}}}}}", 2)]
        [InlineData("{3,6,6,{9,4,{3,2},1},0}", 4)]
        [InlineData("{{{{{{{{6,6,5}}}}}}}}", 1)]
        [InlineData("{3,2,{1,{6,6},6}}", 3)]
        public void ElementStringWithOneDegreeNestingLevelIncludingSubSetsCardinality(string elementString, int expectedCardinality)
        {
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expectedCardinality, set.Cardinality);
        }//ElementStringWithOneDegreeNestingLevelIncludingSubSetsCardinality
        [Theory]
        [InlineData("{6,5,6,{6,6},{8,6}}","{5,6,{6},{6,8}}")]
        [InlineData("{3,2,{5,6,6},{5,6,6},3}","{2,3,{5,6}}")]
        [InlineData("{6,2,1,{5,8,1,9,2},{1,2,5,8,9}}", "{1,2,6,{1,2,5,8,9}}")]
        [InlineData("{3,5,{6,2},1,{6,6,6,6},3}","{1,3,5,{6},{2,6}}")]
        [InlineData("{9,2,3,{4,1},4,4,2,1,{6,3}}", "{1,2,3,4,9,{1,4},{3,6}}")]
        [InlineData("{2,2,{4,3},8,{6,6,6,6}}","{2,8,{6},{3,4}}")]
        [InlineData("{{2,2,2,2},{3,1,2},{1,2,3},{2,1,3},{2,2}}","{{2},{1,2,3}}")]
        public void ElementStringWithMultipleSubsetsOfOneDegreeNestingLevel(string elementString, string expextedElementString)
        {
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expextedElementString, set.ElementString);
        }//ElementStringWithMultipleSubsetsOfOneDegreeNestingLevel

        [Theory]
        [InlineData("{6,5,6,{6,6},{8,6}}", 4)]
        [InlineData("{3,2,{5,6,6},{5,6,6},3}", 3)]
        [InlineData("{6,2,1,{5,8,1,9,2},{1,2,5,8,9}}", 4)]
        [InlineData("{3,5,{6,2},1,{6,6,6,6},3}", 5)]
        [InlineData("{9,2,3,{4,1},4,4,2,1,{6,3}}", 7)]
        [InlineData("{2,2,{4,3},8,{6,6,6,6}}", 4)]
        [InlineData("{{2,2,2,2},{3,1,2},{1,2,3},{2,1,3},{2,2}}", 2)]
        public void ElementStringWithMultipleSubsetsOfOneDegreeNestingLevelCardinality(string elementString, int expectedCardinality)
        {
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expectedCardinality, set.Cardinality);
        }//ElementStringWithMultipleSubsetsOfOneDegreeNestingLevelCardinality

        [Theory]
        [InlineData("{9,8,1,2,5,6,1,2}", "{1,2,5,6,8,9}")]
        [InlineData("{2,6,1,73,10,15,{8,6,{3},{7,5}}}", "{1,10,15,2,6,73,{6,8,{3},{5,7}}}")]
        [InlineData("{5,{5,6,{2}},{8,{6}},2}", "{2,5,{8,{6}},{5,6,{2}}}")]
        [InlineData("{{{{{{{{6}}}}}}}}", "{{{{{{{{6}}}}}}}}")]
        [InlineData("{5,5,3,{6,{5,8},5,6},7}", "{3,5,7,{5,6,{5,8}}}")]
        [InlineData("{ 8, 7, 5, 2, 14, 1, { 5, 8, 9, 6, 33 } }", "{1,14,2,5,7,8,{33,5,6,8,9}}")]
        [InlineData("{5,5,3,{6,{5,8},{5,3},5,6},{6,{5,8},{5,3},5,6},7}", "{3,5,7,{5,6,{3,5},{5,8}}}")]         
        public void GeneralElementStrings(string elementString, string expextedElementString)
        {
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expextedElementString, set.ElementString);
        }//ElementStringWithMultipleSubsetsOfOneDegreeNestingLevel
        [Theory]
        [InlineData("{9,8,1,2,5,6,1,2}", 6)]
        [InlineData("{2,6,1,73,10,15,{8,6,{3},{7,5}}}",7 )]
        [InlineData("{5,{5,6,{2}},{8,{6}},2}", 4)]
        [InlineData("{{{{{{{{6}}}}}}}}", 1)]
        [InlineData("{5,5,3,{6,{5,8},5,6},7}", 4)]
        [InlineData("{ 8, 7, 5, 2, 14, 1, { 5, 8, 9, 6, 33 } }", 7)]
        [InlineData("{5,5,3,{6,{5,8},{5,3},5,6},{6,{5,8},{5,3},5,6},7}",4 )]
        public void GeneralElementStringsCardinality(string elementString, int expectedCardinality)
        {
            //Create the new set objec
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expectedCardinality, set.Cardinality);
        }//CardinalityShouldBeCorrect


        [Theory]
        [InlineData("{{{{}}}}", "{{{{\u2205}}}}")]
        [InlineData("{3,2,{4,2},{}}", "{2,3,{\u2205},{2,4}}")]
        [InlineData("{{},1,2,{}}", "{1,2,{\u2205}}")]
        [InlineData("{\u2205}", "{\u2205}")]
        public void EmptySetsTests(string elementString, string expectedString)
        {
            //Create the new set objec
            ICSet<string> set = new CSet(elementString);

            Assert.Equal(expectedString, set.ElementString);
        }//EmptySetsTests

    }//class
}//namespace
