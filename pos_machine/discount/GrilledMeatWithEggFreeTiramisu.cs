using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class GrilledMeatWithEggFreeTiramisu : ADiscount
    {
        int discount_times;
        bool contain;
        List<Item> product_list = new List<Item>();
        public GrilledMeatWithEggFreeTiramisu(List<Item> items) : base(items)
        {
        }

        public override void DiscountItem()
        {
            product_list = items.Where(x => x.Name == "燒肉便當" || x.Name == "蒸蛋").ToList();

            contain = product_list.Any(x => x.Name == "燒肉便當") && product_list.Any(x => x.Name == "蒸蛋");

            if (contain)
            {
                int currycount = int.Parse(product_list.FirstOrDefault(x => x.Name == "燒肉便當").Count);
                int colacount = int.Parse(product_list.FirstOrDefault(x => x.Name == "蒸蛋").Count);
                discount_times = Math.Min(currycount, colacount);
                Item item = new Item(Name: $"(贈送)提拉米蘇",
                                     UnitPrice: $"10",
                                     Count: $"{discount_times}");
                items.Add(item);
            }
        }
    }
}
