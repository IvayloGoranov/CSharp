using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingValidation
{
    public partial class MainWindow : Window
    {
        private Customer customer = new Customer() 
        {
            Name = "Bay Ivan" ,
            EGN = "3807031764",
            DOB = DateTime.Now.AddYears(-70),
            Code = 1234
        };

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this.customer;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(this.textBoxName))
            {
                var errors = Validation.GetErrors(this.textBoxName);
                string errorMsg = (string)errors[0].ErrorContent;
                MessageBox.Show(errorMsg, "Error");
                return;
            }
            if (Validation.GetHasError(this.textBoxEGN))
            {
                var errors = Validation.GetErrors(this.textBoxEGN);
                string errorMsg = (string)errors[0].ErrorContent;
                MessageBox.Show(errorMsg, "Error");
                return;
            } 
            if (Validation.GetHasError(this.textBoxDOB))
            {
                var errors = Validation.GetErrors(this.textBoxDOB);
                string errorMsg = (string)errors[0].ErrorContent;
                MessageBox.Show(errorMsg, "Error");
                return;
            }
            if (Validation.GetHasError(this.textBoxCode))
            {
                var errors = Validation.GetErrors(this.textBoxCode);
                string errorMsg = (string)errors[0].ErrorContent;
                MessageBox.Show(errorMsg, "Error");
                return;
            }

            string customerInfo =
                "Customer data is valid.\n\n" +
                "Customer Name: " + this.customer.Name + "\n" +
                "Customer EGN: " + this.customer.EGN + "\n" +
                "Customer Date: " + this.customer.DOB.ToString("d/M/yyyy") + "\n" +
                "Customer Code: " + this.customer.Code;
            MessageBox.Show(customerInfo, "Info");
        }
    }
}
