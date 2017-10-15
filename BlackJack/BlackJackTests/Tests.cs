using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUp;
using BlackJack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ReturnsFalseIfBetIsBelowMinimum()
        {
            var expectedResult = false;

            var bet = new Bet();
            var actualResult = bet.IsBetMakable(2.00, 150.00);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsFalseIfBetIsAboveMaximum()
        {
            var expectedResult = false;

            var bet = new Bet();
            var actualResult = bet.IsBetMakable(53.00, 150.00);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsFalseIfInsufficientFunds()
        {
            var expectedResult = false;

            var bet = new Bet();
            var actualResult = bet.IsBetMakable(37.00, 35.00);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsTrueIfBetIsValid()
        {
            var expectedResult = true;

            var bet = new Bet();
            var actualResult = bet.IsBetMakable(40.00, 150.00);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsQueenOfHearts()
        {
            var expectedResult = "Queen of Hearts";

            var card = new Card();
            card.face = Face.Queen;
            card.suit = Suit.Hearts;
            var actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsEight()
        {
            var expectedResult = 8;

            var testCards = new List<Card>();
            var card1 = new Card();
            card1.face = Face.Three;
            card1.suit = Suit.Diamonds;
            var card2 = new Card();
            card2.face = Face.Five;
            card2.suit = Suit.Clubs;
            testCards.Add(card1);
            testCards.Add(card2);

            var hand = new Hand();
            var actualResult = hand.Points(testCards);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsNineteen()
        {
            var expectedResult = 20;

            var testCards = new List<Card>();
            var card1 = new Card();
            card1.face = Face.Two;
            card1.suit = Suit.Diamonds;
            var card2 = new Card();
            card2.face = Face.Seven;
            card2.suit = Suit.Hearts;
            var card3 = new Card();
            card3.face = Face.Ace;
            card3.suit = Suit.Spades;
            testCards.Add(card1);
            testCards.Add(card2);
            testCards.Add(card3);

            var hand = new Hand();
            var actualResult = hand.Points(testCards);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsFourteen()
        {
            var expectedResult = 14;

            var testCards = new List<Card>();
            var card1 = new Card();
            card1.face = Face.Two;
            card1.suit = Suit.Diamonds;
            var card2 = new Card();
            card2.face = Face.Ace;
            card2.suit = Suit.Hearts;
            var card3 = new Card();
            card3.face = Face.Ace;
            card3.suit = Suit.Clubs;
            testCards.Add(card1);
            testCards.Add(card2);
            testCards.Add(card3);

            var hand = new Hand();
            var actualResult = hand.Points(testCards);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsSeven()
        {
            var expectedResult = 7;

            var hand = new Hand();
            var actualResult = hand.GetCardValue(Face.Seven);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsTen()
        {
            var expectedResult = 10;

            var hand = new Hand();
            var actualResult = hand.GetCardValue(Face.Queen);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
