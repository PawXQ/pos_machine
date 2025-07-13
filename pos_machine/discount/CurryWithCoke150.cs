using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class CurryWithCoke150 : ADiscount
    {
        bool contain;
        List<Item> product_list = new List<Item>();
        int discount_times;
        public CurryWithCoke150(List<Item> items) : base(items)
        {
        }

        public override void DiscountItem()
        {
            product_list = items.Where(x => x.Name == "咖哩便當" || x.Name == "可樂").ToList();

            contain = product_list.Any(x => x.Name == "咖哩便當") && product_list.Any(x => x.Name == "可樂");

            if (contain)
            {
                int currycount = int.Parse(product_list.FirstOrDefault(x => x.Name == "咖哩便當").Count);
                int colacount = int.Parse(product_list.FirstOrDefault(x => x.Name == "可樂").Count);
                discount_times = Math.Min(currycount, colacount);
                Item item = new Item(Name: $"(折扣)咖哩便當搭可樂",
                                     UnitPrice: $"10",
                                     Count: $"{discount_times}");
                items.Add(item);
            }
        }
    }
}
