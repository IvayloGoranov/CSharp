using System;
using PokerGame.Deck;
using PokerGame.Interfaces;
using PokerGame.HandEvaluation;

namespace PokerGame
{
    public class CardDealer
    {
        private const int NumberOfCardsPerHand = 5;
        
        private Card[] playerHand;
        private Card[] computerHand;
        private Card[] sortedPlayerHand;
        private Card[] sortedComputerHand;

        public CardDealer(IDeckOfCards deckOfCards)
        {
            this.playerHand = new Card[NumberOfCardsPerHand];
            this.computerHand = new Card[NumberOfCardsPerHand];
            this.sortedPlayerHand = new Card[NumberOfCardsPerHand];
            this.sortedComputerHand = new Card[NumberOfCardsPerHand];
            this.DeckOfCards = deckOfCards;
        }

        public IDeckOfCards DeckOfCards { get; set; }

        public void DealCards()
        {
            this.GetPlayersHands();
            this.SortPlayersHands();
            this.DisplayCards();
            this.EvaluateWinnigHand();
        }

        private void GetPlayersHands()
        {
            for (int i = 0, j = 0; i < NumberOfCardsPerHand; i++, j = j + 2)
            {
                this.playerHand[i] = this.DeckOfCards.GetDeck[j];
                this.computerHand[i] = this.DeckOfCards.GetDeck[i + 1];
            }
        }

        private void SortPlayersHands()
        {
            for (int i = 0; i < NumberOfCardsPerHand; i++)
            {
                this.sortedPlayerHand[i] = this.playerHand[i];
            }

            for (int i = 0; i < NumberOfCardsPerHand; i++)
            {
                this.sortedComputerHand[i] = this.computerHand[i];
            }

            Array.Sort(this.sortedPlayerHand);
            Array.Sort(this.sortedComputerHand);
        }

        private void DisplayCards()
        {
            throw new NotImplementedException();
        }

        private void EvaluateWinnigHand()
        {
            HandEvaluator playerHandEvaluator = new HandEvaluator(sortedPlayerHand);
            HandEvaluator computerHandEvaluator = new HandEvaluator(sortedComputerHand);

            //get the player;s and computer's hand
            HandType playerHand = playerHandEvaluator.EvaluateHand();
            HandType computerHand = computerHandEvaluator.EvaluateHand();

            //display each hand
            Console.WriteLine("\n\n\n\n\nPlayer's Hand: " + playerHand);
            Console.WriteLine("\nComputer's Hand: " + computerHand);

            //evaluate hands
            if (playerHand > computerHand)
            {
                Console.WriteLine("Player WINS!");
            }
            else if (playerHand < computerHand)
            {
                Console.WriteLine("Computer WINS!");
            }
            else //if the hands are the same, evaluate the values
            {
                //first evaluate who has higher value of poker hand
                if (playerHandEvaluator.HandValue.TotalValue > computerHandEvaluator.HandValue.TotalValue)
                {
                    Console.WriteLine("Player WINS!");
                }
                else if (playerHandEvaluator.HandValue.TotalValue < computerHandEvaluator.HandValue.TotalValue)
                {
                    Console.WriteLine("Computer WINS!");
                }
                //if both have the same poker hand (for example, both have a pair of queens), 
                //than the player with the next higher card wins
                else if (playerHandEvaluator.HandValue.HighCardValue > computerHandEvaluator.HandValue.HighCardValue)
                {
                    Console.WriteLine("Player WINS!");
                }
                else if (playerHandEvaluator.HandValue.HighCardValue < computerHandEvaluator.HandValue.HighCardValue)
                {
                    Console.WriteLine("Computer WINS!");
                }
                else
                {
                    Console.WriteLine("DRAW, no one wins!");
                }
            }
        }
    }
}
