using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Iterative_method
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
            BinarySearch_Iterative_method bs = new BinarySearch_Iterative_method();
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
            result += "     t_method";
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
                string t_original = Time_Operation(i+ " BinarySearch_Iterative_method", BinarySearchIterative_obfuscated);

                result += " " + t_original;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);

            PrintTimes();
        }


//                [Obfuscation(Exclude = false, Feature = "virtualization; method")]
private static int BinarySearchIterative_obfuscated(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    int[] code = new int[100645];
    object[] data = new object[4748];
    int vpc = 68;

    code[55109]=1023;code[63128]=1075;code[94021]=-381;code[59926]=867;code[42606]=351;code[77602]=1418;
    code[2052]=-534;code[35759]=1401;code[53972]=164;code[38648]=1358;code[45476]=323;code[97882]=889;
    code[91409]=-417;code[19621]=601;code[65708]=535;code[87677]=1409;code[6159]=-926;code[59927]=-528;
    code[3444]=-654;code[97949]=286;code[47234]=-845;code[93302]=-991;code[97130]=-416;code[17569]=962;
    code[65137]=148;code[65206]=838;code[94160]=844;code[2416]=-955;code[84216]=1178;code[92776]=752;
    code[5306]=1387;code[9457]=1022;code[67381]=1018;code[91187]=1476;code[59490]=-585;code[93218]=-7;
    code[49579]=1173;code[47702]=-26;code[60612]=1422;code[79584]=686;code[5908]=24;code[99973]=-517;
    code[97261]=-661;code[2832]=-192;code[568]=442;code[35453]=-593;code[21830]=-320;code[46493]=286;
    code[97441]=-706;code[33635]=-606;code[32979]=-541;code[19512]=202;code[53666]=-375;code[24416]=-835;
    code[26549]=585;code[41869]=1169;code[8116]=-382;code[64635]=606;code[96773]=1251;code[84809]=333;
    code[78421]=456;code[99142]=-966;code[81923]=908;code[18178]=-450;code[40999]=1398;code[42423]=210;
    code[63874]=582;code[34907]=1187;code[21749]=280;code[66445]=790;code[89907]=1404;code[6002]=-72;
    code[16219]=210;code[8270]=1424;code[63414]=1048;code[55646]=-831;code[27709]=1001;code[38099]=862;
    code[20002]=-551;code[67125]=924;code[7018]=-945;code[66312]=-240;code[21415]=1329;code[23475]=119;
    code[90625]=918;code[42939]=122;code[24188]=-684;code[64436]=1043;code[52633]=534;code[85826]=-176;
    code[68561]=-473;code[59403]=470;code[40924]=-116;code[21027]=1085;code[25608]=504;code[68047]=-910;
    code[85087]=1225;code[65044]=1177;code[30496]=888;code[15957]=-427;code[25271]=586;code[6959]=1156;
    code[39508]=-741;code[83262]=-629;code[16142]=403;code[22354]=462;code[32927]=-157;code[8917]=1146;
    code[43483]=-824;code[90342]=1147;code[72749]=-2;code[19443]=-254;code[9180]=-24;code[60761]=-126;
    code[48344]=923;code[51760]=919;code[45812]=558;code[7903]=-884;code[14278]=818;code[19686]=-243;
    code[52997]=-850;code[67797]=732;code[38209]=-773;code[71354]=270;code[80694]=968;code[44181]=-420;
    code[86324]=-251;code[50980]=1129;code[44418]=926;code[77648]=-995;code[50323]=193;code[67262]=-23;
    code[4726]=136;code[13064]=759;code[26046]=-896;code[72147]=761;code[88075]=486;code[33445]=656;
    code[73026]=249;code[92495]=-1000;code[68590]=-761;code[55171]=731;code[33233]=-296;code[91573]=-612;
    code[11760]=-434;code[60924]=-72;code[96212]=-517;code[80803]=-877;code[39444]=-294;code[65040]=1312;
    code[96750]=-987;code[25090]=899;code[7116]=836;code[35947]=-343;code[97355]=1109;code[12709]=1353;
    code[85689]=928;code[32261]=10;code[93514]=1438;code[6136]=912;code[54813]=1435;code[59071]=-920;
    code[43936]=-137;code[75340]=703;code[79699]=-293;code[27242]=107;code[85924]=1484;code[3903]=690;
    code[85178]=970;code[62609]=489;code[93077]=617;code[18943]=-318;code[10101]=659;code[52335]=-539;
    code[87860]=-4;code[12086]=40;code[22289]=1203;code[38296]=1467;code[42096]=-458;code[32539]=813;
    code[99219]=688;code[47410]=710;code[57695]=707;code[8816]=1143;code[73734]=610;code[56164]=-648;
    code[35572]=162;code[84555]=1244;code[79109]=-215;code[93777]=931;code[83075]=410;code[81381]=-17;
    code[16402]=1135;code[22309]=1431;code[61733]=-871;code[25969]=572;code[46798]=1242;code[61385]=-377;
    code[17697]=259;code[70414]=43;code[58010]=656;code[45483]=-429;code[84584]=1448;code[6334]=890;
    code[4139]=206;code[20232]=-740;code[28722]=376;code[90562]=54;code[87257]=-806;code[52463]=797;
    code[46444]=-713;code[24570]=702;code[38869]=1322;code[68020]=141;code[86077]=477;code[72652]=-295;
    code[61834]=286;code[19742]=-593;code[11283]=449;code[55653]=-541;code[79644]=163;code[93734]=-674;
    code[85617]=-616;code[34600]=1285;code[100340]=-530;code[38469]=-755;code[98902]=1451;code[96191]=153;
    code[42104]=927;code[84794]=1278;code[30534]=515;code[90681]=125;code[76582]=1297;code[49301]=927;
    code[35688]=842;code[31170]=-283;code[52807]=-157;code[93359]=1490;code[18496]=-717;code[83554]=-419;
    code[58884]=904;code[46260]=667;code[21002]=559;code[30128]=584;code[56237]=837;code[74939]=-148;
    code[74209]=603;code[88602]=-538;code[56802]=202;code[37204]=1329;code[66820]=432;code[56323]=-350;
    code[88406]=-763;code[57718]=612;code[5339]=1399;code[27927]=-238;code[94688]=525;code[32858]=354;
    code[14760]=-416;code[24308]=-657;code[62360]=1140;code[21342]=549;code[99866]=1421;code[55331]=1208;
    code[46012]=856;code[43447]=756;code[74867]=1246;code[57215]=-970;code[20328]=-502;code[79382]=-717;
    code[5052]=635;code[58440]=497;code[46034]=99;code[40284]=-682;code[31695]=-154;code[3863]=-174;
    code[24114]=-419;code[31411]=1019;code[36320]=1349;code[26955]=1274;code[54886]=725;code[18918]=-224;
    code[53139]=437;code[56453]=-895;code[4187]=-215;code[34196]=1367;code[44797]=-681;code[8759]=1413;
    code[27725]=532;code[16335]=381;code[57201]=56;code[57201]=-704;code[70872]=-748;code[46603]=278;
    code[59014]=901;code[65543]=-345;code[93771]=1197;code[57187]=-101;code[46921]=-325;code[7156]=1206;
    code[88454]=-106;code[8618]=-999;code[100524]=-772;code[89112]=-721;code[14634]=-134;code[53573]=869;
    code[78262]=788;code[34363]=-693;code[12264]=-827;code[61019]=67;code[11250]=-877;code[45891]=-298;
    code[66737]=-806;code[1550]=415;code[56336]=817;code[50242]=-987;code[54535]=-301;code[67793]=-474;
    code[33905]=419;code[12055]=532;code[21712]=-122;code[36839]=-401;code[22986]=1258;code[48756]=-460;
    code[54097]=113;code[23966]=-8;code[66816]=610;code[77574]=1073;code[90775]=1011;code[33965]=1302;
    code[7635]=-202;code[55542]=45;code[85292]=317;code[20738]=244;code[4203]=-673;code[79100]=385;
    code[95570]=1483;code[21245]=900;code[68783]=-460;code[5285]=899;code[59708]=997;code[2882]=-715;
    code[49205]=-745;code[34359]=1243;code[51223]=1110;code[31047]=330;code[23177]=-504;code[54051]=1241;
    code[80470]=1369;code[39474]=753;code[70175]=1466;code[17572]=16;code[66369]=710;code[45012]=676;
    code[43597]=-974;code[14690]=714;code[75705]=444;code[32994]=-308;code[29249]=93;code[93545]=862;
    code[18680]=-229;code[99528]=-507;code[82781]=-366;code[32588]=877;code[45924]=-214;code[96698]=839;
    code[82937]=-123;code[6291]=516;code[62846]=555;code[45785]=1012;code[65935]=677;code[46739]=246;
    code[70271]=557;code[78497]=631;code[87646]=-350;code[60975]=-95;code[1832]=617;code[51908]=-29;
    code[100408]=1442;code[58774]=14;code[36256]=740;code[21559]=-704;code[4994]=25;code[86713]=2;
    code[51851]=802;code[65657]=671;code[98889]=-689;code[9053]=286;code[84950]=225;code[50257]=-501;
    code[47687]=678;code[88571]=-510;code[71333]=496;code[72218]=-558;code[84075]=684;code[61296]=618;
    code[3839]=-877;code[44747]=1396;code[45960]=-136;code[45180]=-280;code[76614]=-53;code[13828]=-626;
    code[61177]=1343;code[38194]=1234;code[56075]=-998;code[54823]=268;code[48074]=-40;code[93784]=722;
    code[82154]=-955;code[41243]=127;code[69710]=711;code[56933]=1103;code[11281]=-988;code[63439]=1333;
    code[68437]=-673;code[5844]=245;code[4172]=-472;code[44126]=-763;code[53725]=825;code[59200]=928;
    code[22064]=1059;code[62376]=1085;code[12981]=-746;code[17084]=634;code[11817]=888;code[14342]=96;
    code[94207]=1495;code[59921]=-809;code[81842]=-261;code[3787]=507;code[30899]=115;code[21498]=65;
    code[94902]=-884;code[46882]=-335;code[95194]=1092;code[15622]=-786;code[43269]=595;code[23314]=1171;
    code[6529]=828;code[71707]=-975;code[84058]=1441;code[82113]=1311;code[99502]=548;code[56580]=-892;
    code[61992]=-96;code[28357]=-406;code[69715]=1463;code[46738]=932;code[61428]=-516;code[89713]=-794;
    code[64003]=1258;code[71256]=-299;code[60421]=-859;code[865]=-256;code[77131]=816;code[1179]=-796;
    code[58718]=-932;code[77264]=-174;code[63437]=-278;code[44016]=-192;code[48743]=55;code[65456]=460;
    code[55871]=1293;code[39580]=111;code[17511]=146;code[25999]=1177;code[84536]=574;code[37679]=1329;
    code[27020]=338;code[32614]=1330;code[61488]=-339;code[27883]=1223;code[35238]=-501;code[65868]=663;
    code[21900]=-666;code[14363]=-198;code[76129]=419;code[60203]=-467;code[25467]=-690;code[73005]=707;
    code[66754]=409;code[12446]=-231;code[47138]=-649;code[24343]=1383;code[65712]=1089;code[6246]=-763;
    code[97134]=263;code[71704]=-451;code[14628]=902;code[23537]=-112;code[26455]=819;code[22847]=-900;
    code[31794]=1342;code[11543]=-321;code[3202]=-598;code[68310]=-639;code[81519]=602;code[27056]=-883;
    code[14176]=1423;code[42360]=-477;code[96421]=752;code[1254]=-46;code[7225]=-881;    data[596]=522;
code[297]=1869;code[375]=2019;    data[3048]=174;
    data[3161]=653;
code[786]=1869;    data[1807]=2;
    data[78]=false;
    data[3640]=57;
code[133]=3640;code[772]=7202;code[378]=2487;code[836]=4881;code[775]=1244;code[87]=3557;code[316]=1291;    data[3996]=false;
    data[1043]=297;
code[428]=1869;code[655]=4153;        data[2571]=(int[])inputArray;
code[120]=78;code[947]=8916;    data[2487]=475;
    data[3557]=max;
code[585]=3048;code[855]=3557;code[644]=2696;code[951]=1129;code[788]=2696;code[68]=4881;code[598]=3428;    data[3874]=70;
code[730]=3235;    data[2019]=57;
code[544]=1291;    data[2882]=822;
    data[3235]=64;
    data[1492]=172;
code[237]=1807;code[893]=4853;code[307]=2571;code[185]=596;code[593]=458;    data[1291]=key;
code[485]=4853;code[301]=2995;code[112]=2882;    data[1244]=min;
code[64]=1244;code[246]=3936;code[671]=3557;code[424]=8916;code[198]=3557;    data[167]=-822;
code[367]=3428;code[354]=1492;    data[1869]=-785;
code[283]=3996;code[539]=1650;code[905]=167;code[272]=1869;code[136]=3161;code[362]=3996;    data[3628]=57;
code[606]=3628;    data[458]=false;
code[125]=3428;    data[1129]=-1;
code[556]=458;code[645]=1869;    data[2696]=1;
code[844]=78;code[718]=4853;code[76]=78;code[568]=1869;code[196]=1244;code[244]=596;code[609]=3874;code[526]=2571;code[182]=7202;code[497]=1043;code[832]=1244;
    while(true)
    {
    	switch(code[vpc])
    	{
    		case 4853:
    			vpc += (int)data[code[vpc+(12)]];
    			vpc+=54;
    			break;
    		case 3936:
    			data[code[vpc+(26)]]= (int)data[code[vpc+(-2)]]/ (int)data[code[vpc+(-9)]];
    			vpc+=55;
    			break;
    		case 4153:
    			data[code[vpc+(16)]]= (int)data[code[vpc+(-10)]]- (int)data[code[vpc+(-11)]];
    			vpc+=63;
    			break;
    		case 2995:
    			data[code[vpc+(-18)]]= (int)data[code[vpc+(15)]]== ((int[])data[code[vpc+(6)]])[(int)data[code[vpc+(-4)]]];
    			vpc+=66;
    			break;
    		default:
    			break;
    		case 1650:
    			data[code[vpc+(17)]]= (int)data[code[vpc+(5)]]< ((int[])data[code[vpc+(-13)]])[(int)data[code[vpc+(29)]]];
    			vpc+=59;
    			break;
    		case 4881:
    			data[code[vpc+(8)]]= (int)data[code[vpc+(-4)]]<= (int)data[code[vpc+(19)]];
    			vpc+=57;
    			break;
    		case 7202:
    			data[code[vpc+(3)]]= (int)data[code[vpc+(14)]]+ (int)data[code[vpc+(16)]];
    			vpc+=64;
    			break;
    		case 3428:
    			data[code[vpc+(11)]]=(bool)data[code[vpc+(-5)]]?(int)data[code[vpc+(8)]]:(int)data[code[vpc+(-13)]];
    			vpc+=(int)data[code[vpc+(11)]];
    			break;
    		case 8916:
    			return (int)data[code[vpc+(4)]];
    			vpc+=61;
    	}
    }

    return 0;
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

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Iterative_method";
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


    }
}