using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Recursive_method
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
            BinarySearch_Recursive_method bs = new BinarySearch_Recursive_method();
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

            result += "t_original";
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
                string t_original = Time_Operation(i+ " BinarySearch_Recursive_method", BinarySearchRecursive_obfuscated);

                result += " " + t_original;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);

            PrintTimes();
        }



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

//                [Obfuscation(Exclude = false, Feature = "virtualization; method")]
private static int BinarySearchRecursive_obfuscated(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    int[] code = new int[100946];
    object[] data = new object[4504];
    int vpc = 117;

    code[74932]=-53;code[2798]=96;code[100413]=1228;code[17679]=308;code[81663]=-360;code[26390]=503;
    code[41813]=-272;code[64091]=-8;code[19210]=1363;code[93749]=-485;code[17667]=729;code[77230]=-297;
    code[56110]=-725;code[12503]=-147;code[35734]=663;code[72262]=-206;code[6414]=1136;code[64425]=124;
    code[81720]=243;code[29213]=-233;code[41877]=-520;code[60785]=1355;code[59197]=608;code[99306]=1194;
    code[18864]=-771;code[77565]=64;code[32865]=-667;code[100227]=-875;code[61981]=865;code[89119]=1211;
    code[77461]=1084;code[17119]=-641;code[54563]=1358;code[54301]=399;code[65931]=-538;code[59291]=731;
    code[66206]=553;code[79901]=1456;code[9060]=1057;code[70160]=1281;code[12776]=-385;code[15581]=-345;
    code[90544]=-275;code[100177]=1325;code[86971]=469;code[84387]=-842;code[62053]=12;code[54491]=452;
    code[2286]=146;code[40538]=607;code[10639]=60;code[22663]=-996;code[50903]=-811;code[77711]=760;
    code[34493]=-975;code[96972]=977;code[5169]=1425;code[76500]=302;code[68596]=1268;code[24899]=-375;
    code[96004]=519;code[70478]=-837;code[35223]=310;code[7872]=-373;code[8251]=-474;code[96920]=578;
    code[42533]=-870;code[81474]=756;code[2189]=-619;code[76525]=1053;code[52522]=-280;code[59415]=1128;
    code[63310]=-888;code[1220]=610;code[65326]=-954;code[90992]=-712;code[21386]=-622;code[69845]=244;
    code[73267]=-603;code[65918]=1450;code[100710]=297;code[62816]=-673;code[5046]=-177;code[37321]=1497;
    code[16477]=-862;code[50418]=317;code[15054]=63;code[73696]=656;code[1922]=1116;code[44228]=-240;
    code[51681]=84;code[60942]=-843;code[31210]=1111;code[42332]=-325;code[36355]=-227;code[98597]=1156;
    code[50410]=944;code[83139]=-997;code[67238]=143;code[80903]=-256;code[68157]=-968;code[48570]=479;
    code[52410]=-65;code[97541]=966;code[42513]=-927;code[48324]=1197;code[72786]=-128;code[47265]=410;
    code[92389]=398;code[82970]=-487;code[91865]=-752;code[64503]=1134;code[7928]=592;code[2801]=-72;
    code[60744]=821;code[100601]=403;code[4570]=-650;code[63478]=247;code[96144]=-971;code[54902]=1337;
    code[88672]=582;code[85700]=-173;code[83847]=-756;code[14277]=-624;code[31258]=-352;code[8690]=-733;
    code[64154]=490;code[39136]=439;code[37747]=568;code[51818]=1205;code[34979]=487;code[18646]=731;
    code[3294]=1292;code[84168]=451;code[72694]=1422;code[61740]=1258;code[1546]=1217;code[32994]=-308;
    code[25296]=-230;code[2347]=1452;code[50021]=1193;code[6218]=-145;code[64870]=1224;code[93478]=122;
    code[75979]=-867;code[12626]=-188;code[50323]=654;code[59395]=-292;code[45239]=-609;code[30110]=1283;
    code[26635]=401;code[43433]=-149;code[65403]=-544;code[9243]=871;code[27187]=-724;code[32807]=-836;
    code[60973]=331;code[39035]=172;code[53846]=1106;code[5027]=-643;code[100049]=-39;code[83581]=667;
    code[85208]=-284;code[40870]=-116;code[30144]=-892;code[83684]=-765;code[987]=-726;code[72379]=1336;
    code[45129]=802;code[70087]=149;code[80568]=-557;code[18146]=605;code[73511]=-852;code[72796]=1415;
    code[27756]=-702;code[75706]=514;code[10776]=-612;code[93105]=1197;code[73970]=908;code[50104]=-97;
    code[78517]=844;code[45414]=-436;code[28418]=-423;code[5661]=235;code[82314]=129;code[2232]=1030;
    code[14957]=474;code[34803]=1034;code[20687]=-536;code[94753]=962;code[57065]=97;code[7943]=-552;
    code[29624]=-442;code[99661]=1136;code[18922]=1094;code[20388]=709;code[22691]=-168;code[68854]=-850;
    code[73450]=1384;code[36403]=243;code[315]=-433;code[15205]=1057;code[9802]=1344;code[46181]=292;
    code[81824]=-729;code[68058]=367;code[83249]=778;code[80365]=-153;code[66545]=-324;code[94121]=-855;
    code[24597]=-496;code[30967]=1443;code[25232]=-154;code[59305]=1038;code[91634]=-289;code[8680]=-373;
    code[83300]=103;code[78915]=-155;code[29089]=-361;code[8307]=-111;code[77308]=176;code[4424]=-804;
    code[16519]=637;code[86710]=283;code[54180]=-143;code[40479]=142;code[2169]=-244;code[25599]=1003;
    code[92883]=-568;code[57848]=896;code[35349]=605;code[61487]=315;code[2294]=57;code[72855]=-42;
    code[93847]=144;code[5132]=8;code[18996]=441;code[29508]=933;code[15933]=-430;code[82161]=487;
    code[48395]=-815;code[28121]=411;code[89188]=572;code[23173]=306;code[18957]=1450;code[42220]=-713;
    code[68904]=-191;code[566]=-691;code[86943]=294;code[5653]=851;code[94212]=189;code[58915]=-803;
    code[29499]=1493;code[27149]=112;code[1022]=200;code[64969]=730;code[36252]=1445;code[28190]=-310;
    code[36703]=-889;code[64857]=-16;code[19543]=-503;code[19734]=1373;code[3985]=1339;code[72778]=1161;
    code[57639]=-579;code[92059]=600;code[17365]=-817;code[66787]=-991;code[49517]=-502;code[27502]=1215;
    code[36329]=961;code[51747]=768;code[33988]=815;code[76312]=761;code[4476]=824;code[76725]=1042;
    code[88355]=655;code[55204]=835;code[28283]=585;code[3989]=-109;code[27909]=10;code[88213]=1103;
    code[57372]=-992;code[52498]=-286;code[31951]=-312;code[79289]=-590;code[77927]=891;code[3431]=22;
    code[69284]=220;code[61846]=-217;code[18145]=-959;code[82798]=1103;code[41243]=-763;code[77199]=274;
    code[53154]=1318;code[73039]=1140;code[16157]=1289;code[61537]=1388;code[91941]=677;code[14043]=-168;
    code[20802]=175;code[39158]=922;code[95305]=490;code[4530]=-703;code[63405]=-656;code[4841]=980;
    code[2178]=815;code[17840]=-351;code[58966]=-919;code[43698]=183;code[24104]=-975;code[76628]=-27;
    code[55718]=1322;code[398]=1140;code[14819]=-804;code[50281]=-962;code[35220]=-302;code[10826]=773;
    code[63454]=-872;code[90573]=1031;code[5070]=614;code[89013]=-29;code[88765]=1328;code[84257]=84;
    code[74620]=-126;code[37487]=1195;code[24051]=664;code[9524]=-511;code[71789]=1496;code[21890]=-963;
    code[59770]=-528;code[98124]=374;code[64589]=-919;code[44743]=855;code[62479]=168;code[63732]=331;
    code[13650]=550;code[42700]=482;code[12956]=-74;code[51469]=551;code[9539]=425;code[11791]=992;
    code[71379]=549;code[78428]=707;code[18693]=1278;code[100772]=574;code[84243]=1205;code[22249]=1153;
    code[68020]=-170;code[75583]=1116;code[49276]=-769;code[82262]=-321;code[72508]=1096;code[75011]=544;
    code[24516]=253;code[6820]=-149;code[49343]=490;code[92913]=-945;code[7272]=-563;code[85048]=-950;
    code[25823]=900;code[56211]=769;code[47340]=-997;code[70478]=-368;code[40375]=404;code[92772]=990;
    code[62762]=658;code[13366]=-996;code[76229]=1112;code[7960]=1171;code[88497]=-603;code[44432]=709;
    code[85172]=644;code[14243]=-405;code[97097]=-505;code[79679]=247;code[49427]=821;code[59635]=819;
    code[54085]=-732;code[81055]=792;code[14177]=225;code[21996]=703;code[58792]=-322;code[72571]=1063;
    code[46826]=1296;code[26939]=-433;code[9696]=1435;code[14472]=-759;code[32306]=1182;code[87202]=1028;
    code[86847]=149;code[29376]=-497;code[77958]=50;code[30943]=1232;code[7320]=11;code[47047]=619;
    code[4228]=-95;code[73490]=-34;code[95004]=897;code[10225]=430;code[94756]=-212;code[78169]=-892;
    code[94031]=405;code[40668]=289;code[59085]=235;code[41175]=656;code[24574]=1479;code[86460]=701;
    code[20106]=-960;code[91754]=-595;code[97395]=1064;code[76012]=-852;code[45678]=547;code[18703]=835;
    code[24833]=892;code[15706]=402;code[77912]=-272;code[88090]=361;code[69202]=-381;code[27262]=-475;
    code[1739]=977;code[31063]=446;code[100598]=1008;code[40822]=-875;code[51026]=-882;code[18908]=1312;
    code[85801]=1347;code[61328]=-718;code[56788]=787;code[59638]=-219;code[38043]=672;code[27214]=1071;
    code[34162]=1116;code[89924]=1379;code[12007]=-221;code[100437]=1378;code[75329]=747;code[14644]=-566;
    code[52304]=-564;code[6343]=622;code[21664]=-663;code[23072]=-504;code[57493]=-424;code[71785]=1082;
    code[69040]=899;code[99147]=1426;code[66311]=1393;code[84112]=-129;code[52626]=198;code[24233]=-626;
    code[92120]=131;code[94012]=-516;code[5302]=-411;code[18027]=-623;code[80142]=84;code[60029]=-30;
    code[65828]=1354;code[9880]=-396;code[44442]=-823;code[26134]=-731;code[13694]=-856;code[27054]=-103;
    code[33267]=-940;code[29734]=971;code[87374]=991;code[65873]=-903;code[94328]=1282;code[74348]=905;
    code[20560]=-913;code[14735]=-166;code[5267]=399;code[3928]=-375;code[16671]=485;code[32147]=788;
    code[86783]=478;code[91673]=125;code[22245]=-669;code[1424]=1136;code[18618]=430;code[87234]=-930;
    code[95017]=-26;code[28828]=1493;code[78845]=389;code[45789]=847;code[20710]=-161;code[3854]=13;
    code[93386]=1312;code[5599]=439;code[1925]=-956;code[19579]=838;code[71259]=448;code[93772]=-315;
    code[89691]=-495;code[82624]=1005;code[90744]=1204;code[58317]=578;code[17226]=-706;code[39614]=655;
    code[27698]=-896;code[47366]=523;code[14185]=448;code[51486]=309;code[55843]=256;code[53008]=-263;code[659]=917;code[892]=3147;code[458]=4043;    data[66]=466;
code[698]=3382;code[608]=3590;code[885]=1271;code[103]=3724;code[171]=7383;    data[3148]=1;
code[438]=3590;    data[2038]=-979;
    data[2495]=67;
    data[3724]=max;
code[827]=3148;code[1068]=3590;code[479]=3382;code[859]=3590;code[915]=3382;    data[569]=-1;
code[344]=3147;code[390]=2070;code[1192]=9352;code[1145]=3382;code[404]=121;code[750]=2495;    data[2686]=-886;
code[355]=2070;code[638]=7133;code[757]=347;    data[1529]=899;
code[687]=3590;code[854]=1208;code[1079]=2038;code[525]=2686;    data[1855]=67;
code[766]=7383;code[117]=8297;    data[2542]=false;
code[962]=9352;    data[1271]=key;
code[1055]=3148;    data[121]=2;
code[386]=3590;code[793]=914;code[586]=9352;code[519]=7383;code[345]=7504;code[162]=702;    data[914]=false;
    data[2174]=false;
    data[917]=551;
code[1112]=2897;    data[3369]=533;
    data[347]=303;
code[1115]=1271;code[503]=1855;code[238]=9352;code[510]=936;code[1111]=3724;code[114]=2174;code[455]=1271;    data[686]=-378;
    data[3590]=968;
code[1122]=2038;    data[1208]=-941;
code[679]=914;code[1069]=7504;    data[936]=174;
code[260]=569;    data[702]=174;
code[119]=3147;code[459]=2542;code[984]=66;code[713]=1271;code[1014]=7133;code[1214]=2897;code[1123]=6309;code[882]=66;code[693]=1927;    data[2070]=-347;
code[881]=1208;    data[2897]=827;
    data[3147]=min;
code[331]=3724;code[772]=3369;code[546]=2542;code[290]=7133;    data[1612]=175;
code[198]=2174;        data[3382]=(int[])inputArray;
code[177]=686;code[833]=1201;code[155]=3976;code[399]=8607;    data[3976]=67;
code[311]=1529;code[893]=6309;code[1035]=1612;
    while(true)
    {
    	switch(code[vpc])
    	{
    		case 6309:
    			data[code[vpc+(-11)]]= BinarySearchRecursive_obfuscated((int[])data[code[vpc+(22)]], (int)data[code[vpc+(-8)]], (int)data[code[vpc+(-1)]], (int)data[code[vpc+(-12)]]);
    			vpc+=69;
    			break;
    		case 1927:
    			data[code[vpc+(-14)]]= (int)data[code[vpc+(20)]]< ((int[])data[code[vpc+(5)]])[(int)data[code[vpc+(-6)]]];
    			vpc+=73;
    			break;
    		case 8297:
    			data[code[vpc+(-3)]]= (int)data[code[vpc+(-14)]]< (int)data[code[vpc+(2)]];
    			vpc+=54;
    			break;
    		case 7133:
    			vpc += (int)data[code[vpc+(21)]];
    			vpc+=55;
    			break;
    		case 7383:
    			data[code[vpc+(6)]]=(bool)data[code[vpc+(27)]]?(int)data[code[vpc+(-16)]]:(int)data[code[vpc+(-9)]];
    			vpc+=(int)data[code[vpc+(6)]];
    			break;
    		default:
    			break;
    		case 1201:
    			data[code[vpc+(21)]]= (int)data[code[vpc+(26)]]- (int)data[code[vpc+(-6)]];
    			vpc+=60;
    			break;
    		case 4043:
    			data[code[vpc+(1)]]= (int)data[code[vpc+(-3)]]== ((int[])data[code[vpc+(21)]])[(int)data[code[vpc+(-20)]]];
    			vpc+=61;
    			break;
    		case 7504:
    			data[code[vpc+(10)]]= (int)data[code[vpc+(-1)]]+ (int)data[code[vpc+(-14)]];
    			vpc+=54;
    			break;
    		case 9352:
    			return (int)data[code[vpc+(22)]];
    			vpc+=52;
    		case 8607:
    			data[code[vpc+(-13)]]= (int)data[code[vpc+(-9)]]/ (int)data[code[vpc+(5)]];
    			vpc+=59;
    			break;
    	}
    }

    return 0;
}

        


        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Recursive_method";
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

            int res11 = BinarySearchRecursive_obfuscated(unsorted_original, key1, 0, unsorted_original.Length - 1);
            int res22 = BinarySearchRecursive_obfuscated(unsorted_original, key2, 0, unsorted_original.Length - 1);
            int res33 = BinarySearchRecursive_obfuscated(unsorted_original, key3, 0, unsorted_original.Length - 1);
            int res44 = BinarySearchRecursive_obfuscated(unsorted_original, key4, 0, unsorted_original.Length - 1);

            // Print the sorted array
            string sortedOriginalHash = res1 + "_" + res2 + "_" + res3 + "_" + res4;
            string sortedObfuscatedHash = res11 + "_" + res22 + "_" + res33 + "_" + res44;
           
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


    }
}