using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.VirtCode
{
    class CodeLoopTests
    {

        public static void RunLoopTests()
        {
            CodeLoopTests lt = new CodeLoopTests();

//            lt.ForSimple_Check();
//            lt.ForSimple_Array_Check();
//
//            lt.ForBreak_Check();
//            lt.ForContinue_Check();
//            lt.ForDoubleContinue_Check();
//            lt.ForDoubleBreak_Check();
//
//            lt.DoWhile_Simple_Check();


        }

        #region FOR_SIMPLE_ARRAY

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]
private string ForSimple_Array_obfuscated(int b)
{
    //Virtualization variables
    int[] code = new int[100534];
    object[] data = new object[4137];
    int vpc = 57;

    code[25958]=1183;code[30532]=-246;code[16111]=-259;code[1443]=502;code[14872]=-227;code[52067]=-428;
    code[39107]=1467;code[6888]=-388;code[58358]=-396;code[55227]=180;code[27139]=342;code[27086]=1178;
    code[45720]=-713;code[37857]=-529;code[94362]=-636;code[33013]=15;code[75912]=1411;code[68235]=266;
    code[36651]=-644;code[77478]=1149;code[80623]=448;code[25900]=172;code[15810]=1489;code[79621]=464;
    code[84989]=-74;code[20041]=914;code[32853]=-522;code[29176]=802;code[60736]=80;code[85159]=-887;
    code[92511]=1063;code[66578]=-996;code[98608]=-721;code[47651]=61;code[31001]=405;code[88519]=95;
    code[47366]=723;code[67395]=726;code[28095]=1001;code[71805]=147;code[32475]=976;code[34520]=420;
    code[95162]=406;code[7972]=409;code[67786]=1394;code[90713]=1330;code[29699]=813;code[94464]=1440;
    code[92197]=-361;code[49060]=-887;code[52447]=-82;code[27903]=-292;code[49256]=903;code[29603]=593;
    code[52375]=499;code[44400]=1008;code[72177]=-31;code[72605]=-677;code[48479]=-765;code[5571]=45;
    code[3269]=1275;code[75423]=-124;code[66323]=1370;code[14334]=864;code[75386]=735;code[77764]=-941;
    code[31423]=672;code[94240]=1388;code[51582]=-850;code[7862]=-537;code[26972]=105;code[4298]=-814;
    code[51872]=-754;code[21557]=1268;code[323]=1025;code[49676]=1057;code[20128]=-826;code[1298]=528;
    code[62052]=1317;code[62695]=354;code[62206]=371;code[89215]=1067;code[83049]=44;code[49362]=-878;
    code[45297]=916;code[61976]=55;code[1597]=1175;code[15060]=476;code[87211]=688;code[83922]=402;
    code[73760]=-413;code[74645]=1349;code[20095]=1376;code[82800]=-394;code[65937]=-186;code[34011]=465;
    code[43873]=340;code[56948]=798;code[55753]=-461;code[24989]=-755;code[61098]=-587;code[45930]=-409;
    code[19462]=-821;code[81139]=-175;code[92500]=56;code[74791]=1354;code[9252]=-844;code[81244]=-41;
    code[81054]=1369;code[63041]=1188;code[59736]=-380;code[39536]=-689;code[43062]=-925;code[99103]=198;
    code[30534]=75;code[3612]=629;code[42928]=841;code[95828]=421;code[78242]=264;code[75018]=-681;
    code[14419]=233;code[32428]=-417;code[58511]=-9;code[49688]=-66;code[73211]=-543;code[91816]=517;
    code[59186]=-68;code[50664]=-102;code[77612]=-170;code[81253]=-592;code[8662]=-182;code[2644]=224;
    code[38852]=-770;code[51739]=-112;code[11004]=-401;code[60856]=-250;code[20249]=247;code[73602]=-749;
    code[93070]=-601;code[54548]=-921;code[53879]=530;code[75529]=-698;code[51971]=72;code[6330]=-866;
    code[23389]=484;code[80065]=115;code[70142]=457;code[4200]=1039;code[46976]=1081;code[85152]=224;
    code[88670]=-653;code[26569]=221;code[58058]=532;code[40769]=-777;code[64430]=8;code[43595]=530;
    code[79387]=941;code[63080]=185;code[57935]=1263;code[97806]=1393;code[2944]=151;code[12341]=289;
    code[44568]=-602;code[60582]=546;code[45978]=1290;code[63671]=-768;code[31444]=-868;code[15048]=-8;
    code[34960]=-344;code[54626]=1259;code[2357]=1433;code[41530]=1073;code[16100]=-540;code[65984]=1302;
    code[96045]=419;code[24085]=404;code[86443]=1223;code[46292]=53;code[1617]=871;code[4542]=45;
    code[1042]=967;code[63561]=811;code[77411]=-149;code[30103]=842;code[63019]=-425;code[12704]=-217;
    code[36398]=-828;code[93901]=-861;code[4781]=-267;code[35740]=-353;code[50565]=703;code[66677]=1224;
    code[68029]=-822;code[23443]=58;code[59552]=820;code[38304]=497;code[21875]=-688;code[89838]=-409;
    code[34295]=721;code[5961]=1048;code[88946]=1298;code[29589]=812;code[44363]=1315;code[20084]=977;
    code[96059]=11;code[37577]=806;code[39521]=965;code[92008]=-178;code[12435]=856;code[4819]=746;
    code[10797]=1190;code[14522]=1246;code[85387]=318;code[9640]=-408;code[17620]=743;code[71857]=-103;
    code[23539]=339;code[37638]=458;code[38917]=1345;code[45080]=876;code[87635]=105;code[47023]=-531;
    code[35645]=645;code[20711]=78;code[21110]=411;code[11342]=496;code[64396]=-99;code[71595]=-979;
    code[77919]=-11;code[88031]=1285;code[83462]=1407;code[61897]=-356;code[69348]=-964;code[49109]=1142;
    code[41386]=-171;code[94683]=-537;code[29569]=-257;code[83121]=662;code[41063]=1391;code[54683]=-523;
    code[32292]=660;code[2701]=526;code[58781]=-710;code[72235]=1183;code[82817]=-86;code[81269]=1478;
    code[6293]=335;code[92530]=1271;code[83095]=-476;code[50065]=-151;code[17078]=-128;code[1998]=1195;
    code[62620]=1318;code[30609]=-142;code[53682]=-883;code[60329]=1046;code[85643]=711;code[59599]=-586;
    code[94103]=-988;code[67687]=434;code[29776]=537;code[3355]=-886;code[52615]=1376;code[12350]=899;
    code[37895]=1295;code[84308]=-504;code[46109]=-490;code[2121]=1430;code[64790]=-629;code[99295]=643;
    code[81602]=-62;code[34119]=941;code[76982]=1474;code[14014]=-56;code[94654]=886;code[97793]=1053;
    code[53933]=1310;code[4390]=386;code[31715]=1435;code[35676]=680;code[80881]=361;code[97141]=539;
    code[20949]=3;code[36167]=619;code[66710]=551;code[52415]=968;code[1751]=-961;code[76600]=1302;
    code[27722]=-359;code[28158]=333;code[81544]=862;code[82259]=555;code[95030]=-958;code[66574]=335;
    code[16125]=165;code[66038]=676;code[79799]=-212;code[85733]=-333;code[41123]=808;code[57144]=-90;
    code[63357]=228;code[71816]=-198;code[23442]=-537;code[80829]=301;code[16327]=-694;code[28047]=-853;
    code[69765]=1053;code[86583]=-851;code[73034]=-141;code[67426]=-523;code[74312]=1063;code[49000]=-507;
    code[96872]=1127;code[99893]=755;code[16403]=237;code[51455]=380;code[69184]=1289;code[90799]=-202;
    code[3071]=242;code[39129]=899;code[21431]=-646;code[37386]=-906;code[18836]=494;code[98168]=1430;
    code[45651]=982;code[54339]=-838;code[5300]=-57;code[62849]=1011;code[419]=292;code[35937]=-45;
    code[19272]=-746;code[35925]=668;code[61422]=816;code[37268]=945;code[92318]=354;code[2921]=-427;
    code[95974]=1276;code[98322]=493;code[45599]=124;code[989]=-87;code[87912]=-947;code[24931]=-76;
    code[95952]=116;code[50227]=-223;code[29213]=-754;code[31703]=283;code[14045]=-983;code[57124]=-722;
    code[78853]=761;code[42891]=151;code[22849]=-505;code[5428]=1280;code[76819]=-222;code[11111]=-646;
    code[40132]=-931;code[35304]=385;code[51001]=1479;code[51047]=-575;code[85846]=1468;code[71681]=-590;
    code[22825]=-851;code[49021]=1049;code[22755]=289;code[9005]=1369;code[34437]=1166;code[81746]=872;
    code[2328]=372;code[13903]=690;code[97249]=-161;code[60909]=608;code[33790]=-106;code[91661]=-343;
    code[75124]=902;code[612]=-631;code[50186]=-6;code[25871]=992;code[99670]=-345;code[23492]=-582;
    code[71443]=-415;code[68969]=-379;code[22282]=-593;code[80366]=331;code[21569]=505;code[53404]=1395;
    code[85813]=1078;code[20410]=295;code[38352]=-826;code[83263]=1173;code[14878]=-439;code[7298]=163;
    code[51228]=1354;code[45085]=1361;code[61265]=-960;code[76175]=902;code[31712]=1426;code[97068]=832;
    code[65304]=-107;code[42381]=-567;code[56122]=-52;code[4860]=-637;code[23099]=-881;code[29581]=669;
    code[19587]=847;code[41771]=1304;code[43640]=-90;code[1963]=214;code[16240]=-449;code[74282]=-301;
    code[71819]=1136;code[92795]=-504;code[84882]=925;code[64616]=1207;code[87065]=174;code[87335]=-940;
    code[65168]=637;code[31279]=921;code[17730]=1318;code[23684]=154;code[65096]=952;code[75385]=1175;
    code[60384]=1090;code[32849]=1377;code[95631]=199;code[57469]=72;code[62182]=-646;code[46130]=758;
    code[45869]=1124;code[30250]=148;code[40731]=28;code[80585]=812;code[87495]=-22;code[27485]=947;
    code[5343]=-373;code[31122]=-415;code[99033]=-307;code[63575]=1333;code[10541]=-869;code[60096]=-980;
    code[44596]=728;code[93653]=-34;code[90295]=99;code[40772]=266;code[19714]=518;code[31409]=-184;
    code[62981]=940;code[5682]=-410;code[98447]=-938;code[5]=-477;code[56569]=369;code[90279]=751;
    code[17093]=-157;code[44619]=-147;code[51201]=313;code[60188]=8;code[25349]=-269;code[1589]=783;
    code[48242]=37;code[83125]=76;code[99110]=917;code[58613]=113;code[94341]=1457;code[61093]=-478;
    code[22186]=-10;code[95938]=-800;code[5289]=-29;code[44789]=1239;code[79780]=-423;code[21756]=401;
    code[100130]=-840;code[100256]=676;code[894]=1272;code[7468]=-166;code[76442]=-143;code[76024]=410;
    code[19904]=423;code[22456]=989;code[96973]=131;code[76605]=-533;code[73368]=-413;code[12126]=-718;
    code[57406]=296;code[35285]=1158;code[85166]=-701;code[92489]=-379;code[19979]=-335;code[43681]=1304;
    code[77369]=1280;code[43898]=-927;code[91369]=-316;code[45092]=1194;code[64350]=-25;code[88672]=207;
    code[16605]=624;code[93634]=-148;code[47166]=-927;code[83532]=902;code[94865]=1210;code[10030]=225;
    code[56082]=-474;code[48924]=601;code[42521]=268;code[36732]=1329;code[462]=332;code[364]=8652;code[1001]=3597;code[1008]=3456;code[630]=1687;code[928]=2063;    data[1786]=487;
code[498]=3597;code[806]=3653;    data[294]=-5;
    data[2208]=(string[])null;
code[356]=294;        data[2239]=b;
    data[3199]=520;
code[586]=88;code[690]=2921;code[300]=2621;code[178]=1562;code[425]=1562;code[753]=2621;code[245]=2239;code[692]=1851;    data[1882]="#" ;
code[120]=2239;code[1076]=88;code[176]=887;code[177]=3710;    data[1687]=1;
code[817]=2409;code[351]=3199;code[567]=1562;code[873]=2063;    data[2579]=73;
code[743]=2921;code[940]=9315;code[58]=88;code[637]=1562;    data[2063]=535;
code[290]=1786;code[418]=3141;code[631]=3539;code[239]=1851;code[480]=88;code[698]=2239;    data[3141]="_" ;
code[560]=3663;code[56]=435;code[237]=1786;code[733]=1562;    data[332]=1125390383;
    data[435]="";
    data[1860]=false;
code[327]=1860;code[437]=9315;code[657]=1562;    data[1562]=-710;
    data[88]=1698300776;
code[884]=7075;code[545]=2208;    data[3456]=1268840513;
code[280]=1562;code[921]=1882;code[505]=332;code[1028]=88;    data[3653]=-520;
    data[887]=0;
code[349]=2579;code[525]=88;code[780]=1860;code[122]=2208;code[892]=2208;code[119]=9399;code[1063]=1067;    data[2921]=-109;
code[983]=88;code[57]=3710;code[965]=3456;code[366]=1860;
    return (string)InstanceInterpreterVirtualization_CodeLoopTests_1802(vpc, data, code);

}

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]
private string ForSimple_Array_obfuscated_default_junk(int b)
{
    //Virtualization variables
    int[] code = new int[100860];
    object[] data = new object[4182];
    int vpc = 67;

    code[86489]=-316;code[93948]=1292;code[9007]=-222;code[32315]=297;code[3412]=731;code[8470]=-301;
    code[14719]=-958;code[11082]=-175;code[20772]=-888;code[78269]=-533;code[25328]=-225;code[69630]=433;
    code[74250]=-789;code[85760]=-478;code[3721]=-819;code[62173]=-97;code[91471]=-389;code[57309]=983;
    code[73041]=-600;code[44315]=811;code[23662]=-614;code[88877]=1248;code[24127]=620;code[42866]=423;
    code[99507]=889;code[40701]=949;code[55325]=766;code[81804]=368;code[58847]=-105;code[18235]=-989;
    code[46524]=-722;code[48621]=1402;code[7682]=806;code[37599]=1253;code[45252]=-210;code[61107]=-886;
    code[61088]=-872;code[96069]=-759;code[43270]=977;code[33687]=-780;code[66519]=-298;code[22411]=-298;
    code[67485]=1091;code[81993]=-500;code[43715]=-948;code[21189]=-86;code[98794]=86;code[26545]=-693;
    code[67820]=1300;code[83043]=291;code[27773]=308;code[12182]=675;code[15139]=-106;code[17572]=242;
    code[76051]=786;code[11930]=981;code[2446]=-769;code[34819]=-549;code[89703]=-498;code[29456]=-401;
    code[91736]=-569;code[47202]=69;code[10714]=-401;code[6665]=-573;code[79513]=1073;code[42783]=272;
    code[97578]=1043;code[81964]=-661;code[16141]=379;code[13193]=-223;code[66799]=-211;code[45015]=797;
    code[91037]=43;code[34461]=1216;code[9016]=-794;code[23562]=178;code[63336]=459;code[61239]=-743;
    code[5606]=732;code[56888]=1275;code[29434]=-993;code[71471]=1311;code[29275]=523;code[83223]=-483;
    code[28252]=-477;code[2058]=-157;code[7095]=1452;code[58228]=483;code[73233]=872;code[52965]=721;
    code[90598]=-552;code[8235]=764;code[60100]=1382;code[88858]=-41;code[21190]=774;code[8105]=167;
    code[99636]=-449;code[1951]=647;code[61255]=304;code[43239]=-267;code[59741]=-664;code[61184]=1200;
    code[6287]=1240;code[40436]=617;code[645]=-967;code[38008]=-234;code[16932]=1188;code[1200]=-719;
    code[92943]=-993;code[33147]=-157;code[73453]=103;code[100544]=426;code[13002]=383;code[35259]=1124;
    code[96978]=1295;code[99472]=-490;code[32306]=-421;code[9726]=908;code[57761]=-497;code[64881]=749;
    code[55673]=-416;code[38059]=-509;code[33572]=934;code[30170]=-719;code[21053]=1267;code[74395]=510;
    code[19479]=-772;code[56988]=-623;code[13900]=-910;code[75765]=272;code[55125]=378;code[69145]=-780;
    code[2756]=-569;code[99471]=1340;code[78553]=-380;code[54443]=799;code[36280]=572;code[79209]=235;
    code[6458]=1000;code[23957]=-113;code[25643]=-408;code[64646]=-864;code[18212]=-46;code[1127]=-428;
    code[67252]=1363;code[63112]=341;code[45420]=-665;code[15449]=-999;code[55306]=-278;code[17062]=-600;
    code[79433]=-93;code[33662]=1401;code[37020]=-956;code[24672]=410;code[30863]=-824;code[8764]=-157;
    code[80556]=-10;code[25687]=-227;code[91807]=577;code[91543]=613;code[16274]=893;code[27157]=1083;
    code[62792]=-992;code[27195]=-437;code[47981]=961;code[95413]=937;code[63661]=-808;code[57241]=1227;
    code[91098]=701;code[69353]=-593;code[13847]=117;code[93086]=490;code[86597]=-280;code[74409]=-865;
    code[88720]=1109;code[9129]=1293;code[38478]=309;code[100756]=-925;code[9462]=251;code[34073]=-91;
    code[75442]=-952;code[8925]=303;code[12573]=-220;code[71232]=803;code[83566]=-92;code[40983]=-426;
    code[95137]=861;code[51248]=785;code[84151]=682;code[98311]=-165;code[26785]=-462;code[34868]=580;
    code[70001]=-929;code[39675]=-732;code[7889]=343;code[80420]=7;code[34566]=-191;code[41849]=-705;
    code[36154]=3;code[47550]=366;code[58704]=-960;code[22764]=290;code[44101]=1152;code[98255]=592;
    code[1577]=-289;code[19761]=51;code[53018]=-992;code[9898]=331;code[67931]=140;code[83448]=-760;
    code[92653]=497;code[64881]=-272;code[57102]=-992;code[89460]=548;code[33260]=-25;code[35898]=82;
    code[20341]=70;code[75868]=-377;code[99819]=1073;code[19653]=1083;code[5483]=891;code[9257]=984;
    code[34427]=-59;code[88467]=-153;code[22770]=1205;code[44833]=1255;code[57906]=-62;code[63333]=1458;
    code[37617]=1336;code[95813]=84;code[98219]=-113;code[30966]=563;code[93663]=907;code[22087]=-757;
    code[25348]=1122;code[54758]=1109;code[26375]=1485;code[4210]=-595;code[51138]=1124;code[95809]=-527;
    code[12748]=369;code[39697]=118;code[95367]=134;code[86608]=1065;code[80710]=922;code[88386]=-862;
    code[88715]=902;code[86679]=748;code[45340]=165;code[87240]=445;code[15903]=949;code[8858]=-58;
    code[34231]=501;code[64608]=449;code[33646]=164;code[48028]=308;code[99294]=901;code[30996]=65;
    code[96948]=1148;code[68585]=187;code[91214]=-19;code[29983]=205;code[98084]=219;code[97263]=250;
    code[13588]=-145;code[71865]=-898;code[99313]=-71;code[3207]=-134;code[46394]=-959;code[10897]=-138;
    code[82022]=-304;code[49697]=-165;code[29531]=-118;code[7138]=-703;code[45771]=83;code[74465]=474;
    code[79295]=-25;code[67966]=912;code[48650]=513;code[40791]=1129;code[64167]=-650;code[44909]=1478;
    code[75979]=88;code[54328]=532;code[73494]=1401;code[97431]=1361;code[75798]=-163;code[66727]=564;
    code[90764]=1407;code[19115]=548;code[42046]=1113;code[4696]=753;code[60908]=-694;code[25680]=486;
    code[70380]=-334;code[87183]=1136;code[61747]=-360;code[71487]=682;code[84060]=253;code[58603]=1143;
    code[82135]=144;code[39376]=233;code[47138]=984;code[84563]=127;code[73480]=-880;code[87254]=298;
    code[41954]=962;code[43860]=977;code[9444]=859;code[39082]=576;code[18231]=1360;code[92285]=154;
    code[9698]=-722;code[33519]=238;code[63160]=1471;code[79903]=-4;code[38514]=-170;code[81202]=1397;
    code[45873]=383;code[23596]=1025;code[28657]=1008;code[87341]=624;code[40512]=-138;code[44228]=1068;
    code[82848]=1294;code[58436]=-777;code[11484]=1375;code[68247]=1175;code[54763]=1321;code[40051]=-111;
    code[46537]=-142;code[83204]=849;code[25817]=166;code[13876]=-791;code[98827]=189;code[33901]=350;
    code[51436]=443;code[34959]=-57;code[7881]=-337;code[6075]=877;code[67879]=262;code[67958]=770;
    code[41269]=756;code[28713]=78;code[66107]=1337;code[41952]=315;code[15755]=1195;code[35172]=1352;
    code[98687]=-686;code[39701]=1337;code[20916]=-114;code[85467]=-137;code[58669]=-903;code[58449]=341;
    code[60886]=-252;code[79889]=-307;code[87573]=614;code[68869]=1390;code[67516]=-709;code[33364]=383;
    code[18342]=765;code[43209]=-888;code[6052]=1024;code[38742]=579;code[23058]=14;code[40228]=1380;
    code[87925]=-688;code[54848]=-205;code[66334]=-180;code[12778]=-75;code[12426]=870;code[83501]=-110;
    code[14401]=-655;code[66370]=275;code[19695]=-19;code[27384]=1154;code[80201]=1100;code[75973]=253;
    code[93420]=1006;code[28792]=929;code[66055]=1369;code[31053]=-506;code[90819]=1099;code[40929]=857;
    code[10296]=-89;code[30119]=-148;code[99836]=1401;code[43373]=84;code[88564]=-820;code[90994]=1304;
    code[15305]=1184;code[44033]=1090;code[13532]=342;code[15831]=-922;code[37504]=-894;code[39547]=1138;
    code[4321]=-113;code[72134]=-562;code[44407]=574;code[45958]=-243;code[73886]=1287;code[41173]=1076;
    code[9458]=1326;code[87954]=1086;code[41386]=-202;code[62863]=1134;code[90795]=-91;code[62546]=952;
    code[51545]=179;code[6436]=-92;code[68884]=-64;code[37449]=-851;code[98072]=108;code[30081]=587;
    code[24758]=-364;code[100192]=-380;code[62191]=498;code[19067]=-408;code[46958]=514;code[74881]=-491;
    code[67059]=-194;code[62637]=-870;code[42276]=345;code[96325]=697;code[74097]=1335;code[67020]=1421;
    code[57096]=-770;code[62519]=-105;code[54826]=-129;code[86579]=626;code[63759]=-408;code[59408]=-611;
    code[32899]=-63;code[23937]=-248;code[17629]=-42;code[31824]=1263;code[73550]=1150;code[70462]=-99;
    code[75985]=-203;code[64598]=85;code[49248]=548;code[90812]=-222;code[59506]=-939;code[68795]=311;
    code[98788]=1077;code[69922]=-708;code[75378]=-771;code[57650]=69;code[73972]=162;code[73231]=-890;
    code[30339]=635;code[50854]=-122;code[62385]=898;code[24143]=765;code[39690]=-352;code[60995]=-439;
    code[71418]=60;code[16353]=-968;code[33950]=-306;code[57072]=-247;code[69894]=782;code[32416]=-141;
    code[69594]=-504;code[15926]=593;code[29092]=-324;code[63249]=-280;code[59803]=491;code[13456]=1085;
    code[11603]=372;code[69881]=1076;code[79213]=1440;code[13206]=800;code[22808]=171;code[41241]=-193;
    code[93784]=396;code[9205]=139;code[90704]=61;code[35409]=469;code[33562]=-600;code[66704]=50;
    code[60647]=505;code[42118]=-694;code[63767]=-209;code[63704]=-721;code[29327]=-180;code[90558]=969;
    code[58978]=837;code[52047]=792;code[58693]=503;code[11874]=-447;code[79641]=1086;code[71345]=824;
    code[18101]=-572;code[39221]=-580;code[24742]=363;code[50565]=1386;code[89527]=-318;code[23142]=-542;
    code[56324]=-980;code[8864]=1273;code[84426]=-257;code[3266]=504;code[66649]=-241;code[87851]=-590;code[685]=3611;    data[1664]=262;
    data[3871]=-275;
    data[2420]=-244;
code[577]=3697;code[120]=3254;code[386]=8705;    data[2307]=-171;
code[1042]=2484;    data[3203]=866;
    data[34]=644;
code[385]=1065;code[404]=3901;    data[2621]=297;
    data[1770]=-291;
    data[1008]=322;
code[660]=8182;    data[480]=-411;
code[597]=8315;    data[2076]=19;
code[1057]=2566;    data[3037]=500;
code[1105]=2368;    data[818]=-788;
    data[309]=-171;
code[1023]=94;code[405]=215;code[1025]=2119;    data[3464]=-461;
code[863]=2289;code[233]=878;code[341]=804;code[519]=3171;    data[1130]=456;
code[485]=1803;    data[1096]=116;
    data[1017]=-206;
    data[35]="";
code[796]=3297;code[376]=2187;code[686]=3633;    data[472]=-520;
    data[2693]=939;
code[58]=1211;code[848]=1325;code[1129]=2743;    data[2992]=-306;
code[1033]=3016;code[681]=1374;    data[455]=-668;
code[346]=3633;code[313]=3472;    data[2951]=-984;
    data[190]=500;
code[687]=1765;code[713]=4515;code[388]=1795;code[468]=149;code[459]=1365;    data[2033]=911;
code[1043]=2119;code[1122]=3584;    data[2040]=-310;
code[986]=694;code[61]=3811;code[620]=1126;code[155]=1828;code[971]=1365;code[169]=1702;code[1093]=2344;code[618]=1844;code[1095]=1220;    data[3129]=-914;
    data[328]=422;
    data[535]=405;
    data[2614]=405;
code[138]=2843;code[889]=3078;    data[2637]=274;
    data[771]=268;
code[919]=2688;code[1121]=269;code[477]=269;code[623]=2578;code[210]=2480;code[518]=960;code[922]=983;    data[3958]=925;
code[1117]=2119;code[132]=1684;    data[3337]=-902;
    data[694]=360;
code[513]=2119;    data[2470]=-609;
    data[2068]=521;
code[406]=3202;code[739]=3188;    data[3573]=-748;
    data[30]=-818;
code[799]=2488;    data[755]=-681;
code[793]=2280;    data[2234]=-85;
code[526]=1520;    data[2222]=-394;
    data[1645]=427;
    data[2903]=389;
code[388]=2080;code[1059]=2323;code[871]=1801;code[192]=2671;code[1041]=3570;code[716]=465;code[781]=5576;    data[2607]=-44;
code[90]=3618;code[1026]=3946;code[130]=4692;code[521]=1704;    data[3136]=-889;
    data[976]=-1;
    data[1374]=1;
    data[3202]=744;
    data[3177]=115;
code[616]=3254;code[779]=215;    data[3009]=392;
    data[1810]=935;
    data[2702]=-911;
    data[2166]=467;
code[174]=3633;    data[2119]=1767785440;
code[742]=1223;    data[2921]=213;
    data[3210]=-722;
code[698]=861;    data[1811]=731;
code[991]=3016;code[928]=959;code[579]=1046;    data[1137]=-579;
code[530]=2484;code[906]=9203;code[982]=1261;code[54]=330;    data[2636]=55;
code[921]=3686;    data[241]=-786;
code[70]=2428;code[198]=527;code[863]=2474;code[896]=1695;code[67]=5573;    data[868]=-988;
code[808]=3633;code[721]=1621;    data[1577]=-393;
    data[878]=-21;
code[479]=1704;code[928]=3765;        data[1223]=b;
    data[3710]=333;
code[342]=797;code[450]=2790;code[132]=2249;code[531]=2119;    data[3717]=652;
code[280]=1223;code[546]=1445;    data[448]="#" ;
    data[1649]=-905;
    data[2370]=-652;
code[809]=833;    data[2384]=-453;
    data[546]=558;
    data[2224]=-754;
    data[344]=571;
    data[2743]=-454;
    data[669]=785;
    data[3633]=152;
code[317]=215;    data[3901]=520;
    data[3751]=674;
code[137]=3801;code[612]=3633;code[935]=694;    data[2377]=239;
    data[3794]=925;
    data[833]=390;
    data[3291]=-185;
    data[1094]=-617;
code[319]=5576;code[85]=35;    data[1704]=910238941;
    data[127]=909;
    data[2318]=49;
    data[3269]=-666;
code[933]=2983;code[188]=5573;    data[3254]=(string[])null;
code[126]=1223;code[717]=1431;code[601]=2119;    data[1862]=-65;
    data[2790]="_" ;
code[1105]=3299;    data[900]=758;
code[695]=833;    data[2727]=-74;
code[528]=713;    data[1309]=592;
code[1044]=321;    data[76]=-894;
code[81]=3945;code[962]=448;    data[3067]=-822;
code[370]=1637;    data[3155]=-587;
    data[3860]=-40;
code[905]=3254;    data[3016]=1101107014;
code[53]=2119;code[195]=599;code[251]=4515;code[619]=1118;code[914]=778;code[914]=3755;code[206]=1886;    data[1226]=576;
    data[2974]=-646;
    data[2394]=433;
code[1116]=144;code[401]=1567;    data[2164]=-132;
code[805]=3506;code[393]=3412;code[1135]=2967;    data[850]=-791;
    data[215]=false;
code[466]=2590;code[674]=1678;    data[1886]=0;
code[900]=1745;code[934]=1163;code[867]=2750;    data[3187]=161;
code[645]=2940;code[200]=2366;    data[2187]=73;
    data[3359]=-278;
    data[3447]=-747;
code[474]=3633;code[647]=3633;code[784]=659;code[831]=472;code[554]=2535;code[478]=1022;code[313]=2453;code[241]=3795;code[964]=2632;code[347]=878;code[1109]=9870;
    return (string)InstanceInterpreterVirtualization_CodeLoopTests_3525(vpc, data, code);

}

