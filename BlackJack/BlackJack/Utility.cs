using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackMessages;

namespace BlackJack
{
    public enum RoundResult { PlayerBlackJack, DealerBlackJack, Won, Lost, Tied, Surrendered, Busted, DealerBusts, Split, Unknown };
    public class Utility
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

        public Card GetRandomCard(int randomInt, ref List<Card> deck)
        {
            var card = deck[randomInt];
            deck.Remove(card);
            return card;
        }

        public void CheckForDealerShowingAce(List<Card> dealerCards, ref bool boughtInsurance, Hand playerHand, Hand dealerHand, double betAmount, ref double walletAmount)
        {
            if (dealerCards[1].face == Face.Ace)
            {
                boughtInsurance = playerHand.Insurance();
                if (boughtInsurance == true)
                {
                    walletAmount -= betAmount;
                    if (dealerHand.Points(dealerCards) == 21)
                    {
                        walletAmount += betAmount * 2;
                    }
                }
            }
        }

        public void CheckForAnyoneHavingBlackJack(Hand playerHand, Hand dealerHand, List<Card> playerCards, List<Card> dealerCards, ref RoundResult roundResult, ref bool continueHand)
        {
            if (playerHand.CheckIfThereWasABlackJack(playerHand, dealerHand, playerCards, dealerCards))
            {
                if ((playerHand.Points(playerCards) == 21) && (dealerHand.Points(dealerCards) != 21))
                {
                    roundResult = RoundResult.PlayerBlackJack;
                }
                else if ((dealerHand.Points(dealerCards) == 21) && (playerHand.Points(playerCards) != 21))
                {
                    roundResult = RoundResult.DealerBlackJack;
                }
                else
                {
                    roundResult = RoundResult.Tied;
                }
                continueHand = false;
            }
        }

        public void CheckIfSurrenderSituation(Hand playerHand, Hand dealerHand, List<Card> playerCards, List<Card> dealerCards, ref RoundResult roundResult, ref bool surrendered)
        {
            if (((dealerCards[1].face == Face.Ace) || (dealerCards[1].face == Face.King) || (dealerCards[1].face == Face.Queen) || (dealerCards[1].face == Face.Jack) || (dealerCards[1].face == Face.Ten)) && (playerHand.Points(playerCards) == 16) && (roundResult == RoundResult.Unknown) && (playerCards[0].face != Face.Ace) && (playerCards[1].face != Face.Ace))
            {
                surrendered = playerHand.Surrender(dealerCards[1].face.ToString());
                if (surrendered == true)
                {
                    roundResult = RoundResult.Surrendered;
                }
            }
        }

        public void CheckIfSplitHandSituation(ref List<Card> deck, ref List<Card> playerCards, ref List<Card> playerCardsSplit, Hand playerHand, ref bool splitHand, double betAmount, ref double walletAmount, Random random, RoundResult roundResult)
        {
            if ((playerCards[0].face == playerCards[1].face) && playerCards[0].face != Face.Ten && playerCards[0].face != Face.Jack && playerCards[0].face != Face.Queen && playerCards[0].face != Face.King && roundResult == RoundResult.Unknown)
            {
                splitHand = playerHand.SplitTheHand(playerCards[0].face.ToString());
                if (splitHand == true)
                {
                    playerCardsSplit.Add(playerCards[1]);
                    playerCards.RemoveAt(1);
                    playerCards.Add(GetRandomCard(random.Next(0, deck.Count), ref deck));
                    playerCardsSplit.Add(GetRandomCard(random.Next(0, deck.Count), ref deck));
                    Message.ChoseToSplitHand(playerCards[1].ToString(), playerCardsSplit[1].ToString());
                    walletAmount -= betAmount;
                }
            }
            if (splitHand == true)
            {
                Message.FirstHand(playerCards[0].ToString(), playerCards[1].ToString());
            }
        }

        public void CheckIfDoubleDownSituation(ref bool doubledDown, ref List<Card> deck, Hand playerHand, ref List<Card> playerCards, ref double walletAmount, ref double betAmount, ref Card nextCard, ref Random random, RoundResult roundResult)
        {
            if ((playerHand.Points(playerCards) == 9 || playerHand.Points(playerCards) == 10 || playerHand.Points(playerCards) == 11) && (roundResult == RoundResult.Unknown))
            {
                doubledDown = playerHand.DoubleDown(playerHand.Points(playerCards));
                if (doubledDown == true)
                {
                    walletAmount -= betAmount;
                    betAmount += betAmount;
                    nextCard = GetRandomCard(random.Next(0, deck.Count), ref deck);
                    playerCards.Add(nextCard);
                    Message.NextCardForPlayerWas(nextCard.ToString());
                    Message.AfterDoublingDown(playerHand.Points(playerCards));
                }
            }
        }

