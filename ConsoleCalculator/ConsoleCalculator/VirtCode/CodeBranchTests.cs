using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ConsoleCalculator.VirtCode
{
    enum Priority
    {
        Zero,
        Low,
        Medium,
        Important,
        Critical
    }

    ;
    enum PriorityInt
    {
        ZeroInt = 0,
        LowInt = 2,
        MediumInt = 4,
        ImportantInt = 6,
        CriticalInt = 8
    }

    internal class CodeBranchTests
    {
        //TODO: test branching - done
#region SIMPLE_IF

//        [Obfuscation(Exclude = false, Feature = "virtualization; method")]
        private int SimpleIfStatement_0()
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

        private int SimpleIfStatement_1()
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
  
        private void SimpleIfStatement_check()
        {
            string testName = "Code#SimpleIfStatement_Check";
            bool condition = true;
            Program.Start_Check(testName);
            int virt = SimpleIfStatement_0();
            int oracle = SimpleIfStatement_1();
            condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

#endregion
#region NESTED_IF

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        //        private int NestedIfStatement()
        //        {
        //
        //            int sum = 1 + 3;
        //
        //            if (sum > 4)
        //            {
        //                sum += 10;
        //                if (sum > 20)
        //                {
        //                    sum += 30;
        //                }
        //                else
        //                {
        //                    sum -= 15;
        //                }
        //            }
        //            else
        //            {
        //                sum -= 20;
        //                if (sum > 210)
        //                {
        //                    sum += 310;
        //                }
        //                else
        //                {
        //                    sum -= 115;
        //                }
        //
        //            }
        //
        //            return sum;
        //        }
        //
        //        private int NestedIfStatement_Test()
        //        {
        //
        //            int sum = 1 + 3;
        //
        //            if (sum > 4)
        //            {
        //                sum += 10;
        //                if (sum > 20)
        //                {
        //                    sum += 30;
        //                }
        //                else
        //                {
        //                    sum -= 15;
        //                }
        //            }
        //            else
        //            {
        //                sum -= 20;
        //                if (sum > 210)
        //                {
        //                    sum += 310;
        //                }
        //                else
        //                {
        //                    sum -= 115;
        //                }
        //
        //            }
        //
        //            return sum;
        //        }
        //
        //        private void NestedIfStatement_Check()
        //        {
        //            Console.WriteLine("\nStart NestedIfStatement");
        //            int a = 3;
        //            int b = 3;
        //            int virt = NestedIfStatement();
        //            int oracle = NestedIfStatement_Test();
        //            bool condition = virt == oracle;            
        //            if (!condition)
        //            {
        //                throw new Exception("NestedIfStatement fail");
        //            }
        //            Console.WriteLine("NestedIfStatement_Check - " + condition);
        //            Console.WriteLine("---------------");
        //        }
#endregion
#region SIMPLE_SWITCH

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        //        private int SimpleSwitch()
        //        {
        //            int value = 5;
        //            int result = 0;
        //            switch (value)
        //            {
        //                case 1:
        //                    result = 1;
        //                    break;
        //                case 5:
        //                    result = 5;
        //                    break;
        //            }
        //            return result;
        //        }
        //
        //        private int SimpleSwitch_0()
        //        {
        //            int value = 5;
        //            int result = 0;
        //            switch (value)
        //            {
        //                case 1:
        //                    result = 1;
        //                    break;
        //                case 5:
        //                    result = 5;
        //                    break;
        //            }
        //            return result;
        //        }
        //
        //        private void SimpleSwitch_Check()
        //        {
        //            Console.WriteLine("\nStart SimpleSwitch_Check");
        //            int a = 3;
        //            int b = 3;
        //            int virt = SimpleSwitch();
        //            int oracle = SimpleSwitch_0();
        //            bool condition = virt == oracle;
        //            if (!condition)
        //            {
        //                throw new Exception("SimpleSwitch_Check fail");
        //            }
        //            Console.WriteLine("SimpleSwitch_Check - " + condition);
        //            Console.WriteLine("---------------");
        //        }
#endregion
#region SWITCH_CHAR

        //[Obfuscation(Exclude = false, Feature = "local virt")]
        //        private int CharSwitch(string input, int index)
        //        {            
        //            int result = -2;
        //
        //            switch (input[index])
        //            {
        //                case 'a':
        //                    result = 0;
        //                    break;
        //                case 'b':
        //                    result = 1;
        //                    break;
        //                case 'c':
        //                    result = 2;
        //                    break;
        //                default:
        //                    result = -1;
        //                    break;
        //            }
        //            return result;
        //        }
        //
        //        private int CharSwitch_0(string input, int index)
        //        {
        //            int result = -2;
        //
        //            switch (input[index])
        //            {
        //                case 'a':
        //                    result = 0;
        //                    break;
        //                case 'b':
        //                    result = 1;
        //                    break;
        //                case 'c':
        //                    result = 2;
        //                    break;
        //                default:
        //                    result = -1;
        //                    break;
        //            }
        //            return result;
        //        }
        //
        //        private void CharSwitch_Check()
        //        {
        //            Console.WriteLine("\nStart CharSwitch_Check");
        //            string input = "abc";
        //            int index = 0;
        //            int virt = CharSwitch(input, index);
        //            int oracle = CharSwitch_0(input, index);
        //            bool condition = virt == oracle;
        //            if (!condition)
        //            {
        //                throw new Exception("CharSwitch_Check fail");
        //            }
        //            Console.WriteLine("CharSwitch_Check - " + condition);
        //            Console.WriteLine("---------------");
        //        }
#endregion
#region SWITCH_ENUM

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        //        private PriorityInt EnumSwitch(Priority priority)
        //        {
        //            // Switch on the Priority enum.
        //            switch (priority)
        //            {
        //                case Priority.Low:
        //                    return PriorityInt.LowInt;
        //                case Priority.Medium:
        //                    return PriorityInt.MediumInt;
        //                case Priority.Zero:                    
        //                default:
        //                    return PriorityInt.ZeroInt;
        //                case Priority.Important:
        //                case Priority.Critical:
        //                    return PriorityInt.CriticalInt;
        //            }
        //        }
        //
        //        private PriorityInt EnumSwitch_0(Priority priority)
        //        {
        //            // Switch on the Priority enum.
        //            switch (priority)
        //            {
        //                case Priority.Low:
        //                    return PriorityInt.LowInt;
        //                case Priority.Medium:
        //                    return PriorityInt.MediumInt;
        //                case Priority.Zero:
        //                default:
        //                    return PriorityInt.ZeroInt;
        //                case Priority.Important:
        //                case Priority.Critical:
        //                    return PriorityInt.CriticalInt;
        //            }
        //        }
        //
        //        private void EnumSwitch_Check()
        //        {
        //            Console.WriteLine("\nStart EnumSwitch_Check");
        //            Priority p1 = Priority.Low;
        //            Priority p2 = Priority.Critical;
        //            PriorityInt virt1 = EnumSwitch(p1);
        //            PriorityInt oracle1 = EnumSwitch_0(p1);
        //            PriorityInt virt2 = EnumSwitch(p2);
        //            PriorityInt oracle2 = EnumSwitch_0(p2);
        //            PriorityInt virt12 = EnumSwitch2(p1);
        //            PriorityInt oracle12 = EnumSwitch_0(p1);
        //            PriorityInt virt22 = EnumSwitch2(p2);
        //            PriorityInt oracle22 = EnumSwitch_0(p2);
        //            bool condition = (virt1 == oracle1) && (virt2==oracle2);
        //            bool condition2 = (virt12 == oracle12) && (virt22 == oracle22);
        //            if (!condition || !condition2)
        //            {
        //                throw new Exception("EnumSwitch_Check fail");
        //            }
        //            Console.WriteLine("EnumSwitch_Check - " + condition);
        //            Console.WriteLine("---------------");
        //        }
        //
        //        // ConsoleCalculator.CodeBranchTests
        ////         [Obfuscation(Exclude = false, Feature = "local virt")]
        //        private PriorityInt EnumSwitch2(Priority priority)
        //        {
        //            uint[] array = new uint[219];
        //            array[0] = 220u;
        //            object[] array2 = new object[56];
        //            int num = -1;
        //            num++;
        //            array2[2] = 2;
        //            array2[3] = 4;
        //            array2[4] = 0;
        //            array2[5] = 8;
        //            array2[0] = priority;
        //            Priority priority2 = Priority.Zero;
        //            array2[1] = priority2;
        //            object obj = (Priority)array2[0];
        //            array2[1] = obj;
        //            switch ((Priority)array2[1])
        //            {
        //                case Priority.Low:
        //                    return (PriorityInt)((int)array2[2]);
        //                case Priority.Medium:
        //                    return (PriorityInt)((int)array2[3]);
        //                case Priority.Important:
        //                case Priority.Critical:
        //                    return (PriorityInt)((int)array2[5]);
        //            }
        //            return (PriorityInt)((int)array2[4]);
        //        }
#endregion
#region SWITCH_STRING

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        //        int StringSwitch(string month)
        //        {
        //            switch (month.ToLower())
        //            {
        //                case "march":
        //                    return 3;
        //                case "april":
        //                    return 4;
        //                case "may":
        //                    return 5;
        //                case "sulimov dog":
        //                case "whippet":
        //                case "eurasier":
        //                case "brittany":
        //                    return 0;
        //                default:
        //                    return -1;
        //            }
        //        }
        //
        //        int StringSwitch_0(string month)
        //        {
        //            switch (month.ToLower())
        //            {
        //                case "march":
        //                    return 3;
        //                case "april":
        //                    return 4;
        //                case "may":
        //                    return 5;
        //                case "sulimov dog":
        //                case "whippet":
        //                case "eurasier":
        //                case "brittany":
        //                    return 0;
        //                default:
        //                    return -1;
        //            }
        //        }
        //
        //        private void StringSwitch_Check()
        //        {            
        //            string testName = "StringSwitch_Check";
        //            bool condition = false;
        //            Program.Start_Check(testName);
        //
        //            string input1 = "March";
        //            string input2 = "december";            
        //            int virt1 = StringSwitch(input1);
        //            int oracle1 = StringSwitch_0(input1);
        //            bool condition1 = virt1 == oracle1;
        //            int virt2 = StringSwitch(input2);
        //            int oracle2 = StringSwitch_0(input2);
        //            bool condition2 = virt2 == oracle2;
        //            condition = condition1 && condition2;
        //            Program.End_Check(testName, condition);
        //        }
        //
        ////        void refarray()
        ////        {
        ////            object[] array2 = new object[70];
        ////
        ////            array2[2] = 3;
        ////
        ////            object aux = 4;
        ////            array2[2] = aux;
        ////            Console.WriteLine(array2[2]);
        ////                        
        ////            element(out ((int) aux));
        ////
        ////            Console.WriteLine(array2[2]);
        ////        }
        //
        //        void element(out int element)
        //        {
        //            element = 2;
        //        }
#endregion
        public static void RunBranchTests()
        {
            CodeBranchTests bt = new CodeBranchTests();
//                    bt.SimpleIfStatement_check();
        //            bt.NestedIfStatement_Check();
        //            bt.SimpleSwitch_Check();
        //            bt.CharSwitch_Check();
        //            bt.EnumSwitch_Check();
        //            bt.StringSwitch_Check();
        //            bt.refarray();
        }

    }
}