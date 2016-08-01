using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCalculator.Performance.ForLoop
{
   

    class ForLoop_op4_in1_0
    {
        private static string TITLE = "ForLoop_op4_in1";
        private Car car = new Car("invocation-check-car", 4);

        public static int WARMUP;
        public static int ITERATIONS;
        public static int NUMBER_OF_LOOPS;
        public static int NUMBER_OF_TESTS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            ForLoop_op4_in1_0 lt = new ForLoop_op4_in1_0();
            time_warmup.Clear();
            time_run.Clear();

            lt.Profile();

//            lt.ForLoop_Check();

        }

        public static void PrintTimes()
        {
            foreach (var log in time_warmup)
            {
                Output(log);
            }

            foreach (var log in time_run)
            {
                Output(log);
            }

            Output("=============================");
            Output("=============================");
        }

        private void Profile()
        {

            string result = "";

            result += "t_original";
            result += "     t_method";
            result += "     t_class";
            result += "     t_method_junk";
            result += "     t_class_junk";
            result += " " + "\n";


            for (int i = 0; i < NUMBER_OF_TESTS; i++)
            {
                Console.WriteLine(i + " ##############");
                Debug.WriteLine(i + " ##############");
                string t_original = Time_Operation(i+" , "+ TITLE, ForSimple_Array_obfuscated_op4_in1);

                result += " " + t_original;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);

            PrintTimes();
        }


        private int ReturnArg_Array(int arg)
        {
            return arg;
        }

        private string ForSimple_Array_original(int b)
        {
            string sum = "" + 3 + 4 + "";
            var p1 = car.GetEngine().GetPistons().First().GetSize();
            sum += "[" + p1 + "]";
            sum += car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1).ToString();

            string r = "";
            string[] dst = new string[b];
            for (int i = 0; i < ReturnArg_Array(b); i++)
            {
                sum += "_" + i + "_";
                sum += "~";
                r += sum + "#";
                dst[i] = sum;
            }

            sum += "#" + dst.Length;
            return sum;
        }


        private void ForLoop_Check()
        {
            string testName = "Performance_check#"+ TITLE;
            Program.Start_Check(testName);
            bool condition = true;

            int b = 5; //number of loops
            string oracle2 = ForSimple_Array_original(b);
            string virt21 = ForSimple_Array_obfuscated_op4_in1(b);
            Debug.Assert(virt21.Equals(oracle2), "virt21");
            
            condition = virt21.Equals(oracle2);
            Program.End_Check(testName, condition);
        }

        private string ForSimple_Array_obfuscated_op4_in1(int b)
        {
            //Virtualization variables
            int[] code = new int[100613];
            object[] data = new object[4354];
            int vpc = 20;

            //Data init
            data[1499] = b; //b 
            data[3036] = ""; //"" constant
            data[3778] = 3; //3 constant
            data[1643] = 4; //4 constant
            data[3799] = "["; //"[" constant
            data[2195] = "]"; //"]" constant
            data[72] = 1; //1 constant
            data[3798] = 0; //0 constant
            data[963] = "_"; //"_" constant
            data[1414] = "~"; //"~" constant
            data[2515] = "#"; //"#" constant
            data[1725] = 362158193; //sum 
            data[984] = (ConsoleCalculator.Engine)null; //invocationTemp_0 
            data[3132] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
            data[3723] = (ConsoleCalculator.Piston)null; //invocationTemp_2 
            data[394] = (double)0.537795374420376; //p1 
            data[623] = (ConsoleCalculator.Engine)null; //invocationTemp_3 
            data[1514] = (ConsoleCalculator.Engine)null; //invocationTemp_4 
            data[1195] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_5 
            data[3611] = 117; //memberTemp_0 
            data[770] = (ConsoleCalculator.Piston)null; //invocationTemp_6 
            data[1845] = 374684910; //invocationTemp_7 
            data[247] = 362155776; //r 
            data[3015] = (string[])null; //dst 
            data[2617] = -214; //var_forIndex_0 
            data[587] = -762; //invocationTemp_8 
            data[2360] = false; //var_whileCondition_0 
            data[1827] = 151; //invocationTemp_9 
            data[1276] = 995; //memberTemp_1 
            data[343] = 699; //jmpWhileDestinationName_343 constant
            data[1271] = 69; //while_GoTo_True_1271 constant
            data[3065] = 573; //while_GoTo_False_3065 constant
            data[148] = -573; //while_FalseBlockSkip_148 constant

            //Code init

            code[20] = 3746; //ExpressionStatement_0 # ExpressionStatement_0
            code[34] = 1725; //sum
            code[46] = 3036; //""
            code[33] = 3778; //3
            code[13] = 1643; //4
            code[35] = 3036; //""

            code[93] = 5631; //ExpressionStatement_1 # ExpressionStatement_1
            code[107] = 984; //invocationTemp_0

            code[149] = 6837; //ExpressionStatement_2 # ExpressionStatement_2
            code[144] = 3132; //invocationTemp_1
            code[174] = 984; //invocationTemp_0

            code[202] = 6699; //ExpressionStatement_3 # ExpressionStatement_3
            code[188] = 3723; //invocationTemp_2
            code[227] = 3132; //invocationTemp_1

            code[262] = 9219; //ExpressionStatement_4 # ExpressionStatement_4
            code[251] = 394; //p1
            code[279] = 3723; //invocationTemp_2

            code[327] = 9627; //ExpressionStatement_5 # ExpressionStatement_5
            code[338] = 1725; //sum
            code[318] = 1725; //sum
            code[343] = 3799; //"["
            code[320] = 394; //p1
            code[313] = 2195; //"]"

            code[393] = 5631; //ExpressionStatement_1 # ExpressionStatement_6
            code[407] = 623; //invocationTemp_3

            code[449] = 5631; //ExpressionStatement_1 # ExpressionStatement_7
            code[463] = 1514; //invocationTemp_4

            code[505] = 6837; //ExpressionStatement_2 # ExpressionStatement_8
            code[500] = 1195; //invocationTemp_5
            code[530] = 1514; //invocationTemp_4

            code[558] = 2964; //ExpressionStatement_9 # ExpressionStatement_9
            code[567] = 3611; //memberTemp_0
            code[560] = 1195; //invocationTemp_5

            code[612] = 2738; //ExpressionStatement_10 # ExpressionStatement_10
            code[607] = 770; //invocationTemp_6
            code[592] = 623; //invocationTemp_3
            code[595] = 3611; //memberTemp_0
            code[606] = 72; //1

            code[673] = 8700; //ExpressionStatement_11 # ExpressionStatement_11
            code[663] = 1845; //invocationTemp_7
            code[664] = 770; //invocationTemp_6

            code[732] = 3293; //ExpressionStatement_12 # ExpressionStatement_12
            code[723] = 1725; //sum
            code[735] = 1725; //sum
            code[721] = 1845; //invocationTemp_7

            code[800] = 7795; //ExpressionStatement_13 # ExpressionStatement_13
            code[824] = 247; //r
            code[781] = 3036; //""

            code[869] = 2611; //ExpressionStatement_14 # ExpressionStatement_14
            code[886] = 3015; //dst
            code[859] = 1499; //b

            code[931] = 7795; //ExpressionStatement_13 # ExpressionStatement_15
            code[955] = 2617; //var_forIndex_0
            code[912] = 3798; //0

            code[1000] = 4735; //ExpressionStatement_16 # ExpressionStatement_16
            code[1006] = 587; //invocationTemp_8
            code[1002] = 1499; //b

            code[1058] = 7480; //ExpressionStatement_17 # ExpressionStatement_17
            code[1082] = 2360; //var_whileCondition_0
            code[1075] = 2617; //var_forIndex_0
            code[1074] = 587; //invocationTemp_8

            code[1117] = 1081; //WhileStatementSyntax_18 # WhileStatementSyntax_18
            code[1123] = 343; //jmpWhileDestinationName_343
            code[1140] = 2360; //var_whileCondition_0
            code[1099] = 1271; //while_GoTo_True_1271
            code[1133] = 3065; //while_GoTo_False_3065

            code[1186] = 6695; //ExpressionStatement_19 # ExpressionStatement_19
            code[1193] = 1725; //sum
            code[1205] = 1725; //sum
            code[1174] = 963; //"_"
            code[1172] = 2617; //var_forIndex_0
            code[1190] = 963; //"_"

            code[1257] = 3293; //ExpressionStatement_12 # ExpressionStatement_20
            code[1248] = 1725; //sum
            code[1260] = 1725; //sum
            code[1246] = 1414; //"~"

            code[1325] = 6821; //ExpressionStatement_21 # ExpressionStatement_21
            code[1352] = 247; //r
            code[1350] = 247; //r
            code[1339] = 1725; //sum
            code[1319] = 2515; //"#"

            code[1395] = 9150; //ExpressionStatement_22 # ExpressionStatement_22
            code[1396] = 3015; //dst
            code[1411] = 2617; //var_forIndex_0
            code[1379] = 1725; //sum

            code[1459] = 1977; //ExpressionStatement_23 # ExpressionStatement_23
            code[1460] = 2617; //var_forIndex_0
            code[1445] = 2617; //var_forIndex_0
            code[1478] = 72; //1

            code[1515] = 4735; //ExpressionStatement_16 # ExpressionStatement_24
            code[1521] = 1827; //invocationTemp_9
            code[1517] = 1499; //b

            code[1573] = 7480; //ExpressionStatement_17 # ExpressionStatement_25
            code[1597] = 2360; //var_whileCondition_0
            code[1590] = 2617; //var_forIndex_0
            code[1589] = 1827; //invocationTemp_9

            code[1632] = 1500; //ExpressionStatement_26 # ExpressionStatement_26
            code[1645] = 148; //while_FalseBlockSkip_148

            code[1690] = 2603; //ExpressionStatement_27 # ExpressionStatement_27
            code[1715] = 1276; //memberTemp_1
            code[1708] = 3015; //dst

            code[1753] = 4757; //ExpressionStatement_28 # ExpressionStatement_28
            code[1751] = 1725; //sum
            code[1780] = 1725; //sum
            code[1778] = 2515; //"#"
            code[1764] = 1276; //memberTemp_1

            code[1819] = 8067; //ReturnStatement_29 # ReturnStatement_29
            code[1812] = 1725; //sum

            return (string)InstanceInterpreterVirtualization_TraceLoopTests_3371_op4_in1(vpc, data, code);

        }

        private object InstanceInterpreterVirtualization_TraceLoopTests_3371_op4_in1(int vpc, object[] data, int[] code)
        {
            while (true)
            {
                switch (code[vpc])
                {
                    case 8067:  //frequency 1 ReturnStatement_29
                        return (string)data[code[vpc + (-7)]];
                        vpc += 67;
                    case 2738:  //frequency 1 ExpressionStatement_10
                        data[code[vpc + (-5)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (-20)]]).GetPiston((int)data[code[vpc + (-17)]] - (int)data[code[vpc + (-6)]]));
                        vpc += 61;
                        break;
                    default:  //frequency 0 
                        break;
                    case 6699:  //frequency 1 ExpressionStatement_3
                        data[code[vpc + (-14)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (25)]]).First());
                        vpc += 60;
                        break;
                    case 2603:  //frequency 1 ExpressionStatement_27
                        data[code[vpc + (25)]] = ((string[])data[code[vpc + (18)]]).Length;
                        vpc += 63;
                        break;
                    case 3293:  //frequency 2 ExpressionStatement_12
                        data[code[vpc + (-9)]] = (string)data[code[vpc + (3)]] + (string)data[code[vpc + (-11)]];
                        vpc += 68;
                        break;
                    case 8700:  //frequency 1 ExpressionStatement_11
                        data[code[vpc + (-10)]] = ((ConsoleCalculator.Piston)data[code[vpc + (-9)]]).ToString();
                        vpc += 59;
                        break;
                    case 1081:  //frequency 1 WhileStatementSyntax_18
                        data[code[vpc + (6)]] = (bool)data[code[vpc + (23)]] ? (int)data[code[vpc + (-18)]] : (int)data[code[vpc + (16)]];
                        vpc += (int)data[code[vpc + (6)]];
                        break;
                    case 4735:  //frequency 2 ExpressionStatement_16
                        data[code[vpc + (6)]] = ReturnArg_Array((int)data[code[vpc + (2)]]);
                        vpc += 58;
                        break;
                    case 2611:  //frequency 1 ExpressionStatement_14
                        data[code[vpc + (17)]] = (string[])(new string[(int)data[code[vpc + (-10)]]]);
                        vpc += 62;
                        break;
                    case 6821:  //frequency 1 ExpressionStatement_21
                        data[code[vpc + (27)]] = (string)data[code[vpc + (25)]] + (string)data[code[vpc + (14)]] + (string)data[code[vpc + (-6)]];
                        vpc += 70;
                        break;
                    case 1500:  //frequency 1 ExpressionStatement_26
                        vpc += (int)data[code[vpc + (13)]];
                        vpc += 58;
                        break;
                    case 9219:  //frequency 1 ExpressionStatement_4
                        data[code[vpc + (-11)]] = ((ConsoleCalculator.Piston)data[code[vpc + (17)]]).GetSize();
                        vpc += 65;
                        break;
                    case 4757:  //frequency 1 ExpressionStatement_28
                        data[code[vpc + (-2)]] = (string)data[code[vpc + (27)]] + (string)data[code[vpc + (25)]] + (int)data[code[vpc + (11)]];
                        vpc += 66;
                        break;
                    case 5631:  //frequency 3 ExpressionStatement_1
                        data[code[vpc + (14)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                        vpc += 56;
                        break;
                    case 6837:  //frequency 2 ExpressionStatement_2
                        data[code[vpc + (-5)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (25)]]).GetPistons());
                        vpc += 53;
                        break;
                    case 9627:  //frequency 1 ExpressionStatement_5
                        data[code[vpc + (11)]] = (string)data[code[vpc + (-9)]] + (string)data[code[vpc + (16)]] + (double)data[code[vpc + (-7)]] + (string)data[code[vpc + (-14)]];
                        vpc += 66;
                        break;
                    case 6695:  //frequency 1 ExpressionStatement_19
                        data[code[vpc + (7)]] = (string)data[code[vpc + (19)]] + (string)data[code[vpc + (-12)]] + (int)data[code[vpc + (-14)]] + (string)data[code[vpc + (4)]];
                        vpc += 71;
                        break;
                    case 3746:  //frequency 1 ExpressionStatement_0
                        data[code[vpc + (14)]] = (string)data[code[vpc + (26)]] + (int)data[code[vpc + (13)]] + (int)data[code[vpc + (-7)]] + (string)data[code[vpc + (15)]];
                        vpc += 73;
                        break;
                    case 7795:  //frequency 2 ExpressionStatement_13
                        data[code[vpc + (24)]] = data[code[vpc + (-19)]];
                        vpc += 69;
                        break;
                    case 9150:  //frequency 1 ExpressionStatement_22
                        ((string[])data[code[vpc + (1)]])[(int)data[code[vpc + (16)]]] = (string)data[code[vpc + (-16)]];
                        vpc += 64;
                        break;
                    case 2964:  //frequency 1 ExpressionStatement_9
                        data[code[vpc + (9)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (2)]]).Count;
                        vpc += 54;
                        break;
                    case 7480:  //frequency 2 ExpressionStatement_17
                        data[code[vpc + (24)]] = (int)data[code[vpc + (17)]] < (int)data[code[vpc + (16)]];
                        vpc += 59;
                        break;
                    case 1977:  //frequency 1 ExpressionStatement_23
                        data[code[vpc + (1)]] = (int)data[code[vpc + (-14)]] + (int)data[code[vpc + (19)]];
                        vpc += 56;
                        break;
                }
            }

            return null;
        }


        public static string Time_Operation(string id, Func<int, string> method)
        {

            int op = 0;
            string log = id + " warming ... " + WARMUP + " times " ;
            Output(log);

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < WARMUP; i++)
            {
                method(NUMBER_OF_LOOPS);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("   {0}    , sec", timespan.TotalSeconds);
            log = id + " " + "  warmed up in,   " + time;
            Output(log);
            time_warmup.Add(log);

            log = id + " running ... " + ITERATIONS + " times " ;
            Output(log);
            timer = Stopwatch.StartNew();
            for (int j = 0; j < ITERATIONS; j++)
            {
                method(NUMBER_OF_LOOPS);
            }
            timer.Stop();
            timespan = timer.Elapsed;

            time = String.Format("  {0}     , sec", timespan.TotalSeconds);
            log = id + " " + " finished in,     " + time;
            Output(log);
            time_run.Add(log);
            Output("\n");
            return time;
        }

        private static void Output(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }



    }
}