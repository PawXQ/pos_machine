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

            //var buyResult = this.list_items.Select(x =>
            //{
            //    var condition = res.FirstOrDefault(y => y.Product == x.Name);
            //    //if(condition == null || int.Parse(x.Count))
            //});
        }
    }
}
