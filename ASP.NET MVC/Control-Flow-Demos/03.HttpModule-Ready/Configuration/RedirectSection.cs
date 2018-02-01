using System.Configuration;

namespace _03.HttpModule_Ready.Configuration
{
    public class RedirectSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(RedirectCollection))]
        public RedirectCollection Redirects
        {
            get
            {
                return (RedirectCollection)base[""];
            }
        }
    }
}