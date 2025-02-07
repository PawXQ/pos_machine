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
            var total = 0;
            foreach (var item in list_items)
            {
                total += int.Parse(item.UnitPrice) * int.Parse(item.Count);

            }
            if (total > discountType.Conditions[0].TotalPrice)
            {
                this.list_items.Add(new Item($"(折扣){discountType.Name}", discountType.Rewards[0].Price.ToString
                    (), 1.ToString()));
            }
            //var buyResult = this.list_items.Select(x =>
            //{
            //    total += int.Parse(x.UnitPrice) * int.Parse(x.Count);
            //});
        }
    }
}
