using Newtonsoft.Json;
using pos_machine.AI;
using pos_machine.AI.FunctionTool.AiDiscount;
using pos_machine.Models;
using pos_machine.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_machine
{
    internal class DiscountContext
    {
        ADiscountStrategy ADiscount;
        UIOrderRequestModel UIOrderRequestModel;
        string ContentString = MenuData.ContentString;

        public DiscountContext(UIOrderRequestModel uiOrderRequestModel)
        {
            this.UIOrderRequestModel = uiOrderRequestModel;
        }

        public async Task<string> GetResult()
        {
            string reason = "";
            if (!UIOrderRequestModel.AIRecommend)
            {
                SelectStrategyUse();
            }
            else if (UIOrderRequestModel.AIRecommend)
            {
                reason = await aiAgentStrategyUse();
            }

            ADiscount.Discount();
            return reason;
        }

        private void SelectStrategyUse()
        {
            Type type = Type.GetType(UIOrderRequestModel.DiscountType.Strategy);
            ADiscountStrategy strategy = (ADiscountStrategy)Activator.CreateInstance(type, new object[] { UIOrderRequestModel.DiscountType, UIOrderRequestModel.OrderItems });
            this.ADiscount = strategy;
        }

        private async Task<string> aiAgentStrategyUse()
        {
            string userOrder = String.Join("和", UIOrderRequestModel.OrderItems.Select(x => $"{x.Count}份{x.Name}"));
            AIAgent aiAgent = new AIAgent();
            aiAgent.AddInputContent("model", ContentString);
            aiAgent.AddInputContent("user", userOrder);
            AIResponse aiResponse = await aiAgent.SendRequest();
            AIResult aiResult = aiAgent.CheckRequestResult(aiResponse);
            AiDiscountArgs response = (AiDiscountArgs)aiResult.RunTool();

            Menus.Discount discountType = MenuData.Discounts.FirstOrDefault(x => x.Name == response.name);

            Type type = Type.GetType(response.strategy);
            ADiscountStrategy strategy = (ADiscountStrategy)Activator.CreateInstance(type, new object[] { discountType, UIOrderRequestModel.OrderItems });
            this.ADiscount = strategy;

            return response.reason;
        }
    }
}
