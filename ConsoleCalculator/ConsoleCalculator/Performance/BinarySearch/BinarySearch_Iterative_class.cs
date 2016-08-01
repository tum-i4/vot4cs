using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Iterative_class
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
            BinarySearch_Iterative_class bs = new BinarySearch_Iterative_class();
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
                string t_original = Time_Operation(i+ " BinarySearch_Iterative_class", BinarySearchIterative_obfuscated);

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

//         [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]
private static int BinarySearchIterative_obfuscated(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    int[] code = new int[100279];
    object[] data = new object[4278];
    int vpc = 62;

    code[12417]=705;code[22400]=-251;code[13606]=260;code[1151]=-851;code[29108]=895;code[76376]=1483;
    code[61196]=1491;code[43010]=861;code[13985]=543;code[62136]=-662;code[13988]=-340;code[96878]=-830;
    code[18362]=-323;code[22025]=1446;code[54421]=238;code[59488]=-618;code[88761]=486;code[52629]=1387;
    code[19009]=-789;code[4558]=-931;code[50090]=313;code[64892]=-591;code[99857]=42;code[59753]=571;
    code[80573]=379;code[6480]=1066;code[86950]=356;code[78105]=1148;code[71799]=-612;code[11713]=1161;
    code[28532]=-918;code[51834]=987;code[16539]=521;code[10854]=-962;code[47293]=184;code[55657]=-863;
    code[57358]=479;code[63749]=535;code[61897]=1005;code[7248]=914;code[67718]=477;code[17547]=1477;
    code[43184]=916;code[28685]=-144;code[81805]=663;code[23964]=-915;code[97038]=-548;code[74551]=166;
    code[833]=1130;code[100163]=-32;code[30980]=450;code[15741]=-177;code[99937]=-976;code[25542]=-312;
    code[90945]=-589;code[24287]=1284;code[8322]=-123;code[18972]=733;code[86038]=314;code[36538]=-4;
    code[32331]=914;code[20035]=1015;code[23560]=301;code[8750]=-23;code[85057]=-577;code[60764]=912;
    code[80567]=712;code[45823]=-763;code[43526]=1113;code[99723]=52;code[51323]=-974;code[43677]=627;
    code[42435]=-187;code[95392]=542;code[99451]=-876;code[61022]=206;code[48909]=501;code[6508]=357;
    code[38155]=-124;code[9487]=189;code[92496]=1159;code[42840]=844;code[56020]=192;code[11056]=-5;
    code[89641]=-765;code[26015]=-969;code[53285]=1358;code[88906]=-221;code[33110]=371;code[38414]=1274;
    code[57105]=176;code[40039]=995;code[56222]=-692;code[27817]=-493;code[62178]=1284;code[71650]=-792;
    code[75289]=296;code[49996]=620;code[58503]=744;code[9277]=1365;code[21562]=383;code[72488]=1243;
    code[79272]=489;code[95373]=360;code[71584]=882;code[21360]=1079;code[97033]=-538;code[90889]=129;
    code[46567]=572;code[17755]=87;code[20020]=1268;code[78014]=1450;code[38071]=-560;code[26249]=-969;
    code[44604]=-404;code[73040]=580;code[45736]=92;code[69658]=-960;code[74965]=254;code[775]=1411;
    code[17287]=832;code[49049]=1167;code[70270]=1206;code[11600]=414;code[61394]=-884;code[18426]=1386;
    code[52222]=643;code[74854]=-231;code[77742]=856;code[51935]=536;code[33512]=1345;code[9981]=188;
    code[2479]=451;code[37681]=326;code[49164]=1225;code[70632]=1406;code[62295]=-470;code[26349]=166;
    code[41929]=1277;code[28017]=242;code[6057]=739;code[40163]=-5;code[5485]=934;code[11188]=996;
    code[69241]=-33;code[24162]=-988;code[98652]=-17;code[63227]=-415;code[63527]=-966;code[84455]=-700;
    code[50828]=462;code[7579]=805;code[34322]=-448;code[33414]=-229;code[39569]=-301;code[89209]=1160;
    code[46461]=-948;code[55556]=595;code[53930]=753;code[42186]=-374;code[47038]=442;code[84253]=-742;
    code[65101]=748;code[98159]=-431;code[58344]=-929;code[83539]=10;code[6901]=-602;code[99289]=188;
    code[62203]=696;code[5605]=1084;code[44193]=1007;code[40527]=26;code[49865]=-59;code[54303]=1407;
    code[84161]=1480;code[69819]=1330;code[59468]=478;code[65283]=1324;code[74686]=1430;code[7307]=606;
    code[24287]=-737;code[72861]=-86;code[44803]=213;code[79762]=-240;code[3085]=-804;code[1803]=1148;
    code[64727]=467;code[81233]=664;code[17336]=73;code[60780]=-319;code[15842]=-961;code[38971]=474;
    code[33336]=1252;code[81361]=193;code[50968]=-850;code[73264]=620;code[60725]=32;code[59305]=-162;
    code[7677]=-905;code[96650]=-970;code[58292]=-407;code[93471]=901;code[97695]=1092;code[28746]=-986;
    code[78351]=1462;code[75905]=-212;code[36709]=1000;code[48612]=-435;code[71866]=-658;code[3355]=364;
    code[67573]=-205;code[79797]=1426;code[34897]=-76;code[25449]=-420;code[99843]=186;code[59100]=-664;
    code[46704]=485;code[69310]=1301;code[8410]=569;code[61707]=238;code[61598]=1013;code[69799]=307;
    code[30418]=38;code[28282]=1012;code[93093]=-87;code[62046]=1348;code[480]=44;code[33912]=-342;
    code[44296]=1404;code[41381]=510;code[58472]=-865;code[1031]=-234;code[39683]=555;code[85182]=930;
    code[10950]=410;code[14273]=-779;code[52307]=344;code[93416]=1171;code[62367]=-319;code[66897]=1331;
    code[8806]=121;code[30483]=576;code[85831]=624;code[13020]=-881;code[25660]=69;code[48008]=-695;
    code[21590]=-973;code[91497]=399;code[79732]=-27;code[12780]=702;code[56750]=275;code[69792]=-90;
    code[22347]=325;code[41910]=167;code[48775]=174;code[64313]=-578;code[29534]=200;code[51800]=-664;
    code[75240]=-51;code[45198]=864;code[49383]=1004;code[51755]=703;code[8577]=-950;code[87582]=276;
    code[62721]=-71;code[7354]=-419;code[14553]=1465;code[36770]=444;code[75469]=1349;code[40873]=-186;
    code[23249]=657;code[56293]=965;code[78872]=-227;code[82999]=838;code[49578]=944;code[81188]=38;
    code[94127]=-47;code[18908]=910;code[99667]=-964;code[27929]=-494;code[65847]=1268;code[84373]=-714;
    code[39748]=21;code[2408]=-229;code[11368]=1346;code[38295]=1025;code[97492]=-688;code[51551]=1073;
    code[24097]=824;code[89726]=939;code[19296]=-655;code[1628]=1118;code[56354]=645;code[29469]=909;
    code[79974]=506;code[58549]=844;code[66325]=-488;code[67110]=-189;code[82386]=116;code[39087]=-56;
    code[28636]=298;code[62361]=389;code[39714]=1498;code[44429]=1034;code[86984]=-103;code[52539]=-341;
    code[12022]=256;code[1033]=296;code[89352]=1484;code[55434]=845;code[11523]=-349;code[51232]=277;
    code[35589]=609;code[14938]=918;code[45685]=-527;code[792]=984;code[34110]=292;code[49173]=682;
    code[51769]=151;code[45274]=406;code[21558]=200;code[89867]=96;code[7871]=-201;code[61975]=-603;
    code[19510]=-624;code[43471]=1069;code[89625]=628;code[26354]=-938;code[837]=-723;code[20128]=880;
    code[85264]=689;code[35924]=694;code[35214]=825;code[92637]=507;code[1224]=-158;code[225]=76;
    code[54388]=1475;code[52480]=587;code[36522]=-819;code[43363]=-913;code[2599]=1475;code[57437]=-238;
    code[75810]=-550;code[90245]=721;code[25493]=162;code[66666]=13;code[26060]=748;code[71443]=348;
    code[12213]=-455;code[8753]=-130;code[39720]=-963;code[14704]=1143;code[14891]=-993;code[28613]=1259;
    code[12846]=569;code[66279]=1339;code[68040]=-586;code[72817]=1150;code[10321]=-867;code[92447]=-573;
    code[83257]=-413;code[34959]=367;code[67418]=492;code[17102]=1107;code[27840]=1460;code[51450]=-636;
    code[98789]=-790;code[64068]=-974;code[84583]=788;code[15677]=882;code[89732]=1490;code[56215]=565;
    code[80647]=822;code[72881]=-765;code[97594]=1130;code[43755]=-830;code[29718]=1290;code[51945]=-598;
    code[66840]=499;code[18563]=378;code[83483]=105;code[62780]=-640;code[11518]=287;code[95340]=485;
    code[52827]=788;code[1670]=-32;code[89955]=-578;code[27690]=1085;code[67637]=805;code[74484]=1358;
    code[87256]=-810;code[87215]=63;code[54926]=111;code[85193]=-828;code[56770]=194;code[34514]=-391;
    code[53169]=511;code[92297]=131;code[37122]=41;code[51283]=-277;code[78030]=-669;code[56893]=-356;
    code[83795]=-879;code[17179]=-682;code[64194]=710;code[48785]=1360;code[85922]=-396;code[68330]=890;
    code[57422]=-499;code[59795]=675;code[66729]=1204;code[2831]=-878;code[37226]=931;code[85974]=-270;
    code[24925]=1059;code[46510]=-356;code[21152]=133;code[16572]=844;code[51044]=529;code[59133]=247;
    code[27412]=805;code[42987]=1205;code[99415]=-1;code[38809]=-279;code[92593]=-590;code[88228]=-577;
    code[82254]=1103;code[62550]=1240;code[10447]=296;code[88905]=-843;code[19193]=1197;code[88126]=1041;
    code[22080]=-429;code[73530]=8;code[7666]=1359;code[24778]=1401;code[61272]=-757;code[39790]=1358;
    code[45449]=-635;code[5767]=1428;code[38684]=422;code[36994]=-790;code[94645]=-265;code[43888]=-76;
    code[83209]=-328;code[63529]=1476;code[72733]=317;code[30844]=-15;code[84570]=530;code[66377]=907;
    code[66856]=1459;code[21264]=1449;code[91973]=1297;code[55999]=807;code[44567]=701;code[44423]=1395;
    code[46221]=1288;code[67895]=556;code[51153]=986;code[87508]=1314;code[79308]=-92;code[57508]=1018;
    code[31101]=-359;code[23604]=-790;code[79191]=-994;code[10017]=1102;code[48551]=-264;code[30537]=5;
    code[35778]=-27;code[16755]=-939;code[73793]=786;code[92782]=-627;code[82832]=688;code[53112]=1024;
    code[85214]=712;code[88667]=-878;code[74158]=840;code[97464]=-243;code[41138]=11;code[67138]=651;
    code[68562]=185;code[93583]=104;code[58223]=504;code[47523]=-585;code[61251]=-313;code[26649]=-698;
    code[62920]=1119;code[19048]=-810;code[43954]=60;code[98413]=586;code[72889]=63;code[23504]=-739;
    code[11858]=-873;code[10180]=870;code[32363]=-997;code[99454]=1380;code[72172]=266;code[34193]=-346;
    code[78365]=208;code[57024]=-440;code[20209]=-92;code[791]=8429;code[864]=459;code[266]=515;code[910]=1518;code[327]=2370;code[122]=635;    data[607]=331;
code[391]=8146;code[52]=1518;code[717]=2421;code[256]=3930;    data[3226]=629;
code[452]=459;code[306]=459;code[1028]=3937;    data[131]=key;
    data[1317]=920;
code[320]=3001;code[589]=8549;code[462]=6815;code[530]=607;    data[2242]=false;
    data[3937]=-1;
code[845]=1518;code[200]=1518;code[570]=1170;code[189]=5083;    data[635]=-478;
code[406]=2095;    data[830]=max;
    data[1651]=71;
code[948]=2242;    data[263]=299;
code[682]=1651;code[65]=830;    data[1193]=-920;
    data[630]=71;
code[349]=2036;    data[515]=2;
code[134]=2242;code[62]=8983;code[976]=8429;code[920]=8983;code[144]=3867;code[185]=830;    data[2095]=198;
code[181]=3226;        data[2370]=(int[])inputArray;
    data[3867]=71;
code[594]=459;code[90]=2242;code[597]=2370;    data[2128]=67;
code[744]=459;code[671]=1537;code[407]=2036;code[672]=1170;code[727]=5598;    data[1518]=min;
code[395]=263;code[1038]=6815;code[923]=830;code[339]=131;code[660]=2547;code[238]=459;code[753]=830;code[600]=131;code[849]=2421;    data[2036]=false;
    data[1170]=false;
code[133]=1317;code[118]=8146;code[656]=8146;code[794]=2128;code[280]=3226;    data[1537]=197;
    data[459]=795;
    data[2547]=-249;
code[417]=630;    data[2421]=1;
code[527]=8429;code[979]=1193;code[853]=5083;
    return (int)ClassInterpreterVirtualization_BinarySearch_Iterative_class_2477(vpc, data, code);

}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


       
        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Iterative_class";
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