        public void AskPlayerIfWantHit(RoundResult roundResult, bool doubledDown, ref bool continueHand, ref Hand playerHand, ref List<Card> playerCards, List<Card> dealerCards, ref Card nextCard, ref List<Card> deck, ref Random random)
        {
            if (roundResult == RoundResult.Unknown && doubledDown == false)
            {
                continueHand = playerHand.HitMe(playerHand.Points(playerCards), dealerCards[1].ToString());
                while (continueHand == true)
                {
                    nextCard = GetRandomCard(random.Next(0, deck.Count), ref deck);
                    playerCards.Add(nextCard);
                    Message.NextCardForPlayerWas(nextCard.ToString());
                    if (playerHand.Points(playerCards) < 21)
                    {
                        continueHand = playerHand.HitMe(playerHand.Points(playerCards), dealerCards[1].ToString());
                    }
                    if (playerHand.Points(playerCards) >= 21)
                    {
                        continueHand = false;
                    }
                }
                if (playerHand.Points(playerCards) <= 21)
                {
                    Message.ChoseToStand(playerHand.Points(playerCards));
                }
            }
        }

        public void CheckIfPlayerSplitHand(bool splitHand, ref bool doubledDownSplit, ref bool continueHand, ref double walletAmount, ref double splitBetAmount, ref Card nextCard, List<Card> dealerCards, ref List<Card> playerCardsSplit, ref List<Card> deck, ref Hand playerHand, ref Random random, RoundResult roundResultSplit)
        {
            if (splitHand == true)
            {
                Message.SecondHand(playerCardsSplit[0].ToString(), playerCardsSplit[1].ToString());
                if ((playerHand.Points(playerCardsSplit) == 9 || playerHand.Points(playerCardsSplit) == 10 || playerHand.Points(playerCardsSplit) == 11) && roundResultSplit == RoundResult.Unknown)
                {
                    doubledDownSplit = playerHand.DoubleDown(playerHand.Points(playerCardsSplit));
                    if (doubledDownSplit == true)
                    {
                        walletAmount -= splitBetAmount;
                        splitBetAmount += splitBetAmount;
                        nextCard = GetRandomCard(random.Next(0, deck.Count), ref deck);
                        playerCardsSplit.Add(nextCard);
                        Message.NextCardForPlayerWas(nextCard.ToString());
                    }
                }
                if (doubledDownSplit == false)
                {
                    continueHand = playerHand.HitMe(playerHand.Points(playerCardsSplit), dealerCards[1].ToString());
                    while (continueHand == true)
                    {
                        nextCard = GetRandomCard(random.Next(0, deck.Count), ref deck);
                        playerCardsSplit.Add(nextCard);
                        Message.NextCardForPlayerWas(nextCard.ToString());
                        if (playerHand.Points(playerCardsSplit) < 21)
                        {
                            continueHand = playerHand.HitMe(playerHand.Points(playerCardsSplit), dealerCards[1].ToString());
                        }
                        if (playerHand.Points(playerCardsSplit) >= 21)
                        {
                            continueHand = false;
                        }
                    }
                    if (playerHand.Points(playerCardsSplit) <= 21)
                    {
                        Message.ChoseToStand(playerHand.Points(playerCardsSplit));
                    }
                }
            }
        }

        public void DetermineRoundResult(ref RoundResult roundResult, ref RoundResult roundResultSplit, ref Card nextCard, ref Hand playerHand, ref Hand dealerHand, ref List<Card> deck, ref List<Card> playerCards, ref List<Card> playerCardsSplit, ref List<Card> dealerCards, bool splitHand, ref Random random)
        {
            if (playerHand.Points(playerCards) > 21)
            {
                roundResult = RoundResult.Busted;
            }
            if (playerHand.Points(playerCardsSplit) > 21)
            {
                roundResultSplit = RoundResult.Busted;
            }
            if ((playerHand.Points(playerCards) <= 21) && (roundResult == RoundResult.Unknown) || (playerHand.Points(playerCardsSplit) <= 21 && splitHand == true))
            {
                Message.DealerFlipsOverHoleCard(dealerCards[0].ToString(), dealerHand.Points(dealerCards));
                while (dealerHand.Points(dealerCards) < 17)
                {
                    nextCard = GetRandomCard(random.Next(0, deck.Count), ref deck);
                    dealerCards.Add(nextCard);
                    Message.NextCardForDealerWas(nextCard.ToString(), dealerHand.Points(dealerCards));
                }
                if (dealerHand.Points(dealerCards) >= 17 && dealerHand.Points(dealerCards) <= 21)
                {
                    Message.DealerStands(dealerHand.Points(dealerCards).ToString());
                }
                if (playerHand.Points(playerCards) == dealerHand.Points(dealerCards))
                {
                    roundResult = RoundResult.Tied;
                }
                else if (playerHand.Points(playerCards) > dealerHand.Points(dealerCards))
                {
                    roundResult = RoundResult.Won;
                }
                else if (dealerHand.Points(dealerCards) > 21)
                {
                    roundResult = RoundResult.DealerBusts;
                }
                else
                {
                    roundResult = RoundResult.Lost;
                }
            }
        }

