using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine
{
    internal abstract class ADiscount
    {
        protected List<Item> items;

        public ADiscount(List<Item> items)
        {
            this.items = items;
        }
        public abstract void DiscountItem();

    }
}
