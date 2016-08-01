using System;
using System.Diagnostics;

namespace ConsoleCalculator.Performance.Factorial
{
   
    class FactorialTests
    {

        private static int WARMUP = 250;
        private static int ITERATIONS = 250;

        public static void RunLoopTests()
        {
            FactorialTests lt = new FactorialTests();

//                        lt.Profile();

//            lt.FactorialRecursive_Check(10);
        }

        private void Profile()
        {
            //            lt.ForSimple_Check();
            int ELEMENTS = 300;
            
            string result = "";

            result += "t_original";
            result += "     t_method";
            result += "     t_class";
//            result += " t_method_default";
//            result += " t_class_default";
            result += "     t_method_junk";
            result += "     t_class_junk";
            result += " " + "\n";

            int NUMBER_OF_RUNS = 3;
            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {
                Console.WriteLine("##############");
                Debug.WriteLine("##############");
                string t_original = Time_Operation(VirtualizationType.ORIGINAL, FactorialRecursive_original, ELEMENTS, WARMUP, ITERATIONS);
                string t_method = Time_Operation(VirtualizationType.METHOD, FactorialRecursive_method, ELEMENTS, WARMUP, ITERATIONS);
                string t_class = Time_Operation(VirtualizationType.CLASS, FactorialRecursive_class, ELEMENTS, WARMUP, ITERATIONS);
//                string t_method_default = Time_Operation(VirtualizationType.ORIGINAL, ForSimple_Array_original, for_loop, WARMUP, ITERATIONS);
//                string t_class_default = Time_Operation(VirtualizationType.ORIGINAL, ForSimple_Array_original, for_loop, WARMUP, ITERATIONS);
                string t_method_junk = Time_Operation(VirtualizationType.METHOD_JUNK, FactorialRecursive_method_default_junk, ELEMENTS, WARMUP, ITERATIONS);
                string t_class_junk = Time_Operation(VirtualizationType.CLASS_JUNK, FactorialRecursive_class_default_junk, ELEMENTS, WARMUP, ITERATIONS);

                result += " " + t_original;
                result += " " + t_method;
                result += " " + t_class;
//                result += " " + t_method_default;
//                result += " " + t_class_default;
                result += " " + t_method_junk;
                result += " " + t_class_junk;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);
        }


       

      
        public static long FactorialRecursive_original(int num)
        {
            int c = 0;

            if (num == 0)
            {
                return 1;
            }

            return num * FactorialRecursive_original(num - 1);
        }

      


