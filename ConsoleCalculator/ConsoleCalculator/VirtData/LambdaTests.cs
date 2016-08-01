using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    /**
     * http://www.dotnetperls.com/lambda     
     */

    internal class LambdaTests
    {

        #region LIST_INDEX_LAMBDA

//        [Obfuscation(Exclude = false, Feature = "local virt")]
        private int ListIndexLambda()
        {
            List<int> elements = new List<int>() {10, 20, 31, 40};
            // ... Find index of first odd element.
            int oddIndex = elements.FindIndex(x => x%2 != 0);
            return oddIndex;
        }

        private int ListIndexLambda_0()
        {
            List<int> elements = new List<int>() {10, 20, 31, 40};
            // ... Find index of first odd element.
            int oddIndex = elements.FindIndex(x => x%2 != 0);
            return oddIndex;
        }

        private void ListIndexLambda_Check()
        {
            string testName = "ListIndexLambda_Check";
            bool condition = false;
            Program.Start_Check(testName);

            int var1 = ListIndexLambda();
            int var2 = ListIndexLambda_0();
            condition = var1 == var2;

            Program.End_Check(testName, condition);
        }

        #endregion

        #region FUNCTION_LAMBDA

        /* http://www.dotnetperls.com/lambda */

//        [Obfuscation(Exclude = false, Feature = "local virt")]
        private int[] FunctionLambda()
        {
            //Virtualization variables
            int[] code = new int[3000];
            object[] data = new object[1500];
            int vpc = 0;

            //Data init
            data[0] = 10; //10
            data[1] = 0; //0
            data[2] = 1; //1
            data[3] = 2; //2
            data[4] = 3; //3
            data[5] = 4; //4
            data[6] = 5; //5
            data[7] = 6; //6
            data[8] = null; //result
            data[9] = null; //func1
            data[10] = null; //func2
            data[11] = null; //func3
            data[12] = null; //func4
            data[13] = null; //func5
            data[14] = null; //func6
            data[15] = null; //func7
            data[16] = null; //func8

            //Code init
            code[0] = 10; //
            code[1] = 8; //result
            code[2] = 0; //10
            code[3] = 11; //
            code[4] = 9; //func1
            code[5] = 12; //
            code[6] = 10; //func2
            code[7] = 13; //
            code[8] = 11; //func3
            code[9] = 14; //
            code[10] = 12; //func4
            code[11] = 15; //
            code[12] = 13; //func5
            code[13] = 16; //
            code[14] = 14; //func6
            code[15] = 17; //
            code[16] = 15; //func7
            code[17] = 18; //
            code[18] = 16; //func8
            code[19] = 19; //
            code[20] = 8; //result
            code[21] = 1; //0
            code[22] = 9; //func1
            code[23] = 2; //1
            code[24] = 19; //
            code[25] = 8; //result
            code[26] = 2; //1
            code[27] = 10; //func2
            code[28] = 3; //2
            code[29] = 19; //
            code[30] = 8; //result
            code[31] = 3; //2
            code[32] = 11; //func3
            code[33] = 4; //3
            code[34] = 19; //
            code[35] = 8; //result
            code[36] = 4; //3
            code[37] = 12; //func4
            code[38] = 5; //4
            code[39] = 20; //
            code[40] = 8; //result
            code[41] = 5; //4
            code[42] = 13; //func5
            code[43] = 6; //5
            code[44] = 7; //6
            code[45] = 21; //
            code[46] = 14; //func6
            code[47] = 19; //
            code[48] = 8; //result
            code[49] = 6; //5
            code[50] = 15; //func7
            code[51] = 2; //1
            code[52] = 22; //
            code[53] = 8; //result
            code[54] = 7; //6
            code[55] = 16; //func8
            code[56] = 23; //
            code[57] = 8; //result

            while (true)
            {
                switch (code[vpc++])
                {
                    case 10:
                        data[code[vpc++]] = (int[]) (new int[(int) data[code[vpc++]]]);
                        break;
                    case 11:
                        data[code[vpc++]] = (Func<int, int>) (x1 => x1 + 1);
                        break;
                    case 12:
                        data[code[vpc++]] = (Func<int, int>) (x2 =>
                        {
                            return x2 + 1;
                        }

                            );
                        break;
                    case 13:
                        data[code[vpc++]] = (Func<int, int>) ((int x3) => x3 + 1);
                        break;
                    case 14:
                        data[code[vpc++]] = (Func<int, int>) ((int x4) =>
                        {
                            return x4 + 1;
                        }

                            );
                        break;
                    case 15:
                        data[code[vpc++]] = (Func<int, int, int>) ((x5, y) => x5*y);
                        break;
                    case 16:
                        data[code[vpc++]] = (Action) (() => Console.WriteLine("func 6"));
                        break;
                    case 17:
                        data[code[vpc++]] = (Func<int, int>) (delegate(int x6)
                        {
                            return x6 + 1;
                        }

                            );
                        break;
                    case 18:
                        data[code[vpc++]] = (Func<int>) (delegate
                        {
                            return 1 + 1;
                        }

                            );
                        break;
                    case 19:
                        ((int[]) data[code[vpc++]])[(int) data[code[vpc++]]] =
                            ((Func<int, int>) data[code[vpc++]]).Invoke((int) data[code[vpc++]]);
                        break;
                    case 20:
                        ((int[]) data[code[vpc++]])[(int) data[code[vpc++]]] =
                            ((Func<int, int, int>) data[code[vpc++]]).Invoke((int) data[code[vpc++]],
                                (int) data[code[vpc++]]);
                        break;
                    case 21:
                        ((Action) data[code[vpc++]]).Invoke();
                        break;
                    case 22:
                        ((int[]) data[code[vpc++]])[(int) data[code[vpc++]]] = ((Func<int>) data[code[vpc++]]).Invoke();
                        break;
                    case 23:
                        return (int[]) data[code[vpc++]];
                    default:
                        break;
                }
            }

            return null;
        }

        private int[] FunctionLambda_0()
        {
            int[] result = new int[10];
            Func<int, int> func1 = x1 => x1 + 1;
            Func<int, int> func2 = x2 => { return x2 + 1; };
            Func<int, int> func3 = (int x3) => x3 + 1;
            Func<int, int> func4 = (int x4) => { return x4 + 1; };
            Func<int, int, int> func5 = (x5, y) => x5*y;
            Action func6 = () => Console.WriteLine("func 6");
            Func<int, int> func7 = delegate(int x6) { return x6 + 1; };
            Func<int> func8 = delegate { return 1 + 1; };

            result[0] = func1.Invoke(1);
            result[1] = func2.Invoke(2);
            result[2] = func3.Invoke(3);
            result[3] = func4.Invoke(4);
            result[4] = func5.Invoke(5, 6);
            func6.Invoke();
            result[5] = func7.Invoke(1);
            result[6] = func8.Invoke();

            return result;
        }

        private void FunctionLambda_Check()
        {
            string testName = "FunctionLambda_Check";
            bool condition = true;
            Program.Start_Check(testName);

            int[] var1 = FunctionLambda();
            int[] var2 = FunctionLambda_0();
            for (int i = 0; i < var1.Count(); i++)
            {
                if (var1[i] != var2[i])
                    condition = false;
            }

            Program.End_Check(testName, condition);
        }


        #endregion



        public static void RunLambdaTests()
        {
            LambdaTests lt = new LambdaTests();
//            lt.ListIndexLambda_Check();
//            lt.FunctionLambda_Check();
        }
   }

}
