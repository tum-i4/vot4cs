using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Recursive_method_default
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
            BinarySearch_Recursive_method_default bs = new BinarySearch_Recursive_method_default();
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

//            result += "t_original";
//            result += "     t_method";
//            result += "     t_class";
            result += " t_method_default";
//            result += " t_class_default";
//            result += "     t_method_junk";
//            result += "     t_class_junk";
            result += " " + "\n";


            int[] unsorted_original = testData.ToArray();
            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {                
                Console.WriteLine(i+ " ##############");
                Debug.WriteLine(i+ " ##############");
                string t_original = Time_Operation(i+ " BinarySearch_Recursive_method_default", BinarySearchRecursive_obfuscated);

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


//        [Obfuscation(Exclude = false, Feature = "virtualization; method")]
private static int BinarySearchRecursive_obfuscated(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    int[] code = new int[100416];
    object[] data = new object[4377];
    int vpc = 119;

    code[8635]=1141;code[70385]=-188;code[12284]=229;code[30917]=948;code[79665]=-890;code[13828]=-598;
    code[20114]=57;code[83905]=-555;code[869]=471;code[4471]=-652;code[75398]=137;code[4224]=1024;
    code[78138]=-425;code[68957]=1379;code[43330]=1169;code[2429]=-166;code[96464]=1433;code[2382]=1310;
    code[96956]=582;code[33711]=1008;code[62935]=-579;code[88188]=-834;code[99188]=14;code[34166]=-313;
    code[81143]=325;code[45037]=561;code[40197]=1184;code[85400]=577;code[81801]=1227;code[54912]=1230;
    code[80849]=-110;code[34927]=1313;code[2026]=1010;code[20100]=-433;code[40088]=1278;code[21346]=-62;
    code[25380]=-398;code[51483]=455;code[57906]=1438;code[82556]=-70;code[89361]=29;code[14419]=1253;
    code[42114]=-1;code[93726]=-783;code[12351]=-19;code[11007]=-814;code[8663]=108;code[100238]=-324;
    code[82413]=1381;code[4651]=-541;code[20649]=-717;code[87950]=1241;code[31876]=-818;code[37332]=-603;
    code[36251]=-330;code[5464]=1097;code[6913]=-564;code[225]=-17;code[21350]=115;code[50813]=551;
    code[87422]=-717;code[10424]=-984;code[80503]=-655;code[29045]=1022;code[24389]=-395;code[76474]=559;
    code[93309]=595;code[16739]=941;code[53797]=-383;code[58647]=-134;code[2799]=935;code[72893]=1137;
    code[33963]=-324;code[572]=1279;code[44314]=511;code[5815]=-65;code[44861]=64;code[31447]=-769;
    code[964]=1173;code[9544]=-552;code[78697]=406;code[92008]=-703;code[50867]=76;code[91361]=76;
    code[783]=-436;code[86133]=1414;code[86585]=-601;code[59509]=-760;code[38892]=-378;code[67112]=327;
    code[13287]=-57;code[36940]=595;code[18501]=-33;code[17784]=258;code[32654]=-815;code[77007]=666;
    code[15243]=11;code[56503]=163;code[86149]=517;code[34971]=1269;code[36219]=438;code[90772]=-462;
    code[75003]=-770;code[51423]=-283;code[83662]=-459;code[70801]=901;code[20176]=409;code[4728]=15;
    code[19551]=-305;code[93846]=-702;code[25448]=16;code[10572]=1333;code[46076]=-522;code[81735]=144;
    code[59938]=-682;code[23944]=950;code[90443]=901;code[17116]=392;code[47547]=-620;code[89493]=-770;
    code[87871]=1224;code[67304]=-729;code[37074]=-985;code[46746]=469;code[35903]=-609;code[27171]=449;
    code[67527]=-428;code[65695]=1385;code[47187]=1426;code[75984]=389;code[27932]=-864;code[69311]=764;
    code[98238]=1312;code[86350]=100;code[39505]=224;code[93659]=-895;code[38847]=1106;code[24531]=-92;
    code[73920]=1492;code[56661]=131;code[72878]=-435;code[10050]=101;code[86030]=646;code[10819]=679;
    code[10687]=-460;code[8754]=257;code[39725]=-161;code[81731]=1051;code[20053]=1411;code[13062]=110;
    code[14692]=-937;code[19530]=1168;code[22466]=-430;code[19375]=1075;code[98868]=-274;code[21904]=182;
    code[40788]=-240;code[83330]=-870;code[95833]=-376;code[85259]=-201;code[82049]=-530;code[33521]=-557;
    code[40447]=74;code[64946]=-872;code[2866]=59;code[16446]=929;code[87038]=-701;code[30755]=751;
    code[3168]=-419;code[21760]=571;code[46762]=-306;code[69005]=1039;code[100217]=535;code[9723]=-772;
    code[50784]=904;code[86982]=1374;code[11583]=1026;code[62986]=1395;code[69431]=-957;code[46670]=985;
    code[58383]=-646;code[80478]=402;code[12750]=116;code[60877]=-285;code[100195]=-677;code[2064]=804;
    code[3323]=-449;code[85754]=348;code[50301]=295;code[17995]=971;code[33423]=388;code[54777]=-334;
    code[55976]=-466;code[65908]=-860;code[49469]=-130;code[908]=-965;code[77093]=56;code[4732]=-190;
    code[47825]=-685;code[69155]=379;code[790]=1026;code[9407]=-60;code[74433]=-640;code[92060]=1237;
    code[96037]=-781;code[45914]=-567;code[84152]=690;code[46311]=-935;code[59864]=336;code[347]=1282;
    code[79333]=374;code[79693]=624;code[12080]=-985;code[95806]=526;code[17410]=324;code[6334]=-64;
    code[83289]=568;code[78404]=305;code[46349]=-578;code[52764]=32;code[29832]=903;code[10040]=11;
    code[89455]=1089;code[17699]=-771;code[96545]=-948;code[73085]=1353;code[12334]=939;code[76472]=145;
    code[1698]=109;code[25714]=837;code[19105]=-235;code[72444]=66;code[2491]=-794;code[34526]=-474;
    code[89901]=1347;code[56691]=67;code[930]=475;code[61855]=-929;code[45174]=-28;code[76200]=-289;
    code[83343]=1156;code[65167]=-619;code[80549]=-697;code[25284]=-866;code[86961]=-193;code[50748]=-956;
    code[91683]=976;code[22373]=1476;code[4024]=683;code[38152]=1020;code[49396]=1414;code[19715]=-944;
    code[45830]=-249;code[93615]=331;code[16027]=832;code[815]=570;code[68795]=1428;code[90876]=-181;
    code[66010]=422;code[62683]=1258;code[83425]=-276;code[34586]=431;code[43530]=367;code[51613]=-454;
    code[36909]=563;code[99256]=940;code[897]=1376;code[79591]=1160;code[66888]=566;code[69888]=253;
    code[19002]=798;code[89793]=-668;code[31598]=1193;code[33386]=1353;code[88912]=1237;code[33473]=177;
    code[4954]=191;code[98149]=-496;code[62394]=559;code[59150]=1273;code[79004]=783;code[16556]=335;
    code[74765]=-421;code[62166]=836;code[17965]=-898;code[66442]=-923;code[87666]=-693;code[71700]=-722;
    code[39740]=-472;code[25889]=390;code[21537]=431;code[33472]=181;code[29312]=293;code[72997]=330;
    code[97720]=476;code[24382]=-895;code[3750]=966;code[71756]=189;code[55676]=-101;code[39004]=-793;
    code[25933]=494;code[76575]=1111;code[23429]=-245;code[60047]=1316;code[76578]=1164;code[80950]=24;
    code[36753]=-918;code[69783]=-465;code[38172]=730;code[24344]=-433;code[50696]=-783;code[76449]=470;
    code[80130]=548;code[99774]=-784;code[40995]=-405;code[55931]=-911;code[82642]=-563;code[29911]=541;
    code[81327]=221;code[24023]=1473;code[92325]=1001;code[77285]=-733;code[78778]=1082;code[67907]=-989;
    code[9198]=250;code[9599]=1155;code[11792]=-597;code[58038]=-572;code[84012]=-565;code[4683]=534;
    code[31004]=278;code[52037]=310;code[31026]=925;code[58936]=-523;code[73808]=-804;code[40604]=1228;
    code[45495]=-368;code[30897]=760;code[31848]=635;code[80702]=1412;code[94703]=1472;code[99900]=1269;
    code[14328]=737;code[92225]=654;code[59945]=-684;code[78308]=588;code[44390]=563;code[68358]=19;
    code[28341]=-387;code[80152]=-965;code[24697]=213;code[27051]=-968;code[9635]=-490;code[41076]=1161;
    code[85713]=1183;code[85782]=-544;code[37221]=-797;code[67359]=-202;code[51878]=525;code[38321]=535;
    code[85536]=1313;code[59654]=521;code[29984]=922;code[45122]=1069;code[57451]=1249;code[42390]=-821;
    code[85947]=973;code[72214]=144;code[72278]=1454;code[81534]=1346;code[28696]=-866;code[81148]=808;
    code[27329]=493;code[26597]=-99;code[95844]=-98;code[89498]=679;code[86728]=-540;code[16309]=-199;
    code[89483]=651;code[71750]=-183;code[75793]=453;code[29360]=1384;code[45331]=956;code[32793]=453;
    code[36387]=-468;code[60226]=337;code[80162]=107;code[32970]=994;code[11757]=1176;code[33782]=753;
    code[50604]=-778;code[87690]=-473;code[852]=875;code[20898]=679;code[62961]=-4;code[56912]=-853;
    code[26828]=212;code[18448]=761;code[76468]=1135;code[27307]=224;code[27187]=709;code[100231]=853;
    code[76457]=-110;code[87727]=51;code[85930]=-89;code[20449]=-949;code[32571]=-967;code[82659]=664;
    code[71095]=-797;code[94924]=753;code[57670]=636;code[95817]=1409;code[64881]=351;code[26884]=-217;
    code[26045]=559;code[3654]=-344;code[60121]=1116;code[43230]=1050;code[9102]=-671;code[45140]=630;
    code[88017]=968;code[81947]=-344;code[19557]=365;code[73767]=-366;code[66440]=294;code[100061]=700;
    code[91276]=426;code[91919]=540;code[73244]=-915;code[9584]=-449;code[8900]=400;code[16188]=-421;
    code[32946]=1352;code[42346]=194;code[58517]=-993;code[57772]=440;code[63451]=-267;code[82813]=966;
    code[84213]=729;code[77237]=-751;code[80950]=-966;code[65450]=854;code[62998]=-110;code[35525]=-930;
    code[93516]=1036;code[9126]=-859;code[3640]=-428;code[56582]=-210;code[62891]=460;code[93828]=-366;
    code[12511]=-358;code[67394]=646;code[94631]=50;code[4838]=539;code[74908]=-679;code[78057]=-906;
    code[26615]=1489;code[41619]=-813;code[91215]=48;code[60702]=1429;code[58952]=-16;code[54863]=920;
    code[91576]=297;code[54229]=7;code[73275]=270;code[16114]=-364;code[76044]=288;code[97926]=373;
    code[34409]=1482;code[80255]=-482;code[30940]=845;code[28321]=1006;code[3731]=-868;code[79465]=-899;
    code[81781]=221;code[40965]=-484;code[98374]=1406;code[66956]=827;code[71353]=1257;code[74991]=58;
    code[88375]=613;code[88972]=-406;code[97214]=307;code[28157]=874;code[2050]=1163;code[73517]=1288;
    code[62290]=-7;code[66641]=1122;code[11209]=859;code[73412]=1147;code[73057]=248;code[59098]=-398;
    code[10081]=1384;code[27592]=986;code[85200]=-390;code[84209]=99;code[24721]=-61;code[32846]=657;
    code[85549]=-889;code[83802]=285;code[77597]=-896;code[2028]=1372;code[933]=3776;    data[2778]=-46;
code[433]=2764;    data[1759]=1;
    data[1063]=882;
code[312]=1742;code[835]=369;code[304]=583;code[1208]=1029;    data[2574]=324;
code[528]=776;code[274]=1144;code[1074]=132;code[1188]=849;code[945]=614;code[849]=929;code[745]=1464;code[470]=2016;code[212]=2151;code[1021]=17;code[872]=2601;    data[452]=378;
code[560]=2219;code[748]=2296;    data[316]=-903;
    data[1578]=74;
    data[1804]=143;
    data[1040]=-30;
    data[3275]=197;
    data[3894]=756;
code[1264]=1831;code[973]=2031;    data[2665]=-782;
code[648]=699;    data[687]=-717;
    data[2912]=526;
    data[3298]=-838;
    data[2151]=false;
code[1193]=672;code[584]=3425;    data[3776]=-75;
code[428]=1464;code[1010]=7163;code[509]=2412;code[809]=1843;code[119]=6449;    data[63]=392;
code[823]=2511;    data[147]=-594;
    data[3418]=227;
    data[3410]=-75;
code[629]=1792;    data[501]=332;
code[559]=3912;code[885]=4483;code[506]=8411;code[942]=3075;    data[132]=190;
    data[2250]=895;
    data[3633]=-799;
code[500]=2296;code[543]=1503;code[1270]=7163;    data[2544]=556;
    data[2899]=-533;
    data[3766]=322;
    data[743]=745;
code[822]=244;code[473]=1001;    data[1335]=215;
code[1231]=2296;    data[1503]=432;
code[683]=252;code[698]=54;    data[928]=336;
    data[2803]=191;
    data[3772]=-487;
    data[1159]=649;
    data[2181]=-121;
code[1165]=1759;    data[2016]=2;
code[503]=3715;code[704]=1996;    data[439]=-511;
    data[1843]=728;
code[1133]=988;    data[2281]=263;
    data[3740]=-824;
    data[2461]=-176;
    data[1185]=-514;
code[206]=3984;code[751]=2718;    data[1224]=-579;
code[759]=929;code[812]=3766;    data[2049]=463;
code[905]=1464;code[869]=1635;    data[1542]=720;
code[1163]=1464;    data[2046]=296;
    data[1777]=-683;
    data[3377]=-560;
    data[988]=-136;
code[189]=2219;code[826]=2219;code[230]=476;code[572]=2575;code[1009]=1025;    data[929]=false;
code[770]=1887;code[1255]=2685;code[251]=1328;    data[3748]=185;
code[408]=1824;code[508]=2718;code[144]=3075;code[1062]=3862;    data[3137]=-783;
code[825]=2378;    data[615]=823;
code[891]=2900;    data[2718]=key;
code[369]=1167;code[1066]=2629;code[640]=1464;code[583]=1448;code[1233]=3571;code[843]=2769;code[397]=3057;code[1140]=1695;code[1028]=1570;    data[1783]=-336;
    data[155]=416;
    data[2737]=954;
code[561]=3579;code[1207]=3082;code[275]=2003;code[437]=1258;code[908]=3776;    data[1301]=197;
code[1106]=2863;code[1284]=2161;    data[296]=267;
code[1036]=255;    data[2864]=773;
code[970]=1777;    data[111]=338;
code[1288]=948;code[269]=3667;code[687]=3771;code[316]=3771;code[1204]=186;    data[2380]=-200;
    data[3211]=-378;
code[386]=7706;    data[2669]=72;
    data[3667]=-1;
code[1291]=528;    data[707]=367;
    data[1905]=121;
    data[251]=59;
code[707]=300;code[326]=1641;code[107]=672;    data[538]=827;
    data[1326]=-975;
    data[1778]=841;
    data[1464]=186;
    data[126]=-719;
code[403]=672;code[757]=5236;    data[3161]=-283;
code[143]=1802;code[141]=742;code[528]=2078;code[342]=3130;        data[2296]=(int[])inputArray;
code[1064]=3462;    data[1340]=59;
code[671]=1854;code[499]=1448;code[118]=2151;code[948]=1029;code[533]=1464;code[629]=1543;code[1139]=1262;code[992]=2034;code[371]=2764;    data[364]=45;
    data[2220]=875;
code[971]=2296;code[605]=1153;code[175]=1301;code[693]=682;    data[369]=59;
code[198]=1340;    data[2300]=-873;
code[1195]=505;    data[3728]=276;
code[711]=2804;    data[3758]=-95;
code[446]=4643;code[1230]=528;code[625]=1066;    data[226]=-27;
code[619]=7163;    data[1034]=-80;
code[1212]=2718;    data[1951]=-392;
    data[1567]=-384;
code[469]=841;code[975]=3056;code[952]=2718;    data[462]=-717;
code[1027]=241;code[172]=3633;    data[672]=max;
    data[2084]=-970;
    data[3737]=55;
    data[3075]=min;
    data[551]=-982;
code[851]=2262;    data[2764]=-988;
    data[1968]=-455;
code[1090]=783;    data[1569]=521;
code[845]=3466;    data[3564]=963;
    data[2812]=-174;
code[1091]=1375;code[611]=1442;code[882]=1759;code[960]=447;code[1090]=74;    data[1986]=-405;
    data[1448]=false;
code[810]=184;code[1148]=7706;    data[2363]=293;
code[1260]=1828;code[236]=1820;    data[637]=-180;
code[1233]=1126;    data[900]=555;
code[546]=3275;code[436]=2325;    data[2386]=-92;
    data[252]=581;
    data[1480]=477;
code[1202]=988;    data[3675]=52;
code[535]=2214;code[1218]=2130;code[1078]=3771;code[1101]=2445;    data[3782]=194;
    data[2370]=987;
code[992]=3772;code[148]=1898;code[401]=3075;code[569]=251;    data[528]=-407;
code[1289]=438;code[248]=6411;code[1031]=1777;    data[2468]=256;
    data[3112]=675;
    data[1742]=952;

    while(true)
    {
    	switch(code[vpc])
    	{
    		case 4643:
    			data[code[vpc+(-18)]]= (int)data[code[vpc+(-13)]]/ (int)data[code[vpc+(24)]];
    			vpc+=60;
    			break;
    		case 2219:
    			data[code[vpc+(-17)]]=(bool)data[code[vpc+(23)]]?(int)data[code[vpc+(9)]]:(int)data[code[vpc+(-14)]];
    			vpc+=(int)data[code[vpc+(-17)]];
    			break;
    		case 3771:
    			vpc += (int)data[code[vpc+(-4)]];
    			vpc+=70;
    			break;
    		case 4483:
    			data[code[vpc+(23)]]= (int)data[code[vpc+(20)]]- (int)data[code[vpc+(-3)]];
    			vpc+=63;
    			break;
    		case 8411:
    			data[code[vpc+(-7)]]= (int)data[code[vpc+(2)]]== ((int[])data[code[vpc+(-6)]])[(int)data[code[vpc+(27)]]];
    			vpc+=54;
    			break;
    		case 1029:
    			data[code[vpc+(22)]]= BinarySearchRecursive_obfuscated((int[])data[code[vpc+(23)]], (int)data[code[vpc+(4)]], (int)data[code[vpc+(-6)]], (int)data[code[vpc+(-15)]]);
    			vpc+=62;
    			break;
    		case 7706:
    			data[code[vpc+(-15)]]= (int)data[code[vpc+(15)]]+ (int)data[code[vpc+(17)]];
    			vpc+=60;
    			break;
    		case 6449:
    			data[code[vpc+(-1)]]= (int)data[code[vpc+(-12)]]< (int)data[code[vpc+(25)]];
    			vpc+=70;
    			break;
    		default:
    			return (int)data[code[vpc+(21)]];
    			vpc+=68;
    		case 5236:
    			data[code[vpc+(2)]]= (int)data[code[vpc+(-6)]]< ((int[])data[code[vpc+(-9)]])[(int)data[code[vpc+(-12)]]];
    			vpc+=69;
    			break;
    	}
    }

    return 0;
}

        


        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Recursive_method_default";
            Program.Start_Check(testName);
            bool condition = true;


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