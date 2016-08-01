using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ConsoleCalculator
{
    enum Priority
    {
        Zero,
        Low,
        Medium,
        Important,
        Critical
    };

    enum PriorityInt
    {
        ZeroInt = 0,
        LowInt = 2,
        MediumInt = 4,
        ImportantInt = 6,
        CriticalInt = 8
    }



    internal class BranchTests
    {
        //TODO: test branching - done

        public static void RunBranchTests()
        {
            BranchTests bt = new BranchTests();

//                        bt.CheckSimpleIfStatement();
            //
//                        bt.NestedIfStatement_Check(12);
//                        bt.NestedIfStatement_Check(4);
//                        bt.NestedIfStatement_Check(0);
//                        bt.NestedIfStatement_Check(2);
            //
//                        bt.ChainIf_Check(1);
//                        bt.ChainIf_Check(2);
//                        bt.ChainIf_Check(3);
//                        bt.ChainIf_Check(4);
//                        bt.ChainIf_Check(5);

            //            bt.SimpleSwitch_Check();
            //            bt.CharSwitch_Check();
            //            bt.EnumSwitch_Check();
            //            bt.StringSwitch_Check();

        }

        #region SIMPLE_IF

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private int SimpleIfStatement_0true()
        {
            int sum = 1 + 4;

            if (sum > 4)
            {
                sum += 10;
            }
            else
            {
                sum -= 20;
            }

            return sum;
        }

        private int SimpleIfStatement_1true()
        {

            int sum = 1 + 4;

            if (sum > 4)
            {
                sum += 10;
            }
            else
            {
                sum -= 20;
            }

            return sum;
        }

//        [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
        private int SimpleIfStatement_0false()
        {
            int sum = 1 + 3;

            if (sum > 4)
            {
                sum += 10;
            }
            else
            {
                sum -= 20;
            }

            return sum;
        }

        private int SimpleIfStatement_1false()
        {

            int sum = 1 + 3;

            if (sum > 4)
            {
                sum += 10;
            }
            else
            {
                sum -= 20;
            }

            return sum;
        }

        private void CheckSimpleIfStatement()
        {
            string testName = "SimpleIfStatement_true";

            Program.Start_Check(testName);
            int virt1 = SimpleIfStatement_0true();
            int oracle1 = SimpleIfStatement_1true();
            bool condition1 = virt1 == oracle1;
            Program.End_Check(testName, condition1);

            testName = "SimpleIfStatement_false";
            Program.Start_Check(testName);
            int virt2 = SimpleIfStatement_0false();
            int oracle2 = SimpleIfStatement_1false();
            bool condition2 = virt2 == oracle2;
            Program.End_Check(testName, condition2);
        }

        #endregion

        #region NESTED_IF

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private int NestedIfStatement_0(int sum1)
    {
            int sum = sum1 + 2;

            if (sum > 4)
            {
                sum += 10;
                if (sum < 20)
                {
                    sum += 30;
                }
                else
                {
                    sum -= 15;
                }
            }
            else
            {
                sum -= 20;
                if (sum < -17)
                {
                    sum += 310;
                }
                else
                {
                    sum -= 115;
                }

            }

            return sum;
        }

        private int NestedIfStatement_1(int sum1)
        {

            int sum = sum1 + 2;

            if (sum > 4)
            {
                sum += 10;
                if (sum < 20)
                {
                    sum += 30;
                }
                else
                {
                    sum -= 15;
                }
            }
            else
            {
                sum -= 20;
                if (sum < -17)
                {
                    sum += 310;
                }
                else
                {
                    sum -= 115;
                }

            }

            return sum;
        }

        private void NestedIfStatement_Check(int sum)
        {
            string testName = "NestedIfStatement_" + sum;
            Program.Start_Check(testName);
            int virt = NestedIfStatement_0(sum);
            int oracle = NestedIfStatement_1(sum);
            bool condition1 = virt == oracle;
            Program.End_Check(testName, condition1);
        }

        #endregion

        #region CHAIN_IF
//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        public int ChainIf_0(int arg)
        {
            int key = arg;
            int ret = 0;
            if (key == -2)
            {
                Console.WriteLine(arg);
                ret = 2;
            }
            else if (key == 3)
                ret = 3;
            else if (key == 4)
            {
                ret = 5;
            }
            else if (key == 5)
                return key;
            else
                ret = 100;
            return ret;
        }


        public int ChainIf_1(int arg)
        {
            int key = arg;
            int ret = 0;
            if (key == -2)
            {
                Console.WriteLine(arg);
                ret = 2;
            }
            else if (key == 3)
                ret = 3;
            else if (key == 4)
            {
                ret = 5;
            }
            else if (key == 5)
                return key;
            else
                ret = 100;
            return ret;
        }

        private void ChainIf_Check(int sum)
        {
            string testName = "ChainIf_" + sum;
            Program.Start_Check(testName);
            int virt = ChainIf_0(sum);
            int oracle = ChainIf_1(sum);
            bool condition1 = virt == oracle;
            Program.End_Check(testName, condition1);
        }

        #endregion

        #region SIMPLE_SWITCH
//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private int SimpleSwitch_0()
        {
            int value = 5;
            int result = 0;
            switch (value + 1 * 3)
            {
                case 0 + 2:                                   
                case 1:
                {
                        result = 1;
                        do
                        {
                            break;
                        } while (false);
                    }
                    break ;
                case 5:
                    result = 5;
                    
                    break;
                case 6:
                default:
                    result = 6;
                    break;
            }
            return result;
        }

        private int SimpleSwitch_1()
        {
            int value = 5;
            int result = 0;
            switch (value + 1 * 3)
            {
                case 0 + 2:
                case 1:
                    {
                        result = 1;
                        do
                        {
                            break;
                        } while (false);
                    }
                    break;
                case 5:
                    result = 5;

                    break;
                case 6:
                default:
                    result = 6;
                    break;
            }
            return result;
        }

        private void SimpleSwitch_Check()
        {
            string testName = "SimpleSwitch_Check";
            Program.Start_Check(testName);
            int a = 3;
            int b = 3;
            int virt = SimpleSwitch_0();
            int oracle = SimpleSwitch_1();
            bool condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

        #endregion

        #region SWITCH_CHAR

//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        private int CharSwitch(string input, int index)
        {            
            int result = -2;

            switch (input[index])
            {
                case 'a':
                    result = 0;
                    break;
                case 'b':
                    result = 1;
                    break;
                case 'c':
                    result = 2;
                    break;
                default:
                    result = -1;
                    break;
            }
            return result;
        }

        private int CharSwitch_0(string input, int index)
        {
            int result = -2;

            switch (input[index])
            {
                case 'a':
                    result = 0;
                    break;
                case 'b':
                    result = 1;
                    break;
                case 'c':
                    result = 2;
                    break;
                default:
                    result = -1;
                    break;
            }
            return result;
        }

        private void CharSwitch_Check()
        {            
            string testName = "CharSwitch_Check";
            Program.Start_Check(testName);
            string input = "abc";
            int index = 0;
            int virt = CharSwitch(input, index);
            int oracle = CharSwitch_0(input, index);
            bool condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

        #endregion

        #region SWITCH_ENUM
//        [Obfuscation(Exclude = false, Feature = "virtualization; class")]
        private PriorityInt EnumSwitch(Priority priority)
        {
            // Switch on the Priority enum.
            switch (priority)
            {
                case Priority.Low:
                    return PriorityInt.LowInt;
                case Priority.Medium:
                    return PriorityInt.MediumInt;
                case Priority.Zero:                    
                default:
                    return PriorityInt.ZeroInt;
                case Priority.Important:
                case Priority.Critical:
                    return PriorityInt.CriticalInt;
            }
        }

        private PriorityInt EnumSwitch_0(Priority priority)
        {
            // Switch on the Priority enum.
            switch (priority)
            {
                case Priority.Low:
                    return PriorityInt.LowInt;
                case Priority.Medium:
                    return PriorityInt.MediumInt;
                case Priority.Zero:
                default:
                    return PriorityInt.ZeroInt;
                case Priority.Important:
                case Priority.Critical:
                    return PriorityInt.CriticalInt;
            }
        }

        private void EnumSwitch_Check()
        {
            string testName = "EnumSwitch_Check";
            Program.Start_Check(testName);
            Priority p1 = Priority.Low;
            Priority p2 = Priority.Critical;
            PriorityInt virt1 = EnumSwitch(p1);
            PriorityInt oracle1 = EnumSwitch_0(p1);
            PriorityInt virt2 = EnumSwitch(p2);
            PriorityInt oracle2 = EnumSwitch_0(p2);
            
            bool condition = (virt1 == oracle1) && (virt2==oracle2);
            Program.End_Check(testName, condition);
        }

        #endregion

        #region SWITCH_STRING
//        [Obfuscation(Exclude = false, Feature = "virtualization; class")]
        int StringSwitch(string month)
        {
            switch (month.ToLower())
            {
                case "march":
                    return 3;
                case "april":
                    return 4;
                case "may":
                    return 5;
                case "sulimov dog":
                case "whippet":
                case "eurasier":
                case "brittany":
                    return 0;
                default:
                    return -1;
            }
        }

        int StringSwitch_0(string month)
        {
            switch (month.ToLower())
            {
                case "march":
                    return 3;
                case "april":
                    return 4;
                case "may":
                    return 5;
                case "sulimov dog":
                case "whippet":
                case "eurasier":
                case "brittany":
                    return 0;
                default:
                    return -1;
            }
        }

        private void StringSwitch_Check()
        {            

            string testName = "StringSwitch_Check";
            bool condition = false;
            Program.Start_Check(testName);

            string input1 = "March";
            string input2 = "december";            
            int virt1 = StringSwitch(input1);
            int oracle1 = StringSwitch_0(input1);
            bool condition1 = virt1 == oracle1;
            int virt2 = StringSwitch(input2);
            int oracle2 = StringSwitch_0(input2);
            bool condition2 = virt2 == oracle2;
            condition = condition1 && condition2;
            Program.End_Check(testName, condition);
        }

        #endregion


        


    }
}
