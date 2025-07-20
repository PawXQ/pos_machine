using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.AI
{
    internal abstract class ATool<T>
    {

        protected T responseArgs;

        public ATool(object response)
        {
            string responseString = JsonConvert.SerializeObject(response);
            responseArgs = JsonConvert.DeserializeObject<T>(responseString);
        }

        public abstract object Apply();

    }
}
