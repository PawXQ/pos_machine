using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos_machine.Menus;

namespace pos_machine.Models
{
    internal class UIOrderRequestModel
    {
        public Discount DiscountType { get; set; }
        public List<Item> OrderItems { get; set; }
        public Item Item { get; set; }

        public bool AIRecommend { get; set; }


        public UIOrderRequestModel(Discount discountType)
        {
            this.DiscountType = discountType;
            this.AIRecommend = false;
        }
        public UIOrderRequestModel(bool aiRecommend, Item item)
        {
            this.AIRecommend = aiRecommend;
            this.Item = item;
        }
        public UIOrderRequestModel(bool aiRecommend)
        {
            this.AIRecommend = aiRecommend;
        }

        public UIOrderRequestModel(Discount discountType, Item item)
        {
            this.DiscountType = discountType;
            this.Item = item;
            this.AIRecommend = false;
        }

    }
}
