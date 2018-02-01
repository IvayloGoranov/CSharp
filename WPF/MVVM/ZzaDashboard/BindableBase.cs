using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZzaDashboard
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void SetPropery<T>(ref T member, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, value))
            {
                return;
            }

            member = value;
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
