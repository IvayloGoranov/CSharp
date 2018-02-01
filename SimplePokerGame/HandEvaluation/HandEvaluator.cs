using PokerGame.Deck;

namespace PokerGame.HandEvaluation
{
    public class HandEvaluator
    {
        private const int NumberOfCardsInDeck = 52;
        
        private int heartsSum;
        private int clubsSum;
        private int diamondsSum;
        private int spadesSum;
        private Card[] cards; //5 cards in hand.
        private HandValue handValue;
        
        public HandEvaluator(Card[] sortedHand)
        {
            this.heartsSum = 0;
            this.clubsSum = 0;
            this.diamondsSum = 0;
            this.spadesSum = 0;
            this.cards = sortedHand;
            this.handValue = new HandValue();
        }

        public HandValue HandValue { get { return this.handValue; } }
        //public Card[] HandCards { get; set; }

        public HandType EvaluateHand()
        {
            this.GetSuitCountPerHand();

            if (this.IsOnePair())
            {
                return HandType.Pair;
            }
            else if (this.IsTwoPairs())
            {
                return HandType.TwoPairs;
            }
            else if (this.IsThreeOfAKind())
            {
                return HandType.ThreeOfAKind;
            }
            else if (this.IsStraight())
            {
                return HandType.Straight;
            }
            else if (this.IsFlush())
            {
                return HandType.Flush;
            }
            else if (this.IsFullHouse())
            {
                return HandType.FullHouse;
            }
            else if (this.IsFourOfAKind())
            {
                return HandType.FourOfAKind;
            }
            else if (this.IsStraightFlush())
            {
                return HandType.StraightFlush;
            }
            else
            {
                this.handValue.HighCardValue = (int)this.cards[4].CardValue; //High card wins.
                return HandType.Nothing;
            }
        }

        private void GetSuitCountPerHand()
        {
            foreach (var card in this.cards)
            {
                if (card.CardSuit == CardSuit.Hearts)
                {
                    this.heartsSum++;
                }
                else if (card.CardSuit == CardSuit.Clubs)
                {
                    this.clubsSum++;
                }
                else if (card.CardSuit == CardSuit.Diamonds)
                {
                    this.diamondsSum++;
                }
                else if (card.CardSuit == CardSuit.Spades)
                {
                    this.spadesSum++;
                }
            }
        }

        private bool IsFourOfAKind()
        {
            bool isFourOfAKind = false;
            
            //First four cards are the same.
            if (this.cards[0].CardValue == this.cards[1].CardValue && this.cards[0].CardValue == this.cards[2].CardValue &&
                this.cards[0].CardValue == this.cards[3].CardValue)
            {
                this.handValue.TotalValue = (int)this.cards[0].CardValue * 4;
                this.handValue.HighCardValue = (int)this.cards[4].CardValue;
                isFourOfAKind = true;
            }
            //Last four cards are the same.
            else if(this.cards[1].CardValue == this.cards[2].CardValue && this.cards[1].CardValue == this.cards[3].CardValue &&
                this.cards[1].CardValue == this.cards[4].CardValue)
            {
                this.handValue.TotalValue = (int)this.cards[1].CardValue * 4;
                this.handValue.HighCardValue = (int)this.cards[0].CardValue;
                isFourOfAKind = true;
            }

            return isFourOfAKind;
        }

        private bool IsFullHouse()
        {
            bool isFullHouse = false;
            bool isThreeOfAkindAndPair = this.cards[0].CardValue == this.cards[1].CardValue && 
                this.cards[0].CardValue == this.cards[2].CardValue 
                && this.cards[3].CardValue == this.cards[4].CardValue;
            bool isPairAndThreeOfAKind = this.cards[0].CardValue == this.cards[1].CardValue &&
                this.cards[2].CardValue == this.cards[3].CardValue && 
                this.cards[2].CardValue == this.cards[4].CardValue;

            if (isThreeOfAkindAndPair || isPairAndThreeOfAKind)
            {
                this.handValue.TotalValue = (int)this.cards[0].CardValue + (int)this.cards[1].CardValue +
                    (int)this.cards[2].CardValue + (int)this.cards[3].CardValue + (int)this.cards[4].CardValue; 
                isFullHouse = true;
            }
            
            return isFullHouse;
        }

        private bool IsFlush()
        {
            bool isFlush = false;
            if (this.heartsSum == 5 || this.spadesSum == 5 || this.diamondsSum == 5 || this.clubsSum == 5)
            {
                //If more than one player has flush, the player with highest card wins.
                this.handValue.TotalValue = (int)this.cards[4].CardValue;
                isFlush = true;
            }

            return isFlush;
        }

        private bool IsStraight()
        {
            bool isStraight = false;
            if (this.cards[0].CardValue + 1 == this.cards[1].CardValue && 
                this.cards[1].CardValue + 1 == this.cards[2].CardValue && 
                this.cards[2].CardValue + 1 == this.cards[3].CardValue &&
                this.cards[3].CardValue + 1 == this.cards[4].CardValue)
            {
                //If more than one player has straight, the player with highest card wins.
                this.handValue.TotalValue = (int)this.cards[4].CardValue;
                isStraight = true;
            }

            return isStraight;
        }

