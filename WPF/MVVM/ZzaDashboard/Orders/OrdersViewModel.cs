using System;

namespace ZzaDashboard.Orders
{
    public class OrdersViewModel : BindableBase
    {
        private Guid customerId;

        public Guid CustomerId
        {
            get
            {
                return this.customerId;
            }

            set
            {
                this.SetPropery(ref this.customerId, value);
            }
        }
    }
}
