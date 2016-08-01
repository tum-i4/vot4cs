using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

[assembly: Obfuscation(Exclude = true, Feature = "ctrl flow")]
namespace ConsoleCalculator.Performance.BinarySearch
{

    [Obfuscation(Exclude = true, Feature = "ctrl flow")]
    class BinarySearch_Iterative_ctrl_flow
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> testData;
        public static List<int> keys;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunTests()
        {
            BinarySearch_Iterative_ctrl_flow bs = new BinarySearch_Iterative_ctrl_flow();
            time_warmup.Clear();
            time_run.Clear();

            bs.Profile();
            

//            bs.BinarySearch_Check();
            
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

            result += "t_ctrl_flow";
//            result += "     t_method";
//            result += "     t_class";
//            result += " t_method_default";
//            result += " t_class_default";
//            result += "     t_method_junk";
//            result += "     t_class_junk";
            result += " " + "\n";


            int[] unsorted_original = testData.ToArray();
            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {                
                Console.WriteLine(i+ " ##############");
                Debug.WriteLine(i+ " ##############");
                string t_original = Time_Operation(i+ " BinarySearch_Iterative_ctrl_flow", BinarySearchIterative_original);

                result += " " + t_original;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);

            PrintTimes();
        }


        [Obfuscation(Exclude = false, Feature = "ctrl flow")]
        private static int BinarySearchIterative_original(int[] inputArray, int key, int min, int max)
{
    while (min <= max)
    {
        int mid = (min + max) / 2;
        if (key == inputArray[mid])
        {
            return mid;
        }
        else if (key < inputArray[mid])
        {
            max = mid - 1;
        }
        else
        {
            min = mid + 1;
        }
    }
    return -1;
}

