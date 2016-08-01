using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Recursive_method_modified
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
            BinarySearch_Recursive_method_modified bs = new BinarySearch_Recursive_method_modified();
            time_warmup.Clear();
            time_run.Clear();
            init_code();
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
            result += "     t_method_modified";
//            result += "     t_class";
//            result += " t_method_default";
//            result += " t_class_default";
//            result += "     t_method_junk";
//            result += "     t_class_junk";
            result += " " + "\n";


            int[] unsorted_original = testData.ToArray();
            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {                
                Console.WriteLine(i+ " ##############");
                Debug.WriteLine(i+ " ##############");
                string t_original = Time_Operation(i+ " BinarySearch_Recursive_method_modified", BinarySearchRecursive_obfuscated);

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

        private static int[] code;
        private static void init_code()
        {
            code = new int[100277];
            code[45688] = 927; code[50134] = 192; code[10902] = -765; code[38751] = 135; code[8327] = -918; code[65040] = 320;
            code[42877] = -634; code[84496] = 1140; code[19379] = -644; code[80815] = 943; code[41045] = 756; code[82672] = 383;
            code[36254] = -397; code[62844] = 1191; code[29597] = -93; code[51427] = 952; code[83797] = -197; code[41475] = -15;
            code[79423] = 1015; code[75546] = 856; code[21956] = 570; code[13697] = -749; code[57002] = -841; code[64933] = -500;
            code[89961] = 1417; code[52417] = -137; code[27844] = -256; code[47841] = 882; code[94918] = 1366; code[11575] = 1168;
            code[46868] = 274; code[15933] = 799; code[52159] = 1169; code[69450] = -735; code[73506] = 120; code[6427] = -33;
            code[39009] = -842; code[55982] = 952; code[56745] = 809; code[98773] = -256; code[59535] = 66; code[98208] = -180;
            code[84264] = -582; code[50465] = 344; code[84656] = 651; code[44903] = 1113; code[69269] = 1214; code[27594] = 772;
            code[47057] = 41; code[58204] = 751; code[37233] = 353; code[46827] = 122; code[90522] = -661; code[95900] = -465;
            code[74161] = 739; code[18775] = -444; code[96413] = 1044; code[27450] = -899; code[53201] = 1076; code[88209] = -119;
            code[36539] = -614; code[26275] = -819; code[47] = -454; code[69817] = 257; code[79034] = 1123; code[31272] = -627;
            code[14380] = -290; code[92889] = -869; code[96235] = 326; code[42676] = 761; code[21168] = -278; code[80044] = -630;
            code[47455] = -438; code[88651] = 1182; code[61385] = -414; code[17896] = 596; code[53842] = -431; code[33733] = -459;
            code[28002] = -14; code[44962] = 710; code[44065] = 133; code[42734] = 1225; code[38514] = -906; code[7952] = 693;
            code[89390] = -447; code[8122] = -1000; code[40609] = -563; code[14197] = -812; code[35751] = -716; code[60096] = 938;
            code[33538] = 1058; code[89339] = 384; code[67263] = 682; code[61403] = 1289; code[95041] = 774; code[77531] = 413;
            code[8235] = 853; code[26591] = 894; code[86515] = 1269; code[76630] = 88; code[14617] = -483; code[98426] = -23;
            code[15389] = -554; code[23437] = -96; code[8640] = -348; code[86237] = -587; code[79730] = 682; code[35069] = 540;
            code[56388] = 1181; code[22014] = 777; code[42677] = -591; code[73148] = -546; code[44937] = 289; code[92044] = 658;
            code[91236] = -41; code[21326] = 121; code[35052] = -590; code[63136] = -681; code[84401] = 250; code[40132] = 230;
            code[44064] = -374; code[83177] = 717; code[85215] = 519; code[77228] = 22; code[39274] = 622; code[19603] = 1475;
            code[69029] = -867; code[972] = 1455; code[47866] = 999; code[94530] = 594; code[26123] = 425; code[45330] = 756;
            code[4841] = 28; code[81819] = 577; code[4348] = -445; code[77664] = -845; code[47355] = 817; code[27225] = -563;
            code[33508] = -894; code[33275] = 1101; code[74762] = 271; code[27266] = -348; code[18877] = -445; code[76231] = -260;
            code[15473] = 618; code[65210] = -896; code[55891] = 906; code[23246] = 1173; code[80057] = -683; code[64032] = 96;
            code[79391] = -653; code[36677] = -577; code[87689] = -667; code[51947] = 1403; code[78391] = 1086; code[64974] = 86;
            code[46936] = -745; code[89463] = 879; code[29905] = -523; code[51558] = 1064; code[65297] = 299; code[47810] = -11;
            code[57334] = 831; code[50626] = 774; code[49672] = 5; code[37783] = -483; code[40517] = 1233; code[4886] = 516;
            code[14340] = -745; code[38745] = -863; code[70627] = 997; code[51595] = -201; code[100230] = -462; code[57529] = 137;
            code[87270] = 200; code[57262] = 517; code[61459] = 1031; code[78941] = -320; code[66410] = 1424; code[59947] = -646;
            code[63011] = 1020; code[46713] = -52; code[45899] = 102; code[3073] = 436; code[5365] = -286; code[61040] = -511;
            code[80702] = 147; code[12191] = 1130; code[513] = -608; code[39740] = -110; code[15946] = -876; code[84178] = -962;
            code[83345] = 924; code[59583] = 478; code[10648] = 941; code[94684] = -568; code[50589] = -389; code[42779] = 1240;
            code[33408] = -663; code[86442] = 396; code[18544] = 1497; code[40273] = 461; code[87376] = -63; code[80459] = -616;
            code[69297] = 1337; code[26769] = 263; code[57518] = -396; code[98543] = 446; code[97147] = 126; code[54989] = 720;
            code[84900] = 98; code[46975] = -308; code[34236] = 89; code[69330] = 400; code[3264] = -437; code[52042] = 1175;
            code[29576] = 1094; code[17171] = -601; code[64988] = -363; code[14430] = 140; code[96990] = 101; code[90282] = -573;
            code[51109] = 97; code[60115] = -343; code[26263] = 1119; code[92981] = 1206; code[58822] = -566; code[71397] = 864;
            code[53206] = -689; code[24389] = 89; code[68563] = -395; code[12151] = 163; code[41723] = -8; code[21089] = 839;
            code[7059] = 1056; code[93312] = 784; code[30750] = -770; code[72288] = 15; code[54038] = -257; code[76928] = 1256;
            code[83844] = 71; code[29906] = -539; code[29909] = 590; code[28430] = -698; code[12595] = 63; code[63109] = 308;
            code[1163] = 770; code[77440] = 812; code[32016] = 86; code[75710] = -718; code[22927] = 1158; code[19299] = 97;
            code[91993] = -467; code[57752] = 235; code[45428] = -236; code[20736] = -417; code[35859] = -149; code[60125] = -362;
            code[94657] = 1341; code[16773] = 949; code[11361] = -777; code[61205] = 612; code[19394] = 18; code[70431] = 496;
            code[32097] = 1489; code[8716] = -740; code[54381] = 635; code[67567] = 1431; code[23672] = 1147; code[26793] = -788;
            code[6063] = 973; code[66983] = 1049; code[21935] = -10; code[16618] = 677; code[10888] = 292; code[78320] = -44;
            code[26825] = 1438; code[100231] = -652; code[25385] = 369; code[24641] = 275; code[51230] = 1443; code[17463] = 142;
            code[21947] = -744; code[69284] = 758; code[66878] = 567; code[1919] = -788; code[67123] = -795; code[72120] = -190;
            code[42246] = 976; code[42727] = 993; code[24217] = -922; code[49124] = 1007; code[21542] = 760; code[83889] = 417;
            code[65655] = 336; code[72144] = 721; code[61505] = 892; code[57568] = -793; code[61681] = -473; code[60259] = -710;
            code[70710] = 156; code[390] = 204; code[49929] = 740; code[71528] = -537; code[25682] = 688; code[72003] = 156;
            code[12185] = 121; code[26940] = 198; code[48890] = -73; code[24299] = 286; code[26684] = -691; code[4868] = -669;
            code[91002] = -174; code[47281] = 1280; code[50958] = 590; code[71086] = -474; code[19013] = -225; code[9241] = 947;
            code[2771] = -980; code[30595] = 296; code[99365] = 628; code[31171] = 1448; code[81865] = -358; code[56850] = -588;
            code[48970] = -764; code[59709] = -390; code[97119] = -785; code[85228] = 453; code[41501] = 1178; code[57566] = -582;
            code[22528] = 1002; code[67892] = 549; code[96928] = 269; code[27374] = 1028; code[35724] = 223; code[45297] = 198;
            code[6618] = 809; code[52517] = 536; code[81533] = -827; code[31696] = 626; code[76584] = -234; code[42517] = 33;
            code[4087] = 162; code[24260] = -742; code[46137] = 277; code[36621] = -610; code[43540] = -656; code[29480] = -526;
            code[97697] = 727; code[1263] = -229; code[98659] = 888; code[81091] = 1496; code[64479] = -710; code[17848] = -388;
            code[56412] = -413; code[77022] = -139; code[55684] = 1308; code[40461] = 1295; code[37798] = -341; code[58074] = 254;
            code[26639] = -576; code[35234] = 1113; code[12472] = -262; code[4519] = 1320; code[43086] = -166; code[64225] = -695;
            code[5688] = -982; code[66862] = -980; code[49926] = 63; code[77254] = 1311; code[28770] = 1492; code[54223] = -438;
            code[74489] = -949; code[60257] = 276; code[73640] = -61; code[81526] = 776; code[11210] = 277; code[4325] = 1035;
            code[40521] = 1408; code[87681] = -132; code[7130] = -376; code[81741] = -428; code[59632] = 614; code[28860] = 370;
            code[25734] = -12; code[42136] = 1379; code[49456] = 636; code[21539] = -329; code[63066] = -684; code[10274] = -741;
            code[69649] = 335; code[19427] = -866; code[52217] = 1324; code[1037] = 364; code[96681] = 1131; code[60583] = 336;
            code[55234] = 57; code[85583] = -908; code[18242] = -221; code[63198] = -758; code[73486] = -868; code[25484] = -153;
            code[95833] = 1153; code[21806] = 143; code[29690] = 936; code[18578] = -306; code[86328] = 926; code[65475] = 342;
            code[5629] = 903; code[71002] = 662; code[63737] = 854; code[58548] = 10; code[79324] = 1214; code[40200] = -825;
            code[80329] = -556; code[8688] = -208; code[49757] = -987; code[37189] = 604; code[28091] = 1136; code[9835] = 648;
            code[71433] = 382; code[25045] = -527; code[66915] = -184; code[67546] = 950; code[77207] = -209; code[98360] = 51;
            code[60552] = 1413; code[46253] = 1477; code[47031] = 1125; code[54960] = -825; code[46167] = -633; code[65796] = -705;
            code[68981] = 1170; code[78361] = 1138; code[40091] = -972; code[25738] = -497; code[66512] = -879; code[95512] = -794;
            code[49356] = -15; code[73878] = 161; code[21266] = 551; code[30118] = 211; code[19741] = 665; code[71510] = 327;
            code[54582] = -51; code[17313] = 75; code[30734] = -930; code[19957] = 413; code[89943] = -672; code[50305] = 997;
            code[54656] = 1045; code[38138] = 896; code[6014] = 948; code[75934] = 388; code[1292] = -54; code[50004] = -814;
            code[11364] = -792; code[86029] = 1099; code[84913] = -571; code[92398] = -946; code[15556] = -374; code[31187] = -951;
            code[84092] = 1066; code[89752] = 588; code[85196] = -32; code[18606] = -99; code[89506] = 1344; code[92202] = -16;
            code[24107] = 354; code[42561] = 43; code[91135] = -606; code[51936] = -587; code[88375] = -756; code[31760] = -443;
            code[17061] = -102; code[72039] = 813; code[21058] = 199; code[64567] = -264; code[50865] = -99; code[92260] = -417;
            code[88673] = -695; code[70754] = 563; code[19373] = -656; code[18264] = -561; code[16451] = 160; code[60089] = -238;
            code[74934] = 259; code[11329] = 1493; code[73471] = -637; code[13887] = 851; code[51128] = 680; code[46635] = 225;
            code[67072] = 150; code[15116] = 31; code[29462] = 562; code[88900] = 1199; code[62333] = -523; code[53469] = 967;
            code[45358] = 1230; code[97504] = 858; code[91829] = -648;

            code[717] = 859;
            code[943] = 3267;
            code[518] = 390; code[522] = 1075; code[810] = 1428;
            code[142] = 3848;
            code[1044] = 2186;
            code[759] = 1075; code[868] = 1730; code[972] = 2600;
            code[713] = 3739;
            code[1210] = 300; code[673] = 3899; code[234] = 2418; code[139] = 2012;
            code[721] = 3836; code[442] = 859; code[844] = 3739; code[330] = 7426; code[156] = 50;
            code[948] = 571;
            code[290] = 396; code[1159] = 2297; code[771] = 2934;
            code[534] = 3001; code[769] = 3615; code[537] = 1484; code[401] = 5130;
            code[882] = 702; code[328] = 1002; code[424] = 733; code[147] = 168;
            code[1069] = 134;
            code[335] = 475; code[1213] = 6803; code[82] = 3791; code[841] = 2904; code[584] = 2995; code[1130] = 3290; code[348] = 3884; code[587] = 314; code[149] = 14; code[644] = 1269; code[210] = 1307;
            code[535] = 2166;
            code[506] = 2993; code[541] = 3579;
            code[943] = 2105; code[1122] = 2464; code[77] = 475; code[583] = 2445;
            code[755] = 842; code[166] = 1113; code[869] = 859; code[762] = 1287;
            code[884] = 4728; code[1166] = 3081; code[519] = 3847; code[976] = 3416;
            code[247] = 899;
            code[225] = 1972;
            code[703] = 296;
            code[1139] = 4728; code[819] = 1852;
            code[313] = 3985; code[743] = 1455;
            code[851] = 2993; code[1137] = 475;
            code[426] = 3421; code[956] = 1613;

            code[220] = 8976;
            code[698] = 2934;
            code[842] = 382; code[694] = 1936;
            code[1048] = 270; code[887] = 3862; code[1143] = 1530; code[484] = 1627;
            code[1129] = 3642;
            code[162] = 3859; code[905] = 1339;
            code[753] = 2108; code[233] = 1652; code[979] = 3335; code[1020] = 501;
            code[454] = 3713; code[1124] = 859; code[284] = 3696;

            code[715] = 2619; code[817] = 702; code[470] = 3001; code[960] = 1092; code[469] = 1486; code[551] = 774;
            code[579] = 3739; code[1236] = 1132; code[821] = 1389;
            code[1051] = 3739; code[614] = 828;
            code[395] = 3739; code[525] = 3607; code[689] = 1502;
            code[141] = 1344;
            code[112] = 455;
            code[1203] = 2297; code[1068] = 7426; code[404] = 3884; code[234] = 1275; code[958] = 6803;
            code[465] = 1936;
            code[476] = 3773;
            code[351] = 3174;
            code[944] = 1334;
            code[1015] = 4027; code[757] = 2362; code[1142] = 592;
            code[106] = 955; code[1073] = 1389;
            code[333] = 2082; code[636] = 1632;
            code[1217] = 2863; code[153] = 1075; code[767] = 3576; code[875] = 3985;
            code[65] = 2524; code[1061] = 2915; code[180] = 2892; code[1199] = 328;
            code[527] = 3639; code[897] = 1936;
            code[529] = 1169; code[826] = 2232;
            code[605] = 349; code[1022] = 1266; code[902] = 57; code[461] = 3739;
            code[526] = 2875;
            code[589] = 6803;
            code[880] = 2497; code[74] = 2118;
            code[537] = 778;
            code[813] = 1474;
            code[165] = 2118;

            code[181] = 3; code[691] = 3961; code[1030] = 3609; code[460] = 5135;
            code[83] = 3268;
            code[150] = 3469;
            code[953] = 3898; code[92] = 3006;
            code[775] = 669; code[381] = 144;
            code[904] = 571; code[879] = 177; code[516] = 1002;
            code[80] = 3985; code[267] = 241; code[1152] = 1936;
            code[646] = 4027;
            code[277] = 4027;
            code[653] = 2402;
            code[642] = 110; code[1070] = 2904;
            code[699] = 7109; code[725] = 573; code[776] = 1449;
            code[1086] = 3290;
        }

//                [Obfuscation(Exclude = false, Feature = "virtualization; method")]
private static int BinarySearchRecursive_obfuscated(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    object[] data = new object[4367];
    int vpc = 83;

            data[3264] = -108;
            data[3213] = 859;
            data[702] = 336;
            data[1389] = 1; data[1780] = 155;
            data[2970] = -9; data[1307] = -1;
            data[2297] = -798;
            data[1543] = -675; data[2108] = 311;
            data[431] = 316; data[1989] = 196;
            data[2958] = -513;
            data[2934] = false; data[1028] = -875;
            data[475] = max; data[18] = -946;
            data[2766] = -806;
            data[2956] = -97; data[2284] = -141;
            data[196] = -730; data[344] = -263;
            data[3965] = 396; data[868] = 283;
            data[1722] = 828;
            data[3278] = 3; data[1266] = 202; data[3985] = min;
            data[3884] = 247; data[1565] = 988;
            data[182] = 828; data[3713] = 999;
            data[3933] = -856; data[3607] = 67;
            data[2402] = 571;
            data[961] = -250; data[761] = -744;
            data[571] = 259; data[927] = 505;
            data[14] = 177; data[3938] = -869;
            data[3687] = 913;
            data[3345] = -929;
            data[583] = -506; data[861] = -11;
            data[1531] = 782; data[3696] = 940;
            data[1694] = -885;
            data[123] = -907; data[3229] = 282;
            data[2540] = 677; data[1002] = 226;
            data[557] = -55; data[3725] = -723;
            data[2175] = 717; data[1555] = -443;
            data[2739] = -945; data[1511] = 581;
            data[1690] = 353;
            data[1085] = -531; data[2422] = 143;
            data[390] = 177;
            data[566] = -770; data[1966] = -186;
            data[1936] = (int[])inputArray;
            data[430] = 627;
            data[2342] = -176;
            data[671] = 531;
            data[2088] = -12; data[3260] = 885;
            data[2513] = -347;
            data[650] = 257; data[2989] = -11;
            data[3267] = -818; data[3259] = -515;
            data[3739] = 141; data[1287] = 67;
            data[334] = -93; data[2854] = -263;
    data[3883] = 461; data[1500] = 0; 
            data[2616] = 116;
            data[2104] = 542;
            data[1468] = 267; data[3451] = 349;
    data[3668] = -110; data[2617] = -98; 
            data[3001] = false;
            data[476] = -749;
            data[2288] = -108;
            data[2987] = 97; data[2585] = 186;
            data[2] = -263; data[842] = 309;
            data[3290] = -560; data[124] = 517;
            data[972] = 655;
            data[1662] = -495;
            data[2686] = 517;
            data[3833] = 177;
            data[859] = key;
            data[2690] = 192;
            data[765] = 44;
            data[144] = 2;
            data[1904] = 451;
            data[168] = -148; data[1706] = 139;
            data[1652] = -509;
            data[2095] = 54; data[911] = 63;
            data[50] = 67; data[2914] = -33;
            data[3993] = 934;
            data[2754] = -64;
            data[3439] = 629; data[913] = -646;
            data[1100] = 152; data[2645] = -88;
    data[2118] = false;  data[2736] = 285; 
            data[92] = 499; data[1265] = -844;
            data[786] = 708;
            data[3592] = 11;
            data[3476] = -952;
            while (true)
    {
    	switch(code[vpc])
    	{
    		case 5135:
    			data[code[vpc+(10)]]= (int)data[code[vpc+(-18)]]== ((int[])data[code[vpc+(5)]])[(int)data[code[vpc+(1)]]];
    			vpc+=62;
    			break;
    		case 7426:
    			data[code[vpc+(18)]]= (int)data[code[vpc+(-17)]]+ (int)data[code[vpc+(5)]];
    			vpc+=71;
    			break;
    		case 7109:
    			data[code[vpc+(-1)]]= (int)data[code[vpc+(18)]]< ((int[])data[code[vpc+(-5)]])[(int)data[code[vpc+(14)]]];
    			vpc+=60;
    			break;
    		case 4728:
    			data[code[vpc+(20)]]= BinarySearchRecursive_obfuscated((int[])data[code[vpc+(13)]], (int)data[code[vpc+(-15)]], (int)data[code[vpc+(-9)]], (int)data[code[vpc+(-2)]]);
    			vpc+=74;
    			break;
    		case 3268:
    			data[code[vpc+(-9)]]= (int)data[code[vpc+(-6)]]< (int)data[code[vpc+(-3)]];
    			vpc+=70;
    			break;
    		default:
    			return (int)data[code[vpc+(-10)]];
    			vpc+=57;
    		case 4027:
    			vpc += (int)data[code[vpc+(7)]];
    			vpc+=53;
    			break;
    		case 2232:
    			data[code[vpc+(-9)]]= (int)data[code[vpc+(18)]]- (int)data[code[vpc+(-5)]];
    			vpc+=58;
    			break;
    		case 1075:
    			data[code[vpc+(-6)]]=(bool)data[code[vpc+(12)]]?(int)data[code[vpc+(3)]]:(int)data[code[vpc+(-4)]];
    			vpc+=(int)data[code[vpc+(-6)]];
    			break;
    		case 5130:
    			data[code[vpc+(-6)]]= (int)data[code[vpc+(3)]]/ (int)data[code[vpc+(-20)]];
    			vpc+=59;
    			break;
    	}
    }

    return 0;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Recursive_method_modified";
            Program.Start_Check(testName);
            bool condition = true;

            init_code();

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


    }
}