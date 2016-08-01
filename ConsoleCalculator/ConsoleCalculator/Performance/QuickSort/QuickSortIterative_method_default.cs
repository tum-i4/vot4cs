using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortIterative_method_default
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> data;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            QuickSortIterative_method_default lt = new QuickSortIterative_method_default();
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

            Output("##################");
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
                Console.WriteLine(i + "##############");
                Debug.WriteLine(i + "##############");
                string t_original = Time_Operation("QuickSortIterative_method_default", i, QuickSort_Iterative_method_default, unsorted_original, WARMUP, ITERATIONS);
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
            QuickSort_Iterative_method_default(unsorted_obfuscated, unsorted_obfuscated.Length, -1);

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
string QuickSort_Iterative_method_default(int[] arr, int length, int right)
{
    //Virtualization variables
    int[] code = new int[100528];
    object[] data = new object[4465];
    int vpc = 90;

    code[84350]=-966;code[79874]=-250;code[40004]=-804;code[4821]=1101;code[87164]=1373;code[3534]=-933;
    code[78034]=-667;code[59633]=637;code[28916]=1159;code[61155]=870;code[26439]=1231;code[84830]=90;
    code[62419]=205;code[18369]=309;code[15225]=1095;code[85937]=687;code[33231]=-704;code[69280]=-484;
    code[80214]=958;code[33603]=373;code[38024]=-538;code[35553]=1275;code[75831]=1479;code[34473]=-257;
    code[65834]=-909;code[45390]=-896;code[34935]=-151;code[66203]=1365;code[17071]=-105;code[68297]=1288;
    code[90071]=310;code[69270]=-929;code[9509]=-100;code[70020]=644;code[44639]=-34;code[86141]=260;
    code[53234]=-853;code[37185]=-805;code[54185]=1334;code[68563]=572;code[14018]=1213;code[87338]=-713;
    code[38879]=1032;code[32924]=1477;code[46225]=856;code[3697]=99;code[10467]=46;code[65681]=1134;
    code[49848]=-188;code[81977]=-15;code[29679]=712;code[85767]=-330;code[18054]=1368;code[51489]=-279;
    code[97496]=451;code[40952]=-410;code[67969]=-875;code[78021]=-974;code[65891]=435;code[64541]=-297;
    code[3277]=764;code[19906]=753;code[35166]=42;code[40211]=-723;code[40775]=289;code[58525]=-465;
    code[11892]=-281;code[33567]=135;code[3249]=501;code[94029]=98;code[30251]=-903;code[2107]=1198;
    code[33717]=1001;code[76765]=-866;code[64595]=607;code[19957]=1304;code[68645]=335;code[36351]=473;
    code[48961]=-621;code[92331]=906;code[55027]=3;code[88757]=134;code[100358]=-517;code[11835]=-30;
    code[72009]=-196;code[98332]=-863;code[64211]=-494;code[98571]=1484;code[68836]=-204;code[36779]=372;
    code[65694]=-135;code[47075]=906;code[31905]=651;code[53407]=460;code[93109]=861;code[97242]=1201;
    code[68563]=-568;code[89667]=1248;code[15689]=417;code[88564]=-645;code[68661]=-62;code[33934]=-198;
    code[66821]=-642;code[28450]=200;code[55636]=-81;code[90952]=-580;code[79018]=-77;code[10953]=-497;
    code[93797]=-700;code[13727]=-156;code[66545]=333;code[46453]=1429;code[35628]=-756;code[37487]=164;
    code[31233]=-798;code[84196]=-706;code[43999]=-441;code[87062]=-305;code[859]=-632;code[9853]=-566;
    code[37939]=-873;code[3101]=395;code[84407]=997;code[9487]=-219;code[6427]=726;code[97162]=-911;
    code[43273]=357;code[48271]=-627;code[91802]=-86;code[97149]=417;code[77472]=1042;code[17038]=181;
    code[53324]=967;code[73452]=405;code[50598]=1076;code[19374]=963;code[2228]=1406;code[96555]=527;
    code[50522]=1259;code[13295]=388;code[339]=-850;code[40402]=549;code[11503]=1004;code[69090]=1236;
    code[74743]=791;code[36689]=607;code[18201]=327;code[40525]=400;code[88624]=395;code[2791]=-869;
    code[6864]=330;code[81356]=-418;code[50059]=-548;code[1379]=169;code[58567]=1173;code[65041]=-977;
    code[23462]=27;code[56655]=775;code[41744]=373;code[35994]=821;code[10025]=1090;code[82313]=967;
    code[46825]=374;code[60771]=227;code[56257]=0;code[73312]=1360;code[88072]=-801;code[48974]=178;
    code[25229]=-579;code[12266]=1333;code[79209]=-452;code[31362]=1185;code[6983]=-111;code[41165]=925;
    code[97256]=731;code[14574]=-170;code[20137]=-253;code[95793]=-420;code[71697]=-944;code[77140]=1370;
    code[57944]=306;code[91286]=-545;code[14076]=757;code[13392]=-616;code[92864]=-770;code[46183]=-384;
    code[42973]=61;code[94579]=1200;code[52687]=1361;code[72116]=-725;code[14106]=1086;code[52639]=1167;
    code[25662]=-8;code[74780]=442;code[12737]=-363;code[76211]=-429;code[40349]=-566;code[35896]=-337;
    code[31313]=-676;code[73804]=-84;code[22358]=-361;code[85080]=1188;code[23455]=1246;code[90938]=939;
    code[36003]=-819;code[71180]=921;code[30666]=642;code[81207]=854;code[100424]=-898;code[93194]=857;
    code[96396]=390;code[2721]=671;code[33588]=-423;code[84958]=-366;code[6783]=688;code[57166]=-14;
    code[21154]=-124;code[89243]=1211;code[99328]=621;code[63689]=-108;code[49515]=1420;code[22012]=-866;
    code[54979]=1473;code[92833]=860;code[36798]=537;code[26775]=-325;code[20364]=1478;code[40989]=665;
    code[22984]=-557;code[54394]=-994;code[5361]=627;code[71200]=706;code[50674]=-217;code[56111]=1385;
    code[77349]=1308;code[75787]=-124;code[40978]=425;code[25160]=1476;code[33890]=1432;code[12252]=-139;
    code[30902]=-748;code[89223]=130;code[41132]=-255;code[19291]=-453;code[94794]=-447;code[65941]=1026;
    code[10788]=577;code[30508]=1103;code[26123]=340;code[55276]=-417;code[43360]=1422;code[97988]=107;
    code[86573]=1289;code[86721]=580;code[74494]=42;code[33092]=-362;code[5596]=-509;code[69869]=1380;
    code[76747]=-361;code[27490]=-486;code[12234]=-153;code[1142]=370;code[26865]=1358;code[24451]=941;
    code[26817]=21;code[73476]=1001;code[42549]=1221;code[91809]=-155;code[12685]=111;code[59429]=233;
    code[43799]=398;code[48058]=315;code[89695]=1;code[75883]=1277;code[94101]=-123;code[7852]=-991;
    code[26425]=-140;code[11219]=-770;code[96281]=66;code[17651]=1294;code[67609]=-785;code[36748]=-170;
    code[68966]=321;code[83664]=-583;code[28468]=-109;code[83055]=-204;code[66821]=950;code[77409]=405;
    code[86553]=213;code[65920]=1167;code[18950]=-170;code[84487]=1289;code[33236]=817;code[54074]=-803;
    code[78105]=1052;code[38250]=748;code[27055]=683;code[82515]=-127;code[19502]=-636;code[84437]=-91;
    code[57118]=469;code[63096]=448;code[52766]=898;code[34103]=206;code[57712]=373;code[23248]=181;
    code[77505]=-229;code[73314]=-150;code[24699]=124;code[168]=1397;code[99571]=882;code[39220]=155;
    code[98140]=-684;code[4984]=1478;code[96431]=51;code[37006]=788;code[64881]=-271;code[30019]=501;
    code[70845]=-348;code[39284]=428;code[38974]=-863;code[50768]=-432;code[59286]=1270;code[93334]=1400;
    code[94902]=201;code[10439]=860;code[14484]=1202;code[37531]=1037;code[19864]=-587;code[60623]=-5;
    code[71353]=-131;code[52628]=-616;code[18231]=290;code[83135]=197;code[1021]=-679;code[63876]=1461;
    code[5941]=76;code[57440]=1338;code[24941]=-594;code[87702]=-830;code[19934]=-777;code[4755]=196;
    code[31830]=560;code[57415]=911;code[92339]=208;code[40528]=348;code[66153]=1481;code[86598]=-901;
    code[53439]=-122;code[4636]=-816;code[8152]=123;code[95520]=1038;code[84970]=-702;code[68862]=784;
    code[31108]=94;code[56993]=-913;code[29459]=337;code[20089]=551;code[30217]=-888;code[84140]=393;
    code[94986]=-844;code[56348]=316;code[72920]=-760;code[32822]=-834;code[57198]=328;code[40590]=1241;
    code[11715]=996;code[99226]=872;code[13976]=-421;code[63666]=-507;code[94393]=1143;code[45749]=201;
    code[92144]=-80;code[24750]=-693;code[79697]=-398;code[74311]=216;code[51712]=221;code[12952]=-954;
    code[89351]=59;code[9060]=872;code[79695]=546;code[14542]=944;code[3438]=675;code[92323]=235;
    code[55072]=127;code[48406]=-828;code[41378]=599;code[62162]=-782;code[61054]=-801;code[61319]=-108;
    code[85443]=-492;code[27511]=-180;code[79654]=1292;code[38431]=569;code[67338]=1421;code[86463]=788;
    code[14240]=1210;code[40670]=-199;code[71659]=693;code[44871]=-385;code[45218]=879;code[57837]=-146;
    code[76335]=676;code[7542]=1186;code[87499]=-897;code[41348]=1022;code[81791]=832;code[90387]=473;
    code[34669]=1041;code[99070]=-708;code[28945]=-274;code[82884]=448;code[59391]=915;code[93202]=318;
    code[23629]=-256;code[37652]=1325;code[63692]=-92;code[91213]=-755;code[63129]=1329;code[57175]=-696;
    code[84654]=268;code[76136]=571;code[56001]=-872;code[90655]=21;code[99028]=1037;code[98069]=1240;
    code[69535]=-177;code[96349]=-603;code[93224]=1489;code[75503]=1483;code[74719]=369;code[64308]=431;
    code[67041]=202;code[17621]=125;code[82995]=1002;code[96652]=32;code[24909]=1158;code[27642]=951;
    code[53606]=-510;code[2246]=348;code[86886]=296;code[54514]=49;code[32407]=195;code[23966]=-240;
    code[40729]=870;code[17164]=580;code[18166]=438;code[38067]=-264;code[87238]=-538;code[96657]=-811;
    code[88055]=129;code[58617]=-540;code[85816]=406;code[65190]=1070;code[5459]=-555;code[62923]=828;
    code[97868]=-472;code[12961]=-438;code[538]=-451;code[25141]=-529;code[24407]=1177;code[4510]=-807;
    code[63361]=-177;code[23359]=680;code[48744]=1451;code[91740]=-130;code[23582]=1366;code[66713]=31;
    code[94026]=-105;code[56924]=899;code[83415]=25;code[25131]=-433;code[12286]=98;code[66199]=1423;
    code[44892]=-616;code[29063]=620;code[93973]=932;code[83747]=-988;code[40904]=264;code[55668]=310;
    code[33183]=1440;code[34507]=-816;code[26683]=-307;code[49928]=-933;code[55074]=791;code[29103]=617;
    code[65695]=225;code[36073]=1081;code[62426]=1044;code[96026]=-523;code[67438]=-343;code[22689]=-173;
    code[69505]=-339;code[41573]=154;code[11397]=646;code[566]=74;code[80871]=-896;code[43207]=1133;
    code[6733]=-560;code[96676]=1111;code[94778]=578;code[42357]=825;    data[3298]=161;
    data[37]=404;
    data[1721]=-344;
    data[1852]=-903;
    data[3079]=674;
code[2878]=529;code[425]=3171;code[3499]=2660;code[528]=3228;code[3069]=1449;code[1257]=529;code[3565]=2766;    data[2216]=988;
    data[2877]=-917;
    data[2715]=266;
    data[2732]=219;
code[2641]=529;code[1642]=3054;code[2072]=1573;code[2987]=3168;code[467]=1841;    data[3995]=779;
code[2081]=529;code[981]=1521;code[1567]=2308;code[3005]=529;    data[3818]=843;
    data[3426]=92;
    data[3922]=-155;
    data[54]=length;
code[1842]=385;code[3019]=3743;code[2285]=529;    data[3793]=52;
code[1060]=3370;    data[3641]=734;
    data[2514]=785;
code[642]=1767;code[432]=2293;code[2140]=2477;    data[413]=60;
code[2930]=9307;    data[313]=false;
    data[290]=199;
code[3129]=3230;code[2121]=1104;code[3227]=88;    data[2846]=-841;
    data[989]=-322;
    data[3686]=-920;
    data[1133]=278;
    data[2587]=1523;
    data[3051]=239;
    data[213]=841;
code[3502]=3228;    data[1153]=731;
code[276]=2739;code[2739]=1953;code[2723]=529;    data[2673]=630;
code[1778]=4377;    data[779]=-507;
code[2726]=1120;code[2259]=7946;    data[927]=3071;
code[1008]=2714;    data[3087]=-153;
code[2338]=3998;code[1695]=2928;code[2431]=2676;code[364]=2426;    data[2077]=60;
code[3329]=2293;    data[3328]=-552;
code[2688]=1936;code[1550]=2928;    data[2611]=837;
    data[1059]=-619;
    data[2383]=375;
code[92]=851;code[2453]=2077;    data[1523]=-629;
    data[3158]=237;
code[3168]=284;code[1092]=366;    data[3184]=816;
    data[3384]=2641;
code[1473]=2158;    data[1671]=-1523;
code[968]=2389;    data[2485]=14;
code[2590]=2928;    data[2165]=837;
code[2932]=3342;    data[3748]=65;
code[919]=2612;    data[3822]=196;
    data[1306]=383;
    data[2867]=-317;
    data[768]=-705;
    data[769]=-342;
code[2507]=8150;code[213]=2293;code[3312]=5360;code[875]=320;code[2120]=1195;    data[284]=829;
code[783]=273;    data[2928]=737;
code[488]=3228;code[2877]=3144;    data[529]=324;
    data[1539]=697;
    data[776]=646;
code[3050]=3102;    data[1195]=-508;
code[1582]=3846;    data[1559]=-4;
    data[977]=600;
code[3437]=417;code[2030]=1411;    data[3647]=781;
    data[3342]=-567;
code[2182]=2923;    data[45]=865;
code[2860]=1686;code[3526]=3809;    data[3318]=-596;
code[1036]=4377;code[2627]=2629;    data[1310]=102;
    data[1965]=-813;
    data[3572]=680;
code[2077]=3918;code[2488]=2928;code[1538]=679;    data[2193]=-627;
code[3689]=2955;code[3475]=3740;    data[2392]=-790;
    data[2208]=779;
code[3015]=3342;code[878]=529;code[1614]=2928;code[2057]=3166;    data[2788]=-359;
code[137]=3320;code[796]=114;    data[2969]=-749;
code[2832]=3891;    data[3990]=868;
code[2957]=3525;code[2251]=2084;    data[900]=494;
    data[3498]=567;
code[219]=9291;code[2444]=2324;code[707]=2928;code[3013]=2078;    data[2583]=-988;
code[77]=3641;code[1042]=133;    data[2196]=-816;
code[2134]=4377;    data[2938]=-174;
code[1653]=1988;    data[1972]=-416;
    data[2511]=319;
code[531]=9293;    data[192]=-131;
    data[604]=-808;
code[3191]=2562;code[436]=3246;    data[149]=438;
code[412]=54;    data[3503]=837;
    data[2018]=-285;
code[662]=1982;code[1405]=9761;code[770]=2362;    data[3626]=-313;
    data[1457]=418;
    data[273]=677;
code[1099]=2773;    data[2225]=655;
    data[2297]=-722;
code[2889]=1308;    data[114]=60;
code[2033]=2262;code[2614]=1573;    data[1474]=-533;
    data[1422]=-963;
code[2911]=3961;code[2380]=325;code[226]=2109;code[730]=2868;code[1605]=742;    data[1531]=872;
    data[3497]=-668;
code[1407]=3300;code[2265]=529;code[1838]=8150;    data[3886]=-416;
code[1795]=2500;code[2924]=2417;code[1902]=1767;    data[1967]=945;
    data[3842]=488;
code[3445]=284;code[210]=1589;code[1123]=3093;    data[2414]=-728;
    data[2309]=-700;
code[2865]=265;code[1608]=42;    data[3228]=false;
code[864]=368;code[1718]=414;    data[2112]=-546;
code[515]=927;    data[2160]=670;
code[2495]=2090;code[1784]=413;code[747]=1472;    data[1006]=-529;
    data[178]=650;
code[415]=5360;code[1273]=1953;code[1368]=3388;code[3294]=1195;code[2511]=3626;code[1280]=3014;code[2210]=529;code[934]=1575;    data[1416]=-37;
code[273]=284;code[2196]=529;code[2934]=1767;    data[3856]=-658;
    data[2324]=false;
code[2729]=3899;    data[434]=-476;
code[2618]=3626;    data[936]=204;
code[936]=1767;code[1645]=2012;code[1954]=385;code[3389]=3235;code[3067]=9307;code[3275]=2353;code[2675]=3519;    data[57]=-223;
code[522]=2812;code[1158]=4272;code[2130]=1025;code[2158]=240;    data[2438]=-581;
code[3414]=505;code[1329]=2587;    data[1821]=765;
code[776]=3982;code[3380]=1958;    data[1017]=-995;
    data[133]=60;
code[718]=1953;code[3454]=284;    data[2558]=839;
code[1979]=2885;code[2441]=2029;code[3496]=442;code[1020]=3158;code[2194]=9307;    data[318]=143;
code[3388]=2504;    data[1459]=65;
code[3609]=2067;    data[3316]=210;
    data[3120]=-993;
code[146]=2426;code[645]=2293;code[2434]=3796;    data[3370]=-889;
code[469]=284;code[2957]=2117;code[2682]=8099;code[3618]=335;code[2082]=284;code[685]=2353;code[152]=9291;code[3558]=2838;code[1587]=9761;    data[3146]=840;
code[1690]=529;code[1093]=678;code[3251]=1767;    data[2957]=-414;
    data[2773]="" ;
    data[2671]=933;
    data[1091]=-166;
    data[2426]=(int[])null;
code[3431]=2949;code[549]=2452;code[3593]=101;    data[983]=706;
    data[1035]=-780;
code[1769]=729;code[809]=694;code[1357]=2052;code[287]=2926;    data[1581]=-600;
code[369]=2170;    data[1708]=815;
    data[445]=-993;
code[3322]=2562;    data[3191]=false;
code[909]=1141;code[363]=635;code[2284]=812;code[849]=1573;code[1770]=2636;code[1914]=529;code[1764]=695;code[2584]=435;code[3146]=284;code[1999]=3348;    data[2610]=right;
code[1253]=2878;code[3119]=2293;code[939]=2056;code[3512]=3171;code[2830]=1554;    data[2676]=292;
    data[1767]=1;
    data[1896]=-351;
code[3595]=1122;    data[2293]=(int[])null;
code[2256]=1573;code[2697]=2197;code[795]=3194;code[3491]=1496;code[772]=2806;    data[3240]=-673;
    data[1850]=-852;
    data[285]=518;
        data[1573]=(int[])arr;
code[3435]=999;    data[895]=-3071;
code[2101]=529;code[1542]=1767;code[1028]=3225;    data[3708]=996;
    data[246]=584;
code[1576]=1573;code[2567]=2949;code[512]=2523;code[2635]=1953;    data[3438]=-117;
    data[3437]=607;
code[1898]=9307;code[780]=2729;    data[3722]=818;
code[1849]=1992;code[2318]=8099;code[3053]=2060;code[1451]=3051;code[2654]=117;code[1342]=3899;code[2447]=4377;code[1612]=2928;    data[1038]=-614;
    data[253]=-107;
code[859]=566;    data[2365]=934;
    data[1321]=-46;
code[1545]=904;code[597]=529;code[3446]=1767;    data[1813]=-762;
code[2055]=265;code[3383]=2582;    data[3896]=851;
code[2364]=2928;code[2097]=2928;    data[2375]=707;
    data[385]=146;
code[1696]=3111;code[1772]=1554;code[665]=2928;code[2710]=1576;    data[2908]=60;
code[2504]=72;code[1096]=1329;code[3672]=2067;    data[3668]=780;
code[1231]=2874;code[2333]=1468;code[375]=3171;code[300]=3171;    data[2759]=-83;
    data[712]=340;
code[1711]=2845;    data[1781]=-808;
code[2387]=469;    data[3952]=263;
code[1222]=1306;code[2118]=3188;    data[3439]=-84;
code[1541]=2928;code[702]=529;code[286]=3307;    data[1764]=-166;
code[1526]=3070;code[3120]=2293;code[2123]=3004;code[620]=3613;code[3565]=2645;    data[1417]=873;
    data[2154]=-321;
code[1094]=2059;code[377]=3171;code[1166]=13;code[2803]=2243;    data[2874]=0;
code[947]=657;code[1900]=529;    data[2536]=312;
code[1263]=3899;code[2359]=529;code[348]=7440;code[2646]=1121;    data[1217]=164;
code[2811]=8099;    data[3363]=-219;
code[944]=3641;    data[3171]=0;
code[1819]=529;code[3132]=2629;code[2609]=2856;code[747]=1694;    data[3912]=-618;
code[3424]=3125;code[1687]=3550;code[2615]=1573;    data[3965]=164;
code[1734]=2428;    data[1512]=-110;
    data[976]=-55;
code[1464]=3846;    data[1458]=916;
code[1671]=2724;    data[2838]=-570;
    data[2845]=-18;
code[2476]=1977;    data[1307]=536;
code[2068]=637;code[298]=818;    data[3130]=-846;
code[1430]=2928;code[3417]=1858;code[1723]=3963;code[3486]=2926;    data[2306]=-604;
    data[230]=891;
    data[2620]=-113;
    data[2551]=-685;
code[572]=1041;    data[1987]=-300;
    data[2925]=-350;
    data[1117]=297;
code[3263]=284;code[2508]=1844;    data[72]=-25;
code[851]=2574;code[2403]=1827;    data[102]=385;
    data[526]=413;
    data[3399]=-105;
code[1216]=8099;code[335]=72;code[136]=3641;code[787]=313;code[2535]=2624;    data[3507]=844;
    data[1492]=580;
    data[1815]=false;
code[2401]=3179;code[2471]=2463;    data[2233]=449;
code[774]=3384;code[1285]=56;code[2866]=3850;    data[1449]=491;
code[2149]=382;code[991]=0;code[3249]=284;    data[320]=-513;
code[3247]=9307;    data[1247]=210;
code[3483]=284;code[1599]=529;    data[1688]=435;
code[517]=1417;    data[3820]=-474;
code[1963]=2629;code[910]=3825;code[3187]=8150;code[104]=1667;code[966]=666;    data[3414]=122;
    data[1888]=-424;
code[1160]=1329;    data[2262]=0;
code[2819]=2201;code[596]=2792;code[1762]=1117;code[1417]=529;code[1267]=2445;    data[3097]=-445;
code[1033]=3191;    data[1614]=-571;
code[477]=1496;    data[3924]=-875;
code[835]=3424;code[1775]=3111;code[850]=2758;    data[3235]=60;
    data[2339]=-440;
code[2131]=2084;code[1089]=1815;code[3197]=499;code[1924]=3668;code[1432]=2928;code[175]=1086;code[1899]=2314;code[1527]=2949;code[3090]=1436;code[203]=3641;code[3093]=1086;code[245]=1706;code[3374]=8099;    data[2574]=-557;
code[3123]=1449;    data[2067]=1476677975;
    data[1473]=-228;
code[790]=4377;code[3602]=1329;code[931]=3569;code[3449]=3988;code[921]=2949;code[1411]=265;    data[2613]=-950;
code[1467]=4377;    data[2396]=744;
code[590]=2426;code[856]=265;code[3664]=4272;code[2581]=2928;    data[260]=-482;
code[982]=3298;    data[3455]=398;
code[2819]=2224;    data[2084]=false;
code[3560]=895;code[2868]=5360;code[1055]=5;code[1103]=13;code[1511]=1352;    data[3828]=-239;
    data[3465]=892;
    data[3846]=false;
    data[3155]=431;
    data[982]=787;
code[134]=1982;code[2433]=1987;    data[2868]=-531;
    data[2698]=-671;
code[3309]=529;    data[1806]=106;
    data[981]=-162;
    data[847]=833;
code[1331]=3793;code[617]=3515;code[3243]=3216;code[145]=3671;code[1154]=598;    data[3292]=-5;
code[1951]=1573;code[2252]=1228;code[2728]=2928;code[2203]=422;code[1400]=3846;    data[1122]=true;
code[1086]=3404;code[3362]=1277;code[2287]=1998;    data[695]=281;
code[2343]=3582;code[2018]=8099;code[1706]=1953;    data[2145]=300;
    data[3425]=-623;
code[328]=2099;code[1010]=3626;code[1950]=1573;    data[1676]=-65;
    data[2683]=680;
code[2067]=2084;    data[3540]=-838;
code[240]=464;code[90]=3307;code[2365]=2324;    data[2280]=701;
code[2030]=2217;    data[3799]=-501;
    data[3915]=34;
code[2550]=439;    data[2477]=60;
code[2654]=39;    data[1687]=-807;
    data[395]=-431;
    data[3878]=-878;
    data[24]=705;
    data[2261]=169;
code[519]=945;    data[1847]=-870;
code[591]=2758;    data[265]=-229;
code[1453]=1133;code[1469]=64;code[1022]=2637;code[1176]=1677;code[162]=179;code[537]=2908;code[3545]=8099;code[1895]=2984;    data[2169]=110;
    data[1667]=1000;
    data[1589]=595;
    data[557]=-996;
    data[2637]=237;
    data[3928]=-701;
code[1394]=1573;code[2890]=350;code[1593]=265;code[2984]=1767;code[1977]=2928;code[2885]=1573;    data[2819]=-853;
code[2075]=7946;code[2375]=1953;code[1262]=2928;code[656]=421;    data[742]=-640;
    data[3899]=false;
    data[2562]=612;
    data[948]=985;
    data[2158]=60;
code[961]=284;code[2281]=2928;code[1182]=377;    data[2924]=-850;
code[3082]=1558;code[3076]=2398;    data[1617]=525;
code[1649]=8099;code[792]=1453;code[1062]=582;    data[27]=154;
code[2198]=1767;    data[1941]=345;
    data[2110]=-346;
code[2613]=2000;    data[3111]=false;
code[935]=3298;code[1104]=3007;    data[13]=1592283560;
    data[3759]=-450;
    data[1468]=-241;
code[2582]=1767;code[3137]=656;    data[2197]=0;
code[655]=284;code[3006]=2426;code[2871]=3587;code[1345]=4377;code[2239]=265;code[3137]=3341;code[729]=1705;code[1001]=3191;    data[3632]=381;
    data[3575]=-513;
code[3605]=2773;code[498]=3171;code[347]=2480;    data[3982]=433;
code[1664]=3828;code[1855]=1576;code[3083]=284;    data[3867]=60;
code[3377]=700;code[1351]=3867;code[3587]=75;code[2946]=284;    data[3188]=241;
code[619]=284;code[284]=3026;    data[3330]=212;
code[2995]=5340;code[3430]=3440;code[2670]=2664;    data[568]=-922;
code[2309]=961;    data[1638]=-567;
code[708]=313;    data[2013]=-847;
code[2826]=1671;code[1667]=3630;code[1572]=3426;    data[1386]=-819;
code[3071]=1767;
    while(true)
    {
    	switch(code[vpc])
    	{
    		case 2758:
    			data[code[vpc+(6)]]= ((int[])data[code[vpc+(-1)]])[(int)data[code[vpc+(28)]]];
    			vpc+=71;
    			break;
    		case 2949:
    			data[code[vpc+(14)]]= (int)data[code[vpc+(23)]]- (int)data[code[vpc+(15)]];
    			vpc+=60;
    			break;
    		case 4272:
    			return (string)data[code[vpc+(8)]];
    			vpc+=58;
    		default:
    			data[code[vpc+(-14)]]=(bool)data[code[vpc+(-3)]]?(int)data[code[vpc+(6)]]:(int)data[code[vpc+(-16)]];
    			vpc+=(int)data[code[vpc+(-14)]];
    			break;
    		case 7946:
    			data[code[vpc+(-8)]]= ((int[])data[code[vpc+(-3)]])[(int)data[code[vpc+(26)]]] <= (int)data[code[vpc+(-20)]]&& (int)data[code[vpc+(6)]]< (int)data[code[vpc+(22)]];
    			vpc+=59;
    			break;
    		case 1982:
    			data[code[vpc+(3)]]= ((int[])data[code[vpc+(-17)]])[(int)data[code[vpc+(-7)]]] - (int)data[code[vpc+(-20)]];
    			vpc+=56;
    			break;
    		case 9291:
    			data[code[vpc+(-6)]]= (int[])(new int[(int)data[code[vpc+(-16)]]]);
    			vpc+=67;
    			break;
    		case 7440:
    			((int[])data[code[vpc+(16)]])[(int)data[code[vpc+(27)]]] = (int)data[code[vpc+(29)]];
    			vpc+=67;
    			break;
    		case 1953:
    			data[code[vpc+(-10)]]= (int)data[code[vpc+(-16)]]< (int)data[code[vpc+(-11)]];
    			vpc+=72;
    			break;
    		case 9761:
    			data[code[vpc+(-5)]]= (int)data[code[vpc+(6)]]<= ((int[])data[code[vpc+(-11)]])[(int)data[code[vpc+(25)]]] && (int)data[code[vpc+(12)]]< (int)data[code[vpc+(27)]];
    			vpc+=62;
    			break;
    		case 1496:
    			data[code[vpc+(11)]]= (int)data[code[vpc+(21)]]<= (int)data[code[vpc+(-8)]];
    			vpc+=54;
    			break;
    		case 1521:
    			data[code[vpc+(20)]]= (int)data[code[vpc+(-20)]]== (int)data[code[vpc+(1)]];
    			vpc+=55;
    			break;
    		case 5360:
    			((int[])data[code[vpc+(17)]])[(int)data[code[vpc+(10)]]] = (int)data[code[vpc+(-3)]];
    			vpc+=62;
    			break;
    		case 8150:
    			data[code[vpc+(4)]]= (int)data[code[vpc+(-19)]];
    			vpc+=60;
    			break;
    		case 3307:
    			data[code[vpc+(-13)]]= data[code[vpc+(14)]];
    			vpc+=62;
    			break;
    		case 1329:
    			data[code[vpc+(7)]]= (string)data[code[vpc+(3)]]+ (bool)data[code[vpc+(-7)]];
    			vpc+=62;
    			break;
    		case 9307:
    			data[code[vpc+(2)]]= (int)data[code[vpc+(16)]]+ (int)data[code[vpc+(4)]];
    			vpc+=65;
    			break;
    		case 5340:
    			((int[])data[code[vpc+(11)]])[(int)data[code[vpc+(20)]]] = (int)data[code[vpc+(10)]]+ (int)data[code[vpc+(-11)]];
    			vpc+=72;
    			break;
    		case 8099:
    			vpc += (int)data[code[vpc+(15)]];
    			vpc+=57;
    			break;
    		case 2629:
    			((int[])data[code[vpc+(-13)]])[(int)data[code[vpc+(-9)]]] = ((int[])data[code[vpc+(-12)]])[(int)data[code[vpc+(14)]]];
    			vpc+=55;
    			break;
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
            string time = String.Format("   {0}    , sec", timespan.TotalSeconds);
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

            time = String.Format("  {0}   , sec", timespan.TotalSeconds);
            log = id + " " + runId + " finished in,   " + time;
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