        public void AdjustForRoundResultOfHand(RoundResult roundResult, double betAmount, ref double walletAmount, List<Card> dealerCards, List<Card> playerCards, Hand dealerHand, Hand playerHand)
        {
            switch (roundResult)
            {
                case RoundResult.PlayerBlackJack:
                    Message.WonWithABlackJack(2.5 * betAmount);
                    walletAmount += 2.5 * betAmount;
                    break;
                case RoundResult.DealerBlackJack:
                    Message.LostToABlackJack(dealerCards[0].ToString());
                    break;
                case RoundResult.Won:
                    Message.WonHand(playerHand.Points(playerCards), dealerHand.Points(dealerCards), (2 * betAmount));
                    walletAmount += 2 * betAmount;
                    break;
                case RoundResult.Lost:
                    Message.LostHand(playerHand.Points(playerCards), dealerHand.Points(dealerCards));
                    break;
                case RoundResult.Tied:
                    Message.TiedHand(playerHand.Points(playerCards), betAmount);
                    walletAmount += betAmount;
                    break;
                case RoundResult.Surrendered:
                    Message.ChoseToSurrender(.5 * betAmount);
                    walletAmount += .5 * betAmount;
                    break;
                case RoundResult.Busted:
                    Message.YouBusted(playerHand.Points(playerCards));
                    break;
                case RoundResult.DealerBusts:
                    Message.DealerBusted(dealerHand.Points(dealerCards), (2 * betAmount));
                    walletAmount += 2 * betAmount;
                    break;
                case RoundResult.Unknown:
                    break;
                default:
                    break;
            }
        }

        public void DetermineRoundResultSplit(ref RoundResult roundResultSplit, bool splitHand, Hand playerHand, Hand dealerHand, List<Card> playerCardsSplit, List<Card> dealerCards)
        {
            if (splitHand && roundResultSplit != RoundResult.Busted)
            {
                if (playerHand.Points(playerCardsSplit) == dealerHand.Points(dealerCards))
                {
                    roundResultSplit = RoundResult.Tied;
                }
                else if (playerHand.Points(playerCardsSplit) > dealerHand.Points(dealerCards))
                {
                    roundResultSplit = RoundResult.Won;
                }
                else if (dealerHand.Points(dealerCards) > 21)
                {
                    roundResultSplit = RoundResult.DealerBusts;
                }
                else
                {
                    roundResultSplit = RoundResult.Lost;
                }

                Message.ResultOfSplitHand();
            }
        }

        public void AdjustForRoundResultOfSplitHand(RoundResult roundResultSplit, ref double walletAmount, double splitBetAmount, bool splitHand, Hand playerHand, Hand dealerHand, List<Card> playerCardsSplit, List<Card> dealerCards)
        {
            switch (roundResultSplit)
            {
                case RoundResult.Won:
                    Message.WonHand(playerHand.Points(playerCardsSplit), dealerHand.Points(dealerCards), (2 * splitBetAmount));
                    walletAmount += 2 * splitBetAmount;
                    break;
                case RoundResult.Lost:
                    Message.LostHand(playerHand.Points(playerCardsSplit), dealerHand.Points(dealerCards));
                    break;
                case RoundResult.Tied:
                    Message.TiedHand(playerHand.Points(playerCardsSplit), splitBetAmount);
                    walletAmount += splitBetAmount;
                    break;
                case RoundResult.Busted:
                    Message.YouBusted(playerHand.Points(playerCardsSplit));
                    break;
                case RoundResult.DealerBusts:
                    Message.DealerBusted(dealerHand.Points(dealerCards), (2 * splitBetAmount));
                    walletAmount += 2 * splitBetAmount;
                    break;
                case RoundResult.Unknown:
                    break;
                default:
                    break;
            }
        }
    }
}
