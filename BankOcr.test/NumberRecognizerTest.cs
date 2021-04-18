using NUnit.Framework;

namespace BankOcr.test
{
    public class NumberRecognizerTest
    {
        [TestCase("     |  |", true)]
        [TestCase(" _  _||_ ", false)]
        [TestCase(" _  _| _|", false)]
        [TestCase("   |_|  |", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _      |", false)]
        [TestCase(" _ |_||_|", false)]
        [TestCase(" _ |_| _|", false)]
        [TestCase(" _ | ||_|", false)]
        public void GivenNumber_WhenIsOne_ThenTrueOtherwiseFalse(string number, bool expectedIsOne)
        {
            // Act
            var isOne = NumberRecognizer.IsOne(number);

            //Assert
            Assert.AreEqual(expectedIsOne, isOne, "{0} should be isOne={1}", number, expectedIsOne); 
        }

        [TestCase("     |  |", false)]
        [TestCase(" _  _||_ ", true)]
        [TestCase(" _  _| _|", false)]
        [TestCase("   |_|  |", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _      |", false)]
        [TestCase(" _ |_||_|", false)]
        [TestCase(" _ |_| _|", false)]
        [TestCase(" _ | ||_|", false)]
        public void GivenNumber_WhenIsTwo_ThenTrueOtherwiseFalse(string number, bool expectedIsTwo)
        {
            // Act
            var isTwo = NumberRecognizer.IsTwo(number);

            //Assert
            Assert.AreEqual(expectedIsTwo, isTwo, "{0} should be isTwo={1}", number, expectedIsTwo);
        }

        [TestCase("     |  |", false)]
        [TestCase(" _  _||_ ", false)]
        [TestCase(" _  _| _|", true)]
        [TestCase("   |_|  |", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _      |", false)]
        [TestCase(" _ |_||_|", false)]
        [TestCase(" _ |_| _|", false)]
        [TestCase(" _ | ||_|", false)]
        public void GivenNumber_WhenIsThree_ThenTrueOtherwiseFalse(string number, bool expectedIsThree)
        {
            // Act
            var isThree = NumberRecognizer.IsThree(number);

            //Assert
            Assert.AreEqual(expectedIsThree, isThree, "{0} should be isThree={1}", number, expectedIsThree);
        }

        [TestCase("     |  |", false)]
        [TestCase(" _  _||_ ", false)]
        [TestCase(" _  _| _|", false)]
        [TestCase("   |_|  |", true)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _      |", false)]
        [TestCase(" _ |_||_|", false)]
        [TestCase(" _ |_| _|", false)]
        [TestCase(" _ | ||_|", false)]
        public void GivenNumber_WhenIsFour_ThenTrueOtherwiseFalse(string number, bool expectedIsFour)
        {
            // Act
            var isFour = NumberRecognizer.IsFour(number);

            //Assert
            Assert.AreEqual(expectedIsFour, isFour, "{0} should be isFour={1}", number, expectedIsFour);
        }

        [TestCase("     |  |", false)]
        [TestCase(" _  _||_ ", false)]
        [TestCase(" _  _| _|", false)]
        [TestCase("   |_|  |", false)]
        [TestCase(" _ |_  _|", true)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _      |", false)]
        [TestCase(" _ |_||_|", false)]
        [TestCase(" _ |_| _|", false)]
        [TestCase(" _ | ||_|", false)]
        public void GivenNumber_WhenIsFive_ThenTrueOtherwiseFalse(string number, bool expectedIsFive)
        {
            // Act
            var isFive = NumberRecognizer.IsFive(number);

            //Assert
            Assert.AreEqual(expectedIsFive, isFive, "{0} should be isFive={1}", number, expectedIsFive);
        }

        [TestCase("     |  |", false)]
        [TestCase(" _  _||_ ", false)]
        [TestCase(" _  _| _|", false)]
        [TestCase("   |_|  |", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_ |_|", true)]
        [TestCase(" _      |", false)]
        [TestCase(" _ |_||_|", false)]
        [TestCase(" _ |_| _|", false)]
        [TestCase(" _ | ||_|", false)]
        public void GivenNumber_WhenIsSix_ThenTrueOtherwiseFalse(string number, bool expectedIsSix)
        {
            // Act
            var isOne = NumberRecognizer.IsSix(number);

            //Assert
            Assert.AreEqual(expectedIsSix, isOne, "{0} should be isSix={1}", number, expectedIsSix);
        }

        [TestCase("     |  |", false)]
        [TestCase(" _  _||_ ", false)]
        [TestCase(" _  _| _|", false)]
        [TestCase("   |_|  |", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _   |  |", true)]
        [TestCase(" _ |_||_|", false)]
        [TestCase(" _ |_| _|", false)]
        [TestCase(" _ | ||_|", false)]
        public void GivenNumber_WhenIsSeven_ThenTrueOtherwiseFalse(string number, bool expectedIsSeven)
        {
            // Act
            var isOne = NumberRecognizer.IsSeven(number);

            //Assert
            Assert.AreEqual(expectedIsSeven, isOne, "{0} should be isSeven={1}", number, expectedIsSeven);
        }

        [TestCase("     |  |", false)]
        [TestCase(" _  _||_ ", false)]
        [TestCase(" _  _| _|", false)]
        [TestCase("   |_|  |", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _   |  |", false)]
        [TestCase(" _ |_||_|", true)]
        [TestCase(" _ |_| _|", false)]
        [TestCase(" _ | ||_|", false)]
        public void GivenNumber_WhenIsEight_ThenTrueOtherwiseFalse(string number, bool expectedIsEigh)
        {
            // Act
            var isEight = NumberRecognizer.IsEight(number);

            //Assert
            Assert.AreEqual(expectedIsEigh, isEight, "{0} should be isSeven={1}", number, expectedIsEigh);
        }

        [TestCase("     |  |", false)]
        [TestCase(" _  _||_ ", false)]
        [TestCase(" _  _| _|", false)]
        [TestCase("   |_|  |", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _   |  |", false)]
        [TestCase(" _ |_||_|", false)]
        [TestCase(" _ |_| _|", true)]
        [TestCase(" _ | ||_|", false)]
        public void GivenNumber_WhenIsNine_ThenTrueOtherwiseFalse(string number, bool expectedIsNine)
        {
            // Act
            var isNine = NumberRecognizer.IsNine(number);

            //Assert
            Assert.AreEqual(expectedIsNine, isNine, "{0} should be isSeven={1}", number, expectedIsNine);
        }

        [TestCase("     |  |", false)]
        [TestCase(" _  _||_ ", false)]
        [TestCase(" _  _| _|", false)]
        [TestCase("   |_|  |", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_  _|", false)]
        [TestCase(" _ |_ |_|", false)]
        [TestCase(" _   |  |", false)]
        [TestCase(" _ |_||_|", false)]
        [TestCase(" _ |_| _|", false)]
        [TestCase(" _ | ||_|", true)]
        public void GivenNumber_WhenIsZero_ThenTrueOtherwiseFalse(string number, bool expectedIsZero)
        {
            // Act
            var isZero = NumberRecognizer.IsZero(number);

            //Assert
            Assert.AreEqual(expectedIsZero, isZero, "{0} should be isSeven={1}", number, expectedIsZero);
        }

        [TestCase("     |  |", 1)]
        [TestCase(" _  _||_ ", 2)]
        [TestCase(" _  _| _|", 3)]
        [TestCase("   |_|  |", 4)]
        [TestCase(" _ |_  _|", 5)]
        [TestCase(" _ |_ |_|", 6)]
        [TestCase(" _   |  |", 7)]
        [TestCase(" _ |_||_|", 8)]
        [TestCase(" _ |_| _|", 9)]
        [TestCase(" _ | ||_|", 0)]
        public void GivenNumber_WhenRecognizeNumber_ThenGetExpectedDigit(string number, int expectedDigit)
        {
            // Act
            var numberRecognizer = new NumberRecognizer();
            var digit = numberRecognizer.RecognizeNumber(number);

            //Assert
            Assert.AreEqual(expectedDigit, digit, "{0} should be recognized as {1}", number, expectedDigit);
        }
    }
}
