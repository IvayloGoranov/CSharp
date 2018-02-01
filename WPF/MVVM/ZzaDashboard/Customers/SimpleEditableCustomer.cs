using System;
using System.ComponentModel.DataAnnotations;

namespace ZzaDashboard.Customers
{
    public class SimpleEditableCustomer : ValidatableBindableBase
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;

        public Guid Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.SetPropery(ref this.id, value);
            }
        }

        [Required]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.SetPropery(ref this.firstName, value);
            }
        }

        [Required]
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.SetPropery(ref this.lastName, value);
            }
        }

        [Phone]
        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                this.SetPropery(ref this.phone, value);
            }
        }

        [EmailAddress]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.SetPropery(ref this.email, value);
            }
        }
    }
}
