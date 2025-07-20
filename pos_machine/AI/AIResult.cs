using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos_machine.AI.AIResponse;

namespace pos_machine.AI
{
    internal class AIResult
    {
        public bool CanRunTool { get; set; }
        public string Message { get; set; }
        private Functioncall functioncall;
        public AIResult(AIResponse aIResponse)
        {
            if (aIResponse.candidates[0].content.parts[0].text != null)
            {
                this.Message = aIResponse.candidates[0].content.parts[0].text;
                this.CanRunTool = false;
            }
            else
            {
                this.CanRunTool = true;
                this.functioncall = aIResponse.candidates[0].content.parts[0].functionCall;
            }
        }

        public AIResult(bool canRunTool, string message, Functioncall functioncall)
        {
            this.CanRunTool = canRunTool;
            this.Message = message;
            this.functioncall = functioncall;
        }
        public object RunTool()
        {
            Type type = Type.GetType(functioncall.name);
            var tool = Activator.CreateInstance(type, new object[] { functioncall.args });
            return tool.GetType().GetMethod("Apply").Invoke(tool, null);
        }
    }
}
