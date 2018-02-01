using System.ComponentModel;

namespace NavigatingBetweenItems
{
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int age;

        private string name;

        public Person()
        {
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.Notify("Name");
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (this.age == value)
                {
                    return;
                }

                this.age = value;
                this.Notify("Age");
            }
        }

        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
