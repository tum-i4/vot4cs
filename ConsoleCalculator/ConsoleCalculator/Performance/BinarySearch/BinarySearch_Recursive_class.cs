using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Recursive_class
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
            BinarySearch_Recursive_class bs = new BinarySearch_Recursive_class();
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

//            result += "t_original";
//            result += "     t_method";
            result += "     t_class";
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
                string t_original = Time_Operation(i+ " BinarySearch_Recursive_class", BinarySearchRecursive_obfuscated);

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


//        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]
private static int BinarySearchRecursive_obfuscated(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    int[] code = new int[100781];
    object[] data = new object[4967];
    int vpc = 64;

    code[96819]=-196;code[9525]=-58;code[17399]=1070;code[56695]=-970;code[12326]=132;code[93530]=1446;
    code[19840]=364;code[96349]=925;code[19017]=152;code[37375]=-504;code[39110]=-209;code[86843]=132;
    code[92191]=1106;code[54500]=201;code[62846]=265;code[73713]=1292;code[37031]=-317;code[80360]=924;
    code[60357]=1395;code[55067]=1434;code[81529]=635;code[13551]=1288;code[64367]=-731;code[8620]=-899;
    code[41020]=1337;code[80768]=346;code[16770]=1476;code[6598]=610;code[46357]=603;code[46598]=-175;
    code[28949]=-796;code[39168]=539;code[72703]=-973;code[61582]=1308;code[75424]=-535;code[17261]=-425;
    code[92179]=-8;code[39281]=834;code[18357]=1365;code[82064]=1017;code[76287]=250;code[7424]=721;
    code[71046]=-518;code[75653]=-59;code[20954]=-617;code[31243]=1393;code[49983]=-460;code[69198]=817;
    code[26765]=296;code[19560]=569;code[50075]=-595;code[29458]=-448;code[76951]=427;code[62871]=923;
    code[60556]=-171;code[46553]=284;code[83369]=638;code[57764]=967;code[826]=749;code[91805]=321;
    code[26232]=-415;code[72112]=487;code[88286]=-466;code[74012]=745;code[71588]=656;code[47190]=658;
    code[75799]=-534;code[31238]=487;code[20938]=1131;code[93240]=-666;code[57352]=1453;code[78197]=1190;
    code[69676]=990;code[13113]=1101;code[64811]=1248;code[72452]=414;code[61235]=664;code[37029]=-344;
    code[45000]=743;code[34764]=374;code[84320]=1313;code[5954]=1345;code[87011]=995;code[76757]=601;
    code[34826]=1445;code[58393]=-612;code[78075]=942;code[96686]=-303;code[46191]=1098;code[91078]=-801;
    code[8444]=1234;code[5571]=1027;code[95110]=1256;code[5641]=-784;code[82553]=-882;code[14953]=276;
    code[51168]=-62;code[29953]=609;code[92935]=1094;code[1301]=1232;code[3488]=223;code[49872]=662;
    code[32253]=408;code[79713]=1076;code[71174]=-780;code[81055]=518;code[79965]=-338;code[46948]=1356;
    code[87695]=-380;code[100223]=1402;code[74815]=687;code[82794]=-255;code[83637]=-828;code[65284]=-3;
    code[48357]=-211;code[35966]=551;code[83278]=-974;code[4552]=485;code[40222]=-24;code[49467]=-50;
    code[11247]=-437;code[38324]=826;code[24496]=352;code[72267]=-394;code[91679]=-114;code[77949]=684;
    code[84980]=-870;code[15183]=-102;code[67312]=-509;code[84143]=-373;code[92274]=-21;code[35345]=-24;
    code[73720]=-541;code[78702]=956;code[22172]=1178;code[54783]=199;code[76325]=535;code[85582]=292;
    code[29714]=-774;code[5558]=-278;code[35451]=13;code[49328]=-687;code[54652]=707;code[78346]=935;
    code[86675]=714;code[93366]=-494;code[55987]=-401;code[46835]=799;code[88151]=1474;code[100705]=-852;
    code[76608]=1335;code[2271]=-905;code[81723]=-266;code[92375]=-428;code[20447]=584;code[6514]=442;
    code[14259]=365;code[90641]=275;code[90937]=-437;code[85479]=-879;code[40941]=-984;code[92990]=335;
    code[95243]=-148;code[93137]=294;code[15056]=-677;code[64725]=-238;code[9223]=1489;code[53276]=43;
    code[38569]=128;code[31686]=-379;code[77228]=370;code[57579]=-435;code[62588]=-127;code[6144]=-977;
    code[34292]=1385;code[82384]=623;code[14272]=1376;code[65826]=883;code[1170]=220;code[9385]=174;
    code[37246]=-3;code[8031]=-817;code[99920]=899;code[48940]=-636;code[1761]=204;code[12863]=127;
    code[91809]=499;code[28447]=1144;code[43875]=740;code[92040]=489;code[28234]=1286;code[17879]=-513;
    code[31436]=1482;code[16469]=-648;code[34523]=937;code[40900]=1236;code[36093]=1111;code[88581]=-82;
    code[47226]=244;code[23669]=1153;code[87041]=1288;code[99968]=1145;code[83318]=-84;code[74407]=354;
    code[67361]=988;code[32058]=-212;code[57941]=243;code[19110]=137;code[22324]=1211;code[76750]=1496;
    code[60082]=-139;code[80946]=-395;code[7670]=-418;code[9363]=-835;code[72629]=1287;code[39237]=1343;
    code[46510]=-871;code[73779]=-88;code[92999]=-203;code[37116]=1363;code[25662]=553;code[47612]=368;
    code[46064]=-774;code[32206]=1151;code[66011]=60;code[14699]=459;code[74202]=-410;code[26732]=297;
    code[11288]=874;code[78830]=483;code[27563]=679;code[82771]=883;code[40905]=-49;code[86038]=307;
    code[77125]=1061;code[53619]=1256;code[52040]=1040;code[74968]=1436;code[87914]=-361;code[79133]=1463;
    code[92070]=-420;code[41455]=-259;code[77503]=1013;code[20280]=-438;code[79271]=-468;code[25491]=-568;
    code[54107]=936;code[67726]=456;code[80637]=797;code[14255]=-809;code[23871]=991;code[9623]=1075;
    code[89903]=-392;code[6808]=1300;code[49631]=-274;code[65160]=1140;code[97196]=991;code[68531]=-897;
    code[26264]=311;code[99215]=501;code[18075]=571;code[74225]=380;code[57619]=-103;code[36839]=854;
    code[14514]=-597;code[17596]=-617;code[11530]=771;code[75448]=-708;code[13771]=452;code[40763]=314;
    code[74360]=-298;code[73840]=240;code[57103]=-9;code[21033]=850;code[9543]=576;code[32457]=-312;
    code[74018]=352;code[90413]=520;code[6044]=358;code[26060]=332;code[88473]=-186;code[78226]=-172;
    code[11681]=232;code[74751]=-361;code[4841]=407;code[91176]=698;code[12120]=147;code[86935]=1245;
    code[90286]=-399;code[99317]=-563;code[15136]=563;code[65203]=283;code[84568]=1248;code[42221]=433;
    code[81790]=-650;code[5756]=483;code[32495]=1178;code[65277]=29;code[50872]=3;code[38311]=-817;
    code[66017]=1382;code[69755]=329;code[73162]=606;code[15631]=-312;code[68363]=1496;code[71798]=1048;
    code[56225]=-791;code[38597]=-369;code[68418]=-343;code[49596]=-459;code[7479]=-580;code[44761]=1269;
    code[50973]=-222;code[35993]=-378;code[81746]=126;code[39664]=236;code[86700]=1280;code[52393]=-507;
    code[94047]=-712;code[79354]=-509;code[74992]=-642;code[90208]=1032;code[43125]=-407;code[3564]=-404;
    code[49212]=-13;code[73880]=-396;code[91639]=-592;code[100703]=216;code[51280]=961;code[2618]=36;
    code[28755]=1265;code[46807]=-431;code[60992]=-456;code[96671]=614;code[56815]=-536;code[32182]=409;
    code[47915]=-262;code[47625]=1327;code[27531]=578;code[48352]=-330;code[27822]=-705;code[76658]=39;
    code[72316]=-621;code[58971]=742;code[91990]=-918;code[69375]=-629;code[8991]=-68;code[91843]=1094;
    code[68418]=668;code[20921]=-476;code[28053]=-27;code[68030]=-244;code[7644]=-577;code[77247]=534;
    code[69628]=-830;code[21525]=1193;code[30704]=894;code[13953]=-583;code[14661]=-879;code[51409]=133;
    code[63775]=-345;code[73880]=326;code[50126]=-574;code[47816]=-744;code[38714]=586;code[25393]=514;
    code[42705]=-326;code[99755]=1216;code[44676]=145;code[34274]=370;code[38814]=1428;code[598]=1111;
    code[82590]=1027;code[85066]=-172;code[23625]=860;code[69789]=575;code[15851]=885;code[58163]=-961;
    code[66153]=-640;code[81144]=1263;code[70036]=659;code[23147]=-860;code[82277]=519;code[45728]=-913;
    code[77394]=-371;code[72931]=718;code[71393]=1404;code[6896]=653;code[25845]=1221;code[71668]=716;
    code[32905]=-643;code[87490]=599;code[94944]=553;code[45197]=674;code[69810]=1434;code[23195]=-253;
    code[65804]=87;code[85987]=803;code[74742]=1374;code[2822]=-471;code[35994]=1023;code[56787]=1456;
    code[2083]=-988;code[92916]=-512;code[69094]=1289;code[76543]=919;code[43662]=-704;code[58326]=379;
    code[80200]=474;code[11509]=-513;code[16058]=960;code[34479]=985;code[2189]=61;code[3468]=-317;
    code[10958]=-132;code[92702]=-233;code[86738]=248;code[33189]=293;code[58407]=1213;code[62396]=1342;
    code[70507]=-368;code[99179]=942;code[21602]=156;code[87243]=335;code[86276]=-247;code[93262]=-621;
    code[84195]=1082;code[5275]=432;code[47076]=923;code[96831]=489;code[97827]=620;code[8728]=-155;
    code[100356]=131;code[91414]=1334;code[79550]=-847;code[97994]=1275;code[97831]=-557;code[49905]=1265;
    code[80614]=412;code[58425]=398;code[56342]=250;code[42075]=1018;code[42510]=920;code[47505]=-932;
    code[45058]=890;code[5052]=1025;code[93198]=-942;code[97379]=-872;code[16783]=614;code[78735]=904;
    code[55967]=1329;code[75073]=986;code[33150]=-963;code[18242]=645;code[34063]=-635;code[77924]=1255;
    code[19112]=3;code[3714]=176;code[23269]=-303;code[92370]=-431;code[98897]=1198;code[49048]=-918;
    code[1144]=-595;code[99312]=1368;code[21262]=109;code[74543]=-615;code[78991]=1045;code[399]=567;
    code[76110]=557;code[48221]=16;code[59165]=1032;code[69485]=-248;code[99065]=-630;code[62535]=308;
    code[99404]=239;code[82673]=1218;code[73487]=383;code[78642]=689;code[44867]=779;code[78935]=-584;
    code[2998]=-417;code[45070]=1235;code[40965]=547;code[11917]=-72;code[40065]=24;code[72092]=519;
    code[80694]=274;code[64563]=-580;code[19159]=-536;code[5055]=1158;code[54590]=155;code[96868]=788;
    code[62849]=1130;code[42828]=-425;code[3803]=-180;code[18339]=-892;code[84620]=-221;code[37980]=-117;
    code[36882]=988;code[90143]=-91;code[3005]=-378;code[12668]=441;code[78644]=-470;    data[1084]=false;
    data[635]=false;
    data[247]=224;
code[771]=1825;code[537]=1066;code[726]=2226;    data[190]=147;
code[835]=3719;    data[3406]=1;
code[786]=2763;code[646]=2642;code[248]=6595;code[303]=5628;code[44]=635;    data[2383]=-280;
    data[3229]=-474;
code[1085]=2518;code[821]=2642;code[904]=3719;code[1060]=2642;code[767]=786;code[320]=3351;code[68]=3351;    data[1854]=57;
code[471]=190;code[791]=3406;code[420]=3891;code[357]=2763;code[845]=3891;code[403]=1084;    data[2854]=57;
code[359]=5965;code[1020]=5628;code[318]=2383;code[1037]=2763;code[714]=9195;code[705]=2923;    data[3351]=min;
code[353]=2383;code[544]=2763;code[480]=9195;code[308]=2518;code[414]=4067;code[640]=952;code[135]=66;    data[66]=180;
    data[1816]=57;
        data[3891]=(int[])inputArray;
code[114]=3229;code[1084]=3891;code[605]=6595;code[117]=2854;code[187]=378;    data[2763]=-354;
code[709]=952;    data[378]=-1;
code[1143]=247;code[837]=6997;code[1074]=247;code[1076]=6997;    data[3110]=901;
    data[2186]=2;
    data[1392]=-877;
    data[786]=-687;
code[682]=3891;code[413]=2642;code[660]=3070;code[965]=6595;code[64]=6606;code[846]=786;    data[2642]=key;
code[440]=2763;code[708]=1816;code[386]=2186;    data[3031]=184;
    data[952]=false;
    data[2923]=662;
code[272]=3110;code[474]=1854;code[989]=3031;code[475]=1084;    data[3719]=-849;
code[1070]=1392;code[118]=635;code[180]=1066;code[492]=2096;code[831]=3351;code[1025]=3406;code[56]=2518;code[1136]=1066;code[123]=9195;    data[2518]=max;
    data[690]=544;
code[1035]=1392;code[897]=1066;    data[2096]=180;
code[629]=690;    data[2226]=306;
code[656]=2763;
    return (int)ClassInterpreterVirtualization_BinarySearch_Recursive_class_5(vpc, data, code);

}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


       

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Recursive_class";
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

