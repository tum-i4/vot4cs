using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCalculator.Performance.ForLoop
{
   

    class ForLoop_op4_in1
    {
        private static string TITLE = "ForLoop_op4_in1";
        private Car car = new Car("invocation-check-car", 4);

        public static int WARMUP;
        public static int ITERATIONS;
        public static int NUMBER_OF_LOOPS;
        public static int NUMBER_OF_TESTS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();

        public static void RunLoopTests()
        {
            ForLoop_op4_in1 lt = new ForLoop_op4_in1();
            time_warmup.Clear();
            time_run.Clear();

            lt.Profile();

//            lt.ForLoop_Check();

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

            result += "t_original";
            result += "     t_method";
            result += "     t_class";
            result += "     t_method_junk";
            result += "     t_class_junk";
            result += " " + "\n";


            for (int i = 0; i < NUMBER_OF_TESTS; i++)
            {
                Console.WriteLine(i + " ##############");
                Debug.WriteLine(i + " ##############");
                string t_original = Time_Operation(i+" , "+ TITLE, ForSimple_Array_obfuscated2_op4_in1);

                result += " " + t_original;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);

            PrintTimes();
        }


        private int ReturnArg_Array(int arg)
        {
            return arg;
        }
        private string ForSimple_Array_obfuscated2_op4_in1(int b)
        {
            //Virtualization variables
            int[] code = new int[100640];
            object[] data = new object[4600];
            int vpc = 74;

            //Data init
            data[2262] = b; //b 
            data[338] = ""; //"" constant
            data[3290] = 3; //3 constant
            data[2944] = 4; //4 constant
            data[2282] = 1; //1 constant
            data[977] = 0; //0 constant
            data[2695] = "_"; //"_" constant
            data[2478] = "~"; //"~" constant
            data[2115] = "#"; //"#" constant
            data[782] = "["; //"[" constant
            data[1091] = "]"; //"]" constant
            data[3044] = 580772629; //sum 
            data[1586] = (ConsoleCalculator.Engine)null; //invocationTemp_0 
            data[1315] = (ConsoleCalculator.Engine)null; //invocationTemp_1 
            data[2794] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_2 
            data[3259] = -365; //memberTemp_0 
            data[3845] = (ConsoleCalculator.Piston)null; //invocationTemp_3 
            data[3759] = 108831917; //invocationTemp_4 
            data[2048] = 614725912; //r 
            data[3360] = (string[])null; //dst 
            data[480] = 190; //var_forIndex_0 
            data[621] = 689; //invocationTemp_5 
            data[2673] = false; //var_whileCondition_0 
            data[2235] = (ConsoleCalculator.Engine)null; //invocationTemp_6 
            data[3793] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_7 
            data[3658] = (ConsoleCalculator.Piston)null; //invocationTemp_8 
            data[1945] = (double)0.291733439216266; //p1 
            data[3832] = 539; //memberTemp_1 
            data[2008] = 59; //invocationTemp_9 
            data[1495] = -698; //memberTemp_2 
            data[1440] = 159; //fake-1440 
            data[1987] = 812; //fake-1987 
            data[1641] = 169; //fake-1641 
            data[2623] = 130; //fake-2623 
            data[620] = 792; //fake-620 
            data[3463] = 393; //fake-3463 
            data[1222] = -992; //fake-1222 
            data[184] = -770; //fake-184 
            data[530] = -265; //fake-530 
            data[2584] = 496; //fake-2584 
            data[3913] = 10; //fake-3913 
            data[3815] = 40; //fake-3815 
            data[3663] = 310; //fake-3663 
            data[1457] = -209; //fake-1457 
            data[608] = -723; //fake-608 
            data[860] = -587; //fake-860 
            data[3673] = 690; //fake-3673 
            data[2463] = -582; //fake-2463 
            data[2575] = 259; //fake-2575 
            data[1821] = -923; //fake-1821 
            data[3165] = -921; //fake-3165 
            data[2613] = -350; //fake-2613 
            data[2676] = 156; //fake-2676 
            data[1211] = -966; //fake-1211 
            data[3213] = 678; //fake-3213 
            data[3882] = -639; //fake-3882 
            data[1298] = -37; //fake-1298 
            data[3125] = -537; //fake-3125 
            data[2968] = -999; //fake-2968 
            data[2578] = 481; //fake-2578 
            data[2864] = -701; //fake-2864 
            data[1] = -248; //fake-1 
            data[2106] = -199; //fake-2106 
            data[100] = -777; //fake-100 
            data[249] = -965; //fake-249 
            data[244] = 139; //fake-244 
            data[1303] = -690; //fake-1303 
            data[2432] = 962; //fake-2432 
            data[960] = -505; //fake-960 
            data[374] = -413; //fake-374 
            data[1119] = -720; //fake-1119 
            data[2717] = 806; //jmpWhileDestinationName_2717 constant
            data[1279] = 69; //while_GoTo_True_1279 constant
            data[1078] = 1001; //while_GoTo_False_1078 constant
            data[1426] = -1001; //while_FalseBlockSkip_1426 constant
            data[1490] = -435; //fake-1490 
            data[2750] = 105; //fake-2750 
            data[3464] = 339; //fake-3464 
            data[1969] = 500; //fake-1969 
            data[3671] = 325; //fake-3671 
            data[2927] = 310; //fake-2927 
            data[158] = -705; //fake-158 
            data[2501] = -224; //fake-2501 
            data[3508] = 999; //fake-3508 
            data[1750] = -835; //fake-1750 
            data[3283] = -720; //fake-3283 
            data[3554] = -18; //fake-3554 
            data[3640] = -778; //fake-3640 
            data[3649] = -491; //fake-3649 
            data[2649] = -344; //fake-2649 
            data[3859] = 135; //fake-3859 
            data[3817] = 452; //fake-3817 
            data[2878] = 431; //fake-2878 
            data[518] = -571; //fake-518 
            data[2389] = 544; //fake-2389 
            data[3432] = -772; //fake-3432 
            data[552] = 254; //fake-552 
            data[1583] = 196; //fake-1583 
            data[3615] = -743; //fake-3615 
            data[101] = -762; //fake-101 
            data[3005] = 87; //fake-3005 
            data[3810] = -245; //fake-3810 
            data[3010] = 137; //fake-3010 
            data[2652] = -897; //fake-2652 
            data[149] = 727; //fake-149 
            data[2248] = 922; //fake-2248 
            data[1207] = -329; //fake-1207 
            data[470] = 796; //fake-470 
            data[3873] = -727; //fake-3873 
            data[1016] = -916; //fake-1016 
            data[1202] = -950; //fake-1202 
            data[824] = -306; //fake-824 
            data[3537] = -823; //fake-3537 
            data[1684] = 36; //fake-1684 
            data[1488] = 653; //fake-1488 
            data[1076] = -832; //fake-1076 
            data[1021] = 224; //fake-1021 
            data[1738] = 482; //fake-1738 
            data[3555] = -866; //fake-3555 
            data[1320] = -528; //fake-1320 
            data[3711] = 819; //fake-3711 
            data[3597] = -1000; //fake-3597 
            data[872] = 525; //fake-872 
            data[2727] = -517; //fake-2727 
            data[1375] = 175; //fake-1375 
            data[270] = -490; //fake-270 
            data[3140] = 64; //fake-3140 
            data[2813] = -842; //fake-2813 
            data[3282] = -265; //fake-3282 
            data[1429] = 577; //fake-1429 
            data[3834] = 311; //fake-3834 
            data[740] = 909; //fake-740 
            data[3898] = 82; //fake-3898 
            data[320] = 261; //fake-320 
            data[956] = -763; //fake-956 
            data[2838] = -446; //fake-2838 
            data[3440] = 158; //fake-3440 
            data[2774] = -327; //fake-2774 
            data[3386] = -729; //fake-3386 

            //Code init

            code[74] = 5774; //ExpressionStatement_0 # ExpressionStatement_0
            code[54] = 3044; //sum
            code[75] = 338; //""
            code[65] = 3290; //3
            code[85] = 2944; //4
            code[64] = 338; //""
            code[59] = 1655; //fake-ExpressionStatement_0_1655_-15

            code[130] = 7716; //ExpressionStatement_1 # ExpressionStatement_1
            code[125] = 1586; //invocationTemp_0
            code[129] = 570; //fake-ExpressionStatement_1_570_-1
            code[149] = 2374; //fake-ExpressionStatement_1_2374_19
            code[149] = 1054; //fake-ExpressionStatement_1_1054_19
            code[115] = 2862; //fake-ExpressionStatement_1_2862_-15
            code[117] = 2526; //fake-ExpressionStatement_1_2526_-13

            code[196] = 7716; //ExpressionStatement_1 # ExpressionStatement_2
            code[191] = 1315; //invocationTemp_1
            code[212] = 1532; //fake-ExpressionStatement_1_1532_16
            code[211] = 86; //fake-ExpressionStatement_1_86_15
            code[186] = 2028; //fake-ExpressionStatement_1_2028_-10

            code[262] = 6043; //ExpressionStatement_3 # ExpressionStatement_3
            code[291] = 2794; //invocationTemp_2
            code[244] = 1315; //invocationTemp_1
            code[278] = 30; //fake-ExpressionStatement_3_30_16
            code[263] = 672; //fake-ExpressionStatement_3_672_1
            code[256] = 411; //fake-ExpressionStatement_3_411_-6
            code[271] = 1679; //fake-ExpressionStatement_3_1679_9

            code[321] = 7373; //ExpressionStatement_4 # ExpressionStatement_4
            code[333] = 3259; //memberTemp_0
            code[310] = 2794; //invocationTemp_2
            code[305] = 2288; //fake-ExpressionStatement_4_2288_-16

            code[388] = 7807; //ExpressionStatement_5 # ExpressionStatement_5
            code[394] = 3845; //invocationTemp_3
            code[397] = 1586; //invocationTemp_0
            code[375] = 3259; //memberTemp_0
            code[405] = 2282; //1
            code[400] = 2397; //fake-ExpressionStatement_5_2397_12
            code[372] = 2502; //fake-ExpressionStatement_5_2502_-16
            code[410] = 1307; //fake-ExpressionStatement_5_1307_22
            code[372] = 367; //fake-ExpressionStatement_5_367_-16

            code[453] = 2223; //ExpressionStatement_6 # ExpressionStatement_6
            code[463] = 3759; //invocationTemp_4
            code[450] = 3845; //invocationTemp_3
            code[454] = 2444; //fake-ExpressionStatement_6_2444_1
            code[475] = 1940; //fake-ExpressionStatement_6_1940_22
            code[459] = 3789; //fake-ExpressionStatement_6_3789_6

            code[522] = 7862; //ExpressionStatement_7 # ExpressionStatement_7
            code[541] = 3044; //sum
            code[532] = 3044; //sum
            code[529] = 3759; //invocationTemp_4
            code[527] = 3455; //fake-ExpressionStatement_7_3455_5
            code[527] = 1089; //fake-ExpressionStatement_7_1089_5
            code[524] = 1226; //fake-ExpressionStatement_7_1226_2

            code[583] = 8318; //ExpressionStatement_8 # ExpressionStatement_8
            code[565] = 2048; //r
            code[598] = 338; //""
            code[593] = 1375; //fake-ExpressionStatement_8_1375_10
            code[612] = 3485; //fake-ExpressionStatement_8_3485_29
            code[587] = 1200; //fake-ExpressionStatement_8_1200_4

            code[649] = 4889; //ExpressionStatement_9 # ExpressionStatement_9
            code[641] = 3360; //dst
            code[631] = 2262; //b
            code[634] = 3975; //fake-ExpressionStatement_9_3975_-15
            code[677] = 37; //fake-ExpressionStatement_9_37_28
            code[650] = 594; //fake-ExpressionStatement_9_594_1
            code[647] = 3912; //fake-ExpressionStatement_9_3912_-2
            code[632] = 1185; //fake-ExpressionStatement_9_1185_-17
            code[678] = 3558; //fake-ExpressionStatement_9_3558_29
            code[677] = 3240; //fake-ExpressionStatement_9_3240_28

            code[715] = 8318; //ExpressionStatement_8 # ExpressionStatement_10
            code[697] = 480; //var_forIndex_0
            code[730] = 977; //0
            code[731] = 3496; //fake-ExpressionStatement_8_3496_16

            code[781] = 8245; //ExpressionStatement_11 # ExpressionStatement_11
            code[808] = 621; //invocationTemp_5
            code[807] = 2262; //b
            code[792] = 1337; //fake-ExpressionStatement_11_1337_11
            code[789] = 2890; //fake-ExpressionStatement_11_2890_8
            code[766] = 1287; //fake-ExpressionStatement_11_1287_-15
            code[793] = 543; //fake-ExpressionStatement_11_543_12

            code[847] = 2063; //ExpressionStatement_12 # ExpressionStatement_12
            code[855] = 2673; //var_whileCondition_0
            code[831] = 480; //var_forIndex_0
            code[834] = 621; //invocationTemp_5
            code[846] = 3795; //fake-ExpressionStatement_12_3795_-1
            code[856] = 2786; //fake-ExpressionStatement_12_2786_9

            code[900] = 6605; //WhileStatementSyntax_13 # WhileStatementSyntax_13
            code[918] = 2717; //jmpWhileDestinationName_2717
            code[919] = 2673; //var_whileCondition_0
            code[916] = 1279; //while_GoTo_True_1279
            code[898] = 1078; //while_GoTo_False_1078
            code[902] = 2375; //fake-fake-whileVirtualOperation_2375_2
            code[885] = 88; //fake-fake-whileVirtualOperation_88_-15
            code[917] = 2328; //fake-fake-whileVirtualOperation_2328_17
            code[922] = 2892; //fake-fake-whileVirtualOperation_2892_22

            code[969] = 3889; //ExpressionStatement_14 # ExpressionStatement_14
            code[994] = 3044; //sum
            code[985] = 3044; //sum
            code[965] = 2695; //"_"
            code[952] = 480; //var_forIndex_0
            code[990] = 2695; //"_"
            code[986] = 2747; //fake-ExpressionStatement_14_2747_17
            code[963] = 1488; //fake-ExpressionStatement_14_1488_-6
            code[971] = 1904; //fake-ExpressionStatement_14_1904_2
            code[956] = 837; //fake-ExpressionStatement_14_837_-13
            code[967] = 2728; //fake-ExpressionStatement_14_2728_-2
            code[988] = 2541; //fake-ExpressionStatement_14_2541_19

            code[1037] = 7862; //ExpressionStatement_7 # ExpressionStatement_15
            code[1056] = 3044; //sum
            code[1047] = 3044; //sum
            code[1044] = 2478; //"~"
            code[1036] = 3325; //fake-ExpressionStatement_7_3325_-1
            code[1043] = 3081; //fake-ExpressionStatement_7_3081_6
            code[1041] = 1973; //fake-ExpressionStatement_7_1973_4
            code[1036] = 3782; //fake-ExpressionStatement_7_3782_-1
            code[1059] = 65; //fake-ExpressionStatement_7_65_22

            code[1098] = 6517; //ExpressionStatement_16 # ExpressionStatement_16
            code[1103] = 2048; //r
            code[1122] = 2048; //r
            code[1110] = 3044; //sum
            code[1096] = 2115; //"#"
            code[1085] = 3780; //fake-ExpressionStatement_16_3780_-13

            code[1154] = 7716; //ExpressionStatement_1 # ExpressionStatement_17
            code[1149] = 2235; //invocationTemp_6
            code[1161] = 376; //fake-ExpressionStatement_1_376_7
            code[1169] = 6; //fake-ExpressionStatement_1_6_15
            code[1169] = 3932; //fake-ExpressionStatement_1_3932_15
            code[1170] = 1761; //fake-ExpressionStatement_1_1761_16
            code[1164] = 804; //fake-ExpressionStatement_1_804_10
            code[1140] = 2047; //fake-ExpressionStatement_1_2047_-14
            code[1172] = 2489; //fake-ExpressionStatement_1_2489_18

            code[1220] = 6043; //ExpressionStatement_3 # ExpressionStatement_18
            code[1249] = 3793; //invocationTemp_7
            code[1202] = 2235; //invocationTemp_6
            code[1217] = 3258; //fake-ExpressionStatement_3_3258_-3
            code[1242] = 2537; //fake-ExpressionStatement_3_2537_22
            code[1200] = 109; //fake-ExpressionStatement_3_109_-20
            code[1231] = 3426; //fake-ExpressionStatement_3_3426_11
            code[1222] = 3206; //fake-ExpressionStatement_3_3206_2

            code[1279] = 7054; //ExpressionStatement_19 # ExpressionStatement_19
            code[1285] = 3658; //invocationTemp_8
            code[1305] = 3793; //invocationTemp_7
            code[1307] = 1004; //fake-ExpressionStatement_19_1004_28

            code[1345] = 3144; //ExpressionStatement_20 # ExpressionStatement_20
            code[1362] = 1945; //p1
            code[1363] = 3658; //invocationTemp_8
            code[1328] = 1490; //fake-ExpressionStatement_20_1490_-17
            code[1330] = 3538; //fake-ExpressionStatement_20_3538_-15

            code[1408] = 6440; //ExpressionStatement_21 # ExpressionStatement_21
            code[1388] = 2048; //r
            code[1420] = 2048; //r
            code[1412] = 782; //"["
            code[1404] = 1945; //p1
            code[1390] = 1091; //"]"
            code[1399] = 1221; //fake-ExpressionStatement_21_1221_-9
            code[1428] = 282; //fake-ExpressionStatement_21_282_20
            code[1432] = 1532; //fake-ExpressionStatement_21_1532_24
            code[1426] = 6; //fake-ExpressionStatement_21_6_18

            code[1479] = 1796; //ExpressionStatement_22 # ExpressionStatement_22
            code[1460] = 3832; //memberTemp_1
            code[1497] = 2048; //r
            code[1459] = 2606; //fake-ExpressionStatement_22_2606_-20
            code[1505] = 2281; //fake-ExpressionStatement_22_2281_26

            code[1540] = 6361; //ExpressionStatement_23 # ExpressionStatement_23
            code[1544] = 3044; //sum
            code[1568] = 3044; //sum
            code[1530] = 3832; //memberTemp_1
            code[1569] = 1401; //fake-ExpressionStatement_23_1401_29

            code[1602] = 6050; //ExpressionStatement_24 # ExpressionStatement_24
            code[1631] = 3360; //dst
            code[1603] = 480; //var_forIndex_0
            code[1585] = 3044; //sum
            code[1623] = 689; //fake-ExpressionStatement_24_689_21
            code[1583] = 2266; //fake-ExpressionStatement_24_2266_-19
            code[1614] = 3081; //fake-ExpressionStatement_24_3081_12
            code[1607] = 318; //fake-ExpressionStatement_24_318_5
            code[1621] = 2641; //fake-ExpressionStatement_24_2641_19

            code[1663] = 5703; //ExpressionStatement_25 # ExpressionStatement_25
            code[1685] = 480; //var_forIndex_0
            code[1653] = 480; //var_forIndex_0
            code[1650] = 2282; //1
            code[1666] = 1455; //fake-ExpressionStatement_25_1455_3

            code[1731] = 8245; //ExpressionStatement_11 # ExpressionStatement_26
            code[1758] = 2008; //invocationTemp_9
            code[1757] = 2262; //b
            code[1722] = 84; //fake-ExpressionStatement_11_84_-9
            code[1754] = 394; //fake-ExpressionStatement_11_394_23

            code[1797] = 2063; //ExpressionStatement_12 # ExpressionStatement_27
            code[1805] = 2673; //var_whileCondition_0
            code[1781] = 480; //var_forIndex_0
            code[1784] = 2008; //invocationTemp_9
            code[1812] = 785; //fake-ExpressionStatement_12_785_15
            code[1804] = 576; //fake-ExpressionStatement_12_576_7
            code[1819] = 2705; //fake-ExpressionStatement_12_2705_22
            code[1803] = 2307; //fake-ExpressionStatement_12_2307_6

            code[1850] = 9860; //ExpressionStatement_28 # ExpressionStatement_28
            code[1864] = 1426; //while_FalseBlockSkip_1426
            code[1871] = 2694; //fake-ExpressionStatement_28_2694_21
            code[1839] = 1697; //fake-ExpressionStatement_28_1697_-11
            code[1869] = 408; //fake-ExpressionStatement_28_408_19
            code[1879] = 3033; //fake-ExpressionStatement_28_3033_29
            code[1858] = 1446; //fake-ExpressionStatement_28_1446_8
            code[1868] = 923; //fake-ExpressionStatement_28_923_18

            code[1901] = 1706; //ExpressionStatement_29 # ExpressionStatement_29
            code[1925] = 1495; //memberTemp_2
            code[1889] = 3360; //dst
            code[1910] = 3505; //fake-ExpressionStatement_29_3505_9
            code[1902] = 56; //fake-ExpressionStatement_29_56_1

            code[1962] = 2942; //ExpressionStatement_30 # ExpressionStatement_30
            code[1944] = 3044; //sum
            code[1961] = 3044; //sum
            code[1991] = 2115; //"#"
            code[1983] = 1495; //memberTemp_2
            code[1965] = 2058; //fake-ExpressionStatement_30_2058_3
            code[1950] = 3443; //fake-ExpressionStatement_30_3443_-12
            code[1973] = 28; //fake-ExpressionStatement_30_28_11

            code[2034] = 2372; //ReturnStatement_31 # ReturnStatement_31
            code[2058] = 3044; //sum
            code[2049] = 3215; //fake-ReturnStatement_31_3215_15
            code[2014] = 912; //fake-ReturnStatement_31_912_-20
            code[2032] = 1990; //fake-ReturnStatement_31_1990_-2

            return (string)InstanceInterpreterVirtualization_TraceLoopTests_3664_2_op4_in1(vpc, data, code);

        }


        private object InstanceInterpreterVirtualization_TraceLoopTests_3664_2_op4_in1(int vpc, object[] data, int[] code)
        {
            while (true)
            {
                switch (code[vpc])
                {
                    case 6361:  //frequency 1 ExpressionStatement_23
                        data[code[vpc + (4)]] = (string)data[code[vpc + (28)]] + (int)data[code[vpc + (-10)]];
                        vpc += 62;
                        break;
                    case 9860:  //frequency 1 ExpressionStatement_28
                        vpc += (int)data[code[vpc + (14)]];
                        vpc += 51;
                        break;
                    case 2372:  //frequency 1 ReturnStatement_31
                        return (string)data[code[vpc + (24)]];
                        vpc += 56;
                    case 6440:  //frequency 1 ExpressionStatement_21
                        data[code[vpc + (-20)]] = (string)data[code[vpc + (12)]] + (string)data[code[vpc + (4)]] + (double)data[code[vpc + (-4)]] + (string)data[code[vpc + (-18)]];
                        vpc += 71;
                        break;
                    case 4889:  //frequency 1 ExpressionStatement_9
                        data[code[vpc + (-8)]] = (string[])(new string[(int)data[code[vpc + (-18)]]]);
                        vpc += 66;
                        break;
                    case 6517:  //frequency 1 ExpressionStatement_16
                        data[code[vpc + (5)]] = (string)data[code[vpc + (24)]] + (string)data[code[vpc + (12)]] + (string)data[code[vpc + (-2)]];
                        vpc += 56;
                        break;
                    case 6043:  //frequency 2 ExpressionStatement_3
                        data[code[vpc + (29)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (-18)]]).GetPistons());
                        vpc += 59;
                        break;
                    case 6050:  //frequency 1 ExpressionStatement_24
                        ((string[])data[code[vpc + (29)]])[(int)data[code[vpc + (1)]]] = (string)data[code[vpc + (-17)]];
                        vpc += 61;
                        break;
                    case 7807:  //frequency 1 ExpressionStatement_5
                        data[code[vpc + (6)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (9)]]).GetPiston((int)data[code[vpc + (-13)]] - (int)data[code[vpc + (17)]]));
                        vpc += 65;
                        break;
                    case 8318:  //frequency 2 ExpressionStatement_8
                        data[code[vpc + (-18)]] = data[code[vpc + (15)]];
                        vpc += 66;
                        break;
                    case 1796:  //frequency 1 ExpressionStatement_22
                        data[code[vpc + (-19)]] = ((string)data[code[vpc + (18)]]).Length;
                        vpc += 61;
                        break;
                    default:  //frequency 3 ExpressionStatement_1
                        data[code[vpc + (-5)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                        vpc += 66;
                        break;
                    case 8245:  //frequency 2 ExpressionStatement_11
                        data[code[vpc + (27)]] = ReturnArg_Array((int)data[code[vpc + (26)]]);
                        vpc += 66;
                        break;
                    case 3144:  //frequency 1 ExpressionStatement_20
                        data[code[vpc + (17)]] = ((ConsoleCalculator.Piston)data[code[vpc + (18)]]).GetSize();
                        vpc += 63;
                        break;
                    case 2063:  //frequency 2 ExpressionStatement_12
                        data[code[vpc + (8)]] = (int)data[code[vpc + (-16)]] < (int)data[code[vpc + (-13)]];
                        vpc += 53;
                        break;
                    case 7862:  //frequency 2 ExpressionStatement_7
                        data[code[vpc + (19)]] = (string)data[code[vpc + (10)]] + (string)data[code[vpc + (7)]];
                        vpc += 61;
                        break;
                    case 5774:  //frequency 1 ExpressionStatement_0
                        data[code[vpc + (-20)]] = (string)data[code[vpc + (1)]] + (int)data[code[vpc + (-9)]] + (int)data[code[vpc + (11)]] + (string)data[code[vpc + (-10)]];
                        vpc += 56;
                        break;
                    case 7054:  //frequency 1 ExpressionStatement_19
                        data[code[vpc + (6)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (26)]]).First());
                        vpc += 66;
                        break;
                    case 2942:  //frequency 1 ExpressionStatement_30
                        data[code[vpc + (-18)]] = (string)data[code[vpc + (-1)]] + (string)data[code[vpc + (29)]] + (int)data[code[vpc + (21)]];
                        vpc += 72;
                        break;
                    case 7373:  //frequency 1 ExpressionStatement_4
                        data[code[vpc + (12)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-11)]]).Count;
                        vpc += 67;
                        break;
                    case 5703:  //frequency 1 ExpressionStatement_25
                        data[code[vpc + (22)]] = (int)data[code[vpc + (-10)]] + (int)data[code[vpc + (-13)]];
                        vpc += 68;
                        break;
                    case 2223:  //frequency 1 ExpressionStatement_6
                        data[code[vpc + (10)]] = ((ConsoleCalculator.Piston)data[code[vpc + (-3)]]).ToString();
                        vpc += 69;
                        break;
                    case 6605:  //frequency 1 WhileStatementSyntax_13
                        data[code[vpc + (18)]] = (bool)data[code[vpc + (19)]] ? (int)data[code[vpc + (16)]] : (int)data[code[vpc + (-2)]];
                        vpc += (int)data[code[vpc + (18)]];
                        break;
                    case 3889:  //frequency 1 ExpressionStatement_14
                        data[code[vpc + (25)]] = (string)data[code[vpc + (16)]] + (string)data[code[vpc + (-4)]] + (int)data[code[vpc + (-17)]] + (string)data[code[vpc + (21)]];
                        vpc += 68;
                        break;
                    case 1706:  //frequency 1 ExpressionStatement_29
                        data[code[vpc + (24)]] = ((string[])data[code[vpc + (-12)]]).Length;
                        vpc += 61;
                        break;
                }
            }

            return null;
        }



        private string ForSimple_Array_original_in(int b)
        {
            string sum = "" + 3 + 4 + "";

            sum += car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1).ToString();

            string r = "";
            string[] dst = new string[b];
            for (int i = 0; i < ReturnArg_Array(b); i++)
            {
                sum += "_" + i + "_";
                sum += "~";
                r += sum + "#";
                var p1 = car.GetEngine().GetPistons().First().GetSize();
                r += "[" + p1 + "]";
                sum += r.Length;
                dst[i] = sum;
            }

            sum += "#" + dst.Length;
            return sum;
        }


        private void ForLoop_Check()
        {
            string testName = "Performance_check#"+ TITLE;
            Program.Start_Check(testName);
            bool condition = true;

            int b = 5; //number of loops
            string oracle2 = ForSimple_Array_original_in(b);
            string virt21 = ForSimple_Array_obfuscated2_op4_in1(b);
            Debug.Assert(virt21.Equals(oracle2), "virt21");
            
            condition = virt21.Equals(oracle2);
            Program.End_Check(testName, condition);
        }




        public static string Time_Operation(string id, Func<int, string> method)
        {

            int op = 0;
            string log = id + " warming ... " + WARMUP + " times " ;
            Output(log);

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < WARMUP; i++)
            {
                method(NUMBER_OF_LOOPS);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("   {0}    , sec", timespan.TotalSeconds);
            log = id + " " + "  warmed up in,   " + time;
            Output(log);
            time_warmup.Add(log);

            log = id + " running ... " + ITERATIONS + " times " ;
            Output(log);
            timer = Stopwatch.StartNew();
            for (int j = 0; j < ITERATIONS; j++)
            {
                method(NUMBER_OF_LOOPS);
            }
            timer.Stop();
            timespan = timer.Elapsed;

            time = String.Format("  {0}     , sec", timespan.TotalSeconds);
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