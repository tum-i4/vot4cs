using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCalculator.Tracing
{
    class TraceLoopTests
    {

        public static void RunLoopTests()
        {
            TraceLoopTests lt = new TraceLoopTests();

//            lt.ForSimple_Array_Check();
//



        }

        private void ForSimple_Array_Check()
        {
            string testName = "Trace#ForSimple_Array_Check";
            Program.Start_Check(testName);
            bool condition = true;

            int b = 5;
            if (Program.args_in.Count() > 0)
            {
                string loop_count = Program.args_in[0];
                int nr = Int32.Parse(loop_count);
                b = nr;
            }

            string oracle = ForSimple_Array_original(b);
            string oracle2 = ForSimple_Array_original_in(b);

            string ref1 = ForSimple_Array_refactored_op2_in1(b);
            string ref2 = ForSimple_Array_refactored_op3_in1(b);
            string ref3 = ForSimple_Array_refactored_op4_in1(b);
            string ref4 = ForSimple_Array_refactored_op4_in4(b);
            string ref5 = ForSimple_Array_refactored_op4_in5(b);

            Debug.Assert(ref1.Equals(oracle), "ref1");
            Debug.Assert(ref2.Equals(oracle), "ref2");
            Debug.Assert(ref3.Equals(oracle), "ref3");
            Debug.Assert(ref4.Equals(oracle), "ref4");
            Debug.Assert(ref5.Equals(oracle), "ref5");
            bool refactoredCheck = ref1.Equals(oracle) &&
                                   ref2.Equals(oracle) && ref3.Equals(oracle) && ref4.Equals(oracle)
                                   && ref5.Equals(oracle);

            string virt1 = ForSimple_Array_obfuscated_op2_in1(b);
            Debug.Assert(virt1.Equals(oracle), "virt1");

            string virt2 = ForSimple_Array_obfuscated_op3_in1(b);
            Debug.Assert(virt2.Equals(oracle), "virt2");

            string virt3 = ForSimple_Array_obfuscated_op4_in1(b);
            Debug.Assert(virt3.Equals(oracle), "virt3");

            string virt4 = ForSimple_Array_obfuscated_op4_in4(b);
            Debug.Assert(virt4.Equals(oracle), "virt4");

            string virt5 = ForSimple_Array_obfuscated_op4_in5(b);
            Debug.Assert(virt5.Equals(oracle), "virt5");


            string virt21 = ForSimple_Array_obfuscated2_op4_in1(b);
            Debug.Assert(virt21.Equals(oracle2), "virt21");

            string virt22 = ForSimple_Array_obfuscated2_op4_in2(b);
            Debug.Assert(virt22.Equals(oracle2), "virt22");

            string virt23 = ForSimple_Array_obfuscated2_op4_in3(b);
            Debug.Assert(virt23.Equals(oracle2), "virt23");

            string virt24 = ForSimple_Array_obfuscated2_op4_in4(b);
            Debug.Assert(virt24.Equals(oracle2), "virt24");

            string virt25 = ForSimple_Array_obfuscated2_op4_in5(b);
            Debug.Assert(virt25.Equals(oracle2), "virt25");

            bool virtualizedCheck = virt1.Equals(oracle) &&
                                  virt2.Equals(oracle) && virt3.Equals(oracle) && virt4.Equals(oracle)
                                  && virt5.Equals(oracle);

            bool virtualizedCheck2 = virt21.Equals(oracle2) &&
                                  virt22.Equals(oracle2) && virt23.Equals(oracle2) && virt24.Equals(oracle2)
                                  && virt25.Equals(oracle2);

            Console.WriteLine("\n{0}\n{1}", oracle, oracle2);
            condition = refactoredCheck && virtualizedCheck && virtualizedCheck2;
            Program.End_Check(testName, condition);
        }

        private Car car = new Car("invocation-check-car", 4);

        private string ForSimple_Array_original(int b)
        {
            string sum = "" + 3 + 4 + "";
            var p1 = car.GetEngine().GetPistons().First().GetSize();
            sum += "[" + p1 + "]";
            sum += car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1).ToString();

            string r = "";
            string[] dst = new string[b];
            for (int i = 0; i < ReturnArg_Array(b); i++)
            {
                sum += "_" + i + "_";
                sum += "~";               
                r += sum + "#";
                dst[i] = sum;
            }

            sum += "#" + dst.Length;
            
            return sum;
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

//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
private string ForSimple_Array_ref_op4_in1(int b)
{
    string sum = "" + 3 + 4 + "";
    ConsoleCalculator.Engine invocationTemp_0 = car.GetEngine();
    ConsoleCalculator.Engine invocationTemp_1 = car.GetEngine();
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_2 = invocationTemp_1.GetPistons();
    int memberTemp_0 = invocationTemp_2.Count;
    ConsoleCalculator.Piston invocationTemp_3 = invocationTemp_0.GetPiston(memberTemp_0 - 1);
    string invocationTemp_4 = invocationTemp_3.ToString();
    sum = sum + invocationTemp_4;
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    int invocationTemp_5 = ReturnArg_Array(b);
    bool var_whileCondition_0 = var_forIndex_0 < invocationTemp_5;
    while (var_whileCondition_0)
    {
        sum = sum + "_" + var_forIndex_0 + "_";
        sum = sum + "~";
        r = r + sum + "#";
        ConsoleCalculator.Engine invocationTemp_6 = car.GetEngine();
        System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_7 = invocationTemp_6.GetPistons();
        ConsoleCalculator.Piston invocationTemp_8 = invocationTemp_7.First();
        double p1 = invocationTemp_8.GetSize();
        r = r + "[" + p1 + "]";
        int memberTemp_1 = r.Length;
        sum = sum + memberTemp_1;
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        int invocationTemp_9 = ReturnArg_Array(b);
        var_whileCondition_0 = var_forIndex_0 < invocationTemp_9;
    }

    int memberTemp_2 = dst.Length;
    sum = sum + "#" + memberTemp_2;
    return sum;
}

       
private string ForSimple_Array_ref_op4_in2(int b)
{
    string sum = "" + 3 + 4 + "";
    ConsoleCalculator.Engine invocationTemp_0 = car.GetEngine();
    ConsoleCalculator.Engine invocationTemp_1 = car.GetEngine();
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_2 = invocationTemp_1.GetPistons();
    int memberTemp_0 = invocationTemp_2.Count;
    ConsoleCalculator.Piston invocationTemp_3 = invocationTemp_0.GetPiston(memberTemp_0 - 1);
    string invocationTemp_4 = invocationTemp_3.ToString();
    sum = sum + invocationTemp_4;
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    int invocationTemp_5 = ReturnArg_Array(b);
    bool var_whileCondition_0 = var_forIndex_0 < invocationTemp_5;
    while (var_whileCondition_0)
    {
        sum = sum + "_" + var_forIndex_0 + "_";
        sum = sum + "~";
        r = r + sum + "#";
        ConsoleCalculator.Engine invocationTemp_6 = car.GetEngine();
        System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_7 = invocationTemp_6.GetPistons();
        ConsoleCalculator.Piston invocationTemp_8 = invocationTemp_7.First();
        double p1 = invocationTemp_8.GetSize();
        r = r + "[" + p1 + "]";
        int memberTemp_1 = r.Length;
        sum = sum + memberTemp_1;
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        int invocationTemp_9 = ReturnArg_Array(b);
        var_whileCondition_0 = var_forIndex_0 < invocationTemp_9;
    }

    int memberTemp_2 = dst.Length;
    sum = sum + "#" + memberTemp_2;
    return sum;
}


       
private string ForSimple_Array_ref_op4_in3(int b)
{
    string sum = "" + 3 + 4 + "";
    ConsoleCalculator.Engine invocationTemp_0 = car.GetEngine();
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_1 = invocationTemp_0.GetPistons();
    int memberTemp_0 = invocationTemp_1.Count;
    ConsoleCalculator.Piston invocationTemp_2 = car.GetEngine().GetPiston(memberTemp_0 - 1);
    sum = sum + invocationTemp_2.ToString();
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    int invocationTemp_3 = ReturnArg_Array(b);
    bool var_whileCondition_0 = var_forIndex_0 < invocationTemp_3;
    while (var_whileCondition_0)
    {
        sum = sum + "_" + var_forIndex_0 + "_";
        sum = sum + "~";
        r = r + sum + "#";
        System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_4 = car.GetEngine().GetPistons();
        double p1 = invocationTemp_4.First().GetSize();
        r = r + "[" + p1 + "]";
        int memberTemp_1 = r.Length;
        sum = sum + memberTemp_1;
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        var_whileCondition_0 = var_forIndex_0 < ReturnArg_Array(b);
    }

    int memberTemp_2 = dst.Length;
    sum = sum + "#" + memberTemp_2;
    return sum;
}
       
       
private string ForSimple_Array_ref_op4_in4(int b)
{
    string sum = "" + 3 + 4 + "";
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_0 = car.GetEngine().GetPistons();
    int memberTemp_0 = invocationTemp_0.Count;
    string invocationTemp_1 = car.GetEngine().GetPiston(memberTemp_0 - 1).ToString();
    sum = sum + invocationTemp_1;
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    bool var_whileCondition_0 = var_forIndex_0 < ReturnArg_Array(b);
    while (var_whileCondition_0)
    {
        sum = sum + "_" + var_forIndex_0 + "_";
        sum = sum + "~";
        r = r + sum + "#";
        System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_2 = car.GetEngine().GetPistons();
        double p1 = invocationTemp_2.First().GetSize();
        r = r + "[" + p1 + "]";
        int memberTemp_1 = r.Length;
        sum = sum + memberTemp_1;
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        var_whileCondition_0 = var_forIndex_0 < ReturnArg_Array(b);
    }

    int memberTemp_2 = dst.Length;
    sum = sum + "#" + memberTemp_2;
    return sum;
}

        
private string ForSimple_Array_ref_op4_in5(int b)
{
    string sum = "" + 3 + 4 + "";
    int memberTemp_0 = car.GetEngine().GetPistons().Count;
    ConsoleCalculator.Piston invocationTemp_0 = car.GetEngine().GetPiston(memberTemp_0 - 1);
    sum = sum + invocationTemp_0.ToString();
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    bool var_whileCondition_0 = var_forIndex_0 < ReturnArg_Array(b);
    while (var_whileCondition_0)
    {
        sum = sum + "_" + var_forIndex_0 + "_";
        sum = sum + "~";
        r = r + sum + "#";
        System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_1 = car.GetEngine().GetPistons();
        double p1 = invocationTemp_1.First().GetSize();
        r = r + "[" + p1 + "]";
        int memberTemp_1 = r.Length;
        sum = sum + memberTemp_1;
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        var_whileCondition_0 = var_forIndex_0 < ReturnArg_Array(b);
    }

    int memberTemp_2 = dst.Length;
    sum = sum + "#" + memberTemp_2;
    return sum;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string ForSimple_Array_obfuscated2_op4_in1(int b)
{
    //Virtualization variables
    int[] code = new int[100640];
    object[] data = new object[4600];
    int vpc = 74;

    //Data init
    data[2262]=b; //b 
    data[338]="" ; //"" constant
    data[3290]=3 ; //3 constant
    data[2944]=4 ; //4 constant
    data[2282]=1; //1 constant
    data[977]=0; //0 constant
    data[2695]="_" ; //"_" constant
    data[2478]="~"; //"~" constant
    data[2115]="#"; //"#" constant
    data[782]="[" ; //"[" constant
    data[1091]="]"; //"]" constant
    data[3044]=580772629; //sum 
    data[1586]=(ConsoleCalculator.Engine)null; //invocationTemp_0 
    data[1315]=(ConsoleCalculator.Engine)null; //invocationTemp_1 
    data[2794]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_2 
    data[3259]=-365; //memberTemp_0 
    data[3845]=(ConsoleCalculator.Piston)null; //invocationTemp_3 
    data[3759]=108831917; //invocationTemp_4 
    data[2048]=614725912; //r 
    data[3360]=(string[])null; //dst 
    data[480]=190; //var_forIndex_0 
    data[621]=689; //invocationTemp_5 
    data[2673]=false; //var_whileCondition_0 
    data[2235]=(ConsoleCalculator.Engine)null; //invocationTemp_6 
    data[3793]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_7 
    data[3658]=(ConsoleCalculator.Piston)null; //invocationTemp_8 
    data[1945]=(double)0.291733439216266; //p1 
    data[3832]=539; //memberTemp_1 
    data[2008]=59; //invocationTemp_9 
    data[1495]=-698; //memberTemp_2 
    data[1440]=159; //fake-1440 
    data[1987]=812; //fake-1987 
    data[1641]=169; //fake-1641 
    data[2623]=130; //fake-2623 
    data[620]=792; //fake-620 
    data[3463]=393; //fake-3463 
    data[1222]=-992; //fake-1222 
    data[184]=-770; //fake-184 
    data[530]=-265; //fake-530 
    data[2584]=496; //fake-2584 
    data[3913]=10; //fake-3913 
    data[3815]=40; //fake-3815 
    data[3663]=310; //fake-3663 
    data[1457]=-209; //fake-1457 
    data[608]=-723; //fake-608 
    data[860]=-587; //fake-860 
    data[3673]=690; //fake-3673 
    data[2463]=-582; //fake-2463 
    data[2575]=259; //fake-2575 
    data[1821]=-923; //fake-1821 
    data[3165]=-921; //fake-3165 
    data[2613]=-350; //fake-2613 
    data[2676]=156; //fake-2676 
    data[1211]=-966; //fake-1211 
    data[3213]=678; //fake-3213 
    data[3882]=-639; //fake-3882 
    data[1298]=-37; //fake-1298 
    data[3125]=-537; //fake-3125 
    data[2968]=-999; //fake-2968 
    data[2578]=481; //fake-2578 
    data[2864]=-701; //fake-2864 
    data[1]=-248; //fake-1 
    data[2106]=-199; //fake-2106 
    data[100]=-777; //fake-100 
    data[249]=-965; //fake-249 
    data[244]=139; //fake-244 
    data[1303]=-690; //fake-1303 
    data[2432]=962; //fake-2432 
    data[960]=-505; //fake-960 
    data[374]=-413; //fake-374 
    data[1119]=-720; //fake-1119 
    data[2717]=806; //jmpWhileDestinationName_2717 constant
    data[1279]=69; //while_GoTo_True_1279 constant
    data[1078]=1001; //while_GoTo_False_1078 constant
    data[1426]=-1001; //while_FalseBlockSkip_1426 constant
    data[1490]=-435; //fake-1490 
    data[2750]=105; //fake-2750 
    data[3464]=339; //fake-3464 
    data[1969]=500; //fake-1969 
    data[3671]=325; //fake-3671 
    data[2927]=310; //fake-2927 
    data[158]=-705; //fake-158 
    data[2501]=-224; //fake-2501 
    data[3508]=999; //fake-3508 
    data[1750]=-835; //fake-1750 
    data[3283]=-720; //fake-3283 
    data[3554]=-18; //fake-3554 
    data[3640]=-778; //fake-3640 
    data[3649]=-491; //fake-3649 
    data[2649]=-344; //fake-2649 
    data[3859]=135; //fake-3859 
    data[3817]=452; //fake-3817 
    data[2878]=431; //fake-2878 
    data[518]=-571; //fake-518 
    data[2389]=544; //fake-2389 
    data[3432]=-772; //fake-3432 
    data[552]=254; //fake-552 
    data[1583]=196; //fake-1583 
    data[3615]=-743; //fake-3615 
    data[101]=-762; //fake-101 
    data[3005]=87; //fake-3005 
    data[3810]=-245; //fake-3810 
    data[3010]=137; //fake-3010 
    data[2652]=-897; //fake-2652 
    data[149]=727; //fake-149 
    data[2248]=922; //fake-2248 
    data[1207]=-329; //fake-1207 
    data[470]=796; //fake-470 
    data[3873]=-727; //fake-3873 
    data[1016]=-916; //fake-1016 
    data[1202]=-950; //fake-1202 
    data[824]=-306; //fake-824 
    data[3537]=-823; //fake-3537 
    data[1684]=36; //fake-1684 
    data[1488]=653; //fake-1488 
    data[1076]=-832; //fake-1076 
    data[1021]=224; //fake-1021 
    data[1738]=482; //fake-1738 
    data[3555]=-866; //fake-3555 
    data[1320]=-528; //fake-1320 
    data[3711]=819; //fake-3711 
    data[3597]=-1000; //fake-3597 
    data[872]=525; //fake-872 
    data[2727]=-517; //fake-2727 
    data[1375]=175; //fake-1375 
    data[270]=-490; //fake-270 
    data[3140]=64; //fake-3140 
    data[2813]=-842; //fake-2813 
    data[3282]=-265; //fake-3282 
    data[1429]=577; //fake-1429 
    data[3834]=311; //fake-3834 
    data[740]=909; //fake-740 
    data[3898]=82; //fake-3898 
    data[320]=261; //fake-320 
    data[956]=-763; //fake-956 
    data[2838]=-446; //fake-2838 
    data[3440]=158; //fake-3440 
    data[2774]=-327; //fake-2774 
    data[3386]=-729; //fake-3386 

    //Code init

    code[74]=5774; //ExpressionStatement_0 # ExpressionStatement_0
    code[54]=3044; //sum
    code[75]=338; //""
    code[65]=3290; //3
    code[85]=2944; //4
    code[64]=338; //""
    code[59]=1655; //fake-ExpressionStatement_0_1655_-15

    code[130]=7716; //ExpressionStatement_1 # ExpressionStatement_1
    code[125]=1586; //invocationTemp_0
    code[129]=570; //fake-ExpressionStatement_1_570_-1
    code[149]=2374; //fake-ExpressionStatement_1_2374_19
    code[149]=1054; //fake-ExpressionStatement_1_1054_19
    code[115]=2862; //fake-ExpressionStatement_1_2862_-15
    code[117]=2526; //fake-ExpressionStatement_1_2526_-13

    code[196]=7716; //ExpressionStatement_1 # ExpressionStatement_2
    code[191]=1315; //invocationTemp_1
    code[212]=1532; //fake-ExpressionStatement_1_1532_16
    code[211]=86; //fake-ExpressionStatement_1_86_15
    code[186]=2028; //fake-ExpressionStatement_1_2028_-10

    code[262]=6043; //ExpressionStatement_3 # ExpressionStatement_3
    code[291]=2794; //invocationTemp_2
    code[244]=1315; //invocationTemp_1
    code[278]=30; //fake-ExpressionStatement_3_30_16
    code[263]=672; //fake-ExpressionStatement_3_672_1
    code[256]=411; //fake-ExpressionStatement_3_411_-6
    code[271]=1679; //fake-ExpressionStatement_3_1679_9

    code[321]=7373; //ExpressionStatement_4 # ExpressionStatement_4
    code[333]=3259; //memberTemp_0
    code[310]=2794; //invocationTemp_2
    code[305]=2288; //fake-ExpressionStatement_4_2288_-16

    code[388]=7807; //ExpressionStatement_5 # ExpressionStatement_5
    code[394]=3845; //invocationTemp_3
    code[397]=1586; //invocationTemp_0
    code[375]=3259; //memberTemp_0
    code[405]=2282; //1
    code[400]=2397; //fake-ExpressionStatement_5_2397_12
    code[372]=2502; //fake-ExpressionStatement_5_2502_-16
    code[410]=1307; //fake-ExpressionStatement_5_1307_22
    code[372]=367; //fake-ExpressionStatement_5_367_-16

    code[453]=2223; //ExpressionStatement_6 # ExpressionStatement_6
    code[463]=3759; //invocationTemp_4
    code[450]=3845; //invocationTemp_3
    code[454]=2444; //fake-ExpressionStatement_6_2444_1
    code[475]=1940; //fake-ExpressionStatement_6_1940_22
    code[459]=3789; //fake-ExpressionStatement_6_3789_6

    code[522]=7862; //ExpressionStatement_7 # ExpressionStatement_7
    code[541]=3044; //sum
    code[532]=3044; //sum
    code[529]=3759; //invocationTemp_4
    code[527]=3455; //fake-ExpressionStatement_7_3455_5
    code[527]=1089; //fake-ExpressionStatement_7_1089_5
    code[524]=1226; //fake-ExpressionStatement_7_1226_2

    code[583]=8318; //ExpressionStatement_8 # ExpressionStatement_8
    code[565]=2048; //r
    code[598]=338; //""
    code[593]=1375; //fake-ExpressionStatement_8_1375_10
    code[612]=3485; //fake-ExpressionStatement_8_3485_29
    code[587]=1200; //fake-ExpressionStatement_8_1200_4

    code[649]=4889; //ExpressionStatement_9 # ExpressionStatement_9
    code[641]=3360; //dst
    code[631]=2262; //b
    code[634]=3975; //fake-ExpressionStatement_9_3975_-15
    code[677]=37; //fake-ExpressionStatement_9_37_28
    code[650]=594; //fake-ExpressionStatement_9_594_1
    code[647]=3912; //fake-ExpressionStatement_9_3912_-2
    code[632]=1185; //fake-ExpressionStatement_9_1185_-17
    code[678]=3558; //fake-ExpressionStatement_9_3558_29
    code[677]=3240; //fake-ExpressionStatement_9_3240_28

    code[715]=8318; //ExpressionStatement_8 # ExpressionStatement_10
    code[697]=480; //var_forIndex_0
    code[730]=977; //0
    code[731]=3496; //fake-ExpressionStatement_8_3496_16

    code[781]=8245; //ExpressionStatement_11 # ExpressionStatement_11
    code[808]=621; //invocationTemp_5
    code[807]=2262; //b
    code[792]=1337; //fake-ExpressionStatement_11_1337_11
    code[789]=2890; //fake-ExpressionStatement_11_2890_8
    code[766]=1287; //fake-ExpressionStatement_11_1287_-15
    code[793]=543; //fake-ExpressionStatement_11_543_12

    code[847]=2063; //ExpressionStatement_12 # ExpressionStatement_12
    code[855]=2673; //var_whileCondition_0
    code[831]=480; //var_forIndex_0
    code[834]=621; //invocationTemp_5
    code[846]=3795; //fake-ExpressionStatement_12_3795_-1
    code[856]=2786; //fake-ExpressionStatement_12_2786_9

    code[900]=6605; //WhileStatementSyntax_13 # WhileStatementSyntax_13
    code[918]=2717; //jmpWhileDestinationName_2717
    code[919]=2673; //var_whileCondition_0
    code[916]=1279; //while_GoTo_True_1279
    code[898]=1078; //while_GoTo_False_1078
    code[902]=2375; //fake-fake-whileVirtualOperation_2375_2
    code[885]=88; //fake-fake-whileVirtualOperation_88_-15
    code[917]=2328; //fake-fake-whileVirtualOperation_2328_17
    code[922]=2892; //fake-fake-whileVirtualOperation_2892_22

    code[969]=3889; //ExpressionStatement_14 # ExpressionStatement_14
    code[994]=3044; //sum
    code[985]=3044; //sum
    code[965]=2695; //"_"
    code[952]=480; //var_forIndex_0
    code[990]=2695; //"_"
    code[986]=2747; //fake-ExpressionStatement_14_2747_17
    code[963]=1488; //fake-ExpressionStatement_14_1488_-6
    code[971]=1904; //fake-ExpressionStatement_14_1904_2
    code[956]=837; //fake-ExpressionStatement_14_837_-13
    code[967]=2728; //fake-ExpressionStatement_14_2728_-2
    code[988]=2541; //fake-ExpressionStatement_14_2541_19

    code[1037]=7862; //ExpressionStatement_7 # ExpressionStatement_15
    code[1056]=3044; //sum
    code[1047]=3044; //sum
    code[1044]=2478; //"~"
    code[1036]=3325; //fake-ExpressionStatement_7_3325_-1
    code[1043]=3081; //fake-ExpressionStatement_7_3081_6
    code[1041]=1973; //fake-ExpressionStatement_7_1973_4
    code[1036]=3782; //fake-ExpressionStatement_7_3782_-1
    code[1059]=65; //fake-ExpressionStatement_7_65_22

    code[1098]=6517; //ExpressionStatement_16 # ExpressionStatement_16
    code[1103]=2048; //r
    code[1122]=2048; //r
    code[1110]=3044; //sum
    code[1096]=2115; //"#"
    code[1085]=3780; //fake-ExpressionStatement_16_3780_-13

    code[1154]=7716; //ExpressionStatement_1 # ExpressionStatement_17
    code[1149]=2235; //invocationTemp_6
    code[1161]=376; //fake-ExpressionStatement_1_376_7
    code[1169]=6; //fake-ExpressionStatement_1_6_15
    code[1169]=3932; //fake-ExpressionStatement_1_3932_15
    code[1170]=1761; //fake-ExpressionStatement_1_1761_16
    code[1164]=804; //fake-ExpressionStatement_1_804_10
    code[1140]=2047; //fake-ExpressionStatement_1_2047_-14
    code[1172]=2489; //fake-ExpressionStatement_1_2489_18

    code[1220]=6043; //ExpressionStatement_3 # ExpressionStatement_18
    code[1249]=3793; //invocationTemp_7
    code[1202]=2235; //invocationTemp_6
    code[1217]=3258; //fake-ExpressionStatement_3_3258_-3
    code[1242]=2537; //fake-ExpressionStatement_3_2537_22
    code[1200]=109; //fake-ExpressionStatement_3_109_-20
    code[1231]=3426; //fake-ExpressionStatement_3_3426_11
    code[1222]=3206; //fake-ExpressionStatement_3_3206_2

    code[1279]=7054; //ExpressionStatement_19 # ExpressionStatement_19
    code[1285]=3658; //invocationTemp_8
    code[1305]=3793; //invocationTemp_7
    code[1307]=1004; //fake-ExpressionStatement_19_1004_28

    code[1345]=3144; //ExpressionStatement_20 # ExpressionStatement_20
    code[1362]=1945; //p1
    code[1363]=3658; //invocationTemp_8
    code[1328]=1490; //fake-ExpressionStatement_20_1490_-17
    code[1330]=3538; //fake-ExpressionStatement_20_3538_-15

    code[1408]=6440; //ExpressionStatement_21 # ExpressionStatement_21
    code[1388]=2048; //r
    code[1420]=2048; //r
    code[1412]=782; //"["
    code[1404]=1945; //p1
    code[1390]=1091; //"]"
    code[1399]=1221; //fake-ExpressionStatement_21_1221_-9
    code[1428]=282; //fake-ExpressionStatement_21_282_20
    code[1432]=1532; //fake-ExpressionStatement_21_1532_24
    code[1426]=6; //fake-ExpressionStatement_21_6_18

    code[1479]=1796; //ExpressionStatement_22 # ExpressionStatement_22
    code[1460]=3832; //memberTemp_1
    code[1497]=2048; //r
    code[1459]=2606; //fake-ExpressionStatement_22_2606_-20
    code[1505]=2281; //fake-ExpressionStatement_22_2281_26

    code[1540]=6361; //ExpressionStatement_23 # ExpressionStatement_23
    code[1544]=3044; //sum
    code[1568]=3044; //sum
    code[1530]=3832; //memberTemp_1
    code[1569]=1401; //fake-ExpressionStatement_23_1401_29

    code[1602]=6050; //ExpressionStatement_24 # ExpressionStatement_24
    code[1631]=3360; //dst
    code[1603]=480; //var_forIndex_0
    code[1585]=3044; //sum
    code[1623]=689; //fake-ExpressionStatement_24_689_21
    code[1583]=2266; //fake-ExpressionStatement_24_2266_-19
    code[1614]=3081; //fake-ExpressionStatement_24_3081_12
    code[1607]=318; //fake-ExpressionStatement_24_318_5
    code[1621]=2641; //fake-ExpressionStatement_24_2641_19

    code[1663]=5703; //ExpressionStatement_25 # ExpressionStatement_25
    code[1685]=480; //var_forIndex_0
    code[1653]=480; //var_forIndex_0
    code[1650]=2282; //1
    code[1666]=1455; //fake-ExpressionStatement_25_1455_3

    code[1731]=8245; //ExpressionStatement_11 # ExpressionStatement_26
    code[1758]=2008; //invocationTemp_9
    code[1757]=2262; //b
    code[1722]=84; //fake-ExpressionStatement_11_84_-9
    code[1754]=394; //fake-ExpressionStatement_11_394_23

    code[1797]=2063; //ExpressionStatement_12 # ExpressionStatement_27
    code[1805]=2673; //var_whileCondition_0
    code[1781]=480; //var_forIndex_0
    code[1784]=2008; //invocationTemp_9
    code[1812]=785; //fake-ExpressionStatement_12_785_15
    code[1804]=576; //fake-ExpressionStatement_12_576_7
    code[1819]=2705; //fake-ExpressionStatement_12_2705_22
    code[1803]=2307; //fake-ExpressionStatement_12_2307_6

    code[1850]=9860; //ExpressionStatement_28 # ExpressionStatement_28
    code[1864]=1426; //while_FalseBlockSkip_1426
    code[1871]=2694; //fake-ExpressionStatement_28_2694_21
    code[1839]=1697; //fake-ExpressionStatement_28_1697_-11
    code[1869]=408; //fake-ExpressionStatement_28_408_19
    code[1879]=3033; //fake-ExpressionStatement_28_3033_29
    code[1858]=1446; //fake-ExpressionStatement_28_1446_8
    code[1868]=923; //fake-ExpressionStatement_28_923_18

    code[1901]=1706; //ExpressionStatement_29 # ExpressionStatement_29
    code[1925]=1495; //memberTemp_2
    code[1889]=3360; //dst
    code[1910]=3505; //fake-ExpressionStatement_29_3505_9
    code[1902]=56; //fake-ExpressionStatement_29_56_1

    code[1962]=2942; //ExpressionStatement_30 # ExpressionStatement_30
    code[1944]=3044; //sum
    code[1961]=3044; //sum
    code[1991]=2115; //"#"
    code[1983]=1495; //memberTemp_2
    code[1965]=2058; //fake-ExpressionStatement_30_2058_3
    code[1950]=3443; //fake-ExpressionStatement_30_3443_-12
    code[1973]=28; //fake-ExpressionStatement_30_28_11

    code[2034]=2372; //ReturnStatement_31 # ReturnStatement_31
    code[2058]=3044; //sum
    code[2049]=3215; //fake-ReturnStatement_31_3215_15
    code[2014]=912; //fake-ReturnStatement_31_912_-20
    code[2032]=1990; //fake-ReturnStatement_31_1990_-2

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_3664_2_op4_in1(vpc, data, code);

}

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
private string ForSimple_Array_obfuscated2_op4_in2(int b)
{
    //Virtualization variables
    int[] code = new int[100869];
    object[] data = new object[4244];
    int vpc = 36;

    //Data init
    data[2311]=b; //b 
    data[2367]="" ; //"" constant
    data[835]=3 ; //3 constant
    data[1382]=4 ; //4 constant
    data[746]=1; //1 constant
    data[2829]=0; //0 constant
    data[873]="_" ; //"_" constant
    data[1281]="~"; //"~" constant
    data[3485]="#"; //"#" constant
    data[3249]="[" ; //"[" constant
    data[1847]="]"; //"]" constant
    data[2921]=253115470; //sum 
    data[2135]=(ConsoleCalculator.Engine)null; //invocationTemp_0 
    data[2193]=(ConsoleCalculator.Engine)null; //invocationTemp_1 
    data[3263]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_2 
    data[1603]=-352; //memberTemp_0 
    data[64]=(ConsoleCalculator.Piston)null; //invocationTemp_3 
    data[2924]=529691550; //invocationTemp_4 
    data[906]=448189483; //r 
    data[1232]=(string[])null; //dst 
    data[3363]=-591; //var_forIndex_0 
    data[998]=-127; //invocationTemp_5 
    data[1935]=false; //var_whileCondition_0 
    data[2491]=(ConsoleCalculator.Engine)null; //invocationTemp_6 
    data[3865]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_7 
    data[105]=(ConsoleCalculator.Piston)null; //invocationTemp_8 
    data[351]=(double)0.0763740581815942; //p1 
    data[2348]=-481; //memberTemp_1 
    data[2058]=-893; //invocationTemp_9 
    data[309]=503; //memberTemp_2 
    data[2610]=420; //jmpWhileDestinationName_2610 constant
    data[1863]=67; //while_GoTo_True_1863 constant
    data[3304]=1014; //while_GoTo_False_3304 constant
    data[2669]=-1014; //while_FalseBlockSkip_2669 constant

    //Code init

    code[36]=8744; //ExpressionStatement_0 # ExpressionStatement_0
    code[41]=2921; //sum
    code[58]=2367; //""
    code[20]=835; //3
    code[29]=1382; //4
    code[33]=2367; //""

    code[102]=3603; //ExpressionStatement_1 # ExpressionStatement_1
    code[91]=2135; //invocationTemp_0

    code[162]=3603; //ExpressionStatement_1 # ExpressionStatement_2
    code[151]=2193; //invocationTemp_1

    code[222]=5550; //ExpressionStatement_3 # ExpressionStatement_3
    code[240]=3263; //invocationTemp_2
    code[220]=2193; //invocationTemp_1

    code[286]=6602; //ExpressionStatement_4 # ExpressionStatement_4
    code[296]=1603; //memberTemp_0
    code[285]=3263; //invocationTemp_2

    code[348]=1972; //ExpressionStatement_5 # ExpressionStatement_5
    code[346]=64; //invocationTemp_3
    code[336]=2135; //invocationTemp_0
    code[358]=1603; //memberTemp_0
    code[359]=746; //1

    code[413]=8147; //ExpressionStatement_6 # ExpressionStatement_6
    code[422]=2924; //invocationTemp_4
    code[417]=64; //invocationTemp_3

    code[478]=9852; //ExpressionStatement_7 # ExpressionStatement_7
    code[485]=2921; //sum
    code[504]=2921; //sum
    code[480]=2924; //invocationTemp_4

    code[537]=3768; //ExpressionStatement_8 # ExpressionStatement_8
    code[555]=906; //r
    code[531]=2367; //""

    code[600]=4038; //ExpressionStatement_9 # ExpressionStatement_9
    code[602]=1232; //dst
    code[620]=2311; //b

    code[662]=3768; //ExpressionStatement_8 # ExpressionStatement_10
    code[680]=3363; //var_forIndex_0
    code[656]=2829; //0

    code[725]=5836; //ExpressionStatement_11 # ExpressionStatement_11
    code[736]=998; //invocationTemp_5
    code[728]=2311; //b

    code[783]=4592; //ExpressionStatement_12 # ExpressionStatement_12
    code[798]=1935; //var_whileCondition_0
    code[768]=3363; //var_forIndex_0
    code[799]=998; //invocationTemp_5

    code[841]=5350; //WhileStatementSyntax_13 # WhileStatementSyntax_13
    code[858]=2610; //jmpWhileDestinationName_2610
    code[847]=1935; //var_whileCondition_0
    code[828]=1863; //while_GoTo_True_1863
    code[862]=3304; //while_GoTo_False_3304

    code[908]=3761; //ExpressionStatement_14 # ExpressionStatement_14
    code[915]=2921; //sum
    code[928]=2921; //sum
    code[902]=873; //"_"
    code[890]=3363; //var_forIndex_0
    code[919]=873; //"_"

    code[979]=9852; //ExpressionStatement_7 # ExpressionStatement_15
    code[986]=2921; //sum
    code[1005]=2921; //sum
    code[981]=1281; //"~"

    code[1038]=6991; //ExpressionStatement_16 # ExpressionStatement_16
    code[1023]=906; //r
    code[1030]=906; //r
    code[1060]=2921; //sum
    code[1028]=3485; //"#"

    code[1099]=3603; //ExpressionStatement_1 # ExpressionStatement_17
    code[1088]=2491; //invocationTemp_6

    code[1159]=5550; //ExpressionStatement_3 # ExpressionStatement_18
    code[1177]=3865; //invocationTemp_7
    code[1157]=2491; //invocationTemp_6

    code[1223]=3067; //ExpressionStatement_19 # ExpressionStatement_19
    code[1209]=105; //invocationTemp_8
    code[1249]=3865; //invocationTemp_7

    code[1281]=1734; //ExpressionStatement_20 # ExpressionStatement_20
    code[1288]=351; //p1
    code[1270]=105; //invocationTemp_8

    code[1348]=8188; //ExpressionStatement_21 # ExpressionStatement_21
    code[1343]=906; //r
    code[1361]=906; //r
    code[1346]=3249; //"["
    code[1344]=351; //p1
    code[1359]=1847; //"]"

    code[1409]=6308; //ExpressionStatement_22 # ExpressionStatement_22
    code[1422]=2348; //memberTemp_1
    code[1412]=906; //r

    code[1480]=5954; //ExpressionStatement_23 # ExpressionStatement_23
    code[1474]=2921; //sum
    code[1484]=2921; //sum
    code[1491]=2348; //memberTemp_1

    code[1549]=6007; //ExpressionStatement_24 # ExpressionStatement_24
    code[1554]=1232; //dst
    code[1570]=3363; //var_forIndex_0
    code[1555]=2921; //sum

    code[1612]=7907; //ExpressionStatement_25 # ExpressionStatement_25
    code[1594]=3363; //var_forIndex_0
    code[1629]=3363; //var_forIndex_0
    code[1634]=746; //1

    code[1674]=5836; //ExpressionStatement_11 # ExpressionStatement_26
    code[1685]=2058; //invocationTemp_9
    code[1677]=2311; //b

    code[1732]=4592; //ExpressionStatement_12 # ExpressionStatement_27
    code[1747]=1935; //var_whileCondition_0
    code[1717]=3363; //var_forIndex_0
    code[1748]=2058; //invocationTemp_9

    code[1790]=4169; //ExpressionStatement_28 # ExpressionStatement_28
    code[1807]=2669; //while_FalseBlockSkip_2669

    code[1855]=6067; //ExpressionStatement_29 # ExpressionStatement_29
    code[1850]=309; //memberTemp_2
    code[1863]=1232; //dst

    code[1908]=6045; //ExpressionStatement_30 # ExpressionStatement_30
    code[1900]=2921; //sum
    code[1927]=2921; //sum
    code[1905]=3485; //"#"
    code[1891]=309; //memberTemp_2

    code[1969]=1508; //ReturnStatement_31 # ReturnStatement_31
    code[1988]=2921; //sum

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_913_2_op4_in2(vpc, data, code);

}

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
private string ForSimple_Array_obfuscated2_op4_in3(int b)
{
    //Virtualization variables
    int[] code = new int[100612];
    object[] data = new object[4959];
    int vpc = 116;

    //Data init
    data[1828]=b; //b 
    data[123]="" ; //"" constant
    data[2435]=3 ; //3 constant
    data[1805]=4 ; //4 constant
    data[997]=1; //1 constant
    data[2989]=0; //0 constant
    data[2099]="_" ; //"_" constant
    data[2791]="~"; //"~" constant
    data[365]="#"; //"#" constant
    data[1855]="[" ; //"[" constant
    data[12]="]"; //"]" constant
    data[843]=1290348670; //sum 
    data[3782]=(ConsoleCalculator.Engine)null; //invocationTemp_0 
    data[2756]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
    data[1728]=-780; //memberTemp_0 
    data[3972]=(ConsoleCalculator.Piston)null; //invocationTemp_2 
    data[538]=2023170179; //r 
    data[1098]=(string[])null; //dst 
    data[1812]=-536; //var_forIndex_0 
    data[2972]=-238; //invocationTemp_3 
    data[3051]=false; //var_whileCondition_0 
    data[886]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_4 
    data[2974]=(double)0.559951857458778; //p1 
    data[2610]=940; //memberTemp_1 
    data[1104]=-455; //memberTemp_2 
    data[2745]=-239; //jmpWhileDestinationName_2745 constant
    data[2384]=61; //while_GoTo_True_2384 constant
    data[2355]=816; //while_GoTo_False_2355 constant
    data[645]=-816; //while_FalseBlockSkip_645 constant

    //Code init

    code[116]=1395; //ExpressionStatement_0 # ExpressionStatement_0
    code[99]=843; //sum
    code[129]=123; //""
    code[115]=2435; //3
    code[128]=1805; //4
    code[124]=123; //""

    code[182]=8970; //ExpressionStatement_1 # ExpressionStatement_1
    code[199]=3782; //invocationTemp_0

    code[247]=3718; //ExpressionStatement_2 # ExpressionStatement_2
    code[249]=2756; //invocationTemp_1
    code[265]=3782; //invocationTemp_0

    code[314]=3792; //ExpressionStatement_3 # ExpressionStatement_3
    code[307]=1728; //memberTemp_0
    code[298]=2756; //invocationTemp_1

    code[374]=2505; //ExpressionStatement_4 # ExpressionStatement_4
    code[401]=3972; //invocationTemp_2
    code[365]=1728; //memberTemp_0
    code[368]=997; //1

    code[427]=2578; //ExpressionStatement_5 # ExpressionStatement_5
    code[413]=843; //sum
    code[435]=843; //sum
    code[439]=3972; //invocationTemp_2

    code[485]=4590; //ExpressionStatement_6 # ExpressionStatement_6
    code[505]=538; //r
    code[480]=123; //""

    code[543]=1364; //ExpressionStatement_7 # ExpressionStatement_7
    code[536]=1098; //dst
    code[542]=1828; //b

    code[603]=4590; //ExpressionStatement_6 # ExpressionStatement_8
    code[623]=1812; //var_forIndex_0
    code[598]=2989; //0

    code[661]=9526; //ExpressionStatement_9 # ExpressionStatement_9
    code[689]=2972; //invocationTemp_3
    code[650]=1828; //b

    code[731]=3200; //ExpressionStatement_10 # ExpressionStatement_10
    code[738]=3051; //var_whileCondition_0
    code[749]=1812; //var_forIndex_0
    code[735]=2972; //invocationTemp_3

    code[790]=5450; //WhileStatementSyntax_11 # WhileStatementSyntax_11
    code[791]=2745; //jmpWhileDestinationName_2745
    code[804]=3051; //var_whileCondition_0
    code[775]=2384; //while_GoTo_True_2384
    code[800]=2355; //while_GoTo_False_2355

    code[851]=7974; //ExpressionStatement_12 # ExpressionStatement_12
    code[836]=843; //sum
    code[878]=843; //sum
    code[845]=2099; //"_"
    code[849]=1812; //var_forIndex_0
    code[873]=2099; //"_"

    code[913]=1197; //ExpressionStatement_13 # ExpressionStatement_13
    code[894]=843; //sum
    code[942]=843; //sum
    code[908]=2791; //"~"

    code[974]=7817; //ExpressionStatement_14 # ExpressionStatement_14
    code[956]=538; //r
    code[995]=538; //r
    code[954]=843; //sum
    code[998]=365; //"#"

    code[1041]=7703; //ExpressionStatement_15 # ExpressionStatement_15
    code[1042]=886; //invocationTemp_4

    code[1108]=6319; //ExpressionStatement_16 # ExpressionStatement_16
    code[1128]=2974; //p1
    code[1117]=886; //invocationTemp_4

    code[1178]=2262; //ExpressionStatement_17 # ExpressionStatement_17
    code[1197]=538; //r
    code[1165]=538; //r
    code[1188]=1855; //"["
    code[1162]=2974; //p1
    code[1185]=12; //"]"

    code[1249]=1132; //ExpressionStatement_18 # ExpressionStatement_18
    code[1274]=2610; //memberTemp_1
    code[1262]=538; //r

    code[1304]=1510; //ExpressionStatement_19 # ExpressionStatement_19
    code[1319]=843; //sum
    code[1289]=843; //sum
    code[1323]=2610; //memberTemp_1

    code[1363]=1164; //ExpressionStatement_20 # ExpressionStatement_20
    code[1380]=1098; //dst
    code[1351]=1812; //var_forIndex_0
    code[1356]=843; //sum

    code[1427]=6641; //ExpressionStatement_21 # ExpressionStatement_21
    code[1432]=1812; //var_forIndex_0
    code[1447]=1812; //var_forIndex_0
    code[1441]=997; //1

    code[1485]=1335; //ExpressionStatement_22 # ExpressionStatement_22
    code[1476]=3051; //var_whileCondition_0
    code[1479]=1812; //var_forIndex_0
    code[1475]=1828; //b

    code[1542]=7415; //ExpressionStatement_23 # ExpressionStatement_23
    code[1527]=645; //while_FalseBlockSkip_645

    code[1606]=8314; //ExpressionStatement_24 # ExpressionStatement_24
    code[1604]=1104; //memberTemp_2
    code[1591]=1098; //dst

    code[1677]=1849; //ExpressionStatement_25 # ExpressionStatement_25
    code[1680]=843; //sum
    code[1664]=843; //sum
    code[1705]=365; //"#"
    code[1685]=1104; //memberTemp_2

    code[1749]=4449; //ReturnStatement_26 # ReturnStatement_26
    code[1754]=843; //sum

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_2835_2_op4_in3(vpc, data, code);

}

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
private string ForSimple_Array_obfuscated2_op4_in4(int b)
{
    //Virtualization variables
    int[] code = new int[100668];
    object[] data = new object[4842];
    int vpc = 109;

    //Data init
    data[3129]=b; //b 
    data[3526]="" ; //"" constant
    data[232]=3 ; //3 constant
    data[1156]=4 ; //4 constant
    data[1441]=1; //1 constant
    data[98]=0; //0 constant
    data[916]="_" ; //"_" constant
    data[1115]="~"; //"~" constant
    data[3865]="#"; //"#" constant
    data[2343]="[" ; //"[" constant
    data[214]="]"; //"]" constant
    data[1618]=1426291964; //sum 
    data[1644]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_0 
    data[3052]=-993; //memberTemp_0 
    data[3078]=2075095712; //invocationTemp_1 
    data[3838]=637460966; //r 
    data[366]=(string[])null; //dst 
    data[1894]=-437; //var_forIndex_0 
    data[657]=false; //var_whileCondition_0 
    data[2515]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_2 
    data[1239]=(double)0.271554201036484; //p1 
    data[2482]=58; //memberTemp_1 
    data[1821]=-897; //memberTemp_2 
    data[606]=-583; //jmpWhileDestinationName_606 constant
    data[2817]=68; //while_GoTo_True_2817 constant
    data[2185]=774; //while_GoTo_False_2185 constant
    data[2377]=-774; //while_FalseBlockSkip_2377 constant

    //Code init

    code[109]=7526; //ExpressionStatement_0 # ExpressionStatement_0
    code[114]=1618; //sum
    code[118]=3526; //""
    code[96]=232; //3
    code[128]=1156; //4
    code[138]=3526; //""

    code[172]=6090; //ExpressionStatement_1 # ExpressionStatement_1
    code[155]=1644; //invocationTemp_0

    code[230]=2933; //ExpressionStatement_2 # ExpressionStatement_2
    code[255]=3052; //memberTemp_0
    code[213]=1644; //invocationTemp_0

    code[290]=9729; //ExpressionStatement_3 # ExpressionStatement_3
    code[286]=3078; //invocationTemp_1
    code[294]=3052; //memberTemp_0
    code[287]=1441; //1

    code[355]=6453; //ExpressionStatement_4 # ExpressionStatement_4
    code[368]=1618; //sum
    code[384]=1618; //sum
    code[343]=3078; //invocationTemp_1

    code[420]=2506; //ExpressionStatement_5 # ExpressionStatement_5
    code[425]=3838; //r
    code[414]=3526; //""

    code[484]=7925; //ExpressionStatement_6 # ExpressionStatement_6
    code[485]=366; //dst
    code[476]=3129; //b

    code[543]=2506; //ExpressionStatement_5 # ExpressionStatement_7
    code[548]=1894; //var_forIndex_0
    code[537]=98; //0

    code[607]=7895; //ExpressionStatement_8 # ExpressionStatement_8
    code[606]=657; //var_whileCondition_0
    code[624]=1894; //var_forIndex_0
    code[631]=3129; //b

    code[661]=4422; //WhileStatementSyntax_9 # WhileStatementSyntax_9
    code[650]=606; //jmpWhileDestinationName_606
    code[675]=657; //var_whileCondition_0
    code[660]=2817; //while_GoTo_True_2817
    code[687]=2185; //while_GoTo_False_2185

    code[729]=8517; //ExpressionStatement_10 # ExpressionStatement_10
    code[728]=1618; //sum
    code[745]=1618; //sum
    code[736]=916; //"_"
    code[732]=1894; //var_forIndex_0
    code[741]=916; //"_"

    code[789]=6453; //ExpressionStatement_4 # ExpressionStatement_11
    code[802]=1618; //sum
    code[818]=1618; //sum
    code[777]=1115; //"~"

    code[854]=9232; //ExpressionStatement_12 # ExpressionStatement_12
    code[875]=3838; //r
    code[862]=3838; //r
    code[855]=1618; //sum
    code[882]=3865; //"#"

    code[909]=6090; //ExpressionStatement_1 # ExpressionStatement_13
    code[892]=2515; //invocationTemp_2

    code[967]=2924; //ExpressionStatement_14 # ExpressionStatement_14
    code[952]=1239; //p1
    code[969]=2515; //invocationTemp_2

    code[1024]=5044; //ExpressionStatement_15 # ExpressionStatement_15
    code[1020]=3838; //r
    code[1049]=3838; //r
    code[1047]=2343; //"["
    code[1034]=1239; //p1
    code[1037]=214; //"]"

    code[1097]=1624; //ExpressionStatement_16 # ExpressionStatement_16
    code[1088]=2482; //memberTemp_1
    code[1123]=3838; //r

    code[1150]=9963; //ExpressionStatement_17 # ExpressionStatement_17
    code[1172]=1618; //sum
    code[1176]=1618; //sum
    code[1130]=2482; //memberTemp_1

    code[1203]=2516; //ExpressionStatement_18 # ExpressionStatement_18
    code[1223]=366; //dst
    code[1214]=1894; //var_forIndex_0
    code[1201]=1618; //sum

    code[1270]=5643; //ExpressionStatement_19 # ExpressionStatement_19
    code[1277]=1894; //var_forIndex_0
    code[1267]=1894; //var_forIndex_0
    code[1298]=1441; //1

    code[1326]=7895; //ExpressionStatement_8 # ExpressionStatement_20
    code[1325]=657; //var_whileCondition_0
    code[1343]=1894; //var_forIndex_0
    code[1350]=3129; //b

    code[1380]=4453; //ExpressionStatement_21 # ExpressionStatement_21
    code[1407]=2377; //while_FalseBlockSkip_2377

    code[1435]=6071; //ExpressionStatement_22 # ExpressionStatement_22
    code[1416]=1821; //memberTemp_2
    code[1458]=366; //dst

    code[1497]=8607; //ExpressionStatement_23 # ExpressionStatement_23
    code[1507]=1618; //sum
    code[1508]=1618; //sum
    code[1509]=3865; //"#"
    code[1525]=1821; //memberTemp_2

    code[1551]=4043; //ReturnStatement_24 # ReturnStatement_24
    code[1543]=1618; //sum

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_1236_2_op4_in4(vpc, data, code);

}

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
private string ForSimple_Array_obfuscated2_op4_in5(int b)
{
    //Virtualization variables
    int[] code = new int[100962];
    object[] data = new object[4842];
    int vpc = 78;

    //Data init
    data[791]=b; //b 
    data[1679]="" ; //"" constant
    data[1079]=3 ; //3 constant
    data[1920]=4 ; //4 constant
    data[2222]=1; //1 constant
    data[2050]=0; //0 constant
    data[86]="_" ; //"_" constant
    data[2934]="~"; //"~" constant
    data[454]="#"; //"#" constant
    data[520]="[" ; //"[" constant
    data[2332]="]"; //"]" constant
    data[2431]=1952909025; //sum 
    data[3295]=875; //memberTemp_0 
    data[2]=(ConsoleCalculator.Piston)null; //invocationTemp_0 
    data[143]=1466123585; //r 
    data[3578]=(string[])null; //dst 
    data[3783]=243; //var_forIndex_0 
    data[3158]=false; //var_whileCondition_0 
    data[3947]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
    data[2276]=(double)0.0422941758494331; //p1 
    data[3987]=177; //memberTemp_1 
    data[1571]=-447; //memberTemp_2 
    data[2621]=-925; //jmpWhileDestinationName_2621 constant
    data[80]=57; //while_GoTo_True_80 constant
    data[237]=777; //while_GoTo_False_237 constant
    data[82]=-777; //while_FalseBlockSkip_82 constant

    //Code init

    code[78]=5734; //ExpressionStatement_0 # ExpressionStatement_0
    code[65]=2431; //sum
    code[87]=1679; //""
    code[91]=1079; //3
    code[69]=1920; //4
    code[83]=1679; //""

    code[149]=6978; //ExpressionStatement_1 # ExpressionStatement_1
    code[177]=3295; //memberTemp_0

    code[216]=1116; //ExpressionStatement_2 # ExpressionStatement_2
    code[241]=2; //invocationTemp_0
    code[208]=3295; //memberTemp_0
    code[213]=2222; //1

    code[275]=5692; //ExpressionStatement_3 # ExpressionStatement_3
    code[296]=2431; //sum
    code[297]=2431; //sum
    code[261]=2; //invocationTemp_0

    code[345]=9041; //ExpressionStatement_4 # ExpressionStatement_4
    code[365]=143; //r
    code[350]=1679; //""

    code[398]=8243; //ExpressionStatement_5 # ExpressionStatement_5
    code[393]=3578; //dst
    code[409]=791; //b

    code[466]=9041; //ExpressionStatement_4 # ExpressionStatement_6
    code[486]=3783; //var_forIndex_0
    code[471]=2050; //0

    code[519]=8931; //ExpressionStatement_7 # ExpressionStatement_7
    code[521]=3158; //var_whileCondition_0
    code[544]=3783; //var_forIndex_0
    code[502]=791; //b

    code[575]=2437; //WhileStatementSyntax_8 # WhileStatementSyntax_8
    code[601]=2621; //jmpWhileDestinationName_2621
    code[558]=3158; //var_whileCondition_0
    code[577]=80; //while_GoTo_True_80
    code[571]=237; //while_GoTo_False_237

    code[632]=7138; //ExpressionStatement_9 # ExpressionStatement_9
    code[635]=2431; //sum
    code[646]=2431; //sum
    code[642]=86; //"_"
    code[653]=3783; //var_forIndex_0
    code[640]=86; //"_"

    code[700]=1317; //ExpressionStatement_10 # ExpressionStatement_10
    code[713]=2431; //sum
    code[698]=2431; //sum
    code[695]=2934; //"~"

    code[755]=4256; //ExpressionStatement_11 # ExpressionStatement_11
    code[781]=143; //r
    code[765]=143; //r
    code[775]=2431; //sum
    code[748]=454; //"#"

    code[812]=9664; //ExpressionStatement_12 # ExpressionStatement_12
    code[840]=3947; //invocationTemp_1

    code[875]=9597; //ExpressionStatement_13 # ExpressionStatement_13
    code[863]=2276; //p1
    code[899]=3947; //invocationTemp_1

    code[941]=8019; //ExpressionStatement_14 # ExpressionStatement_14
    code[951]=143; //r
    code[938]=143; //r
    code[921]=520; //"["
    code[942]=2276; //p1
    code[944]=2332; //"]"

    code[1000]=1733; //ExpressionStatement_15 # ExpressionStatement_15
    code[1029]=3987; //memberTemp_1
    code[981]=143; //r

    code[1059]=9444; //ExpressionStatement_16 # ExpressionStatement_16
    code[1066]=2431; //sum
    code[1045]=2431; //sum
    code[1081]=3987; //memberTemp_1

    code[1117]=5180; //ExpressionStatement_17 # ExpressionStatement_17
    code[1119]=3578; //dst
    code[1110]=3783; //var_forIndex_0
    code[1134]=2431; //sum

    code[1171]=7576; //ExpressionStatement_18 # ExpressionStatement_18
    code[1186]=3783; //var_forIndex_0
    code[1174]=3783; //var_forIndex_0
    code[1194]=2222; //1

    code[1240]=8931; //ExpressionStatement_7 # ExpressionStatement_19
    code[1242]=3158; //var_whileCondition_0
    code[1265]=3783; //var_forIndex_0
    code[1223]=791; //b

    code[1296]=3168; //ExpressionStatement_20 # ExpressionStatement_20
    code[1293]=82; //while_FalseBlockSkip_82

    code[1352]=9680; //ExpressionStatement_21 # ExpressionStatement_21
    code[1379]=1571; //memberTemp_2
    code[1368]=3578; //dst

    code[1408]=5821; //ExpressionStatement_22 # ExpressionStatement_22
    code[1402]=2431; //sum
    code[1420]=2431; //sum
    code[1429]=454; //"#"
    code[1421]=1571; //memberTemp_2

    code[1470]=6137; //ReturnStatement_23 # ReturnStatement_23
    code[1494]=2431; //sum

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_2145_2_op4_in5(vpc, data, code);

}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
        private string ForSimple_Array_readable(int b)
{
    //Virtualization variables
    int[] code = new int[100462];
    object[] data = new object[4563];
    int vpc = 108;

    //Data init
    data[3388]=b; //b 
    data[1348]="" ; //"" constant
    data[2643]=3; //3 constant
    data[982]=4; //4 constant
    data[1360]="[" ; //"[" constant
    data[3127]="]"; //"]" constant
    data[590]=1; //1 constant
    data[14]=0; //0 constant
    data[557]="_" ; //"_" constant
    data[1329]="~"; //"~" constant
    data[560]="#"; //"#" constant
    data[1157]=703884116; //addTemp_0 
    data[2839]=1869989102; //addTemp_1 
    data[3083]=713491713; //sum 
    data[2171]=(ConsoleCalculator.Engine)null; //invocationTemp_0 
    data[2052]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
    data[2124]=(ConsoleCalculator.Piston)null; //invocationTemp_2 
    data[97]=(double)0.538888361555938; //p1 
    data[2671]=930355603; //addTemp_2 
    data[2586]=760493095; //addTemp_3 
    data[2841]=(ConsoleCalculator.Engine)null; //invocationTemp_3 
    data[2187]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_4 
    data[1571]=-878; //memberTemp_0 
    data[3909]=-386; //addTemp_4 
    data[2611]=(ConsoleCalculator.Engine)null; //invocationTemp_5 
    data[3024]=(ConsoleCalculator.Piston)null; //invocationTemp_6 
    data[2482]=7139119; //invocationTemp_7 
    data[1568]=1148463105; //r 
    data[1638]=(string[])null; //dst 
    data[3108]=-620; //var_forIndex_0 
    data[3627]=-914; //invocationTemp_8 
    data[2032]=false; //var_whileCondition_0 
    data[1021]=970472653; //addTemp_5 
    data[3983]=200065001; //addTemp_6 
    data[2379]=450012801; //addTemp_7 
    data[3062]=-723; //invocationTemp_9 
    data[1492]=696; //memberTemp_1 
    data[2678]=1746629152; //addTemp_8 
    data[1161]=874; //fake-1161 
    data[3035]=664; //fake-3035 
    data[2370]=322; //fake-2370 
    data[2374]=-347; //fake-2374 
    data[1817]=-509; //fake-1817 
    data[631]=574; //fake-631 
    data[583]=725; //fake-583 
    data[2401]=250; //fake-2401 
    data[2601]=98; //fake-2601 
    data[3188]=-900; //fake-3188 
    data[3418]=527; //fake-3418 
    data[2202]=-55; //fake-2202 
    data[680]=894; //fake-680 
    data[3265]=456; //fake-3265 
    data[231]=484; //fake-231 
    data[705]=-434; //fake-705 
    data[545]=491; //fake-545 
    data[2718]=810; //fake-2718 
    data[2217]=-158; //fake-2217 
    data[3922]=634; //fake-3922 
    data[3101]=-331; //fake-3101 
    data[503]=780; //fake-503 
    data[2880]=-630; //fake-2880 
    data[1128]=-894; //fake-1128 
    data[659]=-911; //fake-659 
    data[2791]=-477; //fake-2791 
    data[82]=236; //fake-82 
    data[2766]=257; //fake-2766 
    data[3273]=960; //fake-3273 
    data[1495]=-426; //fake-1495 
    data[3692]=-818; //fake-3692 
    data[155]=224; //fake-155 
    data[663]=-384; //fake-663 
    data[360]=439; //fake-360 
    data[1951]=-617; //fake-1951 
    data[849]=921; //fake-849 
    data[1185]=770; //fake-1185 
    data[3163]=-998; //fake-3163 
    data[2431]=250; //fake-2431 
    data[1734]=89; //fake-1734 
    data[1421]=351; //fake-1421 
    data[3317]=615; //fake-3317 
    data[1371]=609; //fake-1371 
    data[595]=-979; //fake-595 
    data[3560]=86; //fake-3560 
    data[558]=61; //fake-558 
    data[1051]=174; //fake-1051 
    data[1653]=-77; //fake-1653 
    data[444]=-399; //fake-444 
    data[863]=-663; //fake-863 
    data[3157]=-306; //fake-3157 
    data[120]=-392; //fake-120 
    data[3112]=434; //fake-3112 
    data[274]=-938; //fake-274 
    data[1730]=-43; //fake-1730 
    data[509]=-906; //fake-509 
    data[1718]=294; //fake-1718 
    data[1912]=216; //fake-1912 
    data[1968]=-437; //fake-1968 
    data[3330]=967; //fake-3330 
    data[1634]=-662; //fake-1634 
    data[2764]=-532; //fake-2764 
    data[1473]=290; //fake-1473 
    data[603]=-477; //fake-603 
    data[1757]=918; //fake-1757 
    data[2174]=-697; //fake-2174 
    data[3571]=-672; //fake-3571 
    data[1978]=-545; //fake-1978 
    data[499]=73; //fake-499 
    data[3802]=562; //fake-3802 
    data[1243]=-205; //fake-1243 
    data[3596]=489; //fake-3596 
    data[3340]=-440; //fake-3340 
    data[1900]=752; //fake-1900 
    data[378]=-718; //fake-378 
    data[3500]=53; //fake-3500 
    data[3946]=-829; //fake-3946 
    data[3875]=-651; //fake-3875 
    data[1505]=19; //fake-1505 
    data[2452]=28; //jmpWhileDestinationName_2452 constant
    data[2978]=73; //while_GoTo_True_2978 constant
    data[1077]=799; //while_GoTo_False_1077 constant
    data[3246]=-799; //while_FalseBlockSkip_3246 constant
    data[1613]=349; //fake-1613 
    data[1605]=-688; //fake-1605 
    data[3698]=-344; //fake-3698 
    data[3834]=623; //fake-3834 
    data[2051]=880; //fake-2051 
    data[3045]=574; //fake-3045 
    data[3719]=789; //fake-3719 
    data[905]=-446; //fake-905 
    data[1344]=-518; //fake-1344 
    data[3052]=-711; //fake-3052 
    data[3189]=-373; //fake-3189 
    data[2819]=-446; //fake-2819 
    data[1195]=438; //fake-1195 
    data[559]=283; //fake-559 
    data[2325]=-249; //fake-2325 
    data[1090]=-117; //fake-1090 
    data[902]=-675; //fake-902 
    data[1447]=85; //fake-1447 
    data[2441]=-898; //fake-2441 
    data[801]=-218; //fake-801 
    data[203]=-267; //fake-203 
    data[1870]=-281; //fake-1870 
    data[6]=850; //fake-6 
    data[3670]=38; //fake-3670 
    data[101]=541; //fake-101 
    data[333]=204; //fake-333 
    data[3078]=-953; //fake-3078 
    data[720]=682; //fake-720 
    data[2132]=779; //fake-2132 
    data[1470]=903; //fake-1470 
    data[1860]=922; //fake-1860 
    data[3878]=-56; //fake-3878 
    data[3454]=-804; //fake-3454 
    data[3110]=535; //fake-3110 
    data[1809]=-383; //fake-1809 
    data[3026]=-975; //fake-3026 
    data[585]=812; //fake-585 
    data[2831]=667; //fake-2831 
    data[3976]=-357; //fake-3976 
    data[1583]=-656; //fake-1583 
    data[3592]=-486; //fake-3592 
    data[3700]=773; //fake-3700 
    data[1381]=973; //fake-1381 
    data[3301]=-217; //fake-3301 
    data[623]=-66; //fake-623 
    data[3132]=-760; //fake-3132 
    data[394]=-949; //fake-394 
    data[700]=277; //fake-700 
    data[729]=1; //fake-729 
    data[2648]=399; //fake-2648 
    data[2281]=-272; //fake-2281 
    data[342]=85; //fake-342 
    data[2750]=-754; //fake-2750 
    data[1875]=-764; //fake-1875 
    data[3143]=-705; //fake-3143 
    data[2593]=-370; //fake-2593 
    data[3892]=-538; //fake-3892 
    data[2903]=617; //fake-2903 
    data[619]=-919; //fake-619 
    data[3047]=-325; //fake-3047 
    data[320]=526; //fake-320 
    data[3114]=-893; //fake-3114 
    data[3810]=-225; //fake-3810 
    data[3695]=-422; //fake-3695 
    data[266]=-634; //fake-266 

    //Code init

    code[108]=7385; //ExpressionStatement_0 # ExpressionStatement_0
    code[131]=1157; //addTemp_0
    code[90]=1348; //""
    code[119]=2643; //3
    code[135]=2262; //fake-ExpressionStatement_0_2262_27
    code[130]=3527; //fake-ExpressionStatement_0_3527_22
    code[122]=3776; //fake-ExpressionStatement_0_3776_14
    code[125]=644; //fake-ExpressionStatement_0_644_17

    code[169]=7385; //ExpressionStatement_0 # ExpressionStatement_1
    code[192]=2839; //addTemp_1
    code[151]=1157; //addTemp_0
    code[180]=982; //4
    code[188]=931; //fake-ExpressionStatement_0_931_19
    code[186]=3791; //fake-ExpressionStatement_0_3791_17
    code[158]=3128; //fake-ExpressionStatement_0_3128_-11
    code[154]=3893; //fake-ExpressionStatement_0_3893_-15

    code[230]=2244; //ExpressionStatement_2 # ExpressionStatement_2
    code[232]=3083; //sum
    code[234]=2839; //addTemp_1
    code[250]=1348; //""
    code[244]=2653; //fake-ExpressionStatement_2_2653_14

    code[299]=8024; //ExpressionStatement_3 # ExpressionStatement_3
    code[315]=2171; //invocationTemp_0
    code[296]=3882; //fake-ExpressionStatement_3_3882_-3
    code[287]=1085; //fake-ExpressionStatement_3_1085_-12
    code[285]=847; //fake-ExpressionStatement_3_847_-14

    code[351]=6946; //ExpressionStatement_4 # ExpressionStatement_4
    code[354]=2052; //invocationTemp_1
    code[379]=2171; //invocationTemp_0
    code[353]=3968; //fake-ExpressionStatement_4_3968_2
    code[374]=572; //fake-ExpressionStatement_4_572_23

    code[415]=2058; //ExpressionStatement_5 # ExpressionStatement_5
    code[398]=2124; //invocationTemp_2
    code[409]=2052; //invocationTemp_1
    code[408]=1509; //fake-ExpressionStatement_5_1509_-7
    code[419]=700; //fake-ExpressionStatement_5_700_4
    code[442]=1315; //fake-ExpressionStatement_5_1315_27

    code[486]=3148; //ExpressionStatement_6 # ExpressionStatement_6
    code[478]=97; //p1
    code[512]=2124; //invocationTemp_2
    code[477]=3533; //fake-ExpressionStatement_6_3533_-9
    code[497]=3152; //fake-ExpressionStatement_6_3152_11
    code[489]=3309; //fake-ExpressionStatement_6_3309_3
    code[476]=614; //fake-ExpressionStatement_6_614_-10

    code[545]=5921; //ExpressionStatement_7 # ExpressionStatement_7
    code[539]=2671; //addTemp_2
    code[527]=1360; //"["
    code[534]=97; //p1
    code[564]=3890; //fake-ExpressionStatement_7_3890_19
    code[526]=1975; //fake-ExpressionStatement_7_1975_-19
    code[553]=2081; //fake-ExpressionStatement_7_2081_8

    code[613]=9919; //ExpressionStatement_2 # ExpressionStatement_8
    code[615]=2586; //addTemp_3
    code[617]=2671; //addTemp_2
    code[633]=3127; //"]"
    code[623]=3384; //fake-ExpressionStatement_2_3384_10
    code[618]=2543; //fake-ExpressionStatement_2_2543_5
    code[602]=69; //fake-ExpressionStatement_2_69_-11

    code[682]=9919; //ExpressionStatement_2 # ExpressionStatement_9
    code[684]=3083; //sum
    code[686]=3083; //sum
    code[702]=2586; //addTemp_3
    code[706]=1442; //fake-ExpressionStatement_2_1442_24
    code[706]=3889; //fake-ExpressionStatement_2_3889_24
    code[706]=1039; //fake-ExpressionStatement_2_1039_24

    code[751]=8024; //ExpressionStatement_3 # ExpressionStatement_10
    code[767]=2841; //invocationTemp_3
    code[733]=2082; //fake-ExpressionStatement_3_2082_-18
    code[738]=1675; //fake-ExpressionStatement_3_1675_-13

    code[803]=6946; //ExpressionStatement_4 # ExpressionStatement_11
    code[806]=2187; //invocationTemp_4
    code[831]=2841; //invocationTemp_3
    code[802]=2809; //fake-ExpressionStatement_4_2809_-1
    code[807]=2152; //fake-ExpressionStatement_4_2152_4
    code[788]=2394; //fake-ExpressionStatement_4_2394_-15
    code[824]=2690; //fake-ExpressionStatement_4_2690_21
    code[802]=2356; //fake-ExpressionStatement_4_2356_-1
    code[819]=2344; //fake-ExpressionStatement_4_2344_16

    code[867]=5475; //ExpressionStatement_12 # ExpressionStatement_12
    code[878]=1571; //memberTemp_0
    code[868]=2187; //invocationTemp_4
    code[890]=3105; //fake-ExpressionStatement_12_3105_23
    code[862]=744; //fake-ExpressionStatement_12_744_-5
    code[863]=1381; //fake-ExpressionStatement_12_1381_-4

    code[938]=3579; //ExpressionStatement_13 # ExpressionStatement_13
    code[949]=3909; //addTemp_4
    code[937]=1571; //memberTemp_0
    code[960]=590; //1
    code[919]=2842; //fake-ExpressionStatement_13_2842_-19
    code[943]=2969; //fake-ExpressionStatement_13_2969_5
    code[953]=2363; //fake-ExpressionStatement_13_2363_15
    code[951]=3384; //fake-ExpressionStatement_13_3384_13
    code[935]=953; //fake-ExpressionStatement_13_953_-3

    code[996]=8024; //ExpressionStatement_3 # ExpressionStatement_14
    code[1012]=2611; //invocationTemp_5
    code[1000]=3609; //fake-ExpressionStatement_3_3609_4

    code[1048]=9676; //ExpressionStatement_15 # ExpressionStatement_15
    code[1042]=3024; //invocationTemp_6
    code[1050]=2611; //invocationTemp_5
    code[1054]=3909; //addTemp_4
    code[1034]=424; //fake-ExpressionStatement_15_424_-14
    code[1075]=135; //fake-ExpressionStatement_15_135_27
    code[1032]=393; //fake-ExpressionStatement_15_393_-16
    code[1036]=2926; //fake-ExpressionStatement_15_2926_-12
    code[1051]=2758; //fake-ExpressionStatement_15_2758_3

    code[1106]=3262; //ExpressionStatement_16 # ExpressionStatement_16
    code[1115]=2482; //invocationTemp_7
    code[1126]=3024; //invocationTemp_6
    code[1121]=2266; //fake-ExpressionStatement_16_2266_15
    code[1112]=243; //fake-ExpressionStatement_16_243_6
    code[1107]=170; //fake-ExpressionStatement_16_170_1
    code[1129]=3425; //fake-ExpressionStatement_16_3425_23
    code[1093]=164; //fake-ExpressionStatement_16_164_-13

    code[1170]=9919; //ExpressionStatement_2 # ExpressionStatement_17
    code[1172]=3083; //sum
    code[1174]=3083; //sum
    code[1190]=2482; //invocationTemp_7
    code[1163]=342; //fake-ExpressionStatement_2_342_-7
    code[1199]=3471; //fake-ExpressionStatement_2_3471_29
    code[1176]=3418; //fake-ExpressionStatement_2_3418_6
    code[1169]=1958; //fake-ExpressionStatement_2_1958_-1
    code[1151]=3448; //fake-ExpressionStatement_2_3448_-19
    code[1156]=3425; //fake-ExpressionStatement_2_3425_-14

    code[1239]=7635; //ExpressionStatement_18 # ExpressionStatement_18
    code[1248]=1568; //r
    code[1264]=1348; //""
    code[1241]=840; //fake-ExpressionStatement_18_840_2
    code[1243]=3153; //fake-ExpressionStatement_18_3153_4
    code[1228]=2609; //fake-ExpressionStatement_18_2609_-11
    code[1228]=1336; //fake-ExpressionStatement_18_1336_-11
    code[1237]=187; //fake-ExpressionStatement_18_187_-2
    code[1227]=1368; //fake-ExpressionStatement_18_1368_-12
    code[1263]=2132; //fake-ExpressionStatement_18_2132_24
    code[1261]=1699; //fake-ExpressionStatement_18_1699_22

    code[1302]=6304; //ExpressionStatement_19 # ExpressionStatement_19
    code[1314]=1638; //dst
    code[1285]=3388; //b
    code[1317]=1124; //fake-ExpressionStatement_19_1124_15
    code[1292]=1260; //fake-ExpressionStatement_19_1260_-10

    code[1358]=7635; //ExpressionStatement_18 # ExpressionStatement_20
    code[1367]=3108; //var_forIndex_0
    code[1383]=14; //0
    code[1385]=2089; //fake-ExpressionStatement_18_2089_27
    code[1347]=2761; //fake-ExpressionStatement_18_2761_-11

    code[1421]=9872; //ExpressionStatement_21 # ExpressionStatement_21
    code[1417]=3627; //invocationTemp_8
    code[1405]=3388; //b
    code[1428]=2119; //fake-ExpressionStatement_21_2119_7
    code[1408]=3526; //fake-ExpressionStatement_21_3526_-13

    code[1473]=5888; //ExpressionStatement_22 # ExpressionStatement_22
    code[1498]=2032; //var_whileCondition_0
    code[1491]=3108; //var_forIndex_0
    code[1486]=3627; //invocationTemp_8
    code[1454]=2997; //fake-ExpressionStatement_22_2997_-19
    code[1475]=2363; //fake-ExpressionStatement_22_2363_2

    code[1542]=4774; //WhileStatementSyntax_23 # WhileStatementSyntax_23
    code[1528]=2452; //jmpWhileDestinationName_2452
    code[1529]=2032; //var_whileCondition_0
    code[1536]=2978; //while_GoTo_True_2978
    code[1533]=1077; //while_GoTo_False_1077
    code[1538]=2733; //fake-fake-whileVirtualOperation_2733_-4
    code[1535]=1731; //fake-fake-whileVirtualOperation_1731_-7
    code[1532]=1930; //fake-fake-whileVirtualOperation_1930_-10

    code[1615]=7385; //ExpressionStatement_0 # ExpressionStatement_24
    code[1638]=1021; //addTemp_5
    code[1597]=557; //"_"
    code[1626]=3108; //var_forIndex_0
    code[1616]=1697; //fake-ExpressionStatement_0_1697_1
    code[1599]=3980; //fake-ExpressionStatement_0_3980_-16
    code[1621]=2623; //fake-ExpressionStatement_0_2623_6
    code[1616]=1996; //fake-ExpressionStatement_0_1996_1

    code[1676]=9919; //ExpressionStatement_2 # ExpressionStatement_25
    code[1678]=3983; //addTemp_6
    code[1680]=1021; //addTemp_5
    code[1696]=557; //"_"
    code[1687]=3284; //fake-ExpressionStatement_2_3284_11
    code[1701]=501; //fake-ExpressionStatement_2_501_25
    code[1700]=2324; //fake-ExpressionStatement_2_2324_24

    code[1745]=9919; //ExpressionStatement_2 # ExpressionStatement_26
    code[1747]=3083; //sum
    code[1749]=3083; //sum
    code[1765]=3983; //addTemp_6
    code[1767]=2302; //fake-ExpressionStatement_2_2302_22
    code[1753]=2347; //fake-ExpressionStatement_2_2347_8
    code[1773]=1486; //fake-ExpressionStatement_2_1486_28
    code[1754]=923; //fake-ExpressionStatement_2_923_9
    code[1752]=1072; //fake-ExpressionStatement_2_1072_7

    code[1814]=9919; //ExpressionStatement_2 # ExpressionStatement_27
    code[1816]=3083; //sum
    code[1818]=3083; //sum
    code[1834]=1329; //"~"
    code[1836]=1195; //fake-ExpressionStatement_2_1195_22
    code[1803]=3010; //fake-ExpressionStatement_2_3010_-11
    code[1817]=2029; //fake-ExpressionStatement_2_2029_3
    code[1827]=1395; //fake-ExpressionStatement_2_1395_13

    code[1883]=9919; //ExpressionStatement_2 # ExpressionStatement_28
    code[1885]=2379; //addTemp_7
    code[1887]=3083; //sum
    code[1903]=560; //"#"
    code[1898]=1984; //fake-ExpressionStatement_2_1984_15
    code[1909]=2150; //fake-ExpressionStatement_2_2150_26
    code[1871]=1677; //fake-ExpressionStatement_2_1677_-12
    code[1881]=1515; //fake-ExpressionStatement_2_1515_-2

    code[1952]=9919; //ExpressionStatement_2 # ExpressionStatement_29
    code[1954]=1568; //r
    code[1956]=1568; //r
    code[1972]=2379; //addTemp_7
    code[1933]=1531; //fake-ExpressionStatement_2_1531_-19
    code[1975]=576; //fake-ExpressionStatement_2_576_23

    code[2021]=2635; //ExpressionStatement_30 # ExpressionStatement_30
    code[2045]=1638; //dst
    code[2047]=3108; //var_forIndex_0
    code[2027]=3083; //sum
    code[2003]=3584; //fake-ExpressionStatement_30_3584_-18
    code[2039]=1189; //fake-ExpressionStatement_30_1189_18
    code[2017]=276; //fake-ExpressionStatement_30_276_-4

    code[2084]=9059; //ExpressionStatement_31 # ExpressionStatement_31
    code[2068]=3108; //var_forIndex_0
    code[2074]=3108; //var_forIndex_0
    code[2098]=590; //1
    code[2108]=468; //fake-ExpressionStatement_31_468_24
    code[2091]=2732; //fake-ExpressionStatement_31_2732_7
    code[2103]=280; //fake-ExpressionStatement_31_280_19
    code[2076]=2149; //fake-ExpressionStatement_31_2149_-8
    code[2080]=2916; //fake-ExpressionStatement_31_2916_-4
    code[2103]=2880; //fake-ExpressionStatement_31_2880_19

    code[2154]=9872; //ExpressionStatement_21 # ExpressionStatement_32
    code[2150]=3062; //invocationTemp_9
    code[2138]=3388; //b
    code[2139]=1917; //fake-ExpressionStatement_21_1917_-15
    code[2182]=130; //fake-ExpressionStatement_21_130_28
    code[2165]=3223; //fake-ExpressionStatement_21_3223_11
    code[2156]=1485; //fake-ExpressionStatement_21_1485_2
    code[2139]=2763; //fake-ExpressionStatement_21_2763_-15

    code[2206]=5888; //ExpressionStatement_22 # ExpressionStatement_33
    code[2231]=2032; //var_whileCondition_0
    code[2224]=3108; //var_forIndex_0
    code[2219]=3062; //invocationTemp_9
    code[2213]=3127; //fake-ExpressionStatement_22_3127_7
    code[2228]=3080; //fake-ExpressionStatement_22_3080_22
    code[2207]=1293; //fake-ExpressionStatement_22_1293_1
    code[2208]=815; //fake-ExpressionStatement_22_815_2

    code[2275]=5359; //ExpressionStatement_34 # ExpressionStatement_34
    code[2265]=3246; //while_FalseBlockSkip_3246
    code[2276]=3946; //fake-ExpressionStatement_34_3946_1
    code[2302]=616; //fake-ExpressionStatement_34_616_27
    code[2260]=3270; //fake-ExpressionStatement_34_3270_-15

    code[2341]=2506; //ExpressionStatement_35 # ExpressionStatement_35
    code[2323]=1492; //memberTemp_1
    code[2344]=1638; //dst
    code[2348]=1415; //fake-ExpressionStatement_35_1415_7
    code[2353]=1378; //fake-ExpressionStatement_35_1378_12
    code[2366]=3269; //fake-ExpressionStatement_35_3269_25
    code[2324]=882; //fake-ExpressionStatement_35_882_-17
    code[2326]=2080; //fake-ExpressionStatement_35_2080_-15
    code[2346]=205; //fake-ExpressionStatement_35_205_5
    code[2368]=187; //fake-ExpressionStatement_35_187_27

    code[2393]=7385; //ExpressionStatement_0 # ExpressionStatement_36
    code[2416]=2678; //addTemp_8
    code[2375]=560; //"#"
    code[2404]=1492; //memberTemp_1
    code[2419]=3140; //fake-ExpressionStatement_0_3140_26
    code[2422]=3584; //fake-ExpressionStatement_0_3584_29
    code[2422]=3497; //fake-ExpressionStatement_0_3497_29
    code[2383]=1777; //fake-ExpressionStatement_0_1777_-10

    code[2454]=9919; //ExpressionStatement_2 # ExpressionStatement_37
    code[2456]=3083; //sum
    code[2458]=3083; //sum
    code[2474]=2678; //addTemp_8
    code[2440]=525; //fake-ExpressionStatement_2_525_-14
    code[2477]=3590; //fake-ExpressionStatement_2_3590_23
    code[2444]=1841; //fake-ExpressionStatement_2_1841_-10
    code[2483]=3849; //fake-ExpressionStatement_2_3849_29

    code[2523]=9957; //ReturnStatement_38 # ReturnStatement_38
    code[2525]=3083; //sum
    code[2546]=350; //fake-ReturnStatement_38_350_23
    code[2522]=446; //fake-ReturnStatement_38_446_-1
    code[2546]=235; //fake-ReturnStatement_38_235_23
    code[2530]=2769; //fake-ReturnStatement_38_2769_7

    while(true)
    {
    	switch(code[vpc])
    	{
    		case 3579: //frequency 1 ExpressionStatement_13
    			data[code[vpc+(11)]]= (int)data[code[vpc+(-1)]]- (int)data[code[vpc+(22)]];
    			vpc+=58;
    			break;
    		case 9957: //frequency 1 ReturnStatement_38
    			return (string)data[code[vpc+(2)]];
    			vpc+=65;
    		case 4774: //frequency 1 WhileStatementSyntax_23
    			data[code[vpc+(-14)]]=(bool)data[code[vpc+(-13)]]?(int)data[code[vpc+(-6)]]:(int)data[code[vpc+(-9)]];
    			vpc+=(int)data[code[vpc+(-14)]];
    			break;
    		case 9676: //frequency 1 ExpressionStatement_15
    			data[code[vpc+(-6)]]= (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc+(2)]]).GetPiston((int)data[code[vpc+(6)]]));
    			vpc+=58;
    			break;
    		case 7385: //frequency 4 ExpressionStatement_0
    			data[code[vpc+(23)]]= (string)data[code[vpc+(-18)]]+ (int)data[code[vpc+(11)]];
    			vpc+=61;
    			break;
    		case 2058: //frequency 1 ExpressionStatement_5
    			data[code[vpc+(-17)]]= (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc+(-6)]]).First());
    			vpc+=71;
    			break;
    		case 9872: //frequency 2 ExpressionStatement_21
    			data[code[vpc+(-4)]]= ReturnArg_Array((int)data[code[vpc+(-16)]]);
    			vpc+=52;
    			break;
    		case 5921: //frequency 1 ExpressionStatement_7
    			data[code[vpc+(-6)]]= (string)data[code[vpc+(-18)]]+ (double)data[code[vpc+(-11)]];
    			vpc+=68;
    			break;
    		case 7635: //frequency 2 ExpressionStatement_18
    			data[code[vpc+(9)]]= data[code[vpc+(25)]];
    			vpc+=63;
    			break;
    		case 5888: //frequency 2 ExpressionStatement_22
    			data[code[vpc+(25)]]= (int)data[code[vpc+(18)]]< (int)data[code[vpc+(13)]];
    			vpc+=69;
    			break;
    		default: //frequency 10 ExpressionStatement_2
    			data[code[vpc+(2)]]= (string)data[code[vpc+(4)]]+ (string)data[code[vpc+(20)]];
    			vpc+=69;
    			break;
    		case 9059: //frequency 1 ExpressionStatement_31
    			data[code[vpc+(-16)]]= (int)data[code[vpc+(-10)]]+ (int)data[code[vpc+(14)]];
    			vpc+=70;
    			break;
    		case 5359: //frequency 1 ExpressionStatement_34
    			vpc += (int)data[code[vpc+(-10)]];
    			vpc+=66;
    			break;
    		case 3148: //frequency 1 ExpressionStatement_6
    			data[code[vpc+(-8)]]= ((ConsoleCalculator.Piston)data[code[vpc+(26)]]).GetSize();
    			vpc+=59;
    			break;
    		case 2506: //frequency 1 ExpressionStatement_35
    			data[code[vpc+(-18)]]= ((string[])data[code[vpc+(3)]]).Length;
    			vpc+=52;
    			break;
    		case 8024: //frequency 3 ExpressionStatement_3
    			data[code[vpc+(16)]]= (ConsoleCalculator.Engine)(car.GetEngine());
    			vpc+=52;
    			break;
    		case 2635: //frequency 1 ExpressionStatement_30
    			((string[])data[code[vpc+(24)]])[(int)data[code[vpc+(26)]]] = (string)data[code[vpc+(6)]];
    			vpc+=63;
    			break;
    		case 3262: //frequency 1 ExpressionStatement_16
    			data[code[vpc+(9)]]= ((ConsoleCalculator.Piston)data[code[vpc+(20)]]).ToString();
    			vpc+=64;
    			break;
    		case 5475: //frequency 1 ExpressionStatement_12
    			data[code[vpc+(11)]]= ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc+(1)]]).Count;
    			vpc+=71;
    			break;
    		case 6304: //frequency 1 ExpressionStatement_19
    			data[code[vpc+(12)]]= (string[])(new string[(int)data[code[vpc+(-17)]]]);
    			vpc+=56;
    			break;
    		case 6946: //frequency 2 ExpressionStatement_4
    			data[code[vpc+(3)]]= (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc+(28)]]).GetPistons());
    			vpc+=64;
    			break;
    	}
    }

    return null;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        private string ForSimple_Array_refactored_op4_in5(int b)
{
    string sum = "" + 3 + 4 + "";
    double p1 = car.GetEngine().GetPistons().First().GetSize();
    sum = sum + "[" + p1 + "]";
    int memberTemp_0 = car.GetEngine().GetPistons().Count;
    ConsoleCalculator.Piston invocationTemp_0 = car.GetEngine().GetPiston(memberTemp_0 - 1);
    sum = sum + invocationTemp_0.ToString();
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    bool var_whileCondition_0 = var_forIndex_0 < ReturnArg_Array(b);
    while (var_whileCondition_0)
    {
        sum = sum + "_" + var_forIndex_0 + "_";
        sum = sum + "~";
        r = r + sum + "#";
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        var_whileCondition_0 = var_forIndex_0 < ReturnArg_Array(b);
    }

    int memberTemp_1 = dst.Length;
    sum = sum + "#" + memberTemp_1;
    return sum;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        private string ForSimple_Array_refactored_op4_in4(int b)
{
    string sum = "" + 3 + 4 + "";
    ConsoleCalculator.Piston invocationTemp_0 = car.GetEngine().GetPistons().First();
    double p1 = invocationTemp_0.GetSize();
    sum = sum + "[" + p1 + "]";
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_1 = car.GetEngine().GetPistons();
    int memberTemp_0 = invocationTemp_1.Count;
    string invocationTemp_2 = car.GetEngine().GetPiston(memberTemp_0 - 1).ToString();
    sum = sum + invocationTemp_2;
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    bool var_whileCondition_0 = var_forIndex_0 < ReturnArg_Array(b);
    while (var_whileCondition_0)
    {
        sum = sum + "_" + var_forIndex_0 + "_";
        sum = sum + "~";
        r = r + sum + "#";
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        var_whileCondition_0 = var_forIndex_0 < ReturnArg_Array(b);
    }

    int memberTemp_1 = dst.Length;
    sum = sum + "#" + memberTemp_1;
    return sum;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        private string ForSimple_Array_refactored_op4_in1(int b)
{
    string sum = "" + 3 + 4 + "";
    ConsoleCalculator.Engine invocationTemp_0 = car.GetEngine();
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_1 = invocationTemp_0.GetPistons();
    ConsoleCalculator.Piston invocationTemp_2 = invocationTemp_1.First();
    double p1 = invocationTemp_2.GetSize();
    sum = sum + "[" + p1 + "]";
    ConsoleCalculator.Engine invocationTemp_3 = car.GetEngine();
    ConsoleCalculator.Engine invocationTemp_4 = car.GetEngine();
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_5 = invocationTemp_4.GetPistons();
    int memberTemp_0 = invocationTemp_5.Count;
    ConsoleCalculator.Piston invocationTemp_6 = invocationTemp_3.GetPiston(memberTemp_0 - 1);
    string invocationTemp_7 = invocationTemp_6.ToString();
    sum = sum + invocationTemp_7;
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    int invocationTemp_8 = ReturnArg_Array(b);
    bool var_whileCondition_0 = var_forIndex_0 < invocationTemp_8;
    while (var_whileCondition_0)
    {
        sum = sum + "_" + var_forIndex_0 + "_";
        sum = sum + "~";
        r = r + sum + "#";
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        int invocationTemp_9 = ReturnArg_Array(b);
        var_whileCondition_0 = var_forIndex_0 < invocationTemp_9;
    }

    int memberTemp_1 = dst.Length;
    sum = sum + "#" + memberTemp_1;
    return sum;
}

        //                [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        private string ForSimple_Array_refactored_op3_in1(int b)
{
    string addTemp_0 = "" + 3 + 4;
    string sum = addTemp_0 + "";
    ConsoleCalculator.Engine invocationTemp_0 = car.GetEngine();
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_1 = invocationTemp_0.GetPistons();
    ConsoleCalculator.Piston invocationTemp_2 = invocationTemp_1.First();
    double p1 = invocationTemp_2.GetSize();
    string addTemp_1 = "[" + p1 + "]";
    sum = sum + addTemp_1;
    ConsoleCalculator.Engine invocationTemp_3 = car.GetEngine();
    ConsoleCalculator.Engine invocationTemp_4 = car.GetEngine();
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_5 = invocationTemp_4.GetPistons();
    int memberTemp_0 = invocationTemp_5.Count;
    ConsoleCalculator.Piston invocationTemp_6 = invocationTemp_3.GetPiston(memberTemp_0 - 1);
    string invocationTemp_7 = invocationTemp_6.ToString();
    sum = sum + invocationTemp_7;
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    int invocationTemp_8 = ReturnArg_Array(b);
    bool var_whileCondition_0 = var_forIndex_0 < invocationTemp_8;
    while (var_whileCondition_0)
    {
        string addTemp_2 = "_" + var_forIndex_0 + "_";
        sum = sum + addTemp_2;
        sum = sum + "~";
        r = r + sum + "#";
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        int invocationTemp_9 = ReturnArg_Array(b);
        var_whileCondition_0 = var_forIndex_0 < invocationTemp_9;
    }

    int memberTemp_1 = dst.Length;
    sum = sum + "#" + memberTemp_1;
    return sum;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        private string ForSimple_Array_refactored_op2_in1(int b)
{
    string addTemp_0 = "" + 3;
    string addTemp_1 = addTemp_0 + 4;
    string sum = addTemp_1 + "";
    ConsoleCalculator.Engine invocationTemp_0 = car.GetEngine();
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_1 = invocationTemp_0.GetPistons();
    ConsoleCalculator.Piston invocationTemp_2 = invocationTemp_1.First();
    double p1 = invocationTemp_2.GetSize();
    string addTemp_2 = "[" + p1;
    string addTemp_3 = addTemp_2 + "]";
    sum = sum + addTemp_3;
    ConsoleCalculator.Engine invocationTemp_3 = car.GetEngine();
    System.Collections.Generic.List<ConsoleCalculator.Piston> invocationTemp_4 = invocationTemp_3.GetPistons();
    int memberTemp_0 = invocationTemp_4.Count;
    int addTemp_4 = memberTemp_0 - 1;
    ConsoleCalculator.Engine invocationTemp_5 = car.GetEngine();
    ConsoleCalculator.Piston invocationTemp_6 = invocationTemp_5.GetPiston(addTemp_4);
    string invocationTemp_7 = invocationTemp_6.ToString();
    sum = sum + invocationTemp_7;
    string r = "";
    string[] dst = new string[b];
    int var_forIndex_0 = 0;
    int invocationTemp_8 = ReturnArg_Array(b);
    bool var_whileCondition_0 = var_forIndex_0 < invocationTemp_8;
    while (var_whileCondition_0)
    {
        string addTemp_5 = "_" + var_forIndex_0;
        string addTemp_6 = addTemp_5 + "_";
        sum = sum + addTemp_6;
        sum = sum + "~";
        string addTemp_7 = sum + "#";
        r = r + addTemp_7;
        dst[var_forIndex_0] = sum;
        var_forIndex_0 = var_forIndex_0 + 1;
        int invocationTemp_9 = ReturnArg_Array(b);
        var_whileCondition_0 = var_forIndex_0 < invocationTemp_9;
    }

    int memberTemp_1 = dst.Length;
    string addTemp_8 = "#" + memberTemp_1;
    sum = sum + addTemp_8;
    return sum;
}


        //                [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]

        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
private string ForSimple_Array_obfuscated_op3_in1(int b)
{
    //Virtualization variables
    int[] code = new int[100599];
    object[] data = new object[4223];
    int vpc = 27;

    //Data init
    data[2490]=b; //b 
    data[236]="" ; //"" constant
    data[3339]=3 ; //3 constant
    data[2874]=4; //4 constant
    data[2745]="[" ; //"[" constant
    data[413]="]"; //"]" constant
    data[2971]=1; //1 constant
    data[3769]=0; //0 constant
    data[536]="_" ; //"_" constant
    data[2569]="~"; //"~" constant
    data[1869]="#"; //"#" constant
    data[1920]=245619067; //addTemp_0 
    data[2246]=1707035993; //sum 
    data[1218]=(ConsoleCalculator.Engine)null; //invocationTemp_0 
    data[1885]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
    data[2989]=(ConsoleCalculator.Piston)null; //invocationTemp_2 
    data[746]=(double)0.107707382229952; //p1 
    data[1309]=559922757; //addTemp_1 
    data[599]=(ConsoleCalculator.Engine)null; //invocationTemp_3 
    data[992]=(ConsoleCalculator.Engine)null; //invocationTemp_4 
    data[211]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_5 
    data[583]=214; //memberTemp_0 
    data[925]=(ConsoleCalculator.Piston)null; //invocationTemp_6 
    data[2876]=1776754745; //invocationTemp_7 
    data[1495]=875045554; //r 
    data[1921]=(string[])null; //dst 
    data[1398]=257; //var_forIndex_0 
    data[235]=197; //invocationTemp_8 
    data[3871]=false; //var_whileCondition_0 
    data[3894]=1017451102; //addTemp_2 
    data[1276]=-630; //invocationTemp_9 
    data[1913]=-294; //memberTemp_1 
    data[2523]=558; //jmpWhileDestinationName_2523 constant
    data[1129]=70; //while_GoTo_True_1129 constant
    data[306]=634; //while_GoTo_False_306 constant
    data[1251]=-634; //while_FalseBlockSkip_1251 constant

    //Code init

    code[27]=8506; //ExpressionStatement_0 # ExpressionStatement_0
    code[43]=1920; //addTemp_0
    code[47]=236; //""
    code[44]=3339; //3
    code[37]=2874; //4

    code[96]=4875; //ExpressionStatement_1 # ExpressionStatement_1
    code[83]=2246; //sum
    code[114]=1920; //addTemp_0
    code[98]=236; //""

    code[161]=1230; //ExpressionStatement_2 # ExpressionStatement_2
    code[170]=1218; //invocationTemp_0

    code[213]=4523; //ExpressionStatement_3 # ExpressionStatement_3
    code[210]=1885; //invocationTemp_1
    code[216]=1218; //invocationTemp_0

    code[265]=2041; //ExpressionStatement_4 # ExpressionStatement_4
    code[255]=2989; //invocationTemp_2
    code[282]=1885; //invocationTemp_1

    code[323]=9767; //ExpressionStatement_5 # ExpressionStatement_5
    code[319]=746; //p1
    code[352]=2989; //invocationTemp_2

    code[378]=9652; //ExpressionStatement_6 # ExpressionStatement_6
    code[389]=1309; //addTemp_1
    code[405]=2745; //"["
    code[380]=746; //p1
    code[383]=413; //"]"

    code[433]=4875; //ExpressionStatement_1 # ExpressionStatement_7
    code[420]=2246; //sum
    code[451]=2246; //sum
    code[435]=1309; //addTemp_1

    code[498]=1230; //ExpressionStatement_2 # ExpressionStatement_8
    code[507]=599; //invocationTemp_3

    code[550]=1230; //ExpressionStatement_2 # ExpressionStatement_9
    code[559]=992; //invocationTemp_4

    code[602]=4523; //ExpressionStatement_3 # ExpressionStatement_10
    code[599]=211; //invocationTemp_5
    code[605]=992; //invocationTemp_4

    code[654]=6185; //ExpressionStatement_11 # ExpressionStatement_11
    code[635]=583; //memberTemp_0
    code[663]=211; //invocationTemp_5

    code[717]=9172; //ExpressionStatement_12 # ExpressionStatement_12
    code[721]=925; //invocationTemp_6
    code[701]=599; //invocationTemp_3
    code[699]=583; //memberTemp_0
    code[709]=2971; //1

    code[778]=1057; //ExpressionStatement_13 # ExpressionStatement_13
    code[777]=2876; //invocationTemp_7
    code[788]=925; //invocationTemp_6

    code[843]=4875; //ExpressionStatement_1 # ExpressionStatement_14
    code[830]=2246; //sum
    code[861]=2246; //sum
    code[845]=2876; //invocationTemp_7

    code[908]=8883; //ExpressionStatement_15 # ExpressionStatement_15
    code[902]=1495; //r
    code[895]=236; //""

    code[965]=5453; //ExpressionStatement_16 # ExpressionStatement_16
    code[964]=1921; //dst
    code[950]=2490; //b

    code[1030]=8883; //ExpressionStatement_15 # ExpressionStatement_17
    code[1024]=1398; //var_forIndex_0
    code[1017]=3769; //0

    code[1087]=9853; //ExpressionStatement_18 # ExpressionStatement_18
    code[1073]=235; //invocationTemp_8
    code[1105]=2490; //b

    code[1146]=5855; //ExpressionStatement_19 # ExpressionStatement_19
    code[1135]=3871; //var_whileCondition_0
    code[1133]=1398; //var_forIndex_0
    code[1158]=235; //invocationTemp_8

    code[1214]=7901; //WhileStatementSyntax_20 # WhileStatementSyntax_20
    code[1211]=2523; //jmpWhileDestinationName_2523
    code[1239]=3871; //var_whileCondition_0
    code[1229]=1129; //while_GoTo_True_1129
    code[1210]=306; //while_GoTo_False_306

    code[1284]=4796; //ExpressionStatement_21 # ExpressionStatement_21
    code[1290]=3894; //addTemp_2
    code[1310]=536; //"_"
    code[1296]=1398; //var_forIndex_0
    code[1304]=536; //"_"

    code[1342]=4875; //ExpressionStatement_1 # ExpressionStatement_22
    code[1329]=2246; //sum
    code[1360]=2246; //sum
    code[1344]=3894; //addTemp_2

    code[1407]=4875; //ExpressionStatement_1 # ExpressionStatement_23
    code[1394]=2246; //sum
    code[1425]=2246; //sum
    code[1409]=2569; //"~"

    code[1472]=6859; //ExpressionStatement_24 # ExpressionStatement_24
    code[1501]=1495; //r
    code[1491]=1495; //r
    code[1458]=2246; //sum
    code[1483]=1869; //"#"

    code[1528]=8472; //ExpressionStatement_25 # ExpressionStatement_25
    code[1548]=1921; //dst
    code[1533]=1398; //var_forIndex_0
    code[1531]=2246; //sum

    code[1586]=1203; //ExpressionStatement_26 # ExpressionStatement_26
    code[1582]=1398; //var_forIndex_0
    code[1603]=1398; //var_forIndex_0
    code[1607]=2971; //1

    code[1654]=9853; //ExpressionStatement_18 # ExpressionStatement_27
    code[1640]=1276; //invocationTemp_9
    code[1672]=2490; //b

    code[1713]=5855; //ExpressionStatement_19 # ExpressionStatement_28
    code[1702]=3871; //var_whileCondition_0
    code[1700]=1398; //var_forIndex_0
    code[1725]=1276; //invocationTemp_9

    code[1781]=7253; //ExpressionStatement_29 # ExpressionStatement_29
    code[1776]=1251; //while_FalseBlockSkip_1251

    code[1848]=5791; //ExpressionStatement_30 # ExpressionStatement_30
    code[1839]=1913; //memberTemp_1
    code[1828]=1921; //dst

    code[1913]=5456; //ExpressionStatement_31 # ExpressionStatement_31
    code[1932]=2246; //sum
    code[1928]=2246; //sum
    code[1922]=1869; //"#"
    code[1910]=1913; //memberTemp_1

    code[1979]=2324; //ReturnStatement_32 # ReturnStatement_32
    code[1983]=2246; //sum

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_1574_op3_in1(vpc, data, code);

}

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
private string ForSimple_Array_obfuscated_op4_in1(int b)
{
    //Virtualization variables
    int[] code = new int[100613];
    object[] data = new object[4354];
    int vpc = 20;

    //Data init
    data[1499]=b; //b 
    data[3036]="" ; //"" constant
    data[3778]=3 ; //3 constant
    data[1643]=4 ; //4 constant
    data[3799]="[" ; //"[" constant
    data[2195]="]"; //"]" constant
    data[72]=1; //1 constant
    data[3798]=0; //0 constant
    data[963]="_" ; //"_" constant
    data[1414]="~"; //"~" constant
    data[2515]="#"; //"#" constant
    data[1725]=362158193; //sum 
    data[984]=(ConsoleCalculator.Engine)null; //invocationTemp_0 
    data[3132]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
    data[3723]=(ConsoleCalculator.Piston)null; //invocationTemp_2 
    data[394]=(double)0.537795374420376; //p1 
    data[623]=(ConsoleCalculator.Engine)null; //invocationTemp_3 
    data[1514]=(ConsoleCalculator.Engine)null; //invocationTemp_4 
    data[1195]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_5 
    data[3611]=117; //memberTemp_0 
    data[770]=(ConsoleCalculator.Piston)null; //invocationTemp_6 
    data[1845]=374684910; //invocationTemp_7 
    data[247]=362155776; //r 
    data[3015]=(string[])null; //dst 
    data[2617]=-214; //var_forIndex_0 
    data[587]=-762; //invocationTemp_8 
    data[2360]=false; //var_whileCondition_0 
    data[1827]=151; //invocationTemp_9 
    data[1276]=995; //memberTemp_1 
    data[343]=699; //jmpWhileDestinationName_343 constant
    data[1271]=69; //while_GoTo_True_1271 constant
    data[3065]=573; //while_GoTo_False_3065 constant
    data[148]=-573; //while_FalseBlockSkip_148 constant

    //Code init

    code[20]=3746; //ExpressionStatement_0 # ExpressionStatement_0
    code[34]=1725; //sum
    code[46]=3036; //""
    code[33]=3778; //3
    code[13]=1643; //4
    code[35]=3036; //""

    code[93]=5631; //ExpressionStatement_1 # ExpressionStatement_1
    code[107]=984; //invocationTemp_0

    code[149]=6837; //ExpressionStatement_2 # ExpressionStatement_2
    code[144]=3132; //invocationTemp_1
    code[174]=984; //invocationTemp_0

    code[202]=6699; //ExpressionStatement_3 # ExpressionStatement_3
    code[188]=3723; //invocationTemp_2
    code[227]=3132; //invocationTemp_1

    code[262]=9219; //ExpressionStatement_4 # ExpressionStatement_4
    code[251]=394; //p1
    code[279]=3723; //invocationTemp_2

    code[327]=9627; //ExpressionStatement_5 # ExpressionStatement_5
    code[338]=1725; //sum
    code[318]=1725; //sum
    code[343]=3799; //"["
    code[320]=394; //p1
    code[313]=2195; //"]"

    code[393]=5631; //ExpressionStatement_1 # ExpressionStatement_6
    code[407]=623; //invocationTemp_3

    code[449]=5631; //ExpressionStatement_1 # ExpressionStatement_7
    code[463]=1514; //invocationTemp_4

    code[505]=6837; //ExpressionStatement_2 # ExpressionStatement_8
    code[500]=1195; //invocationTemp_5
    code[530]=1514; //invocationTemp_4

    code[558]=2964; //ExpressionStatement_9 # ExpressionStatement_9
    code[567]=3611; //memberTemp_0
    code[560]=1195; //invocationTemp_5

    code[612]=2738; //ExpressionStatement_10 # ExpressionStatement_10
    code[607]=770; //invocationTemp_6
    code[592]=623; //invocationTemp_3
    code[595]=3611; //memberTemp_0
    code[606]=72; //1

    code[673]=8700; //ExpressionStatement_11 # ExpressionStatement_11
    code[663]=1845; //invocationTemp_7
    code[664]=770; //invocationTemp_6

    code[732]=3293; //ExpressionStatement_12 # ExpressionStatement_12
    code[723]=1725; //sum
    code[735]=1725; //sum
    code[721]=1845; //invocationTemp_7

    code[800]=7795; //ExpressionStatement_13 # ExpressionStatement_13
    code[824]=247; //r
    code[781]=3036; //""

    code[869]=2611; //ExpressionStatement_14 # ExpressionStatement_14
    code[886]=3015; //dst
    code[859]=1499; //b

    code[931]=7795; //ExpressionStatement_13 # ExpressionStatement_15
    code[955]=2617; //var_forIndex_0
    code[912]=3798; //0

    code[1000]=4735; //ExpressionStatement_16 # ExpressionStatement_16
    code[1006]=587; //invocationTemp_8
    code[1002]=1499; //b

    code[1058]=7480; //ExpressionStatement_17 # ExpressionStatement_17
    code[1082]=2360; //var_whileCondition_0
    code[1075]=2617; //var_forIndex_0
    code[1074]=587; //invocationTemp_8

    code[1117]=1081; //WhileStatementSyntax_18 # WhileStatementSyntax_18
    code[1123]=343; //jmpWhileDestinationName_343
    code[1140]=2360; //var_whileCondition_0
    code[1099]=1271; //while_GoTo_True_1271
    code[1133]=3065; //while_GoTo_False_3065

    code[1186]=6695; //ExpressionStatement_19 # ExpressionStatement_19
    code[1193]=1725; //sum
    code[1205]=1725; //sum
    code[1174]=963; //"_"
    code[1172]=2617; //var_forIndex_0
    code[1190]=963; //"_"

    code[1257]=3293; //ExpressionStatement_12 # ExpressionStatement_20
    code[1248]=1725; //sum
    code[1260]=1725; //sum
    code[1246]=1414; //"~"

    code[1325]=6821; //ExpressionStatement_21 # ExpressionStatement_21
    code[1352]=247; //r
    code[1350]=247; //r
    code[1339]=1725; //sum
    code[1319]=2515; //"#"

    code[1395]=9150; //ExpressionStatement_22 # ExpressionStatement_22
    code[1396]=3015; //dst
    code[1411]=2617; //var_forIndex_0
    code[1379]=1725; //sum

    code[1459]=1977; //ExpressionStatement_23 # ExpressionStatement_23
    code[1460]=2617; //var_forIndex_0
    code[1445]=2617; //var_forIndex_0
    code[1478]=72; //1

    code[1515]=4735; //ExpressionStatement_16 # ExpressionStatement_24
    code[1521]=1827; //invocationTemp_9
    code[1517]=1499; //b

    code[1573]=7480; //ExpressionStatement_17 # ExpressionStatement_25
    code[1597]=2360; //var_whileCondition_0
    code[1590]=2617; //var_forIndex_0
    code[1589]=1827; //invocationTemp_9

    code[1632]=1500; //ExpressionStatement_26 # ExpressionStatement_26
    code[1645]=148; //while_FalseBlockSkip_148

    code[1690]=2603; //ExpressionStatement_27 # ExpressionStatement_27
    code[1715]=1276; //memberTemp_1
    code[1708]=3015; //dst

    code[1753]=4757; //ExpressionStatement_28 # ExpressionStatement_28
    code[1751]=1725; //sum
    code[1780]=1725; //sum
    code[1778]=2515; //"#"
    code[1764]=1276; //memberTemp_1

    code[1819]=8067; //ReturnStatement_29 # ReturnStatement_29
    code[1812]=1725; //sum

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_3371_op4_in1(vpc, data, code);

}

        private string ForSimple_Array_obfuscated_op2_in1(int b)
{
    //Virtualization variables
    int[] code = new int[100285];
    object[] data = new object[4187];
    int vpc = 44;

    //Data init
    data[92]=b; //b 
    data[2364]="" ; //"" constant
    data[115]=3; //3 constant
    data[1593]=4; //4 constant
    data[3975]="[" ; //"[" constant
    data[1280]="]"; //"]" constant
    data[639]=1; //1 constant
    data[2209]=0; //0 constant
    data[2845]="_" ; //"_" constant
    data[416]="~"; //"~" constant
    data[146]="#"; //"#" constant
    data[3329]=861137969; //addTemp_0 
    data[1424]=426817913; //addTemp_1 
    data[2032]=1090936824; //sum 
    data[3023]=(ConsoleCalculator.Engine)null; //invocationTemp_0 
    data[3639]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
    data[2752]=(ConsoleCalculator.Piston)null; //invocationTemp_2 
    data[1393]=(double)0.792997966889757; //p1 
    data[3658]=1720645340; //addTemp_2 
    data[1742]=1088886007; //addTemp_3 
    data[1371]=(ConsoleCalculator.Engine)null; //invocationTemp_3 
    data[464]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_4 
    data[3405]=430; //memberTemp_0 
    data[89]=690; //addTemp_4 
    data[540]=(ConsoleCalculator.Engine)null; //invocationTemp_5 
    data[633]=(ConsoleCalculator.Piston)null; //invocationTemp_6 
    data[3643]=33887365; //invocationTemp_7 
    data[2869]=179759393; //r 
    data[2173]=(string[])null; //dst 
    data[905]=525; //var_forIndex_0 
    data[1525]=629; //invocationTemp_8 
    data[3690]=false; //var_whileCondition_0 
    data[1760]=748259412; //addTemp_5 
    data[1876]=1366923731; //addTemp_6 
    data[3462]=1837547023; //addTemp_7 
    data[3477]=752; //invocationTemp_9 
    data[1817]=-877; //memberTemp_1 
    data[1135]=450921265; //addTemp_8 
    data[3757]=-812; //jmpWhileDestinationName_3757 constant
    data[2785]=69; //while_GoTo_True_2785 constant
    data[1722]=810; //while_GoTo_False_1722 constant
    data[903]=-810; //while_FalseBlockSkip_903 constant

    //Code init

    code[44]=7697; //ExpressionStatement_0 # ExpressionStatement_0
    code[27]=3329; //addTemp_0
    code[58]=2364; //""
    code[47]=115; //3

    code[115]=7697; //ExpressionStatement_0 # ExpressionStatement_1
    code[98]=1424; //addTemp_1
    code[129]=3329; //addTemp_0
    code[118]=1593; //4

    code[186]=7376; //ExpressionStatement_2 # ExpressionStatement_2
    code[197]=2032; //sum
    code[204]=1424; //addTemp_1
    code[212]=2364; //""

    code[257]=5089; //ExpressionStatement_3 # ExpressionStatement_3
    code[273]=3023; //invocationTemp_0

    code[326]=3369; //ExpressionStatement_4 # ExpressionStatement_4
    code[328]=3639; //invocationTemp_1
    code[306]=3023; //invocationTemp_0

    code[394]=7503; //ExpressionStatement_5 # ExpressionStatement_5
    code[393]=2752; //invocationTemp_2
    code[418]=3639; //invocationTemp_1

    code[448]=8977; //ExpressionStatement_6 # ExpressionStatement_6
    code[433]=1393; //p1
    code[459]=2752; //invocationTemp_2

    code[509]=6388; //ExpressionStatement_7 # ExpressionStatement_7
    code[527]=3658; //addTemp_2
    code[505]=3975; //"["
    code[522]=1393; //p1

    code[565]=7376; //ExpressionStatement_2 # ExpressionStatement_8
    code[576]=1742; //addTemp_3
    code[583]=3658; //addTemp_2
    code[591]=1280; //"]"

    code[636]=7376; //ExpressionStatement_2 # ExpressionStatement_9
    code[647]=2032; //sum
    code[654]=2032; //sum
    code[662]=1742; //addTemp_3

    code[707]=5089; //ExpressionStatement_3 # ExpressionStatement_10
    code[723]=1371; //invocationTemp_3

    code[776]=3369; //ExpressionStatement_4 # ExpressionStatement_11
    code[778]=464; //invocationTemp_4
    code[756]=1371; //invocationTemp_3

    code[844]=6463; //ExpressionStatement_12 # ExpressionStatement_12
    code[839]=3405; //memberTemp_0
    code[824]=464; //invocationTemp_4

    code[915]=2167; //ExpressionStatement_13 # ExpressionStatement_13
    code[896]=89; //addTemp_4
    code[938]=3405; //memberTemp_0
    code[932]=639; //1

    code[976]=5089; //ExpressionStatement_3 # ExpressionStatement_14
    code[992]=540; //invocationTemp_5

    code[1045]=4181; //ExpressionStatement_15 # ExpressionStatement_15
    code[1028]=633; //invocationTemp_6
    code[1051]=540; //invocationTemp_5
    code[1035]=89; //addTemp_4

    code[1109]=5003; //ExpressionStatement_16 # ExpressionStatement_16
    code[1122]=3643; //invocationTemp_7
    code[1103]=633; //invocationTemp_6

    code[1165]=7376; //ExpressionStatement_2 # ExpressionStatement_17
    code[1176]=2032; //sum
    code[1183]=2032; //sum
    code[1191]=3643; //invocationTemp_7

    code[1236]=7595; //ExpressionStatement_18 # ExpressionStatement_18
    code[1249]=2869; //r
    code[1245]=2364; //""

    code[1307]=4138; //ExpressionStatement_19 # ExpressionStatement_19
    code[1305]=2173; //dst
    code[1331]=92; //b

    code[1367]=7595; //ExpressionStatement_18 # ExpressionStatement_20
    code[1380]=905; //var_forIndex_0
    code[1376]=2209; //0

    code[1438]=1729; //ExpressionStatement_21 # ExpressionStatement_21
    code[1452]=1525; //invocationTemp_8
    code[1455]=92; //b

    code[1507]=4452; //ExpressionStatement_22 # ExpressionStatement_22
    code[1524]=3690; //var_whileCondition_0
    code[1512]=905; //var_forIndex_0
    code[1530]=1525; //invocationTemp_8

    code[1574]=4795; //WhileStatementSyntax_23 # WhileStatementSyntax_23
    code[1563]=3757; //jmpWhileDestinationName_3757
    code[1583]=3690; //var_whileCondition_0
    code[1596]=2785; //while_GoTo_True_2785
    code[1571]=1722; //while_GoTo_False_1722

    code[1643]=7697; //ExpressionStatement_0 # ExpressionStatement_24
    code[1626]=1760; //addTemp_5
    code[1657]=2845; //"_"
    code[1646]=905; //var_forIndex_0

    code[1714]=7376; //ExpressionStatement_2 # ExpressionStatement_25
    code[1725]=1876; //addTemp_6
    code[1732]=1760; //addTemp_5
    code[1740]=2845; //"_"

    code[1785]=7376; //ExpressionStatement_2 # ExpressionStatement_26
    code[1796]=2032; //sum
    code[1803]=2032; //sum
    code[1811]=1876; //addTemp_6

    code[1856]=7376; //ExpressionStatement_2 # ExpressionStatement_27
    code[1867]=2032; //sum
    code[1874]=2032; //sum
    code[1882]=416; //"~"

    code[1927]=7376; //ExpressionStatement_2 # ExpressionStatement_28
    code[1938]=3462; //addTemp_7
    code[1945]=2032; //sum
    code[1953]=146; //"#"

    code[1998]=7376; //ExpressionStatement_2 # ExpressionStatement_29
    code[2009]=2869; //r
    code[2016]=2869; //r
    code[2024]=3462; //addTemp_7

    code[2069]=4327; //ExpressionStatement_30 # ExpressionStatement_30
    code[2060]=2173; //dst
    code[2071]=905; //var_forIndex_0
    code[2098]=2032; //sum

    code[2133]=5722; //ExpressionStatement_31 # ExpressionStatement_31
    code[2134]=905; //var_forIndex_0
    code[2155]=905; //var_forIndex_0
    code[2161]=639; //1

    code[2187]=1729; //ExpressionStatement_21 # ExpressionStatement_32
    code[2201]=3477; //invocationTemp_9
    code[2204]=92; //b

    code[2256]=4452; //ExpressionStatement_22 # ExpressionStatement_33
    code[2273]=3690; //var_whileCondition_0
    code[2261]=905; //var_forIndex_0
    code[2279]=3477; //invocationTemp_9

    code[2323]=1141; //ExpressionStatement_34 # ExpressionStatement_34
    code[2349]=903; //while_FalseBlockSkip_903

    code[2384]=5471; //ExpressionStatement_35 # ExpressionStatement_35
    code[2372]=1817; //memberTemp_1
    code[2391]=2173; //dst

    code[2440]=7697; //ExpressionStatement_0 # ExpressionStatement_36
    code[2423]=1135; //addTemp_8
    code[2454]=146; //"#"
    code[2443]=1817; //memberTemp_1

    code[2511]=7376; //ExpressionStatement_2 # ExpressionStatement_37
    code[2522]=2032; //sum
    code[2529]=2032; //sum
    code[2537]=1135; //addTemp_8

    code[2582]=7418; //ReturnStatement_38 # ReturnStatement_38
    code[2591]=2032; //sum

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_3189_op2_in1(vpc, data, code);

}

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
private string ForSimple_Array_obfuscated_op4_in4(int b)
{
    //Virtualization variables
    int[] code = new int[100647];
    object[] data = new object[4745];
    int vpc = 65;

    //Data init
    data[303]=b; //b 
    data[776]="" ; //"" constant
    data[1815]=3 ; //3 constant
    data[1730]=4 ; //4 constant
    data[3218]="[" ; //"[" constant
    data[2933]="]"; //"]" constant
    data[3515]=1; //1 constant
    data[2228]=0; //0 constant
    data[1259]="_" ; //"_" constant
    data[1133]="~"; //"~" constant
    data[1839]="#"; //"#" constant
    data[3931]=855812097; //sum 
    data[1105]=(ConsoleCalculator.Piston)null; //invocationTemp_0 
    data[3035]=(double)0.484366179669446; //p1 
    data[240]=(System.Collections.Generic.List<ConsoleCalculator.Piston>)null; //invocationTemp_1 
    data[584]=856; //memberTemp_0 
    data[2424]=485289089; //invocationTemp_2 
    data[994]=1446861472; //r 
    data[971]=(string[])null; //dst 
    data[919]=11; //var_forIndex_0 
    data[1299]=false; //var_whileCondition_0 
    data[3755]=726; //memberTemp_1 
    data[2699]=-375; //jmpWhileDestinationName_2699 constant
    data[3551]=64; //while_GoTo_True_3551 constant
    data[3743]=515; //while_GoTo_False_3743 constant
    data[1398]=-515; //while_FalseBlockSkip_1398 constant

    //Code init

    code[65]=4266; //ExpressionStatement_0 # ExpressionStatement_0
    code[57]=3931; //sum
    code[75]=776; //""
    code[86]=1815; //3
    code[72]=1730; //4
    code[82]=776; //""

    code[137]=9274; //ExpressionStatement_1 # ExpressionStatement_1
    code[119]=1105; //invocationTemp_0

    code[201]=5928; //ExpressionStatement_2 # ExpressionStatement_2
    code[208]=3035; //p1
    code[206]=1105; //invocationTemp_0

    code[263]=9957; //ExpressionStatement_3 # ExpressionStatement_3
    code[286]=3931; //sum
    code[265]=3931; //sum
    code[270]=3218; //"["
    code[283]=3035; //p1
    code[244]=2933; //"]"

    code[319]=9559; //ExpressionStatement_4 # ExpressionStatement_4
    code[304]=240; //invocationTemp_1

    code[378]=4319; //ExpressionStatement_5 # ExpressionStatement_5
    code[395]=584; //memberTemp_0
    code[398]=240; //invocationTemp_1

    code[432]=4975; //ExpressionStatement_6 # ExpressionStatement_6
    code[443]=2424; //invocationTemp_2
    code[459]=584; //memberTemp_0
    code[436]=3515; //1

    code[502]=7440; //ExpressionStatement_7 # ExpressionStatement_7
    code[499]=3931; //sum
    code[487]=3931; //sum
    code[482]=2424; //invocationTemp_2

    code[559]=1528; //ExpressionStatement_8 # ExpressionStatement_8
    code[573]=994; //r
    code[574]=776; //""

    code[624]=9493; //ExpressionStatement_9 # ExpressionStatement_9
    code[642]=971; //dst
    code[619]=303; //b

    code[683]=1528; //ExpressionStatement_8 # ExpressionStatement_10
    code[697]=919; //var_forIndex_0
    code[698]=2228; //0

    code[748]=3017; //ExpressionStatement_11 # ExpressionStatement_11
    code[771]=1299; //var_whileCondition_0
    code[734]=919; //var_forIndex_0
    code[759]=303; //b

    code[814]=5955; //WhileStatementSyntax_12 # WhileStatementSyntax_12
    code[796]=2699; //jmpWhileDestinationName_2699
    code[809]=1299; //var_whileCondition_0
    code[837]=3551; //while_GoTo_True_3551
    code[799]=3743; //while_GoTo_False_3743

    code[878]=2450; //ExpressionStatement_13 # ExpressionStatement_13
    code[868]=3931; //sum
    code[892]=3931; //sum
    code[858]=1259; //"_"
    code[890]=919; //var_forIndex_0
    code[902]=1259; //"_"

    code[937]=7440; //ExpressionStatement_7 # ExpressionStatement_14
    code[934]=3931; //sum
    code[922]=3931; //sum
    code[917]=1133; //"~"

    code[994]=9092; //ExpressionStatement_15 # ExpressionStatement_15
    code[983]=994; //r
    code[992]=994; //r
    code[975]=3931; //sum
    code[993]=1839; //"#"

    code[1066]=8387; //ExpressionStatement_16 # ExpressionStatement_16
    code[1060]=971; //dst
    code[1076]=919; //var_forIndex_0
    code[1075]=3931; //sum

    code[1127]=1386; //ExpressionStatement_17 # ExpressionStatement_17
    code[1136]=919; //var_forIndex_0
    code[1142]=919; //var_forIndex_0
    code[1119]=3515; //1

    code[1196]=3017; //ExpressionStatement_11 # ExpressionStatement_18
    code[1219]=1299; //var_whileCondition_0
    code[1182]=919; //var_forIndex_0
    code[1207]=303; //b

    code[1262]=1167; //ExpressionStatement_19 # ExpressionStatement_19
    code[1267]=1398; //while_FalseBlockSkip_1398

    code[1329]=6484; //ExpressionStatement_20 # ExpressionStatement_20
    code[1339]=3755; //memberTemp_1
    code[1326]=971; //dst

    code[1382]=9926; //ExpressionStatement_21 # ExpressionStatement_21
    code[1381]=3931; //sum
    code[1372]=3931; //sum
    code[1375]=1839; //"#"
    code[1393]=3755; //memberTemp_1

    code[1455]=9534; //ReturnStatement_22 # ReturnStatement_22
    code[1458]=3931; //sum

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_2774_op4_in4(vpc, data, code);

}

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
private string ForSimple_Array_obfuscated_op4_in5(int b)
{
    //Virtualization variables
    int[] code = new int[100029];
    object[] data = new object[4837];
    int vpc = 95;

    //Data init
    data[2559]=b; //b 
    data[2042]="" ; //"" constant
    data[39]=3 ; //3 constant
    data[2515]=4 ; //4 constant
    data[2332]="[" ; //"[" constant
    data[1592]="]"; //"]" constant
    data[3646]=1; //1 constant
    data[2164]=0; //0 constant
    data[1740]="_" ; //"_" constant
    data[2183]="~"; //"~" constant
    data[3632]="#"; //"#" constant
    data[3280]=596432624; //sum 
    data[1985]=(double)0.129145146873382; //p1 
    data[3127]=-383; //memberTemp_0 
    data[2407]=(ConsoleCalculator.Piston)null; //invocationTemp_0 
    data[3556]=273873507; //r 
    data[184]=(string[])null; //dst 
    data[388]=-989; //var_forIndex_0 
    data[145]=false; //var_whileCondition_0 
    data[2463]=439; //memberTemp_1 
    data[1167]=-55; //jmpWhileDestinationName_1167 constant
    data[1209]=56; //while_GoTo_True_1209 constant
    data[2765]=490; //while_GoTo_False_2765 constant
    data[1562]=-490; //while_FalseBlockSkip_1562 constant

    //Code init

    code[95]=7032; //ExpressionStatement_0 # ExpressionStatement_0
    code[86]=3280; //sum
    code[116]=2042; //""
    code[89]=39; //3
    code[104]=2515; //4
    code[101]=2042; //""

    code[161]=3871; //ExpressionStatement_1 # ExpressionStatement_1
    code[142]=1985; //p1

    code[229]=1570; //ExpressionStatement_2 # ExpressionStatement_2
    code[243]=3280; //sum
    code[244]=3280; //sum
    code[255]=2332; //"["
    code[212]=1985; //p1
    code[234]=1592; //"]"

    code[284]=7409; //ExpressionStatement_3 # ExpressionStatement_3
    code[301]=3127; //memberTemp_0

    code[340]=9817; //ExpressionStatement_4 # ExpressionStatement_4
    code[335]=2407; //invocationTemp_0
    code[331]=3127; //memberTemp_0
    code[343]=3646; //1

    code[406]=5197; //ExpressionStatement_5 # ExpressionStatement_5
    code[416]=3280; //sum
    code[419]=3280; //sum
    code[402]=2407; //invocationTemp_0

    code[464]=4246; //ExpressionStatement_6 # ExpressionStatement_6
    code[475]=3556; //r
    code[491]=2042; //""

    code[527]=4401; //ExpressionStatement_7 # ExpressionStatement_7
    code[555]=184; //dst
    code[530]=2559; //b

    code[590]=4246; //ExpressionStatement_6 # ExpressionStatement_8
    code[601]=388; //var_forIndex_0
    code[617]=2164; //0

    code[653]=8969; //ExpressionStatement_9 # ExpressionStatement_9
    code[652]=145; //var_whileCondition_0
    code[638]=388; //var_forIndex_0
    code[660]=2559; //b

    code[713]=4353; //WhileStatementSyntax_10 # WhileStatementSyntax_10
    code[733]=1167; //jmpWhileDestinationName_1167
    code[712]=145; //var_whileCondition_0
    code[735]=1209; //while_GoTo_True_1209
    code[723]=2765; //while_GoTo_False_2765

    code[769]=7715; //ExpressionStatement_11 # ExpressionStatement_11
    code[768]=3280; //sum
    code[782]=3280; //sum
    code[780]=1740; //"_"
    code[766]=388; //var_forIndex_0
    code[767]=1740; //"_"

    code[838]=6168; //ExpressionStatement_12 # ExpressionStatement_12
    code[834]=3280; //sum
    code[852]=3280; //sum
    code[856]=2183; //"~"

    code[905]=5691; //ExpressionStatement_13 # ExpressionStatement_13
    code[928]=3556; //r
    code[889]=3556; //r
    code[906]=3280; //sum
    code[931]=3632; //"#"

    code[961]=3135; //ExpressionStatement_14 # ExpressionStatement_14
    code[988]=184; //dst
    code[953]=388; //var_forIndex_0
    code[989]=3280; //sum

    code[1024]=1184; //ExpressionStatement_15 # ExpressionStatement_15
    code[1034]=388; //var_forIndex_0
    code[1038]=388; //var_forIndex_0
    code[1044]=3646; //1

    code[1090]=8969; //ExpressionStatement_9 # ExpressionStatement_16
    code[1089]=145; //var_whileCondition_0
    code[1075]=388; //var_forIndex_0
    code[1097]=2559; //b

    code[1150]=7702; //ExpressionStatement_17 # ExpressionStatement_17
    code[1141]=1562; //while_FalseBlockSkip_1562

    code[1203]=7729; //ExpressionStatement_18 # ExpressionStatement_18
    code[1215]=2463; //memberTemp_1
    code[1214]=184; //dst

    code[1256]=7151; //ExpressionStatement_19 # ExpressionStatement_19
    code[1237]=3280; //sum
    code[1252]=3280; //sum
    code[1258]=3632; //"#"
    code[1279]=2463; //memberTemp_1

    code[1310]=6384; //ReturnStatement_20 # ReturnStatement_20
    code[1313]=3280; //sum

    return (string)InstanceInterpreterVirtualization_TraceLoopTests_132_op4_in5(vpc, data, code);

}

        private int ReturnArg_Array(int arg)
        {
            return arg;
        }

       

private object InstanceInterpreterVirtualization_TraceLoopTests_3189_op2_in1(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 7697:  //frequency 4 ExpressionStatement_0
                data[code[vpc + (-17)]] = (string)data[code[vpc + (14)]] + (int)data[code[vpc + (3)]];
                vpc += 71;
                break;
            case 6463:  //frequency 1 ExpressionStatement_12
                data[code[vpc + (-5)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-20)]]).Count;
                vpc += 71;
                break;
            case 2167:  //frequency 1 ExpressionStatement_13
                data[code[vpc + (-19)]] = (int)data[code[vpc + (23)]] - (int)data[code[vpc + (17)]];
                vpc += 61;
                break;
            case 5089:  //frequency 3 ExpressionStatement_3
                data[code[vpc + (16)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                vpc += 69;
                break;
            case 4138:  //frequency 1 ExpressionStatement_19
                data[code[vpc + (-2)]] = (string[])(new string[(int)data[code[vpc + (24)]]]);
                vpc += 60;
                break;
            case 7595:  //frequency 2 ExpressionStatement_18
                data[code[vpc + (13)]] = data[code[vpc + (9)]];
                vpc += 71;
                break;
            default:  //frequency 0 
                break;
            case 7376:  //frequency 10 ExpressionStatement_2
                data[code[vpc + (11)]] = (string)data[code[vpc + (18)]] + (string)data[code[vpc + (26)]];
                vpc += 71;
                break;
            case 5722:  //frequency 1 ExpressionStatement_31
                data[code[vpc + (1)]] = (int)data[code[vpc + (22)]] + (int)data[code[vpc + (28)]];
                vpc += 54;
                break;
            case 5471:  //frequency 1 ExpressionStatement_35
                data[code[vpc + (-12)]] = ((string[])data[code[vpc + (7)]]).Length;
                vpc += 56;
                break;
            case 5003:  //frequency 1 ExpressionStatement_16
                data[code[vpc + (13)]] = ((ConsoleCalculator.Piston)data[code[vpc + (-6)]]).ToString();
                vpc += 56;
                break;
            case 7503:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (-1)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (24)]]).First());
                vpc += 54;
                break;
            case 1141:  //frequency 1 ExpressionStatement_34
                vpc += (int)data[code[vpc + (26)]];
                vpc += 61;
                break;
            case 4795:  //frequency 1 WhileStatementSyntax_23
                data[code[vpc + (-11)]] = (bool)data[code[vpc + (9)]] ? (int)data[code[vpc + (22)]] : (int)data[code[vpc + (-3)]];
                vpc += (int)data[code[vpc + (-11)]];
                break;
            case 4327:  //frequency 1 ExpressionStatement_30
                ((string[])data[code[vpc + (-9)]])[(int)data[code[vpc + (2)]]] = (string)data[code[vpc + (29)]];
                vpc += 64;
                break;
            case 1729:  //frequency 2 ExpressionStatement_21
                data[code[vpc + (14)]] = ReturnArg_Array((int)data[code[vpc + (17)]]);
                vpc += 69;
                break;
            case 3369:  //frequency 2 ExpressionStatement_4
                data[code[vpc + (2)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (-20)]]).GetPistons());
                vpc += 68;
                break;
            case 4452:  //frequency 2 ExpressionStatement_22
                data[code[vpc + (17)]] = (int)data[code[vpc + (5)]] < (int)data[code[vpc + (23)]];
                vpc += 67;
                break;
            case 8977:  //frequency 1 ExpressionStatement_6
                data[code[vpc + (-15)]] = ((ConsoleCalculator.Piston)data[code[vpc + (11)]]).GetSize();
                vpc += 61;
                break;
            case 7418:  //frequency 1 ReturnStatement_38
                return (string)data[code[vpc + (9)]];
                vpc += 60;
            case 4181:  //frequency 1 ExpressionStatement_15
                data[code[vpc + (-17)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (6)]]).GetPiston((int)data[code[vpc + (-10)]]));
                vpc += 64;
                break;
            case 6388:  //frequency 1 ExpressionStatement_7
                data[code[vpc + (18)]] = (string)data[code[vpc + (-4)]] + (double)data[code[vpc + (13)]];
                vpc += 56;
                break;
        }
    }

    return null;
}