        private void FactorialRecursive_Check(int arg)
        {
            string testName = "Performance#FactorialRecursive_Check_" + arg;
            bool condition = true;
            Program.Start_Check(testName);

            long virt = FactorialRecursive_original(arg);
            long oracle1 = FactorialRecursive_method(arg);
            long oracle2 = FactorialRecursive_class(arg);
            long oracle3 = FactorialRecursive_method_default_junk(arg);
            long oracle4 = FactorialRecursive_class_default_junk(arg);
            Console.WriteLine(testName + " => " + virt +" "+ oracle1 + " " + oracle2 + " " + oracle3 + " "+ oracle4);
            condition = virt.Equals(oracle1) && virt.Equals(oracle2) && virt.Equals(oracle3) && virt.Equals(oracle4);
            Program.End_Check(testName, condition);
        }



//                [Obfuscation(Exclude = false, Feature = "virtualization; method; ")]
public long FactorialRecursive_method(int num)
{
    //Virtualization variables
    int[] code = new int[100298];
    object[] data = new object[4700];
    int vpc = 75;

    code[9963]=-60;code[22025]=-748;code[61826]=1167;code[82523]=249;code[15737]=-826;code[66731]=-939;
    code[146]=-555;code[55652]=-77;code[41094]=174;code[16905]=-805;code[11326]=348;code[88567]=92;
    code[21208]=152;code[73691]=18;code[81596]=345;code[37834]=-396;code[62222]=-502;code[69493]=-776;
    code[41073]=502;code[8722]=1108;code[6506]=626;code[73345]=647;code[49549]=733;code[74304]=1379;
    code[77368]=540;code[59865]=1205;code[92969]=234;code[41789]=400;code[49457]=956;code[89220]=-612;
    code[13256]=38;code[68811]=546;code[69468]=59;code[40556]=1005;code[48681]=162;code[96262]=1021;
    code[38416]=-188;code[1342]=155;code[81034]=-441;code[94580]=295;code[72217]=957;code[63770]=-507;
    code[94408]=237;code[31562]=-684;code[78503]=-669;code[59843]=567;code[71367]=1328;code[71330]=623;
    code[96756]=-719;code[96931]=-825;code[28994]=1346;code[46778]=-235;code[65837]=970;code[50055]=504;
    code[48171]=1386;code[75440]=-328;code[84205]=-72;code[43681]=-127;code[78207]=221;code[67945]=-507;
    code[10934]=-306;code[1943]=-119;code[87102]=-168;code[9732]=129;code[61581]=-90;code[49892]=738;
    code[25829]=1181;code[22960]=953;code[31749]=-177;code[54253]=-618;code[99900]=782;code[64832]=1070;
    code[38172]=-182;code[78972]=-150;code[49736]=-96;code[87211]=189;code[43638]=922;code[96416]=-972;
    code[92210]=-716;code[43913]=-192;code[69329]=-882;code[99070]=-710;code[45843]=-859;code[1163]=1417;
    code[14304]=635;code[3276]=125;code[95062]=311;code[20204]=-10;code[63313]=-523;code[97489]=352;
    code[54706]=892;code[95856]=-370;code[49603]=-947;code[26108]=221;code[91408]=-457;code[86447]=-494;
    code[89435]=-457;code[46314]=1371;code[72731]=325;code[37222]=-191;code[31687]=1051;code[19797]=1104;
    code[33028]=48;code[52972]=1276;code[56918]=413;code[38129]=820;code[14220]=1242;code[78046]=1335;
    code[9201]=839;code[62347]=88;code[79881]=307;code[5567]=1312;code[79467]=1074;code[56016]=826;
    code[6284]=-368;code[67292]=-748;code[82250]=620;code[22565]=812;code[56130]=-715;code[92544]=-812;
    code[49477]=-126;code[92382]=-135;code[83982]=-666;code[6115]=1486;code[44048]=318;code[85939]=1473;
    code[91128]=1338;code[52894]=982;code[76726]=-320;code[4947]=248;code[86335]=994;code[85051]=-214;
    code[89693]=-303;code[91081]=234;code[67392]=-867;code[37568]=1444;code[81546]=365;code[94508]=117;
    code[60371]=773;code[8803]=646;code[77121]=409;code[29217]=337;code[39719]=703;code[19303]=1211;
    code[12115]=80;code[96280]=-282;code[6492]=58;code[21509]=739;code[50313]=516;code[45323]=395;
    code[22628]=418;code[32382]=-36;code[15344]=1197;code[17687]=-95;code[99618]=-799;code[19156]=-861;
    code[18504]=-24;code[73263]=-258;code[50787]=-218;code[92133]=-469;code[8691]=-942;code[37392]=-401;
    code[9352]=-783;code[91565]=-26;code[33290]=-384;code[94796]=1488;code[25822]=323;code[43425]=-497;
    code[24155]=1263;code[38324]=292;code[50668]=1075;code[89396]=-900;code[24178]=1260;code[10318]=684;
    code[69489]=1293;code[18982]=-529;code[68989]=-403;code[47297]=-495;code[19512]=-793;code[29359]=-836;
    code[96909]=966;code[3038]=866;code[13582]=-512;code[80055]=637;code[96061]=322;code[5641]=502;
    code[93354]=4;code[70965]=-359;code[13264]=-169;code[100175]=-528;code[98724]=-403;code[69898]=36;
    code[5755]=891;code[30853]=-955;code[5814]=-423;code[704]=-606;code[61441]=-210;code[55225]=796;
    code[80233]=-639;code[90748]=-887;code[10644]=119;code[71835]=-591;code[86367]=470;code[25873]=-285;
    code[53317]=-463;code[7000]=1154;code[8447]=-741;code[8171]=818;code[8995]=539;code[69125]=-53;
    code[89055]=949;code[59874]=817;code[52342]=1246;code[99137]=536;code[85366]=1472;code[45780]=1468;
    code[42907]=1383;code[8305]=340;code[52427]=332;code[55508]=172;code[49990]=-947;code[48815]=1107;
    code[16159]=-638;code[7382]=272;code[23554]=1058;code[63076]=-540;code[45687]=314;code[15809]=-185;
    code[85349]=1473;code[64396]=1406;code[60156]=608;code[43624]=356;code[76097]=-795;code[43543]=-673;
    code[2105]=362;code[20516]=391;code[6249]=-450;code[88320]=1165;code[29404]=885;code[56740]=-58;
    code[82726]=199;code[38073]=-931;code[36113]=-320;code[53357]=1255;code[79798]=891;code[68745]=333;
    code[89357]=476;code[87195]=1137;code[58831]=1360;code[8432]=-803;code[71304]=1356;code[48925]=724;
    code[62062]=-820;code[12226]=-412;code[64710]=-272;code[3316]=-759;code[42491]=-337;code[13828]=-700;
    code[26468]=17;code[18311]=216;code[55191]=330;code[33635]=-339;code[86222]=678;code[66775]=178;
    code[35171]=-936;code[28063]=-128;code[67208]=217;code[66785]=1205;code[99477]=724;code[41022]=-281;
    code[15077]=-259;code[25760]=260;code[72563]=471;code[11001]=564;code[45421]=873;code[59276]=-552;
    code[76376]=493;code[53012]=-553;code[60907]=-442;code[83254]=1368;code[40762]=625;code[88743]=548;
    code[1146]=709;code[42797]=1341;code[60115]=-361;code[12868]=435;code[100110]=1236;code[33715]=-366;
    code[27609]=1077;code[54254]=-323;code[56319]=-900;code[1874]=503;code[43595]=-750;code[58934]=-819;
    code[96117]=217;code[27572]=921;code[86232]=153;code[88406]=249;code[41293]=593;code[49441]=-902;
    code[16239]=-568;code[2638]=-508;code[62277]=-958;code[18181]=1167;code[26220]=-314;code[90621]=940;
    code[68445]=397;code[38719]=-85;code[63353]=-292;code[18539]=1277;code[9665]=-115;code[98134]=-720;
    code[98369]=-101;code[71639]=341;code[1329]=1090;code[84455]=594;code[33903]=253;code[10946]=-29;
    code[1383]=1053;code[98341]=44;code[92183]=801;code[81348]=708;code[58526]=246;code[8628]=-249;
    code[7561]=287;code[87090]=-680;code[45382]=454;code[94595]=1019;code[19506]=1284;code[21703]=-348;
    code[30358]=611;code[85608]=63;code[43402]=-337;code[43957]=-548;code[45122]=1493;code[35357]=1025;
    code[30376]=917;code[99488]=-62;code[54473]=-263;code[53035]=205;code[27463]=33;code[46269]=245;
    code[97071]=784;code[18602]=890;code[55992]=-247;code[19469]=-751;code[60691]=798;code[11535]=-314;
    code[86982]=-36;code[25153]=-206;code[6051]=1262;code[85338]=-806;code[16308]=-855;code[82791]=713;
    code[59171]=418;code[26537]=1248;code[38635]=835;code[99019]=1222;code[18379]=-112;code[45876]=797;
    code[8034]=705;code[62459]=-629;code[80571]=-369;code[20563]=458;code[65407]=793;code[50983]=-607;
    code[4424]=-473;code[42308]=-78;code[56434]=-42;code[33651]=1274;code[89088]=250;code[16665]=1476;
    code[3694]=-264;code[71671]=1177;code[73433]=-436;code[9156]=279;code[93118]=329;code[23854]=-55;
    code[28311]=755;code[27542]=1274;code[85569]=-395;code[3328]=1181;code[5943]=-732;code[85801]=-565;
    code[31331]=546;code[32744]=999;code[1996]=369;code[83324]=449;code[51752]=580;code[11195]=271;
    code[53972]=-165;code[85381]=65;code[62796]=1491;code[22954]=280;code[97588]=-891;code[8678]=1150;
    code[10909]=64;code[5666]=615;code[46834]=-267;code[93419]=1323;code[44036]=350;code[56017]=-716;
    code[90205]=-272;code[49337]=-49;code[70307]=644;code[86475]=625;code[59252]=914;code[37285]=297;
    code[39190]=517;code[24719]=-844;code[88103]=-143;code[20198]=-329;code[53351]=165;code[69314]=485;
    code[49270]=-539;code[11334]=-444;code[70271]=-545;code[6994]=1494;code[77790]=843;code[52846]=-164;
    code[50609]=1120;code[81376]=-213;code[18198]=90;code[27030]=-143;code[5404]=343;code[25624]=1150;
    code[4725]=1171;code[5126]=-761;code[33982]=-276;code[58349]=82;code[60211]=1244;code[89206]=291;
    code[54648]=599;code[95240]=21;code[69814]=-66;code[74564]=632;code[8024]=1279;code[55980]=-925;
    code[53334]=1215;code[8754]=-761;code[19727]=-130;code[54199]=1384;code[93182]=-368;code[17580]=1079;
    code[13135]=1434;code[66104]=214;code[15627]=-766;code[73652]=517;code[96161]=-263;code[77254]=354;
    code[48817]=1152;code[64880]=700;code[79637]=505;code[78235]=-662;code[31145]=-948;code[56584]=131;
    code[20309]=215;code[23719]=-370;code[35830]=1339;code[58912]=-271;code[46588]=-706;code[27855]=805;
    code[71687]=-356;code[49882]=1465;code[17797]=1377;code[7168]=-408;code[11636]=364;code[61069]=-161;
    code[70333]=1150;code[16025]=-184;code[47433]=-901;code[52296]=-725;code[41085]=-484;code[28417]=674;
    code[85976]=205;code[25045]=-943;code[70963]=195;code[7738]=-78;code[58481]=1311;code[96816]=340;
    code[10529]=984;code[96072]=-102;code[95222]=-182;code[33753]=642;code[87987]=1251;code[55257]=242;
    code[77815]=-349;code[82139]=61;code[59798]=-581;code[31355]=270;code[97717]=1069;code[12946]=738;
    code[70355]=-880;code[53089]=594;code[46986]=-401;code[75502]=941;code[89771]=558;code[22240]=697;
    code[8232]=-595;code[16115]=-795;code[87259]=566;code[371]=7559;    data[2106]=(long)1;
code[330]=2150;code[203]=2106;code[128]=9984;code[406]=2925;code[249]=7563;    data[3170]=0;
code[121]=2385;code[65]=3263;code[91]=2150;code[116]=3263;code[306]=5192;    data[1709]=649;
code[498]=8782;    data[2925]=(long)-220L;
    data[3263]=false;
code[238]=812;code[410]=3277;code[151]=1709;    data[2385]=178;
    data[3951]=1;
    data[812]=257;
code[388]=122;code[103]=3170;code[386]=3277;code[184]=8782;        data[2150]=num;
code[75]=8191;    data[2447]=56;
    data[3277]=(long)530L;
code[293]=3951;code[517]=2925;code[423]=2150;code[321]=122;    data[122]=-842;
code[426]=3936;code[156]=2447;
    while(true)
    {
    	switch(code[vpc])
    	{
    		case 7559:
    			data[code[vpc+(15)]]= FactorialRecursive_method((int)data[code[vpc+(17)]]);
    			vpc+=55;
    			break;
    		case 5192:
    			data[code[vpc+(15)]]= (int)data[code[vpc+(24)]]- (int)data[code[vpc+(-13)]];
    			vpc+=65;
    			break;
    		case 3936:
    			data[code[vpc+(-20)]]= (int)data[code[vpc+(-3)]]* (long)data[code[vpc+(-16)]];
    			vpc+=72;
    			break;
    		case 8191:
    			data[code[vpc+(-10)]]= (int)data[code[vpc+(16)]]== (int)data[code[vpc+(28)]];
    			vpc+=53;
    			break;
    		case 9984:
    			data[code[vpc+(23)]]=(bool)data[code[vpc+(-12)]]?(int)data[code[vpc+(28)]]:(int)data[code[vpc+(-7)]];
    			vpc+=(int)data[code[vpc+(23)]];
    			break;
    		case 7563:
    			vpc += (int)data[code[vpc+(-11)]];
    			vpc+=57;
    			break;
    		case 8782:
    			return (long)data[code[vpc+(19)]];
    			vpc+=65;
    		default:
    			break;
    	}
    }

    return 0;
}

//                [Obfuscation(Exclude = false, Feature = "virtualization; class;")]
public long FactorialRecursive_class(int num)
{
    //Virtualization variables
    int[] code = new int[100752];
    object[] data = new object[4194];
    int vpc = 63;

    code[35956]=668;code[63440]=-52;code[26304]=1205;code[6713]=359;code[96029]=-382;code[14522]=674;
    code[17807]=1394;code[84396]=-66;code[90482]=-906;code[47760]=-828;code[92937]=-864;code[78243]=437;
    code[40305]=-504;code[67272]=522;code[64328]=944;code[49623]=1251;code[47815]=-358;code[21467]=49;
    code[30072]=54;code[73111]=555;code[49196]=386;code[96552]=119;code[78695]=1300;code[57760]=521;
    code[84475]=1199;code[12492]=41;code[1633]=-260;code[31902]=-245;code[89767]=-863;code[98677]=-845;
    code[21597]=144;code[91202]=-562;code[76071]=-391;code[19652]=1299;code[75036]=44;code[7601]=190;
    code[31440]=1129;code[58492]=-81;code[9706]=-179;code[79969]=199;code[63017]=-853;code[77630]=896;
    code[65877]=-811;code[89083]=-554;code[94754]=1277;code[53270]=-391;code[44588]=658;code[41075]=-924;
    code[65420]=957;code[69813]=343;code[73065]=634;code[87049]=51;code[81035]=619;code[10538]=-590;
    code[72082]=1371;code[20740]=405;code[26306]=249;code[44010]=-612;code[69228]=-634;code[52532]=697;
    code[36223]=-959;code[98647]=1084;code[89590]=1079;code[3380]=621;code[44763]=374;code[72396]=-217;
    code[64047]=-360;code[76024]=1429;code[19638]=-125;code[96159]=-986;code[97857]=799;code[46659]=1479;
    code[71030]=1415;code[98990]=1357;code[22823]=-370;code[34610]=257;code[26361]=-966;code[17916]=771;
    code[67962]=-925;code[53526]=1431;code[61895]=139;code[72533]=-587;code[23191]=1231;code[93361]=-989;
    code[75064]=162;code[96773]=-158;code[19350]=288;code[71319]=598;code[55753]=1468;code[12986]=1307;
    code[85565]=-774;code[42534]=-520;code[20794]=-461;code[5202]=554;code[7914]=-886;code[29946]=-588;
    code[82489]=1454;code[39457]=288;code[4]=-257;code[76725]=1031;code[4003]=1444;code[19936]=903;
    code[29392]=-984;code[31310]=865;code[30818]=345;code[15651]=717;code[90797]=521;code[12414]=309;
    code[3398]=319;code[96634]=-964;code[84725]=-239;code[93313]=747;code[16906]=989;code[52225]=-475;
    code[12473]=-519;code[64431]=-361;code[22755]=-209;code[88973]=1178;code[89944]=651;code[90707]=-501;
    code[91175]=-237;code[31841]=350;code[89720]=525;code[26559]=-475;code[86514]=1169;code[48526]=180;
    code[34097]=867;code[97879]=837;code[5200]=246;code[59815]=240;code[49171]=-749;code[62707]=-717;
    code[90550]=1248;code[46476]=461;code[73078]=-371;code[63571]=-68;code[63228]=897;code[11031]=338;
    code[99610]=-36;code[81475]=394;code[53608]=-230;code[35408]=-361;code[71619]=-582;code[92425]=196;
    code[34755]=-630;code[82601]=-15;code[6747]=10;code[71727]=1010;code[68815]=-494;code[64634]=1477;
    code[14988]=697;code[48860]=517;code[23871]=-729;code[85093]=448;code[64237]=89;code[75194]=664;
    code[69518]=-911;code[97118]=-551;code[75480]=-84;code[40555]=828;code[98955]=1456;code[24158]=443;
    code[43512]=-408;code[30838]=-442;code[4758]=-238;code[85888]=965;code[74995]=1044;code[41203]=1133;
    code[82928]=861;code[1910]=505;code[32518]=-155;code[84751]=1272;code[40476]=-615;code[70934]=-923;
    code[44363]=329;code[5558]=-209;code[80614]=1275;code[886]=-585;code[44237]=1269;code[17638]=-1000;
    code[80853]=553;code[53604]=-169;code[58788]=1400;code[92827]=1180;code[63171]=-724;code[35956]=-989;
    code[35014]=1000;code[41171]=610;code[14239]=-173;code[17681]=-306;code[53685]=-313;code[78885]=288;
    code[25186]=339;code[99328]=1085;code[81499]=-394;code[41725]=1288;code[57370]=-953;code[80576]=753;
    code[81210]=271;code[32791]=103;code[23452]=1079;code[40702]=-176;code[17637]=-874;code[97626]=1499;
    code[50523]=-89;code[2509]=-730;code[73770]=1243;code[47066]=318;code[84461]=-959;code[8306]=-882;
    code[98176]=-783;code[6385]=-40;code[70180]=103;code[43852]=-179;code[51]=767;code[84432]=581;
    code[538]=835;code[4531]=752;code[87763]=133;code[34277]=-502;code[57121]=1465;code[33527]=110;
    code[21944]=-236;code[18456]=680;code[55593]=-320;code[86963]=973;code[42951]=-306;code[47048]=-636;
    code[77416]=-951;code[63777]=833;code[61985]=601;code[100685]=985;code[53063]=-20;code[10368]=1495;
    code[85874]=915;code[66125]=-38;code[68162]=1207;code[48420]=1471;code[76000]=547;code[16772]=-24;
    code[26024]=907;code[78263]=820;code[85035]=-879;code[20780]=818;code[26910]=1248;code[93969]=1128;
    code[82650]=516;code[58865]=1316;code[99407]=346;code[92441]=1063;code[20449]=-538;code[82591]=964;
    code[62063]=195;code[11359]=358;code[80330]=196;code[39426]=-627;code[85964]=-395;code[47884]=1130;
    code[87009]=-323;code[95741]=194;code[18748]=-62;code[73653]=1382;code[83964]=1012;code[56883]=-826;
    code[30091]=385;code[178]=-461;code[70691]=-148;code[18913]=-817;code[95046]=1477;code[11300]=-86;
    code[94302]=657;code[93710]=971;code[51180]=958;code[100564]=445;code[13235]=830;code[6342]=788;
    code[59260]=98;code[64419]=1068;code[45741]=1166;code[95947]=1027;code[92046]=-893;code[24653]=-392;
    code[48034]=-562;code[45094]=280;code[5502]=5;code[91552]=1181;code[16020]=461;code[54600]=308;
    code[44871]=1356;code[44839]=-876;code[81284]=1466;code[94557]=416;code[49477]=-285;code[63238]=-345;
    code[70687]=-100;code[62390]=-809;code[3905]=-248;code[45559]=1232;code[42131]=717;code[31412]=-169;
    code[33840]=214;code[52733]=823;code[82966]=-524;code[56065]=-991;code[90440]=-710;code[38498]=278;
    code[42484]=1256;code[431]=1317;code[10510]=695;code[75783]=-524;code[55190]=-537;code[81672]=735;
    code[78865]=1080;code[84001]=1144;code[13326]=621;code[10581]=896;code[63544]=-719;code[71940]=-198;
    code[46665]=-478;code[74859]=-249;code[73529]=559;code[36712]=463;code[98546]=-731;code[65989]=-660;
    code[29903]=312;code[79475]=849;code[94167]=-697;code[79063]=-625;code[68033]=1072;code[95368]=1478;
    code[35936]=746;code[87799]=-378;code[1124]=558;code[88741]=-228;code[18977]=708;code[46732]=1237;
    code[94221]=128;code[46411]=1309;code[82730]=-437;code[72163]=687;code[17839]=743;code[56532]=517;
    code[86641]=-88;code[83006]=273;code[33024]=409;code[65046]=585;code[26458]=878;code[95106]=-922;
    code[75814]=-712;code[57856]=-114;code[22863]=-136;code[95512]=533;code[6179]=1234;code[81082]=207;
    code[66560]=1152;code[33168]=125;code[11362]=-322;code[82047]=648;code[13846]=-340;code[39184]=615;
    code[80572]=-72;code[98874]=561;code[3807]=1074;code[63726]=-541;code[51136]=73;code[17262]=764;
    code[65586]=-96;code[45146]=1078;code[75500]=1369;code[54985]=1415;code[56449]=-149;code[85512]=167;
    code[23624]=-512;code[52529]=1477;code[94426]=-289;code[90054]=220;code[73204]=1320;code[55897]=1138;
    code[36718]=-192;code[57994]=-421;code[26313]=552;code[98289]=-422;code[69474]=558;code[80506]=877;
    code[82962]=1457;code[91675]=-526;code[72401]=56;code[8645]=147;code[52657]=286;code[39311]=1105;
    code[31063]=603;code[24822]=-443;code[53957]=708;code[98638]=807;code[81298]=481;code[47030]=65;
    code[37488]=-215;code[71038]=1347;code[36792]=543;code[78315]=527;code[39948]=925;code[16889]=1385;
    code[37757]=760;code[77529]=-241;code[84866]=-761;code[33537]=1124;code[94015]=833;code[93026]=549;
    code[37761]=881;code[70092]=-985;code[64938]=-810;code[95121]=-423;code[52018]=209;code[82377]=11;
    code[72295]=-634;code[9448]=1262;code[74271]=948;code[44905]=344;code[47735]=-270;code[85449]=1078;
    code[92055]=687;code[88708]=777;code[26164]=542;code[49659]=596;code[39371]=-787;code[56853]=531;
    code[92871]=927;code[97361]=-200;code[83241]=1341;code[44108]=1227;code[89313]=-88;code[59077]=739;
    code[207]=69;code[11361]=-616;code[28985]=-37;code[14703]=-794;code[91135]=1160;code[9335]=1423;
    code[19724]=-418;code[97846]=1248;code[99843]=-553;code[1382]=580;code[58678]=203;code[99075]=1415;
    code[81903]=-687;code[71711]=342;code[86087]=1393;code[95205]=371;code[8940]=-538;code[71435]=1079;
    code[50787]=-153;code[35362]=-987;code[94647]=204;code[71325]=-857;code[68340]=1492;code[12541]=482;
    code[97285]=345;code[90664]=768;code[35392]=1385;code[11407]=301;code[44768]=-634;code[34349]=-595;
    code[67862]=522;code[22979]=1368;code[92620]=359;code[88732]=-973;code[52794]=-653;code[39833]=629;
    code[83417]=-980;code[69800]=-749;code[77915]=1314;code[29007]=1040;code[98]=-704;code[57570]=-210;
    code[5778]=-407;code[19887]=-664;code[7215]=-530;code[39053]=-107;code[100558]=-529;code[33435]=-174;
    code[25558]=901;code[13926]=-665;code[11707]=-717;code[6968]=1066;code[14405]=-381;code[88617]=-143;
    code[26331]=-969;code[75303]=296;code[86508]=312;code[16247]=387;code[3777]=1279;code[89665]=704;
    code[34917]=865;code[94637]=-161;code[75721]=-906;code[65877]=598;code[68150]=-95;code[85332]=-969;
    code[79351]=-617;code[70506]=1218;code[4980]=862;code[17443]=1023;code[36054]=1135;code[76]=1477;    data[1291]=0;
code[89]=1291;code[107]=3958;code[254]=1140;code[306]=8212;code[506]=9028;code[450]=1039;code[69]=1039;code[313]=1039;    data[1140]=266;
code[395]=839;code[63]=5812;code[207]=558;code[311]=839;    data[3794]=180;
code[137]=1999;    data[3958]=54;
    data[839]=-238;
    data[465]=(long)-52L;
code[429]=1406;    data[518]=1;
    data[1406]=(long)-408L;
code[378]=7259;code[452]=465;code[129]=3794;code[533]=1406;code[387]=465;        data[1039]=num;
code[126]=7295;    data[558]=(long)1;
code[154]=1477;code[290]=518;code[180]=9028;code[448]=7084;code[246]=8554;    data[1477]=false;
    data[1999]=539;

    return (long)InstanceInterpreterVirtualization_FactorialTests_3953(vpc, data, code);

}

//                [Obfuscation(Exclude = false, Feature = "virtualization; method; ")]
public long FactorialRecursive_method_default_junk(int num)
{
    //Virtualization variables
    int[] code = new int[100262];
    object[] data = new object[4854];
    int vpc = 51;

    code[12440]=312;code[48638]=404;code[8889]=700;code[22348]=-675;code[2322]=-801;code[67792]=1187;
    code[27453]=984;code[9379]=693;code[16840]=-235;code[88547]=431;code[68997]=-337;code[60556]=-704;
    code[17799]=185;code[36686]=232;code[6077]=1281;code[25310]=-586;code[86498]=331;code[41797]=1454;
    code[33168]=600;code[96339]=205;code[76672]=205;code[34503]=180;code[3165]=1000;code[87117]=124;
    code[63556]=1439;code[98445]=957;code[17394]=576;code[47977]=1146;code[92337]=-84;code[38536]=535;
    code[31526]=824;code[6970]=-724;code[82951]=275;code[1245]=852;code[37799]=-721;code[34744]=319;
    code[34636]=2;code[80984]=-485;code[92371]=-671;code[8707]=-57;code[60703]=1290;code[86137]=-789;
    code[93324]=173;code[99488]=-420;code[5427]=395;code[6095]=1410;code[25632]=-134;code[16831]=-913;
    code[41369]=-416;code[64643]=303;code[78985]=-681;code[7302]=305;code[63096]=134;code[43860]=931;
    code[82488]=-319;code[93976]=972;code[28058]=-983;code[886]=-5;code[87300]=1461;code[18010]=-106;
    code[51942]=950;code[68882]=1046;code[5112]=-44;code[27299]=1497;code[23357]=932;code[79548]=719;
    code[48839]=414;code[59105]=194;code[84544]=-158;code[45661]=192;code[3214]=-451;code[41059]=954;
    code[62255]=-321;code[68605]=-379;code[33862]=923;code[16456]=69;code[5418]=-283;code[313]=-981;
    code[44186]=-365;code[47235]=-383;code[18214]=96;code[54109]=-876;code[48032]=-376;code[30274]=785;
    code[41861]=327;code[55658]=334;code[53074]=756;code[32662]=-254;code[37160]=1263;code[19833]=948;
    code[69998]=-941;code[66286]=158;code[61032]=-87;code[63523]=-500;code[56398]=454;code[3708]=472;
    code[86814]=-479;code[29595]=483;code[68173]=-101;code[30335]=-72;code[97228]=1425;code[83325]=1016;
    code[21493]=576;code[90082]=-122;code[96365]=761;code[63866]=338;code[5640]=729;code[55017]=-605;
    code[77947]=-810;code[44228]=-717;code[61772]=-746;code[15209]=1089;code[49543]=1414;code[66958]=-198;
    code[40865]=830;code[62009]=-973;code[60438]=1066;code[81164]=820;code[19307]=1136;code[24973]=1445;
    code[46832]=-295;code[23967]=1144;code[94734]=254;code[53429]=-565;code[66150]=-658;code[81816]=509;
    code[92092]=-528;code[75708]=1169;code[82049]=1488;code[31327]=-379;code[96508]=444;code[94613]=-428;
    code[8643]=565;code[93495]=-426;code[88461]=1051;code[96795]=1307;code[82930]=157;code[64808]=-166;
    code[86495]=-266;code[89309]=1481;code[43419]=234;code[66277]=-324;code[91865]=-964;code[9269]=34;
    code[7165]=1353;code[91212]=-508;code[54349]=-999;code[1578]=1223;code[33952]=-975;code[77362]=-203;
    code[57061]=-242;code[29248]=1097;code[17219]=1232;code[77860]=139;code[54409]=53;code[530]=311;
    code[10494]=-201;code[81747]=171;code[91898]=683;code[31340]=-822;code[53495]=296;code[15861]=1351;
    code[91326]=920;code[38181]=1066;code[44823]=892;code[99775]=1131;code[52362]=429;code[42446]=-676;
    code[20260]=1054;code[9891]=-943;code[23879]=591;code[87333]=625;code[93868]=-37;code[9270]=-445;
    code[18580]=367;code[97541]=663;code[69943]=750;code[78733]=-875;code[14542]=-123;code[93068]=8;
    code[51364]=1375;code[866]=964;code[42726]=-619;code[223]=331;code[89895]=713;code[26739]=-764;
    code[57609]=-277;code[83545]=1242;code[64941]=270;code[454]=314;code[67760]=-604;code[64282]=1250;
    code[78610]=-176;code[15528]=1055;code[78868]=-68;code[98734]=1127;code[89597]=738;code[51216]=-280;
    code[62975]=-787;code[22459]=958;code[38402]=399;code[32634]=249;code[28099]=1195;code[9101]=20;
    code[86913]=1221;code[40367]=592;code[34732]=6;code[72950]=-117;code[30975]=-729;code[169]=-760;
    code[100051]=-550;code[74805]=309;code[70257]=38;code[20156]=1198;code[78065]=363;code[26940]=406;
    code[28476]=-448;code[14297]=-710;code[83539]=-647;code[62146]=1264;code[23962]=866;code[95772]=1245;
    code[97291]=-131;code[50601]=227;code[97012]=-607;code[98168]=298;code[8384]=-681;code[78758]=-493;
    code[81572]=1004;code[80113]=1161;code[67891]=-472;code[63118]=-196;code[62138]=1100;code[35390]=-687;
    code[26070]=528;code[52172]=-582;code[48996]=-761;code[85960]=-373;code[22548]=1119;code[55467]=-118;
    code[91326]=775;code[91416]=553;code[56754]=872;code[48003]=-610;code[43668]=1349;code[30330]=-922;
    code[34320]=887;code[22932]=-931;code[11749]=583;code[27912]=-675;code[99739]=-52;code[23158]=-110;
    code[63853]=1028;code[3097]=1469;code[27098]=335;code[98055]=1414;code[24930]=115;code[95628]=1417;
    code[30039]=-980;code[75757]=1176;code[36236]=-509;code[69159]=-200;code[30977]=222;code[82742]=833;
    code[86934]=1074;code[13434]=478;code[57103]=57;code[35911]=328;code[48030]=389;code[98707]=886;
    code[72010]=227;code[88841]=1252;code[96421]=-158;code[78471]=1240;code[80346]=-346;code[72989]=-728;
    code[88025]=19;code[77075]=995;code[69137]=1276;code[4726]=-631;code[98884]=-257;code[12104]=101;
    code[40139]=-34;code[39714]=1063;code[8811]=55;code[48933]=859;code[2371]=-998;code[15281]=1176;
    code[31130]=971;code[35954]=1430;code[70820]=1322;code[93457]=513;code[10202]=-938;code[71523]=-596;
    code[65602]=399;code[84415]=420;code[50985]=1091;code[77025]=52;code[37121]=113;code[50214]=437;
    code[94319]=1392;code[81046]=-53;code[77558]=1460;code[8559]=1192;code[25600]=1245;code[48897]=1252;
    code[55350]=-813;code[44262]=-857;code[36619]=288;code[33963]=-62;code[67504]=-415;code[17171]=319;
    code[58182]=1299;code[23602]=-533;code[23343]=828;code[50149]=1162;code[28850]=958;code[3145]=873;
    code[12099]=382;code[83406]=-706;code[94205]=1091;code[90881]=890;code[7246]=1352;code[1636]=83;
    code[39622]=777;code[5575]=1137;code[10711]=-687;code[90411]=766;code[78785]=-299;code[80088]=1134;
    code[75060]=1245;code[64573]=309;code[39914]=556;code[61482]=921;code[4376]=730;code[93901]=1030;
    code[68515]=-448;code[43691]=1091;code[32872]=38;code[45681]=598;code[90570]=1004;code[79386]=304;
    code[67772]=613;code[76005]=-595;code[88410]=-188;code[96599]=1100;code[75620]=1445;code[37001]=-897;
    code[19293]=-44;code[35884]=123;code[32861]=-381;code[39087]=757;code[77646]=-392;code[17205]=1214;
    code[69148]=-838;code[37953]=-74;code[82697]=-602;code[95302]=1366;code[10685]=-695;code[85002]=882;
    code[86697]=127;code[88900]=796;code[73061]=-760;code[5812]=763;code[85422]=-14;code[64603]=1362;
    code[5749]=-985;code[31239]=638;code[41311]=-779;code[74932]=81;code[47483]=1180;code[47384]=1042;
    code[94887]=482;code[1545]=486;code[2753]=55;code[93708]=-825;code[53625]=512;code[58629]=1192;
    code[36207]=677;code[97684]=695;code[18590]=165;code[3387]=-263;code[42171]=83;code[31403]=1046;
    code[85009]=-263;code[53611]=-956;code[37583]=38;code[28002]=1481;code[98086]=-826;code[77431]=-661;
    code[8113]=158;code[67967]=74;code[46109]=435;code[41140]=130;code[42247]=86;code[29515]=852;
    code[11478]=-827;code[24778]=-982;code[84069]=-557;code[39725]=282;code[28044]=-509;code[74884]=831;
    code[88988]=1292;code[69715]=-701;code[32656]=480;code[90086]=-272;code[90121]=1096;code[59874]=805;
    code[79039]=510;code[83742]=1116;code[2308]=1152;code[39834]=32;code[63]=984;code[90565]=-237;
    code[16855]=-321;code[15432]=1002;code[67539]=-352;code[85830]=1210;code[71817]=1363;code[54355]=357;
    code[88110]=-274;code[12694]=1072;code[53761]=-993;code[84421]=-311;code[47331]=312;code[21959]=-414;
    code[34312]=374;code[49130]=47;code[80151]=-166;code[73372]=-766;code[1359]=-26;code[95397]=-866;
    code[43955]=-756;code[61926]=599;code[98500]=782;code[593]=1107;code[6208]=-270;code[97017]=830;
    code[73618]=420;code[87920]=1493;code[95430]=568;code[83567]=607;code[5305]=1298;code[45980]=-691;
    code[77123]=93;code[8497]=-44;code[21419]=121;code[53085]=222;code[34012]=-818;code[39164]=96;
    code[38646]=-494;code[29430]=897;code[52036]=-60;code[17295]=-875;code[58362]=894;code[68634]=-423;
    code[45804]=835;code[14228]=-35;code[55770]=-230;code[85]=297;code[64074]=234;code[87265]=362;
    code[62988]=558;code[63088]=533;code[76472]=196;code[39406]=653;code[17810]=95;code[61366]=873;
    code[33465]=-814;code[12450]=691;code[74892]=21;code[54317]=-972;code[75465]=1134;code[92811]=198;
    code[30729]=-642;code[93523]=-923;code[7217]=1179;code[80154]=1229;code[33288]=870;code[13117]=1239;
    code[74884]=397;code[28803]=-742;code[36564]=-943;code[5365]=-954;code[12253]=-19;code[5258]=204;
    code[18459]=-190;code[77396]=-424;code[95449]=1147;code[79456]=936;code[69949]=-626;code[30782]=548;
    code[54722]=-95;code[59097]=-236;code[64059]=800;code[41848]=463;code[94604]=-429;code[93231]=-531;
    code[12162]=95;code[64848]=823;code[80217]=1268;code[97]=1542;code[132]=844;code[483]=1468;    data[844]=177;
code[290]=1655;code[120]=3440;    data[1220]=1;
code[354]=1972;code[414]=250;    data[343]=874;
code[481]=2163;code[373]=3668;code[356]=7866;code[173]=2500;code[174]=3534;    data[1685]=-543;
code[438]=3668;code[195]=895;code[35]=1965;code[370]=1655;    data[750]=-119;
    data[2002]=414;
code[288]=6549;code[464]=198;code[60]=3703;code[384]=3762;    data[1717]=false;
code[186]=2816;code[252]=3963;code[264]=2481;code[417]=6040;    data[3668]=(long)127L;
code[316]=1220;code[460]=599;code[62]=3141;    data[833]=464;
code[486]=827;code[64]=1717;    data[3949]=-167;
        data[3141]=num;
    data[3067]=250;
code[100]=1022;    data[1965]=0;
    data[1542]=-244;
code[74]=3989;    data[2909]=460;
code[111]=9377;code[428]=827;    data[444]=76;
    data[1655]=-832;
    data[1780]=-968;
code[340]=3375;    data[889]=842;
code[99]=1717;    data[3239]=-24;
code[468]=570;    data[3262]=-833;
code[293]=586;code[51]=9896;code[235]=7925;    data[2313]=-404;
    data[881]=655;
code[427]=2467;    data[226]=205;
    data[1561]=46;
    data[1948]=(long)1;
    data[752]=912;
code[371]=1658;    data[1339]=231;
    data[1159]=-232;
    data[2830]=-46;
    data[827]=(long)276L;
code[404]=3141;    data[1912]=986;
code[127]=1875;code[183]=1948;    data[1022]=62;
code[273]=2464;    data[3146]=-670;
code[246]=3067;code[289]=3141;code[105]=3314;    data[1423]=-751;
code[476]=5556;
    while(true)
    {
    	switch(code[vpc])
    	{
    		case 6549:
    			data[code[vpc+(2)]]= (int)data[code[vpc+(1)]]- (int)data[code[vpc+(28)]];
    			vpc+=68;
    			break;
    		case 7866:
    			data[code[vpc+(17)]]= FactorialRecursive_method_default_junk((int)data[code[vpc+(14)]]);
    			vpc+=61;
    			break;
    		case 7925:
    			vpc += (int)data[code[vpc+(11)]];
    			vpc+=53;
    			break;
    		case 9377:
    			data[code[vpc+(-14)]]=(bool)data[code[vpc+(-12)]]?(int)data[code[vpc+(-11)]]:(int)data[code[vpc+(21)]];
    			vpc+=(int)data[code[vpc+(-14)]];
    			break;
    		default:
    			return (long)data[code[vpc+(10)]];
    			vpc+=62;
    		case 9896:
    			data[code[vpc+(13)]]= (int)data[code[vpc+(11)]]== (int)data[code[vpc+(-16)]];
    			vpc+=60;
    			break;
    		case 6040:
    			data[code[vpc+(11)]]= (int)data[code[vpc+(-13)]]* (long)data[code[vpc+(21)]];
    			vpc+=59;
    			break;
    	}
    }

    return 0;
}

//        [Obfuscation(Exclude = false, Feature = "virtualization; class;")]
public long FactorialRecursive_class_default_junk(int num)
{
    //Virtualization variables
    int[] code = new int[100576];
    object[] data = new object[4133];
    int vpc = 87;

    code[17608]=-80;code[50573]=692;code[33621]=731;code[80242]=932;code[1690]=1477;code[93264]=580;
    code[4835]=459;code[24918]=-697;code[68997]=615;code[46784]=-862;code[40090]=-930;code[19602]=630;
    code[32604]=-577;code[33863]=734;code[64366]=510;code[63679]=1390;code[39990]=-445;code[95654]=-299;
    code[42323]=-740;code[13191]=-960;code[15921]=1421;code[3175]=1439;code[36548]=-672;code[89194]=715;
    code[84119]=-697;code[26213]=-303;code[90312]=-649;code[68204]=-633;code[17438]=1126;code[35498]=-588;
    code[35790]=-740;code[13391]=31;code[36004]=1427;code[23592]=1064;code[63653]=1418;code[70455]=454;
    code[51804]=122;code[90210]=75;code[100226]=-453;code[29056]=-518;code[28410]=625;code[86227]=296;
    code[34572]=-115;code[5852]=-358;code[54731]=1010;code[10764]=425;code[75544]=1415;code[66416]=-865;
    code[84009]=547;code[62138]=-20;code[90195]=-848;code[5375]=1172;code[42327]=696;code[76840]=122;
    code[24498]=-381;code[15129]=1385;code[56487]=-600;code[88756]=763;code[24819]=536;code[6907]=-991;
    code[91821]=1443;code[28317]=1071;code[86525]=-675;code[83560]=372;code[79312]=1106;code[59830]=-57;
    code[60470]=1241;code[29771]=-447;code[60033]=1470;code[9830]=662;code[59343]=522;code[1357]=-260;
    code[65743]=-619;code[867]=477;code[8418]=1387;code[81205]=-449;code[55362]=534;code[48203]=1298;
    code[78402]=-439;code[879]=-274;code[85272]=-463;code[66421]=2;code[65683]=932;code[35508]=662;
    code[86910]=652;code[10921]=-354;code[51977]=9;code[41626]=-241;code[96954]=1463;code[17612]=768;
    code[12233]=-401;code[46785]=1084;code[3554]=-65;code[83168]=1468;code[41978]=-59;code[44437]=-70;
    code[98518]=1017;code[82190]=-63;code[95422]=531;code[64683]=1201;code[80426]=-141;code[73101]=56;
    code[85113]=372;code[70799]=-633;code[20117]=-562;code[96079]=985;code[4983]=-248;code[16994]=519;
    code[75425]=1066;code[36757]=-303;code[95155]=-86;code[24902]=218;code[22053]=840;code[28053]=774;
    code[58978]=-903;code[35704]=-122;code[34417]=-264;code[91313]=944;code[51597]=-894;code[99312]=216;
    code[67404]=700;code[79185]=-396;code[42383]=619;code[32454]=695;code[64184]=-477;code[62856]=-695;
    code[24862]=-90;code[93989]=84;code[9659]=-402;code[20449]=-726;code[27155]=1485;code[56365]=-598;
    code[82521]=509;code[45460]=887;code[39550]=-23;code[9552]=768;code[84407]=1197;code[61224]=-335;
    code[58170]=-986;code[6639]=429;code[41603]=501;code[7189]=-57;code[41636]=-418;code[10472]=1445;
    code[36203]=184;code[68586]=-316;code[84409]=1193;code[21765]=689;code[12033]=565;code[42380]=1043;
    code[19675]=419;code[28678]=-383;code[11488]=1294;code[28444]=-80;code[75979]=671;code[86049]=-775;
    code[17438]=579;code[70026]=673;code[92811]=-542;code[75137]=468;code[50272]=184;code[39736]=1298;
    code[71311]=1053;code[87308]=1404;code[66645]=1332;code[14722]=1380;code[58769]=-379;code[37817]=1115;
    code[31721]=1060;code[26447]=240;code[95556]=839;code[22383]=728;code[62193]=479;code[10081]=-482;
    code[18231]=367;code[75742]=1341;code[88424]=1084;code[31940]=804;code[17352]=-86;code[54124]=-268;
    code[4981]=-198;code[70955]=1056;code[52510]=1258;code[50889]=1311;code[25713]=1125;code[35609]=-754;
    code[92555]=-374;code[64113]=909;code[25288]=759;code[30264]=-707;code[72526]=651;code[78493]=-711;
    code[18079]=-476;code[7334]=876;code[93636]=635;code[67736]=1373;code[28778]=1425;code[44941]=572;
    code[3066]=-1;code[17035]=787;code[8611]=-562;code[95739]=-173;code[19400]=636;code[1623]=571;
    code[19746]=384;code[47290]=172;code[6531]=51;code[57504]=-28;code[54375]=474;code[64653]=-220;
    code[83530]=888;code[99950]=503;code[17775]=11;code[81704]=1375;code[80848]=-979;code[73760]=1128;
    code[53730]=464;code[3197]=364;code[71265]=123;code[92809]=312;code[19493]=111;code[55738]=-57;
    code[18524]=-489;code[88969]=1163;code[40062]=-856;code[8885]=101;code[76147]=1143;code[88947]=-175;
    code[18269]=-124;code[15518]=970;code[84703]=-836;code[82935]=-531;code[82503]=546;code[94006]=197;
    code[39117]=-935;code[68435]=-772;code[67085]=-706;code[11899]=-35;code[20242]=541;code[41949]=1430;
    code[52288]=1367;code[55501]=865;code[92540]=-269;code[9489]=692;code[70563]=754;code[36613]=-106;
    code[29680]=-665;code[68691]=-681;code[62338]=-85;code[56019]=413;code[27143]=14;code[47921]=-70;
    code[37954]=1492;code[77810]=598;code[74317]=245;code[12964]=412;code[93891]=-545;code[27004]=1238;
    code[51709]=-804;code[26928]=319;code[52738]=-356;code[78182]=718;code[66583]=-194;code[80070]=331;
    code[43716]=1476;code[77067]=1087;code[5983]=1129;code[70633]=-715;code[47320]=-552;code[37078]=1307;
    code[52203]=137;code[94346]=-492;code[57602]=997;code[42683]=-718;code[87087]=969;code[61724]=353;
    code[9914]=-927;code[4132]=-970;code[63191]=972;code[71431]=-863;code[20214]=-398;code[20598]=871;
    code[73624]=-266;code[50858]=-796;code[48259]=-615;code[42716]=-164;code[71398]=-139;code[860]=-827;
    code[32146]=435;code[11523]=1157;code[90327]=707;code[67056]=617;code[37891]=-438;code[74058]=-925;
    code[81520]=725;code[48872]=703;code[47203]=-216;code[72617]=-305;code[25151]=-526;code[47397]=-304;
    code[29488]=-144;code[63679]=779;code[36512]=-303;code[83612]=884;code[2095]=1428;code[69654]=-865;
    code[67847]=1117;code[15766]=294;code[57760]=394;code[37384]=267;code[56081]=188;code[27293]=974;
    code[67217]=858;code[87020]=-10;code[62630]=826;code[82412]=-675;code[10337]=1089;code[57323]=389;
    code[5028]=1387;code[28548]=-757;code[39592]=1456;code[932]=1097;code[100327]=79;code[676]=555;
    code[15793]=-490;code[70775]=730;code[82260]=1410;code[72529]=1044;code[7151]=1108;code[4355]=549;
    code[41629]=88;code[13186]=-275;code[15305]=406;code[95694]=1096;code[27871]=502;code[47054]=548;
    code[27563]=-315;code[11400]=437;code[46898]=81;code[79674]=-409;code[74090]=-393;code[24045]=46;
    code[2698]=-682;code[31390]=-654;code[11532]=880;code[48731]=-484;code[91702]=660;code[68760]=1396;
    code[85630]=797;code[69071]=87;code[48296]=-581;code[34712]=389;code[74055]=-789;code[42050]=359;
    code[85578]=-635;code[35334]=596;code[5152]=1016;code[88804]=-573;code[19728]=781;code[26498]=-938;
    code[25187]=1032;code[72827]=311;code[11726]=-347;code[71149]=524;code[59382]=-613;code[72784]=868;
    code[74995]=-107;code[76080]=421;code[90299]=707;code[68614]=1355;code[71323]=920;code[28929]=1421;
    code[40330]=1114;code[15623]=-738;code[78573]=281;code[76665]=-653;code[45812]=654;code[18561]=668;
    code[44639]=1050;code[44184]=187;code[37923]=1020;code[95883]=739;code[42480]=509;code[89815]=735;
    code[5048]=-215;code[27468]=282;code[3050]=-198;code[31757]=205;code[52832]=888;code[12449]=-324;
    code[10654]=505;code[83336]=-806;code[39490]=462;code[29351]=-791;code[17364]=-778;code[12559]=-807;
    code[24524]=-483;code[56852]=1252;code[81966]=479;code[54937]=992;code[95831]=153;code[5525]=167;
    code[24099]=-377;code[10914]=-665;code[34806]=756;code[14276]=720;code[70057]=-579;code[37122]=936;
    code[98528]=1189;code[30507]=1093;code[31395]=1022;code[52437]=1402;code[19045]=-511;code[27069]=1057;
    code[76020]=37;code[67097]=1334;code[21046]=-184;code[31972]=611;code[55050]=-96;code[84289]=-642;
    code[47903]=-607;code[74198]=175;code[95269]=91;code[38310]=-812;code[84289]=976;code[92656]=1348;
    code[28999]=771;code[48763]=-641;code[94533]=-766;code[27922]=-891;code[98577]=-287;code[38069]=1328;
    code[3550]=-480;code[48184]=-76;code[85557]=811;code[22871]=545;code[3778]=-601;code[36333]=-614;
    code[7185]=-873;code[1382]=882;code[81940]=-516;code[99073]=1413;code[49642]=819;code[64900]=251;
    code[84676]=-565;code[70874]=133;code[8445]=985;code[16415]=-523;code[78342]=1016;code[43740]=847;
    code[96295]=-973;code[22586]=-717;code[56633]=-242;code[90693]=-680;code[34943]=-175;code[7261]=1221;
    code[8065]=311;code[23059]=965;code[30203]=32;code[44015]=-232;code[56625]=1446;code[53090]=691;
    code[1989]=934;code[53714]=-392;code[100248]=-575;code[37790]=-338;code[61980]=-313;code[79995]=1008;
    code[97488]=1178;code[40456]=-525;code[83080]=292;code[15401]=279;code[10263]=1039;code[37536]=397;
    code[56806]=-58;code[89573]=-86;code[37099]=-682;code[17692]=1447;code[48602]=370;code[9435]=972;
    code[77356]=645;code[13237]=-558;code[95989]=1018;code[27406]=1013;code[73360]=64;code[82164]=72;
    code[1097]=-382;code[48420]=-885;code[83012]=-960;code[57767]=-491;code[40308]=1437;code[68257]=549;
    code[28132]=-976;code[90120]=222;code[9947]=1041;code[32218]=52;code[78213]=532;code[42365]=-581;
    code[38751]=1440;code[56056]=-264;code[54655]=419;code[83452]=-653;code[171]=2381;code[137]=1510;code[166]=2349;code[465]=193;code[236]=834;code[317]=3058;    data[1287]=-586;
code[489]=3700;    data[3201]=-875;
    data[2198]=-255;
code[80]=2203;    data[3530]=79;
    data[2592]=231;
code[172]=2646;code[173]=596;code[449]=504;code[430]=3738;    data[596]=-444;
code[225]=1425;    data[594]=false;
    data[3017]=479;
    data[3699]=(long)-321L;
    data[2646]=61;
code[227]=210;code[432]=2233;    data[3173]=(long)798L;
    data[1920]=723;
    data[2560]=167;
    data[336]=709;
    data[2795]=-320;
code[379]=3030;code[275]=2770;    data[2373]=397;
code[206]=3547;code[308]=867;    data[3304]=-390;
    data[1162]=872;
code[140]=2560;code[324]=2622;code[437]=2261;code[310]=2170;    data[1477]=-684;
code[269]=581;code[195]=580;    data[782]=-512;
    data[2120]=215;
    data[1657]=-112;
    data[2126]=769;
code[364]=1868;code[109]=3044;    data[3735]=0;
    data[681]=-277;
code[322]=2795;        data[186]=num;
    data[1425]=(long)1;
code[262]=1141;code[345]=186;    data[1198]=-988;
code[193]=351;code[452]=1861;code[316]=6545;code[394]=3699;    data[581]=227;
code[104]=186;    data[3366]=-751;
    data[3693]=522;
code[297]=3921;code[93]=369;code[421]=3699;    data[695]=-433;
code[129]=3615;code[70]=3735;code[455]=2427;    data[2147]=-300;
code[149]=3660;    data[2622]=152;
    data[3823]=-871;
code[464]=186;code[210]=1614;code[425]=3173;code[491]=1614;code[87]=4688;    data[104]=-459;
    data[2170]=1;
code[165]=594;code[86]=3489;code[102]=594;code[403]=2795;    data[1360]=931;
code[506]=3173;
    return (long)InstanceInterpreterVirtualization_FactorialTests_2195(vpc, data, code);

}

