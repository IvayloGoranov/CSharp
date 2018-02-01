using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsAndCourses
{
    public partial class StudentsAndCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string firstName = Server.HtmlEncode(this.firstNameTextBox.Text);
            string lastName = Server.HtmlEncode(this.lastNameTextBox.Text);
            string facultyNumber = Server.HtmlEncode(this.facultyNumberTextBox.Text);
            string specialty = this.specialtyDropDownList.SelectedValue;
            string courses = string.Empty;

            foreach (ListItem item in this.coursesListBox.Items)
            {
                if (item.Selected)
                {
                    courses = courses + ", " + item.Text;
                }
            }

            this.resultsLiteral.Text = firstName + Environment.NewLine + lastName + Environment.NewLine +
                facultyNumber + Environment.NewLine + specialty + Environment.NewLine + courses;
        }
    }
}