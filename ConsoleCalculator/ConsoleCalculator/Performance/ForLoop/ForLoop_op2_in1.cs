using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCalculator.Performance.ForLoop
{
   

    class ForLoop_op2_in1
    {
        private static string TITLE = "ForLoop_op2_in1";
        private Car car = new Car("invocation-check-car", 4);

        public static int WARMUP;
        public static int ITERATIONS;
        public static int NUMBER_OF_LOOPS;
        public static int NUMBER_OF_TESTS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            ForLoop_op2_in1 lt = new ForLoop_op2_in1();
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
                string t_original = Time_Operation(i+" , "+ TITLE, ForSimple_Array_obfuscated_op2_in1);

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



        private string ForSimple_Array_obfuscated_op2_in1(int b)
        {
            //Virtualization variables
            int[] code = new int[100285];
            object[] data = new object[4187];
            int vpc = 44;

            //Data init
            data[92] = b; //b 
            data[2364] = ""; //"" constant
            data[115] = 3; //3 constant
            data[1593] = 4; //4 constant
            data[3975] = "["; //"[" constant
            data[1280] = "]"; //"]" constant
            data[639] = 1; //1 constant
            data[2209] = 0; //0 constant
            data[2845] = "_"; //"_" constant
            data[416] = "~"; //"~" constant
            data[146] = "#"; //"#" constant
            data[3329] = 861137969; //addTemp_0 
            data[1424] = 426817913; //addTemp_1 
            data[2032] = 1090936824; //sum 
            data[3023] = (ConsoleCalculator.Engine)null; //invocationTemp_0 
            data[3639] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
            data[2752] = (ConsoleCalculator.Piston)null; //invocationTemp_2 
            data[1393] = (double)0.792997966889757; //p1 
            data[3658] = 1720645340; //addTemp_2 
            data[1742] = 1088886007; //addTemp_3 
            data[1371] = (ConsoleCalculator.Engine)null; //invocationTemp_3 
            data[464] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_4 
            data[3405] = 430; //memberTemp_0 
            data[89] = 690; //addTemp_4 
            data[540] = (ConsoleCalculator.Engine)null; //invocationTemp_5 
            data[633] = (ConsoleCalculator.Piston)null; //invocationTemp_6 
            data[3643] = 33887365; //invocationTemp_7 
            data[2869] = 179759393; //r 
            data[2173] = (string[])null; //dst 
            data[905] = 525; //var_forIndex_0 
            data[1525] = 629; //invocationTemp_8 
            data[3690] = false; //var_whileCondition_0 
            data[1760] = 748259412; //addTemp_5 
            data[1876] = 1366923731; //addTemp_6 
            data[3462] = 1837547023; //addTemp_7 
            data[3477] = 752; //invocationTemp_9 
            data[1817] = -877; //memberTemp_1 
            data[1135] = 450921265; //addTemp_8 
            data[3757] = -812; //jmpWhileDestinationName_3757 constant
            data[2785] = 69; //while_GoTo_True_2785 constant
            data[1722] = 810; //while_GoTo_False_1722 constant
            data[903] = -810; //while_FalseBlockSkip_903 constant

            //Code init

            code[44] = 7697; //ExpressionStatement_0 # ExpressionStatement_0
            code[27] = 3329; //addTemp_0
            code[58] = 2364; //""
            code[47] = 115; //3

            code[115] = 7697; //ExpressionStatement_0 # ExpressionStatement_1
            code[98] = 1424; //addTemp_1
            code[129] = 3329; //addTemp_0
            code[118] = 1593; //4

            code[186] = 7376; //ExpressionStatement_2 # ExpressionStatement_2
            code[197] = 2032; //sum
            code[204] = 1424; //addTemp_1
            code[212] = 2364; //""

            code[257] = 5089; //ExpressionStatement_3 # ExpressionStatement_3
            code[273] = 3023; //invocationTemp_0

            code[326] = 3369; //ExpressionStatement_4 # ExpressionStatement_4
            code[328] = 3639; //invocationTemp_1
            code[306] = 3023; //invocationTemp_0

            code[394] = 7503; //ExpressionStatement_5 # ExpressionStatement_5
            code[393] = 2752; //invocationTemp_2
            code[418] = 3639; //invocationTemp_1

            code[448] = 8977; //ExpressionStatement_6 # ExpressionStatement_6
            code[433] = 1393; //p1
            code[459] = 2752; //invocationTemp_2

            code[509] = 6388; //ExpressionStatement_7 # ExpressionStatement_7
            code[527] = 3658; //addTemp_2
            code[505] = 3975; //"["
            code[522] = 1393; //p1

            code[565] = 7376; //ExpressionStatement_2 # ExpressionStatement_8
            code[576] = 1742; //addTemp_3
            code[583] = 3658; //addTemp_2
            code[591] = 1280; //"]"

            code[636] = 7376; //ExpressionStatement_2 # ExpressionStatement_9
            code[647] = 2032; //sum
            code[654] = 2032; //sum
            code[662] = 1742; //addTemp_3

            code[707] = 5089; //ExpressionStatement_3 # ExpressionStatement_10
            code[723] = 1371; //invocationTemp_3

            code[776] = 3369; //ExpressionStatement_4 # ExpressionStatement_11
            code[778] = 464; //invocationTemp_4
            code[756] = 1371; //invocationTemp_3

            code[844] = 6463; //ExpressionStatement_12 # ExpressionStatement_12
            code[839] = 3405; //memberTemp_0
            code[824] = 464; //invocationTemp_4

            code[915] = 2167; //ExpressionStatement_13 # ExpressionStatement_13
            code[896] = 89; //addTemp_4
            code[938] = 3405; //memberTemp_0
            code[932] = 639; //1

            code[976] = 5089; //ExpressionStatement_3 # ExpressionStatement_14
            code[992] = 540; //invocationTemp_5

            code[1045] = 4181; //ExpressionStatement_15 # ExpressionStatement_15
            code[1028] = 633; //invocationTemp_6
            code[1051] = 540; //invocationTemp_5
            code[1035] = 89; //addTemp_4

            code[1109] = 5003; //ExpressionStatement_16 # ExpressionStatement_16
            code[1122] = 3643; //invocationTemp_7
            code[1103] = 633; //invocationTemp_6

            code[1165] = 7376; //ExpressionStatement_2 # ExpressionStatement_17
            code[1176] = 2032; //sum
            code[1183] = 2032; //sum
            code[1191] = 3643; //invocationTemp_7

            code[1236] = 7595; //ExpressionStatement_18 # ExpressionStatement_18
            code[1249] = 2869; //r
            code[1245] = 2364; //""

            code[1307] = 4138; //ExpressionStatement_19 # ExpressionStatement_19
            code[1305] = 2173; //dst
            code[1331] = 92; //b

            code[1367] = 7595; //ExpressionStatement_18 # ExpressionStatement_20
            code[1380] = 905; //var_forIndex_0
            code[1376] = 2209; //0

            code[1438] = 1729; //ExpressionStatement_21 # ExpressionStatement_21
            code[1452] = 1525; //invocationTemp_8
            code[1455] = 92; //b

            code[1507] = 4452; //ExpressionStatement_22 # ExpressionStatement_22
            code[1524] = 3690; //var_whileCondition_0
            code[1512] = 905; //var_forIndex_0
            code[1530] = 1525; //invocationTemp_8

            code[1574] = 4795; //WhileStatementSyntax_23 # WhileStatementSyntax_23
            code[1563] = 3757; //jmpWhileDestinationName_3757
            code[1583] = 3690; //var_whileCondition_0
            code[1596] = 2785; //while_GoTo_True_2785
            code[1571] = 1722; //while_GoTo_False_1722

            code[1643] = 7697; //ExpressionStatement_0 # ExpressionStatement_24
            code[1626] = 1760; //addTemp_5
            code[1657] = 2845; //"_"
            code[1646] = 905; //var_forIndex_0

            code[1714] = 7376; //ExpressionStatement_2 # ExpressionStatement_25
            code[1725] = 1876; //addTemp_6
            code[1732] = 1760; //addTemp_5
            code[1740] = 2845; //"_"

            code[1785] = 7376; //ExpressionStatement_2 # ExpressionStatement_26
            code[1796] = 2032; //sum
            code[1803] = 2032; //sum
            code[1811] = 1876; //addTemp_6

            code[1856] = 7376; //ExpressionStatement_2 # ExpressionStatement_27
            code[1867] = 2032; //sum
            code[1874] = 2032; //sum
            code[1882] = 416; //"~"

            code[1927] = 7376; //ExpressionStatement_2 # ExpressionStatement_28
            code[1938] = 3462; //addTemp_7
            code[1945] = 2032; //sum
            code[1953] = 146; //"#"

            code[1998] = 7376; //ExpressionStatement_2 # ExpressionStatement_29
            code[2009] = 2869; //r
            code[2016] = 2869; //r
            code[2024] = 3462; //addTemp_7

            code[2069] = 4327; //ExpressionStatement_30 # ExpressionStatement_30
            code[2060] = 2173; //dst
            code[2071] = 905; //var_forIndex_0
            code[2098] = 2032; //sum

            code[2133] = 5722; //ExpressionStatement_31 # ExpressionStatement_31
            code[2134] = 905; //var_forIndex_0
            code[2155] = 905; //var_forIndex_0
            code[2161] = 639; //1

            code[2187] = 1729; //ExpressionStatement_21 # ExpressionStatement_32
            code[2201] = 3477; //invocationTemp_9
            code[2204] = 92; //b

            code[2256] = 4452; //ExpressionStatement_22 # ExpressionStatement_33
            code[2273] = 3690; //var_whileCondition_0
            code[2261] = 905; //var_forIndex_0
            code[2279] = 3477; //invocationTemp_9

            code[2323] = 1141; //ExpressionStatement_34 # ExpressionStatement_34
            code[2349] = 903; //while_FalseBlockSkip_903

            code[2384] = 5471; //ExpressionStatement_35 # ExpressionStatement_35
            code[2372] = 1817; //memberTemp_1
            code[2391] = 2173; //dst

            code[2440] = 7697; //ExpressionStatement_0 # ExpressionStatement_36
            code[2423] = 1135; //addTemp_8
            code[2454] = 146; //"#"
            code[2443] = 1817; //memberTemp_1

            code[2511] = 7376; //ExpressionStatement_2 # ExpressionStatement_37
            code[2522] = 2032; //sum
            code[2529] = 2032; //sum
            code[2537] = 1135; //addTemp_8

            code[2582] = 7418; //ReturnStatement_38 # ReturnStatement_38
            code[2591] = 2032; //sum

            return (string)InstanceInterpreterVirtualization_TraceLoopTests_3189_op2_in1(vpc, data, code);

        }


        private object InstanceInterpreterVirtualization_TraceLoopTests_3189_op2_in1(int vpc, object[] data, int[] code)
        {
            while (true)
            {
                switch (code[vpc])
                {
                    case 7697:  //frequency 4 ExpressionStatement_0
                        data[code[vpc + (-17)]] = (string)data[code[vpc + (14)]] + (int)data[code[vpc + (3)]];
                        vpc += 71;
                        break;
                    case 6463:  //frequency 1 ExpressionStatement_12
                        data[code[vpc + (-5)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-20)]]).Count;
                        vpc += 71;
                        break;
                    case 2167:  //frequency 1 ExpressionStatement_13
                        data[code[vpc + (-19)]] = (int)data[code[vpc + (23)]] - (int)data[code[vpc + (17)]];
                        vpc += 61;
                        break;
                    case 5089:  //frequency 3 ExpressionStatement_3
                        data[code[vpc + (16)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                        vpc += 69;
                        break;
                    case 4138:  //frequency 1 ExpressionStatement_19
                        data[code[vpc + (-2)]] = (string[])(new string[(int)data[code[vpc + (24)]]]);
                        vpc += 60;
                        break;
                    case 7595:  //frequency 2 ExpressionStatement_18
                        data[code[vpc + (13)]] = data[code[vpc + (9)]];
                        vpc += 71;
                        break;
                    default:  //frequency 0 
                        break;
                    case 7376:  //frequency 10 ExpressionStatement_2
                        data[code[vpc + (11)]] = (string)data[code[vpc + (18)]] + (string)data[code[vpc + (26)]];
                        vpc += 71;
                        break;
                    case 5722:  //frequency 1 ExpressionStatement_31
                        data[code[vpc + (1)]] = (int)data[code[vpc + (22)]] + (int)data[code[vpc + (28)]];
                        vpc += 54;
                        break;
                    case 5471:  //frequency 1 ExpressionStatement_35
                        data[code[vpc + (-12)]] = ((string[])data[code[vpc + (7)]]).Length;
                        vpc += 56;
                        break;
                    case 5003:  //frequency 1 ExpressionStatement_16
                        data[code[vpc + (13)]] = ((ConsoleCalculator.Piston)data[code[vpc + (-6)]]).ToString();
                        vpc += 56;
                        break;
                    case 7503:  //frequency 1 ExpressionStatement_5
                        data[code[vpc + (-1)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (24)]]).First());
                        vpc += 54;
                        break;
                    case 1141:  //frequency 1 ExpressionStatement_34
                        vpc += (int)data[code[vpc + (26)]];
                        vpc += 61;
                        break;
                    case 4795:  //frequency 1 WhileStatementSyntax_23
                        data[code[vpc + (-11)]] = (bool)data[code[vpc + (9)]] ? (int)data[code[vpc + (22)]] : (int)data[code[vpc + (-3)]];
                        vpc += (int)data[code[vpc + (-11)]];
                        break;
                    case 4327:  //frequency 1 ExpressionStatement_30
                        ((string[])data[code[vpc + (-9)]])[(int)data[code[vpc + (2)]]] = (string)data[code[vpc + (29)]];
                        vpc += 64;
                        break;
                    case 1729:  //frequency 2 ExpressionStatement_21
                        data[code[vpc + (14)]] = ReturnArg_Array((int)data[code[vpc + (17)]]);
                        vpc += 69;
                        break;
                    case 3369:  //frequency 2 ExpressionStatement_4
                        data[code[vpc + (2)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (-20)]]).GetPistons());
                        vpc += 68;
                        break;
                    case 4452:  //frequency 2 ExpressionStatement_22
                        data[code[vpc + (17)]] = (int)data[code[vpc + (5)]] < (int)data[code[vpc + (23)]];
                        vpc += 67;
                        break;
                    case 8977:  //frequency 1 ExpressionStatement_6
                        data[code[vpc + (-15)]] = ((ConsoleCalculator.Piston)data[code[vpc + (11)]]).GetSize();
                        vpc += 61;
                        break;
                    case 7418:  //frequency 1 ReturnStatement_38
                        return (string)data[code[vpc + (9)]];
                        vpc += 60;
                    case 4181:  //frequency 1 ExpressionStatement_15
                        data[code[vpc + (-17)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (6)]]).GetPiston((int)data[code[vpc + (-10)]]));
                        vpc += 64;
                        break;
                    case 6388:  //frequency 1 ExpressionStatement_7
                        data[code[vpc + (18)]] = (string)data[code[vpc + (-4)]] + (double)data[code[vpc + (13)]];
                        vpc += 56;
                        break;
                }
            }

            return null;
        }


        private void ForLoop_Check()
        {
            string testName = "Performance_check#"+ TITLE;
            Program.Start_Check(testName);
            bool condition = true;

            int b = 5; //number of loops
            string oracle2 = ForSimple_Array_original(b);
            string virt21 = ForSimple_Array_obfuscated_op2_in1(b);
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