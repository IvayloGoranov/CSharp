using System;
using System.ComponentModel;
using System.Windows;

namespace ZzaDashboard
{
    public static class ViewModelLocator
    {
        public static bool GetAutoWireViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoWireViewModel);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireViewModel, value);
        }

        public static readonly DependencyProperty AutoWireViewModel =
            DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(int), typeof(ViewModelLocator), 
                new PropertyMetadata(false, AutoWireViewModelChanged));

        private static void AutoWireViewModelChanged(DependencyObject view, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(view))
            {
                return;
            }

            var viewType = view.GetType();
            string viewTypeFullName = viewType.FullName;
            string viewModelTypeName = viewTypeFullName + "Model";
            var viewModelType = Type.GetType(viewTypeFullName);
            var viewModel = Activator.CreateInstance(viewModelType);
            ((FrameworkElement)view).DataContext = viewModel;
        }
    }
}
