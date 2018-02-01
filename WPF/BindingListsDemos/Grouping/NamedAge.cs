using System.ComponentModel;

namespace Grouping
{
    public class NamedAge : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propNameForAge)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this,
                                new PropertyChangedEventArgs(propNameForAge));
            }
        }


        public string NameForAge { get; set; }
        public int AgeId { get; set; }

    }
}
