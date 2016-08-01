using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeVirtualization_Console.Context
{
    internal class VirtualOperation
    {        
        /// <summary>
        /// maintain the meta-information about each data element that is used in a virtual operation
        /// </summary>
        private readonly List<Tuple<string, string, string>> Data = new List<Tuple<string, string, string>>();

        /// <summary>
        /// maintain the meta-information about each fake data element that is used in a virtual operation
        /// </summary>
        private readonly List<Tuple<string, string, string>> FakeData = new List<Tuple<string, string, string>>();

        /// <summary>
        /// each unique instruction has a different size offset used to randomize the value of the instruction size
        /// </summary>
        public int InstructionSizeOffset = 0;

        public readonly List<StatementSyntax> Statetements = new List<StatementSyntax>();

        public int Key { get; set; }

        private int _size;
        public int Size
        {
            get
            {
                if (_size == 0)
                {
                    _size = VirtualizationContext.INSTRUCTION_SIZE_POSTFIX + VirtualizationContext.INSTRUCTION_SIZE_PREFIX +
                        InstructionSizeOffset;
                }
                return _size;
            }
            set { _size = value; }
        } 

        public string Signature { get; set; } = "";

        public string Name { get; set; } = "";

        public string UniqueName { get; set; } = "";

        private static Dictionary<int, int> AppearanceFrequency = new Dictionary<int, int>();


        public int Frequency => GetAppearanceCount(Key);

        public static int MaxFrequencyKey => maxFrequencyKey;

        private static int maxFrequency = -1;
        private static int maxFrequencyKey = -1;

        public VirtualOperation()
        {
            OffsetKeys = new List<string>();
            OffsetKeys.Add("" + 0); // statement key is always on position 0
        }

        

        public static void MarkAppearance(int key)
        {
            if (!AppearanceFrequency.ContainsKey(key))
            {
                AppearanceFrequency.Add(key, 1);
                if (maxFrequencyKey == -1)
                {
                    maxFrequencyKey = key;
                    maxFrequency = 1;
                }
            }
            else
            {
                int appeared = GetAppearanceCount(key);
                appeared++;
                AppearanceFrequency[key] = appeared;
                if (appeared > maxFrequency)
                {
                    maxFrequency = appeared;
                    maxFrequencyKey = key;
                }
            }
        }

        public static int GetAppearanceCount(int key)
        {
            int appeared = 0;
            AppearanceFrequency.TryGetValue(key, out appeared);
            return appeared;
        }

        /// <summary>
        /// values used to offset the VPC value for the virtual operation which is composed of multiple statements
        /// </summary>
        public List<string> OffsetKeys { get; set; }

        public void AddOffsetKey(string key)
        {
            OffsetKeys.Add(key);
        }

        public bool OffsetKeyUsed(string key)
        {
            return OffsetKeys.Contains(key);
        }

        private StatementSyntax syntax;
        /// <summary>
        /// the expression with randomized positions for paramenters
        /// </summary>
        public StatementSyntax Syntax
        {
            get { return syntax;}
            set
            {
                if (staticSyntax == null)
                {
                    staticSyntax = value; //default initialization
                }
                syntax = value;                
            }
        }

        /// <summary>
        /// the expression with consecutive positions for parameters
        /// </summary>
        private StatementSyntax staticSyntax;
        public StatementSyntax StaticSyntax
        {
            get { return staticSyntax; }
            set
            {
                staticSyntax = value;
            }
        }

        public void AddData(string name, string dataIndex, string vpcOffset)
        {
            Data.Add(new Tuple<string, string, string>(name, dataIndex, vpcOffset));
            OffsetKeys.Add(vpcOffset);
            Size++;
        }

        public void AddData(string name, int dataIndex, int vpcOffset)
        {
            AddData(name, "" + dataIndex, "" + vpcOffset);
        }

        public bool ReplaceStatement(StatementSyntax oldStatement, StatementSyntax newStatement)
        {
            int position = Statetements.IndexOf(oldStatement);
            if (position == -1)
                return false;
            Statetements[position] = newStatement;
            return true;
        }
        
        public void AddFakeData(string name, int dataIndex, int vpcOffset)
        {
            FakeData.Add(new Tuple<string, string, string>(name, "" + dataIndex, "" + vpcOffset));
        }

        public void AddStatement(StatementSyntax value)
        {
            Statetements.Add(value);
        }

        public List<Tuple<string, string, string>> GetData()
        {
            return Data;
        }

        public List<Tuple<string, string, string>> GetFakeData()
        {
            return FakeData;
        }

    }
}
