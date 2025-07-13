using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class ChickenLegBuy2Get1 : ADiscount
    {
        Item product;
        int discount_times;
        public ChickenLegBuy2Get1(List<Item> items) : base(items)
        {
        }

        public override void DiscountItem()
        {
            product = items.FirstOrDefault(x => x.Name == "雞腿便當");
            if (product != null && int.Parse(product.Count) > 1)
            {
                discount_times = int.Parse(product.Count) / 2;

                Item item = new Item(Name: $"(贈送)雞腿便當",
                                     UnitPrice: $"0",
                                     Count: $"{discount_times}");
                items.Add(item);
            }
        }
    }
}
