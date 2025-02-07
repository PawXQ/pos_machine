using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.Strategies
{
    internal class TotalCashDiscount : ADiscountStrategy
    {
        public TotalCashDiscount(Menus.Discount discountType, List<Item> list_items) : base(discountType, list_items)
        {
        }

        public override void Discount()
        {
            //var buyResult = this.list_items.Select(x =>{ 
            //var condition = di
            //})
        }
    }
}
