using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortIterative_class_default
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> data;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            QuickSortIterative_class_default lt = new QuickSortIterative_class_default();
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
//            //            lt.ForSimple_Check();
//            int ELEMENTS = 350;
//            // Create an unsorted array of string elements
//            string[] testData = GenerateData(ELEMENTS);
//            var int_list = new List<int>();
//            foreach (var r in testData)
//            {
//                var value = Int32.Parse(r);
//                int_list.Add(value);
//            }
//            int[] unsorted_obfuscated = int_list.ToArray();
            

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
                int[] unsorted_original = data.ToArray();
                Console.WriteLine(i + " ##############");
                Debug.WriteLine(i+" ##############");
                string t_original = Time_Operation("QuickSortIterative_class_default", i, QuickSort_Iterative_class_default, unsorted_original, WARMUP, ITERATIONS);
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
            QuickSort_Iterative_class_default(unsorted_obfuscated, unsorted_obfuscated.Length, -1);

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



//        [Obfuscation(Exclude = false, Feature = "virtualization; class")]
string QuickSort_Iterative_class_default(int[] arr, int length, int right)
{
    //Virtualization variables
    int[] code = new int[100512];
    object[] data = new object[4760];
    int vpc = 53;

    code[94469]=-501;code[54452]=-950;code[88212]=811;code[26949]=555;code[92436]=-920;code[29545]=1318;
    code[25328]=64;code[20423]=1431;code[18098]=860;code[5574]=962;code[80616]=-305;code[6749]=948;
    code[75413]=-917;code[41462]=492;code[16089]=6;code[16197]=-766;code[63034]=-425;code[6471]=728;
    code[2124]=751;code[50427]=750;code[15461]=-931;code[40277]=98;code[80466]=720;code[90487]=986;
    code[4170]=639;code[81460]=1302;code[33197]=1034;code[39093]=654;code[13346]=906;code[27133]=1111;
    code[31348]=677;code[46449]=292;code[87547]=-500;code[30185]=-946;code[36323]=279;code[95650]=198;
    code[24374]=-113;code[63453]=936;code[88203]=569;code[98370]=-845;code[13360]=544;code[55854]=260;
    code[59513]=-400;code[76731]=1033;code[84564]=6;code[56157]=-354;code[43300]=643;code[39038]=207;
    code[56840]=1209;code[57129]=500;code[38967]=1196;code[43559]=324;code[70772]=-173;code[68194]=1437;
    code[18337]=536;code[78807]=262;code[78777]=-481;code[71514]=735;code[11580]=1394;code[92970]=577;
    code[43906]=217;code[18128]=1396;code[95784]=732;code[4875]=463;code[97170]=-629;code[20996]=1484;
    code[5965]=-55;code[67803]=-365;code[18531]=-936;code[80428]=-348;code[56454]=970;code[63415]=-433;
    code[62185]=-866;code[47731]=-443;code[95059]=735;code[36956]=519;code[96355]=1343;code[16432]=1251;
    code[70176]=186;code[57976]=-973;code[28409]=-767;code[840]=-915;code[40771]=975;code[44796]=13;
    code[53581]=142;code[51237]=-777;code[15842]=660;code[6953]=621;code[86038]=1383;code[34165]=1248;
    code[21920]=1063;code[64274]=-319;code[78470]=502;code[3543]=-696;code[21598]=934;code[55900]=774;
    code[45138]=972;code[98331]=171;code[78391]=492;code[82536]=1071;code[61109]=-827;code[69356]=221;
    code[18543]=-305;code[45237]=-264;code[87277]=287;code[4497]=861;code[13553]=693;code[79711]=143;
    code[45607]=839;code[25462]=1011;code[75876]=-191;code[19148]=898;code[90558]=1000;code[64349]=-79;
    code[68920]=501;code[87305]=-353;code[13306]=278;code[29279]=-629;code[13603]=-623;code[8846]=255;
    code[15188]=851;code[25478]=749;code[73281]=1028;code[57770]=928;code[100108]=302;code[1475]=-890;
    code[34531]=-959;code[7400]=-290;code[88348]=1326;code[59062]=-40;code[64141]=-797;code[61205]=-332;
    code[64963]=964;code[61538]=558;code[38817]=611;code[32357]=-243;code[65115]=877;code[65667]=-965;
    code[7072]=226;code[3032]=-777;code[22654]=1171;code[37448]=-589;code[58906]=1061;code[92024]=-711;
    code[43999]=-983;code[27097]=-489;code[56612]=759;code[86859]=-826;code[13233]=1464;code[5387]=1358;
    code[20028]=1378;code[38733]=-122;code[20013]=779;code[39825]=481;code[36523]=-852;code[21486]=-29;
    code[90521]=245;code[15974]=923;code[71254]=110;code[68500]=1054;code[87450]=241;code[18664]=-53;
    code[37679]=-707;code[74342]=1360;code[89134]=459;code[88715]=-789;code[43920]=-784;code[89474]=-315;
    code[48575]=-948;code[97047]=1185;code[43050]=-193;code[75613]=-54;code[79745]=1202;code[30549]=-838;
    code[54753]=-764;code[36251]=718;code[30592]=-421;code[7377]=756;code[76952]=-985;code[98163]=-796;
    code[97710]=130;code[70935]=949;code[17757]=-677;code[95631]=1034;code[61106]=1212;code[28768]=719;
    code[48119]=1018;code[39547]=367;code[74810]=1018;code[58862]=234;code[81758]=686;code[40144]=980;
    code[22419]=-512;code[78407]=-488;code[1336]=-532;code[51107]=192;code[4464]=1209;code[90675]=1440;
    code[62040]=1431;code[20278]=660;code[93447]=225;code[45945]=649;code[81258]=682;code[20968]=242;
    code[84264]=315;code[96327]=1395;code[42284]=207;code[26968]=-257;code[5293]=1284;code[55943]=1453;
    code[35100]=865;code[80470]=51;code[37830]=1023;code[64673]=487;code[90972]=43;code[93456]=929;
    code[60860]=1303;code[56686]=-192;code[21855]=848;code[98871]=375;code[99170]=-293;code[36866]=217;
    code[23030]=375;code[5653]=403;code[61862]=511;code[92830]=759;code[41817]=-450;code[31647]=-542;
    code[69293]=-909;code[28497]=1497;code[2951]=534;code[59505]=52;code[59957]=-534;code[35463]=247;
    code[92364]=1362;code[8053]=-218;code[93466]=-985;code[99982]=-835;code[38145]=-216;code[19227]=1065;
    code[75687]=-796;code[98447]=-249;code[49615]=-435;code[35742]=-38;code[60978]=-49;code[63722]=-549;
    code[45830]=1461;code[52354]=-68;code[69446]=1364;code[89498]=-894;code[19830]=392;code[64581]=676;
    code[52712]=526;code[77768]=24;code[22677]=-379;code[80801]=-61;code[84969]=143;code[24741]=1368;
    code[63744]=-272;code[93225]=-75;code[83536]=1419;code[89702]=345;code[31251]=1248;code[86156]=1363;
    code[48794]=554;code[37724]=84;code[42538]=-628;code[63216]=-511;code[44167]=-228;code[78004]=1208;
    code[45474]=1364;code[16034]=-105;code[57959]=-355;code[33709]=1496;code[74212]=433;code[74256]=-2;
    code[1821]=300;code[21237]=-426;code[66803]=-740;code[36147]=562;code[75708]=1070;code[92897]=509;
    code[87774]=-75;code[95740]=741;code[83255]=-875;code[51057]=-187;code[51805]=-890;code[92262]=1213;
    code[81228]=335;code[96665]=-869;code[56685]=1146;code[20810]=1279;code[88746]=1439;code[41787]=1257;
    code[94238]=-2;code[53399]=-162;code[95411]=-623;code[13064]=560;code[2176]=389;code[48727]=-484;
    code[30724]=597;code[17125]=720;code[6584]=33;code[88853]=1434;code[60520]=-185;code[42361]=-675;
    code[14312]=-233;code[6141]=1236;code[62445]=-970;code[72460]=1243;code[95916]=-877;code[76277]=72;
    code[52160]=-569;code[37795]=-89;code[91900]=-266;code[86798]=-369;code[4984]=887;code[75084]=1312;
    code[69162]=297;code[85079]=173;code[9235]=104;code[30256]=528;code[98287]=2;code[19387]=605;
    code[9035]=-412;code[284]=-977;code[83899]=468;code[25361]=-360;code[88449]=853;code[17003]=1232;
    code[3764]=298;code[5978]=-230;code[46486]=-578;code[8106]=-32;code[56275]=-660;code[20769]=-745;
    code[16664]=-372;code[80961]=280;code[75217]=-632;code[45340]=-706;code[98480]=834;code[27592]=697;
    code[29248]=1135;code[41991]=155;code[50536]=226;code[4531]=1366;code[35154]=1384;code[43421]=430;
    code[38440]=1481;code[14978]=1022;code[32202]=1014;code[8285]=1384;code[2873]=1251;code[84789]=458;
    code[78589]=849;code[51053]=831;code[29178]=-872;code[91769]=-241;code[24632]=-50;code[1739]=520;
    code[75501]=546;code[88899]=-828;code[9140]=-351;code[75643]=-470;code[82365]=-417;code[13056]=889;
    code[100345]=605;code[80160]=-565;code[65459]=-199;code[65383]=-24;code[1065]=1086;code[68375]=907;
    code[98781]=-219;code[65975]=-254;code[4083]=-680;code[32888]=-995;code[98040]=351;code[5804]=754;
    code[92584]=-967;code[86734]=921;code[14865]=578;code[76770]=371;code[61319]=880;code[73802]=620;
    code[25501]=847;code[65582]=1311;code[73360]=566;code[60076]=1291;code[94297]=-696;code[8680]=946;
    code[60661]=135;code[17239]=728;code[91063]=-681;code[78419]=144;code[58741]=-761;code[25433]=594;
    code[46005]=1204;code[24385]=-53;code[7107]=-672;code[15351]=-424;code[58113]=-980;code[4502]=-246;
    code[47819]=6;code[27359]=-129;code[94782]=-648;code[76763]=998;code[93164]=-789;code[16597]=734;
    code[46227]=-819;code[64596]=205;code[97706]=-309;code[6402]=-605;code[48829]=-964;code[46909]=1120;
    code[38613]=-454;code[85027]=1016;code[97387]=1139;code[20132]=488;code[41137]=1174;code[21655]=258;
    code[85999]=78;code[51726]=108;code[33357]=133;code[71471]=-67;code[72038]=371;code[92394]=1495;
    code[49141]=676;code[25970]=-247;code[94939]=1216;code[82013]=153;code[94085]=60;code[96938]=811;
    code[29663]=1392;code[83479]=-823;code[88866]=424;code[28599]=475;code[86150]=-652;code[62983]=351;
    code[76588]=550;code[83044]=-920;code[30497]=-767;code[13196]=1088;code[30082]=1119;code[31929]=-254;
    code[60055]=1246;code[65400]=306;code[5404]=885;code[57004]=78;code[46951]=975;code[14897]=-64;
    code[62618]=600;code[49161]=-633;code[26560]=-178;code[14172]=-127;code[4406]=794;code[54230]=-190;
    code[6078]=959;code[15864]=1106;code[29438]=-678;code[42734]=118;code[64275]=330;code[47594]=1463;
    code[92388]=904;code[53914]=-743;code[57522]=-513;code[7376]=1429;code[47455]=128;code[41133]=658;
    code[60740]=1461;code[57403]=1425;code[71042]=1420;code[25590]=1199;code[36103]=-184;code[46447]=-325;
    code[59940]=811;code[13925]=-155;code[36687]=752;code[73900]=-773;code[16737]=259;code[22882]=255;
    code[79671]=-905;code[78112]=1121;code[64776]=419;code[85642]=522;code[37638]=236;code[23952]=-229;
    code[56080]=137;code[74427]=678;code[27891]=484;code[62939]=481;code[30137]=-335;code[50915]=1119;
    code[5693]=838;code[60991]=928;code[71990]=-205;code[49939]=-749;code[76064]=-828;code[17847]=671;
    code[19202]=14;code[23636]=978;code[47681]=1132;code[90016]=-746;    data[252]=-360;
    data[3672]=false;
code[2873]=1785;code[1734]=9570;    data[389]=-203;
code[3220]=629;    data[2127]=924;
    data[272]=540;
code[1198]=1489;code[2813]=3258;code[888]=3736;    data[3185]=-124;
    data[3942]=-546;
code[182]=1725;code[2476]=2129;code[1699]=2556;    data[2556]=427;
    data[3036]=672;
code[480]=1642;    data[871]=-568;
code[979]=3819;code[385]=1861;    data[1559]=1485;
code[3439]=3460;code[2954]=3254;    data[3126]=-301;
code[2968]=2858;code[2482]=3456;code[3214]=2284;code[2340]=3819;code[238]=2858;code[3469]=608;code[3327]=1234;    data[1134]=449;
code[1637]=1818;code[2361]=890;code[1723]=2428;    data[2311]=806;
code[2325]=1542;    data[477]=281;
    data[1228]=913;
code[687]=794;code[2047]=3819;    data[1790]="" ;
code[912]=2238;code[1433]=1734;    data[1552]=-638;
    data[71]=147;
code[2252]=2332;code[627]=2980;code[2757]=785;    data[828]=-673;
code[1879]=3741;    data[1550]=-240;
    data[2897]=-965;
    data[310]=false;
code[2236]=2284;code[1003]=75;    data[3265]=-500;
code[2171]=816;code[1593]=3823;code[3055]=2858;    data[3353]=-2940;
code[1038]=4049;code[1271]=359;code[1415]=2097;code[2536]=1107;code[1481]=785;    data[1625]=404;
code[788]=3741;    data[382]=-348;
code[3057]=2369;    data[1889]=-468;
code[2589]=1541;code[1674]=999;    data[2907]=974;
    data[3565]=-517;
code[1113]=408;code[1569]=446;code[368]=66;    data[1381]=-586;
    data[3520]=false;
code[2758]=2854;code[2798]=5326;    data[783]=873;
code[2033]=3053;code[2799]=2858;    data[3590]=-591;
    data[1209]=-710;
code[860]=2495;    data[1015]=-311;
    data[985]=-758;
code[1571]=2284;code[2973]=2814;    data[2502]=-592;
code[593]=2858;    data[3375]=-189;
    data[1175]=239;
    data[3127]=988;
code[1461]=627;    data[1703]=512;
    data[1751]=-937;
code[2689]=2284;code[2717]=870;code[2279]=3247;code[675]=1291;code[2740]=1742;code[3319]=9964;code[1051]=1790;    data[3366]=880;
code[1091]=6387;code[2328]=3739;code[2639]=3362;code[886]=2311;code[1255]=3819;code[3478]=6387;code[267]=2909;    data[1584]=774;
    data[166]=141;
    data[845]=-246;
code[2636]=6594;code[125]=432;    data[3956]=-295;
code[313]=2909;    data[2773]=297;
code[2984]=2316;    data[1177]=992;
code[305]=1785;code[3421]=1883;code[2487]=3147;code[1954]=794;code[1729]=458;code[2180]=785;    data[3198]=91;
code[3212]=1030;    data[1276]=-861;
code[1151]=2284;code[3330]=2170;code[1213]=2171;code[883]=3305;    data[2517]=343;
code[2151]=1095;code[1802]=3502;code[3248]=3871;code[1640]=1201;    data[1191]=-487;
code[1660]=2773;code[2875]=3871;code[914]=9539;code[1314]=1912;    data[3604]=0;
code[1333]=1828;code[1843]=3616;code[3372]=3353;code[613]=7988;code[2415]=3147;code[434]=2858;code[3411]=3603;    data[1145]=641;
code[1512]=3741;code[802]=1044;    data[75]=-358;
    data[2731]=-961;
code[2853]=7686;code[2932]=3871;code[862]=3391;    data[3843]=59;
    data[2905]=236;
    data[2753]=-130;
code[2248]=3494;    data[2251]=227;
    data[837]=739;
    data[3147]=-364;
code[1428]=3871;code[1190]=2675;code[740]=32;code[1991]=785;code[2608]=237;code[1029]=989;code[3127]=2248;code[2998]=27;code[619]=2310;    data[1234]=false;
    data[2813]=-733;
    data[3474]=150;
    data[1894]=729;
    data[1310]=-83;
    data[1304]=right;
    data[2858]=-455;
code[139]=413;code[1522]=794;code[1033]=2603;code[1873]=1079;code[2441]=848;code[2394]=998;code[2880]=3258;    data[293]=106;
    data[3699]=59;
code[542]=2210;    data[1235]=-87;
    data[803]=787;
code[2121]=794;    data[3330]=399;
    data[1003]=59;
code[1494]=3520;code[2287]=6594;code[2698]=3689;code[607]=27;    data[3163]=633;
    data[1347]=-746;
code[3446]=1572;code[756]=803;code[2585]=2284;    data[804]=2533;
code[430]=9964;    data[3812]=974;
    data[564]=407;
    data[3301]=-255;
code[909]=2195;code[318]=2909;    data[86]=-896;
code[843]=3871;code[2032]=652;    data[3122]=-347;
code[3425]=4049;    data[2280]=223;
code[3049]=3542;code[3481]=1281;code[455]=2909;code[308]=125;code[2583]=1088;code[537]=794;code[2165]=3147;    data[978]=-553;
code[1056]=1537;code[2764]=3881;    data[1967]=127;
code[3392]=3470;code[81]=786;code[2276]=2739;code[3169]=256;    data[27]=(int[])null;
code[2412]=3274;    data[922]=215;
code[145]=2311;code[2876]=2685;    data[330]=436;
    data[1438]=885;
code[2339]=310;code[3431]=2394;    data[999]=false;
code[2484]=3147;    data[370]=-387;
code[3502]=17;code[1296]=785;    data[3738]=-159;
code[1445]=2495;code[964]=2280;code[1330]=3147;code[2488]=3670;    data[518]=-201;
code[105]=1133;code[1643]=3147;code[1982]=816;code[76]=1878;code[1953]=794;    data[242]=-636;
    data[3460]=1757590734;
code[712]=538;code[2942]=659;    data[2687]=59;
    data[3053]=59;
code[127]=1785;code[239]=5107;code[2461]=2495;code[3109]=1894;code[790]=3157;    data[2367]=964;
    data[1449]=-852;
    data[773]=-502;
code[3112]=2598;code[1468]=3147;    data[2395]=324;
code[3362]=1356;code[971]=1744;code[2687]=322;code[1386]=3819;    data[990]=-771;
code[706]=2284;code[2997]=27;code[2787]=2830;    data[2814]=-704;
code[3173]=794;    data[68]=-190;
code[2357]=1035;        data[3741]=(int[])arr;
    data[1332]=401;
    data[2588]=842;
    data[3617]=-600;
code[1393]=1413;    data[652]=240;
code[731]=1291;    data[1620]=429;
code[1327]=3741;    data[2985]=-866;
code[2816]=3871;code[2803]=1492;code[371]=2909;code[1309]=3520;code[1994]=3741;    data[1030]=54;
code[2965]=105;    data[1687]=-579;
    data[3828]=380;
code[3479]=1517;code[3102]=2858;    data[3790]=-861;
    data[1686]=-774;
code[2514]=794;code[2507]=2766;code[3172]=27;    data[3032]=638;
code[783]=3506;code[2183]=3741;code[534]=2692;    data[1385]=-341;
code[1471]=3147;code[1389]=2524;    data[3572]=945;
    data[747]=519;
code[1589]=2998;code[2657]=3147;    data[3469]=0;
code[925]=3305;code[2677]=2553;code[3344]=2909;    data[404]=-714;
    data[2492]=103;
code[723]=2050;code[2176]=3243;    data[3852]=-823;
code[531]=2858;code[1998]=180;code[1972]=6046;    data[287]=953;
code[1261]=3544;    data[3830]=322;
    data[737]=-676;
code[2326]=2230;    data[3912]=-258;
code[1622]=6594;    data[816]=false;
code[2929]=2814;code[2124]=3871;code[3156]=1742;code[3275]=1138;    data[3543]=584;
code[1462]=1397;code[732]=3819;    data[2920]=755;
    data[1763]=-991;
    data[1176]=-492;
code[2420]=3907;code[3436]=741;    data[446]=-236;
code[1099]=965;    data[2141]=-55;
    data[3881]=47;
code[1662]=905;code[180]=1685;code[1279]=389;code[485]=3819;code[484]=1234;code[1093]=2835;    data[1183]=-130;
code[1052]=204;code[388]=27;code[509]=2907;code[3119]=3871;code[498]=613;    data[3597]=54;
code[2106]=5326;code[1515]=3147;    data[1920]=-340;
code[2651]=391;code[969]=2916;code[2756]=3741;code[2739]=794;    data[311]=283;
    data[3808]=7;
    data[856]=418;
code[3323]=2858;code[438]=1234;    data[296]=137;
    data[2081]=-13;
    data[392]=296;
    data[1899]=463;
code[2248]=1865;code[294]=2492;code[2399]=9570;    data[1719]=-483;
code[228]=373;code[1618]=999;code[1491]=3426;    data[3080]=-294;
    data[1548]=309;
code[1332]=1882;    data[2230]=59;
code[1089]=204;    data[90]=113;
code[186]=27;code[1385]=3520;code[3476]=3460;code[389]=3594;    data[3170]=-725;
    data[171]=-594;
    data[3974]=909;
code[679]=6594;code[2726]=3834;code[46]=3093;code[1241]=565;code[2256]=1993;code[1851]=3261;code[3155]=2367;    data[3640]=-368;
code[53]=5107;    data[2459]=741;
code[54]=3854;code[3167]=542;    data[785]=326;
code[3288]=2858;code[550]=886;    data[162]=-764;
    data[794]=-736;
    data[2252]=-479;
code[2919]=2183;    data[2737]=-186;
    data[1575]=-5;
code[1473]=1247;code[784]=785;code[2382]=1378;    data[498]=-753;
    data[798]=634;
    data[2468]=971;
code[1750]=794;code[682]=1773;code[204]=2311;code[2632]=1489;code[1499]=1912;    data[2965]=-767;
code[2143]=794;code[978]=2195;    data[2532]=404;
code[2846]=1787;    data[1676]=703;
    data[565]=59;
    data[3494]=536;
    data[665]=-361;
    data[1611]=-846;
code[3157]=3291;code[3380]=3127;    data[2909]=0;
code[2444]=3871;code[2812]=3997;code[778]=794;code[2393]=162;    data[786]=1000;
code[3085]=2913;code[1814]=3871;code[697]=366;    data[2475]=687;
    data[1354]=-762;
code[1372]=3699;code[2515]=3261;code[2107]=794;code[2234]=1550;code[3112]=980;code[471]=1003;code[1630]=794;    data[204]=1088760766;
    data[2686]=-595;
    data[239]=-649;
code[1684]=3075;code[147]=3790;code[2161]=6046;    data[3327]=-42;
    data[247]=-19;
    data[2595]=-702;
code[2293]=380;code[635]=3871;code[965]=484;code[1223]=3147;code[2142]=794;    data[3631]=762;
code[3223]=1164;code[1202]=6594;    data[451]=174;
code[2308]=3147;code[2482]=2267;    data[2296]=330;
code[326]=2002;    data[1267]=122;
code[2837]=1230;code[1880]=3741;    data[2231]=-716;
code[1173]=3670;code[700]=3147;    data[1489]=false;
code[3101]=5326;    data[378]=780;
    data[1657]=2940;
code[718]=2687;code[1641]=71;code[109]=317;code[1150]=2066;code[1855]=3263;code[372]=1742;    data[3651]=-518;
code[3291]=2858;    data[2208]=-880;
    data[3862]=-871;
code[1811]=794;code[331]=640;code[3374]=2284;    data[602]=-619;
code[2501]=147;code[3183]=3945;code[1210]=794;    data[622]=146;
    data[472]=377;
code[1796]=5326;    data[40]=-317;
    data[1865]=67;
code[1838]=3754;    data[322]=-1485;
code[1039]=2896;    data[3642]=-150;
code[1102]=2941;    data[1502]=271;
    data[3756]=18;
code[69]=3865;    data[167]=-155;
    data[3379]=352;
code[2040]=464;code[1034]=3672;    data[562]=595;
code[817]=1584;    data[3688]=-161;
code[2644]=794;code[2418]=3199;code[3039]=9570;    data[3630]=-605;
code[1797]=794;    data[3840]=-867;
    data[484]=59;
    data[2571]=852;
code[1337]=794;code[2538]=3504;code[2519]=162;code[1371]=2905;code[3201]=2179;    data[1641]=-931;
code[2850]=3687;code[1924]=157;code[597]=3147;    data[2066]=758;
    data[1500]=-392;
code[1728]=3263;    data[1785]=(int[])null;
    data[3594]=length;
code[1921]=2284;    data[1849]=-199;
code[2283]=310;code[2908]=2879;code[3394]=3462;    data[3263]=-855;
    data[1448]=963;
    data[3258]=561;
code[541]=1785;code[1698]=1497;    data[879]=156;
    data[3798]=739;
code[2817]=656;code[760]=2949;code[1467]=2130;code[1629]=369;    data[1917]=-707;
code[52]=2311;    data[3433]=888;
code[2543]=3741;code[1976]=3147;code[2915]=2858;    data[2524]=35;
code[2122]=3966;    data[1088]=0;
    data[3613]=58;
code[2969]=3261;code[1240]=1559;code[1149]=3469;    data[1542]=296;
    data[1883]=true;
    data[1291]=false;
code[3033]=2367;code[717]=804;code[1850]=3147;    data[2592]=357;
    data[415]=-201;
    data[536]=-810;
code[2752]=859;code[1254]=1489;code[3116]=2858;    data[3305]=-244;
code[1295]=3147;code[2111]=1913;code[1661]=3843;code[864]=2833;code[791]=8811;    data[124]=137;
    data[3871]=1;
code[2914]=5326;    data[2898]=330;
    data[117]=164;
code[1998]=1973;code[2158]=3535;code[2498]=1231;    data[178]=8;
code[3438]=1790;code[2071]=3798;code[2544]=3741;code[2046]=816;code[398]=738;code[1675]=3819;code[922]=2858;    data[369]=-12;
code[1410]=3640;code[307]=7964;    data[2067]=372;
    data[2195]=false;
code[3265]=2495;code[2425]=1862;code[1919]=3604;code[2858]=794;code[1916]=3043;code[1480]=3147;code[2237]=1894;code[3491]=3961;code[1977]=1195;code[2364]=3330;code[444]=466;code[544]=8811;code[3373]=2953;code[456]=2401;code[121]=1685;code[1743]=3874;    data[2250]=-636;
code[2295]=794;code[241]=11;code[470]=1657;code[1943]=3566;code[2097]=1965;    data[1049]=-277;
code[3068]=2145;
    return (string)InstanceInterpreterVirtualization_QuickSortIterative_class_default_1884(vpc, data, code);

}

        


        public static string Time_Operation(string id, int runId, Func<int[], int, int, string> method, int[] elements, int warmup, int iterations)
        {

            int op = 0;
            string log = runId + " warming ... " + warmup + " times X elements " + elements.Length;
            Output(log);

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < warmup && runId < 1; i++)
            {
                int[] unsorted_original = data.ToArray();
                method(unsorted_original, 0, unsorted_original.Length-1);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("   {0}     , sec", timespan.TotalSeconds);
            log = id + " " + runId + " warmed up in,      " + time;
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

private object InstanceInterpreterVirtualization_QuickSortIterative_class_default_1884(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 2495:
                data[code[vpc + (23)]] = (int)data[code[vpc + (26)]] - (int)data[code[vpc + (-17)]];
                vpc += 54;
                break;
            case 4049:
                data[code[vpc + (14)]] = (string)data[code[vpc + (13)]] + (bool)data[code[vpc + (-4)]];
                vpc += 53;
                break;
            case 8811:
                data[code[vpc + (-7)]] = ((int[])data[code[vpc + (-3)]])[(int)data[code[vpc + (-13)]]];
                vpc += 69;
                break;
            case 7686:
                ((int[])data[code[vpc + (20)]])[(int)data[code[vpc + (27)]]] = (int)data[code[vpc + (5)]] + (int)data[code[vpc + (22)]];
                vpc += 61;
                break;
            case 9570:
                data[code[vpc + (-6)]] = (int)data[code[vpc + (16)]];
                vpc += 62;
                break;
            case 5326:
                data[code[vpc + (15)]] = (int)data[code[vpc + (1)]] + (int)data[code[vpc + (18)]];
                vpc += 55;
                break;
            case 6594:
                data[code[vpc + (-4)]] = (int)data[code[vpc + (8)]] < (int)data[code[vpc + (21)]];
                vpc += 53;
                break;
            case 7988:
                data[code[vpc + (-16)]] = ((int[])data[code[vpc + (-6)]])[(int)data[code[vpc + (-20)]]] - (int)data[code[vpc + (22)]];
                vpc += 66;
                break;
            case 7964:
                ((int[])data[code[vpc + (-2)]])[(int)data[code[vpc + (11)]]] = (int) data[code[vpc + (6)]];
                vpc += 65;
                break;
            case 1742:
                ((int[])data[code[vpc + (16)]])[(int)data[code[vpc + (-1)]]] = (int)data[code[vpc + (17)]];
                vpc += 58;
                break;
            case 6387:
                return (string)data[code[vpc + (-2)]];
                vpc += 60;
            case 6046:
                data[code[vpc + (10)]] = ((int[])data[code[vpc + (22)]])[(int)data[code[vpc + (-18)]]] <= (int)data[code[vpc + (19)]] && (int)data[code[vpc + (-19)]] < (int)data[code[vpc + (4)]];
                vpc += 75;
                break;
            case 9964:
                data[code[vpc + (8)]] = (int)data[code[vpc + (25)]] <= (int)data[code[vpc + (4)]];
                vpc += 55;
                break;
            case 9539:
                data[code[vpc + (-5)]] = (int)data[code[vpc + (8)]] == (int)data[code[vpc + (11)]];
                vpc += 65;
                break;
            case 1912:
                data[code[vpc + (-5)]] = (int)data[code[vpc + (-18)]] <= ((int[])data[code[vpc + (13)]])[(int)data[code[vpc + (-19)]]] && (int)data[code[vpc + (23)]] < (int)data[code[vpc + (16)]];
                vpc += 72;
                break;
            case 1685:
                data[code[vpc + (6)]] = (int[])(new int[(int)data[code[vpc + (24)]]]);
                vpc += 59;
                break;
            case 3261:
                ((int[])data[code[vpc + (28)]])[(int)data[code[vpc + (4)]]] = ((int[])data[code[vpc + (29)]])[(int)data[code[vpc + (-1)]]];
                vpc += 70;
                break;
            case 2284:
                vpc += (int)data[code[vpc + (-2)]];
                vpc += 51;
                break;
            default:
                data[code[vpc + (24)]] = (bool)data[code[vpc + (-1)]] ? (int)data[code[vpc + (-14)]] : (int)data[code[vpc + (-15)]];
                vpc += (int)data[code[vpc + (24)]];
                break;
            case 5107:
                data[code[vpc + (-1)]] = data[code[vpc + (28)]];
                vpc += 68;
                break;
        }
    }

    return null;
}


    }
}