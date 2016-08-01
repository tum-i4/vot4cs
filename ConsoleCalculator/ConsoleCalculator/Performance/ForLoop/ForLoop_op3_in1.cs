using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCalculator.Performance.ForLoop
{
   

    class ForLoop_op3_in1
    {
        private static string TITLE = "ForLoop_op3_in1";
        private Car car = new Car("invocation-check-car", 4);

        public static int WARMUP;
        public static int ITERATIONS;
        public static int NUMBER_OF_LOOPS;
        public static int NUMBER_OF_TESTS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            ForLoop_op3_in1 lt = new ForLoop_op3_in1();
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
                string t_original = Time_Operation(i+" , "+ TITLE, ForSimple_Array_obfuscated_op3_in1);

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


        private string ForSimple_Array_obfuscated_op3_in1(int b)
        {
            //Virtualization variables
            int[] code = new int[100599];
            object[] data = new object[4223];
            int vpc = 27;

            //Data init
            data[2490] = b; //b 
            data[236] = ""; //"" constant
            data[3339] = 3; //3 constant
            data[2874] = 4; //4 constant
            data[2745] = "["; //"[" constant
            data[413] = "]"; //"]" constant
            data[2971] = 1; //1 constant
            data[3769] = 0; //0 constant
            data[536] = "_"; //"_" constant
            data[2569] = "~"; //"~" constant
            data[1869] = "#"; //"#" constant
            data[1920] = 245619067; //addTemp_0 
            data[2246] = 1707035993; //sum 
            data[1218] = (ConsoleCalculator.Engine)null; //invocationTemp_0 
            data[1885] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
            data[2989] = (ConsoleCalculator.Piston)null; //invocationTemp_2 
            data[746] = (double)0.107707382229952; //p1 
            data[1309] = 559922757; //addTemp_1 
            data[599] = (ConsoleCalculator.Engine)null; //invocationTemp_3 
            data[992] = (ConsoleCalculator.Engine)null; //invocationTemp_4 
            data[211] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_5 
            data[583] = 214; //memberTemp_0 
            data[925] = (ConsoleCalculator.Piston)null; //invocationTemp_6 
            data[2876] = 1776754745; //invocationTemp_7 
            data[1495] = 875045554; //r 
            data[1921] = (string[])null; //dst 
            data[1398] = 257; //var_forIndex_0 
            data[235] = 197; //invocationTemp_8 
            data[3871] = false; //var_whileCondition_0 
            data[3894] = 1017451102; //addTemp_2 
            data[1276] = -630; //invocationTemp_9 
            data[1913] = -294; //memberTemp_1 
            data[2523] = 558; //jmpWhileDestinationName_2523 constant
            data[1129] = 70; //while_GoTo_True_1129 constant
            data[306] = 634; //while_GoTo_False_306 constant
            data[1251] = -634; //while_FalseBlockSkip_1251 constant

            //Code init

            code[27] = 8506; //ExpressionStatement_0 # ExpressionStatement_0
            code[43] = 1920; //addTemp_0
            code[47] = 236; //""
            code[44] = 3339; //3
            code[37] = 2874; //4

            code[96] = 4875; //ExpressionStatement_1 # ExpressionStatement_1
            code[83] = 2246; //sum
            code[114] = 1920; //addTemp_0
            code[98] = 236; //""

            code[161] = 1230; //ExpressionStatement_2 # ExpressionStatement_2
            code[170] = 1218; //invocationTemp_0

            code[213] = 4523; //ExpressionStatement_3 # ExpressionStatement_3
            code[210] = 1885; //invocationTemp_1
            code[216] = 1218; //invocationTemp_0

            code[265] = 2041; //ExpressionStatement_4 # ExpressionStatement_4
            code[255] = 2989; //invocationTemp_2
            code[282] = 1885; //invocationTemp_1

            code[323] = 9767; //ExpressionStatement_5 # ExpressionStatement_5
            code[319] = 746; //p1
            code[352] = 2989; //invocationTemp_2

            code[378] = 9652; //ExpressionStatement_6 # ExpressionStatement_6
            code[389] = 1309; //addTemp_1
            code[405] = 2745; //"["
            code[380] = 746; //p1
            code[383] = 413; //"]"

            code[433] = 4875; //ExpressionStatement_1 # ExpressionStatement_7
            code[420] = 2246; //sum
            code[451] = 2246; //sum
            code[435] = 1309; //addTemp_1

            code[498] = 1230; //ExpressionStatement_2 # ExpressionStatement_8
            code[507] = 599; //invocationTemp_3

            code[550] = 1230; //ExpressionStatement_2 # ExpressionStatement_9
            code[559] = 992; //invocationTemp_4

            code[602] = 4523; //ExpressionStatement_3 # ExpressionStatement_10
            code[599] = 211; //invocationTemp_5
            code[605] = 992; //invocationTemp_4

            code[654] = 6185; //ExpressionStatement_11 # ExpressionStatement_11
            code[635] = 583; //memberTemp_0
            code[663] = 211; //invocationTemp_5

            code[717] = 9172; //ExpressionStatement_12 # ExpressionStatement_12
            code[721] = 925; //invocationTemp_6
            code[701] = 599; //invocationTemp_3
            code[699] = 583; //memberTemp_0
            code[709] = 2971; //1

            code[778] = 1057; //ExpressionStatement_13 # ExpressionStatement_13
            code[777] = 2876; //invocationTemp_7
            code[788] = 925; //invocationTemp_6

            code[843] = 4875; //ExpressionStatement_1 # ExpressionStatement_14
            code[830] = 2246; //sum
            code[861] = 2246; //sum
            code[845] = 2876; //invocationTemp_7

            code[908] = 8883; //ExpressionStatement_15 # ExpressionStatement_15
            code[902] = 1495; //r
            code[895] = 236; //""

            code[965] = 5453; //ExpressionStatement_16 # ExpressionStatement_16
            code[964] = 1921; //dst
            code[950] = 2490; //b

            code[1030] = 8883; //ExpressionStatement_15 # ExpressionStatement_17
            code[1024] = 1398; //var_forIndex_0
            code[1017] = 3769; //0

            code[1087] = 9853; //ExpressionStatement_18 # ExpressionStatement_18
            code[1073] = 235; //invocationTemp_8
            code[1105] = 2490; //b

            code[1146] = 5855; //ExpressionStatement_19 # ExpressionStatement_19
            code[1135] = 3871; //var_whileCondition_0
            code[1133] = 1398; //var_forIndex_0
            code[1158] = 235; //invocationTemp_8

            code[1214] = 7901; //WhileStatementSyntax_20 # WhileStatementSyntax_20
            code[1211] = 2523; //jmpWhileDestinationName_2523
            code[1239] = 3871; //var_whileCondition_0
            code[1229] = 1129; //while_GoTo_True_1129
            code[1210] = 306; //while_GoTo_False_306

            code[1284] = 4796; //ExpressionStatement_21 # ExpressionStatement_21
            code[1290] = 3894; //addTemp_2
            code[1310] = 536; //"_"
            code[1296] = 1398; //var_forIndex_0
            code[1304] = 536; //"_"

            code[1342] = 4875; //ExpressionStatement_1 # ExpressionStatement_22
            code[1329] = 2246; //sum
            code[1360] = 2246; //sum
            code[1344] = 3894; //addTemp_2

            code[1407] = 4875; //ExpressionStatement_1 # ExpressionStatement_23
            code[1394] = 2246; //sum
            code[1425] = 2246; //sum
            code[1409] = 2569; //"~"

            code[1472] = 6859; //ExpressionStatement_24 # ExpressionStatement_24
            code[1501] = 1495; //r
            code[1491] = 1495; //r
            code[1458] = 2246; //sum
            code[1483] = 1869; //"#"

            code[1528] = 8472; //ExpressionStatement_25 # ExpressionStatement_25
            code[1548] = 1921; //dst
            code[1533] = 1398; //var_forIndex_0
            code[1531] = 2246; //sum

            code[1586] = 1203; //ExpressionStatement_26 # ExpressionStatement_26
            code[1582] = 1398; //var_forIndex_0
            code[1603] = 1398; //var_forIndex_0
            code[1607] = 2971; //1

            code[1654] = 9853; //ExpressionStatement_18 # ExpressionStatement_27
            code[1640] = 1276; //invocationTemp_9
            code[1672] = 2490; //b

            code[1713] = 5855; //ExpressionStatement_19 # ExpressionStatement_28
            code[1702] = 3871; //var_whileCondition_0
            code[1700] = 1398; //var_forIndex_0
            code[1725] = 1276; //invocationTemp_9

            code[1781] = 7253; //ExpressionStatement_29 # ExpressionStatement_29
            code[1776] = 1251; //while_FalseBlockSkip_1251

            code[1848] = 5791; //ExpressionStatement_30 # ExpressionStatement_30
            code[1839] = 1913; //memberTemp_1
            code[1828] = 1921; //dst

            code[1913] = 5456; //ExpressionStatement_31 # ExpressionStatement_31
            code[1932] = 2246; //sum
            code[1928] = 2246; //sum
            code[1922] = 1869; //"#"
            code[1910] = 1913; //memberTemp_1

            code[1979] = 2324; //ReturnStatement_32 # ReturnStatement_32
            code[1983] = 2246; //sum

            return (string)InstanceInterpreterVirtualization_TraceLoopTests_1574_op3_in1(vpc, data, code);

        }



        private object InstanceInterpreterVirtualization_TraceLoopTests_1574_op3_in1(int vpc, object[] data, int[] code)
        {
            while (true)
            {
                switch (code[vpc])
                {
                    case 6859:  //frequency 1 ExpressionStatement_24
                        data[code[vpc + (29)]] = (string)data[code[vpc + (19)]] + (string)data[code[vpc + (-14)]] + (string)data[code[vpc + (11)]];
                        vpc += 56;
                        break;
                    case 5453:  //frequency 1 ExpressionStatement_16
                        data[code[vpc + (-1)]] = (string[])(new string[(int)data[code[vpc + (-15)]]]);
                        vpc += 65;
                        break;
                    case 9767:  //frequency 1 ExpressionStatement_5
                        data[code[vpc + (-4)]] = ((ConsoleCalculator.Piston)data[code[vpc + (29)]]).GetSize();
                        vpc += 55;
                        break;
                    case 9853:  //frequency 2 ExpressionStatement_18
                        data[code[vpc + (-14)]] = ReturnArg_Array((int)data[code[vpc + (18)]]);
                        vpc += 59;
                        break;
                    case 2041:  //frequency 1 ExpressionStatement_4
                        data[code[vpc + (-10)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (17)]]).First());
                        vpc += 58;
                        break;
                    case 5791:  //frequency 1 ExpressionStatement_30
                        data[code[vpc + (-9)]] = ((string[])data[code[vpc + (-20)]]).Length;
                        vpc += 65;
                        break;
                    case 5855:  //frequency 2 ExpressionStatement_19
                        data[code[vpc + (-11)]] = (int)data[code[vpc + (-13)]] < (int)data[code[vpc + (12)]];
                        vpc += 68;
                        break;
                    case 4523:  //frequency 2 ExpressionStatement_3
                        data[code[vpc + (-3)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (3)]]).GetPistons());
                        vpc += 52;
                        break;
                    case 9172:  //frequency 1 ExpressionStatement_12
                        data[code[vpc + (4)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (-16)]]).GetPiston((int)data[code[vpc + (-18)]] - (int)data[code[vpc + (-8)]]));
                        vpc += 61;
                        break;
                    case 8883:  //frequency 2 ExpressionStatement_15
                        data[code[vpc + (-6)]] = data[code[vpc + (-13)]];
                        vpc += 57;
                        break;
                    case 7253:  //frequency 1 ExpressionStatement_29
                        vpc += (int)data[code[vpc + (-5)]];
                        vpc += 67;
                        break;
                    case 1057:  //frequency 1 ExpressionStatement_13
                        data[code[vpc + (-1)]] = ((ConsoleCalculator.Piston)data[code[vpc + (10)]]).ToString();
                        vpc += 65;
                        break;
                    case 2324:  //frequency 1 ReturnStatement_32
                        return (string)data[code[vpc + (4)]];
                        vpc += 59;
                    case 4796:  //frequency 1 ExpressionStatement_21
                        data[code[vpc + (6)]] = (string)data[code[vpc + (26)]] + (int)data[code[vpc + (12)]] + (string)data[code[vpc + (20)]];
                        vpc += 58;
                        break;
                    case 4875:  //frequency 5 ExpressionStatement_1
                        data[code[vpc + (-13)]] = (string)data[code[vpc + (18)]] + (string)data[code[vpc + (2)]];
                        vpc += 65;
                        break;
                    case 9652:  //frequency 1 ExpressionStatement_6
                        data[code[vpc + (11)]] = (string)data[code[vpc + (27)]] + (double)data[code[vpc + (2)]] + (string)data[code[vpc + (5)]];
                        vpc += 55;
                        break;
                    case 1203:  //frequency 1 ExpressionStatement_26
                        data[code[vpc + (-4)]] = (int)data[code[vpc + (17)]] + (int)data[code[vpc + (21)]];
                        vpc += 68;
                        break;
                    case 6185:  //frequency 1 ExpressionStatement_11
                        data[code[vpc + (-19)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (9)]]).Count;
                        vpc += 63;
                        break;
                    case 1230:  //frequency 3 ExpressionStatement_2
                        data[code[vpc + (9)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                        vpc += 52;
                        break;
                    default:  //frequency 0 
                        break;
                    case 8506:  //frequency 1 ExpressionStatement_0
                        data[code[vpc + (16)]] = (string)data[code[vpc + (20)]] + (int)data[code[vpc + (17)]] + (int)data[code[vpc + (10)]];
                        vpc += 69;
                        break;
                    case 5456:  //frequency 1 ExpressionStatement_31
                        data[code[vpc + (19)]] = (string)data[code[vpc + (15)]] + (string)data[code[vpc + (9)]] + (int)data[code[vpc + (-3)]];
                        vpc += 66;
                        break;
                    case 8472:  //frequency 1 ExpressionStatement_25
                        ((string[])data[code[vpc + (20)]])[(int)data[code[vpc + (5)]]] = (string)data[code[vpc + (3)]];
                        vpc += 58;
                        break;
                    case 7901:  //frequency 1 WhileStatementSyntax_20
                        data[code[vpc + (-3)]] = (bool)data[code[vpc + (25)]] ? (int)data[code[vpc + (15)]] : (int)data[code[vpc + (-4)]];
                        vpc += (int)data[code[vpc + (-3)]];
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
            string virt21 = ForSimple_Array_obfuscated_op3_in1(b);
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