private object InstanceInterpreterVirtualization_TraceLoopTests_1574_op3_in1(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 6859:  //frequency 1 ExpressionStatement_24
                data[code[vpc + (29)]] = (string)data[code[vpc + (19)]] + (string)data[code[vpc + (-14)]] + (string)data[code[vpc + (11)]];
                vpc += 56;
                break;
            case 5453:  //frequency 1 ExpressionStatement_16
                data[code[vpc + (-1)]] = (string[])(new string[(int)data[code[vpc + (-15)]]]);
                vpc += 65;
                break;
            case 9767:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (-4)]] = ((ConsoleCalculator.Piston)data[code[vpc + (29)]]).GetSize();
                vpc += 55;
                break;
            case 9853:  //frequency 2 ExpressionStatement_18
                data[code[vpc + (-14)]] = ReturnArg_Array((int)data[code[vpc + (18)]]);
                vpc += 59;
                break;
            case 2041:  //frequency 1 ExpressionStatement_4
                data[code[vpc + (-10)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (17)]]).First());
                vpc += 58;
                break;
            case 5791:  //frequency 1 ExpressionStatement_30
                data[code[vpc + (-9)]] = ((string[])data[code[vpc + (-20)]]).Length;
                vpc += 65;
                break;
            case 5855:  //frequency 2 ExpressionStatement_19
                data[code[vpc + (-11)]] = (int)data[code[vpc + (-13)]] < (int)data[code[vpc + (12)]];
                vpc += 68;
                break;
            case 4523:  //frequency 2 ExpressionStatement_3
                data[code[vpc + (-3)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (3)]]).GetPistons());
                vpc += 52;
                break;
            case 9172:  //frequency 1 ExpressionStatement_12
                data[code[vpc + (4)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (-16)]]).GetPiston((int)data[code[vpc + (-18)]] - (int)data[code[vpc + (-8)]]));
                vpc += 61;
                break;
            case 8883:  //frequency 2 ExpressionStatement_15
                data[code[vpc + (-6)]] = data[code[vpc + (-13)]];
                vpc += 57;
                break;
            case 7253:  //frequency 1 ExpressionStatement_29
                vpc += (int)data[code[vpc + (-5)]];
                vpc += 67;
                break;
            case 1057:  //frequency 1 ExpressionStatement_13
                data[code[vpc + (-1)]] = ((ConsoleCalculator.Piston)data[code[vpc + (10)]]).ToString();
                vpc += 65;
                break;
            case 2324:  //frequency 1 ReturnStatement_32
                return (string)data[code[vpc + (4)]];
                vpc += 59;
            case 4796:  //frequency 1 ExpressionStatement_21
                data[code[vpc + (6)]] = (string)data[code[vpc + (26)]] + (int)data[code[vpc + (12)]] + (string)data[code[vpc + (20)]];
                vpc += 58;
                break;
            case 4875:  //frequency 5 ExpressionStatement_1
                data[code[vpc + (-13)]] = (string)data[code[vpc + (18)]] + (string)data[code[vpc + (2)]];
                vpc += 65;
                break;
            case 9652:  //frequency 1 ExpressionStatement_6
                data[code[vpc + (11)]] = (string)data[code[vpc + (27)]] + (double)data[code[vpc + (2)]] + (string)data[code[vpc + (5)]];
                vpc += 55;
                break;
            case 1203:  //frequency 1 ExpressionStatement_26
                data[code[vpc + (-4)]] = (int)data[code[vpc + (17)]] + (int)data[code[vpc + (21)]];
                vpc += 68;
                break;
            case 6185:  //frequency 1 ExpressionStatement_11
                data[code[vpc + (-19)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (9)]]).Count;
                vpc += 63;
                break;
            case 1230:  //frequency 3 ExpressionStatement_2
                data[code[vpc + (9)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                vpc += 52;
                break;
            default:  //frequency 0 
                break;
            case 8506:  //frequency 1 ExpressionStatement_0
                data[code[vpc + (16)]] = (string)data[code[vpc + (20)]] + (int)data[code[vpc + (17)]] + (int)data[code[vpc + (10)]];
                vpc += 69;
                break;
            case 5456:  //frequency 1 ExpressionStatement_31
                data[code[vpc + (19)]] = (string)data[code[vpc + (15)]] + (string)data[code[vpc + (9)]] + (int)data[code[vpc + (-3)]];
                vpc += 66;
                break;
            case 8472:  //frequency 1 ExpressionStatement_25
                ((string[])data[code[vpc + (20)]])[(int)data[code[vpc + (5)]]] = (string)data[code[vpc + (3)]];
                vpc += 58;
                break;
            case 7901:  //frequency 1 WhileStatementSyntax_20
                data[code[vpc + (-3)]] = (bool)data[code[vpc + (25)]] ? (int)data[code[vpc + (15)]] : (int)data[code[vpc + (-4)]];
                vpc += (int)data[code[vpc + (-3)]];
                break;
        }
    }

    return null;
}

