using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War;
using Messages;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var action = new Actions();
            var PlayerName = action.GetPlayerName();
            Message.ExplainTheRules(PlayerName);
            var deckBuilder = new DeckBuilder();
            var deck = deckBuilder.CreateDeck();
            var myCards = new List<Card>();
            var playerCards = new List<Card>();
            deckBuilder.DealDeckRandomly(ref deck, ref myCards, ref playerCards);
            Message.DeckIsShuffled(PlayerName);
            var roundResult = new RoundResult();
            var roundCounter = 0;
            while ((myCards.Count > 0) && (playerCards.Count > 0))
            {
                roundCounter += 1;
                Message.DisplayTopCards(myCards[0].ToString(), playerCards[0].ToString());
                roundResult = action.FlipTopCardsOver(PlayerName, ref myCards, ref playerCards, ref deck);
                if ((roundResult == RoundResult.RyanWins) || (roundResult == RoundResult.PlayerWins))
                {
                    action.GiveWinnerTheirCards(roundResult, ref myCards, ref playerCards, ref deck);
                }
                while (roundResult == RoundResult.WarIsDeclard)
                {
                    var warResult = action.GetWarResult(PlayerName, myCards, playerCards);
                    if ((warResult == WarResult.RyanWins) || (warResult == WarResult.PlayerWins) || (warResult == WarResult.WarIsDeclaredAgain))
                    {
                        action.FalloutFromWar(ref myCards, ref playerCards, ref deck, warResult, ref roundResult);
                    }
                    else

                    {
                        action.SomeoneLacksFourCards(ref myCards, ref playerCards, ref deck, warResult, ref roundResult);
                    }
                }
                Message.CardCount(myCards.Count, playerCards.Count, roundCounter);
                
            }
            action.GameIsOver(PlayerName, roundCounter, myCards, playerCards);
            Console.ReadLine();
        }
    }
}
