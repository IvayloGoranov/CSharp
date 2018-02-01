using System.Collections.Generic;
using System;

namespace DOMBuilder
{
    public class DOMElement
    {
        private ICollection<DOMElement> subelements;
        
        public DOMElement(string type, params DOMElement[] elements)
        {
            this.Type = type;
            this.subelements = new List<DOMElement>();
            if (elements.Length > 0)
            {
                this.Add(elements);
            }
        }

        public string Type { get; set; }

        public virtual void Add(params DOMElement[] subelements)
        {
            foreach (DOMElement element in subelements)
            {
                if (element != null)
                {
                    this.subelements.Add(element);
                }
            }
        }

        public virtual void Remove(DOMElement element)
        {
            this.subelements.Remove(element);
        }

        public virtual void Display(int depth = 1)
        {
            Console.WriteLine(new string(' ', depth) + "<" + this.ToString() + ">");

            foreach (var element in this.subelements)
            {
                element.Display(depth + 2);
            }

            Console.WriteLine(new string(' ', depth) + "</" + this.ToString() + ">");
        }

        public override string ToString()
        {
            string output = string.Format("{0}", this.Type);
            
            return output;
        }
    }
}
