using System;

using Microsoft.Practices.Unity;

using Zza.Data;
using ZzaDashboard.Customers;
using ZzaDashboard.OrderPrep;
using ZzaDashboard.Orders;

namespace ZzaDashboard
{
    public class MainViewModel : BindableBase
    {
        private CustomerListViewModel customerListViewModel;
        private OrderPrepViewModel orderPrepViewModel = new OrderPrepViewModel();
        private OrdersViewModel orderViewModel = new OrdersViewModel();
        private AddEditCustomerViewModel addEditViewModel;

        private BindableBase currentViewModel;

        public MainViewModel()
        {
            this.customerListViewModel = ContainerHelper.Container.Resolve<CustomerListViewModel>();
            this.addEditViewModel = ContainerHelper.Container.Resolve<AddEditCustomerViewModel>();

            //this.CurrentViewModel = new CustomerListViewModel();
            this.NavigateCommand = new RelayCommand<string>(this.OnNavigate);
            this.customerListViewModel.PlaceOrderRequested += this.NavigateToOrder;
            this.customerListViewModel.AddCustomerRequested += this.NavigateToAddCustomer;
            this.customerListViewModel.EditCustomerRequested += this.NavigateToEditCustomer;
            this.addEditViewModel.Done += this.NavigateToCustomerList;
        }

        public RelayCommand<string> NavigateCommand { get; private set; }

        public BindableBase CurrentViewModel
        {
            get
            {
                return this.currentViewModel;
            }

            set
            {
                this.SetPropery(ref this.currentViewModel, value);
            }
        }

        private void OnNavigate(string destination)
        {
            switch (destination)
            {
                case "orderPrep":
                    this.CurrentViewModel = this.orderPrepViewModel;
                    break;
                case "orders":
                    this.CurrentViewModel = this.orderViewModel;
                    break;
                case "customers":
                    this.CurrentViewModel = this.customerListViewModel;
                    break;
                default:
                    this.CurrentViewModel = this.customerListViewModel;
                    break;
            }
        }

        private void NavigateToOrder(Guid customerId)
        {
            this.orderViewModel.CustomerId = customerId;
            this.CurrentViewModel = this.orderViewModel;
        }

        private void NavigateToEditCustomer(Customer customer)
        {
            this.addEditViewModel.EditMode = true;
            this.addEditViewModel.SetCustomer(customer);
            this.CurrentViewModel = this.addEditViewModel;
        }

        private void NavigateToAddCustomer(Customer customer)
        {
            this.addEditViewModel.EditMode = false;
            this.addEditViewModel.SetCustomer(customer);
            this.CurrentViewModel = this.addEditViewModel;
        }

        private void NavigateToCustomerList()
        {
            this.CurrentViewModel = this.customerListViewModel;
        }
    }
}
