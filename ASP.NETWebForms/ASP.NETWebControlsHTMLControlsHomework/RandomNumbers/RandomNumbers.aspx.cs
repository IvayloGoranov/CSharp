using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbers
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        private static Random randomizer = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerate_Click(object sender, EventArgs e)
        {
            int firstNumber = int.Parse(this.textFieldFirstNumber.Value);
            int secondNumber = int.Parse(this.textFieldSecondNumber.Value);
            this.textFieldGeneratedNumber.Value = randomizer.Next(firstNumber, secondNumber).ToString();
        }
    }
}