//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; ")]
        private string ForSimple_example()
        {

            string sum = "";            
            for (int i = 0; i < ReturnArg_Array(3); i++)
            {
                sum += "_" + i;                
            }
            
            return sum;
        }


        private string ForSimple_Array_original(int b)
        {

            string sum = "";
            string[] dst = new string[b];
            for (int i = 0; i < ReturnArg_Array(b); i++)
            {
                sum += "_" + i ;
                sum += "~";
                dst[i] = sum;
            }

            sum += "#" + dst.Length;
            return sum;
        }

        private int ReturnArg_Array(int arg)
        {
            return arg;
        }

        private void ForSimple_Array_Check()
        {
            string testName = "Code#ForSimple_Array_Check";
            Program.Start_Check(testName);
            bool condition = true;
            
            int b = 6;
            if (Program.args_in.Count() > 0)
            {
                string loop_count = Program.args_in[0];
                int nr = Int32.Parse(loop_count);
                b = nr;
            }                

            string virt1 = ForSimple_Array_obfuscated( b);
            string virt2 = ForSimple_Array_obfuscated_default_junk(b);
            string oracle = ForSimple_Array_original( b);
            Console.WriteLine("virt {0} {1} = {2} orig", virt1, virt2, oracle);
            condition = virt1 == virt2 && virt2 == oracle;
            Program.End_Check(testName, condition);
        }

        #endregion

        #region FOR_SIMPLE

        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string ForSimple_0(int a, int b)
        {
            string sum = "";
            for (int i = 0; i < ReturnArg(b); i++)
            {
                sum += "_" + i;
            }

            return sum;
        }

        private string ForSimple_1(int a, int b)
        {

            string sum = "";
            for (int i = 0; i < ReturnArg(b); i++)
            {
                sum += "_" + i;
            }

            return sum;
        }

        private int ReturnArg(int arg)
        {
            return arg;
        }

        private void ForSimple_Check()
        {
            string testName = "Code#ForSimple_Check";
            Program.Start_Check(testName);
            bool condition = true;
            int a = 2;
            int b = 6;
            string virt = ForSimple_0(a, b);
            string oracle = ForSimple_1(a, b);
            Console.WriteLine("virt {0} = {1} orig", virt, oracle);
            condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

        #endregion

        #region FOR_BREAK

//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
private string ForBreak_0(int a, int b)
{
    string sum = "";
    int var_forIndex_0 = 0;
    bool var_whileCondition_0 = var_forIndex_0 < b;
    while (var_whileCondition_0)
    {
        sum = sum + var_forIndex_0;
        bool var_ifCondition_0 = var_forIndex_0 == a;
        if (var_ifCondition_0)
        {
            sum = sum + "continue";
            var_forIndex_0 = var_forIndex_0 + 1;
            var_whileCondition_0 = var_forIndex_0 < b;
            continue;
        }

        bool var_ifCondition_1 = var_forIndex_0 == 4;
        if (var_ifCondition_1)
        {
            sum = sum + "break";
            var_forIndex_0 = var_forIndex_0 + 1;
            var_whileCondition_0 = false;
            continue;
        }

        sum = sum + "_";
        var_forIndex_0 = var_forIndex_0 + 1;
        var_whileCondition_0 = var_forIndex_0 < b;
    }

    return sum;
}


    private string ForBreak_1(int a, int b)
    {

        string sum = "";
        for (int i = 0; i < b; i++)
        {
            sum += i;

            if (i == a)
            {
                sum += "continue";
                continue;
            }
            if (i == 4)
            {
                sum += "break";
                break;
            }
            sum += "_";
        }

        return sum;
    }

        private void ForBreak_Check()
        {
            string testName = "Code#ForBreak_Check";
            Program.Start_Check(testName);
            bool condition = true;
            int a = 1;
            int b = 6;
            string virt = ForBreak_0(a, b);
            string oracle = ForBreak_1(a, b);
            Console.WriteLine("virt {0} = {1} orig", virt, oracle);
            condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

        #endregion

        #region FOR_CONTINUE

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string ForContinue_0(int a, int b)
        {

            string sum = "";
            for (int i = 0; i < b; i++)
            {
                sum += i;

                if (i == a)
                {
                    sum += "x";
                    continue;
                }
                if (i == 4)
                    continue;
                sum += "_";
            }

            return sum;
        }


        private string ForContinue_1(int a, int b)
        {

            string sum = "";
            for (int i = 0; i < b; i++)
            {
                sum += i;

                if (i == a)
                {
                    sum += "x";
                    continue;
                }
                if (i == 4)
                    continue;
                sum += "_";
            }

            return sum;
        }

        private void ForContinue_Check()
        {
            string testName = "Code#ForContinue_Check";
            Program.Start_Check(testName);
            bool condition = true;
            int a = 2;
            int b = 6;
            string virt = ForContinue_0(a, b);
            string oracle = ForContinue_1(a, b);
            Console.WriteLine("virt {0} = {1} orig", virt, oracle);
            condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

        #endregion

        #region FOR_Double_CONTINUE

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string ForDoubleContinue_0(int a, int b)
        {
            string sum = "";
            for (int j = 0; j <= a; j++)
            {
                sum += "#j>>>";

                if (j % 2 == 1)
                    continue;

                for (int i = 0; i < b; i++)
                {
                    sum += i;

                    if (i == a)
                    {
                        sum += "x";
                        continue;
                    }
                    if (i == 4)
                        continue;
                    sum += "_";
                }

                sum += "<#";
            }

            return sum;
        }


        private string ForDoubleContinue_1(int a, int b)
        {
            string sum = "";
            for (int j = 0; j <= a; j++)
            {
                sum += "#j>>>";

                if (j % 2 == 1)
                    continue;

                for (int i = 0; i < b; i++)
                {
                    sum += i;

                    if (i == a)
                    {
                        sum += "x";
                        continue;
                    }
                    if (i == 4)
                        continue;
                    sum += "_";
                }

                sum += "<#";
            }

            return sum;
        }

        private void ForDoubleContinue_Check()
        {
            string testName = "Code#ForDoubleContinue_Check";
            Program.Start_Check(testName);
            bool condition = true;
            int a = 2;
            int b = 6;
            string virt = ForDoubleContinue_0(a, b);
            string oracle = ForDoubleContinue_1(a, b);
            Console.WriteLine("virt {0} = {1} orig", virt, oracle);
            condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

        #endregion

        #region FOR_Double_BREAK
//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string ForDoubleBreak_0(int a, int b)
        {

            string sum = "";
            for (int j = 0; j <= a; j++)
            {
                sum += "#j>>>";

                if (j % 2 == 1)
                    break;

                for (int i = 0; i < b; i++)
                {
                    sum += i;

                    if (i == a)
                    {
                        sum += "x";
                        continue;
                    }
                    if (i == 4)
                        break;
                    sum += "_";
                }

                sum += "<#";
            }

            return sum;
        }


        private string ForDoubleBreak_1(int a, int b)
        {

            string sum = "";
            for (int j = 0; j <= a; j++)
            {
                sum += "#j>>>";

                if (j % 2 == 1)
                    break;

                for (int i = 0; i < b; i++)
                {
                    sum += i;

                    if (i == a)
                    {
                        sum += "x";
                        continue;
                    }
                    if (i == 4)
                        break;
                    sum += "_";
                }

                sum += "<#";
            }

            return sum;
        }

        private void ForDoubleBreak_Check()
        {
            string testName = "Code#ForDoubleBreak_Check";
            Program.Start_Check(testName);
            bool condition = true;
            int a = 2;
            int b = 6;
            string virt = ForDoubleBreak_0(a, b);
            string oracle = ForDoubleBreak_1(a, b);
            Console.WriteLine("virt {0} = {1} orig", virt, oracle);
            condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

        #endregion

        #region WHILE_CONTINUE

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string WhileContinue_0(int a, int b)
        {

            string sum = "";
            int i = 0;
            while (i < b)
            {
                sum += i;
                i++;

                if (i == a)
                {
                    sum += "x";
                    continue;
                }
                if (i == 4)
                    continue;
                sum += "_";
            }

            return sum;
        }


        private string WhileContinue_1(int a, int b)
        {
            string sum = "";
            int i = 0;
            while (i < b)
            {
                sum += i;
                i++;

                if (i == a)
                {
                    sum += "x";
                    continue;
                }
                if (i == 4)
                    continue;
                sum += "_";
            }

            return sum;
        }

        private void WhileContinue_Check()
        {
            string testName = "Code#WhileContinue_Check";
            Program.Start_Check(testName);
            bool condition = true;
            int a = 2;
            int b = 6;
            string virt = WhileContinue_0(a, b);
            string oracle = WhileContinue_1(a, b);
            Console.WriteLine("virt {0} = {1} orig", virt, oracle);
            condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

        #endregion

       

        #region SIMPLE_DO_WHILE

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string DoWhile_Simple_0()
        {            
            string sum = "";
            int i = 0;
            do
            {
                sum += i;
                i++;
            } while (i < 5);
            return sum;
        }

        private string DoWhile_Simple_1()
        {
            string sum = "";
            int i = 0;
            do
            {
                sum += i;
                i++;
            } while (i < 5);
            return sum;
        }

        private void DoWhile_Simple_Check()
        {
            string testName = "Code#DoWhile_Simple_Check";
            Program.Start_Check(testName);
            bool condition = true;            
            string virt = DoWhile_Simple_0();
            string oracle = DoWhile_Simple_1();
            Console.WriteLine("virt {0} = {1} orig", virt, oracle);
            condition = virt == oracle;
            Program.End_Check(testName, condition);
        }

private object InstanceInterpreterVirtualization_CodeLoopTests_1802(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 3663:
                ((string[])data[code[vpc + (-15)]])[(int)data[code[vpc + (7)]]] = (string)data[code[vpc + (26)]];
                vpc += 71;
                break;
            case 7075:
                data[code[vpc + (-11)]] = ((string[])data[code[vpc + (8)]]).Length;
                vpc += 56;
                break;
            case 1067:
                return (string)data[code[vpc + (13)]];
                vpc += 68;
            default:
                break;
            case 1851:
                data[code[vpc + (-2)]] = ReturnArg((int)data[code[vpc + (6)]]);
                vpc += 61;
                break;
            case 2409:
                vpc += (int)data[code[vpc + (-11)]];
                vpc += 67;
                break;
            case 3597:
                data[code[vpc + (27)]] = (string)data[code[vpc + (-18)]] + (string)data[code[vpc + (7)]];
                vpc += 62;
                break;
            case 9315:
                data[code[vpc + (25)]] = (string)data[code[vpc + (-19)]] + (int)data[code[vpc + (-12)]];
                vpc += 61;
                break;
            case 2621:
                data[code[vpc + (27)]] = (int)data[code[vpc + (-20)]] < (int)data[code[vpc + (-10)]];
                vpc += 64;
                break;
            case 8652:
                data[code[vpc + (-8)]] = (bool)data[code[vpc + (2)]] ? (int)data[code[vpc + (-15)]] : (int)data[code[vpc + (-13)]];
                vpc += (int)data[code[vpc + (-8)]];
                break;
            case 3539:
                data[code[vpc + (6)]] = (int)data[code[vpc + (26)]] + (int)data[code[vpc + (-1)]];
                vpc += 61;
                break;
            case 3710:
                data[code[vpc + (1)]] = data[code[vpc + (-1)]];
                vpc += 62;
                break;
            case 9399:
                data[code[vpc + (3)]] = (string[])(new string[(int)data[code[vpc + (1)]]]);
                vpc += 58;
                break;
        }
    }

    return null;
}

private object InstanceInterpreterVirtualization_CodeLoopTests_3525(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 8705:
                data[code[vpc + (20)]] = (bool)data[code[vpc + (19)]] ? (int)data[code[vpc + (-10)]] : (int)data[code[vpc + (18)]];
                vpc += (int)data[code[vpc + (20)]];
                break;
            case 9203:
                data[code[vpc + (29)]] = ((string[])data[code[vpc + (-1)]]).Length;
                vpc += 65;
                break;
            case 4515:
                data[code[vpc + (-18)]] = ReturnArg((int)data[code[vpc + (29)]]);
                vpc += 68;
                break;
            case 8182:
                data[code[vpc + (26)]] = (int)data[code[vpc + (-13)]] + (int)data[code[vpc + (21)]];
                vpc += 53;
                break;
            case 5576:
                data[code[vpc + (-2)]] = (int)data[code[vpc + (27)]] < (int)data[code[vpc + (28)]];
                vpc += 67;
                break;
            default:
                data[code[vpc + (-14)]] = data[code[vpc + (18)]];
                vpc += 63;
                break;
            case 2484:
                data[code[vpc + (1)]] = (string)data[code[vpc + (-17)]] + (string)data[code[vpc + (-9)]];
                vpc += 67;
                break;
            case 8315:
                ((string[])data[code[vpc + (19)]])[(int)data[code[vpc + (15)]]] = (string)data[code[vpc + (4)]];
                vpc += 63;
                break;
            case 1325:
                vpc += (int)data[code[vpc + (-17)]];
                vpc += 58;
                break;
            case 4692:
                data[code[vpc + (-10)]] = (string[])(new string[(int)data[code[vpc + (-4)]]]);
                vpc += 58;
                break;
            case 1365:
                data[code[vpc + (20)]] = (string)data[code[vpc + (-9)]] + (int)data[code[vpc + (15)]];
                vpc += 71;
                break;
            case 9870:
                return (string)data[code[vpc + (8)]];
                vpc += 56;
        }
    }

    return null;
}
        #endregion

        


    }
}