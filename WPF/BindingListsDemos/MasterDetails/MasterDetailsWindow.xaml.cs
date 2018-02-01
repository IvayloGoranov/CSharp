using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace MasterDetails
{
    /// <summary>
    /// Interaction logic for MasterDetailsWindow.xaml
    /// </summary>
    public partial class MasterDetailsWindow : Window
    {
        public MasterDetailsWindow()
        {
            InitializeComponent();
        }
    }

    public class Trait
    {
        string description;
        public string Description
        {
            get
            {
                return description; 
            }
            set 
            {
                description = value;
            }
        }
    }

    public class Traits : ObservableCollection<Trait> { }

    public class Person
    {
        string name;
        public string Name
        {
            get 
            { 
                return name; 
            }
            set
            {
                name = value;
            }
        }

        int age;
        public int Age
        {
            get 
            {
                return age;
            }
            set 
            { 
                age = value;
            }
        }

        Traits traits;
        public Traits Traits
        {
            get
            { 
                return traits;
            }
            set 
            { 
                traits = value;
            }
        }
    }

    public class People : ObservableCollection<Person> { }

    public class Family
    {
        string familyName;
        public string FamilyName
        {
            get 
            { 
                return familyName;
            }
            set 
            { 
                familyName = value;
            }
        }

        People members;
        public People Members
        {
            get 
            { 
                return members; 
            }
            set 
            {
                members = value;
            }
        }
    }

    public class Families : ObservableCollection<Family> { }

}