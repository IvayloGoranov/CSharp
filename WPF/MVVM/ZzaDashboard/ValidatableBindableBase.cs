using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZzaDashboard
{
    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public bool HasErrors
        {
            get
            {
                return this.errors.Count > 0;
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (this.errors.ContainsKey(propertyName))
            {
                return this.errors[propertyName];
            }
            else
            {
                return null;
            }
        }

        protected override void SetPropery<T>(ref T member, T value, 
            [CallerMemberName] string propertyName = null)
        {
            base.SetPropery<T>(ref member, value, propertyName);
            this.ValidateProperty(propertyName, value);
        }

        private void ValidateProperty<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                this.errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                this.errors.Remove(propertyName);
            }

            this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
