using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pos_machine
{
    internal class MenuData
    {
        public static pos_machine.Menus.Item[] Items { get; set; }
        public static pos_machine.Menus.Discount[] Discounts { get; set; }
        public static String ContentString { get; set; }


        static MenuData()
        {
            string menu_path = ConfigurationManager.AppSettings["menu_path"];
            ContentString = File.ReadAllText(menu_path);
            Menus menus = JsonConvert.DeserializeObject<Menus>(ContentString);
            Items = menus.Items;
            Discounts = menus.Discounts;
        }
    }
}
