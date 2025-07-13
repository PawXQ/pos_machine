using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pos_machine.Menus;

namespace pos_machine.Strategies
{
    class ConditionGroup
    {
        public String Name { get; set; }
        public string ConditionID { get; set; }
        public int BuyCount { get; set; }
        public int ConditionCount { get; set; }
        public int Price { get; set; }
        public string RewardType { get; set; }
    }

    internal class ProductFreeDiscount : ADiscountStrategy
    {
        public ProductFreeDiscount(Menus.Discount discountType, List<Item> list_items) : base(discountType, list_items)
        {
        }

        public override void Discount()
        {
            //var conditions = discountType.Conditions.Select((x, index) => new
            //{

            //    Names = x.Product.Split(','),
            //    MinRequireQty = x.Quantity,
            //    ConditionID = index.ToString()
            //}).ToList();

            //var rewards = discountType.Rewards.Select((x, index) => new
            //{

            //    Names = x.Product.Split(','),
            //    FreeQty = x.Quantity,
            //    ConditionID = String.IsNullOrEmpty(x.RewardsType) ? "normal_" + index : index.ToString(),
            //    RewardType = x.RewardsType
            //}).ToList();



            //List<ConditionGroup> availableConditions = list_items.Select(x =>
            //{

            //    var condition = conditions.FirstOrDefault(y => y.Names.Contains(x.Name));
            //    if (condition == null)
            //        return null;
            //    ConditionGroup availableCondition = new ConditionGroup()
            //    {
            //        Name = x.Name,
            //        ConditionID = condition.ConditionID,
            //        BuyCount = int.Parse(x.Count),
            //        ConditionCount = condition.MinRequireQty
            //    };
            //    return availableCondition;
            //}).Where(x => x != null).ToList();


            //var conditionGrops = availableConditions.GroupBy(x => new { x.ConditionID, x.ConditionCount });
            //if (conditionGrops.Count() != conditions.Count)
            //    return;

            //List<int> conditionFreeCount = new List<int>();

            //conditionFreeCount = conditionGrops.Select(x =>
            //{
            //    int GroupSum = x.Sum(y => y.BuyCount);
            //    int count = GroupSum / x.Key.ConditionCount;
            //    return count;
            //}).ToList();

            //if (conditionFreeCount.Contains(0))
            //    return;

            //int freeCount = conditionFreeCount.Min();

            ////int passConditionCount = conditionGrops.Select(x =>
            ////{
            ////    int GroupSum = x.Sum(y => y.BuyCount);
            ////    int count = GroupSum / x.Key.ConditionCount;
            ////    conditionFreeCount.Add(count);
            ////    return count > 0;
            ////}).Where(x => x == true).Count();

            ////if (passConditionCount != conditions.Count)
            ////    return;

            ////int freeCount = conditionFreeCount.Min();


            //// 開始撰寫可以贈送的邏輯

            //List<ConditionGroup> availableRewards = list_items.Select((x) =>
            //{
            //    var reward = rewards.FirstOrDefault(y => y.Names.Contains(x.Name));
            //    if (reward == null)
            //        return null;
            //    ConditionGroup availableReward = new ConditionGroup()
            //    {
            //        Name = x.Name,
            //        ConditionID = reward.ConditionID,
            //        BuyCount = int.Parse(x.Count),
            //        ConditionCount = reward.FreeQty,
            //        Price = int.Parse(x.UnitPrice),
            //        RewardType = reward.RewardType
            //    };
            //    return availableReward;
            //}).Where(x => x != null).ToList();


            //List<Item> freeGift = availableRewards.GroupBy(x => new { x.ConditionID, x.RewardType, x.ConditionCount }).Select(x =>
            //{

            //    int price = 0;
            //    string rewardType = x.Key.RewardType;
            //    if (rewardType == "Min")
            //        price = x.Min(y => y.Price);
            //    else if (rewardType == "Max")
            //        price = x.Max(y => y.Price);
            //    else if (rewardType == "Any")
            //    {
            //        price = x.OrderBy(y => new Random(Guid.NewGuid().GetHashCode()).Next()).First().Price;
            //    }



            //    string itemName = price != 0 ? x.First(y => y.Price == price).Name : rewards.First(y => y.ConditionID == x.Key.ConditionID).Names[0];

            //    return new Item("(贈送)" + itemName, "0", (freeCount * x.Key.ConditionCount).ToString());
            //}).ToList();

            //this.list_items.AddRange(freeGift);


            ////處理直接贈送的品項
            //List<Item> normalGift = rewards.Where(x => x.ConditionID.Contains("normal")).Select(x => new Item($"(贈送){x.Names[0]}", "0", (freeCount * x.FreeQty).ToString())).ToList();
            //list_items.AddRange(normalGift);

            // [{ },{ }] 
            // [{ },{ },{ }] 
            // [r,g,m] [b, c]
            // {r:1} {g:1} {m:1} {b:1} {c:1}
            // [{r:1} {g:1} {m:1} {b:1} {c:1}]

            // [[{ },{ }],[{ },{ }]] => [{product, quantity,index },{ },{ },{ }] 
            // [{item, quantity, index}]

            // [[{},{},{}],[{},{},{}]]

            //步驟1:先將每一個Condition設定ConditionID(1,2,3,4)
            //步驟2:將自己購買的Item紀錄所屬的ConditionID是哪一個
            //步驟3:群組，將相同的ConditionID歸屬在同一個Group底下
            //步驟4:檢查歸屬後的符合條件數量的群組是否相等 => 不相等就不用送了

            //var resource = discountType.Conditions.Select()




            var resourceConditionClassification = discountType.Conditions.SelectMany((x, index) =>
                x.Product.Split(',').Select(y => new
                {
                    Product = y,
                    x.Quantity,
                    index
                })).ToList();

            var itemConditionClassification = this.list_items.Select(x =>
            {
                var condition = resourceConditionClassification.FirstOrDefault(y => y.Product == x.Name);
                if (condition == null)
                {
                    return null;
                }
                return new
                {
                    x.Name,
                    x.Count,
                    condition.index
                };
            }).Where(x => x != null).ToList();


            var temp = itemConditionClassification.GroupBy(x => x.index).Select(x => new
            {
                x.Key,
                Total = x.Sum(y => int.Parse(y.Count))
            });

            var temp2 = itemConditionClassification.GroupBy(x => new { x.index, x.Name }).Select(x => new
            {
                x.Key.index,
                x.Key.Name,
                Total = x.Sum(y => int.Parse(y.Count))
            });




            var itemGroup = itemConditionClassification.GroupBy(x => x.index);
            var itemGroupCount = itemGroup.Count();
            var itemGroupIndexTotal = itemGroup.Select(x => new
            {
                index = x.Key,
                sum = x.Sum(y => int.Parse(y.Count))
            });

            var conditionCheck = itemGroupCount == discountType.Conditions.Count();

            if (!conditionCheck) return;


            var buyResult = itemGroupIndexTotal.Select(x =>
            {
                var conditionQuantity = discountType.Conditions[x.index].Quantity;
                if (x.sum < conditionQuantity)
                {
                    return null;
                }
                return new
                {
                    FreeQty = x.sum / conditionQuantity
                };
            }).Where(x => x != null).ToList();

            if (buyResult.Count != discountType.Conditions.Count()) return;

            var resourceRewardsClassification = discountType.Rewards.SelectMany((x, index) =>
                x.Product.Split(',').Select(y => new
                {
                    Product = y,
                    x.Quantity,
                    index
                })).ToList();

            var itemRewardsClassification = this.list_items.Select(x =>
            {
                var condition = resourceRewardsClassification.FirstOrDefault(y => y.Product == x.Name);
                if (condition == null)
                {
                    return null;
                }
                return new
                {
                    x.Name,
                    condition.Quantity,
                    x.UnitPrice,
                    condition.index
                };
            }).Where(x => x != null).ToList();


            var rewardsType = discountType.Rewards[0].RewardsType;
            int minQty = buyResult.Min(x => x.FreeQty);

            List<Item> rewardsResult = itemRewardsClassification.GroupBy(x => new { x.index, x.Quantity }).Select((x, index) =>
            {
                int price = 0;
                string rewardType = rewardsType;
                if (rewardType == "Min")
                    price = x.Min(y => int.Parse(y.UnitPrice));
                else if (rewardType == "Max")
                    price = x.Max(y => int.Parse(y.UnitPrice));

                string itemName = price != 0 ? x.First(y => int.Parse(y.UnitPrice) == price).Name : resourceRewardsClassification.First(y => y.index == x.Key.index).Product;

                return new Item($"(贈送){itemName}", "0", (minQty * x.Key.Quantity).ToString());
            }).ToList();

            if (itemRewardsClassification.Count != 0)
            {
                this.list_items.AddRange(rewardsResult);
                return;
            }
            this.list_items.AddRange(discountType.Rewards.Select(x => new Item($"(贈送){x.Product}", "0", (minQty * x.Quantity).ToString())));

            //this.list_items.AddRange(rewardsResult);

            //if (rewardsType == "Min")
            //{
            //    var rewardsResult = itemRewardsClassification.GroupBy(x => x.index).Select(x => x.OrderBy(y => y.UnitPrice).First()).ToList();

            //    this.list_items.AddRange(
            //        rewardsResult.Select(x => new Item($"(贈送){x.Name}", "0", (minQty * x.Quantity).ToString()))
            //        );
            //}
            //else if (rewardsType == "Max")
            //{
            //    var rewardsResult = itemRewardsClassification.GroupBy(x => x.index).Select(x => x.OrderByDescending(y => y.UnitPrice).First()).ToList();

            //    this.list_items.AddRange(
            //        rewardsResult.Select(x => new Item($"(贈送){x.Name}", "0", (minQty * x.Quantity).ToString()))
            //        );
            //}
            //else
            //{
            //    this.list_items.AddRange(discountType.Rewards.Select(x => new Item($"(贈送){x.Product}", "0", (minQty * x.Quantity).ToString())));
            //}

            //var buyResult = this.list_items.Select(x =>
            //{
            //    var condition = resourceClassification.FirstOrDefault(y => y.Product == x.Name);
            //    if (condition == null || int.Parse(x.Count) < condition.Quantity)
            //    {
            //        return null;
            //    }
            //    return new
            //    {
            //        x.Name,
            //        FreeQty = int.Parse(x.Count) / condition.Quantity
            //    };
            //}).Where(x => x != null).ToList();

            //int minQty = buyResult.Min(x => x.FreeQty);
            //this.list_items.AddRange(discountType.Rewards.Select(x => new Item($"(贈送){x.Product}", "0", (minQty * x.Quantity).ToString())));

        }

        //    case "買燒肉便當搭配蒸蛋送提拉米蘇":
        //        product_list = items.Where(x => x.Name == "燒肉便當" || x.Name == "蒸蛋").ToList();

        //        contain = product_list.Any(x => x.Name == "燒肉便當") && product_list.Any(x => x.Name == "蒸蛋");

        //        if (contain)
        //        {
        //            int roastedmeatcount = int.Parse(product_list.FirstOrDefault(x => x.Name == "燒肉便當").Count);
        //            int eggcount = int.Parse(product_list.FirstOrDefault(x => x.Name == "蒸蛋").Count);
        //            discount_times = Math.Min(roastedmeatcount, eggcount);
        //            Item item = new Item(Name: $"(贈送)提拉米蘇",
        //                                 UnitPrice: $"0",
        //                                 Count: $"{discount_times}");
        //            items.Add(item);
        //        }
        //        break;

    }
}
