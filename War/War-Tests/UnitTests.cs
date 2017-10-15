using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War;
using StartUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace War_Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ReturnsJackOfSpades()
        {
            var expectedResult = "Jack of Spades";

            var card = new Card();
            card.face = Face.Jack;
            card.suit = Suit.Spades;
            var actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsFourOfClubs()
        {
            var expectedResult = "Four of Clubs";

            var card = new Card();
            card.face = Face.Four;
            card.suit = Suit.Clubs;
            var actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsTwoOfHearts()
        {
            var expectedResult = "Two of Hearts";

            var card = new Card();
            card.face = Face.Two;
            card.suit = Suit.Hearts;
            var actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsAceOfSpades()
        {
            var expectedResult = "Ace of Spades";

            var card = new Card();
            card.face = Face.Ace;
            card.suit = Suit.Spades;
            var actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Creates52CardDeck()
        {
            var expectedCount = 52;

            var deckBuilder = new DeckBuilder();
            var deck = deckBuilder.CreateDeck();
            var actualCount = deck.Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void PlayerDealt26Cards()
        {
            var expectedCount = 26;

            var deckBuilder = new DeckBuilder();
            var deck = deckBuilder.CreateDeck();
            var myCards = new List<Card>();
            var playerCards = new List<Card>();
            deckBuilder.DealDeckRandomly(ref deck, ref myCards, ref playerCards);
            var actualCount = playerCards.Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void ImDealt26Cards()
        {
            var expectedCount = 26;

            var deckBuilder = new DeckBuilder();
            var deck = deckBuilder.CreateDeck();
            var myCards = new List<Card>();
            var playerCards = new List<Card>();
            deckBuilder.DealDeckRandomly(ref deck, ref myCards, ref playerCards);
            var actualCount = myCards.Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void ZeroCardsLeftInDeck()
        {
            var expectedCount = 0;

            var deckBuilder = new DeckBuilder();
            var deck = deckBuilder.CreateDeck();
            var myCards = new List<Card>();
            var playerCards = new List<Card>();
            deckBuilder.DealDeckRandomly(ref deck, ref myCards, ref playerCards);
            var actualCount = deck.Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Returns5()
        {
            var expectedResult = 5;

            var action = new Actions();
            var actualResult = action.GetCardValue(Face.Five);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Returns8()
        {
            var expectedResult = 8;

            var action = new Actions();
            var actualResult = action.GetCardValue(Face.Eight);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Returns11()
        {
            var expectedResult = 11;

            var action = new Actions();
            var actualResult = action.GetCardValue(Face.Jack);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Returns14()
        {
            var expectedResult = 14;

            var action = new Actions();
            var actualResult = action.GetCardValue(Face.Ace);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsBothOutOfCards()
        {
            var expectedResult = WarResult.BothOutOfCards;

            var action = new Actions();
            var myCards = new List<Card>();
            var playerCards = new List<Card>();
            var myCard1 = new Card();
            var myCard2 = new Card();
            var playerCard1 = new Card();
            var playerCard2 = new Card();
            myCards.Add(myCard1);
            myCards.Add(myCard2);
            playerCards.Add(playerCard1);
            playerCards.Add(playerCard2);
            var actualResult = action.WarUnPlayable(myCards, playerCards);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnsRyanOutOfCards()
        {
            var expectedResult = WarResult.RyanOutOfCards;

            var action = new Actions();
            var myCards = new List<Card>();
            var playerCards = new List<Card>();
            var playerCard1 = new Card();
            var playerCard2 = new Card();
            var playerCard3 = new Card();
            var playerCard4 = new Card();
            var myCard1 = new Card();
            var myCard2 = new Card();
            myCards.Add(myCard1);
            myCards.Add(myCard2);
            playerCards.Add(playerCard1);
            playerCards.Add(playerCard2);
            playerCards.Add(playerCard3);
            playerCards.Add(playerCard4);

            var actualResult = action.WarUnPlayable(myCards, playerCards);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PlayerOutOfCards()
        {
            var expectedResult = WarResult.PlayerOutOfCards;

            var action = new Actions();
            var myCards = new List<Card>();
            var playerCards = new List<Card>();
            var playerCard1 = new Card();
            var playerCard2 = new Card();
            var myCard1 = new Card();
            var myCard2 = new Card();
            var myCard3 = new Card();
            var myCard4 = new Card();
            myCards.Add(myCard1);
            myCards.Add(myCard2);
            myCards.Add(myCard3);
            myCards.Add(myCard4);
            playerCards.Add(playerCard1);
            playerCards.Add(playerCard2);
            var actualResult = action.WarUnPlayable(myCards, playerCards);

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
