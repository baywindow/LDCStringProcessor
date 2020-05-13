using StringLib;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LDCStringProcessorTests
{
    [TestClass]
    public class TestStringProcessor
    {
        [TestMethod]
        public void TestMethod_NullCollectionPassedIn()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            List<string> idata = null;
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(odata.Count, 0);
        }

        [TestMethod]
        public void TestMethod_EmptyCollectionPassedIn()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            List<string> idata = new List<string>();
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(odata.Count, 0);
        }

        [TestMethod]
        public void TestMethod_EmptyStringSupplied()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            var idata = MockData(0);
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(odata[0], "null or empty");
        }

        [TestMethod]
        public void TestMethod_MoreThan15Chars()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            var idata = MockData(1);
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(odata[0], "This is a strin");
        }

        [TestMethod]
        public void TestMethod_RemoveDuplicates()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            var idata = MockData(2);
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(odata[0], "ABbAcCc");
        }

        [TestMethod]
        public void TestMethod_ReplaceDollarSign()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            var idata = MockData(3);
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(odata[0], "Show me the £");
        }

        [TestMethod]
        public void TestMethod_Remove4AndUnderscore()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            var idata = MockData(4);
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreNotEqual(odata[0], "Hello World");
            // the double "ll" got caught! :-)
            Assert.AreEqual(odata[0], "Helo World");
        }

        [TestMethod]
        public void TestMethod_Remove4AndUnderscoreGivingEmptyString()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            var idata = MockData(5);
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(odata[0], "null or empty");
        }

        [TestMethod]
        public void TestMethod_SuppliedLDCString()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            var idata = MockData(6);
            var odata = stringProcessor.ReformatCollection(idata);

            // "AAAc91%cWwWkLq$1ci3_848v3d__K"
            Assert.AreEqual(odata[0], "Ac91%cWwWkLq£1c");
        }

        [TestMethod]
        public void TestMethod_HandleACollection()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            var idata = MockData(6, 7, 8);
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(idata.Count, odata.Count);
            Assert.AreEqual(odata[0], "Ac91%cWwWkLq£1c");
            Assert.AreEqual(odata[1], "The dog and the");
            Assert.AreEqual(odata[2], "Aple£0");
        }

        [TestMethod]
        public void TestMethod_OpenForDebateShouldThisBeOnePoundSignOrFour()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyLDC());

            var idata = MockData(9);
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(odata[0], "£");
        }

        [TestMethod]
        public void TestMethod_OtherStrategy()
        {
            StringProcessor stringProcessor = new StringProcessor(new ReformatStrategyOther());

            List<string> idata = new List<string>() { "123456789" };
            var odata = stringProcessor.ReformatCollection(idata);

            Assert.AreEqual(odata[0], "987654321");
        }

        // The input string may be any length and can contain any character
        // 1. Output strings must not be null or empty string
        // 2. string should be truncated to max length of 15 chars
        // 3. contiguous duplicate characters in the same case should be reduced to a single character in the same case
        // 4. Dollar sign ($) should be replaced with a pound sign(£)
        // 5. underscores(_) and number 4 should be removed
        private List<string> MockData(params int[] indexes)
        {
            List<string> output = new List<string>();

            List<string> data = new List<string>()
            {
                "", // empty string, 1. empty string should not be returned
                "This is a string of more than 15 chars", // 2. long string
                "AAABbbAAcCCcc", // 3. duplicate chars
                "Show me the $", // 4. dollar sign
                "4Hello _World", // 5. remove 4 and underscore chars
                "_4_", // 5. remove empty chars BUT this will result in empty string so see what happens
                "AAAc91%cWwWkLq$1ci3_848v3d__K", // supplied test string, will need altering on 2. 3. 4. and 5.
                "The dog and the cat sat on the mat", // random data which will get truncated
                "Apple$_04", // more random data
                "$£$£" // this one is open for debate, depends on the order of reformatting if we replace £ for $ then these become duplicates
            };

            foreach (var ix in indexes)
            {
                if (ix < 0 || ix >= data.Count)
                {
                    continue;
                }

                // if index is okay then add the given index to the output
                output.Add(data[ix]);
            }

            return output;
        }
    }
}