private static object ClassInterpreterVirtualization_BinarySearch_Iterative_class_2477(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 5083:
                data[code[vpc + (-8)]] = (int)data[code[vpc + (11)]] + (int)data[code[vpc + (-4)]];
                vpc += 67;
                break;
            case 5598:
                data[code[vpc + (26)]] = (int)data[code[vpc + (17)]] - (int)data[code[vpc + (-10)]];
                vpc += 64;
                break;
            case 8429:
                vpc += (int)data[code[vpc + (3)]];
                vpc += 62;
                break;
            case 8549:
                data[code[vpc + (-19)]] = (int)data[code[vpc + (11)]] < ((int[])data[code[vpc + (8)]])[(int)data[code[vpc + (5)]]];
                vpc += 67;
                break;
            default:
                break;
            case 6815:
                return (int)data[code[vpc + (-10)]];
                vpc += 65;
            case 3930:
                data[code[vpc + (-18)]] = (int)data[code[vpc + (24)]] / (int)data[code[vpc + (10)]];
                vpc += 64;
                break;
            case 3001:
                data[code[vpc + (29)]] = (int)data[code[vpc + (19)]] == ((int[])data[code[vpc + (7)]])[(int)data[code[vpc + (-14)]]];
                vpc += 71;
                break;
            case 8146:
                data[code[vpc + (4)]] = (bool)data[code[vpc + (16)]] ? (int)data[code[vpc + (26)]] : (int)data[code[vpc + (15)]];
                vpc += (int)data[code[vpc + (4)]];
                break;
            case 8983:
                data[code[vpc + (28)]] = (int)data[code[vpc + (-10)]] <= (int)data[code[vpc + (3)]];
                vpc += 56;
                break;
        }
    }

    return null;
}


    }
}