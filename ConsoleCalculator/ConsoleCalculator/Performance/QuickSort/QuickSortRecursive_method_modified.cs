using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortRecursive_method_modified
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> testData;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();


        public static void RunLoopTests()
        {
            QuickSortRecursive_method_modified lt = new QuickSortRecursive_method_modified();
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
            init_code();

            string result = "";

            result += "t_method_modified";
            result += " " + "\n";

            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {
                Console.WriteLine(i +" ##############");
                Debug.WriteLine(i + " ##############");
                int[] unsorted_original = testData.ToArray();
                string t_original = Time_Operation("QuickSortRecursive_method_modified", i, Quicksort_obfuscated, unsorted_original, WARMUP, ITERATIONS);
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
            string testName = "Performance#QuickSortRecursive_method_modified_Check";
            Program.Start_Check(testName);
            bool condition = true;

            init_code();
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

        private int[] code = new int[100256];

        private void init_code()
        {
            code[11644] = 212; code[22945] = -17; code[47249] = 661; code[44226] = 299; code[71854] = 1141; code[71419] = -399;
            code[77079] = 1341; code[47262] = 644; code[38080] = -842; code[31320] = -295; code[49607] = -71; code[70322] = 5;
            code[1766] = 455; code[99166] = 921; code[87155] = -938; code[54144] = -3; code[61310] = 475; code[97340] = 123;
            code[8606] = 1287; code[54155] = 798; code[46623] = -839; code[95142] = -967; code[97079] = -937; code[38625] = 1083;
            code[52343] = 979; code[89093] = 771; code[12218] = 1092; code[83457] = 860; code[78567] = 1066; code[37693] = 1223;
            code[67737] = 681; code[65215] = 729; code[31749] = -217; code[63047] = -554; code[96825] = -945; code[57327] = 162;
            code[52472] = 482; code[81905] = 75; code[42405] = 720; code[43495] = 1480; code[19722] = -611; code[24715] = -806;
            code[13677] = 1078; code[27781] = 936; code[75968] = -434; code[66737] = -353; code[54021] = 627; code[4387] = 981;
            code[41515] = -357; code[69851] = 637; code[39760] = -484; code[86989] = 250; code[22037] = 59; code[18580] = 322;
            code[2007] = 5; code[32200] = -761; code[39384] = -41; code[69433] = 299; code[42706] = 431; code[55660] = 213;
            code[3638] = 1135; code[42195] = 847; code[35730] = -219; code[92854] = 1181; code[55063] = -939; code[1616] = -587;
            code[99381] = 947; code[59707] = 1475; code[28871] = 866; code[86009] = 781; code[64766] = 870; code[75644] = -112;
            code[90789] = 425; code[86850] = -613; code[96076] = 309; code[36750] = 1103; code[70399] = -472; code[62021] = 355;
            code[78776] = -679; code[14401] = 1267; code[49873] = -218; code[98214] = 1489; code[38709] = -612; code[10464] = 534;
            code[79026] = 756; code[23260] = 698; code[71669] = 1106; code[84147] = -280; code[10005] = -837; code[83556] = 965;
            code[44750] = 927; code[91652] = -937; code[65953] = -563; code[46456] = 949; code[16068] = -867; code[20483] = -602;
            code[60438] = 1376; code[21586] = -168; code[77054] = 897; code[97187] = 874; code[46682] = -370; code[36770] = -361;
            code[29250] = 717; code[12677] = 1149; code[37300] = -174; code[44359] = 801; code[29597] = -107; code[46194] = 815;
            code[39964] = 1385; code[33861] = -472; code[69397] = -189; code[45480] = 837; code[49944] = -819; code[7682] = 910;
            code[62868] = 265; code[52080] = -148; code[9620] = -792; code[32156] = -515; code[40541] = 645; code[73557] = 1426;
            code[4847] = 508; code[40887] = 1074; code[61237] = 209; code[86629] = -387; code[49124] = 222; code[93694] = 1036;
            code[42224] = 895; code[5792] = -648; code[80075] = 579; code[75958] = -453; code[61201] = -95; code[23331] = 1164;
            code[81316] = -747; code[62603] = -471; code[3661] = -334; code[32274] = 850; code[22103] = -83; code[16337] = -779;
            code[91898] = 559; code[12447] = -965; code[20913] = 1077; code[27481] = -655; code[57302] = 762; code[92206] = -156;
            code[2574] = -552; code[39628] = 931; code[90300] = 286; code[36122] = 715; code[37180] = 354; code[1864] = 273;
            code[86166] = 630; code[20959] = -442; code[16750] = -515; code[59544] = -865; code[59665] = 1422; code[22507] = -564;
            code[50894] = 858; code[1048] = 948; code[8845] = -764; code[29510] = -735; code[18233] = -284; code[18656] = 1142;
            code[87371] = 373; code[84169] = 764; code[669] = 192; code[71959] = -64; code[60689] = 537; code[15518] = 390;
            code[62357] = -873; code[97347] = -57; code[11143] = 1163; code[74462] = -859; code[95752] = -449; code[26561] = -607;
            code[50546] = 452; code[59929] = -310; code[24818] = 1281; code[32819] = 432; code[46742] = -120; code[35262] = 544;
            code[35565] = 1220; code[4762] = -705; code[25202] = 1124; code[57087] = 1231; code[59009] = 135; code[15781] = -907;
            code[12396] = 1292; code[99740] = -210; code[54522] = -677; code[90414] = 627; code[28513] = 705; code[20216] = 64;
            code[88141] = 103; code[12750] = 731; code[28830] = 454; code[9027] = -326; code[70094] = -117; code[2257] = -443;
            code[82011] = 561; code[80720] = -737; code[65273] = -70; code[57017] = -876; code[42456] = 401; code[15295] = -174;
            code[92004] = -973; code[2912] = -159; code[45142] = 751; code[33417] = 681; code[68820] = 554; code[23961] = 1024;
            code[72441] = 1191; code[60669] = -984; code[36506] = 1218; code[33904] = 925; code[89684] = 929; code[49957] = 1298;
            code[32523] = 991; code[100246] = 1280; code[11380] = -621; code[229] = -204; code[28973] = 991; code[77703] = -309;
            code[55424] = 883; code[82166] = 1496; code[1998] = -125; code[53795] = -510; code[38652] = 1488; code[38372] = 936;
            code[76902] = 405; code[68760] = 339; code[22281] = -45; code[43702] = -636; code[51401] = -726; code[1230] = 634;
            code[70261] = 52; code[56042] = 337; code[62102] = 1300; code[52215] = 1314; code[10186] = -179; code[45502] = 526;
            code[6815] = -151; code[75236] = 361; code[23584] = -245; code[53511] = -178; code[41483] = -437; code[14549] = 378;
            code[46698] = 165; code[9673] = 1267; code[36172] = 572; code[76579] = 107; code[74298] = -586; code[29835] = 497;
            code[79301] = -996; code[57832] = 163; code[47570] = 142; code[67452] = 96; code[10842] = -813; code[46914] = 1206;
            code[63332] = 1228; code[91296] = -474; code[57747] = 707; code[24059] = 188; code[27670] = -982; code[6918] = -618;
            code[82586] = 535; code[56650] = 181; code[56618] = -974; code[87189] = 1255; code[4227] = -621; code[75547] = -417;
            code[72699] = -829; code[85676] = 1392; code[55409] = 766; code[44447] = -24; code[100095] = -466; code[27581] = 173;
            code[72037] = 382; code[86928] = -856; code[92820] = 1055; code[32362] = 958; code[93515] = 59; code[64315] = 1151;
            code[89409] = -500; code[87595] = -757; code[20592] = 414; code[84247] = 200; code[13814] = 692; code[48678] = 268;
            code[83072] = -293; code[92499] = 423; code[56559] = 695; code[15506] = 524; code[33976] = -761; code[75581] = -972;
            code[14408] = 1029; code[97880] = -451; code[83095] = 1425; code[30144] = -247; code[42804] = 1485; code[6523] = -120;
            code[83504] = -136; code[18578] = 81; code[37462] = 987; code[33250] = -897; code[6777] = -102; code[22987] = 606;
            code[90191] = 883; code[21989] = -364; code[26978] = -921; code[52292] = 990; code[44762] = 1155; code[95607] = -16;
            code[59098] = 551; code[65288] = -581; code[37746] = -540; code[8078] = 1086; code[21858] = 425; code[73831] = -455;
            code[49424] = 805; code[23670] = 359; code[76589] = 781; code[94640] = 960; code[58397] = -167; code[32110] = -812;
            code[75264] = -885; code[3235] = -12; code[47370] = -328; code[90812] = 1426; code[39334] = 979; code[84527] = 883;
            code[14418] = -591; code[66655] = 1208; code[27967] = -14; code[42581] = -177; code[1706] = -998; code[76343] = 367;
            code[79767] = 1444; code[3235] = 834; code[92047] = -577; code[81320] = -361; code[30091] = 439; code[41806] = -175;
            code[15228] = 713; code[36293] = 1372; code[66621] = 914; code[82793] = 753; code[88117] = 207; code[40105] = 500;
            code[4780] = -849; code[50650] = -531; code[91114] = 1477; code[5851] = 873; code[28543] = 213; code[60109] = 236;
            code[23717] = -571; code[5278] = -443; code[98304] = 467; code[45424] = 419; code[74883] = -164; code[73339] = 483;
            code[3285] = 188; code[66645] = -372; code[17577] = -850; code[66980] = -219; code[57917] = 80; code[68802] = 1143;
            code[66593] = 558; code[34798] = -228; code[51878] = 668; code[4570] = 666; code[8601] = 1168; code[71442] = 231;
            code[71481] = 507; code[72258] = -271; code[2984] = 1080; code[85526] = 782; code[32988] = 1279; code[15533] = 83;
            code[32708] = 1017; code[57570] = -439; code[81922] = -284; code[91940] = 1010; code[48682] = -513; code[56006] = -108;
            code[24071] = -641; code[5064] = -802; code[28970] = -838; code[50908] = -587; code[76488] = -570; code[53974] = 430;
            code[34030] = -60; code[28373] = 864; code[58064] = 1432; code[52986] = 881; code[46968] = 1284; code[98539] = 776;
            code[9342] = 1052; code[85167] = 997; code[95260] = 1270; code[708] = 294; code[4442] = -91; code[5177] = 1214;
            code[78353] = 933; code[42523] = -340; code[40486] = 1473; code[67205] = -615; code[26931] = -996; code[88733] = 101;
            code[377] = -572; code[22572] = 281; code[66826] = 1015; code[89088] = -185; code[16147] = -150; code[98881] = 169;
            code[21591] = 771; code[21589] = 1136; code[16545] = -949; code[52940] = 1439; code[32554] = -8; code[96656] = 1013;
            code[55039] = -340; code[34967] = 197; code[24409] = 1071; code[44296] = -772; code[93837] = 21; code[79727] = 946;
            code[68488] = 236; code[85351] = -405; code[47622] = 813; code[72659] = 103; code[78929] = 1390; code[4892] = 737;
            code[77603] = 1039; code[99163] = -380; code[47501] = 1273; code[11636] = 516; code[20783] = 48; code[96590] = 5;
            code[45840] = 23; code[8302] = -170; code[90049] = 1237; code[53326] = 1016; code[91585] = 91; code[17193] = 676;
            code[16954] = -276; code[50207] = 498; code[67416] = 306; code[1832] = 481; code[21609] = 634; code[70681] = 69;
            code[84176] = -516; code[61908] = -934; code[29339] = -529; code[57291] = -342; code[53253] = 122; code[78305] = -837;
            code[64418] = -19; code[54467] = 1230; code[42542] = -395; code[78352] = -157; code[64583] = -204; code[7926] = -540;
            code[40950] = 291; code[93649] = 711; code[40231] = -74; code[18715] = 1008; code[70631] = 637; code[49395] = 761;
            code[27817] = 262; code[51529] = 812; code[86732] = 1269; code[13958] = 799; code[50999] = 88; code[95925] = -300;
            code[98182] = -686; code[16883] = 1433; code[87441] = -82; code[78557] = 302; code[11489] = 83; code[61983] = 939;
            code[25521] = 1216; code[86447] = -599; code[26312] = 1443; code[36187] = 1468; code[90201] = 1096; code[61641] = 1297;
            code[73003] = -859; code[47356] = 840; code[17992] = -103; code[67706] = 1432; code[56132] = 635; code[70716] = -312;
            code[20280] = -467; code[93369] = -158; code[87369] = 1429; code[59144] = 1109; code[88918] = 845; code[47146] = 1445;
            code[4577] = 1446; code[45870] = 327; code[7455] = 1423;
            code[1487] = 1494; code[428] = 385; code[1893] = 2509; code[2156] = 1629;
            code[2269] = 45;

            code[333] = 781;
            code[1907] = 79; code[1895] = 9790;
            code[1242] = 3614; code[1673] = 385; code[521] = 730;

            code[1965] = 3712; code[1280] = 1182; code[396] = 488;

            code[601] = 2970;
            code[1778] = 1601; code[1837] = 1601;
            code[1613] = 2036;
            code[910] = 3412;
            code[85] = 2941;
            code[194] = 578; code[1803] = 2156; code[2085] = 2059;
            code[1720] = 2702; code[1892] = 3188; code[1391] = 2705; code[599] = 1984; code[1785] = 854; code[1365] = 1629; code[1416] = 2110; code[2151] = 1236; code[1968] = 2914;

          




            code[1135] = 698;
            code[296] = 3763; code[1233] = 2553; code[1261] = 1464; code[1408] = 2486; code[1919] = 3383; code[1824] = 2663; code[861] = 3759; code[705] = 114; code[1430] = 3006;
            code[1670] = 1746; code[369] = 1629;
            code[953] = 1453;
            code[2073] = 1587; code[1396] = 1519; code[1203] = 1239;
            code[1404] = 3687; code[1541] = 1807;
            code[558] = 3713; code[718] = 407;
            code[2270] = 1339;
            code[1469] = 523; code[1413] = 1679; code[543] = 2314; code[2240] = 1686; code[586] = 297;
            code[558] = 3903; code[730] = 3907; code[1465] = 4337; code[897] = 3273;
            code[354] = 3599; code[1987] = 3384; code[907] = 8845;
            code[413] = 2156; code[845] = 7412;
            code[91] = 302; code[1298] = 1402; code[1094] = 1695;
            code[141] = 414;

            code[1825] = 2276;

            code[2288] = 1073; code[452] = 3784;
            code[83] = 1357; code[1462] = 2901; code[746] = 1793; code[898] = 2800; code[1428] = 173;
            code[212] = 3763; code[2137] = 2019; code[462] = 38; code[1324] = 2156;
            code[1155] = 2156; code[680] = 2634;

            code[2026] = 2059;
            code[1592] = 3187;
            code[1085] = 3877; code[1024] = 7412; code[1829] = 3522; code[1205] = 811; code[780] = 1510; code[1576] = 1981; code[1359] = 1780; code[1451] = 3216; code[1075] = 913;
            code[657] = 4337; code[2050] = 3135;
            code[135] = 7636;
            code[653] = 2017;
            code[2096] = 300; code[2070] = 41; code[453] = 2009; code[587] = 1169; code[2293] = 2662;

            code[184] = 2505; code[353] = 56; code[1389] = 1629; code[1901] = 578; code[2063] = 2744; code[1540] = 2156; code[1646] = 9713;
            code[270] = 1353; code[1814] = 731; code[2051] = 1208; code[365] = 3873; code[1020] = 1629; code[554] = 2160; code[1170] = 3852;
            code[475] = 385;
            code[1336] = 1348; code[1745] = 2253; code[340] = 3628;
            code[667] = 488; code[825] = 3412; code[401] = 9713; code[956] = 3361;
            code[82] = 3146;
            code[472] = 3945;
            code[1232] = 1093;
            code[1891] = 1291; code[1513] = 2760;

            code[2033] = 564; code[1539] = 523;

            code[527] = 3681; code[1533] = 6482;
            code[2135] = 2960; code[1273] = 355; code[1710] = 1624;

            code[1834] = 8845; code[708] = 384; code[744] = 1674; code[1760] = 2532;
            code[975] = 2156;

            code[1275] = 3628; code[429] = 2539;
            code[649] = 488;
            code[725] = 5445; code[1271] = 623; code[469] = 1266; code[839] = 2156; code[1138] = 488; code[1448] = 2249; code[1283] = 405; code[2018] = 1042;

            code[1334] = 488; code[959] = 500; code[463] = 2019;
            code[1774] = 6291;
            code[2125] = 1208;
            code[1631] = 724; code[1474] = 1160; code[553] = 1833; code[2149] = 488; code[133] = 1208; code[614] = 29;
            code[1045] = 2110;
            code[2072] = 1058;
            code[330] = 2527;
            code[799] = 2234;
            code[619] = 1134; code[2288] = 616; code[2143] = 9790; code[2172] = 2505; code[2254] = 3290;
            code[1457] = 488; code[1801] = 2369;
            code[54] = 1558; code[1907] = 439; code[125] = 2156;
            code[533] = 5445;
            code[1086] = 3712; code[532] = 1984; code[1893] = 3705; code[1217] = 3852;
            code[783] = 810;
            code[971] = 3515; code[1145] = 3288; code[846] = 2851; code[1130] = 1064;
            code[2235] = 947;
            code[750] = 2679;
            code[1168] = 2070; code[272] = 627;
            code[1027] = 3765; code[536] = 1629; code[1772] = 3998; code[1485] = 2334;
            code[1543] = 3493; code[66] = 578; code[932] = 1787; code[1781] = 2493; code[500] = 3098;
            code[2110] = 41; code[788] = 3712; code[1605] = 3346;
            code[791] = 663;
            code[116] = 3434; code[1265] = 1828;
            code[1544] = 1094;
            code[1882] = 3654;
            code[2035] = 3469; code[68] = 7636;
            code[817] = 3885; code[58] = 488; code[2144] = 437; code[2030] = 488; code[2213] = 3712; code[1418] = 3508;
            code[2287] = 2943;
            code[1717] = 3712;
            code[2200] = 1228;
            code[457] = 2751;
            code[1702] = 939;
            code[1557] = 2156;
            code[1464] = 591; code[1143] = 9713; code[254] = 823; code[754] = 1333; code[339] = 3681; code[91] = 2647;
            code[206] = 1208; code[978] = 3666; code[1004] = 3412; code[743] = 20; code[1589] = 3712;
            code[2296] = 3669;
            code[1484] = 1315; code[2139] = 151;
            code[1844] = 1708;
            code[1908] = 1629; code[1233] = 1096;
            code[992] = 2156; code[485] = 1828;
            code[661] = 523;
            code[1214] = 8845;
            code[384] = 2882; code[1204] = 1036; code[1401] = 158; code[1412] = 3286; code[1490] = 1135; code[542] = 2514; code[1647] = 3825; code[1860] = 6; code[1304] = 1629;
            code[1431] = 3211; code[1923] = 2665; code[1434] = 2156;
            code[518] = 488; code[1740] = 3159;
            code[1645] = 376;
            code[1658] = 2156; code[841] = 1629; code[394] = 3201; code[1018] = 2156;
            code[1124] = 385; code[1475] = 488;
            code[1722] = 1218; code[1089] = 2969;
            code[893] = 3899; code[1785] = 1474;
            code[935] = 1723;
            code[1268] = 488; code[2216] = 2694;
            code[2022] = 6291;
            code[728] = 1629; code[1918] = 3408;
            code[361] = 866;
            code[986] = 859;
            code[732] = 814;
            code[1819] = 930; code[1862] = 2043;
            code[1515] = 2709;

            code[1970] = 3087; code[849] = 3681;
            code[1641] = 488; code[617] = 1085; code[719] = 3681;
            code[974] = 523; code[710] = 488;
            code[799] = 3749; code[429] = 684; code[2203] = 2707;
            code[707] = 3952;

            code[987] = 3036; code[1782] = 578;
            code[1267] = 835; code[1397] = 1908;

            code[65] = 235;

            code[1877] = 2156;
            code[1274] = 2486;

            code[423] = 3318; code[498] = 3492; code[724] = 1984; code[1028] = 3681; code[202] = 4337; code[1342] = 1629; code[1015] = 1299; code[1407] = 2411; code[1362] = 379; code[2265] = 1174; code[624] = 1777; code[596] = 8845;

            code[1036] = 3493; code[968] = 6482;
            code[2041] = 234;
            code[417] = 92; code[292] = 781;
            code[81] = 2852; code[1699] = 1474; code[1076] = 2468; code[2082] = 8845; code[412] = 3321;

            code[987] = 2350;
        }

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]
        private string Quicksort_obfuscated(int[] elements, int left, int right)
{
    //Virtualization variables
    object[] data = new object[4962];
    int vpc = 68; data[2200] = 537;
            data[3936] = -346; data[3273] = 61;
            data[566]=6; data[1451] = 96; data[41] = 560;
            data[1760]=-742; data[3623] = 546;
            data[1644] = -616; data[630] = -702;
            data[844]=469; data[1294] = 813; data[3817] = 982;
            data[736] = -850; data[1428] = 575;
            data[3047] = -450; data[2681] = 94; data[2399] = 973;
            data[1629] = (int[])elements; data[2863] = 112;
            data[564] = 266; data[1259] = 703; data[3852] = false;
            data[1616] = -611; data[3287] = -334; data[1587] = 188;
            data[823] = 2;
            data[3849] = 396;
            data[1058] = 61; data[2007] = -213;
            data[3777] = -76;
            data[2103] = 861; data[3834] = -687; data[3797] = -744;
            data[2800] = 236; data[1988] = 66;
            data[1883] = -312;
            data[3721] = -148;
            data[2505] = -343;
            data[2485] = 202;
            data[1210] = 578; data[3142] = 898; data[2489] = -817;
            data[2365] = -353;
            data[3399] = -734;
            data[462] = 79; data[3425] = 121; data[3094] = 359;
            data[297] = 61; data[1046] = -377;
            data[3848] = -565;
            data[3863] = 110; data[310] = -196;
            data[1736] = 390;
            data[2472] = 412; data[3412] = false;
            data[488] = 191; data[2690] = 777;
            data[663] = -249;
            data[2038] = -38; data[2703] = 269;
            data[2819] = 493; data[811] = 432;
            data[2891] = 405; data[1999] = -604;
            data[3175] = 645; data[1496] = 392;
            data[241] = -589; data[1962] = -891;
            data[3888] = 978; data[157] = -606;
            data[3763] = -481;
            data[2212] = 647; data[2419] = 264;
            data[2702] = -1302; data[2156] = -66;
            data[2043] = -999; data[752] = -758;
            data[1036] = 61;
            data[1258] = 394; data[638] = -467;
            data[1364] = 610;
            data[1388] = -533; data[2601] = 282;
            data[1867] = -882;
            data[2059] = false; data[3994] = -350;
            data[1623] = -225; data[2722] = 170;
            data[263] = 776; data[875] = 404; data[3728] = 528;
            data[2182] = -613; data[2257] = 617; data[2955] = -28;
            data[3874] = -691;
            data[256] = 627;
            data[96] = -686; data[1586] = -751;
            data[2715] = -187;
            data[3614] = 701; data[3831] = -916; data[2684] = 10;
            data[2796] = 440;
            data[214] = -248;
            data[1785] = -332;
            data[569] = 513;
            data[2483] = -256;
            data[1169] = 249; data[1735] = -211; data[2134] = 340; data[2352] = 938;
            data[1887] = -272; data[2360] = -310;
            data[2944] = 251;
            data[2854] = -994;
            data[3866] = -945; data[3505] = 592; data[2969] = -236; data[848] = 741;
            data[3634] = -123; data[3974] = -334; data[235] = -242;
            data[2542] = -669; data[88] = -18;
            data[1017] = -231;
            data[995] = -278;
            data[2052] = -489;
            data[2451] = -611;
            data[2663] = 61; data[781] = -648; data[2545] = -977; data[3931] = 609;
            data[2708] = -56; data[2387] = 577;
            data[523] = 1; data[1186] = 786; data[2023] = 834;
            data[238] = -75;
            data[1523] = -48;
            data[827] = -571;
            data[3332] = 32; data[2343] = 912; data[3040] = 432;
            data[2634] = -835; data[3112] = 345;
            data[1775] = 839; data[2694] = 0; data[3681] = 44;
            data[785] = 574;
            data[3187] = 0; data[671] = -535;
            data[1161] = -22;
            data[1130] = 62; data[2486] = -442;
            data[2660] = -301;
            data[1777] = -167; data[3291] = -539;
            data[2180] = 262; data[3710] = -794;
            data[432] = 123;
            data[1696] = -478; data[299] = -761; data[2071] = -936;
            data[2741] = -348;
            data[2020] = -160;
            data[2914] = 0;
            data[578] = left; data[430] = -93;
            data[870] = 562;
            data[220] = 467;
            data[954] = -100;
            data[3914] = -706; data[1986] = 421;
            data[1723] = -207;
            data[2995] = -788; data[3388] = -667;
            data[38] = 61; data[374] = -866;
            data[971] = 919;
            data[313] = 636;
            data[1740] = -676;
            data[1869] = -794;
            data[963] = 800;
            data[1208] = right;
            data[1371] = 175;
            data[1948] = -248;
            data[3973] = 687;
            data[1285] = 135;
            data[3967] = -526;
            data[1448] = 919; data[1649] = 955;
            data[3022] = 235; data[472] = -834;
            data[2019] = 1302; data[1044] = 427;
            data[1984] = false; data[262] = -621;
            data[81] = 138; data[3456] = 165; data[2507] = -708;
            data[2243] = -923; data[3098] = -167;
            data[352] = -50; data[3283] = -747; data[226] = -957;
            data[2670] = -427; data[2415] = -488;
            data[1459] = 99; data[3290] = ""; data[385] = false;
            data[1471] = 873; data[1160] = 157;
            data[2276] = 188;
            data[2632] = 367;
            data[1601] = false;
            data[2758] = -225;
            data[354] = 194; data[2104] = 523;
            data[3435] = -986;
            data[1935] = 360; data[1028] = -246;
            data[856] = 464; data[3285] = -736;
            data[468] = 31; data[1781] = 980; data[2111] = 54;


            while (true)
    {
    	switch(code[vpc])
    	{
    		case 9713:
    			data[code[vpc+(27)]]= (int)data[code[vpc+(-5)]]<= (int)data[code[vpc+(12)]];
    			vpc+=71;
    			break;
    		case 5445:
    			data[code[vpc+(-1)]]= ((int[])data[code[vpc+(3)]])[(int)data[code[vpc+(-15)]]] < (int)data[code[vpc+(-6)]];
    			vpc+=63;
    			break;
    		case 7636:
    			data[code[vpc+(-10)]]= (int)data[code[vpc+(-2)]];
    			vpc+=67;
    			break;
    		case 7412:
    			data[code[vpc+(-20)]]= (int)data[code[vpc+(4)]]< ((int[])data[code[vpc+(-4)]])[(int)data[code[vpc+(-6)]]];
    			vpc+=62;
    			break;
    		case 9790:
    			Quicksort_obfuscated((int[])data[code[vpc+(13)]], (int)data[code[vpc+(6)]], (int)data[code[vpc+(-18)]]);
    			vpc+=70;
    			break;
    		case 3712:
    			vpc += (int)data[code[vpc+(3)]];
    			vpc+=57;
    			break;
    		case 1339:
    			return (string)data[code[vpc+(-16)]];
    			vpc+=62;
    		case 6482:
    			data[code[vpc+(7)]]= (int)data[code[vpc+(24)]]- (int)data[code[vpc+(6)]];
    			vpc+=56;
    			break;
    		case 4337:
    			data[code[vpc+(10)]]= (int)data[code[vpc+(-8)]]+ (int)data[code[vpc+(4)]];
    			vpc+=68;
    			break;
    		default:
    			data[code[vpc+(28)]]=(bool)data[code[vpc+(3)]]?(int)data[code[vpc+(-10)]]:(int)data[code[vpc+(-9)]];
    			vpc+=(int)data[code[vpc+(28)]];
    			break;
    		case 1353:
    			data[code[vpc+(22)]]= (int)data[code[vpc+(26)]]/ (int)data[code[vpc+(-16)]];
    			vpc+=70;
    			break;
    		case 3628:
    			data[code[vpc+(-1)]]= ((int[])data[code[vpc+(29)]])[(int)data[code[vpc+(-7)]]];
    			vpc+=61;
    			break;
    		case 1348:
    			((int[])data[code[vpc+(29)]])[(int)data[code[vpc+(-2)]]] = ((int[])data[code[vpc+(6)]])[(int)data[code[vpc+(-12)]]];
    			vpc+=71;
    			break;
    		case 2411:
    			((int[])data[code[vpc+(-18)]])[(int)data[code[vpc+(27)]]] = (int)data[code[vpc+(1)]];
    			vpc+=58;
    			break;
    		case 6291:
    			data[code[vpc+(4)]]= (int)data[code[vpc+(8)]]< (int)data[code[vpc+(29)]];
    			vpc+=60;
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
            for (int i = 0; i < warmup; i++)
            {
                int[] unsorted_original = testData.ToArray();
                method(unsorted_original, 0, unsorted_original.Length - 1);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("   {0}     , sec", timespan.TotalSeconds);
            log = id + " " + runId + " warmed up in, " + time;
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

            time = String.Format("      {0}     , sec", timespan.TotalSeconds);
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


    }
}