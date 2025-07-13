using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class AllItems85Percent : ADiscount
    {
        int total;
        bool contain;
        public AllItems85Percent(List<Item> items) : base(items)
        {
        }

        public override void DiscountItem()
        {
            total = 0;
            contain = items.Any();
            if (contain)
            {
                foreach (Item item_individual in items)
                {
                    total += int.Parse(item_individual.Count) * int.Parse(item_individual.UnitPrice);
                }
                Item item = new Item(Name: $"(折扣)全場打85折",
                                     UnitPrice: $"{Math.Floor(total * -0.15)}",
                                     Count: $"1");
                items.Add(item);
            }
        }
    }
}
