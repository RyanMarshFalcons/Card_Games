using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public static class Message
    {
        public static void AskPlayerName()
        {
            Console.Write("Hello, my name is Ryan. What's your name: ");
        }

        public static void AskNameAgain()
        {
            Console.Write("\nYou must input at least one character in order to have a valid name. Please try again: ");
        }

        public static void ExplainTheRules(string playerName)
        {
            Console.WriteLine($"\nEnough pleasantries {playerName}. Its time to go to War!!!\nPress enter to continue. ");
            Console.ReadLine();
            Console.WriteLine("The rules of War are simple. First we shuffle the deck. Next each of us are \ndealt 26 cards. Then we flip over our cards simultaneously one at a time with\nwhomever having the higher card winning their opponents card. If both of our \ncards are equal we play the next three cards face down and flip over the fourth card and whoever's fourth card is higher wins all ten cards. If our fourth cardsare also equal then we each flip over four more until one of ours is higher or\nsomeone is out of cards. The game is over when one of us has all 52 cards.\nPress enter to continue.");
            Console.ReadLine();
        }

        public static void DeckIsShuffled(string playerName)
        {
            Console.WriteLine($"Okay {playerName} the cards have been dealt. We have 26 cards apiece. \nPress enter to continue.");
            Console.ReadLine();
        }

        public static void DisplayTopCards(string myCard, string playerCard)
        {
            Console.WriteLine($"Ready..........set..........FLIP!!!\nI've got a {myCard} and you've got a {playerCard}. \nPress enter to continue.");
            Console.ReadLine();
        }
        
        public static void PlayersTopCardWins(string playerName, string playerCard, string myCard)
        {
            Console.WriteLine($"Congratulations {playerName} your {playerCard} beats my {myCard}. \nPress enter to continue.");
            Console.ReadLine();
        }

        public static void MyTopCardWins(string playerName, string playerCard, string myCard)
        {
            Console.WriteLine($"Sorry {playerName} but my {myCard} beats your {playerCard}. \nPress enter to continue.");
            Console.ReadLine();
        }

        public static void CardCount(int myCardCount, int playerCardCount, int roundCount)
        {
            Console.WriteLine($"After the conclusion of round number {roundCount} you have {playerCardCount} cards and I have {myCardCount} cards. \nPress enter to continue.");
            Console.ReadLine();
        }

        public static void GetReadyForWar(string playerName, string face)
        {
            Console.WriteLine($"Okay {playerName} we're both showing {face}s. Get ready for War!!!\nPress enter to continue.");
            Console.ReadLine();
        }
        public static void ThreeCardsFaceDown()
        {
            Console.WriteLine("We each place three cards face down.\nPress enter to continue.");
            Console.ReadLine();
        }

        public static void AnotherRoundOfWar(string card)
        {
            Console.WriteLine($"We're both showing a {card}. Get ready for another round of War!!! \nPress enter to continue.");
            Console.ReadLine(); 
        }

        public static void PlayerWinsAWar(string playerName, string playerCard, string myCard)
        {
            Console.WriteLine($"Congratulations {playerName} your {playerCard} beat my {myCard}!!!\nYou won the round of War!!!\nPress enter to continue.");
            Console.ReadLine(); 
        }

        public static void IWonAWar(string playerName, string playerCard, string myCard)
        {
            Console.WriteLine($"Sorry {playerName} but my {myCard} beat your {playerCard} so I won the\nround of War!!!\nPress enter to continue.");
            Console.ReadLine();
        }
        public static void ILackFourCards(int myCardCount, int deckCount)
        {
            Console.WriteLine($"I need 4 cards to partake in this round of war and I only have {myCardCount} cards.\nI'm forced to surrender my remaining {myCardCount} cards to you as well as the {deckCount} cards\nthat were at stake in this War.\nPress enter to continue.");
            Console.ReadLine();
        }

        public static void PlayerLacksFourCards(int playerCardCount, int deckCount)
        {
            Console.WriteLine($"You need 4 cards to partake in this round of war and you only have {playerCardCount} cards.\nYou're forced to surrender your remaining {playerCardCount} cards to me as well as the {deckCount} cards\nthat were at stake in this War.\nPress enter to continue.");
            Console.ReadLine();
        }
        public static void BothOutOfCards(int myCardCount, int playerCardCount)
        {
            Console.WriteLine($"I have {myCardCount} cards and you have {playerCardCount}. Therefore we both lack the 4 cards necessary to partake in this war.\nPress enter to continue.");
            Console.ReadLine();
        }

        public static void PlayerWinsTheGame(string playerName, int rounds)
        {
            Console.WriteLine($"Congratulations {playerName}!!!! After {rounds} rounds of combat you have\nbested me and taken control of all 52 cards. You've won the game!!!\nPress enter to continue.");
            Console.ReadLine();
        }

        public static void IWonTheGame(string playerName, int rounds)
        {
            Console.WriteLine($"Well {playerName} its been fun. But after {rounds} rounds of combat I've\nbested you and taken control of all 52 cards. You've lost the game.\nPress enter to continue.");
            Console.ReadLine();
        }
    }
}
