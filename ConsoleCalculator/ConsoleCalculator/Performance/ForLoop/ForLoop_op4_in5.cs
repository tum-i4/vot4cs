using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCalculator.Performance.ForLoop
{
   

    class ForLoop_op4_in5
    {
        private static string TITLE = "ForLoop_op4_in5";
        private Car car = new Car("invocation-check-car", 4);

        public static int WARMUP;
        public static int ITERATIONS;
        public static int NUMBER_OF_LOOPS;
        public static int NUMBER_OF_TESTS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            ForLoop_op4_in5 lt = new ForLoop_op4_in5();
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
                string t_original = Time_Operation(i+" , "+ TITLE, ForSimple_Array_obfuscated2_op4_in5);

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
            string virt21 = ForSimple_Array_obfuscated2_op4_in5(b);
            Debug.Assert(virt21.Equals(oracle2), "virt21");
            
            condition = virt21.Equals(oracle2);
            Program.End_Check(testName, condition);
        }


        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string ForSimple_Array_obfuscated2_op4_in5(int b)
        {
            //Virtualization variables
            int[] code = new int[100962];
            object[] data = new object[4842];
            int vpc = 78;

            //Data init
            data[791] = b; //b 
            data[1679] = ""; //"" constant
            data[1079] = 3; //3 constant
            data[1920] = 4; //4 constant
            data[2222] = 1; //1 constant
            data[2050] = 0; //0 constant
            data[86] = "_"; //"_" constant
            data[2934] = "~"; //"~" constant
            data[454] = "#"; //"#" constant
            data[520] = "["; //"[" constant
            data[2332] = "]"; //"]" constant
            data[2431] = 1952909025; //sum 
            data[3295] = 875; //memberTemp_0 
            data[2] = (ConsoleCalculator.Piston)null; //invocationTemp_0 
            data[143] = 1466123585; //r 
            data[3578] = (string[])null; //dst 
            data[3783] = 243; //var_forIndex_0 
            data[3158] = false; //var_whileCondition_0 
            data[3947] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
            data[2276] = (double)0.0422941758494331; //p1 
            data[3987] = 177; //memberTemp_1 
            data[1571] = -447; //memberTemp_2 
            data[2621] = -925; //jmpWhileDestinationName_2621 constant
            data[80] = 57; //while_GoTo_True_80 constant
            data[237] = 777; //while_GoTo_False_237 constant
            data[82] = -777; //while_FalseBlockSkip_82 constant

            //Code init

            code[78] = 5734; //ExpressionStatement_0 # ExpressionStatement_0
            code[65] = 2431; //sum
            code[87] = 1679; //""
            code[91] = 1079; //3
            code[69] = 1920; //4
            code[83] = 1679; //""

            code[149] = 6978; //ExpressionStatement_1 # ExpressionStatement_1
            code[177] = 3295; //memberTemp_0

            code[216] = 1116; //ExpressionStatement_2 # ExpressionStatement_2
            code[241] = 2; //invocationTemp_0
            code[208] = 3295; //memberTemp_0
            code[213] = 2222; //1

            code[275] = 5692; //ExpressionStatement_3 # ExpressionStatement_3
            code[296] = 2431; //sum
            code[297] = 2431; //sum
            code[261] = 2; //invocationTemp_0

            code[345] = 9041; //ExpressionStatement_4 # ExpressionStatement_4
            code[365] = 143; //r
            code[350] = 1679; //""

            code[398] = 8243; //ExpressionStatement_5 # ExpressionStatement_5
            code[393] = 3578; //dst
            code[409] = 791; //b

            code[466] = 9041; //ExpressionStatement_4 # ExpressionStatement_6
            code[486] = 3783; //var_forIndex_0
            code[471] = 2050; //0

            code[519] = 8931; //ExpressionStatement_7 # ExpressionStatement_7
            code[521] = 3158; //var_whileCondition_0
            code[544] = 3783; //var_forIndex_0
            code[502] = 791; //b

            code[575] = 2437; //WhileStatementSyntax_8 # WhileStatementSyntax_8
            code[601] = 2621; //jmpWhileDestinationName_2621
            code[558] = 3158; //var_whileCondition_0
            code[577] = 80; //while_GoTo_True_80
            code[571] = 237; //while_GoTo_False_237

            code[632] = 7138; //ExpressionStatement_9 # ExpressionStatement_9
            code[635] = 2431; //sum
            code[646] = 2431; //sum
            code[642] = 86; //"_"
            code[653] = 3783; //var_forIndex_0
            code[640] = 86; //"_"

            code[700] = 1317; //ExpressionStatement_10 # ExpressionStatement_10
            code[713] = 2431; //sum
            code[698] = 2431; //sum
            code[695] = 2934; //"~"

            code[755] = 4256; //ExpressionStatement_11 # ExpressionStatement_11
            code[781] = 143; //r
            code[765] = 143; //r
            code[775] = 2431; //sum
            code[748] = 454; //"#"

            code[812] = 9664; //ExpressionStatement_12 # ExpressionStatement_12
            code[840] = 3947; //invocationTemp_1

            code[875] = 9597; //ExpressionStatement_13 # ExpressionStatement_13
            code[863] = 2276; //p1
            code[899] = 3947; //invocationTemp_1

            code[941] = 8019; //ExpressionStatement_14 # ExpressionStatement_14
            code[951] = 143; //r
            code[938] = 143; //r
            code[921] = 520; //"["
            code[942] = 2276; //p1
            code[944] = 2332; //"]"

            code[1000] = 1733; //ExpressionStatement_15 # ExpressionStatement_15
            code[1029] = 3987; //memberTemp_1
            code[981] = 143; //r

            code[1059] = 9444; //ExpressionStatement_16 # ExpressionStatement_16
            code[1066] = 2431; //sum
            code[1045] = 2431; //sum
            code[1081] = 3987; //memberTemp_1

            code[1117] = 5180; //ExpressionStatement_17 # ExpressionStatement_17
            code[1119] = 3578; //dst
            code[1110] = 3783; //var_forIndex_0
            code[1134] = 2431; //sum

            code[1171] = 7576; //ExpressionStatement_18 # ExpressionStatement_18
            code[1186] = 3783; //var_forIndex_0
            code[1174] = 3783; //var_forIndex_0
            code[1194] = 2222; //1

            code[1240] = 8931; //ExpressionStatement_7 # ExpressionStatement_19
            code[1242] = 3158; //var_whileCondition_0
            code[1265] = 3783; //var_forIndex_0
            code[1223] = 791; //b

            code[1296] = 3168; //ExpressionStatement_20 # ExpressionStatement_20
            code[1293] = 82; //while_FalseBlockSkip_82

            code[1352] = 9680; //ExpressionStatement_21 # ExpressionStatement_21
            code[1379] = 1571; //memberTemp_2
            code[1368] = 3578; //dst

            code[1408] = 5821; //ExpressionStatement_22 # ExpressionStatement_22
            code[1402] = 2431; //sum
            code[1420] = 2431; //sum
            code[1429] = 454; //"#"
            code[1421] = 1571; //memberTemp_2

            code[1470] = 6137; //ReturnStatement_23 # ReturnStatement_23
            code[1494] = 2431; //sum

            return (string)InstanceInterpreterVirtualization_TraceLoopTests_2145_2_op4_in5(vpc, data, code);

        }


        private object InstanceInterpreterVirtualization_TraceLoopTests_2145_2_op4_in5(int vpc, object[] data, int[] code)
        {
            while (true)
            {
                switch (code[vpc])
                {
                    case 4256:  //frequency 1 ExpressionStatement_11
                        data[code[vpc + (26)]] = (string)data[code[vpc + (10)]] + (string)data[code[vpc + (20)]] + (string)data[code[vpc + (-7)]];
                        vpc += 57;
                        break;
                    case 8019:  //frequency 1 ExpressionStatement_14
                        data[code[vpc + (10)]] = (string)data[code[vpc + (-3)]] + (string)data[code[vpc + (-20)]] + (double)data[code[vpc + (1)]] + (string)data[code[vpc + (3)]];
                        vpc += 59;
                        break;
                    case 8243:  //frequency 1 ExpressionStatement_5
                        data[code[vpc + (-5)]] = (string[])(new string[(int)data[code[vpc + (11)]]]);
                        vpc += 68;
                        break;
                    case 7576:  //frequency 1 ExpressionStatement_18
                        data[code[vpc + (15)]] = (int)data[code[vpc + (3)]] + (int)data[code[vpc + (23)]];
                        vpc += 69;
                        break;
                    default:  //frequency 0 
                        break;
                    case 1733:  //frequency 1 ExpressionStatement_15
                        data[code[vpc + (29)]] = ((string)data[code[vpc + (-19)]]).Length;
                        vpc += 59;
                        break;
                    case 5692:  //frequency 1 ExpressionStatement_3
                        data[code[vpc + (21)]] = (string)data[code[vpc + (22)]] + ((ConsoleCalculator.Piston)data[code[vpc + (-14)]]).ToString();
                        vpc += 70;
                        break;
                    case 1317:  //frequency 1 ExpressionStatement_10
                        data[code[vpc + (13)]] = (string)data[code[vpc + (-2)]] + (string)data[code[vpc + (-5)]];
                        vpc += 55;
                        break;
                    case 9041:  //frequency 2 ExpressionStatement_4
                        data[code[vpc + (20)]] = data[code[vpc + (5)]];
                        vpc += 53;
                        break;
                    case 5734:  //frequency 1 ExpressionStatement_0
                        data[code[vpc + (-13)]] = (string)data[code[vpc + (9)]] + (int)data[code[vpc + (13)]] + (int)data[code[vpc + (-9)]] + (string)data[code[vpc + (5)]];
                        vpc += 71;
                        break;
                    case 5821:  //frequency 1 ExpressionStatement_22
                        data[code[vpc + (-6)]] = (string)data[code[vpc + (12)]] + (string)data[code[vpc + (21)]] + (int)data[code[vpc + (13)]];
                        vpc += 62;
                        break;
                    case 9444:  //frequency 1 ExpressionStatement_16
                        data[code[vpc + (7)]] = (string)data[code[vpc + (-14)]] + (int)data[code[vpc + (22)]];
                        vpc += 58;
                        break;
                    case 3168:  //frequency 1 ExpressionStatement_20
                        vpc += (int)data[code[vpc + (-3)]];
                        vpc += 56;
                        break;
                    case 6978:  //frequency 1 ExpressionStatement_1
                        data[code[vpc + (28)]] = car.GetEngine().GetPistons().Count;
                        vpc += 67;
                        break;
                    case 2437:  //frequency 1 WhileStatementSyntax_8
                        data[code[vpc + (26)]] = (bool)data[code[vpc + (-17)]] ? (int)data[code[vpc + (2)]] : (int)data[code[vpc + (-4)]];
                        vpc += (int)data[code[vpc + (26)]];
                        break;
                    case 1116:  //frequency 1 ExpressionStatement_2
                        data[code[vpc + (25)]] = (ConsoleCalculator.Piston)(car.GetEngine().GetPiston((int)data[code[vpc + (-8)]] - (int)data[code[vpc + (-3)]]));
                        vpc += 59;
                        break;
                    case 6137:  //frequency 1 ReturnStatement_23
                        return (string)data[code[vpc + (24)]];
                        vpc += 67;
                    case 9680:  //frequency 1 ExpressionStatement_21
                        data[code[vpc + (27)]] = ((string[])data[code[vpc + (16)]]).Length;
                        vpc += 56;
                        break;
                    case 9664:  //frequency 1 ExpressionStatement_12
                        data[code[vpc + (28)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(car.GetEngine().GetPistons());
                        vpc += 63;
                        break;
                    case 5180:  //frequency 1 ExpressionStatement_17
                        ((string[])data[code[vpc + (2)]])[(int)data[code[vpc + (-7)]]] = (string)data[code[vpc + (17)]];
                        vpc += 54;
                        break;
                    case 9597:  //frequency 1 ExpressionStatement_13
                        data[code[vpc + (-12)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (24)]]).First().GetSize();
                        vpc += 66;
                        break;
                    case 7138:  //frequency 1 ExpressionStatement_9
                        data[code[vpc + (3)]] = (string)data[code[vpc + (14)]] + (string)data[code[vpc + (10)]] + (int)data[code[vpc + (21)]] + (string)data[code[vpc + (8)]];
                        vpc += 68;
                        break;
                    case 8931:  //frequency 2 ExpressionStatement_7
                        data[code[vpc + (2)]] = (int)data[code[vpc + (25)]] < ReturnArg_Array((int)data[code[vpc + (-17)]]);
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