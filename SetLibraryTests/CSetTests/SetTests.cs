using SetLibrary.Operations;
using SetLibrary;
using Xunit;
namespace SetLibraryTests.CSetTests
{
    public class SetTests
    {
        [Theory]
        [InlineData("{9,8,1,2,5,6,1,2}", "1,2,5,6,8,9")]
        [InlineData("{2,6,1,73,10,15,{8,6,{3},{7,5}}}", "{1,2,6,10,15,73,{6,8,{3},{5,7}}}")]
        [InlineData("{5,{5,6,{2}},{8,{6}},2}", "{2,5,{8,{6}},{5,6,{2}}}")]
        [InlineData("{{{{{{{{6}}}}}}}}", "{{{{{{{{6}}}}}}}}")]
        [InlineData("{5,5,3,{6,{5,8},5,6},7}", "{3,5,7,{5,6,{5,8}}}")]
        [InlineData("{ 8, 7, 5, 2, 14, 1, { 5, 8, 9, 6, 33 } }", "{1,14,2,5,7,8,{33,5,6,8,9}}")]
        [InlineData("{5,5,3,{6,{5,8},{5,3},5,6},{6,{5,8},{5,3},5,6},7}", "{3,5,7,{5,6,{3,5},{5,8}}}")]
        public void ElementStringShouldBeCorrect(string elementString, string expectedString)
        {
            //Create the new set objec
            ISet<string> set = new CSet(elementString);

            Assert.Equal(expectedString, set.ElementString);
        }//TestForCorrectElementString
        public void CardinalityShouldBeCorrect(string elementString, int expectedCardinality)
        {

        }
    }//class
}//namespace
