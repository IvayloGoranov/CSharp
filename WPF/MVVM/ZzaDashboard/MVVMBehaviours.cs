using System.Windows;

namespace ZzaDashboard
{
    public static class MVVMBehaviours
    {
        public static int GetLoadedMethodName(DependencyObject obj)
        {
            return (int)obj.GetValue(LoadedMethodName);
        }

        public static void SetLoadedMethodName(DependencyObject obj, int value)
        {
            obj.SetValue(LoadedMethodName, value);
        }

        public static readonly DependencyProperty LoadedMethodName =
            DependencyProperty.RegisterAttached("LoadedMethodName", typeof(int), typeof(MVVMBehaviours), 
                new PropertyMetadata(null, OnLoadedMethodNameChanged));

        private static void OnLoadedMethodNameChanged(DependencyObject dependencyObject, 
            DependencyPropertyChangedEventArgs eventArgs)
        {
            FrameworkElement element = dependencyObject as FrameworkElement;
            if (element != null)
            {
                element.Loaded += (s, e2) =>
                {
                    var viewModel = element.DataContext;
                    if (viewModel == null)
                    {
                        return;
                    }

                    var methodInfo = viewModel.GetType().GetMethod(eventArgs.NewValue.ToString());
                    if (methodInfo != null)
                    {
                        methodInfo.Invoke(viewModel, null);
                    }
                };
            }
        }
    }
}
