using NUnit.Framework;
using UniqueWordsApi.Extensions;
using System.Linq;
namespace Test
{
    public class StringExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetUniqueWordsFilterOk()
        {
            var value = "*.,!\\/¤$€%()={}+?';:|´`";
            var charIgnoreList = "*.,!\\/¤$€%()={}+?';:|´`";
            string[] split = { " ", "\r\n", "\r", "\n" };

        var result = value.GetUniqueWords(split, charIgnoreList);
            Assert.AreEqual(0, result.Count());
        }


        [Test]
        public void TestGetUniqueWordsFilterFail()
        {
            var value = "*.,!\\/¤$€%()={}+?';:|´`";
            var charIgnoreList = "*.,!\\/¤$€%()={}+?';:|´";
            string[] split = { " ", "\r\n", "\r", "\n" };
            var result = value.GetUniqueWords(split, charIgnoreList);
            Assert.AreNotEqual(0, result.Count());
        }

        [Test]
        public void TestGetUniqueWordsSplitNewLine()
        {
            var value = "This \n Test \r\n test2 \r test3 \n test4";
            var charIgnoreList = "";
            string[] split = { " ", "\r\n", "\r", "\n" };
            var result = value.GetUniqueWords(split, charIgnoreList);
            Assert.AreEqual(5, result.Count());
        }
    }
}