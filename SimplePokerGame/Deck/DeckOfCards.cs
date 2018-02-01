using PokerGame.Interfaces;
using System;

namespace PokerGame.Deck
{
    public class DeckOfCards : IDeckOfCards
    {
        private const int NumberOfCardsInDeck = 52;
        private Card[] deckOfCards;

        private readonly Random randomizer = new Random();

        public DeckOfCards()
        {
            this.deckOfCards = new Card[NumberOfCardsInDeck];
            this.SetUpDeck();
        }

        public Card[] GetDeck { get { return this.deckOfCards; } }

        //Create deck of 52 values: 13 values each with 4 suits.
        private void SetUpDeck()
        {
            int i = 0;
            foreach (CardSuit cardSuit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
                {
                    deckOfCards[i] = new Card() {CardSuit = cardSuit, CardValue = cardValue };
                    i++;
                }
            }

            this.ShuffleDeck();
        }

        //Shuffle deck of cards using FisherYatesShuffle.
        public void ShuffleDeck()
        {
            for (int i = 0; i < NumberOfCardsInDeck; i++)
            {
                int randomIndex = i + this.randomizer.Next(0, NumberOfCardsInDeck - i);
                Card temp = this.deckOfCards[i];
                this.deckOfCards[i] = this.deckOfCards[randomIndex];
                this.deckOfCards[randomIndex] = temp;
            }
        }
    }
}
