using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pos_machine.Menus;

namespace pos_machine
{
    internal class Order
    {
        public static List<Item> list_item = new List<Item>();

        public static void Additem(Item item, Discount discount)
        {
            Item product = list_item.FirstOrDefault(x => x.Name == item.Name);

            if (product == null && item.Count == "0") { return; }
            if (product == null) { list_item.Add(item); return; }
            if (product != null) { product.Count = item.Count; }
            if (product.Count == "0") { list_item.Remove(product); }

            DisCount.DiscountOrder(discount, list_item);
        }

        public static void DisCountOrder(Discount discount)
        {
            DisCount.DiscountOrder(discount, list_item);
        }

        //public static void Render(FlowLayoutPanel flowoutpanel_top_level)
        //{
        //    flowoutpanel_top_level.Controls.Clear();
        //    FlowLayoutPanel flowoutpanel_outlayer = new FlowLayoutPanel();
        //    flowoutpanel_outlayer.Width = flowoutpanel_top_level.Width;
        //    flowoutpanel_outlayer.Height = flowoutpanel_top_level.Height;
        //    foreach (Item item in list_item)
        //    {
        //        FlowLayoutPanel flowoutpanel = new FlowLayoutPanel();
        //        flowoutpanel.Width = flowoutpanel_outlayer.Width - 20;
        //        flowoutpanel.Height = 20;
        //        Label label_name = new Label { Text = item.Name, Width = 60 };
        //        Label label_unitprice = new Label { Text = $"${item.UnitPrice}", Width = 50 };
        //        Label label_count = new Label { Text = item.Count, Width = 50 };
        //        Label label_total = new Label { Text = item.Total, Width = 50 };
        //        flowoutpanel.Controls.Add(label_name);
        //        flowoutpanel.Controls.Add(label_unitprice);
        //        flowoutpanel.Controls.Add(label_count);
        //        flowoutpanel.Controls.Add(label_total);
        //        flowoutpanel_outlayer.Controls.Add(flowoutpanel);
        //    }
        //    flowoutpanel_top_level.Controls.Add(flowoutpanel_outlayer);
        //}
    }
}
