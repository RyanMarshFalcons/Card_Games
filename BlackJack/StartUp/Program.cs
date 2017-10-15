using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack;
using BlackJackMessages;


namespace StartUp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Message.Welcome();
            var utility = new Utility();
            var walletAmount = 250.00;
            while ((walletAmount >= 5) && (walletAmount < 500))
            {
                var bet = new Bet();
                Message.PlaceBet(walletAmount);
                var betAmount = bet.GetValidBet(walletAmount);
                var splitBetAmount = betAmount;
                walletAmount -= betAmount;
                var deck = utility.CreateDeck();
                var random = new Random();
                var playerCards = new List<Card>() { utility.GetRandomCard(random.Next(0, deck.Count), ref deck), utility.GetRandomCard(random.Next(0, deck.Count), ref deck) };
                var dealerCards = new List<Card>() { utility.GetRandomCard(random.Next(0, deck.Count), ref deck), utility.GetRandomCard(random.Next(0, deck.Count), ref deck) };
                var playerCardsSplit = new List<Card>();
                var roundResult = RoundResult.Unknown;
                var roundResultSplit = RoundResult.Unknown;
                var playerHand = new Hand();
                var dealerHand = new Hand();
                var nextCard = new Card();
                Message.DealtCards(playerCards[0].ToString(), playerCards[1].ToString(), dealerCards[1].ToString());
                var boughtInsurance = false;
                var surrendered = false;
                var doubledDown = false;
                var splitHand = false;
                var doubledDownSplit = false;
                var continueHand = true;
                utility.CheckForDealerShowingAce(dealerCards, ref boughtInsurance, playerHand, dealerHand, betAmount, ref walletAmount);
                utility.CheckForAnyoneHavingBlackJack(playerHand, dealerHand, playerCards, dealerCards, ref roundResult, ref continueHand);
                utility.CheckIfSurrenderSituation(playerHand, dealerHand, playerCards, dealerCards, ref roundResult, ref surrendered);
                utility.CheckIfSplitHandSituation(ref deck, ref playerCards, ref playerCardsSplit, playerHand, ref splitHand, betAmount, ref walletAmount, random, roundResult);
                utility.CheckIfDoubleDownSituation(ref doubledDown, ref deck, playerHand, ref playerCards, ref walletAmount, ref betAmount, ref nextCard, ref random, roundResult);
                utility.AskPlayerIfWantHit(roundResult, doubledDown, ref continueHand, ref playerHand, ref playerCards, dealerCards, ref nextCard, ref deck, ref random);
                utility.CheckIfPlayerSplitHand(splitHand, ref doubledDownSplit, ref continueHand, ref walletAmount, ref splitBetAmount, ref nextCard, dealerCards, ref playerCardsSplit, ref deck, ref playerHand, ref random, roundResultSplit);
                utility.DetermineRoundResult(ref roundResult, ref roundResultSplit, ref nextCard, ref playerHand, ref dealerHand, ref deck, ref playerCards, ref playerCardsSplit, ref dealerCards, splitHand, ref random);
                utility.AdjustForRoundResultOfHand(roundResult, betAmount, ref walletAmount, dealerCards, playerCards, dealerHand, playerHand);
                utility.DetermineRoundResultSplit(ref roundResultSplit, splitHand, playerHand, dealerHand, playerCardsSplit, dealerCards);
                utility.AdjustForRoundResultOfSplitHand(roundResultSplit, ref walletAmount, splitBetAmount, splitHand, playerHand, dealerHand, playerCardsSplit, dealerCards);
            }
            if (walletAmount < 5)
            {
                Message.WentBroke(walletAmount);
            }
            else
            {
                Message.Reached500(walletAmount);
            }
            Console.ReadLine();
        }
    }
}
