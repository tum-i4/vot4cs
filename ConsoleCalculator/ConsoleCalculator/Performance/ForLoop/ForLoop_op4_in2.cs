using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCalculator.Performance.ForLoop
{
   

    class ForLoop_op4_in2
    {
        private static string TITLE = "ForLoop_op4_in2";
        private Car car = new Car("invocation-check-car", 4);

        public static int WARMUP;
        public static int ITERATIONS;
        public static int NUMBER_OF_LOOPS;
        public static int NUMBER_OF_TESTS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            ForLoop_op4_in2 lt = new ForLoop_op4_in2();
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
                string t_original = Time_Operation(i+" , "+ TITLE, ForSimple_Array_obfuscated2_op4_in2);

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
        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string ForSimple_Array_obfuscated2_op4_in2(int b)
        {
            //Virtualization variables
            int[] code = new int[100869];
            object[] data = new object[4244];
            int vpc = 36;

            //Data init
            data[2311] = b; //b 
            data[2367] = ""; //"" constant
            data[835] = 3; //3 constant
            data[1382] = 4; //4 constant
            data[746] = 1; //1 constant
            data[2829] = 0; //0 constant
            data[873] = "_"; //"_" constant
            data[1281] = "~"; //"~" constant
            data[3485] = "#"; //"#" constant
            data[3249] = "["; //"[" constant
            data[1847] = "]"; //"]" constant
            data[2921] = 253115470; //sum 
            data[2135] = (ConsoleCalculator.Engine)null; //invocationTemp_0 
            data[2193] = (ConsoleCalculator.Engine)null; //invocationTemp_1 
            data[3263] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_2 
            data[1603] = -352; //memberTemp_0 
            data[64] = (ConsoleCalculator.Piston)null; //invocationTemp_3 
            data[2924] = 529691550; //invocationTemp_4 
            data[906] = 448189483; //r 
            data[1232] = (string[])null; //dst 
            data[3363] = -591; //var_forIndex_0 
            data[998] = -127; //invocationTemp_5 
            data[1935] = false; //var_whileCondition_0 
            data[2491] = (ConsoleCalculator.Engine)null; //invocationTemp_6 
            data[3865] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_7 
            data[105] = (ConsoleCalculator.Piston)null; //invocationTemp_8 
            data[351] = (double)0.0763740581815942; //p1 
            data[2348] = -481; //memberTemp_1 
            data[2058] = -893; //invocationTemp_9 
            data[309] = 503; //memberTemp_2 
            data[2610] = 420; //jmpWhileDestinationName_2610 constant
            data[1863] = 67; //while_GoTo_True_1863 constant
            data[3304] = 1014; //while_GoTo_False_3304 constant
            data[2669] = -1014; //while_FalseBlockSkip_2669 constant

            //Code init

            code[36] = 8744; //ExpressionStatement_0 # ExpressionStatement_0
            code[41] = 2921; //sum
            code[58] = 2367; //""
            code[20] = 835; //3
            code[29] = 1382; //4
            code[33] = 2367; //""

            code[102] = 3603; //ExpressionStatement_1 # ExpressionStatement_1
            code[91] = 2135; //invocationTemp_0

            code[162] = 3603; //ExpressionStatement_1 # ExpressionStatement_2
            code[151] = 2193; //invocationTemp_1

            code[222] = 5550; //ExpressionStatement_3 # ExpressionStatement_3
            code[240] = 3263; //invocationTemp_2
            code[220] = 2193; //invocationTemp_1

            code[286] = 6602; //ExpressionStatement_4 # ExpressionStatement_4
            code[296] = 1603; //memberTemp_0
            code[285] = 3263; //invocationTemp_2

            code[348] = 1972; //ExpressionStatement_5 # ExpressionStatement_5
            code[346] = 64; //invocationTemp_3
            code[336] = 2135; //invocationTemp_0
            code[358] = 1603; //memberTemp_0
            code[359] = 746; //1

            code[413] = 8147; //ExpressionStatement_6 # ExpressionStatement_6
            code[422] = 2924; //invocationTemp_4
            code[417] = 64; //invocationTemp_3

            code[478] = 9852; //ExpressionStatement_7 # ExpressionStatement_7
            code[485] = 2921; //sum
            code[504] = 2921; //sum
            code[480] = 2924; //invocationTemp_4

            code[537] = 3768; //ExpressionStatement_8 # ExpressionStatement_8
            code[555] = 906; //r
            code[531] = 2367; //""

            code[600] = 4038; //ExpressionStatement_9 # ExpressionStatement_9
            code[602] = 1232; //dst
            code[620] = 2311; //b

            code[662] = 3768; //ExpressionStatement_8 # ExpressionStatement_10
            code[680] = 3363; //var_forIndex_0
            code[656] = 2829; //0

            code[725] = 5836; //ExpressionStatement_11 # ExpressionStatement_11
            code[736] = 998; //invocationTemp_5
            code[728] = 2311; //b

            code[783] = 4592; //ExpressionStatement_12 # ExpressionStatement_12
            code[798] = 1935; //var_whileCondition_0
            code[768] = 3363; //var_forIndex_0
            code[799] = 998; //invocationTemp_5

            code[841] = 5350; //WhileStatementSyntax_13 # WhileStatementSyntax_13
            code[858] = 2610; //jmpWhileDestinationName_2610
            code[847] = 1935; //var_whileCondition_0
            code[828] = 1863; //while_GoTo_True_1863
            code[862] = 3304; //while_GoTo_False_3304

            code[908] = 3761; //ExpressionStatement_14 # ExpressionStatement_14
            code[915] = 2921; //sum
            code[928] = 2921; //sum
            code[902] = 873; //"_"
            code[890] = 3363; //var_forIndex_0
            code[919] = 873; //"_"

            code[979] = 9852; //ExpressionStatement_7 # ExpressionStatement_15
            code[986] = 2921; //sum
            code[1005] = 2921; //sum
            code[981] = 1281; //"~"

            code[1038] = 6991; //ExpressionStatement_16 # ExpressionStatement_16
            code[1023] = 906; //r
            code[1030] = 906; //r
            code[1060] = 2921; //sum
            code[1028] = 3485; //"#"

            code[1099] = 3603; //ExpressionStatement_1 # ExpressionStatement_17
            code[1088] = 2491; //invocationTemp_6

            code[1159] = 5550; //ExpressionStatement_3 # ExpressionStatement_18
            code[1177] = 3865; //invocationTemp_7
            code[1157] = 2491; //invocationTemp_6

            code[1223] = 3067; //ExpressionStatement_19 # ExpressionStatement_19
            code[1209] = 105; //invocationTemp_8
            code[1249] = 3865; //invocationTemp_7

            code[1281] = 1734; //ExpressionStatement_20 # ExpressionStatement_20
            code[1288] = 351; //p1
            code[1270] = 105; //invocationTemp_8

            code[1348] = 8188; //ExpressionStatement_21 # ExpressionStatement_21
            code[1343] = 906; //r
            code[1361] = 906; //r
            code[1346] = 3249; //"["
            code[1344] = 351; //p1
            code[1359] = 1847; //"]"

            code[1409] = 6308; //ExpressionStatement_22 # ExpressionStatement_22
            code[1422] = 2348; //memberTemp_1
            code[1412] = 906; //r

            code[1480] = 5954; //ExpressionStatement_23 # ExpressionStatement_23
            code[1474] = 2921; //sum
            code[1484] = 2921; //sum
            code[1491] = 2348; //memberTemp_1

            code[1549] = 6007; //ExpressionStatement_24 # ExpressionStatement_24
            code[1554] = 1232; //dst
            code[1570] = 3363; //var_forIndex_0
            code[1555] = 2921; //sum

            code[1612] = 7907; //ExpressionStatement_25 # ExpressionStatement_25
            code[1594] = 3363; //var_forIndex_0
            code[1629] = 3363; //var_forIndex_0
            code[1634] = 746; //1

            code[1674] = 5836; //ExpressionStatement_11 # ExpressionStatement_26
            code[1685] = 2058; //invocationTemp_9
            code[1677] = 2311; //b

            code[1732] = 4592; //ExpressionStatement_12 # ExpressionStatement_27
            code[1747] = 1935; //var_whileCondition_0
            code[1717] = 3363; //var_forIndex_0
            code[1748] = 2058; //invocationTemp_9

            code[1790] = 4169; //ExpressionStatement_28 # ExpressionStatement_28
            code[1807] = 2669; //while_FalseBlockSkip_2669

            code[1855] = 6067; //ExpressionStatement_29 # ExpressionStatement_29
            code[1850] = 309; //memberTemp_2
            code[1863] = 1232; //dst

            code[1908] = 6045; //ExpressionStatement_30 # ExpressionStatement_30
            code[1900] = 2921; //sum
            code[1927] = 2921; //sum
            code[1905] = 3485; //"#"
            code[1891] = 309; //memberTemp_2

            code[1969] = 1508; //ReturnStatement_31 # ReturnStatement_31
            code[1988] = 2921; //sum

            return (string)InstanceInterpreterVirtualization_TraceLoopTests_913_2_op4_in2(vpc, data, code);

        }



        private object InstanceInterpreterVirtualization_TraceLoopTests_913_2_op4_in2(int vpc, object[] data, int[] code)
        {
            while (true)
            {
                switch (code[vpc])
                {
                    case 9852:  //frequency 2 ExpressionStatement_7
                        data[code[vpc + (7)]] = (string)data[code[vpc + (26)]] + (string)data[code[vpc + (2)]];
                        vpc += 59;
                        break;
                    default:  //frequency 0 
                        break;
                    case 6067:  //frequency 1 ExpressionStatement_29
                        data[code[vpc + (-5)]] = ((string[])data[code[vpc + (8)]]).Length;
                        vpc += 53;
                        break;
                    case 8188:  //frequency 1 ExpressionStatement_21
                        data[code[vpc + (-5)]] = (string)data[code[vpc + (13)]] + (string)data[code[vpc + (-2)]] + (double)data[code[vpc + (-4)]] + (string)data[code[vpc + (11)]];
                        vpc += 61;
                        break;
                    case 6007:  //frequency 1 ExpressionStatement_24
                        ((string[])data[code[vpc + (5)]])[(int)data[code[vpc + (21)]]] = (string)data[code[vpc + (6)]];
                        vpc += 63;
                        break;
                    case 7907:  //frequency 1 ExpressionStatement_25
                        data[code[vpc + (-18)]] = (int)data[code[vpc + (17)]] + (int)data[code[vpc + (22)]];
                        vpc += 62;
                        break;
                    case 6991:  //frequency 1 ExpressionStatement_16
                        data[code[vpc + (-15)]] = (string)data[code[vpc + (-8)]] + (string)data[code[vpc + (22)]] + (string)data[code[vpc + (-10)]];
                        vpc += 61;
                        break;
                    case 1508:  //frequency 1 ReturnStatement_31
                        return (string)data[code[vpc + (19)]];
                        vpc += 68;
                    case 6045:  //frequency 1 ExpressionStatement_30
                        data[code[vpc + (-8)]] = (string)data[code[vpc + (19)]] + (string)data[code[vpc + (-3)]] + (int)data[code[vpc + (-17)]];
                        vpc += 61;
                        break;
                    case 4169:  //frequency 1 ExpressionStatement_28
                        vpc += (int)data[code[vpc + (17)]];
                        vpc += 65;
                        break;
                    case 5350:  //frequency 1 WhileStatementSyntax_13
                        data[code[vpc + (17)]] = (bool)data[code[vpc + (6)]] ? (int)data[code[vpc + (-13)]] : (int)data[code[vpc + (21)]];
                        vpc += (int)data[code[vpc + (17)]];
                        break;
                    case 4592:  //frequency 2 ExpressionStatement_12
                        data[code[vpc + (15)]] = (int)data[code[vpc + (-15)]] < (int)data[code[vpc + (16)]];
                        vpc += 58;
                        break;
                    case 6602:  //frequency 1 ExpressionStatement_4
                        data[code[vpc + (10)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-1)]]).Count;
                        vpc += 62;
                        break;
                    case 8147:  //frequency 1 ExpressionStatement_6
                        data[code[vpc + (9)]] = ((ConsoleCalculator.Piston)data[code[vpc + (4)]]).ToString();
                        vpc += 65;
                        break;
                    case 3603:  //frequency 3 ExpressionStatement_1
                        data[code[vpc + (-11)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                        vpc += 60;
                        break;
                    case 3768:  //frequency 2 ExpressionStatement_8
                        data[code[vpc + (18)]] = data[code[vpc + (-6)]];
                        vpc += 63;
                        break;
                    case 5550:  //frequency 2 ExpressionStatement_3
                        data[code[vpc + (18)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (-2)]]).GetPistons());
                        vpc += 64;
                        break;
                    case 5836:  //frequency 2 ExpressionStatement_11
                        data[code[vpc + (11)]] = ReturnArg_Array((int)data[code[vpc + (3)]]);
                        vpc += 58;
                        break;
                    case 6308:  //frequency 1 ExpressionStatement_22
                        data[code[vpc + (13)]] = ((string)data[code[vpc + (3)]]).Length;
                        vpc += 71;
                        break;
                    case 8744:  //frequency 1 ExpressionStatement_0
                        data[code[vpc + (5)]] = (string)data[code[vpc + (22)]] + (int)data[code[vpc + (-16)]] + (int)data[code[vpc + (-7)]] + (string)data[code[vpc + (-3)]];
                        vpc += 66;
                        break;
                    case 5954:  //frequency 1 ExpressionStatement_23
                        data[code[vpc + (-6)]] = (string)data[code[vpc + (4)]] + (int)data[code[vpc + (11)]];
                        vpc += 69;
                        break;
                    case 3761:  //frequency 1 ExpressionStatement_14
                        data[code[vpc + (7)]] = (string)data[code[vpc + (20)]] + (string)data[code[vpc + (-6)]] + (int)data[code[vpc + (-18)]] + (string)data[code[vpc + (11)]];
                        vpc += 71;
                        break;
                    case 3067:  //frequency 1 ExpressionStatement_19
                        data[code[vpc + (-14)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (26)]]).First());
                        vpc += 58;
                        break;
                    case 1734:  //frequency 1 ExpressionStatement_20
                        data[code[vpc + (7)]] = ((ConsoleCalculator.Piston)data[code[vpc + (-11)]]).GetSize();
                        vpc += 67;
                        break;
                    case 1972:  //frequency 1 ExpressionStatement_5
                        data[code[vpc + (-2)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (-12)]]).GetPiston((int)data[code[vpc + (10)]] - (int)data[code[vpc + (11)]]));
                        vpc += 65;
                        break;
                    case 4038:  //frequency 1 ExpressionStatement_9
                        data[code[vpc + (2)]] = (string[])(new string[(int)data[code[vpc + (20)]]]);
                        vpc += 62;
                        break;
                }
            }

            return null;
        }


        private string ForSimple_Array_original_in(int b)
        {
            string sum = "" + 3 + 4 + "";

            sum += car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1).ToString();

            string r = "";
            string[] dst = new string[b];
            for (int i = 0; i < ReturnArg_Array(b); i++)
            {
                sum += "_" + i + "_";
                sum += "~";
                r += sum + "#";
                var p1 = car.GetEngine().GetPistons().First().GetSize();
                r += "[" + p1 + "]";
                sum += r.Length;
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
            string oracle2 = ForSimple_Array_original_in(b);
            string virt21 = ForSimple_Array_obfuscated2_op4_in2(b);
            Debug.Assert(virt21.Equals(oracle2), "virt21");
            
            condition = virt21.Equals(oracle2);
            Program.End_Check(testName, condition);
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