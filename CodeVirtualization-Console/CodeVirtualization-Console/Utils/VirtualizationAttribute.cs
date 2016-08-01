using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeVirtualization_Console.Utils
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class VirtualizationObfuscationAttribute : System.Attribute
    {

        private bool Exclude = true;
        private string Level = "method";
        private bool Debug = false;

        public VirtualizationObfuscationAttribute(bool Exclude = false, string Level = "method", bool Debug = false)
        {
            this.Exclude = Exclude;
            this.Level = Level;
            this.Debug = Debug;
        }
    }

}
