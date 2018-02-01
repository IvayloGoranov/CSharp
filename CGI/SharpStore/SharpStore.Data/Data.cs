using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpStore.Data
{
    public class Data
    {
        private static SharpStoreContext context;

        public static SharpStoreContext Context
        {
            get { return context ?? new SharpStoreContext(); }
        }
    }
}
