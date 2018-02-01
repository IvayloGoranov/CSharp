using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    public class CustomerListViewModel : BindableBase
    {
        public Action<Guid> PlaceOrderRequested = delegate { };
        public Action<Customer> AddCustomerRequested = delegate { };
        public Action<Customer> EditCustomerRequested = delegate { };

        private ICustomersRepository customersRepository;
        private ObservableCollection<Customer> customers;

        private string searchInput;
        private List<Customer> allCustomers;

        public CustomerListViewModel(ICustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;

            this.PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            this.AddCustomerCommand = new RelayCommand<Customer>(OnAddCustomer);
            this.EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
            this.ClearSearchCommand = new RelayCommand(OnClearSearch);
        }

        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }

        public RelayCommand<Customer> AddCustomerCommand { get; private set; }

        public RelayCommand<Customer> EditCustomerCommand { get; private set; }

        public RelayCommand<Customer> ClearSearchCommand { get; private set; }

        public string SearchInput
        {
            get
            {
                return this.searchInput;
            }

            set
            {
                this.SetPropery(ref this.searchInput, value);
                this.FilterCustomers(this.searchInput);
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
                this.SetPropery(ref this.customers, value);
            }
        }

        public async void LoadCustomers()
        {
            this.allCustomers = await this.customersRepository.GetCustomersAsync();

            this.Customers = new ObservableCollection<Customer>(this.allCustomers);
        }

        private void OnPlaceOrder(Customer customer)
        {
            this.PlaceOrderRequested(customer.Id);
        }

        private void OnEditCustomer(Customer customer)
        {
            this.EditCustomerRequested(customer);
        }

        private void OnAddCustomer(Customer customer)
        {
            this.AddCustomerRequested(new Customer { Id = Guid.NewGuid() });
        }

        private void FilterCustomers(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                this.Customers = new ObservableCollection<Customer>(this.allCustomers);
            }
            else
            {
                this.Customers = 
                    new ObservableCollection<Customer>(
                        this.allCustomers.Where(c => c.FullName.ToLower().Contains(searchInput)));
            }
        }

        private void OnClearSearch()
        {
            this.SearchInput = null;
        }
    }
}
