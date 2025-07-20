using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine.AI
{
    internal class AIRequest
    {
        public List<Content> contents { get; set; } = new List<Content>();
        public List<Tool> tools { get; set; } = new List<Tool>();

        public class Content
        {
            public string role { get; set; }
            public List<Part> parts { get; set; } = new List<Part>();
        }

        public class Part
        {
            public string text { get; set; }
        }

        public class Tool
        {
            public List<Functiondeclaration> functionDeclarations { get; set; } = new List<Functiondeclaration>();
        }

        public abstract class Functiondeclaration
        {
            public abstract string name { get; }
            public abstract string description { get; }
            public abstract Parameters parameters { get; }
        }

        public abstract class Parameters
        {
            public string type = "object";
            public abstract object properties { get; }
            public abstract string[] required { get; }
        }

        //public class Properties
        //{
        //    public Brightness brightness { get; set; }
        //    public Color_Temp color_temp { get; set; }
        //}

        //public class Brightness
        //{
        //    public string type { get; set; }
        //    public string description { get; set; }
        //}

        //public class Color_Temp
        //{
        //    public string type { get; set; }
        //    public string[] @enum { get; set; }
        //    public string description { get; set; }
        //}

    }
}
