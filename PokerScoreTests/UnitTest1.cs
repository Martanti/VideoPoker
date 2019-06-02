using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameManagment;

namespace PokerScoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRoyalFlush()
        {

            Card [] testCards = new Card[5];

            testCards[0] = new Card() { cardRank= CardRank.Ace, cardSymbol = CardSymbol.Clubs };
            testCards[1] = new Card() { cardRank = CardRank.King, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.Queen, cardSymbol = CardSymbol.Clubs };
            testCards[3] = new Card() { cardRank = CardRank.Jack, cardSymbol = CardSymbol.Clubs };
            testCards[4] = new Card() { cardRank = CardRank.Ten, cardSymbol = CardSymbol.Clubs };

            int expected = 800;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void TestStraightFlush()
        {

            Card[] testCards = new Card[5];

            testCards[0] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Clubs };
            testCards[1] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.Four, cardSymbol = CardSymbol.Clubs };
            testCards[3] = new Card() { cardRank = CardRank.Six, cardSymbol = CardSymbol.Clubs };
            testCards[4] = new Card() { cardRank = CardRank.Seven, cardSymbol = CardSymbol.Clubs };

            int expected = 50;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestFourOfAKind()
        {

            Card[] testCards = new Card[5];

            testCards[0] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Clubs };
            testCards[1] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Diamonds };
            testCards[3] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Hearts };
            testCards[4] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Spades };

            int expected = 25;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestFullHouse()
        {

            Card[] testCards = new Card[5];

            testCards[0] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Clubs };
            testCards[1] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Hearts };
            testCards[3] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Spades };
            testCards[4] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Diamonds };

            int expected = 9;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestFlush()
        {
            Card[] testCards = new Card[5];

            testCards[0] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Clubs };
            testCards[1] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.King, cardSymbol = CardSymbol.Clubs };
            testCards[3] = new Card() { cardRank = CardRank.Ace, cardSymbol = CardSymbol.Clubs };
            testCards[4] = new Card() { cardRank = CardRank.Eight, cardSymbol = CardSymbol.Clubs };

            int expected = 6;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestStraight()
        {
            Card[] testCards = new Card[5];

            testCards[0] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Diamonds };
            testCards[1] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.Four, cardSymbol = CardSymbol.Hearts };
            testCards[3] = new Card() { cardRank = CardRank.Seven, cardSymbol = CardSymbol.Spades };
            testCards[4] = new Card() { cardRank = CardRank.Six, cardSymbol = CardSymbol.Clubs };

            int expected = 4;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestThreeOfAKind()
        {
            Card[] testCards = new Card[5];

            testCards[0] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Diamonds };
            testCards[1] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Hearts };
            testCards[3] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Spades };
            testCards[4] = new Card() { cardRank = CardRank.Six, cardSymbol = CardSymbol.Clubs };

            int expected = 3;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestTwoPair()
        {
            Card[] testCards = new Card[5];

            testCards[0] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Diamonds };
            testCards[1] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Hearts };
            testCards[3] = new Card() { cardRank = CardRank.Seven, cardSymbol = CardSymbol.Spades };
            testCards[4] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Diamonds };

            int expected = 2;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestJackAndUp()
        {
            Card[] testCards = new Card[5];

            testCards[0] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Diamonds };
            testCards[1] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.Four, cardSymbol = CardSymbol.Hearts };
            testCards[3] = new Card() { cardRank = CardRank.King, cardSymbol = CardSymbol.Spades };
            testCards[4] = new Card() { cardRank = CardRank.Six, cardSymbol = CardSymbol.Clubs };

            int expected = 1;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestNoHand()
        {
            Card[] testCards = new Card[5];

            testCards[0] = new Card() { cardRank = CardRank.Five, cardSymbol = CardSymbol.Diamonds };
            testCards[1] = new Card() { cardRank = CardRank.Three, cardSymbol = CardSymbol.Clubs };
            testCards[2] = new Card() { cardRank = CardRank.Two, cardSymbol = CardSymbol.Hearts };
            testCards[3] = new Card() { cardRank = CardRank.Eight, cardSymbol = CardSymbol.Spades };
            testCards[4] = new Card() { cardRank = CardRank.Six, cardSymbol = CardSymbol.Clubs };

            int expected = 0;

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            int actual = scoreCalculator.GetScore(testCards);

            Assert.AreEqual(expected, actual);

        }
    }
}
