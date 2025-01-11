using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class ChickenSteak3For79Percent : ADiscount
    {
        Item product;
        int discount_times;
        public ChickenSteak3For79Percent(List<Item> items) : base(items)
        {
        }

        public override void DiscountItem()
        {
            product = items.FirstOrDefault(x => x.Name == "雞排便當");

            if (product != null && int.Parse(product.Count) > 2)
            {
                discount_times = 1;
                Item item = new Item(Name: $"(折扣)雞排便當三件79折",
                                     UnitPrice: $"0.79",
                                     Count: $"{discount_times}");
                items.Add(item);
            }
        }
    }
}
