using System;
using System.IO;

namespace DocumentSystem
{
    public class DocumentSystemMain
    {
        static void Main()
        {
            Document doc = new Document();
            doc.Title = "My first Document.";
            doc.Author = "Goranov";
            doc.AddElement(new Paragraph("I am a paragraph!"));
            doc.AddElement(new Hyperlink("http://www.softuni.bg", "www.softuni.bg"));
            doc.AddElement(new Paragraph("I am another paragraph!"));

            Paragraph paragraph = new Paragraph();
            paragraph.AddElement(new TextElement("Default Font", Font.DefaultFont));
            paragraph.AddElement(new TextElement(" "));
            paragraph.AddElement(new TextElement("Second Red", new Font(color : Color.Red)));
            paragraph.AddElement(new TextElement("Green Italic", new Font(fontStyle: FontStyle.Italic, color: Color.Red)));
            paragraph.AddElement(new Paragraph());
            paragraph.AddElement(new TextElement("Consolas Green Italic", 
                new Font(name: "Consolas", fontStyle: FontStyle.BoldItalic, color: Color.Green)));
            doc.AddElement(paragraph);
            doc.AddElement(new Heading("Heading 2<br>", 2));
            doc.AddElement(Image.CreateFromFile("image.JPG"));

            doc.RenderHTML(Console.Out);
            Console.WriteLine();

            File.WriteAllText("document.html", doc.AsHTML);

            //Console.WriteLine(doc.AsHTML);

            Console.WriteLine(doc.AsText);
        }
    }
}
