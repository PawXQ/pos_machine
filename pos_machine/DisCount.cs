﻿using System;
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
            Item product;
            int discount_times;
            int total;
            bool contain;
            List<Item> product_list = new List<Item>();
            items.RemoveAll(x => x.Name.Contains("贈送"));
            items.RemoveAll(x => x.Name.Contains("折扣"));

            switch (discountType)
            {
                case "雞腿便當買二送一":
                    product = items.FirstOrDefault(x => x.Name == "雞腿便當");
                    if (product != null && int.Parse(product.Count) > 1)
                    {
                        discount_times = int.Parse(product.Count) / 2;

                        Item item = new Item(Name: $"(贈送)雞腿便當",
                                             UnitPrice: $"0",
                                             Count: $"{discount_times}");
                        items.Add(item);
                    }
                    break;
                case "排骨便當送紅茶":
                    product = items.FirstOrDefault(x => x.Name == "排骨便當");
                    if (product != null && int.Parse(product.Count) >= 1)
                    {
                        discount_times = int.Parse(product.Count);

                        Item item = new Item(Name: $"(贈送)紅茶",
                                             UnitPrice: $"0",
                                             Count: $"{discount_times}");
                        items.Add(item);
                    }
                    break;
                case "滷肉便當買三個240元":
                    product = items.FirstOrDefault(x => x.Name == "滷肉便當");
                    if (product != null && int.Parse(product.Count) > 2)
                    {
                        discount_times = int.Parse(product.Count) / 3;

                        Item item = new Item(Name: $"(折扣)魯肉便當",
                                             UnitPrice: $"15",
                                             Count: $"{discount_times}");
                        items.Add(item);
                    }
                    break;
                case "咖哩便當搭可樂150元":
                    product_list = items.Where(x => x.Name == "咖哩便當" || x.Name == "可樂").ToList();

                    contain = product_list.Any(x => x.Name == "咖哩便當") && product_list.Any(x => x.Name == "可樂");

                    if (contain)
                    {
                        int currycount = int.Parse(product_list.FirstOrDefault(x => x.Name == "咖哩便當").Count);
                        int colacount = int.Parse(product_list.FirstOrDefault(x => x.Name == "可樂").Count);
                        discount_times = Math.Min(currycount, colacount);
                        Item item = new Item(Name: $"(折扣)咖哩便當搭可樂",
                                             UnitPrice: $"10",
                                             Count: $"{discount_times}");
                        items.Add(item);
                    }
                    break;
                case "雞排便當三件79折":
                    product = items.FirstOrDefault(x => x.Name == "雞排便當");

                    if (product != null && int.Parse(product.Count) > 2)
                    {
                        discount_times = 1;
                        Item item = new Item(Name: $"(折扣)雞排便當三件79折",
                                             UnitPrice: $"0.79",
                                             Count: $"{discount_times}");
                        items.Add(item);
                    }
                    break;
                case "所有飲料均一價25元":
                    product_list = items.Where(x => x.Name == "紅茶" ||
                                                    x.Name == "綠茶" ||
                                                    x.Name == "冬瓜茶" ||
                                                    x.Name == "奶茶" ||
                                                    x.Name == "可樂").ToList();
                    contain = product_list.Any();
                    if (contain)
                    {
                        discount_times = product_list.Count();
                        Item item = new Item(Name: $"(折扣)所有飲料均一價25元",
                                             UnitPrice: $"25",
                                             Count: $"{discount_times}");
                        items.Add(item);
                    }
                    break;
                case "買燒肉便當搭配蒸蛋送提拉米蘇":
                    product_list = items.Where(x => x.Name == "燒肉便當" || x.Name == "蒸蛋").ToList();

                    contain = product_list.Any(x => x.Name == "燒肉便當") && product_list.Any(x => x.Name == "蒸蛋");

                    if (contain)
                    {
                        int currycount = int.Parse(product_list.FirstOrDefault(x => x.Name == "燒肉便當").Count);
                        int colacount = int.Parse(product_list.FirstOrDefault(x => x.Name == "蒸蛋").Count);
                        discount_times = Math.Min(currycount, colacount);
                        Item item = new Item(Name: $"(贈送)提拉米蘇",
                                             UnitPrice: $"10",
                                             Count: $"{discount_times}");
                        items.Add(item);
                    }
                    break;
                case "鯖魚便當搭配玉米濃湯85折":
                    product_list = items.Where(x => x.Name == "鯖魚便當" || x.Name == "玉米濃湯").ToList();
                    contain = product_list.Any(x => x.Name == "鯖魚便當") && product_list.Any(x => x.Name == "玉米濃湯");

                    if (contain)
                    {
                        int currycount = int.Parse(product_list.FirstOrDefault(x => x.Name == "鯖魚便當").Count);
                        int colacount = int.Parse(product_list.FirstOrDefault(x => x.Name == "玉米濃湯").Count);
                        discount_times = Math.Min(currycount, colacount);
                        Item item = new Item(Name: $"(折扣)鯖魚便當搭配玉米濃湯85折",
                                             UnitPrice: $"0.85",
                                             Count: $"{discount_times}");
                        items.Add(item);
                    }
                    break;
                case "全場消費滿399折50":
                    total = 0;
                    contain = items.Any();
                    if (contain)
                    {
                        foreach (Item item_individual in items)
                        {
                            total += int.Parse(item_individual.Count) * int.Parse(item_individual.UnitPrice);
                        }
                        if (total >= 399)
                        {
                            Item item = new Item(Name: $"(折扣)全場消費滿399折50",
                                                 UnitPrice: $"-50",
                                                 Count: $"1");
                            items.Add(item);
                        }
                    }
                    break;
                case "全場打85折":
                    total = 0;
                    contain = items.Any();
                    if (contain)
                    {
                        foreach (Item item_individual in items)
                        {
                            total += int.Parse(item_individual.Count) * int.Parse(item_individual.UnitPrice);
                        }
                        Item item = new Item(Name: $"(折扣)全場打85折",
                                             UnitPrice: $"{Math.Floor(total * -0.15)}",
                                             Count: $"1");
                        items.Add(item);
                    }
                    break;
            }
            ShowPanel.Render(items);
        }
    }
}
