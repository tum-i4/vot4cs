using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Iterative_method_default

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
            BinarySearch_Iterative_method_default bs = new BinarySearch_Iterative_method_default();
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
//            result += " t_method_default";
//            result += " t_class_default";
            result += "     t_method_junk";
//            result += "     t_class_junk";
            result += " " + "\n";


            int[] unsorted_original = testData.ToArray();
            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {                
                Console.WriteLine(i+ " ##############");
                Debug.WriteLine(i+ " ##############");
                string t_original = Time_Operation(i+ " BinarySearch_Iterative_method_default", BinarySearchIterative_obfuscated);

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

//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
private static int BinarySearchIterative_refactored(int[] inputArray, int key, int min, int max)
{
    bool var_whileCondition_0 = min <= max;
    while (var_whileCondition_0)
    {
        int mid = (min + max) / 2;
        bool var_ifCondition_1 = key == inputArray[mid];
        if (var_ifCondition_1)
        {
            return mid;
        }
        else
        {
            bool var_ifCondition_0 = key < inputArray[mid];
            if (var_ifCondition_0)
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }

        var_whileCondition_0 = min <= max;
    }

    return -1;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
        private static int BinarySearchIterative_method_readable_1(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    int[] code = new int[100726];
    object[] data = new object[4654];
    int vpc = 59;

    //Data init
    data[3438]=(int[])inputArray; //inputArray 
    data[2973]=key; //key 
    data[3502]=min; //min 
    data[3153]=max; //max 
    data[2399]=2; //2 constant
    data[2124]=1; //1 constant
    data[58]=-1; //-1 constant
    data[425]=false; //var_whileCondition_0 
    data[812]=-357; //mid 
    data[563]=false; //var_ifCondition_1 
    data[1163]=false; //var_ifCondition_0 
    data[1184]=995; //jmpWhileDestinationName_1184 constant
    data[3837]=54; //while_GoTo_True_3837 constant
    data[1901]=748; //while_GoTo_False_1901 constant
    data[3385]=-748; //while_FalseBlockSkip_3385 constant
    data[1973]=-311; //jmpDestinationName_1973 constant
    data[43]=54; //if_GoTo_True_43 constant
    data[2920]=168; //if_GoTo_False_2920 constant
    data[2915]=281; //if_FalseBlockSize_Skip_2915 constant
    data[335]=890; //jmpDestinationName_335 constant
    data[2993]=54; //if_GoTo_True_2993 constant
    data[3781]=170; //if_GoTo_False_3781 constant
    data[751]=56; //if_FalseBlockSize_Skip_751 constant

    //Code init

    code[59]=3300; //ExpressionStatement_0 # ExpressionStatement_0
    code[46]=425; //var_whileCondition_0
    code[64]=3502; //min
    code[58]=3153; //max

    code[116]=7640; //WhileStatementSyntax_1 # WhileStatementSyntax_1
    code[102]=1184; //jmpWhileDestinationName_1184
    code[104]=425; //var_whileCondition_0
    code[105]=3837; //while_GoTo_True_3837
    code[139]=1901; //while_GoTo_False_1901

    code[170]=1290; //ExpressionStatement_2 # ExpressionStatement_2
    code[182]=812; //mid
    code[195]=3502; //min
    code[165]=3153; //max
    code[154]=2399; //2

    code[238]=2862; //ExpressionStatement_3 # ExpressionStatement_3
    code[252]=563; //var_ifCondition_1
    code[262]=2973; //key
    code[219]=3438; //inputArray
    code[261]=812; //mid

    code[296]=7640; //WhileStatementSyntax_1 # IfStatementSyntax_4
    code[282]=1973; //jmpDestinationName_1973
    code[284]=563; //var_ifCondition_1
    code[285]=43; //if_GoTo_True_43
    code[319]=2920; //if_GoTo_False_2920

    code[350]=2296; //ReturnStatement_5 # ReturnStatement_5
    code[371]=812; //mid

    code[402]=8554; //ExpressionStatement_6 # ExpressionStatement_6
    code[419]=2915; //if_FalseBlockSize_Skip_2915

    code[464]=3116; //ExpressionStatement_7 # ExpressionStatement_7
    code[475]=1163; //var_ifCondition_0
    code[481]=2973; //key
    code[458]=3438; //inputArray
    code[456]=812; //mid

    code[519]=7640; //WhileStatementSyntax_1 # IfStatementSyntax_8
    code[505]=335; //jmpDestinationName_335
    code[507]=1163; //var_ifCondition_0
    code[508]=2993; //if_GoTo_True_2993
    code[542]=3781; //if_GoTo_False_3781

    code[573]=9682; //ExpressionStatement_9 # ExpressionStatement_9
    code[559]=3153; //max
    code[560]=812; //mid
    code[566]=2124; //1

    code[627]=8554; //ExpressionStatement_6 # ExpressionStatement_10
    code[644]=751; //if_FalseBlockSize_Skip_751

    code[689]=3063; //ExpressionStatement_11 # ExpressionStatement_11
    code[705]=3502; //min
    code[704]=812; //mid
    code[717]=2124; //1

    code[745]=3300; //ExpressionStatement_0 # ExpressionStatement_12
    code[732]=425; //var_whileCondition_0
    code[750]=3502; //min
    code[744]=3153; //max

    code[802]=8554; //ExpressionStatement_6 # ExpressionStatement_13
    code[819]=3385; //while_FalseBlockSkip_3385

    code[864]=2296; //ReturnStatement_5 # ReturnStatement_14
    code[885]=58; //-1

    while(true)
    {
    	switch(code[vpc])
    	{
    		case 1290: //frequency 1 ExpressionStatement_2
    			data[code[vpc+(12)]]= ((int)data[code[vpc+(25)]]+ (int)data[code[vpc+(-5)]]) / (int)data[code[vpc+(-16)]];
    			vpc+=68;
    			break;
    		case 2296: //frequency 2 ReturnStatement_5
    			return (int)data[code[vpc+(21)]];
    			vpc+=52;
    		case 9682: //frequency 1 ExpressionStatement_9
    			data[code[vpc+(-14)]]= (int)data[code[vpc+(-13)]]- (int)data[code[vpc+(-7)]];
    			vpc+=54;
    			break;
    		case 7640: //frequency 3 WhileStatementSyntax_1
    			data[code[vpc+(-14)]]=(bool)data[code[vpc+(-12)]]?(int)data[code[vpc+(-11)]]:(int)data[code[vpc+(23)]];
    			vpc+=(int)data[code[vpc+(-14)]];
    			break;
    		case 3116: //frequency 1 ExpressionStatement_7
    			data[code[vpc+(11)]]= (int)data[code[vpc+(17)]]< ((int[])data[code[vpc+(-6)]])[(int)data[code[vpc+(-8)]]];
    			vpc+=55;
    			break;
    		case 2862: //frequency 1 ExpressionStatement_3
    			data[code[vpc+(14)]]= (int)data[code[vpc+(24)]]== ((int[])data[code[vpc+(-19)]])[(int)data[code[vpc+(23)]]];
    			vpc+=58;
    			break;
    		case 3063: //frequency 1 ExpressionStatement_11
    			data[code[vpc+(16)]]= (int)data[code[vpc+(15)]]+ (int)data[code[vpc+(28)]];
    			vpc+=56;
    			break;
    		case 8554: //frequency 3 ExpressionStatement_6
    			vpc += (int)data[code[vpc+(17)]];
    			vpc+=62;
    			break;
    		default: //frequency 0 
    			break;
    		case 3300: //frequency 2 ExpressionStatement_0
    			data[code[vpc+(-13)]]= (int)data[code[vpc+(5)]]<= (int)data[code[vpc+(-1)]];
    			vpc+=57;
    			break;
    	}
    }

    return 0;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]
        private static int BinarySearchIterative_obfuscated(int[] inputArray, int key, int min, int max)
{
    //Virtualization variables
    int[] code = new int[100815];
    object[] data = new object[4674];
    int vpc = 117;

    code[93404]=353;code[86455]=258;code[92972]=1209;code[99738]=-419;code[554]=760;code[40016]=666;
    code[87758]=503;code[69195]=355;code[84489]=280;code[5223]=661;code[27390]=-970;code[24641]=-953;
    code[99200]=764;code[19813]=-646;code[20290]=248;code[46289]=1152;code[4886]=148;code[34477]=1351;
    code[435]=99;code[99376]=-79;code[87006]=836;code[539]=1373;code[57177]=1296;code[64821]=1496;
    code[92265]=-450;code[59687]=1432;code[57765]=1388;code[91724]=1285;code[29921]=1096;code[52359]=-460;
    code[69304]=1118;code[3161]=265;code[24702]=339;code[62307]=28;code[26165]=864;code[54244]=-5;
    code[53054]=707;code[80811]=342;code[687]=-263;code[45551]=-837;code[6339]=-506;code[22844]=1452;
    code[91479]=215;code[29037]=-768;code[55389]=69;code[64898]=-586;code[92794]=923;code[68678]=-962;
    code[70904]=248;code[71026]=-922;code[30300]=-421;code[74523]=-577;code[68769]=-516;code[45038]=1224;
    code[15499]=-68;code[91489]=-996;code[38988]=134;code[15471]=224;code[62597]=-875;code[60349]=897;
    code[24989]=312;code[86882]=1079;code[10290]=-70;code[48169]=892;code[190]=965;code[84048]=268;
    code[59514]=51;code[77106]=1077;code[46227]=-857;code[30134]=784;code[3970]=-5;code[94704]=-559;
    code[52438]=604;code[78535]=166;code[62093]=-522;code[39780]=632;code[90802]=1364;code[78974]=939;
    code[37294]=1268;code[6785]=-226;code[72182]=724;code[89520]=-81;code[54351]=0;code[41494]=1415;
    code[69474]=-195;code[3138]=409;code[75751]=1212;code[72535]=1124;code[59026]=713;code[31426]=150;
    code[59813]=-972;code[14210]=1025;code[39466]=-549;code[61174]=611;code[64241]=1472;code[46496]=378;
    code[99797]=1472;code[100574]=-127;code[51433]=429;code[64265]=-700;code[23209]=1032;code[78366]=-267;
    code[16173]=1077;code[90894]=-961;code[22797]=1334;code[19171]=711;code[60045]=517;code[72235]=761;
    code[55339]=-806;code[98413]=-104;code[79967]=917;code[33158]=749;code[86812]=199;code[57846]=905;
    code[89461]=-76;code[34230]=-966;code[4813]=-522;code[23192]=951;code[23590]=1118;code[65518]=401;
    code[28136]=477;code[42196]=758;code[80551]=941;code[96338]=-43;code[27476]=-268;code[80710]=81;
    code[60039]=-303;code[32958]=158;code[48790]=-807;code[43599]=701;code[25918]=-652;code[12934]=1140;
    code[59894]=-560;code[64214]=10;code[38005]=1340;code[47449]=753;code[43123]=39;code[7997]=-495;
    code[35116]=563;code[90828]=-789;code[52859]=-523;code[49376]=486;code[57404]=1267;code[42162]=921;
    code[87171]=916;code[29887]=-609;code[41826]=1423;code[30596]=-651;code[46658]=406;code[11036]=556;
    code[14066]=378;code[593]=-159;code[82899]=-753;code[480]=-551;code[20133]=-688;code[11592]=1146;
    code[17785]=-131;code[15745]=-835;code[65479]=334;code[28907]=717;code[76435]=1170;code[54372]=525;
    code[64484]=-215;code[28901]=145;code[11302]=1348;code[74529]=964;code[52005]=-305;code[95278]=1431;
    code[18653]=-617;code[77841]=175;code[90959]=-405;code[57362]=849;code[65704]=94;code[98819]=-833;
    code[81983]=-407;code[49430]=1322;code[27792]=55;code[87147]=-322;code[1235]=-11;code[70248]=270;
    code[81895]=366;code[6838]=-350;code[38867]=-178;code[34556]=1245;code[40603]=-542;code[88831]=240;
    code[76794]=1040;code[79123]=299;code[30170]=998;code[96631]=-496;code[33653]=-451;code[65040]=1186;
    code[45285]=1025;code[51438]=-767;code[41727]=684;code[96829]=973;code[46023]=-341;code[66339]=-111;
    code[17183]=-229;code[35719]=-194;code[9582]=-795;code[66968]=574;code[35906]=1485;code[16856]=148;
    code[64272]=-139;code[97992]=-469;code[44066]=237;code[17587]=481;code[90858]=-518;code[81759]=438;
    code[82550]=-377;code[48811]=822;code[22479]=-771;code[3998]=244;code[15959]=72;code[35230]=1476;
    code[44879]=589;code[10762]=-371;code[55988]=-962;code[52284]=137;code[64835]=-873;code[45965]=-827;
    code[70752]=869;code[35515]=1403;code[9012]=-837;code[45829]=1443;code[50185]=947;code[50793]=1114;
    code[60282]=1338;code[41009]=-339;code[96223]=673;code[30346]=-479;code[100317]=1453;code[77385]=1003;
    code[39139]=1306;code[3763]=1214;code[67990]=-111;code[93967]=919;code[79981]=37;code[2735]=188;
    code[74547]=-805;code[41181]=-768;code[98234]=-70;code[49667]=665;code[13308]=-348;code[65905]=550;
    code[61355]=-365;code[50467]=1434;code[75599]=-382;code[7489]=800;code[98806]=377;code[57794]=-584;
    code[2824]=421;code[30545]=-646;code[85391]=839;code[5283]=-543;code[91559]=1328;code[52923]=1190;
    code[26295]=-480;code[23602]=557;code[49285]=-747;code[67469]=-682;code[27122]=43;code[27951]=50;
    code[86228]=1395;code[1818]=364;code[34328]=-233;code[49922]=-529;code[50897]=-396;code[6547]=14;
    code[6962]=-124;code[82571]=-10;code[21029]=176;code[71762]=692;code[73517]=560;code[71877]=354;
    code[1339]=128;code[23326]=1196;code[88895]=115;code[90490]=526;code[29383]=1206;code[28889]=1221;
    code[72370]=266;code[84949]=503;code[43986]=-159;code[37447]=-953;code[14426]=1071;code[55846]=-655;
    code[28479]=-318;code[92611]=996;code[71120]=500;code[69659]=-423;code[24730]=190;code[53699]=1223;
    code[7609]=541;code[30915]=-853;code[34705]=135;code[11514]=-535;code[6474]=1325;code[68376]=755;
    code[63305]=-724;code[24274]=-19;code[25488]=734;code[40197]=-538;code[90463]=-767;code[60090]=521;
    code[53169]=-753;code[91262]=728;code[19336]=-862;code[64866]=-396;code[98172]=1383;code[53013]=1049;
    code[3012]=-219;code[68022]=722;code[72003]=-81;code[7448]=-120;code[59973]=-459;code[17189]=487;
    code[36230]=-255;code[98617]=378;code[7811]=-131;code[99998]=1455;code[2075]=745;code[53575]=-388;
    code[55343]=57;code[100257]=-979;code[28922]=91;code[73426]=686;code[58940]=52;code[36578]=1350;
    code[1941]=774;code[47445]=324;code[1956]=-391;code[1384]=-223;code[93620]=-225;code[33462]=1233;
    code[7794]=-770;code[16550]=564;code[96931]=359;code[80558]=-171;code[78755]=74;code[14104]=-272;
    code[37622]=-838;code[6581]=-605;code[49214]=239;code[1039]=1345;code[94305]=-905;code[53638]=-81;
    code[88432]=155;code[97062]=941;code[68985]=-449;code[31902]=-404;code[9173]=-748;code[93896]=-514;
    code[27463]=-745;code[71885]=-898;code[62710]=-923;code[16030]=474;code[57459]=-552;code[15775]=1385;
    code[18004]=1138;code[82941]=81;code[30242]=-16;code[96590]=-902;code[56461]=991;code[75489]=248;
    code[58559]=-945;code[65283]=401;code[11410]=1253;code[20193]=-320;code[13488]=1176;code[89309]=-36;
    code[78927]=1423;code[31879]=1261;code[88614]=1356;code[80416]=744;code[30825]=-979;code[60298]=1072;
    code[40105]=1209;code[94632]=743;code[14399]=1230;code[63989]=189;code[35641]=-466;code[46386]=499;
    code[38652]=495;code[48032]=671;code[98698]=1210;code[82710]=-230;code[97744]=92;code[65507]=-174;
    code[7807]=-866;code[16162]=544;code[100700]=-873;code[19505]=430;code[42770]=1046;code[16416]=-427;
    code[97038]=257;code[13046]=-396;code[23769]=25;code[3255]=422;code[51335]=791;code[52530]=-299;
    code[46977]=-678;code[72469]=53;code[18967]=-275;code[86629]=1402;code[23588]=520;code[62492]=-778;
    code[73770]=-958;code[48087]=-244;code[2048]=1219;code[17685]=411;code[43907]=-383;code[71192]=190;
    code[76096]=446;code[7290]=398;code[40788]=-799;code[82814]=-98;code[53691]=1199;code[15288]=1174;
    code[33479]=929;code[38729]=-665;code[96723]=-496;code[100355]=-114;code[89028]=-900;code[51412]=-454;
    code[94061]=824;code[55324]=553;code[54551]=1390;code[85198]=-453;code[42622]=-393;code[67213]=523;
    code[21947]=-251;code[56086]=-617;code[79297]=-353;code[56115]=1130;code[87248]=517;code[97840]=-380;
    code[50774]=-897;code[61019]=-416;code[25361]=-121;code[59777]=786;code[6929]=1134;code[63162]=687;
    code[53623]=-500;code[82646]=440;code[3487]=1331;code[45077]=-777;code[10610]=936;code[92398]=649;
    code[65082]=1105;code[57257]=560;code[48753]=644;code[35611]=-186;code[76537]=-249;code[11870]=249;
    code[35396]=528;code[97527]=-823;code[65514]=1380;code[54510]=-90;code[67870]=1203;code[62645]=466;
    code[44275]=1451;code[82412]=1331;code[16123]=1203;code[14428]=822;code[12569]=1363;code[59284]=23;
    code[79008]=1422;code[23289]=27;code[50447]=-249;code[92316]=-422;code[8298]=-201;code[22692]=57;
    code[97314]=-60;code[44301]=-618;code[23593]=381;code[99447]=910;code[22255]=1453;code[18643]=257;
    code[84728]=51;code[16735]=1194;code[15856]=-28;code[37827]=13;code[2361]=394;code[28976]=702;
    code[72694]=-676;code[87070]=-69;code[97358]=-26;code[50830]=-702;code[76147]=-15;code[97535]=959;
    code[44536]=1474;code[49891]=430;code[96695]=1059;code[19020]=1005;code[79027]=819;code[57502]=-801;
    code[13567]=-906;code[7481]=733;code[95235]=1048;code[40293]=18;code[8930]=896;code[43559]=-740;    data[800]=-766;
    data[1911]=2;
code[454]=1455;    data[413]=-920;
    data[961]=-54;
code[111]=3109;    data[950]=254;
    data[2717]=62;
    data[3955]=-848;
code[914]=1622;    data[2127]=773;
    data[1617]=-481;
    data[1455]=184;
code[567]=2810;    data[3584]=-445;
code[559]=2696;code[475]=3642;    data[2649]=-843;
code[623]=2390;    data[1442]=-335;
code[988]=1010;    data[1529]=-191;
code[745]=3908;code[168]=62;    data[2924]=-46;
    data[1313]=-662;
code[865]=7301;code[108]=3358;code[989]=3435;    data[1317]=-236;
code[101]=1907;    data[672]=826;
    data[2397]=816;
code[894]=3358;    data[3530]=-678;
    data[1880]=-478;
code[948]=3525;    data[932]=-646;
code[424]=2314;code[1065]=289;    data[492]=false;
    data[1516]=-212;
code[832]=1781;code[983]=1191;code[829]=3997;    data[2214]=-202;
code[418]=3634;    data[151]=59;
    data[2937]=176;
    data[2407]=54;
code[114]=2448;code[176]=667;    data[901]=-571;
code[240]=1622;code[893]=3998;    data[2390]=key;
code[810]=9528;code[708]=2937;code[169]=492;code[1063]=3739;    data[442]=268;
    data[896]=-43;
code[581]=900;code[703]=73;code[619]=5939;code[604]=1655;    data[1622]=max;
    data[656]=382;
code[417]=3980;code[672]=788;code[444]=3929;    data[2053]=-975;
code[205]=553;code[909]=2328;    data[3465]=28;
code[678]=1202;code[748]=2545;code[602]=3532;    data[2272]=658;
code[267]=2336;    data[43]=-660;
code[797]=3335;code[628]=3425;code[680]=1794;code[388]=606;code[925]=2242;code[308]=1924;    data[989]=-522;
    data[669]=-306;
code[291]=2354;code[385]=3425;code[1061]=2053;code[250]=1921;code[860]=3015;    data[3292]=-51;
    data[2314]=59;
    data[1636]=-224;
code[616]=1674;code[1075]=92;code[323]=2690;    data[3538]=874;
code[751]=1622;    data[214]=-943;
    data[3574]=-302;
code[562]=2827;code[979]=578;    data[2389]=-170;
code[922]=492;code[307]=5133;    data[2972]=-463;
code[290]=2905;code[494]=4783;code[312]=2517;    data[489]=989;
    data[33]=-347;
    data[3358]=min;
code[545]=2146;    data[3395]=342;
code[379]=7687;    data[3015]=1;
    data[1712]=-873;
code[253]=684;code[435]=7415;    data[570]=-569;
    data[3797]=299;
code[761]=42;    data[2957]=-448;
    data[3408]=-94;
code[112]=492;code[117]=3245;    data[1082]=910;
code[245]=7301;code[1038]=1989;code[638]=570;code[459]=2398;code[189]=427;code[728]=451;    data[48]=42;
code[390]=3634;    data[1068]=-717;
code[792]=1605;code[802]=2717;code[859]=570;code[1044]=2562;code[681]=99;code[1009]=2557;code[167]=3679;code[854]=3519;code[288]=1911;code[179]=2924;code[455]=2480;code[793]=1993;    data[1963]=291;
    data[304]=608;
    data[439]=561;
code[736]=3015;    data[1208]=157;
code[1070]=877;code[187]=547;code[513]=39;code[737]=1743;code[797]=3523;    data[67]=-885;
    data[1929]=418;
    data[219]=-986;
code[645]=3768;code[869]=2599;    data[788]=false;
code[99]=3732;code[583]=3837;    data[3240]=-385;
code[629]=3273;code[333]=2441;code[1055]=1720;    data[3717]=-244;
    data[536]=-474;
code[635]=1653;code[800]=3475;    data[1565]=107;
    data[3683]=-281;
code[677]=1146;    data[847]=-199;
    data[326]=454;
    data[1010]=-865;
    data[1942]=955;
    data[1926]=36;
    data[1989]=-1;
    data[1829]=-407;
code[701]=2557;    data[900]=-192;
    data[2073]=-904;
    data[2405]=-929;
    data[3297]=-10;
code[1063]=43;code[631]=788;code[987]=668;code[996]=9528;code[297]=2304;    data[2290]=547;
    data[130]=-455;
code[881]=2470;    data[3634]=false;
    data[553]=865;
code[572]=86;code[581]=2430;code[556]=3410;code[175]=151;code[481]=570;code[863]=3301;    data[2291]=293;
    data[2498]=-734;
code[373]=2615;code[428]=3228;code[1046]=3124;    data[1193]=618;
code[1078]=3717;    data[444]=-960;
    data[2930]=809;
code[1051]=4783;    data[3745]=-787;
    data[3228]=-626;
code[239]=3358;    data[148]=970;
    data[2979]=-671;
    data[2246]=-457;
code[682]=2957;    data[2153]=26;
    data[2905]=-518;
code[992]=3791;    data[3720]=646;
    data[797]=-119;
    data[2868]=-188;
code[891]=477;    data[3619]=-153;
code[104]=1622;    data[641]=269;
code[564]=9528;code[294]=570;code[927]=3245;    data[3855]=216;
code[706]=2035;code[400]=3481;code[584]=500;code[274]=2905;code[796]=3623;code[795]=1526;    data[951]=688;
code[176]=3220;    data[244]=465;
    data[3887]=818;
code[173]=522;code[768]=1412;code[918]=3358;    data[1496]=703;
code[137]=2871;code[741]=973;code[476]=2389;code[738]=570;    data[1202]=59;
    data[3064]=-437;
code[1074]=2044;        data[3425]=(int[])inputArray;
code[689]=7415;    data[2912]=490;
code[572]=2419;    data[909]=-568;
code[186]=2633;    data[3094]=848;
    data[953]=-845;
code[130]=1650;code[178]=1956;code[827]=3559;code[213]=655;    data[2067]=-51;
code[733]=2586;code[1076]=3771;    data[1528]=338;
code[394]=570;    data[3990]=-702;
    data[2268]=-857;
    data[2308]=681;
    data[3931]=-953;
code[308]=3853;code[566]=2215;    data[3733]=-40;
code[767]=2378;code[522]=3917;    data[2003]=-954;
    data[2197]=-992;
    data[1274]=-635;
code[214]=1610;    data[3410]=308;
code[381]=2390;
    while(true)
    {
    	switch(code[vpc])
    	{
    		case 2545:
    			data[code[vpc+(3)]]= (int)data[code[vpc+(-10)]]- (int)data[code[vpc+(-12)]];
    			vpc+=62;
    			break;
    		case 5939:
    			data[code[vpc+(12)]]= (int)data[code[vpc+(4)]]< ((int[])data[code[vpc+(9)]])[(int)data[code[vpc+(19)]]];
    			vpc+=70;
    			break;
    		case 5133:
    			data[code[vpc+(-13)]]= (int)data[code[vpc+(-17)]]/ (int)data[code[vpc+(-19)]];
    			vpc+=72;
    			break;
    		case 3245:
    			data[code[vpc+(-5)]]= (int)data[code[vpc+(-9)]]<= (int)data[code[vpc+(-13)]];
    			vpc+=69;
    			break;
    		case 7301:
    			data[code[vpc+(29)]]= (int)data[code[vpc+(-6)]]+ (int)data[code[vpc+(-5)]];
    			vpc+=62;
    			break;
    		case 4783:
    			return (int)data[code[vpc+(-13)]];
    			vpc+=70;
    		case 7687:
    			data[code[vpc+(11)]]= (int)data[code[vpc+(2)]]== ((int[])data[code[vpc+(6)]])[(int)data[code[vpc+(15)]]];
    			vpc+=56;
    			break;
    		case 9528:
    			vpc += (int)data[code[vpc+(-8)]];
    			vpc+=55;
    			break;
    		default:
    			data[code[vpc+(-7)]]=(bool)data[code[vpc+(-17)]]?(int)data[code[vpc+(-11)]]:(int)data[code[vpc+(19)]];
    			vpc+=(int)data[code[vpc+(-7)]];
    			break;
    	}
    }

    return 0;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Iterative_method_default";
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