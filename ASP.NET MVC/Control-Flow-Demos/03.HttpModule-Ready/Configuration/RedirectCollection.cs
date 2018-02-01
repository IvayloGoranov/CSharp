using System.Configuration;

namespace _03.HttpModule_Ready.Configuration
{
    public class RedirectCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Redirect();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Redirect)element).Title;
        }
    }
}