private object InstanceInterpreterVirtualization_TraceLoopTests_3371_op4_in1(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 8067:  //frequency 1 ReturnStatement_29
                return (string)data[code[vpc + (-7)]];
                vpc += 67;
            case 2738:  //frequency 1 ExpressionStatement_10
                data[code[vpc + (-5)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (-20)]]).GetPiston((int)data[code[vpc + (-17)]] - (int)data[code[vpc + (-6)]]));
                vpc += 61;
                break;
            default:  //frequency 0 
                break;
            case 6699:  //frequency 1 ExpressionStatement_3
                data[code[vpc + (-14)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (25)]]).First());
                vpc += 60;
                break;
            case 2603:  //frequency 1 ExpressionStatement_27
                data[code[vpc + (25)]] = ((string[])data[code[vpc + (18)]]).Length;
                vpc += 63;
                break;
            case 3293:  //frequency 2 ExpressionStatement_12
                data[code[vpc + (-9)]] = (string)data[code[vpc + (3)]] + (string)data[code[vpc + (-11)]];
                vpc += 68;
                break;
            case 8700:  //frequency 1 ExpressionStatement_11
                data[code[vpc + (-10)]] = ((ConsoleCalculator.Piston)data[code[vpc + (-9)]]).ToString();
                vpc += 59;
                break;
            case 1081:  //frequency 1 WhileStatementSyntax_18
                data[code[vpc + (6)]] = (bool)data[code[vpc + (23)]] ? (int)data[code[vpc + (-18)]] : (int)data[code[vpc + (16)]];
                vpc += (int)data[code[vpc + (6)]];
                break;
            case 4735:  //frequency 2 ExpressionStatement_16
                data[code[vpc + (6)]] = ReturnArg_Array((int)data[code[vpc + (2)]]);
                vpc += 58;
                break;
            case 2611:  //frequency 1 ExpressionStatement_14
                data[code[vpc + (17)]] = (string[])(new string[(int)data[code[vpc + (-10)]]]);
                vpc += 62;
                break;
            case 6821:  //frequency 1 ExpressionStatement_21
                data[code[vpc + (27)]] = (string)data[code[vpc + (25)]] + (string)data[code[vpc + (14)]] + (string)data[code[vpc + (-6)]];
                vpc += 70;
                break;
            case 1500:  //frequency 1 ExpressionStatement_26
                vpc += (int)data[code[vpc + (13)]];
                vpc += 58;
                break;
            case 9219:  //frequency 1 ExpressionStatement_4
                data[code[vpc + (-11)]] = ((ConsoleCalculator.Piston)data[code[vpc + (17)]]).GetSize();
                vpc += 65;
                break;
            case 4757:  //frequency 1 ExpressionStatement_28
                data[code[vpc + (-2)]] = (string)data[code[vpc + (27)]] + (string)data[code[vpc + (25)]] + (int)data[code[vpc + (11)]];
                vpc += 66;
                break;
            case 5631:  //frequency 3 ExpressionStatement_1
                data[code[vpc + (14)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                vpc += 56;
                break;
            case 6837:  //frequency 2 ExpressionStatement_2
                data[code[vpc + (-5)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (25)]]).GetPistons());
                vpc += 53;
                break;
            case 9627:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (11)]] = (string)data[code[vpc + (-9)]] + (string)data[code[vpc + (16)]] + (double)data[code[vpc + (-7)]] + (string)data[code[vpc + (-14)]];
                vpc += 66;
                break;
            case 6695:  //frequency 1 ExpressionStatement_19
                data[code[vpc + (7)]] = (string)data[code[vpc + (19)]] + (string)data[code[vpc + (-12)]] + (int)data[code[vpc + (-14)]] + (string)data[code[vpc + (4)]];
                vpc += 71;
                break;
            case 3746:  //frequency 1 ExpressionStatement_0
                data[code[vpc + (14)]] = (string)data[code[vpc + (26)]] + (int)data[code[vpc + (13)]] + (int)data[code[vpc + (-7)]] + (string)data[code[vpc + (15)]];
                vpc += 73;
                break;
            case 7795:  //frequency 2 ExpressionStatement_13
                data[code[vpc + (24)]] = data[code[vpc + (-19)]];
                vpc += 69;
                break;
            case 9150:  //frequency 1 ExpressionStatement_22
                ((string[])data[code[vpc + (1)]])[(int)data[code[vpc + (16)]]] = (string)data[code[vpc + (-16)]];
                vpc += 64;
                break;
            case 2964:  //frequency 1 ExpressionStatement_9
                data[code[vpc + (9)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (2)]]).Count;
                vpc += 54;
                break;
            case 7480:  //frequency 2 ExpressionStatement_17
                data[code[vpc + (24)]] = (int)data[code[vpc + (17)]] < (int)data[code[vpc + (16)]];
                vpc += 59;
                break;
            case 1977:  //frequency 1 ExpressionStatement_23
                data[code[vpc + (1)]] = (int)data[code[vpc + (-14)]] + (int)data[code[vpc + (19)]];
                vpc += 56;
                break;
        }
    }

    return null;
}

