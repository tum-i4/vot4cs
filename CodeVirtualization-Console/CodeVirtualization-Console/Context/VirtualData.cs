using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console
{
    class VirtualData
    {

        public readonly List<SyntaxAnnotation> Annotations = new List<SyntaxAnnotation>();

        public int Index { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public SyntaxNode Node { get; set; }

        public StatementSyntax Statement { get; set; }

        private ExpressionSyntax _defaultValue;
        public ExpressionSyntax DefaultValue
        {
            get
            {
                if (_defaultValue == null)
                    DefaultValue = null;
                return _defaultValue;
            }
            set
            {
                if (value == null)
                    _defaultValue = SyntaxFactoryExtensions.DefaultRandomValue(Type);
                else
                    _defaultValue = value;
            }
        }

        public bool IsConstant
        {
            get
            {
                var found = Annotations.Where(a => a.Kind.Equals("type")).FirstOrDefault(a => a.Data.Equals("constant"));
                if (found == null)
                    return false;
                return true;
            }
        }
        
         
    }
}
