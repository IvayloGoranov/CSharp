using System;

namespace _01.ByTheCake
{
    class ByTheCake
    {
        static void Main()
        {
            Console.WriteLine("Content-type:text/html\r\n\r\n");
            //7. By the Cake: Add Head
            Console.WriteLine("<head>");
            Console.WriteLine("<title>By the Cake</title>");
            Console.WriteLine("<meta charset=\"UTF-8\">");
            Console.WriteLine("<meta name=\"description\" content=\"Buy the cake in By the Cake\">");
            Console.WriteLine("<meta name=\"keywords\" content=\"cakes, buy\">");
            Console.WriteLine("<meta name=\"author\" content=\"Valentin Kolev\">");
            Console.WriteLine("<style>");
            Console.WriteLine("footer p { text-align: center; } pre {background-color: #F94F80;}");
            Console.WriteLine("</style>");
            Console.WriteLine("</head>");
            //1. By the Cake: First Web Site
            Console.WriteLine("<h1>By The Cake</h1>");
            Console.WriteLine("<h2>Enjoy our awesome cakes</h2>");
            Console.WriteLine("<hr/>");

            //2. By the Cake: Add Menu, Add Anchors
            Console.WriteLine("<ul>");
            Console.WriteLine("<li><a href=\"#\">Home</a>");
            Console.WriteLine("<ol>");
            Console.WriteLine("<li><a href=\"#cakes\">Our Cakes</a></li>");
            Console.WriteLine("<li><a href=\"#stores\">Our Stores</li>");
            Console.WriteLine("</ol></li>");
            Console.WriteLine("<li><a href=\"AddCake.exe\">Add Cake</a></li>");
            Console.WriteLine("<li><a href=\"BrowseCakes.exe\">Browse Cakes</a></li>");
            Console.WriteLine("<li><a href=\"#aboutus\">About Us</a></li>");
            Console.WriteLine("</ul>");

            //3. By the Cake: Add Paragraph
            Console.WriteLine("<h2>Home</h2>");
            Console.WriteLine("<h3 id=\"cakes\">Our Cakes</h3>");
            Console.WriteLine("<p><strong><em>Cake</em></strong> is a form of <strong><em>sweet dessert</em></strong> that is typically baked. In its oldest forms, cakes were modifications of breads, but cakes now cover a wide range of preparations that can be simple or elaborate, and that share features with other desserts such as pastries, meringues, custards, and pies.</p>");
            Console.WriteLine("<img src=\"http://wallpapercave.com/wp/63hB3f3.jpg\" width=\"200\"/>");
            Console.WriteLine("<h3 id=\"stores\">Our Stores</h3>");
            Console.WriteLine("<p>Our stores are located in 21 cities all over the world. Come and see what we have for you.</p>");
            Console.WriteLine("<img src=\"https://i.ytimg.com/vi/aryWey6TQF0/maxresdefault.jpg\" width=\"200\"/>");

            //9.By the Cake: Add About Info
            Console.WriteLine("<h3 id=\"aboutus\">About Us</h3>");
            Console.WriteLine("<dl>");
            Console.WriteLine("<dt>By the Cake Ltd.</dt>");
            Console.WriteLine("<dd>Company Name</dd>");
            Console.WriteLine("<dt>John Smith</dt>");
            Console.WriteLine("<dd>Owner</dd>");
            Console.WriteLine("</dl>");

            //8. By the Cake: Add stores Info
            Console.WriteLine("<pre>");
            Console.WriteLine("City: Hong Kong\t\tCity: Salzburg");
            Console.WriteLine("Address: ChoCoLad 18\tAddress: SchokoLeiden 73");
            Console.WriteLine("Phone: +78952804429\tPhone: +49241432990");
            Console.WriteLine("</pre>");

            //6. By the Cake: Add Footer
            Console.WriteLine("<footer>");
            Console.WriteLine("<hr/>");
            Console.WriteLine("<p style=\"text-align:center\">&copy;All Rights Reserved.</p>");
            Console.WriteLine("</footer>");
        }
    }
}