private object InstanceInterpreterVirtualization_TraceLoopTests_2774_op4_in4(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 1167:  //frequency 1 ExpressionStatement_19
                vpc += (int)data[code[vpc + (5)]];
                vpc += 67;
                break;
            case 1528:  //frequency 2 ExpressionStatement_8
                data[code[vpc + (14)]] = data[code[vpc + (15)]];
                vpc += 65;
                break;
            case 2450:  //frequency 1 ExpressionStatement_13
                data[code[vpc + (-10)]] = (string)data[code[vpc + (14)]] + (string)data[code[vpc + (-20)]] + (int)data[code[vpc + (12)]] + (string)data[code[vpc + (24)]];
                vpc += 59;
                break;
            case 7440:  //frequency 2 ExpressionStatement_7
                data[code[vpc + (-3)]] = (string)data[code[vpc + (-15)]] + (string)data[code[vpc + (-20)]];
                vpc += 57;
                break;
            case 9926:  //frequency 1 ExpressionStatement_21
                data[code[vpc + (-1)]] = (string)data[code[vpc + (-10)]] + (string)data[code[vpc + (-7)]] + (int)data[code[vpc + (11)]];
                vpc += 73;
                break;
            case 4975:  //frequency 1 ExpressionStatement_6
                data[code[vpc + (11)]] = car.GetEngine().GetPiston((int)data[code[vpc + (27)]] - (int)data[code[vpc + (4)]]).ToString();
                vpc += 70;
                break;
            case 9534:  //frequency 1 ReturnStatement_22
                return (string)data[code[vpc + (3)]];
                vpc += 51;
            case 5955:  //frequency 1 WhileStatementSyntax_12
                data[code[vpc + (-18)]] = (bool)data[code[vpc + (-5)]] ? (int)data[code[vpc + (23)]] : (int)data[code[vpc + (-15)]];
                vpc += (int)data[code[vpc + (-18)]];
                break;
            case 9957:  //frequency 1 ExpressionStatement_3
                data[code[vpc + (23)]] = (string)data[code[vpc + (2)]] + (string)data[code[vpc + (7)]] + (double)data[code[vpc + (20)]] + (string)data[code[vpc + (-19)]];
                vpc += 56;
                break;
            case 3017:  //frequency 2 ExpressionStatement_11
                data[code[vpc + (23)]] = (int)data[code[vpc + (-14)]] < ReturnArg_Array((int)data[code[vpc + (11)]]);
                vpc += 66;
                break;
            case 4319:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (17)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (20)]]).Count;
                vpc += 54;
                break;
            case 6484:  //frequency 1 ExpressionStatement_20
                data[code[vpc + (10)]] = ((string[])data[code[vpc + (-3)]]).Length;
                vpc += 53;
                break;
            case 5928:  //frequency 1 ExpressionStatement_2
                data[code[vpc + (7)]] = ((ConsoleCalculator.Piston)data[code[vpc + (5)]]).GetSize();
                vpc += 62;
                break;
            case 9092:  //frequency 1 ExpressionStatement_15
                data[code[vpc + (-11)]] = (string)data[code[vpc + (-2)]] + (string)data[code[vpc + (-19)]] + (string)data[code[vpc + (-1)]];
                vpc += 72;
                break;
            case 8387:  //frequency 1 ExpressionStatement_16
                ((string[])data[code[vpc + (-6)]])[(int)data[code[vpc + (10)]]] = (string)data[code[vpc + (9)]];
                vpc += 61;
                break;
            case 1386:  //frequency 1 ExpressionStatement_17
                data[code[vpc + (9)]] = (int)data[code[vpc + (15)]] + (int)data[code[vpc + (-8)]];
                vpc += 69;
                break;
            case 9559:  //frequency 1 ExpressionStatement_4
                data[code[vpc + (-15)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(car.GetEngine().GetPistons());
                vpc += 59;
                break;
            case 9274:  //frequency 1 ExpressionStatement_1
                data[code[vpc + (-18)]] = (ConsoleCalculator.Piston)(car.GetEngine().GetPistons().First());
                vpc += 64;
                break;
            case 9493:  //frequency 1 ExpressionStatement_9
                data[code[vpc + (18)]] = (string[])(new string[(int)data[code[vpc + (-5)]]]);
                vpc += 59;
                break;
            case 4266:  //frequency 1 ExpressionStatement_0
                data[code[vpc + (-8)]] = (string)data[code[vpc + (10)]] + (int)data[code[vpc + (21)]] + (int)data[code[vpc + (7)]] + (string)data[code[vpc + (17)]];
                vpc += 72;
                break;
            default:  //frequency 0 
                break;
        }
    }

    return null;
}

