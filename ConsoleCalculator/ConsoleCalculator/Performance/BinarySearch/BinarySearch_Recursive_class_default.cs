using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Recursive_class_default
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
            BinarySearch_Recursive_class_default bs = new BinarySearch_Recursive_class_default();
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
//            result += "     t_class";
//            result += " t_method_default";
            result += " t_class_default";
//            result += "     t_method_junk";
//            result += "     t_class_junk";
            result += " " + "\n";


            int[] unsorted_original = testData.ToArray();
            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {                
                Console.WriteLine(i+ " ##############");
                Debug.WriteLine(i+ " ##############");
                string t_original = Time_Operation(i+ " BinarySearch_Recursive_class_default", BinarySearchRecursive_obfuscated);

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
    int[] code = new int[100828];
    object[] data = new object[4609];
    int vpc = 62;

    code[7974]=1366;code[38892]=206;code[80924]=265;code[34762]=-926;code[22136]=1368;code[34912]=-252;
    code[47543]=-763;code[14798]=1171;code[44484]=457;code[73718]=1409;code[90836]=-918;code[22938]=305;
    code[12536]=-919;code[15719]=924;code[45376]=1460;code[9421]=-198;code[56846]=-780;code[22633]=-516;
    code[22101]=229;code[85660]=982;code[8784]=-648;code[69417]=291;code[76794]=785;code[39262]=1465;
    code[45104]=-677;code[17478]=-314;code[16479]=-844;code[31785]=-886;code[72494]=1159;code[36125]=924;
    code[35335]=437;code[58467]=-412;code[86086]=-937;code[74176]=-42;code[87764]=1382;code[65484]=1373;
    code[73952]=1345;code[88381]=899;code[34751]=777;code[76670]=25;code[64861]=-576;code[32529]=-199;
    code[81751]=1047;code[15885]=252;code[77924]=-554;code[47866]=-112;code[13474]=-801;code[44627]=280;
    code[56581]=132;code[66827]=840;code[98662]=-986;code[11652]=235;code[48389]=-440;code[54546]=-437;
    code[18773]=388;code[70706]=-980;code[10410]=1370;code[12766]=-549;code[25425]=-352;code[42809]=-913;
    code[87490]=-414;code[61562]=729;code[48226]=-266;code[82237]=634;code[49955]=-90;code[20032]=1228;
    code[4849]=-940;code[43516]=593;code[5477]=1070;code[84767]=466;code[28029]=1330;code[31744]=-457;
    code[48122]=166;code[25436]=-537;code[96093]=-345;code[26229]=-246;code[2874]=569;code[87583]=859;
    code[39866]=59;code[1613]=-536;code[41183]=1218;code[73594]=1054;code[35966]=1024;code[96793]=-802;
    code[52083]=223;code[12728]=59;code[42197]=1094;code[76308]=1338;code[92739]=-18;code[21639]=-971;
    code[4200]=575;code[70652]=-417;code[10495]=1241;code[87020]=50;code[15668]=719;code[24392]=576;
    code[81904]=636;code[17974]=-24;code[20394]=232;code[86787]=668;code[51082]=-568;code[67444]=159;
    code[13692]=1090;code[89072]=-524;code[87835]=1332;code[83092]=-995;code[21077]=-990;code[14550]=945;
    code[18801]=241;code[72379]=149;code[95444]=349;code[93144]=1072;code[24941]=238;code[61658]=909;
    code[66505]=-85;code[73933]=67;code[53675]=367;code[50921]=1171;code[96917]=-408;code[9841]=-331;
    code[1342]=681;code[55351]=-445;code[87073]=-401;code[42509]=1019;code[51464]=-1;code[20600]=764;
    code[78144]=1;code[72693]=1416;code[25132]=1100;code[21817]=600;code[22663]=-701;code[53544]=262;
    code[20148]=-7;code[47381]=655;code[50342]=-311;code[82383]=1373;code[40218]=125;code[45035]=-315;
    code[99909]=753;code[97326]=-981;code[7458]=1008;code[25544]=-351;code[16305]=-932;code[65725]=-672;
    code[83289]=345;code[62445]=-698;code[2075]=143;code[4338]=1234;code[14254]=-891;code[2264]=165;
    code[77607]=898;code[31125]=-414;code[58770]=-363;code[30941]=-188;code[96200]=116;code[98392]=369;
    code[88200]=-479;code[57093]=53;code[87345]=-322;code[34623]=-570;code[75150]=-155;code[84286]=1402;
    code[66181]=739;code[93660]=1353;code[41039]=382;code[13392]=1367;code[68466]=247;code[23998]=-215;
    code[49891]=-954;code[68235]=1267;code[72658]=-183;code[17892]=-52;code[56707]=-822;code[24844]=1029;
    code[89849]=554;code[2759]=1174;code[70625]=1125;code[72700]=78;code[93128]=-131;code[58310]=1217;
    code[32858]=-87;code[92553]=2;code[31654]=-928;code[87587]=-61;code[97867]=-371;code[93409]=1119;
    code[59957]=91;code[45544]=46;code[16222]=141;code[40188]=461;code[45320]=-708;code[5079]=963;
    code[52997]=-343;code[24862]=1072;code[78428]=1016;code[39396]=-633;code[44396]=974;code[58583]=-112;
    code[41232]=940;code[6587]=334;code[20456]=1176;code[84823]=598;code[70109]=-551;code[27757]=-341;
    code[40172]=-244;code[27270]=167;code[95695]=1483;code[44111]=-478;code[31759]=-669;code[88273]=-873;
    code[78868]=-901;code[60297]=-591;code[86826]=948;code[41069]=1012;code[86252]=-759;code[958]=-39;
    code[39456]=1162;code[38506]=447;code[27801]=27;code[9065]=-136;code[99573]=1456;code[43405]=188;
    code[54062]=1309;code[19966]=116;code[35518]=-70;code[4058]=-310;code[90829]=-965;code[75762]=-593;
    code[27474]=693;code[78453]=1290;code[77877]=176;code[41190]=-246;code[29551]=1214;code[7626]=-790;
    code[61667]=1146;code[94086]=1259;code[4313]=323;code[6404]=999;code[61432]=-694;code[63298]=1343;
    code[58608]=1401;code[45636]=208;code[5666]=833;code[48770]=-58;code[11450]=-454;code[30900]=496;
    code[63825]=-566;code[57825]=292;code[57883]=-679;code[18367]=625;code[85513]=-716;code[84209]=234;
    code[44262]=-660;code[23540]=-72;code[95858]=1379;code[55840]=-626;code[4990]=1101;code[33752]=1029;
    code[1793]=1313;code[24779]=399;code[40553]=746;code[97859]=-18;code[55662]=-164;code[27308]=1172;
    code[96398]=365;code[22738]=201;code[94838]=1443;code[9001]=168;code[12638]=1397;code[4467]=1299;
    code[50391]=-719;code[42988]=-596;code[67046]=-609;code[55348]=980;code[84604]=904;code[50350]=622;
    code[89006]=555;code[25012]=-627;code[14451]=105;code[94947]=-740;code[87270]=-89;code[41860]=10;
    code[73229]=-818;code[21084]=-821;code[75765]=1168;code[69218]=-853;code[88819]=-186;code[6054]=-276;
    code[27444]=1022;code[73387]=-12;code[79226]=196;code[3005]=-514;code[4738]=441;code[60294]=-205;
    code[73546]=1349;code[32673]=707;code[1731]=1350;code[5471]=-662;code[70305]=-945;code[43907]=479;
    code[95547]=192;code[4121]=1429;code[7577]=101;code[77430]=392;code[56693]=1395;code[88462]=-164;
    code[72042]=365;code[32115]=-33;code[33752]=-449;code[36032]=-626;code[47898]=1227;code[34538]=1029;
    code[54781]=-992;code[4208]=1352;code[27392]=1312;code[59736]=-375;code[37642]=-661;code[45136]=-228;
    code[44127]=-855;code[12025]=516;code[81538]=-898;code[76224]=927;code[6285]=1473;code[97647]=176;
    code[62664]=668;code[80708]=191;code[67012]=-286;code[11781]=-859;code[13552]=-428;code[43195]=-821;
    code[40201]=1067;code[28749]=593;code[36888]=567;code[96914]=446;code[9953]=-976;code[95720]=-309;
    code[10231]=877;code[34375]=84;code[13596]=428;code[75558]=384;code[3534]=427;code[32202]=511;
    code[12539]=-711;code[59039]=-782;code[1925]=-23;code[17584]=-479;code[63486]=-881;code[20954]=1454;
    code[76230]=-704;code[40860]=87;code[2857]=-26;code[37514]=529;code[72383]=309;code[37815]=1284;
    code[95270]=707;code[92957]=407;code[48372]=1186;code[3687]=1069;code[51187]=701;code[51732]=-376;
    code[4196]=1184;code[56410]=769;code[84221]=852;code[65237]=-866;code[54749]=-102;code[68341]=-960;
    code[16755]=-215;code[52979]=612;code[20052]=768;code[89386]=501;code[74699]=679;code[14378]=-160;
    code[47279]=528;code[73477]=887;code[1117]=-50;code[47788]=-812;code[61046]=-612;code[39679]=-614;
    code[83729]=660;code[78290]=1442;code[88400]=-197;code[37386]=463;code[521]=1264;code[40007]=-587;
    code[35205]=-22;code[63408]=1000;code[80074]=1281;code[51327]=-76;code[73712]=-442;code[24090]=-441;
    code[1219]=1229;code[4310]=-593;code[89266]=506;code[41424]=-973;code[92830]=-73;code[82147]=336;
    code[93881]=1273;code[72981]=49;code[30345]=392;code[33367]=408;code[21641]=408;code[40922]=549;
    code[75738]=684;code[28348]=732;code[65160]=-941;code[42706]=517;code[42881]=381;code[97293]=1461;
    code[28077]=-481;code[70603]=6;code[49889]=-36;code[24687]=1445;code[58144]=-765;code[87614]=1211;
    code[19023]=-777;code[6947]=-565;code[89980]=689;code[932]=122;code[49013]=57;code[41517]=-472;
    code[32396]=794;code[36761]=1242;code[95507]=-481;code[11026]=-54;code[95233]=847;code[14233]=-768;
    code[86386]=1320;code[6904]=1071;code[32099]=68;code[4334]=642;code[81158]=-9;code[50844]=392;
    code[96266]=-377;code[72054]=874;code[54784]=290;code[50278]=1138;code[80266]=221;code[8206]=942;
    code[2151]=-131;code[3137]=-78;code[99301]=226;code[94794]=124;code[95608]=1439;code[31991]=1410;
    code[61220]=-549;code[13159]=-854;code[38323]=887;code[40989]=1312;code[21537]=1019;code[95004]=744;
    code[49712]=-101;code[84208]=71;code[24237]=-286;code[29949]=-81;code[85384]=-272;code[81404]=1426;
    code[39967]=684;code[67763]=-214;code[46005]=-864;code[61363]=1447;code[93992]=876;code[14363]=-93;
    code[38874]=100;code[47923]=-897;code[8292]=-609;code[56795]=-467;code[40892]=-167;code[88320]=562;
    code[66067]=279;code[21096]=656;code[68436]=1373;code[11831]=-211;code[37625]=-601;code[66767]=765;
    code[8343]=-770;code[47243]=-603;code[20080]=1408;code[77186]=856;code[21906]=180;code[4324]=1000;
    code[81717]=-361;code[28810]=725;code[73429]=484;code[56963]=-843;code[80462]=-883;code[66468]=1361;
    code[85240]=1365;code[30270]=1457;code[63833]=1067;code[99781]=-437;code[78429]=922;code[96643]=1475;
    code[69367]=10;code[1454]=105;code[57253]=-667;code[41125]=-543;code[47270]=22;code[85903]=57;
    code[66904]=67;code[59219]=948;code[59993]=497;code[91558]=-911;code[43639]=309;code[31614]=-368;code[845]=1784;code[1163]=323;    data[2489]=151;
code[539]=298;    data[3220]=-969;
code[528]=43;code[642]=1784;code[901]=3046;    data[2519]=298;
    data[49]=939;
    data[241]=-475;
code[260]=3135;code[640]=2543;code[1052]=2809;code[940]=3896;code[530]=3466;    data[3881]=-343;
code[1070]=2958;code[474]=2678;code[140]=3750;    data[54]=435;
    data[3024]=-302;
code[314]=193;    data[3743]=163;
code[1164]=560;code[982]=1428;code[44]=219;code[352]=193;code[308]=219;code[369]=1095;code[674]=1894;code[117]=1468;code[474]=1685;code[207]=2287;    data[43]=-547;
    data[669]=-792;
code[544]=3449;code[399]=1752;code[323]=1398;code[1040]=1261;code[1025]=2904;    data[858]=-589;
    data[3946]=-270;
    data[3412]=159;
code[147]=280;    data[2246]=-90;
    data[3257]=374;
code[972]=46;    data[2927]=key;
    data[1687]=-985;
code[434]=3601;code[142]=3964;    data[693]=268;
code[549]=636;    data[914]=-207;
    data[1072]=-392;
    data[3862]=-775;
    data[105]=-532;
code[800]=2131;    data[3386]=34;
code[958]=3671;    data[3064]=686;
code[731]=806;code[480]=9115;    data[961]=-737;
    data[3693]=-849;
code[1009]=1393;code[681]=1295;code[85]=3964;code[75]=3473;code[1030]=2546;code[980]=2300;code[317]=2544;code[235]=2764;code[386]=3357;    data[2357]=212;
code[1088]=2952;code[1045]=1295;    data[2963]=-260;
code[224]=2024;code[1079]=1662;code[482]=101;code[241]=2855;    data[193]=780;
code[242]=1110;    data[2774]=552;
    data[3070]=-544;
code[1011]=260;    data[1691]=20;
    data[855]=-123;
code[844]=529;    data[2844]=-488;
code[285]=899;code[929]=2219;code[234]=3764;code[935]=1237;code[120]=798;code[841]=2927;code[663]=2378;    data[1816]=-531;
    data[1458]=-244;
code[914]=3449;    data[2293]=-930;
    data[2260]=755;
    data[2375]=954;
code[1018]=2938;code[499]=2966;code[347]=1752;    data[3897]=-600;
code[1009]=3784;    data[330]=-103;
    data[1942]=-927;
code[409]=3450;    data[469]=-948;
code[425]=1996;code[1026]=3815;code[599]=1110;    data[1364]=-611;
code[1085]=1784;code[775]=1964;code[942]=1164;    data[3523]=679;
    data[3533]=-17;
code[143]=2573;code[1163]=862;code[1035]=1752;code[549]=3731;    data[1801]=601;
    data[3473]=max;
code[792]=2938;    data[1280]=-64;
code[1105]=2784;code[1099]=81;    data[2582]=-150;
code[433]=1784;code[657]=5283;code[614]=1880;    data[2481]=138;
    data[3556]=298;
code[817]=1752;code[830]=219;        data[1784]=(int[])inputArray;
code[474]=3239;code[42]=3806;code[1114]=370;code[1178]=3429;code[542]=1752;code[1081]=2927;    data[3417]=831;
code[1102]=287;code[1007]=3832;    data[2958]=-43;
    data[3966]=-581;
code[361]=3928;code[1089]=1458;code[849]=241;code[300]=8122;    data[2702]=-242;
code[536]=1935;code[180]=2362;code[955]=2879;code[813]=924;code[912]=241;code[148]=2362;    data[1668]=-521;
code[185]=2880;    data[2688]=-787;
code[1027]=8122;code[1087]=3102;    data[3948]=453;
code[187]=3449;    data[3678]=809;
code[1154]=3449;    data[2362]=177;
code[748]=1894;code[816]=1485;code[280]=3549;    data[1472]=-740;
code[714]=3412;code[481]=715;    data[906]=-155;
    data[3964]=false;
code[617]=2774;    data[219]=min;
code[875]=1964;code[570]=2123;code[270]=3060;code[534]=2868;code[950]=2137;code[850]=1981;code[234]=525;code[505]=2937;code[920]=3106;    data[2066]=49;
code[992]=3365;code[796]=113;    data[1376]=907;
    data[122]=132;
    data[2671]=45;
    data[3414]=-405;
    data[2938]=1;
    data[1013]=825;
code[469]=280;    data[1788]=-413;
    data[179]=56;
    data[46]=778;
code[1139]=1854;code[494]=2089;code[870]=2037;code[919]=2161;code[390]=1757;    data[1752]=-648;
    data[1898]=417;
    data[2240]=-975;
code[1033]=292;    data[2750]=-536;
    data[2834]=-833;
code[1041]=2958;code[1155]=1197;    data[1757]=2;
    data[668]=-960;
code[291]=3473;code[351]=2724;code[108]=598;code[443]=2966;    data[1216]=884;
    data[253]=-824;
    data[1414]=-245;
    data[2697]=-347;
code[987]=3200;    data[91]=610;
    data[2880]=-1;
code[363]=2017;    data[3542]=471;
code[969]=1110;code[1021]=213;    data[1922]=-817;
    data[187]=198;
code[465]=1801;code[414]=6790;code[62]=4865;code[1112]=3272;    data[2212]=-830;
    data[2495]=594;
    data[598]=410;
    data[2966]=false;
    data[3437]=904;
    data[165]=-140;
    data[62]=547;
    data[3507]=853;
code[678]=2927;    data[806]=64;
    data[1894]=false;
code[64]=3498;    data[2333]=311;
code[727]=1215;code[778]=3071;code[848]=2952;    data[3991]=836;
code[328]=579;    data[110]=613;
    data[1622]=396;
code[125]=3411;    data[2678]=961;
    data[135]=59;
code[1115]=3473;code[296]=752;code[1152]=1458;    data[101]=64;
    data[1425]=-546;
    data[3411]=64;
    data[3485]=359;
code[546]=3483;code[793]=6473;    data[1360]=-14;
    data[2022]=-556;
code[665]=1752;    data[730]=-32;
    data[1964]=651;
code[937]=1347;    data[3876]=34;
    data[2421]=-945;
    data[2]=-802;
code[1019]=2864;code[422]=1737;    data[2394]=234;
code[304]=3471;code[104]=2914;code[1156]=947;    data[2937]=177;
    data[2882]=464;
    data[3200]=182;
    data[562]=-660;
code[123]=9115;    data[1147]=535;
    data[1900]=-285;
    data[3135]=909;
    data[1323]=18;
code[1014]=174;code[551]=2586;    data[683]=-373;
code[598]=3692;    data[2704]=569;
code[713]=2007;code[226]=2541;code[415]=2927;code[754]=3556;code[729]=9115;code[322]=2407;    data[820]=-75;
    data[1005]=-502;
    data[1286]=815;
    data[2998]=-620;

    return (int)ClassInterpreterVirtualization_BinarySearch_Recursive_class_default_5(vpc, data, code);

}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


       

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Recursive_class_default";
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

