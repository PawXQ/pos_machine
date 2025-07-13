using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.Strategies
{
    internal class AnyProductCashDiscount : ADiscountStrategy
    {
        public AnyProductCashDiscount(Menus.Discount discountType, List<Item> list_items) : base(discountType, list_items)
        {
        }

        public override void Discount()
        {
            var res = discountType.Conditions.SelectMany(x =>
                x.Product.Split(',').Select(y => new
                {
                    Product = y,
                    x.Quantity,
                })).ToList();

            var buyResult = this.list_items.Select(x =>
            {
                var condition = res.FirstOrDefault(y => y.Product == x.Name);
                if (condition == null)
                {
                    return null;
                }
                return new
                {
                    x.Name,
                    x.UnitPrice,
                    x.Count,
                    discountType.Rewards[0].Price,
                };
            }).Where(x => x != null).ToList();

            if (buyResult.Count != 0)
            {
                int TotalDiscount = 0;
                foreach (var item in buyResult)
                {
                    int discount = (item.Price - int.Parse(item.UnitPrice)) * int.Parse(item.Count);
                    TotalDiscount += discount;
                }
                this.list_items.Add(new Item($"(折扣){discountType.Name}", TotalDiscount.ToString(), "1"));
            }
        }
    }
}
