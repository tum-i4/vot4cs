using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCalculator.Performance.ForLoop
{
   

    class ForLoop_op4_in4
    {
        private static string TITLE = "ForLoop_op4_in4";
        private Car car = new Car("invocation-check-car", 4);

        public static int WARMUP;
        public static int ITERATIONS;
        public static int NUMBER_OF_LOOPS;
        public static int NUMBER_OF_TESTS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            ForLoop_op4_in4 lt = new ForLoop_op4_in4();
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
                string t_original = Time_Operation(i+" , "+ TITLE, ForSimple_Array_obfuscated2_op4_in4);

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
            string virt21 = ForSimple_Array_obfuscated2_op4_in4(b);
            Debug.Assert(virt21.Equals(oracle2), "virt21");
            
            condition = virt21.Equals(oracle2);
            Program.End_Check(testName, condition);
        }



        private string ForSimple_Array_obfuscated2_op4_in4(int b)
        {
            //Virtualization variables
            int[] code = new int[100668];
            object[] data = new object[4842];
            int vpc = 109;

            //Data init
            data[3129] = b; //b 
            data[3526] = ""; //"" constant
            data[232] = 3; //3 constant
            data[1156] = 4; //4 constant
            data[1441] = 1; //1 constant
            data[98] = 0; //0 constant
            data[916] = "_"; //"_" constant
            data[1115] = "~"; //"~" constant
            data[3865] = "#"; //"#" constant
            data[2343] = "["; //"[" constant
            data[214] = "]"; //"]" constant
            data[1618] = 1426291964; //sum 
            data[1644] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_0 
            data[3052] = -993; //memberTemp_0 
            data[3078] = 2075095712; //invocationTemp_1 
            data[3838] = 637460966; //r 
            data[366] = (string[])null; //dst 
            data[1894] = -437; //var_forIndex_0 
            data[657] = false; //var_whileCondition_0 
            data[2515] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_2 
            data[1239] = (double)0.271554201036484; //p1 
            data[2482] = 58; //memberTemp_1 
            data[1821] = -897; //memberTemp_2 
            data[606] = -583; //jmpWhileDestinationName_606 constant
            data[2817] = 68; //while_GoTo_True_2817 constant
            data[2185] = 774; //while_GoTo_False_2185 constant
            data[2377] = -774; //while_FalseBlockSkip_2377 constant

            //Code init

            code[109] = 7526; //ExpressionStatement_0 # ExpressionStatement_0
            code[114] = 1618; //sum
            code[118] = 3526; //""
            code[96] = 232; //3
            code[128] = 1156; //4
            code[138] = 3526; //""

            code[172] = 6090; //ExpressionStatement_1 # ExpressionStatement_1
            code[155] = 1644; //invocationTemp_0

            code[230] = 2933; //ExpressionStatement_2 # ExpressionStatement_2
            code[255] = 3052; //memberTemp_0
            code[213] = 1644; //invocationTemp_0

            code[290] = 9729; //ExpressionStatement_3 # ExpressionStatement_3
            code[286] = 3078; //invocationTemp_1
            code[294] = 3052; //memberTemp_0
            code[287] = 1441; //1

            code[355] = 6453; //ExpressionStatement_4 # ExpressionStatement_4
            code[368] = 1618; //sum
            code[384] = 1618; //sum
            code[343] = 3078; //invocationTemp_1

            code[420] = 2506; //ExpressionStatement_5 # ExpressionStatement_5
            code[425] = 3838; //r
            code[414] = 3526; //""

            code[484] = 7925; //ExpressionStatement_6 # ExpressionStatement_6
            code[485] = 366; //dst
            code[476] = 3129; //b

            code[543] = 2506; //ExpressionStatement_5 # ExpressionStatement_7
            code[548] = 1894; //var_forIndex_0
            code[537] = 98; //0

            code[607] = 7895; //ExpressionStatement_8 # ExpressionStatement_8
            code[606] = 657; //var_whileCondition_0
            code[624] = 1894; //var_forIndex_0
            code[631] = 3129; //b

            code[661] = 4422; //WhileStatementSyntax_9 # WhileStatementSyntax_9
            code[650] = 606; //jmpWhileDestinationName_606
            code[675] = 657; //var_whileCondition_0
            code[660] = 2817; //while_GoTo_True_2817
            code[687] = 2185; //while_GoTo_False_2185

            code[729] = 8517; //ExpressionStatement_10 # ExpressionStatement_10
            code[728] = 1618; //sum
            code[745] = 1618; //sum
            code[736] = 916; //"_"
            code[732] = 1894; //var_forIndex_0
            code[741] = 916; //"_"

            code[789] = 6453; //ExpressionStatement_4 # ExpressionStatement_11
            code[802] = 1618; //sum
            code[818] = 1618; //sum
            code[777] = 1115; //"~"

            code[854] = 9232; //ExpressionStatement_12 # ExpressionStatement_12
            code[875] = 3838; //r
            code[862] = 3838; //r
            code[855] = 1618; //sum
            code[882] = 3865; //"#"

            code[909] = 6090; //ExpressionStatement_1 # ExpressionStatement_13
            code[892] = 2515; //invocationTemp_2

            code[967] = 2924; //ExpressionStatement_14 # ExpressionStatement_14
            code[952] = 1239; //p1
            code[969] = 2515; //invocationTemp_2

            code[1024] = 5044; //ExpressionStatement_15 # ExpressionStatement_15
            code[1020] = 3838; //r
            code[1049] = 3838; //r
            code[1047] = 2343; //"["
            code[1034] = 1239; //p1
            code[1037] = 214; //"]"

            code[1097] = 1624; //ExpressionStatement_16 # ExpressionStatement_16
            code[1088] = 2482; //memberTemp_1
            code[1123] = 3838; //r

            code[1150] = 9963; //ExpressionStatement_17 # ExpressionStatement_17
            code[1172] = 1618; //sum
            code[1176] = 1618; //sum
            code[1130] = 2482; //memberTemp_1

            code[1203] = 2516; //ExpressionStatement_18 # ExpressionStatement_18
            code[1223] = 366; //dst
            code[1214] = 1894; //var_forIndex_0
            code[1201] = 1618; //sum

            code[1270] = 5643; //ExpressionStatement_19 # ExpressionStatement_19
            code[1277] = 1894; //var_forIndex_0
            code[1267] = 1894; //var_forIndex_0
            code[1298] = 1441; //1

            code[1326] = 7895; //ExpressionStatement_8 # ExpressionStatement_20
            code[1325] = 657; //var_whileCondition_0
            code[1343] = 1894; //var_forIndex_0
            code[1350] = 3129; //b

            code[1380] = 4453; //ExpressionStatement_21 # ExpressionStatement_21
            code[1407] = 2377; //while_FalseBlockSkip_2377

            code[1435] = 6071; //ExpressionStatement_22 # ExpressionStatement_22
            code[1416] = 1821; //memberTemp_2
            code[1458] = 366; //dst

            code[1497] = 8607; //ExpressionStatement_23 # ExpressionStatement_23
            code[1507] = 1618; //sum
            code[1508] = 1618; //sum
            code[1509] = 3865; //"#"
            code[1525] = 1821; //memberTemp_2

            code[1551] = 4043; //ReturnStatement_24 # ReturnStatement_24
            code[1543] = 1618; //sum

            return (string)InstanceInterpreterVirtualization_TraceLoopTests_1236_2_op4_in4(vpc, data, code);

        }



        private object InstanceInterpreterVirtualization_TraceLoopTests_1236_2_op4_in4(int vpc, object[] data, int[] code)
        {
            while (true)
            {
                switch (code[vpc])
                {
                    case 2933:  //frequency 1 ExpressionStatement_2
                        data[code[vpc + (25)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-17)]]).Count;
                        vpc += 60;
                        break;
                    case 4422:  //frequency 1 WhileStatementSyntax_9
                        data[code[vpc + (-11)]] = (bool)data[code[vpc + (14)]] ? (int)data[code[vpc + (-1)]] : (int)data[code[vpc + (26)]];
                        vpc += (int)data[code[vpc + (-11)]];
                        break;
                    case 2506:  //frequency 2 ExpressionStatement_5
                        data[code[vpc + (5)]] = data[code[vpc + (-6)]];
                        vpc += 64;
                        break;
                    case 6071:  //frequency 1 ExpressionStatement_22
                        data[code[vpc + (-19)]] = ((string[])data[code[vpc + (23)]]).Length;
                        vpc += 62;
                        break;
                    case 5044:  //frequency 1 ExpressionStatement_15
                        data[code[vpc + (-4)]] = (string)data[code[vpc + (25)]] + (string)data[code[vpc + (23)]] + (double)data[code[vpc + (10)]] + (string)data[code[vpc + (13)]];
                        vpc += 73;
                        break;
                    case 1624:  //frequency 1 ExpressionStatement_16
                        data[code[vpc + (-9)]] = ((string)data[code[vpc + (26)]]).Length;
                        vpc += 53;
                        break;
                    case 7895:  //frequency 2 ExpressionStatement_8
                        data[code[vpc + (-1)]] = (int)data[code[vpc + (17)]] < ReturnArg_Array((int)data[code[vpc + (24)]]);
                        vpc += 54;
                        break;
                    case 6453:  //frequency 2 ExpressionStatement_4
                        data[code[vpc + (13)]] = (string)data[code[vpc + (29)]] + (string)data[code[vpc + (-12)]];
                        vpc += 65;
                        break;
                    case 6090:  //frequency 2 ExpressionStatement_1
                        data[code[vpc + (-17)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(car.GetEngine().GetPistons());
                        vpc += 58;
                        break;
                    case 2924:  //frequency 1 ExpressionStatement_14
                        data[code[vpc + (-15)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (2)]]).First().GetSize();
                        vpc += 57;
                        break;
                    default:  //frequency 0 
                        break;
                    case 7526:  //frequency 1 ExpressionStatement_0
                        data[code[vpc + (5)]] = (string)data[code[vpc + (9)]] + (int)data[code[vpc + (-13)]] + (int)data[code[vpc + (19)]] + (string)data[code[vpc + (29)]];
                        vpc += 63;
                        break;
                    case 4453:  //frequency 1 ExpressionStatement_21
                        vpc += (int)data[code[vpc + (27)]];
                        vpc += 55;
                        break;
                    case 8517:  //frequency 1 ExpressionStatement_10
                        data[code[vpc + (-1)]] = (string)data[code[vpc + (16)]] + (string)data[code[vpc + (7)]] + (int)data[code[vpc + (3)]] + (string)data[code[vpc + (12)]];
                        vpc += 60;
                        break;
                    case 9963:  //frequency 1 ExpressionStatement_17
                        data[code[vpc + (22)]] = (string)data[code[vpc + (26)]] + (int)data[code[vpc + (-20)]];
                        vpc += 53;
                        break;
                    case 5643:  //frequency 1 ExpressionStatement_19
                        data[code[vpc + (7)]] = (int)data[code[vpc + (-3)]] + (int)data[code[vpc + (28)]];
                        vpc += 56;
                        break;
                    case 4043:  //frequency 1 ReturnStatement_24
                        return (string)data[code[vpc + (-8)]];
                        vpc += 56;
                    case 7925:  //frequency 1 ExpressionStatement_6
                        data[code[vpc + (1)]] = (string[])(new string[(int)data[code[vpc + (-8)]]]);
                        vpc += 59;
                        break;
                    case 2516:  //frequency 1 ExpressionStatement_18
                        ((string[])data[code[vpc + (20)]])[(int)data[code[vpc + (11)]]] = (string)data[code[vpc + (-2)]];
                        vpc += 67;
                        break;
                    case 9729:  //frequency 1 ExpressionStatement_3
                        data[code[vpc + (-4)]] = car.GetEngine().GetPiston((int)data[code[vpc + (4)]] - (int)data[code[vpc + (-3)]]).ToString();
                        vpc += 65;
                        break;
                    case 9232:  //frequency 1 ExpressionStatement_12
                        data[code[vpc + (21)]] = (string)data[code[vpc + (8)]] + (string)data[code[vpc + (1)]] + (string)data[code[vpc + (28)]];
                        vpc += 55;
                        break;
                    case 8607:  //frequency 1 ExpressionStatement_23
                        data[code[vpc + (10)]] = (string)data[code[vpc + (11)]] + (string)data[code[vpc + (12)]] + (int)data[code[vpc + (28)]];
                        vpc += 54;
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