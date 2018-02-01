using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    public class CustomerDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICustomersRepository customersRepository = new CustomersRepository();
        private Customer selectedCustomer;
        private ObservableCollection<Customer> customers;

        public CustomerDetailViewModel()
        {
            this.DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }

        public RelayCommand DeleteCommand { get; private set; }

        public async void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            this.Customers = new ObservableCollection<Customer>(
                await this.customersRepository.GetCustomersAsync());
        }

        public Customer SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }

            set
            {
                if (value != this.selectedCustomer)
                {
                    this.selectedCustomer = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SelectedCustomer"));
                    this.DeleteCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return this.customers;
            }

            set
            {
                if (this.customers != value)
                {
                    this.customers = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Customers"));
                }
            }
        }

        private void OnDelete()
        {
            this.Customers.Remove(this.SelectedCustomer);
        }

        private bool CanDelete()
        {
            return this.SelectedCustomer != null;
        }
    }
}
