using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCalculator.Performance.ForLoop
{
   

    class ForLoop_op4_in3
    {
        private static string TITLE = "ForLoop_op4_in3";
        private Car car = new Car("invocation-check-car", 4);

        public static int WARMUP;
        public static int ITERATIONS;
        public static int NUMBER_OF_LOOPS;
        public static int NUMBER_OF_TESTS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            ForLoop_op4_in3 lt = new ForLoop_op4_in3();
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
                string t_original = Time_Operation(i+" , "+ TITLE, ForSimple_Array_obfuscated2_op4_in3);

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
            string virt21 = ForSimple_Array_obfuscated2_op4_in3(b);
            Debug.Assert(virt21.Equals(oracle2), "virt21");
            
            condition = virt21.Equals(oracle2);
            Program.End_Check(testName, condition);
        }

        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string ForSimple_Array_obfuscated2_op4_in3(int b)
        {
            //Virtualization variables
            int[] code = new int[100612];
            object[] data = new object[4959];
            int vpc = 116;

            //Data init
            data[1828] = b; //b 
            data[123] = ""; //"" constant
            data[2435] = 3; //3 constant
            data[1805] = 4; //4 constant
            data[997] = 1; //1 constant
            data[2989] = 0; //0 constant
            data[2099] = "_"; //"_" constant
            data[2791] = "~"; //"~" constant
            data[365] = "#"; //"#" constant
            data[1855] = "["; //"[" constant
            data[12] = "]"; //"]" constant
            data[843] = 1290348670; //sum 
            data[3782] = (ConsoleCalculator.Engine)null; //invocationTemp_0 
            data[2756] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
            data[1728] = -780; //memberTemp_0 
            data[3972] = (ConsoleCalculator.Piston)null; //invocationTemp_2 
            data[538] = 2023170179; //r 
            data[1098] = (string[])null; //dst 
            data[1812] = -536; //var_forIndex_0 
            data[2972] = -238; //invocationTemp_3 
            data[3051] = false; //var_whileCondition_0 
            data[886] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_4 
            data[2974] = (double)0.559951857458778; //p1 
            data[2610] = 940; //memberTemp_1 
            data[1104] = -455; //memberTemp_2 
            data[2745] = -239; //jmpWhileDestinationName_2745 constant
            data[2384] = 61; //while_GoTo_True_2384 constant
            data[2355] = 816; //while_GoTo_False_2355 constant
            data[645] = -816; //while_FalseBlockSkip_645 constant

            //Code init

            code[116] = 1395; //ExpressionStatement_0 # ExpressionStatement_0
            code[99] = 843; //sum
            code[129] = 123; //""
            code[115] = 2435; //3
            code[128] = 1805; //4
            code[124] = 123; //""

            code[182] = 8970; //ExpressionStatement_1 # ExpressionStatement_1
            code[199] = 3782; //invocationTemp_0

            code[247] = 3718; //ExpressionStatement_2 # ExpressionStatement_2
            code[249] = 2756; //invocationTemp_1
            code[265] = 3782; //invocationTemp_0

            code[314] = 3792; //ExpressionStatement_3 # ExpressionStatement_3
            code[307] = 1728; //memberTemp_0
            code[298] = 2756; //invocationTemp_1

            code[374] = 2505; //ExpressionStatement_4 # ExpressionStatement_4
            code[401] = 3972; //invocationTemp_2
            code[365] = 1728; //memberTemp_0
            code[368] = 997; //1

            code[427] = 2578; //ExpressionStatement_5 # ExpressionStatement_5
            code[413] = 843; //sum
            code[435] = 843; //sum
            code[439] = 3972; //invocationTemp_2

            code[485] = 4590; //ExpressionStatement_6 # ExpressionStatement_6
            code[505] = 538; //r
            code[480] = 123; //""

            code[543] = 1364; //ExpressionStatement_7 # ExpressionStatement_7
            code[536] = 1098; //dst
            code[542] = 1828; //b

            code[603] = 4590; //ExpressionStatement_6 # ExpressionStatement_8
            code[623] = 1812; //var_forIndex_0
            code[598] = 2989; //0

            code[661] = 9526; //ExpressionStatement_9 # ExpressionStatement_9
            code[689] = 2972; //invocationTemp_3
            code[650] = 1828; //b

            code[731] = 3200; //ExpressionStatement_10 # ExpressionStatement_10
            code[738] = 3051; //var_whileCondition_0
            code[749] = 1812; //var_forIndex_0
            code[735] = 2972; //invocationTemp_3

            code[790] = 5450; //WhileStatementSyntax_11 # WhileStatementSyntax_11
            code[791] = 2745; //jmpWhileDestinationName_2745
            code[804] = 3051; //var_whileCondition_0
            code[775] = 2384; //while_GoTo_True_2384
            code[800] = 2355; //while_GoTo_False_2355

            code[851] = 7974; //ExpressionStatement_12 # ExpressionStatement_12
            code[836] = 843; //sum
            code[878] = 843; //sum
            code[845] = 2099; //"_"
            code[849] = 1812; //var_forIndex_0
            code[873] = 2099; //"_"

            code[913] = 1197; //ExpressionStatement_13 # ExpressionStatement_13
            code[894] = 843; //sum
            code[942] = 843; //sum
            code[908] = 2791; //"~"

            code[974] = 7817; //ExpressionStatement_14 # ExpressionStatement_14
            code[956] = 538; //r
            code[995] = 538; //r
            code[954] = 843; //sum
            code[998] = 365; //"#"

            code[1041] = 7703; //ExpressionStatement_15 # ExpressionStatement_15
            code[1042] = 886; //invocationTemp_4

            code[1108] = 6319; //ExpressionStatement_16 # ExpressionStatement_16
            code[1128] = 2974; //p1
            code[1117] = 886; //invocationTemp_4

            code[1178] = 2262; //ExpressionStatement_17 # ExpressionStatement_17
            code[1197] = 538; //r
            code[1165] = 538; //r
            code[1188] = 1855; //"["
            code[1162] = 2974; //p1
            code[1185] = 12; //"]"

            code[1249] = 1132; //ExpressionStatement_18 # ExpressionStatement_18
            code[1274] = 2610; //memberTemp_1
            code[1262] = 538; //r

            code[1304] = 1510; //ExpressionStatement_19 # ExpressionStatement_19
            code[1319] = 843; //sum
            code[1289] = 843; //sum
            code[1323] = 2610; //memberTemp_1

            code[1363] = 1164; //ExpressionStatement_20 # ExpressionStatement_20
            code[1380] = 1098; //dst
            code[1351] = 1812; //var_forIndex_0
            code[1356] = 843; //sum

            code[1427] = 6641; //ExpressionStatement_21 # ExpressionStatement_21
            code[1432] = 1812; //var_forIndex_0
            code[1447] = 1812; //var_forIndex_0
            code[1441] = 997; //1

            code[1485] = 1335; //ExpressionStatement_22 # ExpressionStatement_22
            code[1476] = 3051; //var_whileCondition_0
            code[1479] = 1812; //var_forIndex_0
            code[1475] = 1828; //b

            code[1542] = 7415; //ExpressionStatement_23 # ExpressionStatement_23
            code[1527] = 645; //while_FalseBlockSkip_645

            code[1606] = 8314; //ExpressionStatement_24 # ExpressionStatement_24
            code[1604] = 1104; //memberTemp_2
            code[1591] = 1098; //dst

            code[1677] = 1849; //ExpressionStatement_25 # ExpressionStatement_25
            code[1680] = 843; //sum
            code[1664] = 843; //sum
            code[1705] = 365; //"#"
            code[1685] = 1104; //memberTemp_2

            code[1749] = 4449; //ReturnStatement_26 # ReturnStatement_26
            code[1754] = 843; //sum

            return (string)InstanceInterpreterVirtualization_TraceLoopTests_2835_2_op4_in3(vpc, data, code);

        }


        private object InstanceInterpreterVirtualization_TraceLoopTests_2835_2_op4_in3(int vpc, object[] data, int[] code)
        {
            while (true)
            {
                switch (code[vpc])
                {
                    case 7415:  //frequency 1 ExpressionStatement_23
                        vpc += (int)data[code[vpc + (-15)]];
                        vpc += 64;
                        break;
                    case 4449:  //frequency 1 ReturnStatement_26
                        return (string)data[code[vpc + (5)]];
                        vpc += 63;
                    case 8970:  //frequency 1 ExpressionStatement_1
                        data[code[vpc + (17)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                        vpc += 65;
                        break;
                    case 3792:  //frequency 1 ExpressionStatement_3
                        data[code[vpc + (-7)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-16)]]).Count;
                        vpc += 60;
                        break;
                    case 1335:  //frequency 1 ExpressionStatement_22
                        data[code[vpc + (-9)]] = (int)data[code[vpc + (-6)]] < ReturnArg_Array((int)data[code[vpc + (-10)]]);
                        vpc += 57;
                        break;
                    case 1395:  //frequency 1 ExpressionStatement_0
                        data[code[vpc + (-17)]] = (string)data[code[vpc + (13)]] + (int)data[code[vpc + (-1)]] + (int)data[code[vpc + (12)]] + (string)data[code[vpc + (8)]];
                        vpc += 66;
                        break;
                    case 6641:  //frequency 1 ExpressionStatement_21
                        data[code[vpc + (5)]] = (int)data[code[vpc + (20)]] + (int)data[code[vpc + (14)]];
                        vpc += 58;
                        break;
                    case 1132:  //frequency 1 ExpressionStatement_18
                        data[code[vpc + (25)]] = ((string)data[code[vpc + (13)]]).Length;
                        vpc += 55;
                        break;
                    case 1164:  //frequency 1 ExpressionStatement_20
                        ((string[])data[code[vpc + (17)]])[(int)data[code[vpc + (-12)]]] = (string)data[code[vpc + (-7)]];
                        vpc += 64;
                        break;
                    case 2578:  //frequency 1 ExpressionStatement_5
                        data[code[vpc + (-14)]] = (string)data[code[vpc + (8)]] + ((ConsoleCalculator.Piston)data[code[vpc + (12)]]).ToString();
                        vpc += 58;
                        break;
                    case 5450:  //frequency 1 WhileStatementSyntax_11
                        data[code[vpc + (1)]] = (bool)data[code[vpc + (14)]] ? (int)data[code[vpc + (-15)]] : (int)data[code[vpc + (10)]];
                        vpc += (int)data[code[vpc + (1)]];
                        break;
                    case 3200:  //frequency 1 ExpressionStatement_10
                        data[code[vpc + (7)]] = (int)data[code[vpc + (18)]] < (int)data[code[vpc + (4)]];
                        vpc += 59;
                        break;
                    case 3718:  //frequency 1 ExpressionStatement_2
                        data[code[vpc + (2)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (18)]]).GetPistons());
                        vpc += 67;
                        break;
                    case 4590:  //frequency 2 ExpressionStatement_6
                        data[code[vpc + (20)]] = data[code[vpc + (-5)]];
                        vpc += 58;
                        break;
                    case 1197:  //frequency 1 ExpressionStatement_13
                        data[code[vpc + (-19)]] = (string)data[code[vpc + (29)]] + (string)data[code[vpc + (-5)]];
                        vpc += 61;
                        break;
                    case 1849:  //frequency 1 ExpressionStatement_25
                        data[code[vpc + (3)]] = (string)data[code[vpc + (-13)]] + (string)data[code[vpc + (28)]] + (int)data[code[vpc + (8)]];
                        vpc += 72;
                        break;
                    case 7703:  //frequency 1 ExpressionStatement_15
                        data[code[vpc + (1)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(car.GetEngine().GetPistons());
                        vpc += 67;
                        break;
                    case 1364:  //frequency 1 ExpressionStatement_7
                        data[code[vpc + (-7)]] = (string[])(new string[(int)data[code[vpc + (-1)]]]);
                        vpc += 60;
                        break;
                    case 9526:  //frequency 1 ExpressionStatement_9
                        data[code[vpc + (28)]] = ReturnArg_Array((int)data[code[vpc + (-11)]]);
                        vpc += 70;
                        break;
                    case 2262:  //frequency 1 ExpressionStatement_17
                        data[code[vpc + (19)]] = (string)data[code[vpc + (-13)]] + (string)data[code[vpc + (10)]] + (double)data[code[vpc + (-16)]] + (string)data[code[vpc + (7)]];
                        vpc += 71;
                        break;
                    case 8314:  //frequency 1 ExpressionStatement_24
                        data[code[vpc + (-2)]] = ((string[])data[code[vpc + (-15)]]).Length;
                        vpc += 71;
                        break;
                    case 7974:  //frequency 1 ExpressionStatement_12
                        data[code[vpc + (-15)]] = (string)data[code[vpc + (27)]] + (string)data[code[vpc + (-6)]] + (int)data[code[vpc + (-2)]] + (string)data[code[vpc + (22)]];
                        vpc += 62;
                        break;
                    case 1510:  //frequency 1 ExpressionStatement_19
                        data[code[vpc + (15)]] = (string)data[code[vpc + (-15)]] + (int)data[code[vpc + (19)]];
                        vpc += 59;
                        break;
                    case 2505:  //frequency 1 ExpressionStatement_4
                        data[code[vpc + (27)]] = (ConsoleCalculator.Piston)(car.GetEngine().GetPiston((int)data[code[vpc + (-9)]] - (int)data[code[vpc + (-6)]]));
                        vpc += 53;
                        break;
                    default:  //frequency 0 
                        break;
                    case 7817:  //frequency 1 ExpressionStatement_14
                        data[code[vpc + (-18)]] = (string)data[code[vpc + (21)]] + (string)data[code[vpc + (-20)]] + (string)data[code[vpc + (24)]];
                        vpc += 67;
                        break;
                    case 6319:  //frequency 1 ExpressionStatement_16
                        data[code[vpc + (20)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (9)]]).First().GetSize();
                        vpc += 70;
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