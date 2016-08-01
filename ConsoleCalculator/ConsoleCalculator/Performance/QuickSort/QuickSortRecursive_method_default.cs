using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortRecursive_method_default
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> testData;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();


        public static void RunLoopTests()
        {
            QuickSortRecursive_method_default lt = new QuickSortRecursive_method_default();
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
                Console.WriteLine(i + " ##############");
                Debug.WriteLine("##############");
                int[] unsorted_original = testData.ToArray();
                string t_original = Time_Operation("QuickSortRecursive_method_default", i, Quicksort_obfuscated, unsorted_original, WARMUP, ITERATIONS);
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
            string testName = "Performance#QuickSortRecursive_method_default_Check";
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



//        [Obfuscation(Exclude = false, Feature = "virtualization; method; ")]
private string Quicksort_obfuscated(int[] elements, int left, int right)
{
    //Virtualization variables
    int[] code = new int[100277];
    object[] data = new object[4944];
    int vpc = 93;

    code[30157]=-987;code[64978]=449;code[52307]=1377;code[88983]=1435;code[23101]=1271;code[19933]=678;
    code[7202]=-55;code[59802]=1478;code[39335]=1359;code[34634]=898;code[52150]=799;code[42524]=506;
    code[18384]=705;code[34037]=394;code[65430]=1142;code[6855]=-599;code[4134]=-318;code[38973]=1475;
    code[51718]=1438;code[27722]=739;code[96516]=572;code[40397]=-58;code[39662]=959;code[8487]=924;
    code[24313]=1177;code[83639]=1479;code[30762]=-186;code[28624]=452;code[58280]=-887;code[39756]=1098;
    code[61314]=-177;code[32273]=-67;code[84268]=-905;code[63199]=996;code[99230]=515;code[47679]=41;
    code[66925]=624;code[79922]=1228;code[31771]=-883;code[20757]=-2;code[59920]=424;code[31639]=953;
    code[2291]=-809;code[85626]=788;code[99040]=1019;code[41030]=175;code[58070]=92;code[8450]=582;
    code[30782]=-927;code[53817]=-107;code[15399]=-286;code[78239]=591;code[39655]=43;code[32533]=642;
    code[53036]=-15;code[26492]=335;code[84076]=1492;code[24255]=-896;code[1391]=350;code[35154]=909;
    code[18471]=1287;code[81324]=-546;code[19737]=-988;code[83990]=-425;code[56696]=-591;code[58588]=-282;
    code[51173]=1123;code[24661]=-222;code[79156]=697;code[38716]=513;code[75414]=-509;code[18691]=483;
    code[54492]=1187;code[63360]=455;code[19566]=-894;code[62094]=916;code[68073]=932;code[17370]=-404;
    code[47626]=495;code[44084]=-25;code[58140]=-765;code[9195]=-88;code[81216]=1441;code[2392]=1472;
    code[75309]=1325;code[25314]=-163;code[15460]=862;code[1183]=1468;code[73056]=-457;code[64028]=-196;
    code[37434]=-362;code[3536]=307;code[54618]=1043;code[61022]=843;code[67820]=-982;code[83894]=-523;
    code[24009]=1489;code[2571]=645;code[10538]=1053;code[78569]=416;code[85348]=607;code[83341]=-338;
    code[79217]=-289;code[61420]=1334;code[76313]=-536;code[51148]=-357;code[96242]=-706;code[1702]=-190;
    code[5894]=421;code[82257]=1480;code[36925]=-285;code[31340]=859;code[9392]=-847;code[9563]=-605;
    code[72145]=-116;code[88474]=1267;code[43519]=-821;code[47199]=825;code[42550]=926;code[73499]=-350;
    code[20562]=687;code[97916]=226;code[49860]=448;code[23195]=-696;code[98152]=753;code[60088]=340;
    code[110]=977;code[19894]=411;code[33134]=-782;code[17164]=821;code[18957]=135;code[21486]=18;
    code[30435]=507;code[82569]=1219;code[64887]=-284;code[90250]=-280;code[83806]=400;code[78946]=733;
    code[31074]=1055;code[24716]=286;code[83233]=1434;code[18003]=-955;code[75662]=-136;code[90854]=607;
    code[87589]=1264;code[40100]=-158;code[60091]=-990;code[7139]=877;code[46180]=423;code[18751]=1235;
    code[75787]=-142;code[47586]=730;code[80348]=-223;code[70253]=102;code[390]=262;code[25560]=271;
    code[84324]=641;code[90106]=-462;code[27536]=-510;code[65450]=1393;code[69882]=-549;code[1444]=852;
    code[88919]=407;code[69099]=1078;code[49021]=-910;code[23354]=851;code[63677]=-120;code[76075]=216;
    code[50055]=218;code[21750]=109;code[64712]=162;code[64068]=-79;code[65281]=1228;code[49737]=1356;
    code[10604]=1139;code[47761]=-339;code[91904]=-427;code[19794]=437;code[32992]=833;code[80766]=-405;
    code[62351]=1172;code[95480]=1418;code[27281]=285;code[87580]=221;code[90053]=29;code[71812]=968;
    code[98189]=-478;code[31308]=-421;code[54317]=614;code[9040]=1488;code[6727]=866;code[72766]=582;
    code[56162]=1421;code[82642]=14;code[15521]=-542;code[15804]=914;code[68379]=1446;code[82413]=940;
    code[51424]=678;code[9672]=-659;code[1814]=-982;code[4461]=734;code[14011]=722;code[28604]=768;
    code[91972]=1413;code[3360]=707;code[64499]=1025;code[17156]=1188;code[14391]=-203;code[40855]=-241;
    code[69198]=169;code[33486]=786;code[25505]=1375;code[10562]=-999;code[38824]=340;code[72104]=1175;
    code[55093]=1383;code[97986]=-851;code[70398]=-921;code[49461]=1177;code[68508]=-709;code[48975]=-527;
    code[15036]=186;code[12291]=1179;code[80987]=1366;code[63439]=-516;code[26470]=982;code[44794]=375;
    code[67519]=-176;code[44065]=-527;code[58532]=-289;code[32118]=-48;code[24712]=-592;code[13408]=724;
    code[83531]=-722;code[17367]=-721;code[82821]=340;code[62211]=433;code[98208]=-639;code[56619]=949;
    code[83005]=-417;code[19334]=101;code[90590]=313;code[60795]=891;code[50805]=67;code[38754]=-70;
    code[59405]=-241;code[28811]=-4;code[79857]=-732;code[94544]=1466;code[34169]=81;code[3882]=740;
    code[77554]=302;code[36871]=818;code[17292]=1183;code[57250]=321;code[76737]=648;code[36261]=-125;
    code[9223]=1199;code[47904]=802;code[55849]=-58;code[18370]=15;code[72679]=1002;code[52066]=305;
    code[24976]=-446;code[77916]=1180;code[20237]=444;code[44034]=-13;code[19541]=241;code[66898]=-44;
    code[15815]=1196;code[58572]=583;code[85830]=1144;code[60856]=1332;code[94484]=1343;code[30727]=1291;
    code[63128]=-446;code[43092]=1408;code[25021]=581;code[97425]=1430;code[176]=1114;code[47982]=1376;
    code[9655]=747;code[32776]=-532;code[22104]=1416;code[15566]=488;code[21319]=-762;code[56485]=695;
    code[79523]=374;code[55173]=1167;code[19469]=465;code[58143]=-221;code[91809]=1150;code[24322]=1449;
    code[14859]=188;code[14591]=405;code[52632]=736;code[38169]=-220;code[40130]=584;code[53853]=-608;
    code[53240]=48;code[71438]=1439;code[78413]=777;code[70596]=335;code[66033]=878;code[17101]=749;
    code[8258]=-739;code[78035]=38;code[26652]=-584;code[3497]=-411;code[45753]=-133;code[3925]=862;
    code[82332]=482;code[7085]=294;code[71663]=-372;code[27882]=-602;code[1283]=-18;code[33697]=936;
    code[87637]=510;code[53135]=-489;code[15680]=770;code[32237]=-9;code[30583]=114;code[48127]=50;
    code[91909]=1413;code[4643]=-417;code[60043]=-248;code[70277]=-540;code[38145]=1418;code[15503]=-528;
    code[64200]=-535;code[82183]=18;code[47473]=-973;code[68877]=723;code[77065]=-992;code[54291]=654;
    code[63849]=1075;code[7973]=869;code[2544]=606;code[44111]=-62;code[11329]=625;code[60292]=873;
    code[20546]=-889;code[56215]=779;code[69416]=-621;code[39528]=1266;code[45080]=-148;code[56599]=1425;
    code[89119]=1285;code[92581]=-266;code[76105]=976;code[65356]=1282;code[42502]=-39;code[59847]=921;
    code[22226]=1382;code[15914]=844;code[52908]=948;code[7627]=1474;code[58654]=-825;code[20295]=72;
    code[45179]=1438;code[99975]=541;code[61108]=587;code[21264]=-261;code[26650]=-727;code[86158]=-723;
    code[72115]=-635;code[61796]=-195;code[100134]=720;code[32644]=1050;code[44888]=980;code[49133]=848;
    code[99599]=640;code[37985]=675;code[26551]=436;code[38632]=1046;code[71374]=235;code[84560]=959;
    code[79586]=-912;code[30441]=972;code[17310]=-248;code[50418]=-720;code[9393]=-882;code[1884]=-47;
    code[16356]=884;code[99402]=1241;code[74668]=-45;code[98399]=646;code[48659]=-356;code[62503]=1382;
    code[25687]=354;code[3119]=728;code[72606]=-899;code[40051]=-438;code[30361]=1081;code[53007]=1408;
    code[38577]=341;code[64938]=-634;code[29003]=-56;code[64747]=1364;code[63919]=1493;code[50846]=277;
    code[58487]=221;code[7414]=-177;code[51445]=-539;code[29928]=340;code[41302]=-124;code[53417]=576;
    code[27057]=1028;code[38933]=-868;code[64988]=984;code[7899]=-174;code[22577]=-931;code[51333]=-481;
    code[73661]=1086;code[37029]=-731;code[61363]=693;code[31659]=-353;code[3490]=300;code[10824]=-412;
    code[96936]=-826;code[71377]=-705;code[53554]=1481;code[55301]=-915;code[397]=-958;code[87929]=194;
    code[99212]=481;code[29846]=1108;code[92100]=-559;code[28664]=388;code[97939]=1164;code[59665]=696;
    code[81774]=-523;code[92664]=835;code[3477]=-316;code[59758]=874;code[70558]=-618;code[8658]=445;
    code[8236]=1401;code[79870]=-419;code[47772]=194;code[20456]=794;code[96034]=1229;code[11853]=-952;
    code[38097]=180;code[34138]=1145;code[23488]=381;code[25945]=-749;code[47611]=-917;code[30336]=-142;
    code[6867]=1042;code[100238]=825;code[42205]=-683;code[77614]=1091;code[50771]=798;code[76345]=1394;
    code[38102]=-867;code[7917]=247;code[66380]=1193;code[72274]=1309;code[7285]=1262;code[35537]=406;
    code[93591]=844;code[51692]=-623;code[89654]=1464;code[10376]=-879;code[66004]=133;code[16454]=648;
    code[47931]=184;code[29766]=1076;code[11794]=-296;code[51439]=651;code[71284]=-44;code[47966]=-548;
    code[47494]=899;code[43993]=493;code[31345]=-54;code[27129]=-591;code[46405]=92;code[79903]=708;
    code[61332]=557;code[94508]=301;code[61758]=781;code[30030]=1316;code[89164]=49;code[2114]=-530;
    code[58202]=1225;code[80846]=977;code[39291]=734;code[85391]=376;code[25998]=-164;code[67928]=-664;
    code[54841]=264;code[73822]=-302;code[18325]=-999;code[19699]=-898;code[67884]=533;code[21953]=236;
    code[34008]=1480;code[4479]=1495;code[8347]=379;    data[314]=445;
code[1015]=2821;    data[1187]=-343;
    data[3854]=760;
code[234]=1450;    data[3225]=1303;
    data[1369]=261;
code[240]=659;    data[155]=-155;
code[1021]=458;    data[2585]=-167;
code[345]=54;    data[2410]=-498;
code[811]=1412;    data[2493]=-899;
    data[1427]=-784;
    data[2811]=620;
code[2249]=4176;code[506]=3742;code[2076]=2614;code[1143]=1994;    data[98]=188;
code[232]=339;    data[1439]=-906;
    data[2421]=584;
code[1146]=282;    data[2922]=-806;
    data[2120]=-653;
code[846]=429;    data[2042]=471;
code[1240]=2098;code[1009]=1157;    data[3539]=76;
    data[898]=-973;
code[545]=1158;    data[3981]=117;
    data[2114]=832;
    data[1374]=-137;
    data[1029]=771;
    data[1727]=912;
    data[1158]=97;
code[1378]=2098;code[480]=3225;code[1448]=665;    data[2884]=-87;
code[2089]=2126;code[1638]=4684;code[636]=3723;code[950]=657;code[1875]=3957;    data[3643]=382;
code[399]=4684;code[571]=9413;code[576]=3136;    data[3103]=-815;
code[400]=3175;code[230]=233;code[814]=3028;code[981]=3525;    data[482]=882;
    data[3038]=637;
code[433]=1952;    data[2000]=false;
    data[1946]=-833;
code[1536]=2760;code[1590]=3506;code[1219]=3457;    data[2850]=-868;
code[889]=9413;code[427]=3234;    data[2829]=-248;
    data[3457]=447;
code[1261]=3960;code[1127]=1177;    data[3884]=-759;
    data[1637]=-743;
    data[751]=-253;
code[1812]=3798;    data[1483]=295;
    data[1564]=921;
    data[1635]=-198;
code[617]=1749;code[648]=727;code[139]=1087;    data[3678]=728;
    data[339]=right;
code[2002]=4297;code[1797]=570;code[1265]=300;code[1269]=928;code[1298]=3028;    data[784]=-166;
    data[1993]=false;
    data[2126]=188;
code[1335]=3936;    data[517]=-696;
    data[3309]=65;
    data[2470]=65;
code[948]=2751;code[1745]=1610;code[1885]=3028;    data[1723]=156;
code[1769]=3122;    data[915]=72;
    data[3313]=712;
code[872]=2102;code[381]=2760;code[1664]=1993;code[1579]=468;code[88]=2801;    data[3798]=false;
    data[1136]=-2;
code[1902]=2528;code[1864]=2760;    data[592]=-351;
    data[3590]=395;
code[2144]=34;    data[2566]=86;
    data[952]=413;
code[2061]=9413;    data[2933]=766;
code[1118]=3285;code[425]=1993;code[1150]=2435;code[2240]=3447;code[238]=3648;code[2062]=1440;    data[3378]=607;
code[894]=3430;code[1273]=976;    data[3331]=649;
code[203]=1833;code[1656]=373;    data[3560]=68;
code[465]=3323;    data[2284]=474;
    data[822]=-412;
    data[632]=196;
code[1307]=3028;code[2229]=333;code[1408]=831;    data[2345]=399;
code[845]=2516;    data[686]=-886;
code[748]=307;code[646]=1192;code[961]=2760;    data[776]=522;
code[2238]=3948;code[1178]=3600;code[1997]=1642;    data[3136]=-887;
code[830]=2821;code[1124]=996;code[733]=2693;code[1814]=9413;code[1026]=2760;code[288]=191;code[1716]=2479;code[244]=2528;    data[280]=-594;
    data[1017]=974;
code[2066]=2811;    data[209]=-234;
    data[1221]=79;
    data[725]=873;
code[1372]=3028;code[1204]=1875;    data[3074]=285;
code[1409]=808;code[770]=2118;code[1889]=3278;code[501]=3028;code[1007]=1579;code[1825]=1859;    data[2726]=0;
code[215]=3723;    data[627]=-849;
code[1567]=1557;code[850]=1472;code[688]=176;code[2090]=2967;code[1317]=2093;code[590]=3181;code[658]=1467;code[761]=636;    data[1814]=680;
code[1258]=1158;    data[3348]=-324;
    data[2427]=-497;
    data[2883]=884;
code[1137]=714;    data[2099]=-91;
    data[2778]=-709;
code[282]=2472;    data[796]=879;
code[390]=1158;    data[639]=496;
    data[496]=103;
code[510]=2000;    data[2144]=486;
code[635]=1457;    data[570]=65;
code[951]=3031;    data[3247]=-985;
    data[2553]=0;
code[172]=2760;code[1735]=3798;    data[2638]=-182;
code[1072]=2606;    data[2760]=27;
code[544]=2693;code[513]=2208;code[272]=352;code[2106]=3285;code[179]=339;code[470]=3734;    data[170]=488;
code[241]=482;code[1841]=576;    data[2399]=-249;
code[2111]=339;code[1874]=2586;    data[2973]=-903;
code[731]=2490;code[1767]=967;    data[3252]=338;
    data[3597]=366;
code[962]=830;    data[3676]=-623;
    data[3850]=-257;
code[224]=1046;    data[369]=-111;
code[80]=622;code[1202]=2085;code[1544]=3626;    data[2163]=-404;
    data[2828]=-129;
    data[619]=-407;
code[93]=9818;code[939]=17;code[523]=3524;    data[3666]=408;
code[450]=1993;code[302]=885;    data[2956]=-429;
    data[1608]=321;
code[1676]=2832;code[176]=1333;    data[2221]=656;
    data[3691]=-636;
    data[2437]=650;
code[2059]=3133;code[212]=473;code[599]=1274;code[1189]=1657;code[111]=1158;code[699]=2000;code[1574]=4224;code[1057]=852;code[1537]=2656;code[952]=1271;code[1129]=1158;code[2070]=601;    data[3144]=957;
code[1691]=4224;code[1434]=945;code[1897]=3508;code[622]=1709;code[2005]=2377;    data[801]=395;
code[954]=8461;code[1982]=3133;code[1057]=1449;code[917]=2586;code[2263]=314;    data[3108]=703;
code[1088]=1948;    data[1948]=-249;
code[1380]=2760;code[824]=1157;    data[3250]=-746;
code[438]=2005;code[2086]=1254;    data[1142]=-850;
    data[557]=-309;
    data[2794]=-972;
    data[2656]=1;
code[285]=4404;code[1034]=2030;code[853]=220;code[876]=2664;code[1519]=8461;code[521]=1540;code[354]=3028;code[1028]=2693;    data[2073]=600;
code[84]=1683;    data[2530]=-153;
code[1196]=2829;    data[3915]=666;
    data[1586]=-567;
code[1767]=272;code[1751]=3096;code[1475]=1158;code[1990]=339;code[1687]=3595;code[1074]=4224;code[1403]=2000;code[1031]=3760;code[1318]=1158;code[723]=3506;code[665]=1158;code[2268]=2220;code[844]=1037;code[774]=751;code[734]=1158;    data[1046]=-821;
code[118]=2528;        data[3028]=(int[])elements;
    data[2550]=-429;
    data[3067]=-720;
    data[1274]=253;
    data[862]=194;
code[569]=2000;code[948]=1108;code[1985]=3600;    data[2478]=-869;
    data[3172]=478;
code[972]=2656;    data[3435]=-872;
    data[623]=-727;
code[1781]=2652;code[444]=1512;    data[2692]=962;
    data[1657]=false;
    data[46]=-907;
    data[1989]=767;
    data[3398]=-331;
    data[1607]=-508;
code[1449]=3723;code[517]=9886;code[1662]=2088;    data[1661]=577;
    data[2224]=192;
code[308]=482;    data[2037]=-858;
code[971]=2760;code[1138]=4684;code[2253]=3353;code[662]=1158;code[1246]=2418;code[1316]=482;    data[352]=2;
code[1118]=709;code[1952]=1890;code[435]=2470;    data[2525]=-257;
code[787]=3055;code[719]=703;code[1544]=97;    data[3245]=-725;
code[1629]=1158;    data[1890]=0;
code[2027]=1158;code[1593]=3658;code[1012]=3727;code[1237]=361;    data[3016]=-244;
code[554]=1431;    data[2098]=-859;
code[717]=1281;    data[2194]=433;
    data[2693]=-383;
    data[3924]=-423;
code[1962]=2624;    data[1290]=434;
code[1478]=1158;code[1842]=98;    data[1924]=-595;
    data[279]=-326;
    data[3223]=833;
code[296]=1439;code[332]=493;    data[2894]=726;
    data[1431]=65;
    data[3129]=214;
    data[3]=501;
    data[714]=180;
code[1388]=5667;code[1174]=2341;code[1780]=2528;code[2126]=7942;code[770]=3995;code[1270]=2000;code[154]=9818;code[843]=2693;    data[1211]=-735;
    data[1693]=165;
    data[424]=138;
    data[2586]=249;
code[1801]=442;code[841]=2760;    data[2486]=261;
code[1499]=3280;code[1216]=2378;code[1259]=1007;    data[1186]=-196;
code[1556]=2081;code[1204]=825;code[1526]=2760;    data[2341]=65;
    data[2065]=645;
    data[3006]=606;
    data[905]=-858;
code[226]=3785;    data[3783]=561;
code[1157]=1689;code[1377]=3473;code[2199]=2726;code[1242]=2021;    data[2608]=923;
code[2185]=4224;    data[3948]="";
code[690]=3028;    data[2528]=left;
code[566]=2869;code[2022]=1199;code[887]=2821;    data[447]=169;
code[2180]=1013;    data[3567]=-878;
code[1712]=1128;    data[2017]=21;
code[353]=2931;code[1545]=658;code[653]=2656;code[2149]=1158;    data[2383]=-341;
code[363]=2634;code[773]=1774;code[853]=2093;code[1819]=2005;    data[3958]=517;
    data[1872]=-731;
code[1938]=4224;    data[2644]=345;
    data[3133]=false;
    data[2751]=-591;
    data[3772]=-462;
code[1256]=9721;code[1755]=4297;    data[3745]=-15;
code[340]=1439;    data[1681]=-193;
code[1764]=1397;code[1822]=3581;    data[310]=-733;
    data[1748]=-925;
code[687]=889;code[1894]=2244;code[745]=3308;code[1164]=1657;    data[1729]=74;
code[1559]=1556;    data[1347]=864;
    data[3383]=-480;
code[715]=3871;    data[3684]=-431;
code[2044]=3309;code[583]=1119;code[2236]=1820;code[647]=145;code[1743]=2760;code[452]=8248;    data[2821]=false;
    data[3872]=423;
    data[654]=217;
code[974]=2968;code[559]=1263;    data[1197]=-157;
    data[2005]=-907;
code[1404]=2074;    data[2852]=-779;
code[203]=1274;code[1272]=3028;    data[611]=-29;
code[760]=4224;    data[3346]=239;
    data[2072]=-766;
    data[1505]=781;
code[1466]=2656;    data[2441]=655;
code[322]=2693;code[958]=2200;    data[2400]=-833;
code[321]=1678;    data[2155]=-803;
code[713]=2435;code[266]=1966;    data[2599]=871;
    data[633]=-460;
    data[2571]=191;
    data[1262]=978;
code[970]=60;    data[3270]=139;
code[1322]=2130;    data[2546]=547;
    data[1371]=592;
code[1141]=3118;    data[3280]=816;
code[319]=3826;    data[2258]=-704;
code[2073]=2710;    data[329]=-603;
    data[794]=-220;
code[706]=9886;code[808]=2087;code[1191]=9413;code[451]=1872;code[999]=3028;    data[3715]=495;
    data[2670]=878;
code[1120]=2760;code[1588]=2553;    data[1919]=-253;
code[2212]=368;    data[3430]=-722;
code[1620]=2760;    data[2102]=65;
code[632]=3792;    data[1912]=-1303;
    data[27]=667;
code[1925]=1039;    data[2396]=477;
code[1336]=2760;code[655]=919;code[1389]=2481;code[1895]=2692;code[338]=9721;code[1943]=452;code[1438]=421;code[2260]=2412;code[657]=3890;code[1879]=7942;code[1705]=1912;    data[2885]=755;
    data[2589]=310;
    data[376]=299;
    data[3741]=-301;
code[2132]=3028;
    while(true)
    {
    	switch(code[vpc])
    	{
    		case 4684:
    			data[code[vpc+(26)]]= (int)data[code[vpc+(-9)]]<= (int)data[code[vpc+(-18)]];
    			vpc+=53;
    			break;
    		case 7942:
    			Quicksort_obfuscated((int[])data[code[vpc+(6)]], (int)data[code[vpc+(23)]], (int)data[code[vpc+(-15)]]);
    			vpc+=59;
    			break;
    		case 2093:
    			((int[])data[code[vpc+(-10)]])[(int)data[code[vpc+(1)]]] = ((int[])data[code[vpc+(-19)]])[(int)data[code[vpc+(19)]]];
    			vpc+=71;
    			break;
    		case 9818:
    			data[code[vpc+(18)]]= (int)data[code[vpc+(25)]];
    			vpc+=61;
    			break;
    		case 4404:
    			data[code[vpc+(11)]]= (int)data[code[vpc+(23)]]/ (int)data[code[vpc+(-13)]];
    			vpc+=53;
    			break;
    		case 9886:
    			data[code[vpc+(-7)]]= ((int[])data[code[vpc+(-16)]])[(int)data[code[vpc+(28)]]] < (int)data[code[vpc+(27)]];
    			vpc+=54;
    			break;
    		case 3723:
    			data[code[vpc+(26)]]= (int)data[code[vpc+(29)]]+ (int)data[code[vpc+(17)]];
    			vpc+=70;
    			break;
    		case 4176:
    			return (string)data[code[vpc+(-11)]];
    			vpc+=65;
    		case 8461:
    			data[code[vpc+(17)]]= (int)data[code[vpc+(7)]]- (int)data[code[vpc+(18)]];
    			vpc+=55;
    			break;
    		case 1157:
    			data[code[vpc+(6)]]= (int)data[code[vpc+(19)]]< ((int[])data[code[vpc+(-10)]])[(int)data[code[vpc+(17)]]];
    			vpc+=65;
    			break;
    		case 9721:
    			data[code[vpc+(-16)]]= ((int[])data[code[vpc+(16)]])[(int)data[code[vpc+(2)]]];
    			vpc+=61;
    			break;
    		default:
    			data[code[vpc+(-1)]]=(bool)data[code[vpc+(-2)]]?(int)data[code[vpc+(-17)]]:(int)data[code[vpc+(28)]];
    			vpc+=(int)data[code[vpc+(-1)]];
    			break;
    		case 4297:
    			data[code[vpc+(-20)]]= (int)data[code[vpc+(25)]]< (int)data[code[vpc+(-12)]];
    			vpc+=59;
    			break;
    		case 5667:
    			((int[])data[code[vpc+(-16)]])[(int)data[code[vpc+(-8)]]] = (int)data[code[vpc+(-10)]];
    			vpc+=61;
    			break;
    		case 4224:
    			vpc += (int)data[code[vpc+(14)]];
    			vpc+=64;
    			break;
    	}
    }

    return null;
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
            string time = String.Format("   {0}     , sec", timespan.TotalSeconds);
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

            time = String.Format("  {0}     , sec", timespan.TotalSeconds);
            log = id + " " + runId + " finished in,       " + time;
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