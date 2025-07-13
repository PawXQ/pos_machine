using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class BraisedPork3For240 : ADiscount
    {
        Item product;
        int discount_times;
        public BraisedPork3For240(List<Item> items) : base(items)
        {
        }

        public override void DiscountItem()
        {
            product = items.FirstOrDefault(x => x.Name == "滷肉便當");
            if (product != null && int.Parse(product.Count) > 2)
            {
                discount_times = int.Parse(product.Count) / 3;

                Item item = new Item(Name: $"(折扣)魯肉便當",
                                     UnitPrice: $"15",
                                     Count: $"{discount_times}");
                items.Add(item);
            }
        }
    }
}
