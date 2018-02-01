using Exporter.Interfaces;
using Exporter.Layouts;
using Exporter.Appenders;
using System.Data;
using System.Windows.Forms;

namespace Exporter
{
    public class FileExporterMain
    {
        static void Main()
        {
            ILayout dataGridToPdfLayout = new SimpleDataGridViewToPDFLayout();
            string folderPath = "C:\\PDFs\\";

            IFileAppender fileAppender = new PDFAppender(folderPath, dataGridToPdfLayout);

            FileExporter fileExporter = new FileExporter(fileAppender);

            DataGridView dataGridView = CreateDataGridView();

            fileExporter.Export(dataGridView);
        }

        private static DataGridView CreateDataGridView()
        {
            // Make the DataTable object.
            DataTable dataTable = new DataTable("People");

            // Add columns to the DataTable.
            dataTable.Columns.Add("First Name",
                System.Type.GetType("System.String"));
            dataTable.Columns.Add("Last Name",
                System.Type.GetType("System.String"));
            dataTable.Columns.Add("Occupation",
                System.Type.GetType("System.String"));
            dataTable.Columns.Add("Salary",
                System.Type.GetType("System.Int32"));

            // Make all columns required.
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].AllowDBNull = false;
            }

            // Make First Name + Last Name require uniqueness.
            DataColumn[] unique_cols = 
            {
                dataTable.Columns["First Name"],
                dataTable.Columns["Last Name"]
            };
            dataTable.Constraints.Add(new UniqueConstraint(unique_cols));

            // Add items to the table.
            dataTable.Rows.Add(new object[] { "Rod", "Stephens", "Nerd", 10000 });
            dataTable.Rows.Add(new object[] { "Sergio", "Aragones", "Cartoonist", 20000 });
            dataTable.Rows.Add(new object[] { "Eoin", "Colfer", "Author", 30000 });
            dataTable.Rows.Add(new object[] { "Terry", "Pratchett", "Author", 40000 });

            // Make the DataGridView use the DataTable as its data source.
            DataGridView dataGridView = new DataGridView();
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = dataTable;

            return dataGridView;
        }
    }
}
