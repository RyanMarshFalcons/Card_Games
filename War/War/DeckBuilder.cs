using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class DeckBuilder
    {
        public List<Card> CreateDeck()
        {
            var deck = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Face face in Enum.GetValues(typeof(Face)))
                {
                    var card = new Card();
                    card.suit = suit;
                    card.face = face;
                    deck.Add(card);
                }
            }
            return deck;
        }

        public void DealDeckRandomly(ref List<Card> deck, ref List<Card> myCards, ref List<Card> playerCards)
        {
            var random = new Random();
            var randomNumber = 0;
            var card = new Card();
            for (int i = 0; i < 26; i++)
            {
                randomNumber = random.Next(0, deck.Count);
                card = deck[randomNumber];
                myCards.Add(card);
                deck.Remove(card);
                randomNumber = random.Next(0, deck.Count);
                card = deck[randomNumber];
                playerCards.Add(card);
                deck.Remove(card);
            }
        }
    }
}
