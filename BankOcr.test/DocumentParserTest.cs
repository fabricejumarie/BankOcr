using Moq;
using NUnit.Framework;
using System.Linq;

namespace BankOcr.test
{
    public class DocumentParserTest
    {
        [Test]
        public void GivenContentFile_WhenGetEntryByPosition_ThenGetExpectedEntry()
        {
            // Arrange
            var lines = new[]
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           ",
                " _  _  _  _  _  _  _  _  _ ",
                "| || || || || || || || || |",
                "|_||_||_||_||_||_||_||_||_|",
                "                           ",
                "                           ",
                "  |  |  |  |  |  |  |  |  |",
                "  |  |  |  |  |  |  |  |  |",
                "                           ",
                " _  _  _  _  _  _  _  _  _ ",
                " _| _| _| _| _| _| _| _| _|",
                "|_ |_ |_ |_ |_ |_ |_ |_ |_ ",
                "                           ",
            };

            var numberRecognizerMock = new Mock<INumberRecognizer>();

            // Act
            var documentParser = new DocumentParser(numberRecognizerMock.Object);
            var entry = documentParser.GetEntryByPosition(lines, 0).ToList();

            Assert.IsNotNull(entry, "entry should not be null");
            Assert.AreEqual(4, entry.Count, "4 lines should be returned");
            Assert.AreEqual(lines[0], entry[0]);
            Assert.AreEqual(lines[1], entry[1]);
            Assert.AreEqual(lines[2], entry[2]);

            entry = documentParser.GetEntryByPosition(lines, 1).ToList();
            Assert.IsNotNull(entry, "entry should not be null");
            Assert.AreEqual(4, entry.Count, "4 lines should be returned");
            Assert.AreEqual(lines[4], entry[0]);
            Assert.AreEqual(lines[5], entry[1]);
            Assert.AreEqual(lines[6], entry[2]);

            entry = documentParser.GetEntryByPosition(lines, 2).ToList();
            Assert.IsNotNull(entry, "entry should not be null");
            Assert.AreEqual(4, entry.Count, "4 lines should be returned");
            Assert.AreEqual(lines[8], entry[0]);
            Assert.AreEqual(lines[9], entry[1]);
            Assert.AreEqual(lines[10], entry[2]);

            entry = documentParser.GetEntryByPosition(lines, 3).ToList();
            Assert.IsNotNull(entry, "entry should not be null");
            Assert.AreEqual(4, entry.Count, "4 lines should be returned");
            Assert.AreEqual(lines[12], entry[0]);
            Assert.AreEqual(lines[13], entry[1]);
            Assert.AreEqual(lines[14], entry[2]);
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(4, 5)]
        [TestCase(5, 6)]
        [TestCase(6, 7)]
        [TestCase(7, 8)]
        [TestCase(8, 9)]
        public void GivenEntry_WhenGetDigitByPosition_ThenGetExpectedDigit(int position, int expectedDigit)
        {
            // Arrange
            var lines = new[]
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           ",
            };

            // Act
            var documentParser = new DocumentParser(new NumberRecognizer());
            var number = documentParser.GetDigitByPosition(lines, position);

            Assert.AreEqual(expectedDigit, number, "Number at position {0} should be {1}", position, expectedDigit);
        }

        [Test]
        public void GivenEntryLinesZeros_WhenParseEntry_ThenGetZeros()
        {
            // Arrange
            var entryLines = new[]
            {
                " _  _  _  _  _  _  _  _  _ ",
                "| || || || || || || || || |",
                "|_||_||_||_||_||_||_||_||_|",
                "                           ",
            };

            // Act
            var documentParser = new DocumentParser(new NumberRecognizer());
            var parsedEntry = documentParser.ParseEntry(entryLines);

            Assert.AreEqual("000000000", parsedEntry, "parsedEntry should be 000000000");
        }

        [Test]
        public void GivenEntryLinesOnes_WhenParseEntry_ThenGetOnes()
        {
            // Arrange
            var entryLines = new[]
            {
                "                           ",
                "  |  |  |  |  |  |  |  |  |",
                "  |  |  |  |  |  |  |  |  |",
                "                           ",
            };

            // Act
            var documentParser = new DocumentParser(new NumberRecognizer());
            var parsedEntry = documentParser.ParseEntry(entryLines);

            // Assert
            Assert.AreEqual("111111111", parsedEntry, "parsedEntry should be 111111111");
        }

        [Test]
        public void GivenEntryLinesTwos_WhenParseEntry_ThenGetOnes()
        {
            // Arrange
            var entryLines = new[]
            {
                " _  _  _  _  _  _  _  _  _ ",
                " _| _| _| _| _| _| _| _| _|",
                "|_ |_ |_ |_ |_ |_ |_ |_ |_ ",
                "                           ",
            };

            // Act
            var documentParser = new DocumentParser(new NumberRecognizer());
            var parsedEntry = documentParser.ParseEntry(entryLines);

            // Assert
            Assert.AreEqual("222222222", parsedEntry, "parsedEntry should be 222222222");
        }

        [Test]
        public void GivenEntryLinesThrees_WhenParseEntry_ThenGetThrees()
        {
            // Arrange
            var entryLines = new[]
            {
                " _  _  _  _  _  _  _  _  _ ",
                " _| _| _| _| _| _| _| _| _|",
                " _| _| _| _| _| _| _| _| _|",
                "                           ",
            };

            // Act
            var documentParser = new DocumentParser(new NumberRecognizer());
            var parsedEntry = documentParser.ParseEntry(entryLines);

            // Assert
            Assert.AreEqual("333333333", parsedEntry, "parsedEntry should be 333333333");
        }

        [Test]
        public void GivenEntryLinesFours_WhenParseEntry_ThenGetFours()
        {
            // Arrange
            var entryLines = new[]
            {
                "                           ",
                "|_||_||_||_||_||_||_||_||_|",
                "  |  |  |  |  |  |  |  |  |",
                "                           ",
            };

            // Act
            var documentParser = new DocumentParser(new NumberRecognizer());
            var parsedEntry = documentParser.ParseEntry(entryLines);

            // Assert
            Assert.AreEqual("444444444", parsedEntry, "parsedEntry should be 444444444");
        }

        [Test]
        public void GivenEntryLinesFives_WhenParseEntry_ThenGetFives()
        {
            // Arrange
            var entryLines = new[]
            {
                " _  _  _  _  _  _  _  _  _ ",
                "|_ |_ |_ |_ |_ |_ |_ |_ |_ ",
                " _| _| _| _| _| _| _| _| _|",
                "                           ",
            };

            // Act
            var documentParser = new DocumentParser(new NumberRecognizer());
            var parsedEntry = documentParser.ParseEntry(entryLines);

            // Assert
            Assert.AreEqual("555555555", parsedEntry, "parsedEntry should be 555555555");
        }
    }
}
