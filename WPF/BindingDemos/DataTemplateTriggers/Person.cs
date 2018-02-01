using System.ComponentModel;

namespace DataTemplateTriggers
{
    public class Person : INotifyPropertyChanged
    {
        private int age;

        public string Name { get; set; }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value != this.age)
                {
                    this.age = value;
                    this.OnPropertyChanged("Age");
                }
            }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person()
            : this("", 0)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
