using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Iterative_class_default
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
            BinarySearch_Iterative_class_default bs = new BinarySearch_Iterative_class_default();
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
//            result += " t_class_default";
//            result += "     t_method_junk";
            result += "     t_class_junk";
            result += " " + "\n";


            int[] unsorted_original = testData.ToArray();
            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {                
                Console.WriteLine(i+ " ##############");
                Debug.WriteLine(i+ " ##############");
                string t_original = Time_Operation(i+ " BinarySearch_Iterative_class_default", BinarySearchIterative_obfuscated);

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

//                [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]
private static int BinarySearchIterative_obfuscated(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    int[] code = new int[100500];
    object[] data = new object[4120];
    int vpc = 32;

    code[60907]=-189;code[80274]=1389;code[66872]=-570;code[36594]=-314;code[42678]=-154;code[77635]=992;
    code[5094]=688;code[66777]=1339;code[11494]=757;code[31734]=146;code[77973]=-36;code[74361]=-623;
    code[67627]=1373;code[11510]=-328;code[92315]=-343;code[20755]=156;code[51517]=92;code[91078]=697;
    code[15191]=473;code[32249]=1217;code[21597]=767;code[14512]=-900;code[57466]=1211;code[62365]=-159;
    code[69027]=-901;code[65392]=-983;code[39685]=547;code[46635]=-450;code[58778]=618;code[28418]=790;
    code[5791]=-762;code[35781]=-596;code[13269]=-225;code[28598]=534;code[77284]=1463;code[78870]=312;
    code[38402]=71;code[24486]=-828;code[24265]=749;code[58228]=970;code[33033]=945;code[58499]=1197;
    code[61541]=-501;code[6792]=1233;code[97779]=715;code[9450]=259;code[30814]=511;code[83352]=-701;
    code[35270]=1456;code[91272]=-346;code[60310]=-983;code[57033]=753;code[25611]=-686;code[62788]=1415;
    code[37735]=-13;code[98363]=1212;code[6850]=236;code[38938]=-301;code[51567]=192;code[55200]=1331;
    code[24365]=-23;code[64397]=-793;code[89597]=-298;code[21946]=943;code[60235]=-691;code[72150]=-354;
    code[79545]=-206;code[18906]=-196;code[21156]=1202;code[62721]=216;code[57773]=-747;code[52059]=444;
    code[71083]=-478;code[43760]=1030;code[21837]=374;code[60961]=1184;code[43567]=1439;code[1943]=-478;
    code[36789]=211;code[81380]=1434;code[91184]=1118;code[36859]=-372;code[68062]=800;code[9413]=876;
    code[30793]=-836;code[6943]=580;code[85726]=-844;code[35932]=-648;code[87742]=-843;code[37750]=706;
    code[84997]=15;code[56286]=-877;code[51994]=1110;code[82927]=1039;code[29975]=1447;code[96055]=814;
    code[7139]=626;code[58223]=818;code[73835]=-334;code[90502]=1468;code[11576]=712;code[50820]=-621;
    code[48309]=1435;code[2094]=-73;code[62133]=1195;code[33763]=-243;code[10947]=-683;code[12853]=252;
    code[28876]=-208;code[73782]=1082;code[89939]=-306;code[45454]=-182;code[11036]=-143;code[56406]=-494;
    code[48566]=575;code[40832]=516;code[16328]=-29;code[57030]=-598;code[90510]=20;code[57172]=357;
    code[82734]=135;code[19845]=49;code[64634]=631;code[62009]=1359;code[52515]=-805;code[44233]=43;
    code[53498]=-832;code[9274]=1093;code[23374]=-555;code[4208]=-657;code[41507]=1045;code[89208]=1470;
    code[47441]=823;code[14128]=801;code[56242]=1417;code[60341]=1197;code[75203]=-523;code[998]=101;
    code[8087]=-920;code[68758]=142;code[72974]=543;code[68341]=12;code[19088]=1471;code[7463]=-763;
    code[29760]=825;code[93292]=805;code[36832]=78;code[13072]=-988;code[56940]=-477;code[95259]=1284;
    code[51469]=1241;code[38622]=388;code[48027]=402;code[67255]=-147;code[5770]=628;code[76054]=-500;
    code[49666]=461;code[41349]=989;code[13894]=206;code[80222]=208;code[65838]=-887;code[42650]=1073;
    code[3891]=1195;code[51500]=-208;code[6130]=-988;code[87847]=1177;code[8492]=926;code[94966]=1074;
    code[23418]=-689;code[93167]=571;code[32116]=832;code[3789]=611;code[97830]=820;code[22917]=954;
    code[1998]=-165;code[87102]=-791;code[41311]=161;code[25993]=166;code[47447]=387;code[51939]=499;
    code[4897]=-120;code[28165]=-869;code[78136]=1213;code[11629]=809;code[64303]=454;code[56547]=-966;
    code[55844]=-577;code[16451]=1305;code[780]=949;code[86022]=-224;code[65338]=826;code[29857]=816;
    code[13897]=975;code[46241]=549;code[51432]=195;code[35928]=695;code[61070]=-182;code[58292]=1418;
    code[45501]=1463;code[87138]=-781;code[61542]=260;code[14257]=95;code[77557]=1132;code[53082]=-397;
    code[30239]=-159;code[46119]=730;code[70243]=-485;code[95430]=-206;code[5542]=384;code[91871]=1468;
    code[42759]=239;code[21307]=-597;code[22544]=1211;code[40812]=-430;code[59239]=-510;code[47169]=-944;
    code[91734]=920;code[70175]=-636;code[59181]=1147;code[95964]=-287;code[26337]=-454;code[32060]=-562;
    code[1946]=663;code[98405]=3;code[37964]=-345;code[91673]=1247;code[7147]=1199;code[66568]=-709;
    code[29369]=1450;code[21480]=1217;code[44905]=-251;code[65537]=-739;code[87151]=91;code[78336]=1327;
    code[51044]=1009;code[73275]=-510;code[60175]=571;code[72878]=-483;code[17767]=-909;code[14289]=397;
    code[90990]=-989;code[85482]=-182;code[28559]=425;code[95612]=-918;code[10624]=454;code[85792]=521;
    code[64851]=-831;code[84271]=1405;code[56924]=-464;code[30957]=457;code[89017]=-880;code[89804]=435;
    code[53558]=790;code[30183]=105;code[15543]=138;code[94446]=-362;code[84230]=636;code[98668]=105;
    code[45150]=-189;code[82444]=-258;code[48745]=866;code[82925]=1315;code[95475]=-699;code[55357]=327;
    code[79420]=907;code[64371]=1405;code[73238]=398;code[67669]=1142;code[11157]=-309;code[79845]=420;
    code[27124]=272;code[88268]=625;code[64513]=495;code[77428]=1476;code[8635]=-10;code[51552]=-396;
    code[39609]=-973;code[9840]=-652;code[22429]=1418;code[62718]=30;code[16606]=923;code[65532]=-21;
    code[81899]=1443;code[52932]=-303;code[98619]=-689;code[33285]=-569;code[53286]=-370;code[2718]=1439;
    code[87253]=-563;code[28567]=-121;code[35186]=400;code[44735]=-16;code[25122]=-3;code[57101]=794;
    code[46361]=335;code[63705]=-641;code[65567]=-45;code[40488]=251;code[86124]=216;code[83951]=661;
    code[7187]=228;code[939]=1403;code[6543]=-150;code[71503]=-646;code[98895]=-696;code[27240]=-880;
    code[68654]=-320;code[6256]=512;code[32575]=-355;code[14246]=40;code[41133]=1022;code[82165]=118;
    code[49326]=-532;code[52294]=-630;code[85360]=316;code[11961]=-46;code[34121]=549;code[28167]=1146;
    code[55357]=209;code[33047]=1274;code[69076]=65;code[73727]=-152;code[26434]=463;code[46279]=-50;
    code[32145]=994;code[17736]=497;code[34654]=48;code[25644]=-344;code[67733]=405;code[47274]=1193;
    code[82393]=408;code[29397]=144;code[291]=1223;code[71233]=-842;code[99694]=-491;code[5450]=1100;
    code[93393]=-421;code[73241]=1457;code[7579]=195;code[18509]=1263;code[73071]=-650;code[83237]=-872;
    code[35169]=300;code[3698]=1300;code[36643]=-956;code[18550]=1471;code[1359]=128;code[9038]=-691;
    code[13443]=-310;code[33816]=-66;code[88115]=-8;code[39008]=-710;code[74728]=-160;code[67288]=-718;
    code[69390]=-320;code[18799]=-511;code[37985]=412;code[15120]=699;code[73880]=-398;code[10820]=206;
    code[85687]=971;code[70220]=1435;code[1920]=-837;code[83081]=195;code[14274]=512;code[85347]=998;
    code[14240]=1026;code[2859]=-176;code[75581]=780;code[30951]=-966;code[85487]=1309;code[23097]=-769;
    code[83488]=1472;code[61376]=120;code[30234]=25;code[39075]=1232;code[16917]=1134;code[52358]=-780;
    code[70191]=34;code[9754]=695;code[51211]=-522;code[97565]=-786;code[42504]=-31;code[5435]=418;
    code[53939]=1051;code[93219]=-943;code[93764]=-766;code[63524]=1321;code[56148]=515;code[14417]=-925;
    code[45711]=-55;code[17804]=829;code[21708]=1391;code[63422]=-281;code[29102]=1350;code[63464]=-155;
    code[61809]=574;code[50662]=647;code[95789]=-640;code[67285]=107;code[93937]=-892;code[91619]=200;
    code[48514]=-86;code[96460]=-815;code[22277]=480;code[53221]=-770;code[27183]=-834;code[22429]=-672;
    code[1445]=-403;code[87396]=166;code[76033]=915;code[27920]=491;code[18997]=473;code[41006]=-243;
    code[59282]=1432;code[98039]=36;code[94142]=750;code[9606]=28;code[46902]=742;code[25024]=1125;
    code[100159]=391;code[6660]=743;code[41266]=348;code[6797]=370;code[40880]=-68;code[64793]=785;
    code[27594]=-493;code[68996]=-579;code[76931]=-213;code[29274]=1233;code[96251]=641;code[48688]=-379;
    code[61985]=-713;code[15618]=425;code[97600]=1029;code[66785]=-207;code[99501]=-952;code[47222]=-501;
    code[70336]=451;code[18683]=624;code[52441]=1149;code[90073]=-458;code[32991]=-347;code[14062]=834;
    code[1389]=1317;code[64925]=-622;code[40757]=-111;code[89695]=-151;code[7262]=1044;code[8089]=-262;
    code[38583]=243;code[57999]=487;code[71186]=-183;code[72760]=-363;code[73680]=216;code[47103]=-538;
    code[12985]=603;code[37332]=-756;code[76430]=-332;code[92498]=-112;code[98001]=54;code[55907]=-890;
    code[16645]=282;code[91653]=585;code[12750]=-675;code[12819]=1205;code[50255]=1225;code[26710]=-940;
    code[28404]=-248;code[51121]=-998;code[54016]=1211;code[59]=317;code[46061]=152;code[2248]=909;
    code[98915]=986;code[58222]=1012;code[90168]=812;code[32199]=1405;code[94591]=332;code[43163]=-512;
    code[41726]=-776;code[12895]=507;code[36093]=466;code[68830]=-403;code[37767]=-133;code[81942]=148;
    code[76256]=1298;code[82191]=-774;code[42318]=-928;code[58873]=761;code[49303]=-630;code[65335]=-170;
    code[55344]=-194;code[98997]=937;code[57281]=-242;code[8348]=874;code[87600]=-217;code[58883]=119;
    code[76018]=-7;code[16880]=1179;code[78006]=958;code[39009]=592;    data[3819]=810;
code[180]=1634;    data[2329]=-823;
    data[1695]=-859;
    data[1980]=-132;
code[340]=1204;code[168]=2966;    data[1107]=470;
code[41]=2881;code[392]=2401;code[326]=965;    data[3596]=1;
    data[3575]=-744;
    data[3263]=-1;
code[399]=3221;code[149]=985;code[502]=441;code[557]=441;code[83]=3936;code[728]=2309;code[923]=47;    data[2495]=374;
code[165]=1938;code[923]=1514;code[753]=6947;    data[3048]=423;
    data[2376]=-519;
code[895]=77;code[623]=2878;code[135]=1925;    data[279]=-540;
code[517]=1145;    data[1758]=903;
    data[3988]=877;
code[710]=1567;    data[3182]=917;
    data[2781]=key;
code[935]=692;    data[3864]=-492;
code[51]=2878;    data[108]=-432;
code[857]=342;    data[2987]=-563;
code[208]=6499;code[355]=565;code[717]=3143;code[602]=2732;    data[2966]=min;
code[282]=2059;code[92]=1251;    data[2640]=-552;
code[488]=2188;code[692]=3826;code[106]=505;code[271]=3432;code[656]=178;code[682]=2704;    data[1847]=485;
    data[1964]=-696;
code[619]=3550;    data[391]=246;
    data[1810]=650;
code[575]=4196;code[301]=287;code[561]=1840;    data[154]=-569;
code[188]=3564;    data[447]=3;
    data[1295]=-455;
code[60]=3280;code[953]=14;    data[1697]=853;
code[346]=1026;    data[569]=-380;
code[190]=985;code[947]=3263;code[533]=134;    data[2058]=-320;
code[769]=2572;code[461]=3327;code[634]=2572;code[449]=2162;code[212]=301;    data[1567]=56;
code[711]=2443;code[510]=220;    data[2732]=57;
code[463]=9126;code[258]=2781;    data[265]=-396;
code[35]=2966;    data[2901]=-14;
code[15]=1490;code[422]=2572;code[40]=2656;    data[1087]=176;
    data[2572]=921;
code[32]=6236;code[738]=1043;code[763]=3845;code[772]=3009;    data[855]=293;
code[94]=3781;code[595]=1442;    data[3562]=96;
    data[965]=false;
    data[926]=57;
code[828]=2878;code[572]=3182;    data[993]=872;
    data[211]=292;
code[387]=974;code[506]=2670;    data[1466]=538;
code[418]=2107;code[290]=2652;code[272]=965;    data[2684]=-459;
code[279]=1967;code[444]=2685;    data[87]=-129;
    data[2345]=-980;
code[934]=236;code[894]=976;code[119]=2671;        data[134]=(int[])inputArray;
code[649]=3486;code[410]=1899;    data[1658]=616;
    data[649]=-81;
code[91]=103;code[429]=1877;code[230]=163;code[515]=2781;    data[613]=315;
code[416]=3654;code[426]=2660;    data[2609]=276;
    data[985]=-777;
code[699]=9126;code[628]=3126;    data[2656]=false;
code[478]=1988;    data[2185]=850;
code[173]=2878;code[586]=1220;    data[3230]=404;
code[393]=3291;    data[1746]=814;
code[579]=817;code[50]=1893;    data[2179]=-103;
code[564]=2150;code[872]=9126;code[883]=3395;code[370]=1793;    data[3643]=178;
    data[3395]=-831;
code[855]=1159;code[583]=3620;code[826]=2558;code[543]=2437;code[293]=134;    data[2129]=-792;
    data[462]=424;
    data[1418]=-834;
code[650]=3596;code[350]=2907;code[817]=2656;code[941]=2838;    data[318]=746;
code[926]=9631;    data[2706]=-700;
code[365]=2935;code[456]=3833;    data[3237]=180;
code[263]=3588;code[718]=2856;    data[3901]=822;
    data[940]=-933;
    data[749]=-732;
    data[817]=-276;
code[503]=2572;code[171]=892;    data[759]=-559;
    data[3572]=553;
    data[1251]=128;
    data[3516]=132;
    data[1204]=173;
    data[2627]=49;
code[410]=3447;    data[2864]=29;
    data[1437]=-464;
    data[2885]=-580;
    data[2909]=-144;
    data[2217]=-219;
    data[2582]=591;
code[750]=2966;    data[446]=57;
code[145]=2784;code[401]=9631;code[274]=2572;code[275]=8224;code[76]=1499;    data[2664]=521;
    data[3316]=931;
code[23]=2280;    data[15]=442;
    data[1868]=917;
    data[441]=false;
code[95]=4196;code[99]=474;code[166]=1119;code[152]=6947;    data[3925]=526;
    data[2863]=-566;
code[155]=3664;code[77]=2656;    data[2878]=max;
    data[1686]=155;
    data[3735]=-33;
code[284]=1921;code[352]=2279;code[809]=6236;code[52]=2081;code[866]=1773;    data[2289]=-916;
    data[2135]=-932;
    data[1809]=-397;
code[344]=4196;code[571]=3643;    data[520]=-801;
code[60]=196;    data[1676]=2;
    data[310]=637;
    data[2487]=852;
code[285]=3519;code[194]=2572;    data[3783]=-519;
    data[1078]=692;
code[859]=2253;code[489]=1718;    data[3029]=506;
code[371]=926;code[824]=1034;code[774]=3596;code[421]=1436;code[631]=500;    data[1241]=364;
    data[2410]=-731;
    data[103]=831;
code[812]=2966;    data[2726]=888;
code[122]=446;    data[2637]=-374;
code[460]=334;    data[2406]=-372;
    data[1360]=-360;
    data[3964]=-907;
    data[1815]=-403;
code[227]=1676;    data[3630]=-121;
    data[3929]=787;
    data[1088]=794;
    data[1594]=315;
code[477]=348;code[632]=6274;code[269]=3484;code[626]=987;    data[987]=434;
code[341]=2627;    data[1331]=-987;
code[474]=211;    data[2696]=691;
    data[2555]=-779;

    return (int)ClassInterpreterVirtualization_BinarySearch_Iterative_class_default_3011(vpc, data, code);

}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


      

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Iterative_class_default";
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

private static object ClassInterpreterVirtualization_BinarySearch_Iterative_class_default_3011(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 9126:
                vpc += (int)data[code[vpc + (11)]];
                vpc += 54;
                break;
            case 6236:
                data[code[vpc + (8)]] = (int)data[code[vpc + (3)]] <= (int)data[code[vpc + (19)]];
                vpc += 63;
                break;
            case 6274:
                data[code[vpc + (-9)]] = (int)data[code[vpc + (2)]] - (int)data[code[vpc + (18)]];
                vpc += 67;
                break;
            case 1145:
                data[code[vpc + (-15)]] = (int)data[code[vpc + (-2)]] < ((int[])data[code[vpc + (16)]])[(int)data[code[vpc + (-14)]]];
                vpc += 58;
                break;
            case 6947:
                data[code[vpc + (-3)]] = (int)data[code[vpc + (16)]] + (int)data[code[vpc + (21)]];
                vpc += 56;
                break;
            case 8224:
                data[code[vpc + (-3)]] = (int)data[code[vpc + (-17)]] == ((int[])data[code[vpc + (18)]])[(int)data[code[vpc + (-1)]]];
                vpc += 69;
                break;
            case 6499:
                data[code[vpc + (-14)]] = (int)data[code[vpc + (-18)]] / (int)data[code[vpc + (19)]];
                vpc += 67;
                break;
            case 9631:
                return (int)data[code[vpc + (21)]];
                vpc += 62;
            default:
                data[code[vpc + (-3)]] = (bool)data[code[vpc + (-18)]] ? (int)data[code[vpc + (27)]] : (int)data[code[vpc + (-4)]];
                vpc += (int)data[code[vpc + (-3)]];
                break;
        }
    }

    return null;
}


    }
}