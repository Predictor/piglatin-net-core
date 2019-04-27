namespace PigLatinTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PigLatin;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

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

        [TestMethod]
        public async Task StreamWordConverter_WithDegenerateConverter()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\gpl.txt");
            string text = File.ReadAllText(path);
            var converter = new StreamWordConverter(new MemoryStream(Encoding.UTF8.GetBytes(text)), s => s, CharExtensions.IsWordSeparator);
            var convertedStream = new MemoryStream();
            await converter.ConvertTo(convertedStream, CancellationToken.None);
            convertedStream.Position = 0;
            var convertedText = await new StreamReader(convertedStream).ReadToEndAsync();
            File.WriteAllText(path + ".pig", convertedText);
            Assert.AreEqual(text, convertedText);
        }
    }
}
