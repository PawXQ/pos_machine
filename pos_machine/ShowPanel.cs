using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_machine
{
    internal class ShowPanel
    {
        //public static List<Item> list_item = new List<Item>();
        //public static FlowLayoutPanel flowoutpanel_outlayer = new FlowLayoutPanel();
        public static void Render(List<Item> list_item)
        {
            //flowoutpanel_top_level.Controls.Clear();
            FlowLayoutPanel flowoutpanel_outlayer = new FlowLayoutPanel();
            Label label_total_price = new Label();
            int total_price = 0;
            flowoutpanel_outlayer.Controls.Clear();
            flowoutpanel_outlayer.Width = 302;
            flowoutpanel_outlayer.Height = 584;
            foreach (Item item in list_item)
            {
                FlowLayoutPanel flowoutpanel = new FlowLayoutPanel();
                flowoutpanel.Width = flowoutpanel_outlayer.Width - 20;
                flowoutpanel.Height = 20;
                Label label_name = new Label { Text = item.Name, Width = 85 };
                Label label_unitprice = new Label { Text = $"${item.UnitPrice}", Width = 50 };
                Label label_count = new Label { Text = item.Count, Width = 50 };
                Label label_total = new Label { Text = item.Total, Width = 50 };
                flowoutpanel.Controls.Add(label_name);
                flowoutpanel.Controls.Add(label_unitprice);
                flowoutpanel.Controls.Add(label_count);
                flowoutpanel.Controls.Add(label_total);
                flowoutpanel_outlayer.Controls.Add(flowoutpanel);
                total_price += int.Parse(item.Total);
            }
            PanelInfo panelinfo = new PanelInfo(flowLayoutPanel: flowoutpanel_outlayer, total_price: total_price);

            EventPanel.UpdatePanel(panelinfo);
            //return flowoutpanel_outlayer;
            //flowoutpanel_top_level.Controls.Add(flowoutpanel_outlayer);
        }
    }
}