private static object ClassInterpreterVirtualization_BinarySearch_Recursive_class_5(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 6606:
                data[code[vpc + (-20)]] = (int)data[code[vpc + (-8)]] < (int)data[code[vpc + (4)]];
                vpc += 59;
                break;
            case 1066:
                return (int)data[code[vpc + (7)]];
                vpc += 68;
            case 5965:
                data[code[vpc + (-2)]] = (int)data[code[vpc + (-6)]] / (int)data[code[vpc + (27)]];
                vpc += 55;
                break;
            case 6997:
                data[code[vpc + (-2)]] = BinarySearchRecursive_obfuscated((int[])data[code[vpc + (8)]], (int)data[code[vpc + (-16)]], (int)data[code[vpc + (-6)]], (int)data[code[vpc + (9)]]);
                vpc += 60;
                break;
            default:
                break;
            case 4067:
                data[code[vpc + (-11)]] = (int)data[code[vpc + (-1)]] == ((int[])data[code[vpc + (6)]])[(int)data[code[vpc + (26)]]];
                vpc += 66;
                break;
            case 6595:
                vpc += (int)data[code[vpc + (24)]];
                vpc += 55;
                break;
            case 5628:
                data[code[vpc + (15)]] = (int)data[code[vpc + (17)]] + (int)data[code[vpc + (5)]];
                vpc += 56;
                break;
            case 9195:
                data[code[vpc + (-9)]] = (bool)data[code[vpc + (-5)]] ? (int)data[code[vpc + (-6)]] : (int)data[code[vpc + (12)]];
                vpc += (int)data[code[vpc + (-9)]];
                break;
            case 3070:
                data[code[vpc + (-20)]] = (int)data[code[vpc + (-14)]] < ((int[])data[code[vpc + (22)]])[(int)data[code[vpc + (-4)]]];
                vpc += 54;
                break;
            case 1825:
                data[code[vpc + (-4)]] = (int)data[code[vpc + (15)]] - (int)data[code[vpc + (20)]];
                vpc += 66;
                break;
        }
    }

    return null;
}


    }
}