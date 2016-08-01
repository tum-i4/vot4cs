using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortRecursive_class_default
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> testData;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();


        public static void RunLoopTests()
        {
            QuickSortRecursive_class_default lt = new QuickSortRecursive_class_default();
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
                Debug.WriteLine(i + " ##############");
                int[] unsorted_original = testData.ToArray();
                string t_original = Time_Operation("QuickSortRecursive_class_default", i, Quicksort_obfuscated, unsorted_original, WARMUP, ITERATIONS);
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
            string testName = "Performance#QuickSortRecursive_class_default_Check";
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
    int[] code = new int[100948];
    object[] data = new object[4079];
    int vpc = 27;

    code[41324]=1040;code[32760]=-965;code[57287]=-915;code[97308]=73;code[42601]=345;code[30153]=292;
    code[15222]=-162;code[25613]=40;code[80287]=688;code[54029]=-232;code[31883]=1043;code[89552]=551;
    code[92192]=186;code[83665]=-590;code[34949]=1287;code[82133]=-136;code[75492]=-146;code[15498]=-504;
    code[15082]=265;code[93278]=528;code[49816]=-881;code[88475]=775;code[23112]=-960;code[93498]=-249;
    code[29699]=1359;code[82983]=630;code[14663]=-428;code[73253]=480;code[93777]=759;code[10199]=-768;
    code[20734]=999;code[8395]=267;code[73135]=1382;code[77657]=1022;code[18377]=-863;code[26921]=-277;
    code[75852]=1309;code[82170]=-330;code[94966]=-558;code[39542]=1243;code[55356]=320;code[87827]=5;
    code[9365]=-597;code[20251]=296;code[62178]=403;code[27216]=113;code[40893]=1077;code[40999]=734;
    code[97370]=-77;code[99511]=-310;code[24908]=-708;code[11947]=-403;code[68359]=332;code[90944]=-447;
    code[41902]=143;code[65758]=880;code[31511]=-491;code[54969]=692;code[93848]=702;code[41834]=407;
    code[75934]=-374;code[19506]=551;code[79297]=1052;code[89247]=1300;code[52243]=-700;code[30641]=428;
    code[19287]=-712;code[65665]=78;code[41392]=577;code[73203]=399;code[26285]=1447;code[10464]=-605;
    code[91856]=293;code[13465]=-497;code[28929]=822;code[77133]=-291;code[96387]=56;code[52885]=1490;
    code[93253]=244;code[45782]=1140;code[65488]=1451;code[71071]=-263;code[15548]=-801;code[56638]=-509;
    code[55853]=-718;code[26948]=-254;code[96469]=1136;code[30566]=932;code[14826]=-913;code[71747]=-330;
    code[69426]=706;code[63970]=970;code[35948]=-951;code[62250]=921;code[59729]=635;code[51237]=1280;
    code[17911]=1172;code[91981]=-301;code[27759]=1021;code[440]=1075;code[96546]=1342;code[65414]=-567;
    code[46657]=163;code[33120]=-750;code[12093]=876;code[85738]=1222;code[79436]=-537;code[16988]=1414;
    code[35019]=1289;code[94765]=-665;code[46763]=981;code[61060]=1247;code[61134]=-114;code[12241]=-784;
    code[95224]=-943;code[50291]=-155;code[3077]=1201;code[31460]=877;code[3511]=150;code[32927]=1226;
    code[69823]=290;code[65481]=1102;code[81257]=546;code[12664]=1479;code[70747]=1363;code[94169]=-102;
    code[87826]=1175;code[37025]=-591;code[33509]=872;code[57316]=-731;code[34737]=-397;code[15851]=-759;
    code[25490]=278;code[86658]=1265;code[88209]=43;code[93997]=1216;code[59506]=-880;code[44674]=1367;
    code[14529]=909;code[9495]=1467;code[23128]=-677;code[38933]=1495;code[9101]=-653;code[47249]=-600;
    code[51880]=-631;code[42294]=-286;code[90097]=-454;code[55178]=125;code[36269]=379;code[59403]=-266;
    code[76738]=-452;code[11926]=-292;code[1422]=-885;code[77712]=1054;code[43163]=49;code[2005]=420;
    code[66113]=452;code[88681]=-463;code[86400]=-603;code[667]=-716;code[4359]=745;code[39597]=814;
    code[100783]=613;code[100349]=-73;code[50618]=1481;code[59320]=480;code[17708]=1000;code[22894]=-976;
    code[1126]=-745;code[99329]=-891;code[37252]=615;code[73970]=-765;code[12919]=1127;code[63683]=-221;
    code[34329]=-171;code[59983]=-500;code[55044]=187;code[25288]=-845;code[83484]=-20;code[28780]=-79;
    code[5267]=-3;code[32358]=87;code[84009]=69;code[39635]=1136;code[35736]=1171;code[20558]=884;
    code[17665]=1406;code[75166]=-8;code[97447]=-255;code[60365]=-632;code[1464]=705;code[3112]=-576;
    code[40201]=-32;code[4719]=751;code[55505]=-589;code[18457]=547;code[82483]=538;code[100111]=1425;
    code[32861]=-256;code[26435]=750;code[46263]=940;code[96677]=178;code[12935]=1101;code[2556]=456;
    code[73712]=1133;code[9766]=322;code[80170]=-656;code[35757]=-76;code[37157]=-623;code[3724]=112;
    code[38468]=730;code[30760]=-527;code[69229]=461;code[94547]=399;code[98017]=936;code[7225]=669;
    code[3662]=1244;code[69569]=-405;code[73152]=398;code[4189]=394;code[36541]=160;code[97957]=741;
    code[6860]=634;code[83261]=698;code[26349]=554;code[60771]=-564;code[26321]=1042;code[32208]=915;
    code[47603]=920;code[79307]=358;code[91246]=163;code[61738]=1389;code[78924]=72;code[49722]=1240;
    code[45272]=-710;code[65126]=1021;code[11044]=197;code[8369]=1292;code[72847]=520;code[12248]=-921;
    code[76706]=-358;code[30155]=-128;code[17412]=1242;code[41080]=-452;code[58425]=1307;code[77390]=1390;
    code[78109]=245;code[66002]=1241;code[86065]=-964;code[92326]=597;code[16296]=1321;code[23315]=-638;
    code[98600]=983;code[6582]=953;code[74102]=5;code[4504]=1158;code[65318]=884;code[79102]=616;
    code[16843]=-344;code[79064]=1212;code[2230]=-317;code[32057]=313;code[35266]=722;code[3525]=528;
    code[83313]=-534;code[6492]=767;code[70024]=206;code[87860]=1078;code[2642]=-616;code[37584]=-53;
    code[83962]=563;code[48982]=-559;code[88660]=1258;code[31212]=-951;code[72119]=-983;code[73645]=475;
    code[23364]=-926;code[62265]=1220;code[61667]=763;code[80318]=-281;code[76558]=134;code[96532]=368;
    code[34105]=-156;code[17122]=-589;code[89184]=1380;code[62645]=-968;code[89864]=10;code[5363]=-9;
    code[79549]=-648;code[65341]=115;code[38329]=-963;code[90543]=1045;code[46128]=185;code[48001]=659;
    code[87380]=1455;code[22261]=-199;code[36145]=-789;code[62663]=-56;code[67543]=1344;code[84669]=351;
    code[74068]=-639;code[13773]=905;code[39015]=791;code[70646]=1068;code[98583]=-450;code[10109]=174;
    code[5865]=-126;code[91675]=858;code[56215]=-655;code[9147]=1158;code[87030]=264;code[30185]=1253;
    code[73858]=-251;code[66128]=1014;code[79073]=688;code[73452]=1125;code[30507]=-734;code[71901]=-413;
    code[88686]=-664;code[43583]=851;code[78175]=620;code[69388]=613;code[89038]=876;code[26515]=-979;
    code[17797]=1193;code[82881]=327;code[85506]=1437;code[68492]=-430;code[85355]=-413;code[3087]=-784;
    code[6190]=1235;code[4448]=-247;code[49711]=-376;code[16930]=1378;code[64341]=682;code[87305]=55;
    code[71296]=-125;code[9001]=-465;code[82603]=633;code[1945]=1452;code[3747]=616;code[63540]=1264;
    code[86226]=-509;code[336]=-183;code[43221]=210;code[39327]=608;code[10510]=-138;code[68564]=1200;
    code[60978]=-36;code[15452]=580;code[58841]=-222;code[37454]=258;code[1259]=-3;code[83260]=242;
    code[89439]=161;code[41367]=-520;code[21791]=-877;code[5004]=36;code[26714]=-655;code[45143]=-261;
    code[24877]=1101;code[52825]=-618;code[28612]=-447;code[32107]=-97;code[67721]=-478;code[61572]=80;
    code[50516]=-33;code[40192]=814;code[27825]=-685;code[90196]=138;code[37529]=265;code[44521]=1409;
    code[7509]=-507;code[43158]=-864;code[29827]=-339;code[62152]=164;code[94769]=1142;code[38947]=855;
    code[79538]=-456;code[22191]=977;code[8155]=158;code[83393]=692;code[86263]=1443;code[69818]=1072;
    code[65754]=-191;code[14033]=-654;code[24690]=1479;code[93286]=850;code[40341]=399;code[7955]=-786;
    code[80143]=-342;code[6638]=15;code[59875]=-641;code[49815]=608;code[120]=639;code[94687]=-856;
    code[91491]=-744;code[37808]=1270;code[68669]=909;code[11015]=-758;code[51068]=496;code[40702]=1429;
    code[12673]=193;code[22347]=1367;code[94190]=614;code[34583]=-430;code[14034]=-666;code[100654]=1043;
    code[40155]=49;code[8482]=776;code[48860]=-880;code[83549]=1488;code[38932]=-797;code[23433]=-645;
    code[62318]=-961;code[6038]=589;code[45476]=1454;code[58551]=-512;code[86842]=-766;code[28341]=-711;
    code[93133]=366;code[71689]=-112;code[31630]=774;code[92748]=931;code[10637]=393;code[51526]=-349;
    code[68627]=-4;code[61866]=143;code[77833]=19;code[59168]=-890;code[24741]=-802;code[33271]=1292;
    code[59147]=767;code[78516]=-608;code[55914]=1004;code[96609]=-241;code[14037]=1420;code[79542]=1343;
    code[34142]=180;code[68856]=689;code[16395]=149;code[3708]=-850;code[51024]=998;code[96497]=-871;
    code[37254]=-694;code[42820]=131;code[51263]=-409;code[87906]=1108;code[21900]=982;code[77681]=516;
    code[94072]=904;code[22059]=-242;code[60588]=-484;code[12253]=779;code[61637]=688;code[12041]=-253;
    code[73252]=1275;code[89028]=963;code[4292]=-327;code[41561]=966;code[75803]=814;code[79551]=78;
    code[38126]=261;code[80355]=1256;code[9823]=1361;code[72733]=363;code[70932]=-811;code[75113]=1;
    code[24347]=833;code[46426]=-253;code[68440]=-390;code[44552]=734;code[326]=-687;code[73373]=494;
    code[35784]=-787;code[80839]=1368;code[38488]=1457;code[86368]=-485;code[98285]=967;code[93457]=-761;
    code[41446]=-454;code[62022]=664;code[96392]=435;code[60180]=625;code[16763]=202;code[54933]=-227;
    code[81725]=-718;code[10958]=266;code[28719]=-765;code[43220]=-370;code[78502]=-505;code[55335]=-971;
    code[14517]=932;code[16550]=799;code[22211]=345;code[43114]=135;code[81507]=-90;code[89670]=148;
    code[63576]=938;code[74577]=72;code[53420]=-808;code[43570]=1183;code[54637]=228;code[13918]=-329;    data[2634]=-396;
code[38]=2029;code[1672]=864;    data[3990]=760;
    data[1413]=-987;
code[374]=9824;code[974]=2758;code[128]=3555;    data[328]=407;
code[496]=18;code[1345]=699;code[1820]=699;code[585]=4740;    data[594]=536;
code[1197]=6997;    data[1377]=193;
code[747]=1203;code[1080]=3492;code[339]=2209;code[1339]=1254;code[1588]=919;code[1998]=1010;    data[1557]=false;
code[212]=2956;    data[1908]=-332;
code[1052]=758;code[960]=699;code[1735]=3593;code[1032]=3716;code[182]=3759;    data[2088]=-698;
code[1273]=1774;code[1859]=3416;    data[1010]=69;
    data[647]=-243;
    data[2450]=-130;
    data[153]=614;
    data[3241]=-998;
    data[3395]=522;
code[378]=2868;code[1971]=2582;code[82]=303;code[245]=919;code[545]=571;    data[1055]=-39;
    data[2480]=-520;
    data[105]=-434;
    data[3823]=-599;
    data[3668]=-854;
    data[3562]=69;
code[899]=706;    data[550]=415;
code[1123]=954;code[248]=2051;    data[3550]=778;
    data[71]=-828;
    data[3813]=527;
code[369]=3231;    data[718]=700;
    data[1248]=69;
code[894]=3779;code[2078]=2128;    data[2035]=-738;
    data[1860]=494;
code[1819]=2817;code[922]=2226;    data[403]=left;
code[361]=3767;    data[1927]=-972;
code[2077]=462;code[1135]=1393;    data[1106]=-296;
    data[1584]=907;
    data[706]=1;
    data[748]=-516;
    data[369]=794;
    data[3243]="";
    data[226]=79;
code[1333]=7920;code[1404]=3714;code[716]=538;    data[2568]=-432;
code[1516]=3416;    data[1203]=-175;
code[1979]=3311;code[1671]=3874;code[852]=3211;code[93]=3965;code[2120]=1338;    data[1338]=0;
code[813]=3444;    data[1227]=-667;
    data[1547]=964;
code[399]=3324;code[301]=3605;code[434]=3714;code[1906]=3311;    data[3058]=114;
    data[2048]=false;
code[1070]=6474;    data[2079]=426;
code[1839]=3572;code[2080]=667;    data[1205]=902;
    data[2081]=-871;
code[1551]=2850;    data[2145]=-774;
code[1530]=3801;code[430]=2996;code[324]=3709;    data[2868]=-777;
    data[799]=-31;
code[146]=464;code[311]=1958;    data[2750]=-970;
    data[1895]=-857;
code[1668]=403;code[918]=919;code[699]=2547;code[520]=1106;code[515]=2132;code[1216]=3880;code[1835]=1830;    data[1630]=-225;
code[532]=3957;code[1762]=2012;    data[1729]=905;
        data[699]=(int[])elements;
code[1132]=2013;code[1392]=3714;code[1852]=920;code[246]=6997;code[848]=3253;    data[1890]=12;
code[1731]=3346;code[1026]=1138;code[533]=2813;    data[1593]=90;
code[539]=1452;code[438]=833;code[1089]=919;code[743]=2590;code[1146]=1198;code[1211]=699;    data[165]=-617;
code[893]=1039;    data[3882]=-205;
code[1994]=3710;code[1969]=9824;    data[3690]=128;
    data[2012]=175;
    data[2314]=-169;
code[1252]=2225;code[1267]=8365;    data[1631]=-318;
code[912]=3493;    data[1726]=259;
    data[999]=-386;
code[437]=300;code[1470]=919;code[1141]=430;code[127]=2438;    data[2355]=22;
    data[3487]=-985;
code[1477]=919;code[590]=3714;code[808]=521;code[1568]=3714;code[35]=1029;code[1414]=706;code[1949]=2251;    data[2610]=792;
code[46]=2745;code[377]=3149;code[209]=2634;code[896]=1458;    data[1746]=-929;
    data[3211]=243;
code[78]=3302;code[1179]=3714;code[641]=5635;code[1789]=919;    data[944]=-726;
    data[2970]=626;
code[815]=1345;code[1295]=699;code[335]=919;code[331]=1359;code[639]=3831;code[457]=1111;    data[3856]=276;
    data[440]=853;
code[658]=541;code[441]=3536;code[981]=1425;    data[3370]=660;
code[1330]=919;code[668]=469;code[124]=2794;code[632]=3714;code[1941]=649;code[773]=1507;code[1975]=993;code[772]=1408;code[298]=2850;    data[2593]=3;
code[1737]=9824;code[749]=1939;    data[3759]=2;
code[1656]=3619;    data[578]=-641;
    data[1548]=80;
    data[645]=922;
    data[3569]=88;
code[714]=3416;code[2038]=6216;code[102]=919;    data[2013]=-423;
    data[2581]=999;
    data[3559]=837;
code[2052]=699;code[1447]=1891;code[136]=403;code[655]=1111;code[775]=107;code[541]=586;code[1035]=1980;code[1458]=706;    data[3840]=215;
    data[1298]=180;
    data[3005]=78;
code[1319]=1662;    data[1600]=639;
    data[3109]=606;
    data[1762]=441;
code[205]=2794;    data[581]=-773;
code[1388]=3787;    data[3014]=-976;
code[187]=7387;code[2058]=2137;    data[2861]=-640;
code[1481]=2854;    data[923]=201;
code[1473]=2374;code[1053]=3369;    data[253]=-592;
    data[2826]=561;
    data[3705]=526;
    data[955]=-603;
    data[3796]=-440;
    data[3443]=737;
code[184]=3164;code[1399]=4740;code[1465]=561;    data[2794]=319;
code[1580]=109;code[735]=496;code[370]=3735;    data[3136]=386;
code[1504]=1243;    data[2850]=false;
    data[2018]=272;
code[1545]=1365;code[1069]=3714;code[1449]=3356;code[376]=1549;code[1210]=3124;code[1272]=2836;code[1328]=2935;    data[3401]=591;
code[1627]=3416;code[2021]=464;code[265]=1111;code[1455]=1458;code[967]=1111;    data[1591]=-98;
code[753]=2048;code[815]=3467;    data[2688]=-921;
    data[1111]=776;
code[185]=613;code[623]=202;    data[387]=675;
code[343]=3240;    data[3808]=-114;
    data[758]=false;
    data[402]=-460;
    data[586]=251;
    data[2703]=-400;
code[354]=3225;code[1153]=1762;    data[1549]=-10;
    data[3565]=711;
    data[3324]=1306;
code[329]=1934;code[315]=3714;    data[593]=-913;
code[2063]=3714;code[387]=2794;    data[2113]=-82;
    data[2983]=-262;
    data[2858]=-328;
    data[3143]=-417;
code[779]=919;code[1626]=3097;code[1902]=464;code[403]=1248;code[1250]=919;code[943]=2048;code[1680]=2036;    data[3774]=-763;
code[1806]=6216;    data[1266]=-209;
    data[2161]=-656;
    data[2330]=569;
    data[1970]=-246;
code[1087]=458;    data[3214]=-69;
code[1530]=2762;code[260]=699;code[2084]=3593;    data[385]=-969;
    data[2193]=259;
code[571]=2646;    data[420]=434;
code[2042]=476;    data[1466]=-547;
code[831]=2035;    data[1772]=226;
code[2061]=1978;code[1046]=647;code[1574]=298;code[827]=9824;code[384]=2850;code[367]=2286;code[777]=1111;    data[2849]=-873;
code[443]=5635;code[997]=2917;    data[1268]=140;
    data[2665]=-697;
    data[736]=38;
code[316]=6474;code[1051]=170;code[1865]=1449;code[214]=1434;    data[1365]=0;
code[1009]=2812;    data[231]=69;
code[1347]=382;    data[818]=-698;
code[27]=5706;code[1078]=2718;code[1766]=266;code[1011]=2105;    data[2921]=89;
    data[490]=-135;
code[512]=106;code[1199]=3061;code[228]=2634;code[1973]=2450;code[73]=464;code[636]=833;    data[3864]=-467;
code[578]=3714;code[131]=4740;    data[1522]=407;
code[216]=3129;    data[204]=642;
code[1896]=870;code[1922]=3923;    data[3205]=319;
    data[3146]=-192;
code[1057]=3776;    data[3034]=-138;
code[1225]=2571;    data[3714]=-662;
code[25]=3345;code[7]=3780;code[1138]=758;    data[1144]=-85;
    data[1388]=-391;
    data[3190]=800;
code[1017]=3416;    data[3121]=499;
code[586]=2335;code[1481]=2441;code[957]=3417;    data[1592]=-671;
    data[1655]=-5;
code[1674]=1557;code[2144]=6723;    data[266]=69;
    data[186]=13;
code[1863]=1126;code[1888]=2080;    data[2571]=470;
code[1617]=2078;code[71]=326;code[1830]=892;    data[3880]=-903;
    data[2590]=-251;
code[79]=5706;code[752]=1703;    data[197]=-646;
    data[833]=false;
    data[571]=69;
code[2158]=1310;code[1269]=699;    data[2421]=422;
    data[2132]=80;
code[969]=919;    data[2243]=-702;
code[50]=3714;    data[2080]=0;
code[2087]=2717;    data[176]=148;
code[1670]=919;code[606]=1032;code[178]=434;code[453]=699;    data[3255]=-57;
    data[3924]=-222;
    data[3787]=-937;
code[1157]=231;    data[3619]=-1306;
    data[1280]=228;
code[1029]=326;code[2141]=3243;    data[2848]=-641;
    data[3641]=548;
code[600]=706;code[261]=2855;code[2094]=2205;code[21]=403;code[767]=3417;    data[2392]=-22;
code[879]=1332;code[1624]=2520;    data[1532]=179;
code[1727]=1262;code[783]=583;code[2091]=3416;code[1183]=1294;code[1900]=3714;code[651]=699;    data[464]=right;
code[1741]=1227;code[1831]=403;code[1409]=2871;code[30]=2939;    data[974]=-761;
code[1142]=449;    data[2625]=33;
code[526]=833;code[911]=919;code[1128]=9824;    data[919]=582;
code[1126]=2355;code[1923]=1861;code[1283]=3952;    data[3944]=-868;
code[1464]=3338;code[516]=9824;    data[3843]=-133;
    data[1994]=-754;
    data[1952]=106;
code[37]=429;    data[2819]=-363;
    data[3311]=false;
code[1265]=3714;    data[3019]=-522;
    data[3949]=756;
code[1747]=1557;    data[3710]=175;
    data[284]=-966;
code[1569]=6474;code[91]=604;code[2065]=2099;    data[2870]=76;
    data[386]=-312;
code[1912]=2036;code[1441]=1660;    data[2190]=-514;
code[770]=699;    data[533]=-570;
    data[1894]=-674;
code[837]=2048;    data[436]=-110;
code[856]=3562;code[1182]=3024;code[1355]=3880;
    return (string)InstanceInterpreterVirtualization_QuickSortRecursive_class_default_1559(vpc, data, code);

}

        public static string Time_Operation(string id, int runId, Func<int[], int, int, string> method, int[] elements, int warmup, int iterations)
        {

            int op = 0;
            string log = runId + " warming ... " + warmup + " times X elements " + elements.Length;
            Output(log);

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < warmup; i++)
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

            time = String.Format("   {0}   , sec", timespan.TotalSeconds);
            log = id + " " + runId + " finished in,      " + time;
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

