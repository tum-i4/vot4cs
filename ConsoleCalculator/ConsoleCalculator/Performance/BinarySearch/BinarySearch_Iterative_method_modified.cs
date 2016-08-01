using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Iterative_method_modified
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
            BinarySearch_Iterative_method_modified bs = new BinarySearch_Iterative_method_modified();
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
            init_code();
//            result += "t_original";
//            result += "     t_method";
//            result += "     t_class";
//            result += " t_method_default";
//            result += " t_class_default";
            result += "     t_method_modified";
//            result += "     t_class_junk";
            result += " " + "\n";


            int[] unsorted_original = testData.ToArray();
            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {                
                Console.WriteLine(i+ " ##############");
                Debug.WriteLine(i+ " ##############");
                string t_original = Time_Operation(i+ " BinarySearch_Iterative_method_modified", BinarySearchIterative_obfuscated);

                result += " " + t_original;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);

            PrintTimes();
        }


        private static int[] code;

        private void init_code()
        {
            code = new int[100366];
            code[72689] = 1444; code[77318] = 570; code[63641] = -12; code[89069] = -707; code[72270] = -8; code[71906] = 1123;
            code[3008] = 446; code[68708] = 570; code[10735] = -153; code[74329] = 534; code[78066] = 825; code[95547] = -876;
            code[75946] = -564; code[37614] = -446; code[82635] = 1332; code[65198] = 170; code[9380] = 1146; code[1004] = -485;
            code[76404] = -465; code[3656] = 261; code[75183] = 9; code[64099] = 591; code[85572] = 1046; code[3221] = -3;
            code[18518] = -604; code[94389] = 713; code[25747] = 304; code[54546] = 1484; code[2575] = 801; code[87480] = 148;
            code[2079] = 664; code[29509] = 967; code[75020] = -380; code[75867] = -572; code[57079] = 195; code[86991] = 1232;
            code[30365] = -411; code[86773] = -66; code[9192] = -212; code[19800] = 1345; code[14313] = 1439; code[3741] = 662;
            code[99605] = 1410; code[21228] = 429; code[31635] = -960; code[18132] = -899; code[34369] = 442; code[48577] = -792;
            code[11025] = 1128; code[89251] = 510; code[6277] = 1152; code[83322] = 765; code[29276] = -882; code[38421] = -949;
            code[65945] = -577; code[90569] = 775; code[52509] = 1333; code[31792] = -888; code[63069] = 572; code[79764] = 958;
            code[3702] = -540; code[85921] = 381; code[29867] = 1064; code[55246] = 813; code[75459] = 952; code[26506] = -400;
            code[42754] = 482; code[87889] = -296; code[14620] = -173; code[37456] = 1362; code[58354] = -523; code[91810] = -636;
            code[11402] = 175; code[51950] = 22; code[26123] = 97; code[45668] = 201; code[5694] = -735; code[56939] = 1196;
            code[473] = -307; code[41014] = 164; code[49891] = 643; code[26980] = 1189; code[90873] = 655; code[28543] = 1325;
            code[5788] = -913; code[90245] = -257; code[25685] = 1124; code[20253] = 1115; code[27030] = 776; code[44070] = 1068;
            code[30946] = -647; code[46690] = -219; code[32731] = 958; code[18403] = -201; code[2584] = 1493; code[27810] = 1170;
            code[92573] = 1268; code[44940] = 1310; code[92537] = -903; code[24111] = 128; code[18655] = 468; code[35268] = -437;
            code[54196] = -606; code[22563] = -483; code[90754] = 803; code[61136] = -265; code[84144] = 453; code[15797] = -111;
            code[19281] = 1390; code[55177] = -695; code[48067] = 1411; code[90765] = -849; code[76062] = -923; code[37636] = -129;
            code[40357] = -306; code[92741] = -424; code[47190] = 1469; code[64378] = 802; code[79286] = -401; code[77551] = -579;
            code[56059] = 1441; code[41723] = -239; code[38952] = 1457; code[2991] = -148; code[75279] = -770; code[73465] = 1414;
            code[49088] = -705; code[97593] = -447; code[68563] = -273; code[46917] = 272; code[78551] = 1190; code[80769] = 566;
            code[80013] = -54; code[82711] = 1126; code[94332] = 91; code[56779] = 1380; code[18410] = -47; code[56556] = 256;
            code[55073] = 499; code[67477] = 937; code[117] = -916; code[60058] = -225; code[54770] = 1395; code[74405] = -120;
            code[1545] = 50; code[3783] = 247; code[77523] = -341; code[38721] = 705; code[17238] = 972; code[50911] = -977;
            code[15928] = -552; code[40259] = -217; code[52823] = 949; code[78529] = -731; code[55669] = 174; code[67514] = -792;
            code[62091] = 731; code[50969] = 871; code[27896] = 236; code[8111] = 1097; code[63966] = 180; code[83824] = 299;
            code[40032] = -834; code[18048] = 1299; code[99912] = 1203; code[33187] = 898; code[9294] = 657; code[61860] = 1054;
            code[63514] = -288; code[78661] = 914; code[17636] = 583; code[80024] = 363; code[75005] = 1386; code[88356] = -800;
            code[75859] = 592; code[40573] = 692; code[71093] = 670; code[37343] = 716; code[34527] = 1203; code[91796] = 148;
            code[60210] = 1156; code[11271] = 683; code[13981] = 1282; code[99429] = 1389; code[7632] = 714; code[11627] = 1482;
            code[71353] = -213; code[66576] = -991; code[67722] = -276; code[77537] = 111; code[18705] = -751; code[16451] = -105;
            code[47878] = 634; code[5139] = 61; code[29187] = 1324; code[47968] = 878; code[37163] = -190; code[16666] = -218;
            code[52315] = -691; code[40759] = 1085; code[96725] = 1311; code[396] = -826; code[52316] = 28; code[96964] = -17;
            code[487] = -80; code[1188] = -865; code[10910] = 175; code[27421] = 250; code[70131] = 884; code[19705] = 214;
            code[86507] = 415; code[66736] = -635; code[20869] = -90; code[62503] = -34; code[14934] = -125; code[48428] = 377;
            code[88687] = 1345; code[48247] = -346; code[9621] = -766; code[84016] = -836; code[68999] = 644; code[42108] = 1306;
            code[92125] = 59; code[64522] = 1250; code[5113] = 664; code[61651] = 918; code[93100] = 1301; code[97581] = -7;
            code[26059] = 1144; code[86517] = -608; code[79132] = 448; code[24559] = 636; code[88900] = 152; code[17121] = -575;
            code[99306] = -972; code[40570] = 512; code[92016] = -674; code[80113] = -490; code[14725] = 856; code[22923] = 960;
            code[72403] = 806; code[33706] = 207; code[73872] = 788; code[62545] = 1408; code[96962] = -792; code[214] = -405;
            code[23277] = 700; code[27839] = -730; code[41451] = 912; code[3688] = 142; code[25402] = 181; code[91397] = -902;
            code[26268] = -977; code[85360] = 992; code[12262] = 920; code[25166] = 293; code[63154] = -806; code[43717] = -836;
            code[24439] = 904; code[92186] = -574; code[84092] = -482; code[20499] = 1265; code[933] = -585; code[37423] = -409;
            code[85624] = 725; code[79408] = -46; code[70824] = 928; code[53307] = -378; code[81497] = -260; code[22191] = 816;
            code[86785] = 1065; code[84413] = -505; code[83553] = 212; code[61119] = -615; code[24543] = -472; code[86779] = 627;
            code[84959] = 1165; code[62125] = -886; code[26926] = -989; code[3032] = -761; code[63891] = 534; code[94743] = 80;
            code[98041] = 1172; code[81451] = 1144; code[54864] = -534; code[25470] = 1367; code[54272] = -521; code[30698] = -971;
            code[36762] = -985; code[7397] = 310; code[55906] = -454; code[99578] = 603; code[82845] = -650; code[53716] = 1098;
            code[15310] = 213; code[98416] = 1018; code[26708] = -687; code[9030] = -373; code[88529] = 22; code[22200] = 1408;
            code[67581] = 878; code[60970] = -856; code[96130] = 1293; code[11079] = 636; code[56236] = 517; code[68195] = -345;
            code[93412] = 264; code[54065] = 44; code[62391] = -244; code[60887] = 1091; code[33505] = 1430; code[70773] = -847;
            code[20687] = 115; code[68355] = 38; code[10233] = -863; code[13019] = 1393; code[78787] = -725; code[85414] = 1014;
            code[61346] = 1335; code[68623] = 1269; code[2976] = 1201; code[28019] = 363; code[80884] = 796; code[88003] = 900;
            code[58883] = 680; code[63154] = 449; code[80523] = -40; code[63192] = 753; code[4626] = 365; code[85481] = 278;
            code[23725] = 737; code[55461] = 263; code[47921] = 805; code[47881] = 1051; code[65717] = 832; code[80957] = 718;
            code[62096] = 746; code[81008] = 132; code[69541] = -601; code[25630] = 219; code[57145] = 1301; code[83170] = 74;
            code[42727] = 375; code[15558] = 1; code[48237] = -626; code[76244] = -838; code[8292] = -570; code[67404] = -164;
            code[32925] = 934; code[6812] = -791; code[24231] = -860; code[10588] = 1134; code[86863] = 1354; code[96443] = -741;
            code[57936] = -559; code[843] = 1215; code[29189] = -90; code[94565] = -211; code[86950] = -694; code[7991] = 1318;
            code[56919] = -809; code[34110] = 262; code[97679] = 854; code[60689] = 116; code[2717] = 181; code[12558] = 1297;
            code[9227] = -571; code[24708] = 282; code[81824] = 1437; code[56644] = 209; code[59131] = -872; code[82635] = -240;
            code[14185] = 1183; code[77700] = 796; code[23076] = -111; code[47000] = -487; code[69673] = -649; code[51850] = -588;
            code[71910] = 501; code[88374] = -691; code[33848] = 285; code[7683] = -739; code[5149] = -777; code[79724] = -702;
            code[11833] = 73; code[50216] = 1228; code[56038] = 489; code[33945] = 289; code[25403] = -911; code[36503] = -751;
            code[97096] = 1215; code[21742] = 677; code[422] = 1299; code[22567] = 1378; code[65738] = -797; code[79943] = -463;
            code[9472] = 101; code[14706] = -813; code[97838] = 796; code[25378] = -871; code[7933] = 637; code[60282] = 1001;
            code[85877] = 442; code[64932] = -755; code[80520] = -998; code[91517] = 702; code[23761] = 951; code[15700] = 127;
            code[29881] = 13; code[10091] = -672; code[86764] = 1107; code[46591] = -909; code[63498] = -287; code[79995] = -706;
            code[45094] = -342; code[54289] = 336; code[78567] = -221; code[2088] = -219; code[28656] = 39; code[81841] = 68;
            code[27384] = -684; code[14972] = 635; code[16998] = -711; code[98162] = -216; code[28512] = 738; code[77990] = 423;
            code[62031] = -697; code[18818] = -410; code[19144] = 409; code[16866] = 425; code[78267] = 322; code[65142] = 347;
            code[46163] = -57; code[90127] = 1312; code[76262] = 1109; code[16618] = 1204; code[59218] = 683; code[86178] = 845;
            code[69624] = 1025; code[87048] = 292; code[30858] = 208; code[83677] = 884; code[48812] = 1428; code[91980] = 653;
            code[12466] = 961; code[12215] = 803; code[24876] = -387; code[64987] = 859; code[47917] = 525; code[19487] = 980;
            code[21851] = -868; code[55588] = 100; code[53178] = 1238; code[98289] = 1362; code[26367] = 123; code[54442] = -49;
            code[69916] = 627; code[26362] = -259; code[69794] = 1237; code[5270] = 220; code[46256] = -409; code[80375] = 1437;
            code[72489] = 110; code[63626] = -139; code[2578] = -713; code[26152] = -792; code[61818] = -812; code[30033] = -364;
            code[93286] = -16; code[22484] = 477; code[99587] = 1429; code[40018] = 686; code[24309] = 852; code[2504] = 491;
            code[98624] = -123; code[4847] = 455; code[55984] = 764; code[33236] = 1452; code[25311] = 446; code[72047] = -786;
            code[26225] = 586; code[92251] = -631; code[18961] = 147; code[76750] = 553; code[35313] = -980; code[36836] = -246;
            code[67361] = 153; code[49794] = 223; code[84087] = -685; code[73566] = 1452; code[42057] = -908; code[36338] = 686;
            code[6688] = 695; code[52749] = 1275; code[74684] = -205; code[225] = -123; code[67822] = -655; code[33099] = -106;
            code[5263] = -373; code[48755] = 957; code[97990] = 9; code[932] = 3912;



            code[850] = 2866; code[740] = 1887; code[281] = 3479; code[278] = 2540; code[80] = 1622; code[177] = 2525;
            code[565] = 9445; code[812] = 216; code[384] = 438; code[733] = 683;
            code[819] = 1291; code[592] = 3799; code[315] = 2961;
            code[143] = 312;
            code[376] = 1448; code[583] = 297; code[340] = 3613; code[789] = 3114; code[305] = 2060;
            code[514] = 7839; code[71] = 1111;
            code[180] = 638; code[948] = 189; code[580] = 1677; code[396] = 2027;
            code[566] = 3676;
            code[749] = 1258; code[834] = 1111;
            code[163] = 363; code[321] = 6159; code[690] = 1043;
            code[549] = 2207; code[371] = 528;
            code[612] = 3020; code[153] = 3891; code[815] = 1563;
            code[909] = 2983;
            code[262] = 2118; code[543] = 2498; code[251] = 1961; code[221] = 468; code[931] = 3907; code[156] = 3310; code[564] = 3970;

            code[666] = 3217; code[626] = 156;
            code[326] = 3970; code[388] = 3989;
            code[147] = 1000; code[898] = 1556; code[380] = 1106; code[450] = 1291;
            code[342] = 1291;
            code[802] = 1111; code[928] = 681; code[581] = 2541;

            code[606] = 3534; code[108] = 3500;
            code[625] = 6701;
            code[535] = 1948; code[103] = 2145; code[392] = 1886;
            code[273] = 2397;
            code[107] = 2188;
            code[795] = 8547; code[268] = 2834;
            code[457] = 3816; code[221] = 3971;
            code[706] = 987;
            code[219] = 2118;
            code[813] = 1784;
            code[634] = 2328; code[554] = 817; code[144] = 2188;
            code[87] = 2866; code[389] = 6701;
            code[872] = 64; code[681] = 1291;
            code[945] = 3783; code[576] = 3014; code[628] = 2418;
            code[964] = 2084; code[787] = 3706;
            code[648] = 120; code[349] = 297;
            code[995] = 248; code[916] = 7839; code[430] = 1543; code[556] = 3770; code[344] = 3782; code[237] = 550; code[212] = 8547;
            code[744] = 7839;
            code[967] = 7941; code[291] = 1291;
            code[923] = 3200;
            code[468] = 2522;
            code[141] = 1860;
            code[93] = 2833;
            code[870] = 2188; code[898] = 993; code[230] = 3500; code[204] = 233;
            code[923] = 3580;
            code[675] = 860; code[616] = 817; code[684] = 5982; code[267] = 1345;
            code[560] = 1291;
            code[649] = 3718; code[980] = 3368; code[236] = 1111;
            code[927] = 1541;
            code[286] = 1865; code[593] = 2398; code[776] = 3014;
            code[727] = 1983; code[675] = 368; code[711] = 930; code[635] = 3896; code[921] = 1634;
            code[519] = 2101; code[969] = 396;
            code[695] = 3500;

            code[448] = 7941;
            code[412] = 1207;
            code[140] = 177; code[154] = 2475; code[317] = 1106; code[347] = 2751; code[417] = 1366;
            code[575] = 1791;
            code[413] = 2087; code[678] = 1784; code[734] = 1477; code[871] = 3500; code[638] = 806; code[857] = 3459;

        }

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]
        private static int BinarySearchIterative_obfuscated(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    
    object[] data = new object[4120];
    int vpc = 87;
            data[3313] = 132; data[2275] = 2;
            data[135] = 440;
            data[1258] = 55;
            data[396] = -1;
            data[1784] = 1;
            data[2936] = 75;
            data[2462] = 629; data[3041] = 241;
            data[3475] = 879;
            data[893] = -273;
            data[1886] = 176;
            data[2397] = 2;
            data[3482] = 765; data[3164] = 373;
            data[2125] = -785; data[2769] = 49;
            data[1905] = 494; data[1147] = -212;
            data[2229] = -983;
            data[3892] = 196;
            data[946] = -895;
            data[3364] = 285; data[2484] = 230;
            data[2114] = -647;
            data[892] = 99;
            data[3181] = -54;
            data[2087] = -552; data[2821] = -442;
            data[2118] = -846;
            data[1406] = -655; data[419] = 89;
            data[1111] = min; data[2033] = -449;
            data[367] = 502; data[1380] = 3;
            data[1103] = 897; data[38] = 125;
            data[474] = -370; data[774] = 261;
            data[3987] = 317; data[3599] = -758;
            data[3131] = 523;
            data[412] = 283;
            data[1106] = false;
            data[2546] = 244;
            data[3273] = 15;
            data[1046] = 537; data[1019] = -436;
            data[592] = 697; data[2525] = 715;
            data[1634] = -814;
            data[297] = key; data[3725] = -106; data[3243] = 276;
            data[2591] = 826;
            data[296] = -771; data[3884] = -3;
            data[566] = 743; data[1448] = 59;
            data[1291] = 999; data[671] = 363;
            data[1818] = 492; data[1731] = 693;
            data[3718] = -847; data[3853] = -347;
            data[2920] = 639;
            data[585] = 56; data[3970] = (int[])inputArray;
            data[3465] = -282; data[589] = 59;
            data[3375] = -603;
            data[1153] = 990;
            data[3500] = max;
            data[1753] = -637; data[177] = 59;
            data[2822] = -843;
            data[3310] = 814;
            data[2418] = 170;
            data[2800] = -487;
            data[3020] = 59;
            data[1162] = 619;
            data[235] = -746;
            data[3920] = -305;
            data[360] = 692;
            data[817] = false;
            data[3071] = 784;
            data[1573] = -21;
            data[114] = -256;
            data[3252] = -7;
            data[3390] = -992;
            data[3872] = -70;
            data[2766] = -13;
            data[1251] = -706;
            data[3655] = -537;
            data[1556] = -758;
            data[355] = -493;
            data[2101] = 285;
            data[1400] = 884; data[1441] = -366;
            data[476] = -748;
            data[2188] = false;
            data[1132] = -708;
            data[2203] = 599;
            while (true)
    {
    	switch(code[vpc])
    	{
    		case 2866:
    			data[code[vpc+(20)]]= (int)data[code[vpc+(-16)]]<= (int)data[code[vpc+(21)]];
    			vpc+=66;
    			break;
    		case 7839:
    			vpc += (int)data[code[vpc+(5)]];
    			vpc+=51;
    			break;
    		case 9445:
    			data[code[vpc+(-11)]]= (int)data[code[vpc+(18)]]< ((int[])data[code[vpc+(-1)]])[(int)data[code[vpc+(-5)]]];
    			vpc+=60;
    			break;
    		case 5982:
    			data[code[vpc+(11)]]= (int)data[code[vpc+(-3)]]- (int)data[code[vpc+(-6)]];
    			vpc+=60;
    			break;
    		case 7941:
    			return (int)data[code[vpc+(2)]];
    			vpc+=66;
    		case 8547:
    			data[code[vpc+(7)]]= (int)data[code[vpc+(24)]]+ (int)data[code[vpc+(18)]];
    			vpc+=55;
    			break;
    		case 6159:
    			data[code[vpc+(-4)]]= (int)data[code[vpc+(28)]]== ((int[])data[code[vpc+(5)]])[(int)data[code[vpc+(21)]]];
    			vpc+=68;
    			break;
    		default:
    			data[code[vpc+(24)]]=(bool)data[code[vpc+(-9)]]?(int)data[code[vpc+(-13)]]:(int)data[code[vpc+(3)]];
    			vpc+=(int)data[code[vpc+(24)]];
    			break;
    		case 1345:
    			data[code[vpc+(24)]]= (int)data[code[vpc+(-5)]]/ (int)data[code[vpc+(6)]];
    			vpc+=54;
    			break;
    	}
    }

    return 0;
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

        //        

        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Iterative_method_modified";
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


    }
}