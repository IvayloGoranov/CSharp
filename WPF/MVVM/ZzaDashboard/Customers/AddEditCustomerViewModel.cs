using System;
using System.ComponentModel;

using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    public class AddEditCustomerViewModel : BindableBase
    {
        public event Action Done = delegate { };

        private bool editMode;
        private Customer editingCustomer;
        private SimpleEditableCustomer simpleEditableCustomer;
        private ICustomersRepository customersRepository;

        public AddEditCustomerViewModel(ICustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;

            this.CancelCommand = new RelayCommand(OnCancel);
            this.SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        public RelayCommand CancelCommand { get; private set; }

        public RelayCommand SaveCommand { get; private set; }

        public bool EditMode
        {
            get
            {
                return this.editMode;
            }

            set
            {
                this.SetPropery(ref this.editMode, value);
            }
        }

        public SimpleEditableCustomer Customer
        {
            get
            {
                return this.simpleEditableCustomer;
            }

            set
            {
                this.SetPropery(ref this.simpleEditableCustomer, value);
            }
        }

        public void SetCustomer(Customer customer)
        {
            this.editingCustomer = customer;
            if (this.Customer != null)
            {
                this.Customer.ErrorsChanged -= this.RaiseCanExecuteChanged;
            }

            this.Customer = new SimpleEditableCustomer();
            this.Customer.ErrorsChanged += this.RaiseCanExecuteChanged;
            this.CopyCustomer(customer, this.Customer);
        }

        private void RaiseCanExecuteChanged(object sender, DataErrorsChangedEventArgs e)
        {
            this.SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyCustomer(Customer source, SimpleEditableCustomer target)
        {
            target.Id = source.Id;
            if (this.EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Email = source.Email;
                target.Phone = source.Phone;
            }
        }

        private async void OnSave()
        {
            this.UpdateCustomer(this.Customer, this.editingCustomer);
            if (this.EditMode)
            {
                await this.customersRepository.UpdateCustomerAsync(this.editingCustomer);
            }
            else
            {
                await this.customersRepository.AddCustomerAsync(this.editingCustomer);
            }

            this.Done();
        }

        private void UpdateCustomer(SimpleEditableCustomer source, Customer target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Email = source.Email;
            target.Phone = source.Phone;
        }

        private void OnCancel()
        {
            this.Done();
        }

        private bool CanSave()
        {
            return !this.Customer.HasErrors;
        }
    }
}