private object InstanceInterpreterVirtualization_QuickSortRecursive_class_default_1559(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 7920:
                ((int[])data[code[vpc + (12)]])[(int)data[code[vpc + (-3)]]] = (int)data[code[vpc + (22)]];
                vpc += 66;
                break;
            case 7387:
                data[code[vpc + (22)]] = (int)data[code[vpc + (18)]] / (int)data[code[vpc + (-5)]];
                vpc += 59;
                break;
            case 3416:
                vpc += (int)data[code[vpc + (29)]];
                vpc += 53;
                break;
            case 6474:
                data[code[vpc + (-18)]] = (int)data[code[vpc + (-1)]] <= (int)data[code[vpc + (19)]];
                vpc += 58;
                break;
            default:
                data[code[vpc + (4)]] = (bool)data[code[vpc + (10)]] ? (int)data[code[vpc + (29)]] : (int)data[code[vpc + (25)]];
                vpc += (int)data[code[vpc + (4)]];
                break;
            case 1458:
                data[code[vpc + (15)]] = (int)data[code[vpc + (22)]] - (int)data[code[vpc + (3)]];
                vpc += 61;
                break;
            case 4740:
                data[code[vpc + (-7)]] = (int)data[code[vpc + (5)]] + (int)data[code[vpc + (15)]];
                vpc += 56;
                break;
            case 6723:
                return (string)data[code[vpc + (-3)]];
                vpc += 61;
            case 6997:
                data[code[vpc + (19)]] = ((int[])data[code[vpc + (14)]])[(int)data[code[vpc + (-18)]]];
                vpc += 70;
                break;
            case 8365:
                ((int[])data[code[vpc + (28)]])[(int)data[code[vpc + (-2)]]] = ((int[])data[code[vpc + (2)]])[(int)data[code[vpc + (-17)]]];
                vpc += 66;
                break;
            case 5706:
                data[code[vpc + (23)]] = (int)data[code[vpc + (-6)]];
                vpc += 52;
                break;
            case 3417:
                data[code[vpc + (-14)]] = (int)data[code[vpc + (10)]] < ((int[])data[code[vpc + (3)]])[(int)data[code[vpc + (12)]]];
                vpc += 60;
                break;
            case 2036:
                data[code[vpc + (-6)]] = (int)data[code[vpc + (-12)]] < (int)data[code[vpc + (-10)]];
                vpc += 57;
                break;
            case 5635:
                data[code[vpc + (-5)]] = ((int[])data[code[vpc + (10)]])[(int)data[code[vpc + (-9)]]] < (int)data[code[vpc + (14)]];
                vpc += 73;
                break;
            case 6216:
                Quicksort_obfuscated((int[])data[code[vpc + (14)]], (int)data[code[vpc + (25)]], (int)data[code[vpc + (-17)]]);
                vpc += 53;
                break;
        }
    }

    return null;
}


    }
}