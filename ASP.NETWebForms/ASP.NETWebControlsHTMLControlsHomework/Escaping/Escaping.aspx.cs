using System;
using System.Web.UI;

namespace Escaping
{
    public partial class Escaping : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowTextButton_Click(object sender, EventArgs e)
        {
            string text = this.firstTextBox.Text;
            this.unescapedTextBox.Text = Server.HtmlEncode(text);
        }
    }
}