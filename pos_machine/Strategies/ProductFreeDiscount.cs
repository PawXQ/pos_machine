using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.Strategies
{
    internal class ProductFreeDiscount : ADiscountStrategy
    {
        public ProductFreeDiscount(Menus.Discount discountType, List<Item> list_items) : base(discountType, list_items)
        {
        }

        public override void Discount()
        {
            var buyResult = this.list_items.Select(x =>
            {
                var condition = discountType.Conditions.FirstOrDefault(y => y.Product == x.Name);
                if (condition == null || int.Parse(x.Count) < condition.Quantity)
                {
                    return null;
                }
                return new
                {
                    x.Name,
                    FreeQty = int.Parse(x.Count) / condition.Quantity
                };
            }).Where(x => x != null).ToList();

            if (buyResult.Count == discountType.Conditions.Count())
            {
                int minQty = buyResult.Min(x => x.FreeQty);
                this.list_items.AddRange(discountType.Rewards.Select(x => new Item($"(贈送){x.Product}", "0", (minQty * x.Quantity).ToString())));
            }
        }
        //    case "買燒肉便當搭配蒸蛋送提拉米蘇":
        //        product_list = items.Where(x => x.Name == "燒肉便當" || x.Name == "蒸蛋").ToList();

        //        contain = product_list.Any(x => x.Name == "燒肉便當") && product_list.Any(x => x.Name == "蒸蛋");

        //        if (contain)
        //        {
        //            int roastedmeatcount = int.Parse(product_list.FirstOrDefault(x => x.Name == "燒肉便當").Count);
        //            int eggcount = int.Parse(product_list.FirstOrDefault(x => x.Name == "蒸蛋").Count);
        //            discount_times = Math.Min(roastedmeatcount, eggcount);
        //            Item item = new Item(Name: $"(贈送)提拉米蘇",
        //                                 UnitPrice: $"0",
        //                                 Count: $"{discount_times}");
        //            items.Add(item);
        //        }
        //        break;

    }
}