        private bool IsThreeOfAKind()
        {
            bool isThreeOfAKind = false;
            bool areFirstThreeCardsSame = this.cards[0].CardValue == this.cards[1].CardValue
                && this.cards[0].CardValue == this.cards[2].CardValue;
            bool areMiddleThreeCardsSame = this.cards[1].CardValue == this.cards[2].CardValue 
                && this.cards[1].CardValue == this.cards[3].CardValue;
            
            //First three cards are the same.
            if (areFirstThreeCardsSame || areMiddleThreeCardsSame)
            {
                this.handValue.TotalValue = (int)this.cards[2].CardValue * 3;
                this.handValue.HighCardValue = (int)this.cards[4].CardValue;
                isThreeOfAKind = true;
            }
            //Last three cards are the same.
            else if (this.cards[2].CardValue == this.cards[3].CardValue && this.cards[2].CardValue == this.cards[4].CardValue)
            {
                this.handValue.TotalValue = (int)this.cards[2].CardValue * 3;
                this.handValue.HighCardValue = (int)this.cards[1].CardValue;
                isThreeOfAKind = true;
            }
            
            return isThreeOfAKind;
        }

        private bool IsTwoPairs()
        {
            //With two pairs second card will always be part of first pair
            //and fourth card will always be part of second pair.
            
            bool isTwoPairs = false;
            //First and second card form one pair, third and fourth card - another pair.
            if (this.cards[0].CardValue == this.cards[1].CardValue && this.cards[2].CardValue == this.cards[3].CardValue)
            {
                this.handValue.TotalValue = ((int)this.cards[0].CardValue * 2) + ((int)this.cards[2].CardValue * 2);
                this.handValue.HighCardValue = (int)this.cards[4].CardValue;
                isTwoPairs = true;
            }
            //First and second card form one pair, last two cards - another pair.
            else if (this.cards[0].CardValue == this.cards[1].CardValue && this.cards[3].CardValue == this.cards[4].CardValue)
            {
                this.handValue.TotalValue = ((int)this.cards[0].CardValue * 2) + ((int)this.cards[3].CardValue * 2);
                this.handValue.HighCardValue = (int)this.cards[2].CardValue;
                isTwoPairs = true;
            }
            //Second and third card form one pair, last two cards - another pair.
            else if (this.cards[1].CardValue == this.cards[2].CardValue && this.cards[3].CardValue == this.cards[4].CardValue)
            {
                this.handValue.TotalValue = ((int)this.cards[1].CardValue * 2) + ((int)this.cards[3].CardValue * 2);
                this.handValue.HighCardValue = (int)this.cards[0].CardValue;
                isTwoPairs = true;
            }

            return isTwoPairs;
        }

        private bool IsOnePair()
        {
            bool isOnePair = false;
            //First and second cards form a pair, last card is high card.
            if (this.cards[0].CardValue == this.cards[1].CardValue)
            {
                this.handValue.TotalValue = ((int)this.cards[0].CardValue * 2);
                this.handValue.HighCardValue = (int)this.cards[4].CardValue;
                isOnePair = true;
            }
            //Second and third cards form one pair, last card is high card.
            else if (this.cards[1].CardValue == this.cards[2].CardValue)
            {
                this.handValue.TotalValue = ((int)this.cards[1].CardValue * 2);
                this.handValue.HighCardValue = (int)this.cards[4].CardValue;
                isOnePair = true;
            }
            //Third and fourth cards form one pair, last card is high card.
            else if (this.cards[2].CardValue == this.cards[3].CardValue)
            {
                this.handValue.TotalValue = ((int)this.cards[2].CardValue * 2);
                this.handValue.HighCardValue = (int)this.cards[4].CardValue;
                isOnePair = true;
            }
            //Lats two cards form one pair, third card is high card.
            else if (this.cards[3].CardValue == this.cards[4].CardValue)
            {
                this.handValue.TotalValue = ((int)this.cards[3].CardValue * 2);
                this.handValue.HighCardValue = (int)this.cards[3].CardValue;
                isOnePair = true;
            }

            return isOnePair;
        }

        private bool IsStraightFlush()
        {
            bool isStraightFlush = false;
            bool isStraight = this.cards[0].CardValue + 1 == this.cards[1].CardValue &&
                this.cards[1].CardValue + 1 == this.cards[2].CardValue &&
                this.cards[2].CardValue + 1 == this.cards[3].CardValue &&
                this.cards[3].CardValue + 1 == this.cards[4].CardValue;
            bool isFlush = this.heartsSum == 5 || this.spadesSum == 5 || this.diamondsSum == 5 || this.clubsSum == 5;
            
            if (isFlush && isStraight)
            {
                //If more than one player has straight flush, the player with highest card wins.
                this.handValue.TotalValue = (int)this.cards[4].CardValue;
                isStraightFlush = true;
            }

            return isStraightFlush;
        }
    }
}