private static object ClassInterpreterVirtualization_BinarySearch_Recursive_class_default_5(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 4865:
                data[code[vpc + (23)]] = (int)data[code[vpc + (13)]] < (int)data[code[vpc + (-18)]];
                vpc += 61;
                break;
            case 6473:
                data[code[vpc + (-18)]] = (int)data[code[vpc + (24)]] - (int)data[code[vpc + (-1)]];
                vpc += 55;
                break;
            case 8122:
                data[code[vpc + (14)]] = (int)data[code[vpc + (8)]] + (int)data[code[vpc + (-9)]];
                vpc += 61;
                break;
            case 3928:
                data[code[vpc + (-14)]] = (int)data[code[vpc + (-9)]] / (int)data[code[vpc + (29)]];
                vpc += 53;
                break;
            case 1110:
                vpc += (int)data[code[vpc + (18)]];
                vpc += 58;
                break;
            case 2952:
                data[code[vpc + (1)]] = BinarySearchRecursive_obfuscated((int[])data[code[vpc + (-3)]], (int)data[code[vpc + (-7)]], (int)data[code[vpc + (-18)]], (int)data[code[vpc + (27)]]);
                vpc += 66;
                break;
            default:
                return (int)data[code[vpc + (-2)]];
                vpc += 55;
            case 9115:
                data[code[vpc + (-15)]] = (bool)data[code[vpc + (19)]] ? (int)data[code[vpc + (2)]] : (int)data[code[vpc + (25)]];
                vpc += (int)data[code[vpc + (-15)]];
                break;
            case 5283:
                data[code[vpc + (17)]] = (int)data[code[vpc + (21)]] < ((int[])data[code[vpc + (-15)]])[(int)data[code[vpc + (8)]]];
                vpc += 72;
                break;
            case 6790:
                data[code[vpc + (29)]] = (int)data[code[vpc + (1)]] == ((int[])data[code[vpc + (19)]])[(int)data[code[vpc + (-15)]]];
                vpc += 66;
                break;
        }
    }

    return null;
}


    }
}