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
                var condition = discountType.Conditions.FirstOrDefault(y => y.Product == x.Name);
                if (condition == null || int.Parse(x.Count) < condition.Quantity) { return null; }
                return new
                {
                    x.Name,
                    DiscountQty = int.Parse(x.Count) / condition.Quantity
                };
            }
            ).Where(x => x != null).ToList();
        }
    }
}
