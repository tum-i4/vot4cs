using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortIterative_class
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> data;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            QuickSortIterative_class lt = new QuickSortIterative_class();
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
                Console.WriteLine(i+" ##############");
                Debug.WriteLine(i+" ##############");
                string t_original = Time_Operation("QuickSortIterative_class", i, QuickSort_Iterative_class, unsorted_original, WARMUP, ITERATIONS);
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
            QuickSort_Iterative_class(unsorted_obfuscated, unsorted_obfuscated.Length, -1);

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
string QuickSort_Iterative_class(int[] arr, int length, int right)
{
    //Virtualization variables
    int[] code = new int[100798];
    object[] data = new object[4695];
    int vpc = 42;

    code[41603]=493;code[56411]=2;code[35352]=37;code[95288]=-381;code[12892]=-833;code[97178]=1219;
    code[90121]=1267;code[9497]=1490;code[24907]=1055;code[78915]=672;code[24619]=-498;code[99593]=-56;
    code[22380]=-425;code[74570]=834;code[64736]=-598;code[8590]=-857;code[45995]=-450;code[60818]=541;
    code[62224]=1135;code[2208]=771;code[71910]=502;code[51507]=-641;code[228]=-822;code[58128]=307;
    code[26994]=868;code[80530]=714;code[91326]=-573;code[8528]=-471;code[61399]=-546;code[18041]=-699;
    code[68051]=-472;code[61026]=1417;code[98961]=1266;code[43501]=685;code[30588]=193;code[38194]=-18;
    code[80657]=-815;code[96305]=607;code[69561]=1110;code[37851]=-624;code[65881]=-459;code[46968]=1237;
    code[36496]=-2;code[15266]=-288;code[13648]=-21;code[767]=88;code[68043]=1253;code[3388]=254;
    code[100367]=360;code[16331]=-761;code[64511]=1256;code[22141]=975;code[37137]=14;code[89264]=1079;
    code[21741]=103;code[52565]=912;code[81277]=-929;code[47054]=146;code[75153]=776;code[60962]=455;
    code[76115]=-634;code[54295]=1279;code[47359]=1358;code[72372]=1246;code[4087]=133;code[65249]=-635;
    code[68766]=-301;code[51450]=877;code[100495]=689;code[53063]=1390;code[51795]=-202;code[7003]=734;
    code[87720]=-394;code[63412]=616;code[43811]=437;code[76228]=-288;code[94679]=449;code[34324]=234;
    code[36686]=-231;code[32305]=62;code[69334]=1467;code[79764]=905;code[80053]=-62;code[8331]=316;
    code[52223]=789;code[46513]=-826;code[18558]=621;code[6903]=88;code[7753]=1111;code[4176]=-433;
    code[31686]=-822;code[46778]=163;code[70289]=-95;code[20834]=-744;code[94679]=-958;code[39009]=722;
    code[35796]=-747;code[27048]=317;code[53245]=-232;code[90682]=236;code[16133]=-744;code[12943]=797;
    code[11460]=715;code[10186]=-274;code[51525]=1262;code[42000]=297;code[26865]=-767;code[11148]=540;
    code[52693]=-186;code[6527]=80;code[17014]=1450;code[59187]=253;code[33144]=931;code[72052]=-794;
    code[38327]=353;code[91455]=923;code[95267]=366;code[6759]=-471;code[95058]=863;code[35449]=-973;
    code[26317]=1289;code[59608]=-915;code[60492]=1169;code[42587]=-346;code[99876]=629;code[426]=-495;
    code[24455]=169;code[32857]=-551;code[51951]=567;code[39308]=-147;code[97920]=-954;code[91772]=1424;
    code[100560]=617;code[57860]=799;code[2652]=1247;code[67866]=943;code[98202]=-866;code[17232]=-368;
    code[39182]=382;code[90831]=152;code[35269]=132;code[9249]=820;code[54153]=762;code[53112]=193;
    code[22244]=1217;code[70190]=-211;code[35813]=-974;code[3989]=-394;code[555]=554;code[3697]=1382;
    code[29616]=756;code[23732]=-770;code[98647]=-434;code[22985]=-528;code[29901]=-818;code[79754]=1406;
    code[73179]=1322;code[99927]=296;code[93404]=-545;code[43589]=-269;code[12117]=-759;code[50316]=-652;
    code[20409]=-107;code[42555]=1409;code[1424]=1320;code[24928]=917;code[52028]=1370;code[16849]=618;
    code[21934]=1499;code[75557]=-224;code[48079]=-155;code[18232]=-632;code[9661]=834;code[59462]=65;
    code[1918]=302;code[31852]=1058;code[19072]=860;code[83942]=-507;code[20507]=-760;code[89663]=553;
    code[81096]=-340;code[17617]=-80;code[83242]=-940;code[44992]=944;code[76790]=-140;code[30318]=1317;
    code[43605]=-696;code[82213]=955;code[92290]=-121;code[4370]=171;code[77355]=1489;code[95234]=232;
    code[61715]=60;code[58243]=930;code[11626]=1424;code[44736]=-697;code[11107]=-680;code[50999]=-469;
    code[16454]=1031;code[32424]=-821;code[28973]=1030;code[66977]=687;code[22214]=-28;code[39381]=-832;
    code[93582]=-874;code[28397]=1129;code[5328]=52;code[86066]=1021;code[32192]=704;code[76210]=4;
    code[44991]=685;code[66780]=979;code[90744]=-552;code[82323]=-240;code[62089]=507;code[62388]=-743;
    code[3021]=1429;code[18267]=1388;code[33404]=-326;code[27472]=-443;code[3356]=276;code[85041]=-839;
    code[69359]=480;code[6905]=723;code[27662]=743;code[90054]=203;code[5690]=1299;code[63028]=532;
    code[15073]=1181;code[78083]=-898;code[57693]=-785;code[45488]=-187;code[43508]=-554;code[82836]=-798;
    code[24155]=1246;code[48107]=-877;code[41253]=332;code[37147]=1339;code[83719]=494;code[10471]=-230;
    code[11177]=-682;code[3010]=1296;code[71506]=-657;code[4698]=-725;code[34915]=420;code[81226]=147;
    code[49915]=-422;code[65599]=1367;code[5973]=295;code[63814]=273;code[77635]=1468;code[45326]=-61;
    code[22177]=1109;code[7271]=308;code[55570]=723;code[78884]=379;code[77471]=166;code[93750]=112;
    code[5697]=331;code[62108]=-265;code[13308]=779;code[74063]=678;code[9337]=-955;code[55871]=-556;
    code[88911]=54;code[88352]=-219;code[97235]=486;code[54232]=-692;code[68311]=634;code[70425]=1163;
    code[6592]=307;code[56327]=642;code[79170]=-365;code[69584]=-929;code[30387]=-486;code[89747]=316;
    code[90910]=-153;code[38042]=-854;code[25458]=945;code[28557]=-496;code[29193]=1236;code[64659]=-676;
    code[81943]=175;code[59178]=-565;code[93578]=1016;code[77337]=6;code[84055]=876;code[23053]=522;
    code[15408]=-806;code[89320]=1096;code[33061]=313;code[88321]=690;code[53547]=-126;code[41382]=564;
    code[21875]=198;code[87791]=1249;code[37354]=242;code[58045]=-573;code[88859]=72;code[85066]=-212;
    code[67227]=290;code[10119]=237;code[44207]=219;code[69828]=-622;code[11116]=921;code[91287]=-564;
    code[89905]=111;code[88063]=910;code[1833]=1413;code[60320]=157;code[6005]=1403;code[96475]=122;
    code[94302]=1169;code[3226]=-158;code[17621]=-856;code[73320]=809;code[23580]=427;code[17296]=1029;
    code[42849]=-47;code[23955]=-892;code[66233]=-352;code[51949]=121;code[57842]=740;code[773]=1314;
    code[62830]=1029;code[15399]=1290;code[83732]=-48;code[25776]=763;code[56352]=628;code[56381]=427;
    code[45939]=-111;code[98418]=-869;code[4135]=-546;code[94825]=-198;code[27532]=-846;code[34171]=592;
    code[73337]=387;code[81241]=1000;code[44960]=271;code[88199]=-402;code[86681]=-735;code[71925]=-93;
    code[91217]=1027;code[90014]=1132;code[31761]=165;code[25476]=933;code[82850]=666;code[59239]=-247;
    code[28516]=157;code[41080]=-21;code[76154]=716;code[65789]=403;code[47649]=289;code[19026]=-311;
    code[57943]=138;code[26154]=-874;code[78268]=-200;code[71664]=-127;code[64742]=533;code[14876]=-426;
    code[29120]=-781;code[605]=1017;code[81556]=413;code[82142]=-848;code[97496]=261;code[52146]=1458;
    code[10178]=207;code[48761]=-567;code[45709]=-620;code[89745]=-28;code[62727]=543;code[28044]=1149;
    code[20824]=-495;code[100504]=254;code[96336]=-405;code[66417]=673;code[31776]=-556;code[10385]=669;
    code[68597]=1114;code[75835]=1268;code[70654]=-681;code[31094]=-825;code[94560]=-310;code[95711]=-267;
    code[84297]=343;code[90324]=225;code[72872]=896;code[61247]=679;code[81589]=-635;code[60527]=517;
    code[57285]=-218;code[10594]=822;code[85257]=1119;code[67327]=1308;code[38309]=1039;code[49677]=519;
    code[40291]=1457;code[69359]=236;code[31125]=-480;code[92884]=1325;code[25468]=759;code[67087]=45;
    code[34474]=-579;code[95417]=391;code[57451]=78;code[86525]=335;code[24707]=-637;code[34167]=-31;
    code[2297]=448;code[22604]=-775;code[61316]=-935;code[92061]=-949;code[4508]=-280;code[9120]=849;
    code[7096]=-717;code[36571]=503;code[22667]=675;code[35704]=1161;code[65264]=717;code[39019]=692;
    code[90829]=-722;code[35621]=1371;code[96511]=1396;code[36564]=-365;code[64922]=-250;code[47537]=823;
    code[99171]=1077;code[32456]=-434;code[79666]=612;code[37641]=-866;code[7885]=-484;code[49020]=141;
    code[6913]=-358;code[31175]=437;code[79755]=185;code[74632]=-161;code[19378]=367;code[19077]=242;
    code[67812]=1411;code[6343]=-785;code[93285]=1090;code[9657]=925;code[64671]=583;code[62234]=-16;
    code[35093]=-681;code[7484]=-995;code[31599]=-167;code[60366]=735;code[62985]=1241;code[88707]=750;
    code[65455]=969;code[46670]=-576;code[56423]=-661;code[54145]=91;code[64696]=1062;code[55815]=1064;
    code[58685]=-282;code[12932]=-395;code[11181]=790;code[82164]=87;code[64478]=1288;code[22860]=658;
    code[40327]=845;code[2252]=1147;code[95579]=237;code[87918]=940;code[8528]=-94;code[44014]=-656;
    code[37618]=1315;code[21211]=264;code[9698]=-549;code[75790]=308;code[57854]=-379;code[42345]=-935;
    code[20665]=-108;code[58810]=1271;code[8215]=112;code[6116]=834;code[56545]=998;code[77578]=1054;
    code[11432]=695;code[49239]=-633;code[96025]=944;code[74698]=-451;code[85751]=1476;code[87571]=-538;
    code[50971]=-227;code[34168]=147;code[16492]=758;code[9028]=-622;code[32052]=1490;code[65912]=478;
    code[91869]=1408;code[70014]=599;code[30429]=757;code[58130]=434;code[15765]=-29;code[39554]=44;
    code[69770]=512;code[57515]=990;code[51152]=-499;code[17677]=-464;code[49198]=-4;code[1421]=8176;code[449]=2793;    data[3600]=1000;
code[2000]=569;code[3226]=1255;    data[1771]=244;
code[3321]=1769;code[718]=3511;code[2063]=2841;code[1280]=1332;code[1764]=239;    data[3179]=911;
code[471]=3890;code[886]=1486;code[1845]=3179;code[2018]=4797;code[815]=1029;    data[2887]=length;
code[2394]=3359;code[719]=2138;    data[1222]=true;
    data[1722]=62;
code[1706]=1210;    data[253]=1026765439;
code[2227]=3043;    data[279]=-245;
code[2565]=1029;code[1612]=2895;code[869]=9480;    data[2270]=668;
code[1328]=3256;code[1549]=569;code[1067]=253;code[622]=6480;    data[2479]=false;
code[2559]=3179;    data[569]=-432;
code[972]=3262;    data[42]="" ;
code[1004]=364;code[2842]=1258;code[3504]=42;code[946]=1486;code[2217]=3179;code[1908]=7091;code[630]=207;code[1220]=1332;code[3132]=4819;code[2577]=1029;    data[3843]=false;
    data[1397]=1641648764;
code[1915]=207;code[170]=4692;code[3578]=1397;code[985]=3311;code[3136]=536;code[472]=730;    data[3311]=false;
code[1120]=9895;code[973]=2980;code[1905]=239;code[2208]=4797;code[1358]=569;code[3326]=536;code[3193]=3179;    data[3095]=right;
    data[3629]=714;
code[2637]=725;code[951]=3311;    data[3890]=2997;
code[2190]=569;code[2027]=3179;code[2094]=736;code[1993]=1855;code[2315]=962;code[391]=2793;    data[1995]=965;
    data[2841]=-955;
    data[1255]=943;
code[1284]=8176;code[3016]=1995;code[2155]=3179;code[3460]=2565;code[3346]=536;code[2832]=536;code[1405]=2459;code[120]=587;    data[2493]=(int[])null;
    data[1769]=1;
    data[3511]=2574;
    data[3359]=62;
code[1500]=207;    data[2665]=62;
code[69]=3600;code[2510]=1769;code[2552]=7091;    data[110]=62;
code[3198]=2493;code[1537]=1811;code[3392]=2793;code[2677]=207;code[2298]=1232;code[2952]=4819;code[324]=2793;code[797]=7567;code[810]=3179;code[420]=7131;code[1768]=3179;code[2029]=3179;code[3284]=3001;    data[429]=1488;
code[2269]=2895;code[1532]=207;code[3075]=9736;code[568]=587;    data[730]=-195;
code[2893]=1258;    data[1332]=false;
code[403]=536;code[3199]=6846;code[2662]=5746;code[2233]=1029;code[919]=536;code[679]=5746;code[131]=2270;code[1174]=2895;code[3055]=1255;code[1243]=207;code[923]=5973;    data[1044]=362;
code[2608]=2895;code[872]=2270;    data[3043]=false;
code[1855]=3179;    data[3256]=false;
code[298]=2943;    data[2301]=245;
code[323]=2793;    data[3001]=54;
    data[3262]=239;
code[2425]=207;code[824]=569;code[3431]=2895;code[2062]=1771;code[2766]=569;code[3481]=1222;code[1784]=9736;    data[207]=532;
code[2363]=372;code[1417]=3256;code[1921]=1029;code[2338]=207;code[2141]=4819;code[1338]=3179;code[63]=2270;    data[795]=283;
code[3501]=1397;code[284]=587;code[632]=536;code[2646]=3179;code[1526]=1029;code[2799]=3179;code[1666]=5746;code[2145]=3179;code[3363]=7131;code[2956]=536;    data[1182]=296;
code[1144]=253;code[663]=3179;code[638]=2493;    data[1232]=-244;
code[3044]=2493;    data[239]=93;
code[110]=4692;code[1964]=2895;code[2379]=8176;code[1533]=207;code[2747]=3744;code[435]=3518;code[1681]=207;code[1658]=2479;code[1650]=3179;        data[1029]=(int[])arr;
code[191]=2270;code[180]=2493;code[2307]=3179;    data[587]=(int[])null;
code[2219]=3179;code[2362]=795;code[1869]=1769;code[1641]=279;code[1529]=3179;code[1495]=1769;code[3554]=9895;    data[1486]=-837;
code[3485]=1576;code[1436]=110;code[1705]=1182;    data[2980]=709;
    data[962]=false;
code[2828]=4819;code[2718]=2895;code[617]=1769;code[1933]=1029;code[503]=1722;    data[736]=62;
code[1519]=3256;    data[3744]=-1488;
    data[2138]=-957;
code[881]=1769;code[484]=3518;    data[536]=189;
code[2075]=3043;    data[1674]=0;
code[577]=3179;code[2323]=5746;code[671]=63;code[3309]=9480;code[1483]=9480;code[2441]=9736;code[364]=6846;code[3160]=1769;code[3019]=7091;    data[2565]=-2997;
    data[3975]=62;
code[3032]=2493;code[363]=2493;code[2654]=1332;    data[364]=62;
    data[1855]=0;
code[2014]=207;code[3312]=536;    data[1258]=647;
    data[3020]=62;
code[3026]=536;code[2881]=3179;code[989]=8176;code[2515]=207;code[1047]=3843;code[2421]=1044;code[2079]=8176;code[1212]=3179;code[42]=4078;code[1841]=4819;code[1299]=2665;code[3146]=536;code[2501]=207;code[3255]=2895;    data[2793]=0;
    data[63]=false;
code[1486]=207;code[2498]=9480;code[2980]=1769;code[3378]=3518;code[1051]=1576;code[1342]=207;    data[372]=219;
code[694]=207;code[731]=63;code[488]=8176;code[2169]=1769;code[2907]=1769;code[358]=2887;code[230]=4078;code[1341]=207;code[750]=3975;code[1346]=1811;    data[725]=0;
code[1718]=2479;code[1070]=42;    data[3518]=false;
    data[1210]=116;
code[2549]=1044;code[1404]=2301;code[257]=2793;code[3059]=536;code[2895]=2925;code[1228]=5746;code[2043]=1029;code[2375]=962;code[251]=536;code[2772]=6846;    data[2459]=-17;
code[1267]=429;code[550]=7567;code[563]=536;code[2771]=1029;code[1722]=8176;code[2204]=207;code[735]=8176;code[2856]=1769;code[1737]=3020;code[2966]=1995;code[1203]=1674;code[2887]=587;code[1335]=1029;code[1268]=3629;code[2037]=3043;
    return (string)InstanceInterpreterVirtualization_QuickSortIterative_class_368(vpc, data, code);

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

private object InstanceInterpreterVirtualization_QuickSortIterative_class_368(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 4692:
                data[code[vpc + (10)]] = (int[])(new int[(int)data[code[vpc + (21)]]]);
                vpc += 60;
                break;
            case 2925:
                ((int[])data[code[vpc + (-8)]])[(int)data[code[vpc + (-2)]]] = (int)data[code[vpc + (-14)]] + (int)data[code[vpc + (12)]];
                vpc += 57;
                break;
            case 2943:
                ((int[])data[code[vpc + (-14)]])[(int)data[code[vpc + (26)]]] = (int) data[code[vpc + (25)]];
                vpc += 66;
                break;
            case 4797:
                data[code[vpc + (19)]] = ((int[])data[code[vpc + (25)]])[(int)data[code[vpc + (9)]]] <= (int)data[code[vpc + (-18)]] && (int)data[code[vpc + (11)]] < (int)data[code[vpc + (-4)]];
                vpc += 61;
                break;
            case 4819:
                data[code[vpc + (14)]] = (int)data[code[vpc + (4)]] + (int)data[code[vpc + (28)]];
                vpc += 67;
                break;
            case 7091:
                ((int[])data[code[vpc + (25)]])[(int)data[code[vpc + (-3)]]] = ((int[])data[code[vpc + (13)]])[(int)data[code[vpc + (7)]]];
                vpc += 56;
                break;
            default:
                break;
            case 7567:
                data[code[vpc + (27)]] = ((int[])data[code[vpc + (18)]])[(int)data[code[vpc + (13)]]];
                vpc += 72;
                break;
            case 4078:
                data[code[vpc + (21)]] = data[code[vpc + (27)]];
                vpc += 68;
                break;
            case 7131:
                data[code[vpc + (15)]] = (int)data[code[vpc + (29)]] <= (int)data[code[vpc + (-17)]];
                vpc += 68;
                break;
            case 9736:
                data[code[vpc + (-20)]] = (int)data[code[vpc + (-16)]];
                vpc += 57;
                break;
            case 9895:
                return (string)data[code[vpc + (24)]];
                vpc += 54;
            case 5973:
                data[code[vpc + (28)]] = (int)data[code[vpc + (-4)]] == (int)data[code[vpc + (23)]];
                vpc += 66;
                break;
            case 8176:
                data[code[vpc + (-16)]] = (bool)data[code[vpc + (-4)]] ? (int)data[code[vpc + (15)]] : (int)data[code[vpc + (-17)]];
                vpc += (int)data[code[vpc + (-16)]];
                break;
            case 5746:
                data[code[vpc + (-8)]] = (int)data[code[vpc + (-16)]] < (int)data[code[vpc + (15)]];
                vpc += 56;
                break;
            case 1576:
                data[code[vpc + (16)]] = (string)data[code[vpc + (19)]] + (bool)data[code[vpc + (-4)]];
                vpc += 69;
                break;
            case 9480:
                data[code[vpc + (17)]] = (int)data[code[vpc + (3)]] - (int)data[code[vpc + (12)]];
                vpc += 54;
                break;
            case 6480:
                data[code[vpc + (8)]] = ((int[])data[code[vpc + (16)]])[(int)data[code[vpc + (10)]]] - (int)data[code[vpc + (-5)]];
                vpc += 57;
                break;
            case 2895:
                vpc += (int)data[code[vpc + (29)]];
                vpc += 54;
                break;
            case 1811:
                data[code[vpc + (-18)]] = (int)data[code[vpc + (12)]] <= ((int[])data[code[vpc + (-11)]])[(int)data[code[vpc + (-5)]]] && (int)data[code[vpc + (-8)]] < (int)data[code[vpc + (-4)]];
                vpc += 75;
                break;
            case 6846:
                ((int[])data[code[vpc + (-1)]])[(int)data[code[vpc + (27)]]] = (int)data[code[vpc + (-6)]];
                vpc += 56;
                break;
        }
    }

    return null;
}


    }
}