private object InstanceInterpreterVirtualization_TraceLoopTests_132_op4_in5(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 7409:  //frequency 1 ExpressionStatement_3
                data[code[vpc + (17)]] = car.GetEngine().GetPistons().Count;
                vpc += 56;
                break;
            case 4353:  //frequency 1 WhileStatementSyntax_10
                data[code[vpc + (20)]] = (bool)data[code[vpc + (-1)]] ? (int)data[code[vpc + (22)]] : (int)data[code[vpc + (10)]];
                vpc += (int)data[code[vpc + (20)]];
                break;
            case 7151:  //frequency 1 ExpressionStatement_19
                data[code[vpc + (-19)]] = (string)data[code[vpc + (-4)]] + (string)data[code[vpc + (2)]] + (int)data[code[vpc + (23)]];
                vpc += 54;
                break;
            case 5197:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (10)]] = (string)data[code[vpc + (13)]] + ((ConsoleCalculator.Piston)data[code[vpc + (-4)]]).ToString();
                vpc += 58;
                break;
            case 1570:  //frequency 1 ExpressionStatement_2
                data[code[vpc + (14)]] = (string)data[code[vpc + (15)]] + (string)data[code[vpc + (26)]] + (double)data[code[vpc + (-17)]] + (string)data[code[vpc + (5)]];
                vpc += 55;
                break;
            case 7715:  //frequency 1 ExpressionStatement_11
                data[code[vpc + (-1)]] = (string)data[code[vpc + (13)]] + (string)data[code[vpc + (11)]] + (int)data[code[vpc + (-3)]] + (string)data[code[vpc + (-2)]];
                vpc += 69;
                break;
            case 5691:  //frequency 1 ExpressionStatement_13
                data[code[vpc + (23)]] = (string)data[code[vpc + (-16)]] + (string)data[code[vpc + (1)]] + (string)data[code[vpc + (26)]];
                vpc += 56;
                break;
            case 7702:  //frequency 1 ExpressionStatement_17
                vpc += (int)data[code[vpc + (-9)]];
                vpc += 53;
                break;
            case 3871:  //frequency 1 ExpressionStatement_1
                data[code[vpc + (-19)]] = car.GetEngine().GetPistons().First().GetSize();
                vpc += 68;
                break;
            case 1184:  //frequency 1 ExpressionStatement_15
                data[code[vpc + (10)]] = (int)data[code[vpc + (14)]] + (int)data[code[vpc + (20)]];
                vpc += 66;
                break;
            case 6384:  //frequency 1 ReturnStatement_20
                return (string)data[code[vpc + (3)]];
                vpc += 57;
            case 3135:  //frequency 1 ExpressionStatement_14
                ((string[])data[code[vpc + (27)]])[(int)data[code[vpc + (-8)]]] = (string)data[code[vpc + (28)]];
                vpc += 63;
                break;
            case 6168:  //frequency 1 ExpressionStatement_12
                data[code[vpc + (-4)]] = (string)data[code[vpc + (14)]] + (string)data[code[vpc + (18)]];
                vpc += 67;
                break;
            case 4246:  //frequency 2 ExpressionStatement_6
                data[code[vpc + (11)]] = data[code[vpc + (27)]];
                vpc += 63;
                break;
            default:  //frequency 0 
                break;
            case 7032:  //frequency 1 ExpressionStatement_0
                data[code[vpc + (-9)]] = (string)data[code[vpc + (21)]] + (int)data[code[vpc + (-6)]] + (int)data[code[vpc + (9)]] + (string)data[code[vpc + (6)]];
                vpc += 66;
                break;
            case 9817:  //frequency 1 ExpressionStatement_4
                data[code[vpc + (-5)]] = (ConsoleCalculator.Piston)(car.GetEngine().GetPiston((int)data[code[vpc + (-9)]] - (int)data[code[vpc + (3)]]));
                vpc += 66;
                break;
            case 7729:  //frequency 1 ExpressionStatement_18
                data[code[vpc + (12)]] = ((string[])data[code[vpc + (11)]]).Length;
                vpc += 53;
                break;
            case 8969:  //frequency 2 ExpressionStatement_9
                data[code[vpc + (-1)]] = (int)data[code[vpc + (-15)]] < ReturnArg_Array((int)data[code[vpc + (7)]]);
                vpc += 60;
                break;
            case 4401:  //frequency 1 ExpressionStatement_7
                data[code[vpc + (28)]] = (string[])(new string[(int)data[code[vpc + (3)]]]);
                vpc += 63;
                break;
        }
    }

    return null;
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

