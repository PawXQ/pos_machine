using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class Spend399Get50Off : ADiscount
    {
        int total;
        bool contain;
        public Spend399Get50Off(List<Item> items) : base(items)
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
                if (total >= 399)
                {
                    Item item = new Item(Name: $"(折扣)全場消費滿399折50",
                                         UnitPrice: $"-50",
                                         Count: $"1");
                    items.Add(item);
                }
            }
        }
    }
}
