using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos_machine.Menus;

namespace pos_machine.Strategies
{
    internal class ProductCashDiscount : ADiscountStrategy
    {
        public ProductCashDiscount(Menus.Discount discountType, List<Item> list_items) : base(discountType, list_items)
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
                        x.UnitPrice,
                        DiscountCashQty = int.Parse(x.Count) / condition.Quantity,
                    };
                }).Where(x => x != null).ToList();
            if (buyResult.Count == discountType.Conditions.Count())
            {
                int minQty = buyResult.Min(x => x.DiscountCashQty);
                int minDiscount = discountType.Conditions.Select(x =>
                {
                    var item = buyResult.FirstOrDefault(y => y.Name == x.Product);
                    return int.Parse(item.UnitPrice) * x.Quantity;
                }).Sum();
                int Discount = discountType.Rewards[0].Price - minDiscount;
                this.list_items.Add(new Item($"(折扣){discountType.Name}", Discount.ToString(), minQty.ToString()));
            }
        }

    }
}
