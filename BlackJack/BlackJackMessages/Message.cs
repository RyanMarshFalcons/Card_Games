using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackMessages
{
    public static class Message
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to the BlackJack table at Ryan's Casino. The minimum bet at the table isfive dollars and the maximum bet at the table is fifty dollars. Input your bets as numbers with decimals i.e. to make a bet of seven dollars and twenty five\ncents input 7.25 and to make a bet of thirty dollars just input 30 \nPress enter to continue.");
            Console.ReadLine();
        }

        public static void WentBroke(double walletAmount)
        {
            Console.WriteLine($"\nThe minimum bet at this table is $5.00 and you only have {walletAmount.ToString("C2")} in chips left.\nFarewell friend.");
        }

        public static void Reached500(double walletAmount)
        {
            Console.WriteLine($"\nYou started the day with $250.00 in chips and through skill and dedication you\nnow have {walletAmount.ToString("C2")} in chips. Hats off to you, you're a real pro.");
        }

        public static void PlaceBet(double walletAmount)
        {
            Console.Write($"\nYou currently have {walletAmount.ToString("C2")} in chips on the table. How much would you like to\nbet this hand: ");
        }

        public static void InvalidBet(string input)
        {
            Console.Write($"\n{input} is not a valid bet amount. How much would you like to bet: ");
        }

        public static void NotEnoughFunds(double betAmount, double walletAmount)
        {
            Console.Write($"\nSorry but you can't make a bet of {betAmount.ToString("C2")} since you only have {walletAmount.ToString("C2")} in chips.\nHow much would you like to bet: ");
        }

        public static void BetAboveMaximum (double betAmount)
        {
            Console.Write($"\nSorry but you can't make a bet of {betAmount.ToString("C2")} since the maximum allowable bet is\n$50.00 How much would you like to bet: ");
        }

        public static void BetBelowMinimum(double betAmount)
        {
            Console.Write($"\nSorry but you can't make a bet of {betAmount.ToString("C2")} since the minimum allowable bet is\n$5.00 How much would you like to bet: ");
        }

        public static void DealtCards(string card1, string card2, string dealerCard)
        {
            Console.WriteLine($"\nYou were dealt a {card1} and a {card2}. The dealer is\nshowing a {dealerCard}. Press enter to continue.");
            Console.ReadLine();
        }

        public static void PurchaseInsurance()
        {
            Console.Write("\nThe dealer is showing an ace. Would you like to purchase insurance? y/n: ");
        }

        public static void WonWithABlackJack(double winnings)
        {
            Console.WriteLine($"\nCongratulations you won the hand with a BlackJack!!! You won {winnings.ToString("C2")}!!!\nPress enter to continue.");
            Console.ReadLine();
        }

        public static void LostToABlackJack(string card)
        {
            Console.WriteLine($"\nYikes the dealer is on fire they dealt themselves a {card} which gives\nthem a BlackJack and now the hand is over. Press enter to continue.");
            Console.ReadLine();
        }

        public static void Surrender(string face)
        {
            Console.Write($"\nYou were dealt a hand worth sixteen points and the dealer is showing an a {face}. Would you like to surrender? y/n: ");
        }

        public static void ChoseToSurrender(double winnings)
        {
            Console.WriteLine($"\nYou chose to surrender the hand is over. The dealer returns {winnings.ToString("C2")} to you.");
        }
        public static void SplitHand(string face)
        {
            Console.Write($"\nYou were dealt a pair of {face}s. Would you like to split your two {face}s into\ntwo separate hands and be dealt two additional starting cards? y/n: ");
        }

        public static void ChoseToSplitHand(string playerCard2, string playerCardSplit2)
        {
            Console.WriteLine($"\nAfter splitting your hand up you are dealt two additional cards. A\n{playerCard2} and a {playerCardSplit2} Press enter to continue.");
            Console.ReadLine();
        }

        public static void FirstHand(string playerCard1, string playerCard2)
        {
            Console.WriteLine($"First hand: {playerCard1} and {playerCard2}. Press enter to continue.");
            Console.ReadLine();
        }

        public static void SecondHand(string playerCardSplit1, string playerCardSplit2)
        {
            Console.WriteLine($"\nSecond hand: {playerCardSplit1} and {playerCardSplit2}. Press enter to continue.");
            Console.ReadLine();
        }

        public static void ResultOfSplitHand()
        {
            Console.WriteLine("Earlier in the round you chose to split your pair. Press enter to see what the\nresult of your second hand was.");
            Console.ReadLine();
        }

        public static void DoubleDown(int points)
        {
            Console.Write($"\nThe value of your dealt cards is {points}. Would you like to double down? y/n: ");
        }

        public static void AfterDoublingDown(int points)
        {
            Console.WriteLine($"\nAfter doubling down the value of your hand is {points} and you are forced to stand.\nPress enter to contine.");
            Console.ReadLine();
        }

        public static void TakeAnotherCard(int points, string dealerCard)
        {
            Console.Write($"\nAs of right now your hand is worth {points} points and the dealer is showing a\n{dealerCard}. Would you like to be dealt another card? y/n: ");
        }

        public static void NextCardForPlayerWas(string card)
        {
            Console.WriteLine($"\nThe dealer gives you a {card}. Press enter to continue.");
            Console.ReadLine();
        }

        public static void NextCardForDealerWas(string card, int points)
        {
            Console.WriteLine($"\nThe dealer gives himself a {card}. The dealer's hand is now worth {points}\npoints. Press enter to continue.");
            Console.ReadLine();
        }

        public static void YouBusted(int points)
        {
            Console.WriteLine($"\nYour hand is worth {points} points so you busted. Better luck next time. Press enter\nto continue.");
            Console.ReadLine();
        }

        public static void DealerBusted(int points, double winnings)
        {
            Console.WriteLine($"\nThe dealers hand is worth {points}. Therefore they busted. You won {winnings.ToString("C2")}. Press\nenter to continue.");
            Console.ReadLine();
        }

        public static void ChoseToStand(int playerPoints)
        {
            Console.WriteLine($"\nYou have chosen to stand with a hand worth {playerPoints} points. Press enter to continue.");
            Console.ReadLine();
        }

        public static void DealerFlipsOverHoleCard(string dealerHoleCard, int dealerPoints)
        {
            Console.WriteLine($"The dealer flips over their hole card revealing it to be a {dealerHoleCard}. \nThe dealer's hand is worth {dealerPoints} points. Press enter to continue.");
            Console.ReadLine();
        }

        public static void DealerStands(string dealerPoints)
        {
            Console.WriteLine($"\nThe dealer is forced to stand with a hand worth {dealerPoints} points. Press enter to\ncontinue.");
            Console.ReadLine();
        }
        public static void WonHand(int playerPoints, int dealerPoints, double winnings)
        {
            Console.WriteLine($"\nCongratulations you won the hand. Your hand worth {playerPoints} beats the dealer's hand\nworth {dealerPoints}. You won {winnings.ToString("C2")}. Press enter to continue.");
            Console.ReadLine();
        }

        public static void LostHand(int playerPoints, int dealerPoints)
        {
            Console.WriteLine($"\nYou lost the hand. Your hand worth {playerPoints} loses to the dealer's hand worth {dealerPoints}.\nPress enter to continue.");
            Console.ReadLine();
        }

        public static void TiedHand(int points, double betAmount)
        {
            Console.WriteLine($"\nThe hand was a draw. Both you and the dealer had hands worth {points} points. Your\noriginal bet of {betAmount.ToString("C2")} is returned to you. Press enter to continue.");
            Console.ReadLine();
        }


        public static bool YesOrNo()
        {
            var response = "";
            var validResponse = false;
            bool yesOrNo = false;
            do
            {
                response = Console.ReadLine();
                if (response == "y")
                {
                    yesOrNo = true;
                    validResponse = true;
                }
                else if (response == "n") 
                {
                    yesOrNo = false;
                    validResponse = true;
                }
                else
                {
                    Message.InvalidResponse(response);
                }
            } while (validResponse == false);
            return yesOrNo;
        }

        public static void InvalidResponse(string input)
        {
            Console.Write($"\nI'm sorry but {input} is not a valid response. Please input either y or n\nto procede: ");
        }
    }
}
