using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackMessages;

namespace BlackJack
{
    public class Hand
    {
        public int Points (List<Card> cards)
        {
            var handValue = 0;
            var aceCounter = 0;
            foreach (var card in cards)
            {
                handValue += (GetCardValue(card.face));
                if (card.face == Face.Ace)
                {
                    aceCounter += 1;
                }
            }
            if (handValue > 21)
            {
                if (handValue > 52 && aceCounter == 4)
                {
                    handValue -= 40;
                }
                else if (handValue > 42 && aceCounter >= 3)
                {
                    handValue -= 30;
                }
                else if (handValue > 32 && aceCounter >= 2)
                {
                    handValue -= 20;
                }
                else
                {
                    if (aceCounter >= 1)
                    {
                        handValue -= 10;
                    }
                }
            }
            return handValue;
        }

        public int GetCardValue(Face face)
        {
            switch (face)
            {
                case Face.Two:
                    return 2;
                    break;
                case Face.Three:
                    return 3;
                    break;
                case Face.Four:
                    return 4;
                    break;
                case Face.Five:
                    return 5;
                    break;
                case Face.Six:
                    return 6;
                    break;
                case Face.Seven:
                    return 7;
                    break;
                case Face.Eight:
                    return 8;
                    break;
                case Face.Nine:
                    return 9;
                    break;
                case Face.Ten:
                    return 10;
                    break;
                case Face.Jack:
                    return 10;
                    break;
                case Face.Queen:
                    return 10;
                    break;
                case Face.King:
                    return 10;
                    break;
                case Face.Ace:
                default:
                    return 11;
                    break;
            }
        }

        public bool CheckIfThereWasABlackJack(Hand playerHand, Hand dealerHand, List<Card> playerCards, List<Card> dealerCards)
        {
            return (playerHand.Points(playerCards) == 21 || dealerHand.Points(dealerCards) == 21);
        }

        public bool Insurance()
        {
            Message.PurchaseInsurance();
            return Message.YesOrNo();
        }

        public bool Surrender(string face)
        {
            Message.Surrender(face);
            return Message.YesOrNo();
        }

        public bool SplitTheHand(string face)
        {
            Message.SplitHand(face);
            return Message.YesOrNo();
        }

        public bool DoubleDown(int points)
        {
            Message.DoubleDown(points);
            return Message.YesOrNo();
        }

        public bool HitMe(int points, string dealerCard)
        {
            Message.TakeAnotherCard(points, dealerCard);
            return Message.YesOrNo();
        }
    }
}
