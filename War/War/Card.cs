using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades };
    public enum Face { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
    public class Card
    {
        public Suit suit { get; set; }
        public Face face { get; set; }
        public override string ToString()
        {
            return face + " of " + suit;
        }
    }
}
