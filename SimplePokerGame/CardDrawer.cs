using PokerGame.Deck;
using System;
using System.Text;

namespace PokerGame
{
    public class CardDrawer
    {
        private const int CardWidth = 10;
        private const int CardOffset = 12;
        
        public static void DrawCardOutline(int xCoordinate, int yCoordinate)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int x = xCoordinate * CardOffset;
            int y = yCoordinate;
            Console.SetCursorPosition(x, y);

            StringBuilder cardOutline = new StringBuilder();
            cardOutline.Append("|" + new string('_', CardWidth) + "|"); //Top edge of the card.

            for (int i = 0; i < CardWidth; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);
                if (i != 9)
                {
                    cardOutline.AppendLine("|" + new string(' ', CardWidth) + "|"); //Left and right edge of the card.
                }
                else
                {
                    cardOutline.AppendLine("|" + new string('_', CardWidth) + "|"); //Bottom edge of the card.
                }
            }

            Console.WriteLine(cardOutline.ToString());
        }

        //Displays suit and value of the card inside the outline
        public static void DrawCardSuitAndValue(Card card, int xCoordinate, int yCoordinate)
        {
            char cardSuit = ' ';
            int x = xCoordinate * CardOffset;
            int y = yCoordinate;

            switch (card.CardSuit)
            { 
                case CardSuit.Hearts:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case CardSuit.Diamonds:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case CardSuit.Clubs:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case CardSuit.Spades:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            //Display the encoded character and value of the card.
            Console.SetCursorPosition(x + 10, y + 25);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.CardValue);
        }
    }
}