        public static string Time_Operation(VirtualizationType type, Func< int, long> method, int number, int warmup, int iterations)
        {

            int op = 0;
            string log = type + " warming ... " + warmup + " # " + number;
            Output(log);

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < warmup; i++)
            {
                method(number);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("{0} sec", timespan.TotalSeconds);
            log = type + " warmed up in " + time;
            Output(log);


            log = type + " running ... " + iterations + " # " + number;
            Output(log);
            timer = Stopwatch.StartNew();
            for (int j = 0; j < iterations; j++)
            {
                method(number);
            }
            timer.Stop();
            timespan = timer.Elapsed;

            time = String.Format("{0} sec", timespan.TotalSeconds);
            log = type + " finished in " + time;
            Output(log);
            Output("\n");
            return time;
        }

        private static void Output(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

private object InstanceInterpreterVirtualization_FactorialTests_2195(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 6545:
                data[code[vpc + (6)]] = (int)data[code[vpc + (29)]] - (int)data[code[vpc + (-6)]];
                vpc += 63;
                break;
            case 3030:
                data[code[vpc + (15)]] = FactorialRecursive_class_default_junk((int)data[code[vpc + (24)]]);
                vpc += 58;
                break;
            case 1141:
                vpc += (int)data[code[vpc + (7)]];
                vpc += 54;
                break;
            default:
                return (long)data[code[vpc + (15)]];
                vpc += 52;
            case 4688:
                data[code[vpc + (15)]] = (int)data[code[vpc + (17)]] == (int)data[code[vpc + (-17)]];
                vpc += 62;
                break;
            case 2261:
                data[code[vpc + (-12)]] = (int)data[code[vpc + (27)]] * (long)data[code[vpc + (-16)]];
                vpc += 54;
                break;
            case 3660:
                data[code[vpc + (24)]] = (bool)data[code[vpc + (16)]] ? (int)data[code[vpc + (23)]] : (int)data[code[vpc + (-9)]];
                vpc += (int)data[code[vpc + (24)]];
                break;
        }
    }

    return null;
}

private object InstanceInterpreterVirtualization_FactorialTests_3953(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 5812:
                data[code[vpc + (13)]] = (int)data[code[vpc + (6)]] == (int)data[code[vpc + (26)]];
                vpc += 63;
                break;
            case 7259:
                data[code[vpc + (9)]] = FactorialRecursive_class((int)data[code[vpc + (17)]]);
                vpc += 70;
                break;
            case 7084:
                data[code[vpc + (-19)]] = (int)data[code[vpc + (2)]] * (long)data[code[vpc + (4)]];
                vpc += 58;
                break;
            case 8554:
                vpc += (int)data[code[vpc + (8)]];
                vpc += 60;
                break;
            case 8212:
                data[code[vpc + (5)]] = (int)data[code[vpc + (7)]] - (int)data[code[vpc + (-16)]];
                vpc += 72;
                break;
            case 9028:
                return (long)data[code[vpc + (27)]];
                vpc += 66;
            default:
                break;
            case 7295:
                data[code[vpc + (11)]] = (bool)data[code[vpc + (28)]] ? (int)data[code[vpc + (-19)]] : (int)data[code[vpc + (3)]];
                vpc += (int)data[code[vpc + (11)]];
                break;
        }
    }

    return null;
}


    }
}