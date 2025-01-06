﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_machine
{
    public partial class Form1 : Form
    {
        List<string> list_main_meal = new List<string> { "雞腿便當$95", "排骨便當$90", "滷肉便當$85", "魚排便當$100", "燒肉便當$105", "咖哩便當$110", "炸雞便當$80", "鯖魚便當$120", "雞排便當$115", "控肉便當$95" };
        List<string> list_side_meal = new List<string> { "玉米濃湯$60", "蔥抓餅$70", "炸薯條$80", "涼拌木耳$90", "蒸蛋$100" };
        List<string> list_drink = new List<string> { "紅茶$30", "綠茶$35", "冬瓜茶$40", "奶茶$45", "可樂$50" };
        List<string> list_dessert = new List<string> { "布丁$60", "蛋塔$70", "提拉米蘇$80", "起司蛋糕$90", "巧克力慕斯$100" };

        public Form1()
        {
            InitializeComponent();
            EventPanel.panelHandler += RenderPanel;
        }
        private string price_calculator()
        {
            int total_price = 0;
            total_price += flowLayoutPanel1.CalculatePanelTotal();
            total_price += flowLayoutPanel2.CalculatePanelTotal();
            total_price += flowLayoutPanel3.CalculatePanelTotal();
            total_price += flowLayoutPanel4.CalculatePanelTotal();

            return total_price.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sum.Text = "0";
            sum.Text = price_calculator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // main meal flowLayoutPanel1
            flowLayoutPanel1.CreateFromList(this.list_main_meal, CheckChange, ValueChange);
            // side meal flowLayoutPanel2
            flowLayoutPanel2.CreateFromList(this.list_side_meal, CheckChange, ValueChange);
            // drink flowLayoutPanel3
            flowLayoutPanel3.CreateFromList(this.list_drink, CheckChange, ValueChange);
            // dessert flowLayoutPanel4
            flowLayoutPanel4.CreateFromList(this.list_dessert, CheckChange, ValueChange);

            comboBox1.SelectedIndex = 0;
        }

        private void CheckChange(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)checkBox.Parent;
            NumericUpDown numericUpDown = (NumericUpDown)flowLayoutPanel.Controls[1];
            if (checkBox.Checked) { numericUpDown.Value = 1; }
            if (!checkBox.Checked) { numericUpDown.Value = 0; }
            Item item = new Item(Name: $"{checkBox.Text.Split('$')[0]}",
                                 UnitPrice: $"{checkBox.Text.Split('$')[1]}",
                                 Count: $"{numericUpDown.Value}");
            Order.Additem(item, comboBox1.Text);
            //Order.Render(flowLayoutPanel5);
            //flowLayoutPanel5.UpdatePanel(checkBox);
        }

        private void ValueChange(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)numericUpDown.Parent;
            CheckBox checkBox = (CheckBox)flowLayoutPanel.Controls[0];
            if (numericUpDown.Value != 0) { checkBox.Checked = true; }
            if (numericUpDown.Value == 0) { checkBox.Checked = false; }
            Item item = new Item(Name: $"{checkBox.Text.Split('$')[0]}",
                                 UnitPrice: $"{checkBox.Text.Split('$')[1]}",
                                 Count: $"{numericUpDown.Value}");
            Order.Additem(item, comboBox1.Text);
            //Order.Render(flowLayoutPanel5);
            //flowLayoutPanel5.UpdatePanel(checkBox);
        }
        private void RenderPanel(object sender, PanelInfo panelInfo)
        {
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel5.Controls.Add(panelInfo.flowLayoutPanel);
            sum.Text = panelInfo.total_price.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order.DisCountOrder(comboBox1.Text.ToString());

        }
    }
}
