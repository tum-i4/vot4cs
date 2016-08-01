using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortIterative_method
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> data;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            QuickSortIterative_method lt = new QuickSortIterative_method();
            time_warmup.Clear();
            time_run.Clear();
//
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

            Output("##################");
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
                int[] unsorted_original = data.ToArray();
                Console.WriteLine(i+ " ##############");
                Debug.WriteLine(i + " ##############");
                string t_original = Time_Operation("QuickSortIterative_method", i, QuickSort_Iterative, unsorted_original, WARMUP, ITERATIONS);
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
            string testName = "Performance#QuickSort_Check";
            Program.Start_Check(testName);
            bool condition = true;


            // Create an unsorted array of string elements
            //            int[] testData = GenerateDataStatic();
            int[] data = GenerateDataInt(360);
            var unsorted_obfuscated1 = (new List<int>(data));
            var int_list = new List<int>(data);
            
            int[] unsorted_obfuscated = int_list.ToArray();
            int[] unsorted_original = int_list.ToArray();

            // Print the unsorted array
            for (int i = 0; i < unsorted_original.Length; i++)
            {
                Console.Write(unsorted_original[i] + ", ");
            }
            Console.WriteLine("\n" + unsorted_original.Length);

            // Sort the array
            Quicksort_original(unsorted_original, 0, unsorted_original.Length - 1);
//            sort(unsorted_original, 0, unsorted_original.Length - 1);
            Output("original_finished");
            QuickSort_Iterative(unsorted_obfuscated, unsorted_obfuscated.Length, -1);

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



