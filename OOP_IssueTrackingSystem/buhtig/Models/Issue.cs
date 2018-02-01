using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buhtig.Models
{
    public class Issue
    {
        private const int TitleDefaultLength = 3;
        private const int DescriptionDefaultLength = 5;
        
        private string title;
        private string description;

        public Issue(string title, string description, IssuePriority priority, ICollection<string> tags, User author)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = new HashSet<string>(tags);
            this.Author = author;
            this.Comments = new List<Comment>();
        }
        
        public int Id { get; set; }

        public int MyProperty { get; set; }
        
        public string Title
        {
            get
            {
                return this.title;
            }
            
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The title cannot be empty.");
                }

                if (value.Length < TitleDefaultLength)
                {
                    throw new ArgumentException(string.Format("The title must be at least {0} symbols long", 
                        TitleDefaultLength));
                }

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The description cannot be empty.");
                }

                if (value.Length < DescriptionDefaultLength)
                {
                    throw new ArgumentException(string.Format("The description must be at least {0} symbols long", 
                        DescriptionDefaultLength));
                }
                
                this.description = value;
            }
        }
        
        public IssuePriority Priority { get; private set; }
        
        public ICollection<string> Tags { get; private set; }
        
        public IList<Comment> Comments { get; private set; }

        public User Author { get; private set; }
        
        public override string ToString()
        {
            //PERFORMANCE: Replaced AppendLine() with Environment.NewLine, which is a quicker operation.
            
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}{1}", this.Title, Environment.NewLine);
            output.AppendFormat("Priority: {0}{1}", this.GetPriorityAsString(), Environment.NewLine);
            output.AppendFormat("{0}{1}", this.Description, Environment.NewLine);
            if (this.Tags.Count > 0)
            {
                output.AppendFormat("Tags: {0}", string.Join(",", this.Tags.OrderBy(t => t)));
            }
            
            if (this.Comments.Count > 0)
            {
                output.AppendFormat("{0}", Environment.NewLine);
                output.AppendFormat("Comments:{0}", Environment.NewLine);
                for (int i = 0; i < this.Comments.Count; i++ )
                {
                    if (i == this.Comments.Count - 1)
                    {
                        output.AppendFormat("{0}", this.Comments[i]);
                        break;
                    }
                    
                    output.AppendFormat("{0}{1}", this.Comments[i], Environment.NewLine);
                }
            }

            return output.ToString();
        }

        private string GetPriorityAsString()
        {
            string result = new string('*', (int)this.Priority);

            return result;
            
        }
    }
}
