using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortRecursive_class
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> testData;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();


        public static void RunLoopTests()
        {
            QuickSortRecursive_class lt = new QuickSortRecursive_class();
            time_warmup.Clear();
            time_run.Clear();

            lt.Profile();
            PrintTimes();

//            lt.QuickSort_Check();
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
            //            lt.ForSimple_Check();
//            int ELEMENTS = 30;
            // Create an unsorted array of string elements
//            string[] unsorted_original = GenerateData(ELEMENTS);
//            string[] unsorted_method = (new List<string>(unsorted_original)).ToArray();
//            string[] unsorted_class = (new List<string>(unsorted_original)).ToArray();
//            string[] unsorted_method_default_junk = (new List<string>(unsorted_original)).ToArray();
//            string[] unsorted_class_default_junk = (new List<string>(unsorted_original)).ToArray();

            string result = "";

            result += "t_original";
            result += "     t_method";
            result += "     t_class";
//            result += " t_method_default";
//            result += " t_class_default";
            result += "     t_method_junk";
            result += "     t_class_junk";
            result += " " + "\n";

            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {
                Console.WriteLine(i + "##############");
                Debug.WriteLine(i + "##############");
                int[] unsorted_original = testData.ToArray();
                string t_original = Time_Operation("QuickSortRecursive_class", i, Quicksort_obfuscated, unsorted_original, WARMUP, ITERATIONS);
//                string t_method = Time_Operation(VirtualizationType.METHOD, Quicksort_method, unsorted_method, WARMUP, ITERATIONS);
//                string t_class = Time_Operation(VirtualizationType.CLASS, Quicksort_class, unsorted_class, WARMUP, ITERATIONS);
//                string t_method_default = Time_Operation(VirtualizationType.ORIGINAL, ForSimple_Array_original, for_loop, WARMUP, ITERATIONS);
//                string t_class_default = Time_Operation(VirtualizationType.ORIGINAL, ForSimple_Array_original, for_loop, WARMUP, ITERATIONS);
//                string t_method_junk = Time_Operation(VirtualizationType.METHOD_JUNK, Quicksort_method_default_junk, unsorted_method_default_junk, WARMUP, ITERATIONS);
//                string t_class_junk = Time_Operation(VirtualizationType.CLASS_JUNK, Quicksort_class_default_junk, unsorted_class_default_junk, WARMUP, ITERATIONS);

                result += " " + t_original;
//                result += " " + t_method;
//                result += " " + t_class;
//                result += " " + t_method_default;
//                result += " " + t_class_default;
//                result += " " + t_method_junk;
//                result += " " + t_class_junk;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);
        }


       




//        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


//        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]

        private void QuickSort_Check()
        {
            string testName = "Performance#QuickSortRecursive_class_Check";
            Program.Start_Check(testName);
            bool condition = true;
            

            // Create an unsorted array of string elements
            int[] unsorted_original = GenerateDataInt(15);
            int[] unsorted_obfuscated = (new List<int>(unsorted_original)).ToArray();

            // Print the unsorted array
            for (int i = 0; i < unsorted_original.Length; i++)
            {
                Console.Write(unsorted_original[i] + " ");
            }
            Console.WriteLine();

            // Sort the array
            Quicksort_original(unsorted_original, 0, unsorted_original.Length - 1);
            Quicksort_obfuscated(unsorted_obfuscated, 0, unsorted_obfuscated.Length - 1);

            // Print the sorted array
            string sortedOriginalHash = "";
            string sortedObfuscatedHash = "";
            for (int i = 0; i < unsorted_original.Length; i++)
            {
                sortedOriginalHash += unsorted_original[i] + "_";
                sortedObfuscatedHash += unsorted_obfuscated[i] + "_";
            }

            Console.WriteLine("ori: " + sortedOriginalHash);
            Console.WriteLine("obf: " + sortedObfuscatedHash);

            string virt = sortedObfuscatedHash;
            string oracle = sortedOriginalHash;
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
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

        private string[] GenerateDataString(int elements)
        {
            string[] str = new string[elements];
            Int32[] int1 = new Int32[elements];

            Random rand = new Random();
            for (int i = 0; i < elements; i++)
            {
                string element = "" + rand.Next(0, 100000);
                str[i] = element;
            }
            
            return str;
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



//        [Obfuscation(Exclude = false, Feature = "virtualization; class")]
private string Quicksort_obfuscated(int[] elements, int left, int right)
{
    //Virtualization variables
    int[] code = new int[100761];
    object[] data = new object[4429];
    int vpc = 62;

    code[72650]=1152;code[100027]=26;code[22153]=862;code[26945]=-910;code[79031]=626;code[62186]=573;
    code[71446]=1001;code[15981]=-981;code[59900]=1038;code[3193]=-56;code[42569]=-361;code[88747]=-890;
    code[22318]=1215;code[11480]=620;code[14697]=632;code[48699]=-988;code[24021]=-311;code[33223]=-651;
    code[2955]=386;code[11619]=-180;code[98932]=-500;code[99636]=-229;code[33883]=-96;code[42606]=-201;
    code[14564]=1266;code[13904]=279;code[768]=271;code[52197]=162;code[98759]=1371;code[19052]=-166;
    code[63592]=547;code[89706]=-672;code[16837]=530;code[39417]=83;code[47433]=-954;code[98603]=-901;
    code[70556]=758;code[39899]=-445;code[26901]=430;code[71339]=1149;code[46679]=985;code[50760]=-402;
    code[51890]=1428;code[100493]=824;code[76356]=1161;code[16090]=-798;code[36829]=953;code[70255]=-94;
    code[31217]=1143;code[14246]=810;code[97795]=1474;code[85557]=-686;code[93489]=-755;code[81776]=-240;
    code[11334]=-261;code[19971]=19;code[24224]=-177;code[87706]=1092;code[11620]=627;code[62106]=-511;
    code[61951]=653;code[68055]=515;code[86561]=1244;code[67948]=1296;code[610]=-917;code[91948]=23;
    code[43415]=1459;code[89589]=184;code[95212]=-55;code[31395]=42;code[16110]=732;code[62213]=155;
    code[67138]=879;code[84686]=-910;code[91805]=1150;code[24932]=647;code[24293]=1364;code[11007]=-227;
    code[31658]=-393;code[26871]=-925;code[42698]=1232;code[30051]=-802;code[38604]=971;code[98440]=-359;
    code[44358]=-9;code[89889]=843;code[34187]=-502;code[3600]=1304;code[4416]=-467;code[94703]=-732;
    code[5766]=595;code[757]=-636;code[79174]=-366;code[16968]=212;code[88134]=449;code[16066]=755;
    code[11216]=-297;code[100066]=-333;code[39780]=345;code[7960]=1194;code[78073]=460;code[60043]=285;
    code[97543]=275;code[32207]=-896;code[91695]=-532;code[26749]=-748;code[30530]=-602;code[98030]=963;
    code[89214]=-620;code[29572]=-677;code[62501]=229;code[38468]=1151;code[23915]=-525;code[63075]=-856;
    code[20795]=921;code[53099]=264;code[13531]=-845;code[33494]=183;code[4262]=232;code[17914]=-311;
    code[94105]=-683;code[57943]=718;code[31673]=-854;code[40207]=1379;code[31088]=-482;code[38443]=-394;
    code[24652]=1373;code[25926]=-293;code[20375]=838;code[27909]=945;code[89084]=-346;code[84156]=-647;
    code[66547]=899;code[97395]=-399;code[83329]=249;code[74889]=-20;code[98198]=-956;code[19705]=233;
    code[92377]=736;code[55021]=-554;code[79703]=685;code[75500]=1497;code[39018]=-289;code[26298]=-538;
    code[81108]=-877;code[27306]=-233;code[21784]=-1;code[39449]=680;code[29379]=84;code[2699]=386;
    code[9263]=-605;code[12582]=1022;code[46785]=1473;code[26988]=-433;code[75963]=909;code[36894]=269;
    code[19086]=-755;code[99448]=-475;code[51639]=1091;code[75975]=-61;code[50259]=954;code[43906]=943;
    code[23041]=91;code[17736]=436;code[63108]=308;code[20345]=207;code[67281]=1478;code[8751]=581;
    code[55340]=1351;code[53855]=-6;code[1684]=-915;code[43418]=-898;code[68847]=908;code[11828]=-705;
    code[41594]=-547;code[16086]=137;code[68494]=627;code[5615]=-225;code[72805]=-132;code[58457]=-931;
    code[81946]=732;code[60505]=-424;code[56615]=1207;code[84632]=-506;code[1141]=-115;code[66580]=430;
    code[30420]=-110;code[36189]=161;code[35354]=-14;code[9499]=163;code[32145]=-855;code[16321]=112;
    code[36653]=866;code[80932]=-958;code[94290]=941;code[91706]=-496;code[36302]=266;code[58908]=-191;
    code[43699]=-499;code[48291]=1000;code[93040]=1298;code[10749]=-854;code[52468]=469;code[15443]=-191;
    code[29395]=477;code[96656]=-181;code[25496]=-713;code[71425]=888;code[53510]=-611;code[87330]=1037;
    code[8054]=1057;code[26410]=-414;code[44750]=147;code[21335]=988;code[77731]=-912;code[3116]=-624;
    code[92228]=-265;code[54609]=-2;code[95856]=-742;code[93112]=940;code[59798]=198;code[73060]=-139;
    code[82365]=455;code[95608]=-387;code[80378]=1073;code[79861]=-305;code[33624]=660;code[72566]=-750;
    code[66238]=1180;code[61906]=-846;code[37872]=-106;code[55641]=-360;code[56444]=1022;code[41577]=1397;
    code[57719]=-227;code[81003]=69;code[23332]=-774;code[22336]=500;code[9875]=1293;code[42035]=1154;
    code[51386]=1415;code[100517]=1355;code[24476]=882;code[82295]=-372;code[57832]=104;code[74777]=-802;
    code[49277]=1155;code[40332]=-412;code[93437]=172;code[79045]=-979;code[17082]=1474;code[67774]=220;
    code[2564]=-88;code[4681]=-393;code[44580]=-701;code[228]=849;code[45832]=881;code[55605]=23;
    code[36308]=525;code[1341]=1018;code[99960]=-597;code[38785]=-673;code[57151]=811;code[94568]=-77;
    code[69553]=1465;code[67817]=572;code[13394]=21;code[69767]=300;code[29587]=273;code[92358]=1194;
    code[71179]=434;code[81490]=135;code[44277]=-995;code[62915]=841;code[31273]=1476;code[88182]=-208;
    code[45901]=1443;code[1668]=-980;code[60965]=353;code[92817]=-248;code[42967]=692;code[55705]=140;
    code[45014]=-68;code[61163]=-885;code[6049]=-921;code[11683]=1127;code[69879]=-662;code[10162]=46;
    code[35536]=1326;code[69697]=412;code[10099]=-496;code[5939]=748;code[11182]=-111;code[17490]=-611;
    code[39498]=710;code[92190]=880;code[59251]=539;code[45493]=-927;code[2091]=-119;code[746]=-835;
    code[39815]=445;code[68170]=-304;code[88137]=-940;code[62839]=-200;code[88300]=495;code[66040]=685;
    code[85623]=-110;code[20210]=-439;code[62289]=1133;code[34792]=-773;code[20105]=128;code[65927]=-61;
    code[11779]=-91;code[26508]=-806;code[68907]=-822;code[40071]=-1000;code[93038]=563;code[17117]=305;
    code[52937]=951;code[83113]=-783;code[73778]=1133;code[28150]=984;code[2910]=-399;code[90924]=-421;
    code[41838]=-433;code[41421]=-582;code[721]=1291;code[87335]=1359;code[93082]=-248;code[16284]=277;
    code[76673]=364;code[64112]=1011;code[20192]=638;code[75661]=-440;code[18768]=696;code[70441]=1094;
    code[2860]=-355;code[36137]=-135;code[17321]=1150;code[34949]=1190;code[46492]=-923;code[66752]=142;
    code[66550]=-425;code[100059]=-983;code[76440]=-435;code[60287]=-439;code[62351]=-216;code[32847]=-535;
    code[21876]=186;code[59801]=-66;code[49348]=695;code[4598]=841;code[53192]=433;code[14016]=872;
    code[56213]=301;code[77780]=-842;code[96122]=-287;code[4988]=824;code[89016]=-552;code[14538]=1425;
    code[66719]=860;code[46926]=1400;code[8072]=186;code[22062]=786;code[93944]=-570;code[12999]=743;
    code[26891]=1432;code[38940]=958;code[99304]=1314;code[93600]=-783;code[9177]=-390;code[45234]=-405;
    code[45753]=337;code[27263]=-167;code[26643]=490;code[30513]=-906;code[33283]=558;code[71691]=864;
    code[21390]=-787;code[66165]=-867;code[35705]=61;code[82264]=-37;code[39459]=-814;code[80257]=1451;
    code[90574]=-335;code[74985]=1394;code[25238]=-858;code[88580]=44;code[29739]=-431;code[50999]=363;
    code[20551]=1213;code[45344]=-160;code[87614]=-772;code[36977]=608;code[26366]=601;code[57545]=1250;
    code[27109]=1188;code[73837]=666;code[43105]=-842;code[85282]=-52;code[74400]=-276;code[43781]=1495;
    code[85851]=-138;code[79318]=-318;code[74982]=-267;code[45395]=1461;code[58364]=-722;code[85586]=172;
    code[98203]=200;code[51990]=-250;code[71303]=-618;code[72458]=-355;code[70027]=1110;code[69391]=-63;
    code[32679]=-469;code[99763]=-421;code[38422]=-684;code[81293]=1285;code[45445]=129;code[48775]=311;
    code[30644]=-766;code[90626]=1420;code[19170]=466;code[32335]=-607;code[2636]=-341;code[69704]=1368;
    code[55158]=365;code[67689]=463;code[57501]=-560;code[30562]=-980;code[66141]=30;code[95607]=328;
    code[30579]=-454;code[60782]=131;code[30697]=1338;code[1793]=307;code[100381]=1478;code[100371]=534;
    code[25542]=877;code[6837]=-729;code[52709]=327;code[35139]=-850;code[52487]=-894;code[68950]=1088;
    code[45836]=-447;code[34610]=-314;code[14951]=190;code[87460]=1229;code[14603]=-81;code[66964]=1428;
    code[99077]=1170;code[85942]=-773;code[24804]=-578;code[95846]=389;code[55415]=-856;code[33449]=1049;
    code[10935]=-513;code[48856]=-687;code[6402]=1221;code[1062]=-348;code[53855]=920;code[100521]=-792;
    code[59623]=857;code[37738]=300;code[12448]=-740;code[47248]=1213;code[8710]=-759;code[12609]=636;
    code[68329]=-356;code[82036]=-120;code[9208]=-679;code[28741]=-8;code[89612]=309;code[16737]=1383;
    code[99872]=856;code[83460]=-359;code[36014]=9;code[44028]=-462;code[87735]=924;code[50298]=257;
    code[80037]=77;code[43560]=114;code[59348]=116;code[73876]=-970;code[7025]=1075;code[45059]=1014;
    code[7489]=646;code[17076]=15;code[48645]=501;code[19542]=-831;code[58144]=52;code[53300]=-48;
    code[27808]=-469;code[53211]=706;code[66444]=1274;code[78996]=1271;code[76439]=-223;code[56195]=650;
    code[70140]=1098;code[81410]=107;code[79666]=-616;code[89051]=-598;code[29771]=-944;code[989]=963;code[423]=2531;    data[3861]=686;
    data[2714]=left;
code[1572]=3861;code[2057]=749;code[1185]=1275;code[854]=2291;code[2104]=481;code[1584]=700;    data[2999]=-1292;
    data[631]=68;
code[289]=590;    data[700]=false;
code[1706]=9978;code[62]=1700;code[1520]=2801;    data[963]=-831;
code[611]=2063;code[615]=3861;code[1812]=2722;code[2002]=3812;code[344]=700;code[1407]=2063;code[1265]=2722;code[2042]=2722;    data[59]=2;
code[160]=2714;    data[2801]=0;
code[1228]=2440;code[1269]=963;code[801]=963;code[1451]=1480;code[617]=1480;code[1486]=963;code[230]=6540;code[806]=2722;code[1413]=1480;code[1075]=3861;code[1654]=9626;code[1244]=3861;code[115]=1700;code[494]=2722;    data[177]=173;
code[2190]=369;code[1773]=1541;code[215]=59;code[1309]=2722;code[172]=1365;code[1152]=2396;code[873]=2631;code[424]=741;code[775]=2631;code[923]=963;code[1023]=1330;code[538]=381;code[797]=590;    data[2440]=994;
code[1085]=3909;code[1582]=3909;code[1963]=749;    data[1275]=false;
code[1936]=9978;    data[2557]=-813;
code[1225]=8113;code[254]=2557;code[1577]=963;code[337]=963;code[332]=3861;    data[481]=0;
code[913]=9486;code[673]=8651;code[1080]=963;    data[211]=240;
code[1167]=577;code[1087]=1275;code[409]=403;code[1763]=6316;code[1281]=6610;code[543]=6316;code[1365]=2722;code[286]=8113;code[1831]=1456;code[1157]=6316;    data[590]=-178;
code[1211]=2722;    data[865]=0;
    data[3242]=68;
code[2114]=9626;code[85]=3861;code[1166]=2053;    data[381]=243;
    data[2894]=-762;
code[1339]=6952;    data[2053]=68;
    data[3812]=68;
code[974]=7098;code[2089]=3861;    data[2631]=false;
    data[403]=1292;
code[1033]=9626;code[1927]=3861;    data[1541]=-742;
code[83]=2714;code[855]=2354;code[499]=2089;code[305]=2557;code[174]=749;code[2021]=785;code[734]=9626;code[442]=700;code[1884]=9626;    data[741]=78;
code[1479]=963;    data[369]="";
code[1772]=3242;    data[2396]=425;
code[895]=1480;code[930]=963;code[1361]=963;code[1411]=3861;code[1733]=963;code[168]=2063;code[845]=6316;code[1326]=2440;code[553]=2894;    data[749]=right;
code[696]=3861;    data[1365]=729;
code[1916]=785;code[1993]=6316;code[690]=2089;    data[1583]=false;
code[1644]=2999;code[840]=211;code[505]=3861;code[1530]=9626;code[571]=2089;    data[1330]=-240;
    data[2531]=68;
code[464]=590;    data[785]=false;
code[994]=2722;code[1697]=2714;code[603]=3861;code[1827]=963;code[1469]=9486;    data[2354]=890;
code[482]=8651;code[985]=590;code[1399]=3861;code[2166]=3946;code[136]=749;    data[3834]=-739;
    data[577]=-719;
code[342]=3909;    data[1480]=1;
code[1859]=2714;code[1988]=3964;code[138]=963;code[1758]=177;code[2061]=1456;code[963]=2631;code[655]=590;code[272]=2722;    data[3887]=-243;
code[552]=631;        data[2722]=(int[])elements;
code[2003]=3834;code[1686]=1583;code[1271]=3861;code[1874]=865;code[724]=3887;code[786]=7098;code[1791]=1583;code[221]=1365;    data[2089]=false;
code[685]=2722;    data[3964]=173;
    data[2291]=68;
code[414]=6316;
    return (string)InstanceInterpreterVirtualization_QuickSortRecursive_class_1560(vpc, data, code);

}

        public static string Time_Operation(string id, int runId, Func<int[], int, int, string> method, int[] elements, int warmup, int iterations)
        {

            int op = 0;
            string log = runId + " warming ... " + warmup + " times X elements " + elements.Length;
            Output(log);

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < warmup && runId < 1; i++)
            {
                int[] unsorted_original = testData.ToArray();
                method(unsorted_original, 0, unsorted_original.Length - 1);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("   {0}    , sec", timespan.TotalSeconds);
            log = id + " " + runId + " warmed up in,     " + time;
            Output(log);
            time_warmup.Add(log);

            log = runId + " running ... " + iterations + " times X elements " + elements.Length;
            Output(log);
            timer = Stopwatch.StartNew();
            for (int j = 0; j < iterations; j++)
            {
                int[] unsorted_original = testData.ToArray();
                method(unsorted_original, 0, unsorted_original.Length - 1);
            }
            timer.Stop();
            timespan = timer.Elapsed;

            time = String.Format("      {0}   , sec", timespan.TotalSeconds);
            log = id + " " + runId + " finished in,  " + time;
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

private object InstanceInterpreterVirtualization_QuickSortRecursive_class_1560(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 9978:
                data[code[vpc + (-20)]] = (int)data[code[vpc + (-9)]] < (int)data[code[vpc + (27)]];
                vpc += 57;
                break;
            case 6316:
                data[code[vpc + (10)]] = (bool)data[code[vpc + (28)]] ? (int)data[code[vpc + (9)]] : (int)data[code[vpc + (-5)]];
                vpc += (int)data[code[vpc + (10)]];
                break;
            case 8651:
                data[code[vpc + (17)]] = ((int[])data[code[vpc + (12)]])[(int)data[code[vpc + (23)]]] < (int)data[code[vpc + (-18)]];
                vpc += 61;
                break;
            case 1456:
                Quicksort_obfuscated((int[])data[code[vpc + (-19)]], (int)data[code[vpc + (28)]], (int)data[code[vpc + (-4)]]);
                vpc += 53;
                break;
            case 1700:
                data[code[vpc + (23)]] = (int)data[code[vpc + (21)]];
                vpc += 53;
                break;
            case 9486:
                data[code[vpc + (10)]] = (int)data[code[vpc + (17)]] - (int)data[code[vpc + (-18)]];
                vpc += 61;
                break;
            case 6540:
                data[code[vpc + (24)]] = (int)data[code[vpc + (-9)]] / (int)data[code[vpc + (-15)]];
                vpc += 56;
                break;
            case 3946:
                return (string)data[code[vpc + (24)]];
                vpc += 51;
            case 8113:
                data[code[vpc + (3)]] = ((int[])data[code[vpc + (-14)]])[(int)data[code[vpc + (19)]]];
                vpc += 56;
                break;
            case 3909:
                data[code[vpc + (2)]] = (int)data[code[vpc + (-10)]] <= (int)data[code[vpc + (-5)]];
                vpc += 72;
                break;
            case 6952:
                ((int[])data[code[vpc + (26)]])[(int)data[code[vpc + (22)]]] = (int)data[code[vpc + (-13)]];
                vpc += 68;
                break;
            case 6610:
                ((int[])data[code[vpc + (28)]])[(int)data[code[vpc + (-10)]]] = ((int[])data[code[vpc + (-16)]])[(int)data[code[vpc + (-12)]]];
                vpc += 58;
                break;
            case 2063:
                data[code[vpc + (4)]] = (int)data[code[vpc + (-8)]] + (int)data[code[vpc + (6)]];
                vpc += 62;
                break;
            default:
                break;
            case 7098:
                data[code[vpc + (-11)]] = (int)data[code[vpc + (11)]] < ((int[])data[code[vpc + (20)]])[(int)data[code[vpc + (15)]]];
                vpc += 59;
                break;
            case 9626:
                vpc += (int)data[code[vpc + (-10)]];
                vpc += 52;
                break;
        }
    }

    return null;
}


    }
}