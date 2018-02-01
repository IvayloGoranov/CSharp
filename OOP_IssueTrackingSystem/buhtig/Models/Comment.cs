using System;
using System.Text;

namespace Buhtig.Models
{
    public class Comment
    {
        private const int TextDefaultLength = 2;
        
        string commentText;
    
        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; private set; }

        public string Text
        {
            get
            {
                return this.commentText;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The comment text cannot be empty.");
                }

                if (value.Length < TextDefaultLength)
                {
                    throw new ArgumentException(string.Format("The text must be at least {0} symbols long", TextDefaultLength));
                }

                this.commentText = value;
            }
        }

        public override string ToString()
        {
            //PERFORMANCE: Replaced AppendLine() with Environment.NewLine, which is a quicker operation.
            
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}{1}", this.Text, Environment.NewLine);
            output.AppendFormat("-- {0}", this.Author.Username);

            return output.ToString();
        }
    }
}

