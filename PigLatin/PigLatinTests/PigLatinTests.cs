namespace PigLatinTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PigLatin;

    [TestClass]
    public class PigLatinTests
    {
        [TestMethod]
        [DataRow("Hello", "Ellohay")]
        [DataRow("apple", "appleway")]
        [DataRow("stairway", "stairway")]
        [DataRow("can't", "antca'y")]
        [DataRow("end", "endway")]
        [DataRow("Beach", "Eachbay")]
        [DataRow("McCloud", "CcLoudmay")]
        public void BasicTestCases(string original, string pigLatin)
        {
            Assert.AreEqual(pigLatin, PigLatinWordConverter.Convert(original));
        }
    }
}
