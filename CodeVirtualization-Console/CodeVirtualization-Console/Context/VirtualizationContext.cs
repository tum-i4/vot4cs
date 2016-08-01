using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeVirtualization_Console.Context;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace CodeVirtualization_Console
{
    /// <summary>
    /// Use this attribute to mark obfuscation on a method
    /// [Obfuscation(Exclude = false, Feature = "virtualization; method/class; refactor; debug; readable")]
    /// </summary>
    internal class VirtualizationContext
    {
        //new
        #region INPUT_PARAMS
        public static readonly bool COMPILED_INTERPRETER = false; //TODO: compiled lambda expression interpreter not implemented

        /// <summary>
        /// the number of dummy code values inserted into a virtual operation
        /// </summary>
        public static int MAX_JUNK_CODE;

        public static int MAX_JUNK_STATEMENTS = 0; //TODO: MAX_JUNK_STATEMENTS not implemented
        public static bool DEFAULT_MOST_FREQUENT_OPERATION ;
        /// <summary>
        /// For example, statement  sum = 1 + 2 + 3 + 4 + 5 + 6;
        /// will be split into sub-statements which have maximum N operands
        /// Minimum value: 2 
        /// Default value: 2
        /// </summary>
        public static int MAX_OPERANDS;
        /// <summary>
        /// Minimum value: 1 
        /// Default value: 1
        /// </summary>
        public static int MAX_INVOCATIONS; 

        /// <summary>
        /// the size of the bytecode instruction
        /// </summary>
        public static int   INSTRUCTION_SIZE_POSTFIX;
        /// <summary>
        /// add the end of any instruction there can be overlapping between junk code or param from the next instruction
        /// </summary>
        public static int INSTRUCTION_SIZE_PREFIX;

        /// <summary>
        /// size of random empty positions considered for each unique instruction
        /// actual_instruction_size = INSTRUCTION_SIZE_POSTFIX + INSTRUCTION_SIZE_PREFIX + INSTRUCTION_SIZE_OFFSET
        /// </summary>
        public static int INSTRUCTION_SIZE_OFFSET;

        #endregion


        /* virtualization obfuscation variables identifiers */
        public static string DATA_IDENTIFIER;
        public static string CODE_IDENTIFIER ;
        public static string VPC_IDENTIFIER ;

        public static String Instance_INTERPRETER = "InstanceInterpreterVirtualization";
        public static String Class_INTERPRETER = "ClassInterpreterVirtualization";

        internal SemanticModel semanticModel;
        internal Project project;
        internal Document document;
        public Compilation compilation;
        public SyntaxNode currentRoot;

        private static int internalUniqueId = 0;
        public static int UniqueId => internalUniqueId++;
//        public int DataIndex => dataIndex++;

        /// <summary>
        /// initialization data for each method 
        /// </summary>
        public readonly List<VirtualData> data;

        /// <summary>
        /// list of code operands unique for each method
        /// </summary>
        public readonly List<VirtualOperation> code;

        /// <summary>
        /// list of code instructions unique for each interpreter
        /// </summary>
        public readonly List<VirtualOperation> Operations;

        private string VirtualizationLevel;
        public bool IsInstanceLevel => VirtualizationLevel.Equals("class-instance");
        public bool IsClassLevel => VirtualizationLevel.Equals("class-static");
        public bool IsMethodLevel => VirtualizationLevel.Equals("method");

        public void SetMethodLevelVirtualization()
        {
            VirtualizationLevel = "method";
        }

        public void SetInstanceLevelVirtualization()
        {
            VirtualizationLevel = "class-instance";
        }

        public void SetClassLevelVirtualization()
        {
            VirtualizationLevel = "class-static";
        }

        public String InterpreterIdentifier()
        {
            if (IsInstanceLevel)
                return VirtualizationContext.Instance_INTERPRETER;
            if (IsClassLevel)
                return VirtualizationContext.Class_INTERPRETER;
            return "";
        }

        /// <summary>
        /// Use this attribute to mark obfuscation on a method
        /// [Obfuscation(Exclude = false, Feature = "virtualization; method/class; refactor; debug")]
        /// 
        /// possible features:
        /// virtualization - signifies virtualization obfuscation
        /// method - add the interpreter inside the method
        /// class - add the interpreter at the class level
        /// refactor - only perform refactoring without virtualization (for debugging only)
        /// debug - to be decided...
        /// readable - adds comments to statements
        /// </summary>
        /// 
        public List<string> Options ;

        public static int InstructionSizeOffsetRand()
        {
            return GetRandom(0, INSTRUCTION_SIZE_OFFSET);
        }
        

        public static int MIN_SWITCH_KEY ;
        public static int MAX_SWITCH_KEY ;

        public int SWITCH_KEY
        {
            get { return GetRandomUnique(MIN_SWITCH_KEY, MAX_SWITCH_KEY); }
        }

        public static int MAX_DATA_KEY;
        public int DataIndex
        {
            get { return GetRandomUnique(0, MAX_DATA_KEY); }
        }

        public int DataIndexFake
        {
            get { return GetRandom(0, MAX_DATA_KEY); }
        }

        public static int MAX_CODE_KEY;
        public int CodeIndex
        {
            get { return GetRandomUnique(0, MAX_CODE_KEY); }
        }

        public int CodeIndexFake
        {
            get { return GetRandom(0, MAX_CODE_KEY); }
        }


        public VirtualizationContext()
        {
            Random = new Random();
            data = new List<VirtualData>();
            code = new List<VirtualOperation>();
            Operations = new List<VirtualOperation>();
            Options = new List<string>() {"method"};            
        }

        public void SetClassLevelOn()
        {
            if (!ClassLevelOn)
            {
                Options.Remove("method");
                Options.Add("class");
            }
        }

        public bool RefactoringOn => Options.Contains("refactor");
        public bool MethodLevelOn => Options.Contains("method");
        public bool ClassLevelOn => Options.Contains("class");
        public bool DebugOn => Options.Contains("debug");
        public bool ReadableOn => Options.Contains("readable");

        private static Random Random = new Random();
        public MSBuildWorkspace workspace;

        public void UpdateSemanticModel(SyntaxNode node)
        {
            var tree = node.Parent.SyntaxTree;
            UpdateSemanticModel(tree);
        }

        public void UpdateSemanticModel(SyntaxTree tree)
        {
            semanticModel = compilation.GetSemanticModel(tree);
        }

        public void UpdateCompilation(SyntaxNode newSource)
        {
            var oldSyntaxTree = semanticModel.SyntaxTree;
            var newSyntaxTree = newSource.SyntaxTree;
            var newCompilation = compilation.ReplaceSyntaxTree(oldSyntaxTree, newSyntaxTree);
            var newSemanticModel = newCompilation.GetSemanticModel(newSyntaxTree);

            compilation = newCompilation;
            semanticModel = newSemanticModel;
            currentRoot = newSemanticModel.SyntaxTree.GetRoot();
        }


        public void Reset()
        {
            data.Clear();
            code.Clear();
        }

        public static int GetRandom(int low, int high)
        {
            if (high < low)
            {
                int aux = low;
                low = high;
                high = aux;
            }        

            int value = Random.Next(low, high);
            return value;
        }

        public static int GetRandom()
        {
            int value = Random.Next();
            return value;
        }

        private List<int> randomSwitchKeyList = new List<int>();
        private int GetRandomUnique()
        {
            int generated = Random.Next();
            while (randomSwitchKeyList.Contains(generated))
                generated = Random.Next();
            randomSwitchKeyList.Add(generated);
            return generated;
        }

        private int GetRandomUnique(int min, int max)
        {
            int generated = Random.Next(min, max);
            while (randomSwitchKeyList.Contains(generated))
                generated = Random.Next(min, max);
            randomSwitchKeyList.Add(generated);
            return generated;
        }

        //DATA array index

        private List<int> randomDataKeyList = new List<int>();
        private int GetRandomDataUnique()
        {
            int generated = Random.Next();
            while (randomDataKeyList.Contains(generated))
                generated = Random.Next();
            randomDataKeyList.Add(generated);
            return generated;
        }

        private int GetRandomDataUnique(int min, int max)
        {
            int generated = Random.Next(min, max);
            while (randomDataKeyList.Contains(generated))
                generated = Random.Next(min, max);
            randomDataKeyList.Add(generated);
            return generated;
        }

        //CODE array index

        private List<int> randomCodeKeyList = new List<int>();
        private int GetRandomCodeUnique()
        {
            int generated = Random.Next();
            while (randomCodeKeyList.Contains(generated))
                generated = Random.Next();
            randomCodeKeyList.Add(generated);
            return generated;
        }

        private int GetRandomCodeUnique(int min, int max)
        {
            int generated = Random.Next(min, max);
            while (randomCodeKeyList.Contains(generated))
                generated = Random.Next(min, max);
            randomCodeKeyList.Add(generated);
            return generated;
        }

        public static int RandomInstructionPosition()
        {
            int generated = Random.Next(-INSTRUCTION_SIZE_PREFIX, INSTRUCTION_SIZE_POSTFIX);            
            return generated;
        }

    }
}
