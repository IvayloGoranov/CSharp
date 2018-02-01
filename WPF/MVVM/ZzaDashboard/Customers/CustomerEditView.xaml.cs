using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    public partial class CustomerEditView : UserControl
    {
        //public static readonly DependencyProperty CustomerIdProperty =
        //    DependencyProperty.Register("CustomerId", typeof(Guid), typeof(CustomerEditView), 
        //        new PropertyMetadata(Guid.Empty));

        //private ICustomersRepository repository = new CustomersRepository();
        //private Customer customer = null;

        public CustomerEditView()
        {
            this.InitializeComponent();
        }

        //public Guid CustomerId
        //{
        //    get
        //    {
        //        return (Guid)this.GetValue(CustomerIdProperty);
        //    }

        //    set
        //    {
        //        this.SetValue(CustomerIdProperty, value);
        //    }
        //}

        //private async void OnLoaded(object sender, RoutedEventArgs e)
        //{
        //    if (DesignerProperties.GetIsInDesignMode(this))
        //    {
        //        return;
        //    }

        //    this.customer = await repository.GetCustomerAsync(CustomerId);

        //    this.DataContext = this.customer;

        //    //if (this.customer == null)
        //    //{
        //    //    return;
        //    //}

        //    //this.firstNameTextBox.Text = customer.FirstName;
        //    //this.lastNameTextBox.Text = customer.LastName;
        //    //this.phoneTextBox.Text = customer.Phone;
        //}

        //private async void OnSave(object sender, RoutedEventArgs e)
        //{
        //    // TODO: Validate input... call business rules... etc...
        //    //this.customer.FirstName = firstNameTextBox.Text;
        //    //this.customer.LastName = lastNameTextBox.Text;
        //    //this.customer.Phone = phoneTextBox.Text;

        //    await this.repository.UpdateCustomerAsync(customer);
        //}
    }
}
