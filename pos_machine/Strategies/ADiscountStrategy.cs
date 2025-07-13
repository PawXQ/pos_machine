using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos_machine.Menus;

namespace pos_machine.Strategies
{
    internal abstract class ADiscountStrategy
    {
        protected Discount discountType;
        protected List<Item> list_items;
        public ADiscountStrategy(Discount discountType, List<Item> list_items)
        {
            this.discountType = discountType;
            this.list_items = list_items;
        }

        public abstract void Discount();
    }
}
