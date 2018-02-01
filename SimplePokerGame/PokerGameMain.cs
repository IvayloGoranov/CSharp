using PokerGame.Deck;
namespace PokerGame
{
    class PokerGameMain
    {
        static void Main()
        {
            CardDrawer.DrawCardOutline(0, 0);
            Card card = new Card();
            card.CardSuit = CardSuit.Hearts;
            card.CardValue = CardValue.Ace;
            CardDrawer.DrawCardSuitAndValue(card, 0, 0);
        }
    }
}
