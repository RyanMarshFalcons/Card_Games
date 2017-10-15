using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackMessages;

namespace BlackJack
{
    public class Bet
    {
        public double GetValidBet(double walletAmount)
        {
            var validInput = false;
            var betAmountAsString = "";
            var betAmount = 0.0;
            do
            {
                betAmountAsString = Console.ReadLine();
                if(Double.TryParse(betAmountAsString, out betAmount))
                {
                    if (IsBetMakable(betAmount, walletAmount))
                    {
                        validInput = true;
                    }
                }
                else
                {
                    Message.InvalidBet(betAmountAsString);
                }
            } while (validInput == false);
            return betAmount;
        }

        public bool IsBetMakable(double betAmount, double walletAmount)
        {
            if (betAmount > walletAmount)
            {
                Message.NotEnoughFunds(betAmount, walletAmount);
                return false;
            }
            else if (betAmount < 5)
            {
                Message.BetBelowMinimum(betAmount);
                return false;
            }
            else if (betAmount > 50)
            {
                Message.BetAboveMaximum(betAmount);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