private object InstanceInterpreterVirtualization_TraceLoopTests_913_2_op4_in2(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 9852:  //frequency 2 ExpressionStatement_7
                data[code[vpc + (7)]] = (string)data[code[vpc + (26)]] + (string)data[code[vpc + (2)]];
                vpc += 59;
                break;
            default:  //frequency 0 
                break;
            case 6067:  //frequency 1 ExpressionStatement_29
                data[code[vpc + (-5)]] = ((string[])data[code[vpc + (8)]]).Length;
                vpc += 53;
                break;
            case 8188:  //frequency 1 ExpressionStatement_21
                data[code[vpc + (-5)]] = (string)data[code[vpc + (13)]] + (string)data[code[vpc + (-2)]] + (double)data[code[vpc + (-4)]] + (string)data[code[vpc + (11)]];
                vpc += 61;
                break;
            case 6007:  //frequency 1 ExpressionStatement_24
                ((string[])data[code[vpc + (5)]])[(int)data[code[vpc + (21)]]] = (string)data[code[vpc + (6)]];
                vpc += 63;
                break;
            case 7907:  //frequency 1 ExpressionStatement_25
                data[code[vpc + (-18)]] = (int)data[code[vpc + (17)]] + (int)data[code[vpc + (22)]];
                vpc += 62;
                break;
            case 6991:  //frequency 1 ExpressionStatement_16
                data[code[vpc + (-15)]] = (string)data[code[vpc + (-8)]] + (string)data[code[vpc + (22)]] + (string)data[code[vpc + (-10)]];
                vpc += 61;
                break;
            case 1508:  //frequency 1 ReturnStatement_31
                return (string)data[code[vpc + (19)]];
                vpc += 68;
            case 6045:  //frequency 1 ExpressionStatement_30
                data[code[vpc + (-8)]] = (string)data[code[vpc + (19)]] + (string)data[code[vpc + (-3)]] + (int)data[code[vpc + (-17)]];
                vpc += 61;
                break;
            case 4169:  //frequency 1 ExpressionStatement_28
                vpc += (int)data[code[vpc + (17)]];
                vpc += 65;
                break;
            case 5350:  //frequency 1 WhileStatementSyntax_13
                data[code[vpc + (17)]] = (bool)data[code[vpc + (6)]] ? (int)data[code[vpc + (-13)]] : (int)data[code[vpc + (21)]];
                vpc += (int)data[code[vpc + (17)]];
                break;
            case 4592:  //frequency 2 ExpressionStatement_12
                data[code[vpc + (15)]] = (int)data[code[vpc + (-15)]] < (int)data[code[vpc + (16)]];
                vpc += 58;
                break;
            case 6602:  //frequency 1 ExpressionStatement_4
                data[code[vpc + (10)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-1)]]).Count;
                vpc += 62;
                break;
            case 8147:  //frequency 1 ExpressionStatement_6
                data[code[vpc + (9)]] = ((ConsoleCalculator.Piston)data[code[vpc + (4)]]).ToString();
                vpc += 65;
                break;
            case 3603:  //frequency 3 ExpressionStatement_1
                data[code[vpc + (-11)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                vpc += 60;
                break;
            case 3768:  //frequency 2 ExpressionStatement_8
                data[code[vpc + (18)]] = data[code[vpc + (-6)]];
                vpc += 63;
                break;
            case 5550:  //frequency 2 ExpressionStatement_3
                data[code[vpc + (18)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (-2)]]).GetPistons());
                vpc += 64;
                break;
            case 5836:  //frequency 2 ExpressionStatement_11
                data[code[vpc + (11)]] = ReturnArg_Array((int)data[code[vpc + (3)]]);
                vpc += 58;
                break;
            case 6308:  //frequency 1 ExpressionStatement_22
                data[code[vpc + (13)]] = ((string)data[code[vpc + (3)]]).Length;
                vpc += 71;
                break;
            case 8744:  //frequency 1 ExpressionStatement_0
                data[code[vpc + (5)]] = (string)data[code[vpc + (22)]] + (int)data[code[vpc + (-16)]] + (int)data[code[vpc + (-7)]] + (string)data[code[vpc + (-3)]];
                vpc += 66;
                break;
            case 5954:  //frequency 1 ExpressionStatement_23
                data[code[vpc + (-6)]] = (string)data[code[vpc + (4)]] + (int)data[code[vpc + (11)]];
                vpc += 69;
                break;
            case 3761:  //frequency 1 ExpressionStatement_14
                data[code[vpc + (7)]] = (string)data[code[vpc + (20)]] + (string)data[code[vpc + (-6)]] + (int)data[code[vpc + (-18)]] + (string)data[code[vpc + (11)]];
                vpc += 71;
                break;
            case 3067:  //frequency 1 ExpressionStatement_19
                data[code[vpc + (-14)]] = (ConsoleCalculator.Piston)(((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (26)]]).First());
                vpc += 58;
                break;
            case 1734:  //frequency 1 ExpressionStatement_20
                data[code[vpc + (7)]] = ((ConsoleCalculator.Piston)data[code[vpc + (-11)]]).GetSize();
                vpc += 67;
                break;
            case 1972:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (-2)]] = (ConsoleCalculator.Piston)(((ConsoleCalculator.Engine)data[code[vpc + (-12)]]).GetPiston((int)data[code[vpc + (10)]] - (int)data[code[vpc + (11)]]));
                vpc += 65;
                break;
            case 4038:  //frequency 1 ExpressionStatement_9
                data[code[vpc + (2)]] = (string[])(new string[(int)data[code[vpc + (20)]]]);
                vpc += 62;
                break;
        }
    }

    return null;
}

