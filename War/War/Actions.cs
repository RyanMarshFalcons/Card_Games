using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;

namespace War
{
    public enum RoundResult { RyanWins, PlayerWins, WarIsDeclard, GameIsOver };
    public enum WarResult { RyanWins, PlayerWins, RyanOutOfCards, PlayerOutOfCards, BothOutOfCards, WarIsDeclaredAgain};
    public class Actions
    {
        public string GetPlayerName()
        {
            var playerName = "";
            Message.AskPlayerName();
            playerName = Console.ReadLine();
            while (playerName.Length == 0)
            {
                Message.AskNameAgain();
                playerName = Console.ReadLine();
            }
            return playerName;
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
                    return 11;
                    break;
                case Face.Queen:
                    return 12;
                    break;
                case Face.King:
                    return 13;
                    break;
                case Face.Ace:
                default:
                    return 14;
                    break;
            }
        }

        public RoundResult FlipTopCardsOver(string playerName, ref List<Card> myCards, ref List<Card> playerCards, ref List<Card> deck)
        {
            var myCard = myCards[0];
            var playerCard = playerCards[0];
            deck.Add(myCards[0]);
            deck.Add(playerCards[0]);
            myCards.RemoveAt(0);
            playerCards.RemoveAt(0);
            if (GetCardValue(deck[0].face) > GetCardValue(deck[1].face))
            {
                Message.MyTopCardWins(playerName, playerCard.ToString(), myCard.ToString());
                return RoundResult.RyanWins;
            }
            if (GetCardValue(deck[0].face) < GetCardValue(deck[1].face))
            {
                Message.PlayersTopCardWins(playerName, playerCard.ToString(), myCard.ToString());
                return RoundResult.PlayerWins;
            }
            else
            {
                Message.GetReadyForWar(playerName, myCard.face.ToString());
                return RoundResult.WarIsDeclard;
            }
        }

        public void GiveWinnerTheirCards(RoundResult roundResult, ref List<Card> myCards, ref List<Card> playerCards, ref List<Card> deck)
        {
            if (roundResult == RoundResult.RyanWins)
            {
                myCards.AddRange(deck);
            }
            else
            {
                playerCards.AddRange(deck);
            }
            deck.Clear();
        }

        public WarResult GetWarResult(string playerName, List<Card> myCards, List<Card> playerCards)
        {
            if ((myCards.Count < 4) || (playerCards.Count < 4))
            {
                return WarUnPlayable(myCards, playerCards);
            }
            else
            {
                return WarPlayable(playerName, myCards, playerCards);
            }
        }

        public WarResult WarUnPlayable(List<Card> myCards, List<Card> playerCards)
        {
            if ((myCards.Count < 4) && (playerCards.Count >= 4))
            {
                return WarResult.RyanOutOfCards;
            }
            else if ((playerCards.Count < 4) && (myCards.Count >= 4))
            {
                return WarResult.PlayerOutOfCards;
            }
            else
            {
                return WarResult.BothOutOfCards;
            }
        }

        public WarResult WarPlayable(string playerName, List<Card> myCards, List<Card> playerCards)
        {
            Message.ThreeCardsFaceDown();
            Message.DisplayTopCards(myCards[3].ToString(), playerCards[3].ToString());
            if ((GetCardValue(myCards[3].face)) > (GetCardValue(playerCards[3].face)))
            {
                Message.IWonAWar(playerName, playerCards[3].ToString(), myCards[3].ToString());
                return WarResult.RyanWins;
            }
            else if ((GetCardValue(playerCards[3].face)) > (GetCardValue(myCards[3].face)))
            {
                Message.PlayerWinsAWar(playerName, playerCards[3].ToString(), myCards[3].ToString());
                return WarResult.PlayerWins;
            }
            else
            {
                Message.AnotherRoundOfWar(playerCards[3].face.ToString());
                return WarResult.WarIsDeclaredAgain;
            }
        }

        public void FalloutFromWar(ref List<Card> myCards, ref List<Card> playerCards, ref List<Card> deck, WarResult warResult, ref RoundResult roundResult)
        {
            for (int i = 0; i < 4; i++)
            {
                deck.Add(myCards[i]);
                deck.Add(playerCards[i]);
            }
            myCards.RemoveRange(0, 4);
            playerCards.RemoveRange(0, 4);

            switch (warResult)
            {
                case WarResult.RyanWins:
                    myCards.AddRange(deck);
                    deck.Clear();
                    roundResult = RoundResult.RyanWins;
                    break;
                case WarResult.PlayerWins:
                    playerCards.AddRange(deck);
                    deck.Clear();
                    roundResult = RoundResult.RyanWins;
                    break;
                case WarResult.WarIsDeclaredAgain:
                    break;
                default:
                    break;
            }
        }

        public void SomeoneLacksFourCards(ref List<Card> myCards, ref List<Card> playerCards, ref List<Card> deck, WarResult warResult, ref RoundResult roundResult)
        {
            switch (warResult)
            {
                case WarResult.RyanOutOfCards:
                    Message.ILackFourCards(myCards.Count, deck.Count);
                    playerCards.AddRange(deck);
                    playerCards.AddRange(myCards);
                    myCards.Clear();
                    deck.Clear();
                    break;
                case WarResult.PlayerOutOfCards:
                    Message.PlayerLacksFourCards(playerCards.Count, deck.Count);
                    myCards.AddRange(deck);
                    myCards.AddRange(playerCards);
                    playerCards.Clear();
                    deck.Clear();
                    break;
                case WarResult.BothOutOfCards:
                    Message.BothOutOfCards(myCards.Count, playerCards.Count);
                    break;
            }
            roundResult = RoundResult.GameIsOver;
        }

        public void GameIsOver(string playerName, int roundNumber, List<Card> myCards, List<Card> playerCards)
        {
            if (myCards.Count > playerCards.Count)
            {
                Message.IWonTheGame(playerName, roundNumber);
            }
            else
            {
                Message.PlayerWinsTheGame(playerName, roundNumber);
            }
        }

    }
}
