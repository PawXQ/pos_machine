using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.AI.FunctionTool.AiDiscount
{
    internal class AiDiscountTool : ATool<AiDiscountArgs>
    {
        public AiDiscountTool(object json) : base(json)
        {
        }

        public override object Apply()
        {
            return responseArgs;
            //Console.WriteLine(responseArgs.name + ":" + responseArgs.strategy + ":" + responseArgs.reason);
        }
    }
}
