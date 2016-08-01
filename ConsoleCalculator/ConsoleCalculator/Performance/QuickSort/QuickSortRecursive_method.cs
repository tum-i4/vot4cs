using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortRecursive_method
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> testData;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();


        public static void RunLoopTests()
        {
            QuickSortRecursive_method lt = new QuickSortRecursive_method();
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
                Console.WriteLine(i + " ##############");
                Debug.WriteLine(i+" ##############");
                int[] unsorted_original = testData.ToArray();
                string t_original = Time_Operation("QuickSortRecursive_method", i, Quicksort_method, unsorted_original, WARMUP, ITERATIONS);
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
            string testName = "Performance#QuickSortRecursive_method_Check";
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
            Quicksort_method(unsorted_obfuscated, 0, unsorted_obfuscated.Length - 1);

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


//        [Obfuscation(Exclude = false, Feature = "virtualization; method")]
private string Quicksort_method(int[] elements, int left, int right)
{
    //Virtualization variables
    int[] code = new int[100196];
    object[] data = new object[4242];
    int vpc = 78;

    code[4294]=753;code[9302]=148;code[75264]=1108;code[52540]=-528;code[1305]=-863;code[23143]=-780;
    code[81498]=1331;code[79265]=946;code[66218]=682;code[54381]=346;code[67213]=458;code[43683]=-735;
    code[82371]=643;code[14704]=-572;code[89405]=-876;code[69906]=1370;code[19024]=1048;code[94370]=-916;
    code[77713]=1133;code[87203]=-645;code[472]=1431;code[84736]=130;code[51647]=-358;code[37335]=-306;
    code[46685]=205;code[38879]=-497;code[24603]=1076;code[4261]=149;code[26611]=1466;code[63840]=-766;
    code[69799]=-118;code[29724]=1408;code[35795]=-294;code[89987]=1484;code[99250]=893;code[312]=1018;
    code[80407]=1;code[53481]=745;code[73894]=1459;code[59199]=412;code[28543]=1172;code[70685]=25;
    code[66305]=241;code[70406]=-102;code[77847]=205;code[76965]=972;code[21675]=941;code[44629]=629;
    code[67708]=1206;code[9526]=-419;code[35961]=-54;code[28765]=771;code[47995]=451;code[39954]=1112;
    code[29742]=-140;code[72354]=-296;code[39646]=-820;code[81036]=1068;code[64874]=1216;code[30205]=1152;
    code[58116]=347;code[21737]=270;code[99113]=-465;code[59222]=-936;code[95713]=1205;code[2267]=1137;
    code[89029]=-105;code[20656]=1265;code[58312]=1492;code[93296]=-798;code[9784]=1144;code[6252]=82;
    code[76157]=215;code[39416]=-640;code[96976]=544;code[428]=973;code[58215]=-415;code[65398]=1050;
    code[16208]=946;code[72077]=-338;code[99149]=-68;code[89132]=37;code[32212]=1167;code[39415]=-907;
    code[86762]=1256;code[24604]=626;code[95721]=-450;code[76466]=805;code[47739]=960;code[74971]=257;
    code[82224]=117;code[5808]=-157;code[87944]=-417;code[27453]=635;code[70676]=-35;code[74585]=1008;
    code[27805]=665;code[9174]=811;code[97013]=618;code[11154]=1232;code[9299]=-111;code[27885]=-837;
    code[37303]=-116;code[83554]=-99;code[47199]=1326;code[34424]=-56;code[3055]=-460;code[44521]=356;
    code[31556]=380;code[53814]=-780;code[59427]=847;code[33284]=199;code[15853]=105;code[37380]=-278;
    code[12902]=-904;code[75540]=1072;code[67410]=1138;code[41098]=162;code[16885]=1481;code[96697]=310;
    code[40021]=1283;code[18360]=937;code[4262]=-84;code[77425]=-848;code[22224]=372;code[41058]=40;
    code[11068]=-943;code[30044]=-116;code[2364]=996;code[90879]=1324;code[98252]=361;code[23235]=81;
    code[17692]=286;code[70622]=-562;code[80775]=1448;code[37493]=-195;code[58823]=-968;code[69004]=699;
    code[55691]=393;code[43812]=978;code[67088]=-221;code[6750]=449;code[62988]=-156;code[71981]=624;
    code[55650]=-859;code[44209]=-75;code[8586]=-913;code[54449]=1136;code[68273]=876;code[59945]=319;
    code[66318]=493;code[25545]=-395;code[17497]=-782;code[83058]=-757;code[33513]=550;code[79946]=165;
    code[36192]=-712;code[26090]=671;code[47829]=629;code[80554]=1096;code[79781]=-862;code[62099]=874;
    code[53932]=-990;code[23699]=379;code[47053]=1084;code[100033]=1013;code[96091]=1273;code[12982]=-820;
    code[5708]=1062;code[40609]=352;code[50989]=552;code[31574]=1338;code[25903]=1437;code[882]=1425;
    code[77622]=1186;code[37808]=-927;code[94848]=898;code[73301]=516;code[97965]=263;code[70540]=-574;
    code[85268]=-308;code[62903]=251;code[62288]=1481;code[50821]=129;code[98790]=-530;code[61290]=630;
    code[24715]=-343;code[33044]=-562;code[74156]=711;code[49216]=408;code[99730]=-335;code[77877]=487;
    code[45754]=1422;code[86025]=-502;code[17817]=307;code[9448]=379;code[12127]=-413;code[69142]=-421;
    code[99512]=1036;code[31430]=-336;code[46864]=392;code[98609]=465;code[26354]=812;code[78429]=709;
    code[43062]=390;code[86822]=-267;code[1404]=-649;code[17544]=461;code[50070]=-918;code[4391]=631;
    code[13438]=-231;code[27451]=157;code[9423]=-851;code[53229]=-971;code[57390]=-756;code[18243]=1313;
    code[37145]=-437;code[9577]=95;code[28275]=-523;code[33248]=828;code[18654]=-563;code[77117]=553;
    code[65766]=1002;code[53878]=1450;code[5985]=-737;code[73360]=1400;code[77231]=652;code[13197]=-601;
    code[28358]=302;code[49327]=-493;code[19417]=927;code[11120]=-171;code[37496]=1352;code[92439]=971;
    code[4521]=841;code[30302]=-228;code[70246]=-220;code[46744]=1398;code[53914]=631;code[80824]=-268;
    code[52324]=377;code[95395]=168;code[36642]=-446;code[15497]=774;code[9383]=1339;code[15561]=902;
    code[69994]=-679;code[53885]=38;code[6394]=94;code[24774]=788;code[88009]=872;code[93702]=-193;
    code[80456]=58;code[25965]=146;code[19481]=-569;code[62308]=576;code[71584]=-502;code[68217]=607;
    code[82042]=609;code[96806]=-619;code[78791]=-468;code[69634]=-727;code[58257]=353;code[61144]=430;
    code[77593]=-872;code[89724]=-750;code[40599]=-772;code[41550]=932;code[61693]=572;code[66564]=1355;
    code[96455]=740;code[51633]=1303;code[31436]=311;code[4673]=248;code[44879]=1237;code[59758]=50;
    code[47251]=-763;code[93075]=663;code[5420]=1064;code[74298]=-346;code[81467]=717;code[68547]=-643;
    code[27744]=303;code[22579]=557;code[78607]=1269;code[2718]=-526;code[98120]=-941;code[19009]=-775;
    code[69886]=934;code[79729]=-859;code[49566]=-723;code[12466]=1198;code[45575]=188;code[62994]=-225;
    code[16270]=872;code[72044]=975;code[88931]=6;code[12953]=-311;code[1197]=-70;code[64560]=980;
    code[29998]=58;code[71619]=350;code[86950]=16;code[44173]=119;code[90690]=1096;code[96992]=-300;
    code[3001]=712;code[76845]=755;code[56349]=1011;code[68961]=1003;code[89457]=1287;code[46162]=-912;
    code[18903]=-408;code[30271]=441;code[89627]=1284;code[7848]=-187;code[12964]=-992;code[75876]=-823;
    code[39687]=460;code[1169]=-880;code[3451]=-548;code[40599]=-191;code[78263]=96;code[76155]=-494;
    code[63696]=67;code[71486]=-482;code[68524]=1106;code[90112]=-40;code[96468]=698;code[35223]=576;
    code[10478]=1160;code[55432]=1478;code[76180]=606;code[15126]=-934;code[92937]=739;code[30666]=1445;
    code[79452]=600;code[76863]=779;code[51079]=-658;code[25478]=874;code[47795]=-752;code[94271]=168;
    code[20077]=1177;code[64266]=-284;code[10437]=-68;code[10856]=791;code[23310]=-48;code[94540]=-575;
    code[62891]=34;code[56450]=-655;code[28827]=834;code[27570]=1349;code[12127]=838;code[41512]=-891;
    code[7577]=-532;code[87628]=1064;code[42595]=503;code[15398]=-988;code[92518]=-786;code[79244]=1223;
    code[130]=1160;code[92403]=386;code[58857]=473;code[74699]=30;code[69791]=492;code[8436]=-761;
    code[57471]=-711;code[46316]=858;code[82584]=-998;code[34706]=162;code[45761]=494;code[21141]=1291;
    code[49929]=-294;code[29214]=577;code[22772]=1345;code[24726]=354;code[62423]=685;code[13735]=58;
    code[81301]=801;code[35319]=329;code[99166]=-995;code[34790]=196;code[10347]=946;code[25270]=-227;
    code[13957]=25;code[18130]=1306;code[74087]=-186;code[43340]=9;code[65460]=-987;code[5644]=-238;
    code[29837]=-714;code[18509]=895;code[35086]=355;code[47378]=1248;code[98071]=-903;code[93375]=-741;
    code[64970]=1036;code[47628]=136;code[25088]=830;code[81501]=799;code[3039]=1455;code[49273]=1042;
    code[75890]=-190;code[80400]=-257;code[24202]=833;code[77154]=1014;code[66546]=-881;code[23433]=1188;
    code[81915]=472;code[12872]=402;code[30643]=-119;code[33106]=-749;code[47931]=-807;code[27453]=1311;
    code[85210]=1445;code[15356]=1302;code[19248]=-159;code[27508]=-212;code[62390]=-81;code[75]=-936;
    code[74133]=-561;code[65921]=-387;code[26937]=-685;code[44042]=502;code[58196]=500;code[63810]=653;
    code[60504]=-369;code[41458]=693;code[65320]=-22;code[33924]=700;code[5043]=1194;code[44764]=-342;
    code[58128]=1122;code[61498]=-182;code[77457]=1296;code[25307]=124;code[58945]=-744;code[82265]=-675;
    code[69616]=-788;code[83318]=-120;code[63890]=682;code[34455]=-375;code[34193]=229;code[31773]=1349;
    code[92473]=492;code[66480]=-422;code[2924]=-199;code[97740]=1155;code[73029]=-14;code[66653]=49;
    code[51325]=-720;code[82937]=655;code[34818]=-533;code[7317]=253;code[43227]=-292;code[98470]=417;
    code[56088]=1465;code[4261]=-58;code[53486]=-509;code[92395]=-780;code[53298]=685;code[40530]=-560;
    code[25542]=-947;code[42143]=-331;code[12737]=1397;code[40210]=-250;code[42061]=29;code[84172]=313;
    code[84706]=703;code[90460]=-615;code[41970]=1039;code[50918]=598;code[61536]=-759;code[67285]=-893;
    code[27855]=495;code[32899]=331;code[47327]=442;code[88957]=1095;code[70898]=629;code[40826]=-185;
    code[76794]=1013;code[37483]=181;code[88397]=706;code[14738]=-630;code[14643]=292;code[53277]=1130;
    code[29414]=919;code[67063]=790;code[16629]=912;code[56303]=-605;code[35038]=-56;code[99167]=321;
    code[63175]=1172;code[82955]=1106;code[52496]=-996;code[81954]=-516;code[27455]=441;code[38850]=534;
    code[44263]=-911;code[75857]=1329;code[1424]=2053;code[1726]=9611;code[1064]=2091;code[336]=3145;    data[1379]=198;
code[254]=2317;code[1394]=3335;    data[2028]=977;
code[1475]=2053;code[1625]=1212;    data[2130]=0;
code[648]=268;code[320]=6821;code[141]=6544;code[1316]=3150;code[2329]=840;    data[1203]=left;
code[2201]=2028;    data[673]=-470;
    data[2497]=false;
code[1460]=3335;code[2013]=2053;code[552]=268;code[310]=416;    data[2737]=73;
code[1253]=1274;code[526]=2053;    data[2549]=false;
code[1789]=2432;code[136]=3335;code[1793]=1468;code[530]=416;code[1847]=9488;code[1047]=2053;code[1596]=5531;code[2115]=9488;code[186]=1159;code[188]=1203;code[727]=1185;code[478]=2497;code[752]=268;code[924]=3755;code[1136]=1927;code[650]=268;code[2001]=3335;    data[1468]=-1393;
code[2204]=1379;    data[2317]=2;
code[2383]=8866;code[73]=268;code[851]=2091;code[1463]=6640;code[1535]=9118;code[730]=416;code[1277]=36;    data[394]=73;
code[1724]=268;    data[2788]=false;
code[204]=9118;code[938]=864;code[97]=1203;    data[3013]=false;
code[793]=2432;code[1668]=2432;    data[2286]=198;
code[1922]=394;code[797]=1649;code[1204]=36;code[2057]=2432;code[528]=1537;code[2103]=2788;code[454]=1274;code[1519]=268;code[992]=5531;    data[1746]=473;
    data[1212]=1;
    data[1938]=0;
code[728]=1537;    data[1537]=false;
code[1331]=2053;code[833]=3013;code[609]=2041;    data[3335]=-560;
code[919]=1274;    data[840]=0;
code[834]=2053;code[1740]=2497;code[1342]=268;    data[3150]=340;
    data[3880]=-615;
code[2258]=9861;code[160]=3254;code[1941]=2549;code[2381]=2730;code[2325]=2432;    data[1159]=-636;
code[1093]=416;code[2112]=3254;code[2061]=2130;code[1272]=1746;code[1387]=268;code[325]=2053;code[1672]=1938;    data[1927]=-271;
code[2281]=2053;code[459]=2737;code[612]=2197;code[1007]=3335;code[1326]=6821;code[265]=4301;    data[1649]=-258;
code[261]=3145;    data[864]=271;
    data[268]=-245;
code[470]=3880;code[1046]=3013;code[1216]=3335;code[473]=659;    data[3145]=835;
code[1752]=3335;code[1021]=1212;code[1269]=673;code[695]=1212;code[2253]=268;code[1611]=3335;code[78]=6544;    data[3255]=804;
code[233]=3254;code[1488]=3150;code[1132]=2432;code[1917]=1274;    data[2855]=73;
code[2185]=1274;    data[3254]=right;
code[417]=3335;    data[2985]=73;
code[598]=2855;    data[36]=false;
code[527]=1185;code[726]=2053;code[1258]=1265;code[405]=2497;code[1406]=2053;code[2209]=2788;    data[3755]=73;
code[943]=3013;code[1869]=1203;code[593]=1274;code[935]=3255;code[1564]=1212;code[1844]=3335;code[880]=416;code[1985]=1203;code[1067]=3335;    data[1265]=73;
code[389]=268;code[391]=9611;code[1517]=268;code[854]=3335;    data[2041]=-531;
    data[659]=1393;
code[1835]=2549;    data[2730]="";
code[1936]=2286;code[1397]=9509;code[2190]=2985;code[2269]=3254;code[1990]=9861;code[281]=1159;        data[2053]=(int[])elements;
    data[2197]=258;
code[1190]=9611;code[1188]=268;    data[416]=619;
code[666]=9118;code[978]=3335;code[617]=1537;code[2137]=268;code[1582]=3335;    data[612]=-743;
code[1933]=612;
    while(true)
    {
    	switch(code[vpc])
    	{
    		case 9509:
    			((int[])data[code[vpc+(9)]])[(int)data[code[vpc+(-10)]]] = ((int[])data[code[vpc+(27)]])[(int)data[code[vpc+(-3)]]];
    			vpc+=66;
    			break;
    		case 9611:
    			data[code[vpc+(14)]]= (int)data[code[vpc+(-2)]]<= (int)data[code[vpc+(26)]];
    			vpc+=63;
    			break;
    		case 6821:
    			data[code[vpc+(-10)]]= ((int[])data[code[vpc+(5)]])[(int)data[code[vpc+(16)]]];
    			vpc+=71;
    			break;
    		case 6640:
    			((int[])data[code[vpc+(12)]])[(int)data[code[vpc+(-3)]]] = (int)data[code[vpc+(25)]];
    			vpc+=72;
    			break;
    		case 8866:
    			return (string)data[code[vpc+(-2)]];
    			vpc+=66;
    		case 9861:
    			Quicksort_method((int[])data[code[vpc+(23)]], (int)data[code[vpc+(-5)]], (int)data[code[vpc+(11)]]);
    			vpc+=67;
    			break;
    		case 1274:
    			data[code[vpc+(16)]]=(bool)data[code[vpc+(24)]]?(int)data[code[vpc+(5)]]:(int)data[code[vpc+(19)]];
    			vpc+=(int)data[code[vpc+(16)]];
    			break;
    		case 4301:
    			data[code[vpc+(-4)]]= (int)data[code[vpc+(16)]]/ (int)data[code[vpc+(-11)]];
    			vpc+=55;
    			break;
    		case 9488:
    			data[code[vpc+(-12)]]= (int)data[code[vpc+(22)]]< (int)data[code[vpc+(-3)]];
    			vpc+=70;
    			break;
    		case 9118:
    			data[code[vpc+(-18)]]= (int)data[code[vpc+(-16)]]+ (int)data[code[vpc+(29)]];
    			vpc+=61;
    			break;
    		default:
    			break;
    		case 1185:
    			data[code[vpc+(1)]]= ((int[])data[code[vpc+(-1)]])[(int)data[code[vpc+(25)]]] < (int)data[code[vpc+(3)]];
    			vpc+=66;
    			break;
    		case 6544:
    			data[code[vpc+(-5)]]= (int)data[code[vpc+(19)]];
    			vpc+=63;
    			break;
    		case 5531:
    			data[code[vpc+(-14)]]= (int)data[code[vpc+(15)]]- (int)data[code[vpc+(29)]];
    			vpc+=72;
    			break;
    		case 2432:
    			vpc += (int)data[code[vpc+(4)]];
    			vpc+=58;
    			break;
    		case 2091:
    			data[code[vpc+(-18)]]= (int)data[code[vpc+(29)]]< ((int[])data[code[vpc+(-17)]])[(int)data[code[vpc+(3)]]];
    			vpc+=68;
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
            string time = String.Format("   {0}    , sec", timespan.TotalSeconds);
            log = id + " " + runId + " warmed up in,      " + time;
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