using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.Strategies
{
    internal class ProductPercentageDiscount : ADiscountStrategy
    {
        public ProductPercentageDiscount(Menus.Discount discountType, List<Item> list_items) : base(discountType, list_items)
        {
        }

        public override void Discount()
        {

            var buyResult = this.list_items.Select(x =>
            {
                var condition = discountType.Conditions.FirstOrDefault(y => y.Product == x.Name
                || y.Product == "ALL");
                if (condition == null || int.Parse(x.Count) < condition.Quantity)
                {
                    return null;
                }
                if (condition.Product == "ALL")
                {
                    return new
                    {
                        x.Name,
                        x.UnitPrice,
                        x.Count,
                        DiscountQty = int.Parse(x.Count)
                    };
                }
                return new
                {
                    x.Name,
                    x.UnitPrice,
                    x.Count,
                    DiscountQty = int.Parse(x.Count) / condition.Quantity
                };
            }).Where(x => x != null).ToList();
            if (discountType.Conditions.Any(x => x.Product == "ALL"))
            {
                int Total = 0;
                foreach (var item in buyResult)
                {
                    Total += int.Parse(item.UnitPrice) * int.Parse(item.Count);
                }
                int RewardTotal = (int)(Total * discountType.Rewards[0].Percentage);
                int Discount = RewardTotal - Total;
                this.list_items.Add(new Item($"(折扣){discountType.Name}", Discount.ToString(), "1"));
                return;
            }
            if (buyResult.Count == discountType.Conditions.Count())
            {
                int minQty = buyResult.Min(x => x.DiscountQty);
                int ConditionTotal = discountType.Conditions.Select(x =>
                {
                    var item = buyResult.FirstOrDefault(y => y.Name == x.Product);
                    return int.Parse(item.UnitPrice) * x.Quantity;
                }).Sum();
                int RewardTotal = (int)(ConditionTotal * discountType.Rewards[0].Percentage);
                int Discount = RewardTotal - ConditionTotal;
                this.list_items.Add(new Item($"(折扣){discountType.Name}", Discount.ToString(), minQty.ToString()));
                return;
            }
        }
    }
}
