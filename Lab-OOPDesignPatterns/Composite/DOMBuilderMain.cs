using System;

namespace DOMBuilder
{
    public class DOMBuilderMain
    {
        static void Main()
        {
            DOMElement html =
                    new DOMElement("html",
                        new DOMElement("head"),
                        new DOMElement("body",
                            new DOMElement("section",
                                new DOMElement("h2"),
                                new DOMElement("p"),
                                new DOMElement("span")),
                            new DOMElement("footer")));

            html.Display();
        }
    }
}
