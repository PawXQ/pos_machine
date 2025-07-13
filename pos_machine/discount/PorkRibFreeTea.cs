using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class PorkRibFreeTea : ADiscount
    {
        Item product;
        int discount_times;
        public PorkRibFreeTea(List<Item> items) : base(items)
        {
        }

        public override void DiscountItem()
        {
            product = items.FirstOrDefault(x => x.Name == "排骨便當");
            if (product != null && int.Parse(product.Count) >= 1)
            {
                discount_times = int.Parse(product.Count);

                Item item = new Item(Name: $"(贈送)紅茶",
                                     UnitPrice: $"0",
                                     Count: $"{discount_times}");
                items.Add(item);
            }
        }
    }
}
