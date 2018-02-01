using Exporter.Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Windows.Forms;
using System.IO;
using System;

namespace Exporter.Layouts
{
    public class SimpleDataGridViewToPDFLayout : ILayout
    {
        public object Format(object obj)
        {
            DataGridView dataGridView = obj as DataGridView;
            if (dataGridView == null)
            {
                throw new ArgumentException(
                    string.Format("{0} works only with DataGridView objects. Please use appropriate types or change appender.", 
                    this.GetType().Name));
            }

            //Creating iTextSharp Table from the DataGridView tavle
            PdfPTable pdfTable = new PdfPTable(dataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            return pdfTable;
        }
    }
}
