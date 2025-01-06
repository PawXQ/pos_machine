using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine
{
    internal class Item
    {
        public string Name { get; set; }
        public string UnitPrice { get; set; }
        public string Count { get; set; }
        public string Total
        {
            get
            {
                return (double.Parse(UnitPrice) * int.Parse(Count)).ToString();
            }
        }

        public Item(string Name, string UnitPrice, string Count)
        {
            this.Name = Name;
            this.UnitPrice = UnitPrice;
            this.Count = Count;
        }

    }
}
