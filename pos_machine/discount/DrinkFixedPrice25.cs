using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.discount
{
    internal class DrinkFixedPrice25 : ADiscount
    {
        int discount_times;
        bool contain;
        List<Item> product_list = new List<Item>();
        public DrinkFixedPrice25(List<Item> items) : base(items)
        {
        }

        public override void DiscountItem()
        {
            product_list = items.Where(x => x.Name == "紅茶" ||
                                                    x.Name == "綠茶" ||
                                                    x.Name == "冬瓜茶" ||
                                                    x.Name == "奶茶" ||
                                                    x.Name == "可樂").ToList();
            contain = product_list.Any();
            if (contain)
            {
                discount_times = product_list.Count();
                Item item = new Item(Name: $"(折扣)所有飲料均一價25元",
                                     UnitPrice: $"25",
                                     Count: $"{discount_times}");
                items.Add(item);
            }
        }
    }
}
