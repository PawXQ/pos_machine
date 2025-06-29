using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine
{

    internal class Menus
    {
        public Item[] Items { get; set; }
        public Discount[] Discounts { get; set; }

        public class Item
        {
            public string TypeName { get; set; }
            public Food[] Foods { get; set; }
        }

        public class Food
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class Discount
        {
            public int id { get; set; }
            public string Name { get; set; }
            public string Strategy { get; set; }
            public Condition[] Conditions { get; set; }
            public Reward[] Rewards { get; set; }
        }

        public class Condition
        {
            public string Product { get; set; }
            public int Quantity { get; set; }
            public int TotalPrice { get; set; }
        }

        public class Reward
        {
            public string Product { get; set; }
            public string RewardsType { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
            public int TotalPrice { get; set; }
            public float Percentage { get; set; }
        }

    }
}
