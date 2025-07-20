using pos_machine.Models;
using pos_machine.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pos_machine.Menus;

namespace pos_machine
{
    internal class DisCount
    {
        public DisCount()
        {
            //雞腿便當買二送一
            //排骨便當送紅茶
            //買燒肉便當搭配蒸蛋送提拉米蘇

            //滷肉便當買三個240元
            //咖哩便當搭可樂150元
            //所有飲料均一價25元

            //全場消費滿399折50

            //鯖魚便當搭配玉米濃湯85折
            //雞排便當三件79折
            //全場打85折
        }

        public static async Task DiscountOrder(UIOrderRequestModel uIOrderRequestModel)
        {
            uIOrderRequestModel.OrderItems.RemoveAll(x => x.Name.Contains("贈送"));
            uIOrderRequestModel.OrderItems.RemoveAll(x => x.Name.Contains("折扣"));

            DiscountContext discountContext = new DiscountContext(uIOrderRequestModel);
            string reason = await discountContext.GetResult();

            ShowPanel.Render(uIOrderRequestModel.OrderItems, reason);
        }
    }
}
