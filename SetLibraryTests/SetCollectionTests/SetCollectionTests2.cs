using System;
using SetLibrary;
using SetLibrary.Generic;
using SetLibrary.Collections;
using Xunit;

namespace SetLibraryTests.SetCollectionTests
{
    public class SetCollectionTests2
    {
        private static readonly SetExtractionSettings<int> settings = new SetExtractionSettings<int>(",");
        private static SetCollection<int> collection;
        public SetCollectionTests2()
        {
            //Create an empty set
            collection = new SetCollection<int>();
            //Add 16,384 empty sets. 
            var set =new GenericSet<int>(settings);
            for (int i = 0; i < 16384; i++)
                collection.Add(set);
            string exp = "{5,6,8,5,6,5,2,{3,5}}";
            set = new GenericSet<int>(exp, settings);
            collection.Add(set);
        }

        [Fact]
        public void TestNamingUsingExcelColumns()
        {
            //In excel column 16384 == XFD
            var set16384 = collection.GetSetByIndex(16383);

            //In excel column 16383 == XFC
            var set16383 = collection.GetSetByIndex(16382);

            //In excel column 27 == AA
            var set27 = collection.GetSetByIndex(26);

            //Since excel end at 16384(XFD) we can assume that 16385 == XFE
            var set16385 = collection.GetSetByIndex(16384);


            Assert.Equal("XFD", set16384.Name);
            Assert.Equal("XFC", set16383.Name);
            Assert.Equal("XFE", set16385.Name);
            Assert.Equal("AA", set27.Name);

        }//TestNamingUsingExcelColumns
        [Fact]
        public void LastSetShouldNotBeEmpty()
        {
            var set = collection[collection.Count - 1];

            int count = set.Cardinality;
            bool isempty = count <= 0;
            Assert.False(isempty);
        }//LastSetShouldNotBeEmpty

        [Fact]
        public void CountShouldBe16385()
        {
            Assert.Equal(16385, collection.Count);
        }//CountShouldBe16384

    }//class
}//namespace
