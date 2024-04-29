using System;
using Xunit;
using SetLibrary;
namespace SetLibraryTests.CSetTests
{
    public class SetExceptions
    {
        [Theory]
        [InlineData("{5,6,2,5,{6,6,5,2,5,5,}}}")]
        [InlineData("{1,{2,2,3,{5},5,}}}")]
        [InlineData("{{2,1},5,{{{4,2}}}")]
        [InlineData("{1,2}}},6}")]
        [InlineData("{{1,2}")]
        [InlineData("{1,2}}")]
        [InlineData("{1,2},{3,4}")] //Bug Resolved here
        [InlineData("{1,2,3},{{4,5}")]
        [InlineData("{{{1,2,3},{{4,5,6}}}")]
        [InlineData("{{1,2},{3,4}}}")]
        [InlineData("{{{{1,2},{3,4},{5,6}}}")]
        [InlineData("{{1,2},{3,4}},{{5,6},{7,8}}}")]
        [InlineData("{{1,2},{{3,4},{5,6}}}}")] 
        [InlineData("{{1,2},{{3,4},{5,6}}}},{{{{66}}}}")] 
        public void BracesNotMatchingException(string elementString)
        {
            //ArgumentException("Braces are not matching");
            ArgumentException ex = Assert.Throws<ArgumentException>(() => { new CSet(elementString); });
            Assert.Equal(ex.Message, "Braces are not matching");
        }
    }//class
}//namespace