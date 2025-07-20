using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos_machine.AI.AIRequest;

namespace pos_machine.AI.FunctionTool.AiDiscount
{
    internal class AiDisCountFunctionDeclaration : Functiondeclaration
    {
        private string _name = "pos_machine.AI.FunctionTool.AiDiscount.AiDiscountTool";
        public override string name { get => _name; }
        private string _description = "這是一個菜單折扣對應說明表, 根據用戶點選的菜單內容, 選擇最適方案的說明書";
        public override string description { get => _description; }

        private MenuParameters _parameters;
        public override Parameters parameters { get => _parameters; }

        public AiDisCountFunctionDeclaration()
        {
            _parameters = new MenuParameters();
        }
    }
    internal class MenuParameters : Parameters
    {
        private object _properties;
        private string[] _required = new string[] { "strategy", "name", "reason" };

        public override object properties { get => _properties; }
        public override string[] required { get => _required; }

        public MenuParameters()
        {
            _properties = new
            {
                reason = new AIReuqestArgs("string", "這個參數是用來解釋選擇的原因, 詳細解釋原因, 並解釋當給付金額折算類似時選擇不同方案的原因"),
                strategy = new AIReuqestArgs("string", "策略的選擇, 已獲的贈送多樣性為優先", MenuData.Discounts.Select(x => x.Strategy).ToArray()),
                name = new AIReuqestArgs("string", "折扣的名稱", MenuData.Discounts.Select(x => x.Name).ToArray())
            };
        }
    }

    public class AIReuqestArgs
    {
        public string type { get; set; }
        public string description { get; set; }
        public string[] @enum { get; set; }

        public AIReuqestArgs(string type, string description, string[] @enum)
        {
            this.type = type;
            this.description = description;
            this.@enum = @enum;
        }

        public AIReuqestArgs(string type, string description)
        {
            this.type = type;
            this.description = description;
        }
    }
}
