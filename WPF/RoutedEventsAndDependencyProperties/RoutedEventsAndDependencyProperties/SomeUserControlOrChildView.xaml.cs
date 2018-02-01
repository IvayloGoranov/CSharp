using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoutedEventsAndDependencyProperties
{
    /// <summary>
    /// Interaction logic for SomeUserControlOrChildView.xaml
    /// </summary>
    public partial class SomeUserControlOrChildView : UserControl
    {
        public SomeUserControlOrChildView()
        {
            InitializeComponent();
            DependencyPropertyDescriptor dpd = 
                DependencyPropertyDescriptor.FromProperty(Button.IsFocusedProperty, typeof(Button));
            dpd.AddValueChanged(SaveButton, (s, e) =>
            {
                if (!SaveButton.IsFocused)
                    MessageBox.Show("Button Lost Focus!");
            });
        }

        public static readonly RoutedEvent DataIsDirtyChangedEvent =
            EventManager.RegisterRoutedEvent("DataIsDirtyChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<bool>), typeof(SomeUserControlOrChildView));

        public event RoutedPropertyChangedEventHandler<bool> DataIsDirtyChanged
        {
            add { AddHandler(DataIsDirtyChangedEvent, value); }
            remove { RemoveHandler(DataIsDirtyChangedEvent, value); }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            RoutedPropertyChangedEventArgs<bool> args =
                new RoutedPropertyChangedEventArgs<bool>(false, true, DataIsDirtyChangedEvent);
            RaiseEvent(args);
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            RoutedPropertyChangedEventArgs<bool> args =
                new RoutedPropertyChangedEventArgs<bool>(true, false, DataIsDirtyChangedEvent);
            RaiseEvent(args);
        }
    }
}
