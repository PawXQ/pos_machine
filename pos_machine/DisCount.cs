using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_machine
{
    internal class DisCount
    {
        public DisCount()
        {
            //雞腿便當買二送一
            //排骨便當送紅茶
            //滷肉便當買三個240元
            //咖哩便當搭可樂150元
            //雞排便當三件79折
            //所有飲料均一價25元
            //買燒肉便當搭配蒸蛋送提拉米蘇
            //鯖魚便當搭配玉米濃湯85折
            //全場消費滿399折50
            //全場打85折
        }

        public static void DiscountOrder(string discountType, List<Item> items)
        {
            items.RemoveAll(x => x.Name.Contains("贈送"));
            items.RemoveAll(x => x.Name.Contains("折扣"));

            ADiscount aDiscount = DiscountFactory.createDiscount(discountType, items);
            aDiscount.DiscountItem();
            ShowPanel.Render(items);
        }
    }
}
