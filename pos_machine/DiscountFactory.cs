using pos_machine.discount;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine
{
    internal class DiscountFactory
    {
        public static ADiscount createDiscount(string discounttype, List<Item> items)
        {
            ADiscount discount = null;
            switch (discounttype)
            {
                case "雞腿便當買二送一":
                    discount = new ChickenLegBuy2Get1(items);
                    return discount;
                case "排骨便當送紅茶":
                    discount = new PorkRibFreeTea(items);
                    return discount;
                case "滷肉便當買三個240元":
                    discount = new BraisedPork3For240(items);
                    return discount;
                case "咖哩便當搭可樂150元":
                    discount = new CurryWithCoke150(items);
                    return discount;
                case "雞排便當三件79折":
                    discount = new ChickenSteak3For79Percent(items);
                    return discount;
                case "所有飲料均一價25元":
                    discount = new DrinkFixedPrice25(items);
                    return discount;
                case "買燒肉便當搭配蒸蛋送提拉米蘇":
                    discount = new GrilledMeatWithEggFreeTiramisu(items);
                    return discount;
                case "鯖魚便當搭配玉米濃湯85折":
                    discount = new MackerelWithSoup85Percent(items);
                    return discount;
                case "全場消費滿399折50":
                    discount = new Spend399Get50Off(items);
                    return discount;
                case "全場打85折":
                    discount = new MackerelWithSoup85Percent(items);
                    return discount;
            }
            return discount;
        }
    }
}