private object InstanceInterpreterVirtualization_TraceLoopTests_2835_2_op4_in3(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 7415:  //frequency 1 ExpressionStatement_23
                vpc += (int)data[code[vpc + (-15)]];
                vpc += 64;
                break;
            case 4449:  //frequency 1 ReturnStatement_26
                return (string)data[code[vpc + (5)]];
                vpc += 63;
            case 8970:  //frequency 1 ExpressionStatement_1
                data[code[vpc + (17)]] = (ConsoleCalculator.Engine)(car.GetEngine());
                vpc += 65;
                break;
            case 3792:  //frequency 1 ExpressionStatement_3
                data[code[vpc + (-7)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-16)]]).Count;
                vpc += 60;
                break;
            case 1335:  //frequency 1 ExpressionStatement_22
                data[code[vpc + (-9)]] = (int)data[code[vpc + (-6)]] < ReturnArg_Array((int)data[code[vpc + (-10)]]);
                vpc += 57;
                break;
            case 1395:  //frequency 1 ExpressionStatement_0
                data[code[vpc + (-17)]] = (string)data[code[vpc + (13)]] + (int)data[code[vpc + (-1)]] + (int)data[code[vpc + (12)]] + (string)data[code[vpc + (8)]];
                vpc += 66;
                break;
            case 6641:  //frequency 1 ExpressionStatement_21
                data[code[vpc + (5)]] = (int)data[code[vpc + (20)]] + (int)data[code[vpc + (14)]];
                vpc += 58;
                break;
            case 1132:  //frequency 1 ExpressionStatement_18
                data[code[vpc + (25)]] = ((string)data[code[vpc + (13)]]).Length;
                vpc += 55;
                break;
            case 1164:  //frequency 1 ExpressionStatement_20
                ((string[])data[code[vpc + (17)]])[(int)data[code[vpc + (-12)]]] = (string)data[code[vpc + (-7)]];
                vpc += 64;
                break;
            case 2578:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (-14)]] = (string)data[code[vpc + (8)]] + ((ConsoleCalculator.Piston)data[code[vpc + (12)]]).ToString();
                vpc += 58;
                break;
            case 5450:  //frequency 1 WhileStatementSyntax_11
                data[code[vpc + (1)]] = (bool)data[code[vpc + (14)]] ? (int)data[code[vpc + (-15)]] : (int)data[code[vpc + (10)]];
                vpc += (int)data[code[vpc + (1)]];
                break;
            case 3200:  //frequency 1 ExpressionStatement_10
                data[code[vpc + (7)]] = (int)data[code[vpc + (18)]] < (int)data[code[vpc + (4)]];
                vpc += 59;
                break;
            case 3718:  //frequency 1 ExpressionStatement_2
                data[code[vpc + (2)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(((ConsoleCalculator.Engine)data[code[vpc + (18)]]).GetPistons());
                vpc += 67;
                break;
            case 4590:  //frequency 2 ExpressionStatement_6
                data[code[vpc + (20)]] = data[code[vpc + (-5)]];
                vpc += 58;
                break;
            case 1197:  //frequency 1 ExpressionStatement_13
                data[code[vpc + (-19)]] = (string)data[code[vpc + (29)]] + (string)data[code[vpc + (-5)]];
                vpc += 61;
                break;
            case 1849:  //frequency 1 ExpressionStatement_25
                data[code[vpc + (3)]] = (string)data[code[vpc + (-13)]] + (string)data[code[vpc + (28)]] + (int)data[code[vpc + (8)]];
                vpc += 72;
                break;
            case 7703:  //frequency 1 ExpressionStatement_15
                data[code[vpc + (1)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(car.GetEngine().GetPistons());
                vpc += 67;
                break;
            case 1364:  //frequency 1 ExpressionStatement_7
                data[code[vpc + (-7)]] = (string[])(new string[(int)data[code[vpc + (-1)]]]);
                vpc += 60;
                break;
            case 9526:  //frequency 1 ExpressionStatement_9
                data[code[vpc + (28)]] = ReturnArg_Array((int)data[code[vpc + (-11)]]);
                vpc += 70;
                break;
            case 2262:  //frequency 1 ExpressionStatement_17
                data[code[vpc + (19)]] = (string)data[code[vpc + (-13)]] + (string)data[code[vpc + (10)]] + (double)data[code[vpc + (-16)]] + (string)data[code[vpc + (7)]];
                vpc += 71;
                break;
            case 8314:  //frequency 1 ExpressionStatement_24
                data[code[vpc + (-2)]] = ((string[])data[code[vpc + (-15)]]).Length;
                vpc += 71;
                break;
            case 7974:  //frequency 1 ExpressionStatement_12
                data[code[vpc + (-15)]] = (string)data[code[vpc + (27)]] + (string)data[code[vpc + (-6)]] + (int)data[code[vpc + (-2)]] + (string)data[code[vpc + (22)]];
                vpc += 62;
                break;
            case 1510:  //frequency 1 ExpressionStatement_19
                data[code[vpc + (15)]] = (string)data[code[vpc + (-15)]] + (int)data[code[vpc + (19)]];
                vpc += 59;
                break;
            case 2505:  //frequency 1 ExpressionStatement_4
                data[code[vpc + (27)]] = (ConsoleCalculator.Piston)(car.GetEngine().GetPiston((int)data[code[vpc + (-9)]] - (int)data[code[vpc + (-6)]]));
                vpc += 53;
                break;
            default:  //frequency 0 
                break;
            case 7817:  //frequency 1 ExpressionStatement_14
                data[code[vpc + (-18)]] = (string)data[code[vpc + (21)]] + (string)data[code[vpc + (-20)]] + (string)data[code[vpc + (24)]];
                vpc += 67;
                break;
            case 6319:  //frequency 1 ExpressionStatement_16
                data[code[vpc + (20)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (9)]]).First().GetSize();
                vpc += 70;
                break;
        }
    }

    return null;
}

