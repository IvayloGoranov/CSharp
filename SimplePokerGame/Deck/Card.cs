
using System;
namespace PokerGame.Deck
{
    public class Card : IComparable
    {
        public CardSuit CardSuit { get; set; }
        public CardValue CardValue { get; set; }

        public int CompareTo(Card obj)
        {
            if ((int)this.CardValue < (int)obj.CardValue)
            {
                return -1;
            }
            else if ((int)this.CardValue == (int)obj.CardValue)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
