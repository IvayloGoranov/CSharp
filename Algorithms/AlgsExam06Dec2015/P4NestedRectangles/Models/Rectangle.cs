using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4NestedRectangles.Models
{
    public class Rectangle : IComparable<Rectangle>
    {
        private string name;
        public Rectangle(string name, Point topLeft, Point bottomRight)
        {
            this.Name = name;
            this.TopLeftPoint = topLeft;
            this.BottomRightPoint = bottomRight;
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Rectangle Name", "Name should not be empty!");
                }
                value = value.Trim();
                foreach (char letter in value)
                {
                    if (IsValidName(letter) == false)
                    {
                        throw new ArgumentException("Rectangle Name", "Name should contain letters or numbers only!");
                    }
                }
                this.name = value;
            }
        }
        
        public Point TopLeftPoint { get; set; }
        public Point BottomRightPoint { get; set; }

        static bool IsValidName(char letter)
        {
            bool isValidLetter = (char.IsLetter(letter)) || (char.IsNumber(letter));
            return isValidLetter;
        }
        public override string ToString()
        {
            string output = string.Format("{0}", this.Name);
            return output;
        }

        public int CompareTo(Rectangle rectangle)
        {
            if (string.Compare(this.Name, rectangle.Name) == -1)
            {
                return -1;
            }
            else if (string.Compare(this.Name, rectangle.Name) == 0)
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
