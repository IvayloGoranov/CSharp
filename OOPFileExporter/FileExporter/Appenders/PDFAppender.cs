using Exporter.Interfaces;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Exporter.Appenders
{
    public class PDFAppender : FileAppender
    {
        public PDFAppender(string filePath, ILayout layout)
            : base(filePath, layout)
        {
        }

        public override void Append(object obj)
        {
            PdfPTable pdfTable = this.Layout.Format(obj) as PdfPTable;
            
            //Exporting to PDF
            if (!Directory.Exists(this.FilePath))
            {
                Directory.CreateDirectory(this.FilePath);
            }

            using (FileStream stream = new FileStream(this.FilePath + "DataGridViewExport.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }
    }
}