//        [Obfuscation(Exclude = false, Feature = "virtualization; method")]
string QuickSort_Iterative(int[] arr, int length, int right)
{
    //Virtualization variables
    int[] code = new int[100641];
    object[] data = new object[4249];
    int vpc = 87;

    code[87396]=-411;code[25262]=170;code[82536]=1191;code[81918]=-417;code[54221]=437;code[33091]=914;
    code[24217]=675;code[41699]=416;code[97519]=475;code[62642]=986;code[3751]=-418;code[34278]=293;
    code[34673]=239;code[73688]=528;code[31587]=309;code[45847]=1425;code[11177]=274;code[91221]=-201;
    code[28286]=1167;code[84548]=1143;code[8817]=523;code[26088]=1490;code[67895]=-271;code[58022]=325;
    code[9700]=-657;code[53192]=1191;code[5772]=-552;code[42821]=588;code[90112]=834;code[12433]=-190;
    code[14546]=-494;code[92531]=-963;code[12007]=-104;code[65882]=826;code[76878]=-764;code[28742]=-745;
    code[75502]=912;code[71161]=69;code[97988]=-139;code[84803]=-869;code[92520]=-495;code[51832]=-559;
    code[100148]=447;code[91857]=1329;code[8498]=-323;code[42698]=368;code[74813]=289;code[71736]=1212;
    code[69447]=-390;code[88242]=-211;code[64120]=1114;code[77103]=-996;code[85715]=66;code[12701]=-270;
    code[47540]=1494;code[66610]=377;code[89679]=-824;code[40753]=1355;code[69193]=857;code[2012]=350;
    code[44885]=807;code[65038]=232;code[67471]=845;code[36099]=-415;code[5262]=1055;code[74245]=823;
    code[47064]=316;code[41829]=-817;code[43883]=283;code[32694]=421;code[45582]=551;code[46216]=-784;
    code[61291]=1183;code[66043]=681;code[11161]=926;code[19878]=1367;code[22554]=-159;code[87548]=1285;
    code[20086]=-318;code[33339]=-717;code[6819]=1229;code[24151]=625;code[26163]=1330;code[8380]=-90;
    code[65934]=-172;code[50955]=-565;code[42067]=128;code[8782]=1063;code[26549]=398;code[88964]=992;
    code[8255]=715;code[12426]=-296;code[62851]=976;code[50866]=-673;code[66100]=253;code[87949]=-593;
    code[18321]=-472;code[50409]=402;code[38292]=1022;code[83206]=691;code[79512]=-271;code[1755]=948;
    code[26582]=-942;code[53257]=931;code[25096]=-890;code[65444]=600;code[39162]=335;code[3160]=-46;
    code[77327]=1395;code[2599]=173;code[42963]=1380;code[71209]=-616;code[46047]=-142;code[99851]=-484;
    code[95654]=315;code[44788]=137;code[73742]=-482;code[706]=975;code[67294]=-140;code[1782]=503;
    code[26302]=831;code[88729]=531;code[85670]=-416;code[77874]=619;code[18118]=-702;code[79780]=55;
    code[78806]=-107;code[25137]=1094;code[58803]=1159;code[32396]=1301;code[3133]=-194;code[82756]=807;
    code[60318]=-512;code[91314]=-546;code[53055]=-397;code[71755]=60;code[94643]=61;code[20940]=735;
    code[7105]=-763;code[30428]=-441;code[57323]=-140;code[2670]=1078;code[73813]=-944;code[67618]=-62;
    code[96365]=-577;code[20719]=1012;code[2224]=-758;code[57372]=1346;code[91619]=-604;code[1314]=639;
    code[32858]=479;code[12143]=1346;code[40883]=-80;code[48502]=-104;code[15022]=388;code[77211]=222;
    code[56507]=-755;code[35340]=717;code[29797]=1477;code[99608]=441;code[52681]=329;code[22572]=-106;
    code[3558]=1270;code[40481]=1108;code[86000]=-327;code[78888]=1280;code[8261]=616;code[90295]=1444;
    code[22508]=-781;code[42772]=-88;code[54420]=-217;code[22757]=4;code[40457]=791;code[24491]=1309;
    code[75058]=1208;code[64675]=1298;code[16978]=90;code[13328]=986;code[37003]=906;code[90922]=245;
    code[97233]=596;code[50711]=1199;code[77661]=1137;code[40966]=1287;code[20226]=-67;code[46612]=-480;
    code[56968]=561;code[3615]=-475;code[30777]=1055;code[96208]=-204;code[66906]=195;code[9826]=1428;
    code[63072]=1161;code[74820]=614;code[51730]=-744;code[61384]=152;code[18547]=1317;code[40146]=1255;
    code[81474]=-135;code[63434]=367;code[31165]=-180;code[72755]=-70;code[42278]=85;code[35550]=360;
    code[40303]=1306;code[49186]=363;code[81189]=462;code[83860]=219;code[54430]=331;code[25482]=1267;
    code[11232]=903;code[40358]=-755;code[76848]=-995;code[2420]=597;code[22722]=-666;code[40301]=1399;
    code[19322]=22;code[901]=-159;code[76022]=813;code[55471]=-519;code[51458]=-502;code[24679]=478;
    code[61786]=-839;code[65841]=498;code[9425]=1277;code[36372]=-308;code[9359]=808;code[43812]=370;
    code[93324]=561;code[61257]=44;code[41287]=785;code[32027]=-333;code[52531]=322;code[35563]=-6;
    code[57954]=241;code[73711]=1038;code[98770]=-849;code[39832]=1280;code[51944]=1023;code[48748]=747;
    code[35020]=61;code[54896]=-214;code[77719]=-692;code[87215]=171;code[97991]=151;code[41179]=-674;
    code[11743]=-667;code[78716]=992;code[88682]=1446;code[7006]=-788;code[71574]=-359;code[2377]=492;
    code[17980]=364;code[29742]=-920;code[32950]=307;code[3237]=-706;code[14113]=1274;code[7035]=1464;
    code[16972]=-992;code[49771]=-4;code[66675]=1211;code[42674]=-712;code[8817]=504;code[70326]=1120;
    code[28041]=496;code[3120]=344;code[74454]=-2;code[99416]=-772;code[40350]=1371;code[13689]=-435;
    code[83326]=1086;code[14228]=126;code[43123]=-272;code[99687]=-483;code[6380]=991;code[63258]=1194;
    code[48697]=677;code[42500]=1066;code[83781]=1271;code[51252]=442;code[85255]=118;code[75839]=822;
    code[49529]=236;code[38048]=851;code[92769]=1446;code[58848]=-450;code[87308]=-330;code[57415]=1070;
    code[74796]=1433;code[69110]=990;code[61503]=229;code[78974]=205;code[97624]=-617;code[5418]=-829;
    code[98352]=-597;code[26063]=231;code[44215]=397;code[38160]=-49;code[8134]=31;code[96452]=1335;
    code[91907]=-376;code[28707]=-788;code[21308]=21;code[1015]=-461;code[10128]=485;code[8392]=1147;
    code[22313]=782;code[97205]=-112;code[66693]=-322;code[76363]=-154;code[44343]=-227;code[76828]=901;
    code[72406]=-770;code[78569]=-229;code[89473]=-526;code[75206]=-174;code[1520]=881;code[88873]=-97;
    code[20781]=749;code[27215]=403;code[14420]=1095;code[97422]=-43;code[7834]=-1;code[27253]=815;
    code[59694]=-941;code[72246]=1023;code[65796]=549;code[49658]=509;code[48958]=311;code[36783]=-702;
    code[63184]=753;code[32869]=1276;code[85233]=881;code[84928]=172;code[83518]=511;code[14985]=1407;
    code[100]=-507;code[19671]=506;code[34354]=-50;code[68707]=-202;code[82668]=-865;code[71992]=1163;
    code[47510]=1344;code[68119]=-12;code[26090]=-302;code[88039]=704;code[33639]=-623;code[93966]=104;
    code[51486]=-857;code[53959]=-188;code[55965]=1004;code[90226]=1471;code[88048]=887;code[81358]=141;
    code[42688]=1227;code[26415]=-735;code[84738]=-885;code[29997]=433;code[99254]=153;code[44142]=1272;
    code[7637]=121;code[21114]=376;code[73449]=167;code[63269]=1125;code[26525]=884;code[9141]=-290;
    code[84955]=-106;code[76827]=-951;code[15878]=817;code[99670]=792;code[13029]=-450;code[97752]=-80;
    code[1686]=921;code[84516]=-280;code[85831]=-100;code[45838]=-875;code[62268]=567;code[25080]=-731;
    code[59575]=-136;code[26037]=19;code[12706]=1395;code[19418]=676;code[80529]=1446;code[26366]=210;
    code[28443]=-304;code[41840]=-352;code[47398]=803;code[78455]=1138;code[48016]=1103;code[53728]=1402;
    code[63133]=-149;code[100359]=1258;code[30020]=-899;code[66955]=-458;code[10908]=639;code[43043]=1029;
    code[47109]=456;code[59467]=-573;code[2757]=-248;code[57169]=-905;code[50990]=-112;code[565]=436;
    code[95047]=-510;code[58297]=1243;code[85299]=-16;code[63460]=875;code[81721]=-257;code[78545]=964;
    code[96727]=-277;code[37448]=898;code[31516]=-888;code[37840]=567;code[85614]=509;code[79639]=1220;
    code[13141]=521;code[83343]=-560;code[27525]=238;code[45742]=-321;code[33695]=56;code[96511]=-745;
    code[46426]=920;code[37182]=786;code[2530]=693;code[100626]=-574;code[80727]=1012;code[21135]=844;
    code[93473]=1021;code[72978]=154;code[98567]=-54;code[72837]=-149;code[40730]=727;code[77158]=-403;
    code[56915]=135;code[47994]=-209;code[84841]=271;code[45389]=345;code[33268]=-326;code[30018]=362;
    code[67982]=653;code[60562]=-567;code[60785]=551;code[8679]=-187;code[40097]=-775;code[24900]=162;
    code[77536]=1482;code[29438]=1390;code[70349]=546;code[70199]=926;code[136]=-675;code[15014]=426;
    code[20169]=708;code[32962]=-266;code[35632]=679;code[40989]=647;code[51345]=-550;code[79122]=-205;
    code[78189]=375;code[74129]=959;code[60851]=102;code[84608]=188;code[20826]=-971;code[54951]=1125;
    code[21740]=237;code[84471]=780;code[57598]=319;code[54723]=362;code[51536]=-923;code[97921]=1301;
    code[29511]=981;code[97767]=816;code[68736]=471;code[96095]=476;code[20794]=1435;code[18034]=-629;
    code[88747]=1283;code[16684]=400;code[29147]=684;code[36618]=-529;code[13828]=193;code[7807]=1147;
    code[83763]=737;code[8716]=1455;code[64033]=-398;code[81120]=864;code[58105]=1040;code[49384]=1030;
    code[47271]=-716;code[79732]=546;code[5737]=1389;code[64769]=-396;code[31770]=726;code[83565]=646;
    code[36438]=1458;code[25719]=1095;code[67139]=961;code[78818]=1039;code[71963]=-720;code[90019]=1469;
    code[50508]=1431;code[96024]=1414;code[16941]=83;code[57496]=-836;code[42559]=-116;code[1024]=1028;code[957]=1028;code[2093]=853;code[522]=9408;code[3158]=2894;code[997]=662;    data[1506]=55;
    data[819]=0;
code[2769]=3850;code[1563]=3213;    data[2610]="" ;
code[1911]=1274;code[2335]=1228;code[3547]=2610;    data[2441]=(int[])null;
    data[154]=-89;
code[382]=3790;code[2104]=9408;    data[682]=false;
        data[3093]=(int[])arr;
code[1372]=3213;code[2059]=443;    data[733]=right;
code[2369]=12;code[2056]=3651;code[3420]=682;    data[3879]=-236;
code[935]=154;code[2958]=1218;code[1327]=3435;code[2730]=3881;code[3283]=3850;code[3400]=2047;    data[558]=55;
code[2233]=3881;code[2188]=1218;code[1070]=2792;code[2565]=3881;code[1126]=3794;code[3117]=7328;code[1456]=3894;code[849]=154;code[2862]=2894;code[456]=6845;code[1081]=2610;code[1450]=3213;code[854]=2291;code[271]=2047;    data[286]=1514;
code[1789]=2035;code[3320]=2894;    data[2894]=252;
code[2812]=3881;code[1371]=1228;code[1277]=3435;code[1348]=3881;code[766]=558;code[2025]=3881;code[2033]=2328;code[3229]=1677;    data[1218]=1;
code[469]=682;    data[662]=240;
code[2946]=2842;code[2419]=12;    data[2744]=55;
code[448]=2894;code[1744]=9408;    data[958]=false;
code[1390]=1228;    data[3435]=false;
code[3325]=2894;code[151]=5416;code[1489]=4083;code[2994]=1239;    data[3894]=-106;
code[1379]=3093;code[1423]=3918;code[2116]=3402;code[2949]=3881;code[1008]=9408;code[3136]=2894;code[2701]=1228;code[3026]=1218;code[3516]=1532;    data[123]=55;
code[341]=2698;    data[3402]=55;
code[2126]=3913;    data[3881]=959;
code[2199]=3093;code[1192]=3850;code[3055]=2441;code[641]=1228;    data[2792]=1225530453;
code[2392]=3645;code[776]=3641;code[1705]=3881;code[936]=6690;code[2220]=1228;code[720]=1964;code[2502]=1228;    data[3721]=-848;
    data[3790]=length;
    data[1964]=false;
code[691]=1732;code[770]=1964;code[3529]=6822;    data[1532]=true;
code[1178]=819;code[1681]=1732;    data[547]=-1514;
code[2599]=3093;code[402]=1677;    data[2314]=false;
code[944]=2894;code[2825]=1677;code[2053]=3881;code[2040]=1228;code[1300]=286;code[2604]=3673;code[1050]=2314;    data[3065]=3007;
code[1886]=1218;code[1333]=1548;code[636]=3662;    data[2155]=55;
code[1248]=1732;code[240]=2291;code[2156]=3881;code[2755]=547;code[1272]=3881;code[277]=5150;code[807]=3881;code[3339]=4083;code[577]=4757;code[3204]=1218;code[1311]=9408;code[3227]=2441;code[511]=3065;code[2516]=4083;code[1840]=3881;    data[3651]=false;
    data[820]=-584;
code[2527]=1218;code[3399]=2894;code[1243]=1228;code[400]=2441;code[344]=2047;    data[1548]=454;
    data[300]=55;
    data[1239]=-981;
code[868]=4083;code[3107]=3416;code[715]=3881;code[3269]=3300;code[3175]=8538;code[1931]=2035;    data[1228]=-194;
    data[3519]=472;
code[2497]=1228;code[2650]=3850;code[3032]=2894;code[1542]=443;code[3407]=6845;code[2735]=3435;code[87]=5150;    data[2695]=0;
    data[853]=236;
code[1625]=3850;code[150]=3024;code[1063]=6822;code[2823]=3093;    data[12]=false;
code[177]=2291;code[2458]=7328;code[3350]=1218;code[2213]=2328;code[2980]=2894;    data[3641]=18;
code[544]=820;    data[2291]=-863;
code[2364]=3881;code[630]=2894;code[3618]=54;    data[2842]=820;
code[1926]=3093;code[337]=2047;code[1446]=1554;code[3536]=54;code[642]=2441;code[1766]=2557;code[2236]=3651;code[1915]=3093;code[2205]=3881;code[2403]=9408;code[3066]=2441;code[116]=2291;code[686]=1228;    data[1825]=-3007;
code[3592]=3794;code[2120]=3651;code[1539]=3881;    data[3645]=303;
    data[1607]=0;
    data[3024]=(int[])null;
code[1500]=1218;code[1557]=6983;code[2284]=3850;code[538]=682;code[1611]=1241;    data[517]=2585;
code[1710]=958;code[1977]=3850;code[2997]=8538;    data[3022]=289;
code[3071]=1239;code[2270]=3879;code[1152]=2792;code[1854]=3881;code[575]=2894;code[1030]=3721;code[2340]=1732;code[1570]=3093;    data[2047]=0;
code[2908]=1218;code[1562]=1228;    data[2557]=154;
code[1756]=2744;code[1434]=9408;code[1963]=2695;code[2876]=2842;code[214]=5416;code[578]=3881;code[3172]=2894;code[809]=4757;code[2805]=443;code[2425]=3519;code[1676]=1228;code[1818]=3881;code[644]=1218;code[389]=2047;    data[3918]=247;
    data[2035]=767;
code[1470]=1228;code[534]=300;code[1323]=2155;    data[3300]=68;
code[331]=3024;    data[1554]=55;
    data[3213]=false;
    data[1028]=false;
code[1581]=1228;code[306]=2894;code[1366]=6983;code[3459]=1825;code[2159]=8538;    data[3913]=-262;
code[557]=3024;code[1020]=1506;code[2706]=1732;    data[1529]=1000;
code[754]=9408;    data[1241]=-247;
code[2636]=1607;code[3209]=3881;code[1799]=7328;    data[3673]=-66;
code[2142]=3881;code[2415]=123;code[2477]=1228;code[2448]=3673;code[81]=1529;code[3216]=3416;code[789]=3093;code[2588]=3093;code[213]=2441;    data[54]=904396971;
    data[3416]=-467;
code[3051]=1274;code[2584]=1274;code[2239]=443;code[1351]=443;code[449]=2047;code[2929]=3024;code[2019]=3093;code[1857]=8538;code[2879]=8538;code[1892]=1228;code[1760]=958;code[743]=517;code[1475]=1228;code[810]=443;code[879]=1218;code[1733]=3022;code[3473]=3850;    data[443]=-127;
code[2933]=6000;
    while(true)
    {
    	switch(code[vpc])
    	{
    		case 1274:
    			((int[])data[code[vpc+(4)]])[(int)data[code[vpc+(20)]]] = ((int[])data[code[vpc+(15)]])[(int)data[code[vpc+(-19)]]];
    			vpc+=66;
    			break;
    		case 8538:
    			data[code[vpc+(-3)]]= (int)data[code[vpc+(-17)]]+ (int)data[code[vpc+(29)]];
    			vpc+=54;
    			break;
    		case 5150:
    			data[code[vpc+(29)]]= data[code[vpc+(-6)]];
    			vpc+=64;
    			break;
    		case 7328:
    			data[code[vpc+(-10)]]= (int)data[code[vpc+(19)]];
    			vpc+=58;
    			break;
    		case 4083:
    			data[code[vpc+(-19)]]= (int)data[code[vpc+(-14)]]- (int)data[code[vpc+(11)]];
    			vpc+=68;
    			break;
    		case 2328:
    			data[code[vpc+(23)]]= ((int[])data[code[vpc+(-14)]])[(int)data[code[vpc+(20)]]] <= (int)data[code[vpc+(26)]]&& (int)data[code[vpc+(-8)]]< (int)data[code[vpc+(7)]];
    			vpc+=71;
    			break;
    		case 5416:
    			data[code[vpc+(-1)]]= (int[])(new int[(int)data[code[vpc+(26)]]]);
    			vpc+=63;
    			break;
    		case 2698:
    			((int[])data[code[vpc+(-10)]])[(int)data[code[vpc+(-4)]]] = (int) data[code[vpc+(3)]];
    			vpc+=61;
    			break;
    		case 6845:
    			data[code[vpc+(13)]]= (int)data[code[vpc+(-7)]]<= (int)data[code[vpc+(-8)]];
    			vpc+=66;
    			break;
    		case 6983:
    			data[code[vpc+(6)]]= (int)data[code[vpc+(-15)]]<= ((int[])data[code[vpc+(13)]])[(int)data[code[vpc+(5)]]] && (int)data[code[vpc+(-18)]]< (int)data[code[vpc+(24)]];
    			vpc+=68;
    			break;
    		default:
    			break;
    		case 1677:
    			((int[])data[code[vpc+(-2)]])[(int)data[code[vpc+(-13)]]] = (int)data[code[vpc+(-20)]];
    			vpc+=54;
    			break;
    		case 3850:
    			vpc += (int)data[code[vpc+(-14)]];
    			vpc+=56;
    			break;
    		case 6690:
    			data[code[vpc+(21)]]= (int)data[code[vpc+(8)]]== (int)data[code[vpc+(-1)]];
    			vpc+=72;
    			break;
    		case 6822:
    			data[code[vpc+(7)]]= (string)data[code[vpc+(18)]]+ (bool)data[code[vpc+(-13)]];
    			vpc+=63;
    			break;
    		case 3662:
    			data[code[vpc+(5)]]= ((int[])data[code[vpc+(6)]])[(int)data[code[vpc+(-6)]]] - (int)data[code[vpc+(8)]];
    			vpc+=55;
    			break;
    		case 9408:
    			data[code[vpc+(22)]]=(bool)data[code[vpc+(16)]]?(int)data[code[vpc+(12)]]:(int)data[code[vpc+(-11)]];
    			vpc+=(int)data[code[vpc+(22)]];
    			break;
    		case 6000:
    			((int[])data[code[vpc+(-4)]])[(int)data[code[vpc+(13)]]] = (int)data[code[vpc+(16)]]+ (int)data[code[vpc+(25)]];
    			vpc+=64;
    			break;
    		case 4757:
    			data[code[vpc+(1)]]= ((int[])data[code[vpc+(-20)]])[(int)data[code[vpc+(-2)]]];
    			vpc+=59;
    			break;
    		case 1732:
    			data[code[vpc+(29)]]= (int)data[code[vpc+(24)]]< (int)data[code[vpc+(-5)]];
    			vpc+=63;
    			break;
    		case 3794:
    			return (string)data[code[vpc+(26)]];
    			vpc+=66;
    	}
    }

    return null;
}

        


        public static string Time_Operation(string id, int runId, Func<int[], int, int, string> method, int[] elements, int warmup, int iterations)
        {

            int op = 0;
            string log = runId + " warming ... " + warmup + "  times X elements " + elements.Length;
            Output(log);

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < warmup && runId < 1; i++)
            {
                int[] unsorted_original = data.ToArray();
                method(unsorted_original, 0, unsorted_original.Length-1);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("       {0}    , sec", timespan.TotalSeconds);
            log = id + " " + runId + " warmed up in, " + time;
            Output(log);
            time_warmup.Add(log);

            log = runId + " running ... " + iterations + "  times X elements " + elements.Length;
            Output(log);
            timer = Stopwatch.StartNew();
            for (int j = 0; j < iterations; j++)
            {
                int[] unsorted_original = data.ToArray();
                method(unsorted_original, 0, unsorted_original.Length - 1);
            }
            timer.Stop();
            timespan = timer.Elapsed;

            time = String.Format("      {0}   , sec", timespan.TotalSeconds);
            log = id + " " + runId + "    finished in,   " + time;
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