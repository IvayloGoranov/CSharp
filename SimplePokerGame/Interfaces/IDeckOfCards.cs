using PokerGame.Deck;

namespace PokerGame.Interfaces
{
    public interface IDeckOfCards
    {
        Card[] GetDeck { get; }
        void ShuffleDeck();
    }
}
