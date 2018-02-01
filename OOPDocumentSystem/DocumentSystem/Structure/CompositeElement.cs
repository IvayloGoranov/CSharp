using System.Collections.Generic;
using System.IO;

namespace DocumentSystem
{
    public abstract class CompositeElement : Element
    {
        public CompositeElement()
        {
            this.ChildElements = new List<Element>();
        }

        public CompositeElement(params Element[] elements)
        : this()
        {
            this.AddElement(elements);
        }
        
        public IList<Element> ChildElements { get; private set; }

        public void AddElement(params Element[] elements)
        {
            foreach (Element element in elements)
            {
                if (element != null)
                {
                    this.ChildElements.Add(element);
                }
            }
        }

        public override void RenderHTML(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.RenderHTML(writer);
            }
        }

        public override void RenderText(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.RenderText(writer);
            }
        }
    }
}
