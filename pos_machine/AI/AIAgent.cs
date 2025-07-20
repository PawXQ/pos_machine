using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static pos_machine.AI.AIRequest;
using static pos_machine.AI.AIResponse;

namespace pos_machine.AI
{
    internal class AIAgent
    {

        AIRequest requestBody = new AIRequest()
        {
            tools = new List<AIRequest.Tool> {
                 new AIRequest.Tool()
            },
            contents = new List<AIRequest.Content> {
                 new AIRequest.Content
                 {
                     role = "model",
                     parts = new List<AIRequest.Part>
                     {
                         new AIRequest.Part{
                         text= "你是一個全知全能的AI助理，你不能幫助使用者回答各類問題，你只能從現有的工具中進行輔助，並且你必須要返回對應的參數來幫助使用者進行自動化設定"
                         }
                     }
                 }
             }
        };

        public AIAgent()
        {
            List<Functiondeclaration> functiondeclarationList = Assembly.GetExecutingAssembly()
                .DefinedTypes.Where(x => x.BaseType == typeof(Functiondeclaration))
                .Select(x => (Functiondeclaration)Activator.CreateInstance(x, null))
                .ToList();
            this.requestBody.tools[0].functionDeclarations.AddRange(functiondeclarationList);
        }
        public async Task<AIResponse> SendRequest()
        {
            var client = new HttpClient();

            string content = JsonConvert.SerializeObject(this.requestBody);

            var request = new HttpRequestMessage(HttpMethod.Post, "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key=AIzaSyDmM_uG1IOw92eCQMWuZddj8mXwNrZEbsM");
            request.Content = new StringContent(content);
            var response = await client.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            AIResponse aIResponse = JsonConvert.DeserializeObject<AIResponse>(responseString);
            return aIResponse;
        }
        public void AddInputContent(string role, string userinput)
        {
            AIRequest.Content inputContent = new AIRequest.Content
            {
                role = $"{role}",
                parts = new List<AIRequest.Part>
                {
                    new AIRequest.Part{
                        text= $"{userinput}"
                    }
                }
            };
            this.requestBody.contents.Add(inputContent);
        }

        public AIResult CheckRequestResult(AIResponse aIResponse)
        {
            return new AIResult(aIResponse);
        }
    }
}
