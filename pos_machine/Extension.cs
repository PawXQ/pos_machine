using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pos_machine
{
    internal static class Extension
    {
        // "abc".
        internal static int GetNumberString(this string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                    count++;
            }

            return count;
        }
        public static void CreateFromList(this FlowLayoutPanel flowlayoutpanel, List<string> list, EventHandler checkedChange, EventHandler valueChange)
        {
            for (int i = 0; i < list.Count; i++)
            {
                FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
                flowLayoutPanel2.Size = new System.Drawing.Size(250, 25);
                CheckBox checkBox = new CheckBox();
                checkBox.AutoSize = true;
                checkBox.Font = new System.Drawing.Font("Microsoft JhengHei", 12F);
                checkBox.Size = new System.Drawing.Size(100, 20);
                checkBox.Text = list[i];
                checkBox.CheckedChanged += checkedChange;
                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Size = new System.Drawing.Size(60, 20);
                numericUpDown.ValueChanged += valueChange;
                flowLayoutPanel2.Controls.Add(checkBox);
                flowLayoutPanel2.Controls.Add(numericUpDown);
                flowlayoutpanel.Controls.Add(flowLayoutPanel2);
            }
        }
        public static int CalculatePanelTotal(this FlowLayoutPanel flowlayoutpanel)
        {
            int total_price = 0;
            foreach (Control control in flowlayoutpanel.Controls)
            {
                if (!(control is FlowLayoutPanel flowlayoutpanel2)) continue;
                CheckBox checkbox = (CheckBox)flowlayoutpanel2.Controls[0];
                NumericUpDown numericUpDown = (NumericUpDown)flowlayoutpanel2.Controls[1];

                if (checkbox.Checked && numericUpDown.Value != 0)
                {
                    int total = int.Parse(checkbox.Text.Split('$')[1]) * (int)numericUpDown.Value;
                    total_price += total;
                }
            }
            return total_price;
        }
        public static void UpdatePanel(this FlowLayoutPanel FlowLayoutPanelTotal, CheckBox checkBox)
        {
            foreach (Control control in FlowLayoutPanelTotal.Controls)
            {
                if (control is FlowLayoutPanel flowLayoutPanel)
                {
                    Label itemlabel = (Label)flowLayoutPanel.Controls[0];
                    if (itemlabel.Text == checkBox.Text.Split('$')[0])
                    {
                        FlowLayoutPanelTotal.Controls.Remove(flowLayoutPanel);
                    }
                }
            }
            if (checkBox.Checked)
            {
                FlowLayoutPanel flowLayoutPanelAdd = new FlowLayoutPanel();
                //flowLayoutPanelAdd.FlowDirection = FlowDirection.LeftToRight;
                //flowLayoutPanelAdd.AutoSize = true;
                //flowLayoutPanelAdd.MaximumSize = new System.Drawing.Size(1000, 30);
                flowLayoutPanelAdd.BorderStyle = BorderStyle.FixedSingle;
                flowLayoutPanelAdd.Height = 20;
                flowLayoutPanelAdd.Width = FlowLayoutPanelTotal.Width - 50;
                FlowLayoutPanel flowLayoutPanelParent = (FlowLayoutPanel)checkBox.Parent;
                NumericUpDown numericUpDown = (NumericUpDown)flowLayoutPanelParent.Controls[1];
                Label label_item = new Label { Text = $"{checkBox.Text.Split('$')[0]}", Width = 60 };
                Label label_price = new Label { Text = $"${checkBox.Text.Split('$')[1]}", Width = 50 };
                Label label_quantity = new Label { Text = $"{numericUpDown.Value}", Width = 50 };
                Label label_total_price = new Label { Text = $"{int.Parse(checkBox.Text.Split('$')[1]) * (int)numericUpDown.Value}", Width = 50 };
                flowLayoutPanelAdd.Controls.Add(label_item);
                flowLayoutPanelAdd.Controls.Add(label_price);
                flowLayoutPanelAdd.Controls.Add(label_quantity);
                flowLayoutPanelAdd.Controls.Add(label_total_price);
                FlowLayoutPanelTotal.Controls.Add(flowLayoutPanelAdd);
            }
        }

    }
}