private object InstanceInterpreterVirtualization_TraceLoopTests_1236_2_op4_in4(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 2933:  //frequency 1 ExpressionStatement_2
                data[code[vpc + (25)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (-17)]]).Count;
                vpc += 60;
                break;
            case 4422:  //frequency 1 WhileStatementSyntax_9
                data[code[vpc + (-11)]] = (bool)data[code[vpc + (14)]] ? (int)data[code[vpc + (-1)]] : (int)data[code[vpc + (26)]];
                vpc += (int)data[code[vpc + (-11)]];
                break;
            case 2506:  //frequency 2 ExpressionStatement_5
                data[code[vpc + (5)]] = data[code[vpc + (-6)]];
                vpc += 64;
                break;
            case 6071:  //frequency 1 ExpressionStatement_22
                data[code[vpc + (-19)]] = ((string[])data[code[vpc + (23)]]).Length;
                vpc += 62;
                break;
            case 5044:  //frequency 1 ExpressionStatement_15
                data[code[vpc + (-4)]] = (string)data[code[vpc + (25)]] + (string)data[code[vpc + (23)]] + (double)data[code[vpc + (10)]] + (string)data[code[vpc + (13)]];
                vpc += 73;
                break;
            case 1624:  //frequency 1 ExpressionStatement_16
                data[code[vpc + (-9)]] = ((string)data[code[vpc + (26)]]).Length;
                vpc += 53;
                break;
            case 7895:  //frequency 2 ExpressionStatement_8
                data[code[vpc + (-1)]] = (int)data[code[vpc + (17)]] < ReturnArg_Array((int)data[code[vpc + (24)]]);
                vpc += 54;
                break;
            case 6453:  //frequency 2 ExpressionStatement_4
                data[code[vpc + (13)]] = (string)data[code[vpc + (29)]] + (string)data[code[vpc + (-12)]];
                vpc += 65;
                break;
            case 6090:  //frequency 2 ExpressionStatement_1
                data[code[vpc + (-17)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(car.GetEngine().GetPistons());
                vpc += 58;
                break;
            case 2924:  //frequency 1 ExpressionStatement_14
                data[code[vpc + (-15)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (2)]]).First().GetSize();
                vpc += 57;
                break;
            default:  //frequency 0 
                break;
            case 7526:  //frequency 1 ExpressionStatement_0
                data[code[vpc + (5)]] = (string)data[code[vpc + (9)]] + (int)data[code[vpc + (-13)]] + (int)data[code[vpc + (19)]] + (string)data[code[vpc + (29)]];
                vpc += 63;
                break;
            case 4453:  //frequency 1 ExpressionStatement_21
                vpc += (int)data[code[vpc + (27)]];
                vpc += 55;
                break;
            case 8517:  //frequency 1 ExpressionStatement_10
                data[code[vpc + (-1)]] = (string)data[code[vpc + (16)]] + (string)data[code[vpc + (7)]] + (int)data[code[vpc + (3)]] + (string)data[code[vpc + (12)]];
                vpc += 60;
                break;
            case 9963:  //frequency 1 ExpressionStatement_17
                data[code[vpc + (22)]] = (string)data[code[vpc + (26)]] + (int)data[code[vpc + (-20)]];
                vpc += 53;
                break;
            case 5643:  //frequency 1 ExpressionStatement_19
                data[code[vpc + (7)]] = (int)data[code[vpc + (-3)]] + (int)data[code[vpc + (28)]];
                vpc += 56;
                break;
            case 4043:  //frequency 1 ReturnStatement_24
                return (string)data[code[vpc + (-8)]];
                vpc += 56;
            case 7925:  //frequency 1 ExpressionStatement_6
                data[code[vpc + (1)]] = (string[])(new string[(int)data[code[vpc + (-8)]]]);
                vpc += 59;
                break;
            case 2516:  //frequency 1 ExpressionStatement_18
                ((string[])data[code[vpc + (20)]])[(int)data[code[vpc + (11)]]] = (string)data[code[vpc + (-2)]];
                vpc += 67;
                break;
            case 9729:  //frequency 1 ExpressionStatement_3
                data[code[vpc + (-4)]] = car.GetEngine().GetPiston((int)data[code[vpc + (4)]] - (int)data[code[vpc + (-3)]]).ToString();
                vpc += 65;
                break;
            case 9232:  //frequency 1 ExpressionStatement_12
                data[code[vpc + (21)]] = (string)data[code[vpc + (8)]] + (string)data[code[vpc + (1)]] + (string)data[code[vpc + (28)]];
                vpc += 55;
                break;
            case 8607:  //frequency 1 ExpressionStatement_23
                data[code[vpc + (10)]] = (string)data[code[vpc + (11)]] + (string)data[code[vpc + (12)]] + (int)data[code[vpc + (28)]];
                vpc += 54;
                break;
        }
    }

    return null;
}

private object InstanceInterpreterVirtualization_TraceLoopTests_2145_2_op4_in5(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 4256:  //frequency 1 ExpressionStatement_11
                data[code[vpc + (26)]] = (string)data[code[vpc + (10)]] + (string)data[code[vpc + (20)]] + (string)data[code[vpc + (-7)]];
                vpc += 57;
                break;
            case 8019:  //frequency 1 ExpressionStatement_14
                data[code[vpc + (10)]] = (string)data[code[vpc + (-3)]] + (string)data[code[vpc + (-20)]] + (double)data[code[vpc + (1)]] + (string)data[code[vpc + (3)]];
                vpc += 59;
                break;
            case 8243:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (-5)]] = (string[])(new string[(int)data[code[vpc + (11)]]]);
                vpc += 68;
                break;
            case 7576:  //frequency 1 ExpressionStatement_18
                data[code[vpc + (15)]] = (int)data[code[vpc + (3)]] + (int)data[code[vpc + (23)]];
                vpc += 69;
                break;
            default:  //frequency 0 
                break;
            case 1733:  //frequency 1 ExpressionStatement_15
                data[code[vpc + (29)]] = ((string)data[code[vpc + (-19)]]).Length;
                vpc += 59;
                break;
            case 5692:  //frequency 1 ExpressionStatement_3
                data[code[vpc + (21)]] = (string)data[code[vpc + (22)]] + ((ConsoleCalculator.Piston)data[code[vpc + (-14)]]).ToString();
                vpc += 70;
                break;
            case 1317:  //frequency 1 ExpressionStatement_10
                data[code[vpc + (13)]] = (string)data[code[vpc + (-2)]] + (string)data[code[vpc + (-5)]];
                vpc += 55;
                break;
            case 9041:  //frequency 2 ExpressionStatement_4
                data[code[vpc + (20)]] = data[code[vpc + (5)]];
                vpc += 53;
                break;
            case 5734:  //frequency 1 ExpressionStatement_0
                data[code[vpc + (-13)]] = (string)data[code[vpc + (9)]] + (int)data[code[vpc + (13)]] + (int)data[code[vpc + (-9)]] + (string)data[code[vpc + (5)]];
                vpc += 71;
                break;
            case 5821:  //frequency 1 ExpressionStatement_22
                data[code[vpc + (-6)]] = (string)data[code[vpc + (12)]] + (string)data[code[vpc + (21)]] + (int)data[code[vpc + (13)]];
                vpc += 62;
                break;
            case 9444:  //frequency 1 ExpressionStatement_16
                data[code[vpc + (7)]] = (string)data[code[vpc + (-14)]] + (int)data[code[vpc + (22)]];
                vpc += 58;
                break;
            case 3168:  //frequency 1 ExpressionStatement_20
                vpc += (int)data[code[vpc + (-3)]];
                vpc += 56;
                break;
            case 6978:  //frequency 1 ExpressionStatement_1
                data[code[vpc + (28)]] = car.GetEngine().GetPistons().Count;
                vpc += 67;
                break;
            case 2437:  //frequency 1 WhileStatementSyntax_8
                data[code[vpc + (26)]] = (bool)data[code[vpc + (-17)]] ? (int)data[code[vpc + (2)]] : (int)data[code[vpc + (-4)]];
                vpc += (int)data[code[vpc + (26)]];
                break;
            case 1116:  //frequency 1 ExpressionStatement_2
                data[code[vpc + (25)]] = (ConsoleCalculator.Piston)(car.GetEngine().GetPiston((int)data[code[vpc + (-8)]] - (int)data[code[vpc + (-3)]]));
                vpc += 59;
                break;
            case 6137:  //frequency 1 ReturnStatement_23
                return (string)data[code[vpc + (24)]];
                vpc += 67;
            case 9680:  //frequency 1 ExpressionStatement_21
                data[code[vpc + (27)]] = ((string[])data[code[vpc + (16)]]).Length;
                vpc += 56;
                break;
            case 9664:  //frequency 1 ExpressionStatement_12
                data[code[vpc + (28)]] = (System.Collections.Generic.List<ConsoleCalculator.Piston>)(car.GetEngine().GetPistons());
                vpc += 63;
                break;
            case 5180:  //frequency 1 ExpressionStatement_17
                ((string[])data[code[vpc + (2)]])[(int)data[code[vpc + (-7)]]] = (string)data[code[vpc + (17)]];
                vpc += 54;
                break;
            case 9597:  //frequency 1 ExpressionStatement_13
                data[code[vpc + (-12)]] = ((System.Collections.Generic.List<ConsoleCalculator.Piston>)data[code[vpc + (24)]]).First().GetSize();
                vpc += 66;
                break;
            case 7138:  //frequency 1 ExpressionStatement_9
                data[code[vpc + (3)]] = (string)data[code[vpc + (14)]] + (string)data[code[vpc + (10)]] + (int)data[code[vpc + (21)]] + (string)data[code[vpc + (8)]];
                vpc += 68;
                break;
            case 8931:  //frequency 2 ExpressionStatement_7
                data[code[vpc + (2)]] = (int)data[code[vpc + (25)]] < ReturnArg_Array((int)data[code[vpc + (-17)]]);
                vpc += 56;
                break;
        }
    }

    return null;
}

  
        



    }
}