        //[Obfuscation(Exclude = false, Feature = "ctrl flow")]
        private static int BinarySearchIterative_1(int[] inputArray, int key, int min, int max)
        {
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
public long FactorialIterative(int num)
{
    //Virtualization variables
    int[] code = new int[100754];
    object[] data = new object[4475];
    int vpc = 24;

    //Data init
    data[273]=num; //num 
    data[3111]=1 ; //1 constant
    data[1815]=(long)0L; //0L constant
    data[2356]=0; //0 constant
    data[1214]=(long)1; //1 constant
    data[2024]=2; //2 constant
    data[1843]=(long)-973L; //result 
    data[3026]=false; //var_ifCondition_0 
    data[3249]=-84; //var_forIndex_0 
    data[2894]=false; //var_whileCondition_0 
    data[1011]=-496; //jmpDestinationName_1011 constant
    data[812]=57; //if_GoTo_True_812 constant
    data[2881]=180; //if_GoTo_False_2881 constant
    data[552]=497; //if_FalseBlockSize_Skip_552 constant
    data[638]=-614; //jmpWhileDestinationName_638 constant
    data[3371]=57; //while_GoTo_True_3371 constant
    data[2097]=318; //while_GoTo_False_2097 constant
    data[1090]=-318; //while_FalseBlockSkip_1090 constant

    //Code init

    code[24]=7887; //ExpressionStatement_0 # ExpressionStatement_0
    code[46]=1843; //result
    code[18]=3111; //1
    code[44]=1815; //0L

    code[80]=9058; //ExpressionStatement_1 # ExpressionStatement_1
    code[106]=3026; //var_ifCondition_0
    code[74]=273; //num
    code[97]=2356; //0

    code[136]=6442; //IfStatementSyntax_2 # IfStatementSyntax_2
    code[121]=1011; //jmpDestinationName_1011
    code[153]=3026; //var_ifCondition_0
    code[147]=812; //if_GoTo_True_812
    code[160]=2881; //if_GoTo_False_2881

    code[193]=7902; //ReturnStatement_3 # ReturnStatement_3
    code[196]=1214; //1

    code[253]=9095; //ExpressionStatement_4 # ExpressionStatement_4
    code[266]=552; //if_FalseBlockSize_Skip_552

    code[316]=3105; //ExpressionStatement_5 # ExpressionStatement_5
    code[300]=3249; //var_forIndex_0
    code[302]=2024; //2

    code[368]=7369; //ExpressionStatement_6 # ExpressionStatement_6
    code[397]=2894; //var_whileCondition_0
    code[391]=3249; //var_forIndex_0
    code[393]=273; //num

    code[435]=6442; //IfStatementSyntax_2 # WhileStatementSyntax_7
    code[420]=638; //jmpWhileDestinationName_638
    code[452]=2894; //var_whileCondition_0
    code[446]=3371; //while_GoTo_True_3371
    code[459]=2097; //while_GoTo_False_2097

    code[492]=1086; //ExpressionStatement_8 # ExpressionStatement_8
    code[476]=1843; //result
    code[479]=1843; //result
    code[497]=3249; //var_forIndex_0

    code[559]=1402; //ExpressionStatement_9 # ExpressionStatement_9
    code[574]=3249; //var_forIndex_0
    code[564]=3249; //var_forIndex_0
    code[558]=3111; //1

    code[623]=7369; //ExpressionStatement_6 # ExpressionStatement_10
    code[652]=2894; //var_whileCondition_0
    code[646]=3249; //var_forIndex_0
    code[648]=273; //num

    code[690]=9095; //ExpressionStatement_4 # ExpressionStatement_11
    code[703]=1090; //while_FalseBlockSkip_1090

    code[753]=7902; //ReturnStatement_3 # ReturnStatement_12
    code[756]=1843; //result

    return (long)InstanceInterpreterVirtualization_BinarySearch_Iterative_3054(vpc, data, code);

}

        private Car car;

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
private string ForSimple_Array(int b)
{
    //Virtualization variables
    int[] code = new int[100871];
    object[] data = new object[4401];
    int vpc = 66;

    //Data init
    data[2398]=b; //b 
    data[74]="" ; //"" constant
    data[2180]=3 ; //3 constant
    data[2297]=4 ; //4 constant
    data[406]="[" ; //"[" constant
    data[2495]="]"; //"]" constant
    data[1704]=1; //1 constant
    data[3722]=0; //0 constant
    data[744]="_" ; //"_" constant
    data[1065]="~"; //"~" constant
    data[1339]="#"; //"#" constant
    data[3213]=1455568598; //sum 
    data[2875]=(ConsoleCalculator.Engine)null; //invocationTemp_0 
    data[3913]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
    data[3695]=(ConsoleCalculator.Piston)null; //invocationTemp_2 
    data[3747]=(double)0.571546291267288; //p1 
    data[2296]=(ConsoleCalculator.Engine)null; //invocationTemp_3 
    data[3498]=(ConsoleCalculator.Engine)null; //invocationTemp_4 
    data[3558]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_5 
    data[2375]=-55; //memberTemp_0 
    data[2155]=(ConsoleCalculator.Piston)null; //invocationTemp_6 
    data[898]=1145075257; //invocationTemp_7 
    data[3841]=945632379; //r 
    data[3941]=(string[])null; //dst 
    data[1983]=313; //var_forIndex_1 
    data[1675]=200; //invocationTemp_8 
    data[651]=false; //var_whileCondition_1 
    data[1296]=-570; //invocationTemp_9 
    data[1509]=-909; //memberTemp_1 
    data[2780]=-841; //jmpWhileDestinationName_2780 constant
    data[2915]=57; //while_GoTo_True_2915 constant
    data[737]=563; //while_GoTo_False_737 constant
    data[2784]=-563; //while_FalseBlockSkip_2784 constant

    //Code init

    code[66]=6244; //ExpressionStatement_13 # ExpressionStatement_13
    code[87]=3213; //sum
    code[94]=74; //""
    code[62]=2180; //3
    code[54]=2297; //4
    code[65]=74; //""

    code[132]=2386; //ExpressionStatement_14 # ExpressionStatement_14
    code[123]=2875; //invocationTemp_0

    code[202]=3169; //ExpressionStatement_15 # ExpressionStatement_15
    code[218]=3913; //invocationTemp_1
    code[211]=2875; //invocationTemp_0

    code[271]=7779; //ExpressionStatement_16 # ExpressionStatement_16
    code[256]=3695; //invocationTemp_2
    code[280]=3913; //invocationTemp_1

    code[335]=1545; //ExpressionStatement_17 # ExpressionStatement_17
    code[344]=3747; //p1
    code[345]=3695; //invocationTemp_2

    code[402]=6460; //ExpressionStatement_18 # ExpressionStatement_18
    code[422]=3213; //sum
    code[405]=3213; //sum
    code[388]=406; //"["
    code[386]=3747; //p1
    code[429]=2495; //"]"

    code[473]=2386; //ExpressionStatement_14 # ExpressionStatement_19
    code[464]=2296; //invocationTemp_3

    code[543]=2386; //ExpressionStatement_14 # ExpressionStatement_20
    code[534]=3498; //invocationTemp_4

    code[613]=3169; //ExpressionStatement_15 # ExpressionStatement_21
    code[629]=3558; //invocationTemp_5
    code[622]=3498; //invocationTemp_4

    code[682]=4960; //ExpressionStatement_22 # ExpressionStatement_22
    code[711]=2375; //memberTemp_0
    code[663]=3558; //invocationTemp_5

    code[745]=6619; //ExpressionStatement_23 # ExpressionStatement_23
    code[753]=2155; //invocationTemp_6
    code[768]=2296; //invocationTemp_3
    code[756]=2375; //memberTemp_0
    code[765]=1704; //1

    code[812]=8351; //ExpressionStatement_24 # ExpressionStatement_24
    code[816]=898; //invocationTemp_7
    code[793]=2155; //invocationTemp_6

    code[882]=7644; //ExpressionStatement_25 # ExpressionStatement_25
    code[871]=3213; //sum
    code[862]=3213; //sum
    code[889]=898; //invocationTemp_7

    code[946]=3105; //ExpressionStatement_5 # ExpressionStatement_26
    code[930]=3841; //r
    code[932]=74; //""

    code[998]=5282; //ExpressionStatement_27 # ExpressionStatement_27
    code[1014]=3941; //dst
    code[993]=2398; //b

    code[1066]=3105; //ExpressionStatement_5 # ExpressionStatement_28
    code[1050]=1983; //var_forIndex_1
    code[1052]=3722; //0

    code[1118]=5554; //ExpressionStatement_29 # ExpressionStatement_29
    code[1128]=1675; //invocationTemp_8
    code[1144]=2398; //b

    code[1188]=5419; //ExpressionStatement_30 # ExpressionStatement_30
    code[1196]=651; //var_whileCondition_1
    code[1210]=1983; //var_forIndex_1
    code[1217]=1675; //invocationTemp_8

    code[1257]=6442; //IfStatementSyntax_2 # WhileStatementSyntax_31
    code[1242]=2780; //jmpWhileDestinationName_2780
    code[1274]=651; //var_whileCondition_1
    code[1268]=2915; //while_GoTo_True_2915
    code[1281]=737; //while_GoTo_False_737

    code[1314]=6265; //ExpressionStatement_32 # ExpressionStatement_32
    code[1339]=3213; //sum
    code[1297]=3213; //sum
    code[1322]=744; //"_"
    code[1319]=1983; //var_forIndex_1
    code[1300]=744; //"_"

    code[1373]=7644; //ExpressionStatement_25 # ExpressionStatement_33
    code[1362]=3213; //sum
    code[1353]=3213; //sum
    code[1380]=1065; //"~"

    code[1437]=9034; //ExpressionStatement_34 # ExpressionStatement_34
    code[1444]=3841; //r
    code[1462]=3841; //r
    code[1461]=3213; //sum
    code[1436]=1339; //"#"

    code[1499]=4502; //ExpressionStatement_35 # ExpressionStatement_35
    code[1522]=3941; //dst
    code[1487]=1983; //var_forIndex_1
    code[1523]=3213; //sum

    code[1554]=1402; //ExpressionStatement_9 # ExpressionStatement_36
    code[1569]=1983; //var_forIndex_1
    code[1559]=1983; //var_forIndex_1
    code[1553]=1704; //1

    code[1618]=5554; //ExpressionStatement_29 # ExpressionStatement_37
    code[1628]=1296; //invocationTemp_9
    code[1644]=2398; //b

    code[1688]=5419; //ExpressionStatement_30 # ExpressionStatement_38
    code[1696]=651; //var_whileCondition_1
    code[1710]=1983; //var_forIndex_1
    code[1717]=1296; //invocationTemp_9

    code[1757]=9095; //ExpressionStatement_4 # ExpressionStatement_39
    code[1770]=2784; //while_FalseBlockSkip_2784

    code[1820]=7019; //ExpressionStatement_40 # ExpressionStatement_40
    code[1840]=1509; //memberTemp_1
    code[1848]=3941; //dst

    code[1878]=8015; //ExpressionStatement_41 # ExpressionStatement_41
    code[1883]=3213; //sum
    code[1877]=3213; //sum
    code[1879]=1339; //"#"
    code[1904]=1509; //memberTemp_1

    code[1937]=8233; //ReturnStatement_42 # ReturnStatement_42
    code[1931]=3213; //sum

    return (string)InstanceInterpreterVirtualization_BinarySearch_Iterative_3054(vpc, data, code);

}

        private int ReturnArg_Array(int val)
        {
            return val;
        }

        private static int BinarySearchIterative_obfuscated(int[] inputArray, int key, int min, int max)
        {
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Iterative_ctrl_flow";
            Program.Start_Check(testName);
            bool condition = true;


            // Create an unsorted array of string elements
            //            int[] testData = GenerateDataStatic();
            int[] data = GenerateDataInt(360);
            var int_list = new List<int>(data);
            
            int[] unsorted_original = int_list.ToArray();

            // Sort the array
            Quicksort_original(unsorted_original, 0, unsorted_original.Length - 1);

            int key1 = unsorted_original[20];
            int key2 = unsorted_original[300];
            int key3 = unsorted_original[160];
            int key4 = -1;

            int res1 = BinarySearchIterative_original(unsorted_original, key1, 0, unsorted_original.Length - 1);
            int res2 = BinarySearchIterative_original(unsorted_original, key2, 0, unsorted_original.Length - 1);
            int res3 = BinarySearchIterative_original(unsorted_original, key3, 0, unsorted_original.Length - 1);
            int res4 = BinarySearchIterative_original(unsorted_original, key4, 0, unsorted_original.Length - 1);

            // Print the sorted array
            string sortedOriginalHash = "20_300_160_-1";
            string sortedObfuscatedHash = res1 + "_" + res2 + "_" + res3 + "_" + res4;
           
            Console.WriteLine("ori: " + sortedOriginalHash);
            Console.WriteLine("obf: " + sortedObfuscatedHash);

            string virt = sortedObfuscatedHash;
            string oracle = sortedOriginalHash;
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

       


        private int[] GenerateDataStatic()
        {
            int[] arr = {4, 3, 5, 2, 1, 3, 2, 3, 89201, 45932, 56552, 58302, 3768, 99875, 26543, 44898, 93328, 35746, 23265, 86042, 69630, 45843, 64590, 69515, 58230, 99227, 87729, 13089, 33472, 30304, 79972,23975, 45058, 35066, 81533, 81112, 79368, 17658, 79228, 30577, 67501, 45700, 94125, 30606, 21605, 54404, 96450, 29349, 94577, 81012, 87055, 50237, 86788, 6366,69903, 64801, 13172, 53670, 62243, 43631, 71885, 86104, 1582, 58896, 65960, 32577, 13243, 68702, 18341, 45430, 65530, 75669, 56518, 92687, 18541, 23930, 51718,33983, 47910, 3826, 2777, 58379, 18511, 52459, 43249, 29735, 37186, 38692, 65163, 16732, 67940, 25698, 55414, 35596, 58691, 
    75028, 47371, 69363, 36976, 31863, 36015,  23};

            return arr;
        }

        private int[] GenerateDataInt(int elements)
        {
            string[] str = new string[elements];
            int[] int1 = new int[elements];

            Random rand = new Random();
            for (int i = 0; i < elements; i++)
            {
                int element = rand.Next(-1000000, 1000000);
                int1[i] = element;
            }

            return int1;
        }

        private string Quicksort_original(int[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i] < pivot)
                {
                    i++;
                }

                while (elements[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort_original(elements, left, j);
            }

            if (i < right)
            {
                Quicksort_original(elements, i, right);
            }

            return "";
        }

        


        public static string Time_Operation(string id,  Func<int[], int, int, int, int> method)
        {

            int op = 0;
            string log = id + " warming ... " + WARMUP + " times X elements " + testData.Count + " keys " + keys.Count;
            Output(log);
            int[] unsorted_original = testData.ToArray();
            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < WARMUP; i++)
            {
                foreach(var key in keys)
                    method(unsorted_original, key, 0, unsorted_original.Length-1);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("{0}    , sec", timespan.TotalSeconds);
            log = id + " " + " warmed up in,    " + time;
            Output(log);
            time_warmup.Add(log);

            log = id + " running ... " + ITERATIONS + " times X elements " + testData.Count + " keys " + keys.Count;
            Output(log);
            timer = Stopwatch.StartNew();
            for (int j = 0; j < ITERATIONS; j++)
            {
                foreach (var key in keys)
                    method(unsorted_original, key, 0, unsorted_original.Length - 1);
            }
            timer.Stop();
            timespan = timer.Elapsed;

            time = String.Format("{0}   , sec", timespan.TotalSeconds);
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

private object InstanceInterpreterVirtualization_BinarySearch_Iterative_3054(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 9095:  //frequency 3 ExpressionStatement_4
                vpc += (int)data[code[vpc + (13)]];
                vpc += 63;
                break;
            case 7887:  //frequency 1 ExpressionStatement_0
                data[code[vpc + (22)]] = (int)data[code[vpc + (-6)]] + (long)data[code[vpc + (20)]];
                vpc += 56;
                break;
            case 7902:  //frequency 2 ReturnStatement_3
                return (long)data[code[vpc + (3)]];
                vpc += 60;
            case 6460:  //frequency 1 ExpressionStatement_18
                data[code[vpc + (20)]] = (string)data[code[vpc + (3)]] + (string)data[code[vpc + (-14)]] + (double)data[code[vpc + (-16)]] + (string)data[code[vpc + (27)]];
                vpc += 71;
                break;
            case 7779:  //frequency 1 ExpressionStatement_16
                data[code[vpc + (-15)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (9)]]).First());
                vpc += 64;
                break;
            case 7644:  //frequency 2 ExpressionStatement_25
                data[code[vpc + (-11)]] = (string)data[code[vpc + (-20)]] + (string)data[code[vpc + (7)]];
                vpc += 64;
                break;
            case 8351:  //frequency 1 ExpressionStatement_24
                data[code[vpc + (4)]] = ((ConsoleCalculator.Piston)data[code[vpc + (-19)]]).ToString();
                vpc += 70;
                break;
            case 4502:  //frequency 1 ExpressionStatement_35
                ((string[])data[code[vpc + (23)]])[(int)data[code[vpc + (-12)]]] = (string)data[code[vpc + (24)]];
                vpc += 55;
                break;
            case 6244:  //frequency 1 ExpressionStatement_13
                data[code[vpc + (21)]] = (string)data[code[vpc + (28)]] + (int)data[code[vpc + (-4)]] + (int)data[code[vpc + (-12)]] + (string)data[code[vpc + (-1)]];
                vpc += 66;
                break;
            case 6265:  //frequency 1 ExpressionStatement_32
                data[code[vpc + (25)]] = (string)data[code[vpc + (-17)]] + (string)data[code[vpc + (8)]] + (int)data[code[vpc + (5)]] + (string)data[code[vpc + (-14)]];
                vpc += 59;
                break;
            case 7019:  //frequency 1 ExpressionStatement_40
                data[code[vpc + (20)]] = ((string[])data[code[vpc + (28)]]).Length;
                vpc += 58;
                break;
            case 2386:  //frequency 3 ExpressionStatement_14
                data[code[vpc + (-9)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                vpc += 70;
                break;
            case 1086:  //frequency 1 ExpressionStatement_8
                data[code[vpc + (-16)]] = (long)data[code[vpc + (-13)]] * (int)data[code[vpc + (5)]];
                vpc += 67;
                break;
            case 3105:  //frequency 3 ExpressionStatement_5
                data[code[vpc + (-16)]] = data[code[vpc + (-14)]];
                vpc += 52;
                break;
            case 6619:  //frequency 1 ExpressionStatement_23
                data[code[vpc + (8)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (23)]]).GetPiston((int)data[code[vpc + (11)]] - (int)data[code[vpc + (20)]]));
                vpc += 67;
                break;
            case 9058:  //frequency 1 ExpressionStatement_1
                data[code[vpc + (26)]] = (int)data[code[vpc + (-6)]] == (int)data[code[vpc + (17)]];
                vpc += 56;
                break;
            case 7369:  //frequency 2 ExpressionStatement_6
                data[code[vpc + (29)]] = (int)data[code[vpc + (23)]] <= (int)data[code[vpc + (25)]];
                vpc += 67;
                break;
            case 3169:  //frequency 2 ExpressionStatement_15
                data[code[vpc + (16)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (9)]]).GetPistons());
                vpc += 69;
                break;
            default:  //frequency 0 
                break;
            case 8015:  //frequency 1 ExpressionStatement_41
                data[code[vpc + (5)]] = (string)data[code[vpc + (-1)]] + (string)data[code[vpc + (1)]] + (int)data[code[vpc + (26)]];
                vpc += 59;
                break;
            case 6442:  //frequency 3 IfStatementSyntax_2
                data[code[vpc + (-15)]] = (bool)data[code[vpc + (17)]] ? (int)data[code[vpc + (11)]] : (int)data[code[vpc + (24)]];
                vpc += (int)data[code[vpc + (-15)]];
                break;
            case 1545:  //frequency 1 ExpressionStatement_17
                data[code[vpc + (9)]] = ((ConsoleCalculator.Piston)data[code[vpc + (10)]]).GetSize();
                vpc += 67;
                break;
            case 1402:  //frequency 2 ExpressionStatement_9
                data[code[vpc + (15)]] = (int)data[code[vpc + (5)]] + (int)data[code[vpc + (-1)]];
                vpc += 64;
                break;
            case 9034:  //frequency 1 ExpressionStatement_34
                data[code[vpc + (7)]] = (string)data[code[vpc + (25)]] + (string)data[code[vpc + (24)]] + (string)data[code[vpc + (-1)]];
                vpc += 62;
                break;
            case 5554:  //frequency 2 ExpressionStatement_29
                data[code[vpc + (10)]] = ReturnArg_Array((int)data[code[vpc + (26)]]);
                vpc += 70;
                break;
            case 8233:  //frequency 1 ReturnStatement_42
                return (string)data[code[vpc + (-6)]];
                vpc += 56;
            case 5419:  //frequency 2 ExpressionStatement_30
                data[code[vpc + (8)]] = (int)data[code[vpc + (22)]] < (int)data[code[vpc + (29)]];
                vpc += 69;
                break;
            case 4960:  //frequency 1 ExpressionStatement_22
                data[code[vpc + (29)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-19)]]).Count;
                vpc += 63;
                break;
            case 5282:  //frequency 1 ExpressionStatement_27
                data[code[vpc + (16)]] = (string[])(new string[(int)data[code[vpc + (-5)]]]);
                vpc += 68;
                break;
        }
    }

    return null;
}


    }
}