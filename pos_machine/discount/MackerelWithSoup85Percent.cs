using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class MackerelWithSoup85Percent : ADiscount
    {
        int discount_times;
        bool contain;
        List<Item> product_list = new List<Item>();
        public MackerelWithSoup85Percent(List<Item> items) : base(items)
        {
        }

        public override void DiscountItem()
        {
            product_list = items.Where(x => x.Name == "鯖魚便當" || x.Name == "玉米濃湯").ToList();
            contain = product_list.Any(x => x.Name == "鯖魚便當") && product_list.Any(x => x.Name == "玉米濃湯");

            if (contain)
            {
                int currycount = int.Parse(product_list.FirstOrDefault(x => x.Name == "鯖魚便當").Count);
                int colacount = int.Parse(product_list.FirstOrDefault(x => x.Name == "玉米濃湯").Count);
                discount_times = Math.Min(currycount, colacount);
                Item item = new Item(Name: $"(折扣)鯖魚便當搭配玉米濃湯85折",
                                     UnitPrice: $"0.85",
                                     Count: $"{discount_times}");
                items.Add(item);
            }
        }
    }
}
