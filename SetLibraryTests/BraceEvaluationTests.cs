using Xunit;
using SetLibrary;
using System;
namespace SetLibraryTests
{
    public class BraceEvaluationTests
    {
        [Theory]
        [InlineData("{5,6,8,{10,5,6,{5,3}}", false)]
        [InlineData("{2,5,6,{8,6,{9,8,{2}}}",false)]
        [InlineData("2,8,6,5,7}", false)]
        [InlineData("{6,8,2,{3,9,8,5,6,{5,4,6,{9,7}}}}", true)]
        [InlineData("5,6,8,5,45,5,6,2",false)]
        [InlineData("{{{{{{{}}}}}}}}}}",false)]
        [InlineData("{{{{{5,6,8,{3,4,5}{{6,7,8},6,8},6,2,1,{5,6,8,{3,8,7,1,{4}}}}}},{5,6}},6}", true)]
        [InlineData("}}{{{", false)]
        public void SetBracesEvaluationTests(string elementString, bool expected)
        {
            bool actual = BracesEvaluation.AreBracesCorrect(elementString);

            Assert.Equal(expected, actual);
        }//SetBracesEvaluationTests
    }//class
}//namespace
