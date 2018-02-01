using System;
using System.ComponentModel;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    public class CustomerEditViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICustomersRepository repository = new CustomersRepository();
        private Customer customer = null;

        public CustomerEditViewModel()
        {
            this.SaveCommand = new RelayCommand(OnSave);
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            set
            {
                if (value != this.customer)
                {
                    this.customer = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Customer"));
                }
            }
        }

        public Guid CustomerId { get; set; }

        public ICommand SaveCommand { get; set; }

        public async void LoadCustomer()
        {
            this.Customer = await repository.GetCustomerAsync(CustomerId);
        }

        private async void OnSave()
        {
            this.Customer = await this.repository.UpdateCustomerAsync(this.Customer);
        }
    }
}
