using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Tracing
{
    class BasicOperations
    {

        public static void RunBasicTests()
        {
            BasicOperations bo = new BasicOperations();
//            bo.FactorialRecursive_Check();

            
        }


        string OperationOrder_String()
        {
            int a = 20;
            int b = 10;
            int c = 15;
            int d = 5;
            int e = 2;
            double sum = 1.0;
            string result = "";

            sum += 1;
            result += sum + a + b + c;
            sum += (a - b) * (c - d) + a + d;
            result += sum;
            sum += a * b + c / d * e + 2 + 7 % 3;
            result += sum;

            return result;
        }

        private void FactorialRecursive_Check()
        {
            string testName = "Trace#FactorialRecursive_Check";
            Program.Start_Check(testName);
            bool condition = true;

            int b = 5;
            if (Program.args_in.Count() > 0)
            {
                string loop_count = Program.args_in[0];
                int nr = Int32.Parse(loop_count);
                b = nr;
            }

            long oracle = FactorialRecursive_original(b);
            //            string oracle2 = ForSimple_Array_original_in(b);
            //
            long ref1 = FactorialRecursive_ref_op2_in1(b);
            long ref2 = FactorialRecursive_ref_op3_in1(b);
            long ref3 = FactorialRecursive_ref_op4_in1(b);
//            string ref4 = ForSimple_Array_refactored_op4_in4(b);
//            string ref5 = ForSimple_Array_refactored_op4_in5(b);
//
            Debug.Assert(ref1.Equals(oracle), "ref1");
            Debug.Assert(ref2.Equals(oracle), "ref2");
            Debug.Assert(ref3.Equals(oracle), "ref3");
//            Debug.Assert(ref4.Equals(oracle), "ref4");
//            Debug.Assert(ref5.Equals(oracle), "ref5");
            bool refactoredCheck = ref1.Equals(oracle) &&
                                   ref2.Equals(oracle) && 
                                   ref3.Equals(oracle)                                                                      
                                   ;

            long virt1 = FactorialRecursive_obf_op2_in1(b);
            Debug.Assert(virt1.Equals(oracle), "virt1");

            long virt2 = FactorialRecursive_obf_op3_in1(b);
            Debug.Assert(virt2.Equals(oracle), "virt2");

            long virt3 = FactorialRecursive_obf_op4_in1(b);
            Debug.Assert(virt3.Equals(oracle), "virt3");

//            string virt4 = ForSimple_Array_obfuscated_op4_in4(b);
//            Debug.Assert(virt4.Equals(oracle), "virt4");
//
//            string virt5 = ForSimple_Array_obfuscated_op4_in5(b);
//            Debug.Assert(virt5.Equals(oracle), "virt5");
//
//
//            string virt21 = ForSimple_Array_obfuscated2_op4_in1(b);
//            Debug.Assert(virt21.Equals(oracle2), "virt21");
//
//            string virt22 = ForSimple_Array_obfuscated2_op4_in2(b);
//            Debug.Assert(virt22.Equals(oracle2), "virt22");
//
//            string virt23 = ForSimple_Array_obfuscated2_op4_in3(b);
//            Debug.Assert(virt23.Equals(oracle2), "virt23");
//
//            string virt24 = ForSimple_Array_obfuscated2_op4_in4(b);
//            Debug.Assert(virt24.Equals(oracle2), "virt24");
//
//            string virt25 = ForSimple_Array_obfuscated2_op4_in5(b);
//            Debug.Assert(virt25.Equals(oracle2), "virt25");
//
            bool virtualizedCheck = virt1.Equals(oracle) &&
                                  virt2.Equals(oracle) && 
                                  virt3.Equals(oracle)  
                                  ;
//
//            bool virtualizedCheck2 = virt21.Equals(oracle2) &&
//                                  virt22.Equals(oracle2) && virt23.Equals(oracle2) && virt24.Equals(oracle2)
//                                  && virt25.Equals(oracle2);

            Console.WriteLine("\n{0}\n{1}", oracle, "oracle2");
            condition = refactoredCheck 
                && virtualizedCheck 
                ;
            Program.End_Check(testName, condition);
        }

public static long FactorialRecursive_original(int num)
{
    int c = 0;
    int a = 20;
    int b = 10;            
    int d = 5;
    int e = 2;
    double sum = 1.0;
    string result = "FactorialRecursive_original";

    sum += 1 + num;
    result += sum + a + b + c;
    sum += (a - b) * (c - d) + a + d;
    result += sum;
    sum += a * b + c / d * e + 2 + 7 % 3 + num;
    result += sum;
    Console.WriteLine("{0} {1}", "result", result);
    Console.WriteLine("{0} {1}", "fact", num);
    if (num == 0)
    {
        return 1;
    }

    return num * FactorialRecursive_original(num - 1);
}

        #region REFACTORED
//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
public static long FactorialRecursive_ref_op2_in1(int num)
{
    int c = 0;
    int a = 20;
    int b = 10;
    int d = 5;
    int e = 2;
    double sum = 1.0 + 0.0;
    string result = "FactorialRecursive_ref_op2_in1";
    int addTemp_0 = 1 + num;
    sum = sum + addTemp_0;
    double addTemp_1 = sum + a;
    double addTemp_2 = addTemp_1 + b;
    double addTemp_3 = addTemp_2 + c;
    result = result + addTemp_3;
    int parTemp_0 = a - b;
    int parTemp_1 = c - d;
    int mulTemp_0 = parTemp_0 * parTemp_1;
    int addTemp_4 = mulTemp_0 + a;
    int addTemp_5 = addTemp_4 + d;
    sum = sum + addTemp_5;
    result = result + sum;
    int mulTemp_1 = a * b;
    int mulTemp_2 = c / d;
    int mulTemp_3 = mulTemp_2 * e;
    int mulTemp_4 = 7 % 3;
    int addTemp_6 = mulTemp_1 + mulTemp_3;
    int addTemp_7 = addTemp_6 + 2;
    int addTemp_8 = addTemp_7 + mulTemp_4;
    int addTemp_9 = addTemp_8 + num;
    sum = sum + addTemp_9;
    result = result + sum;
    Console.WriteLine("{0} {1}", "result", result);
    Console.WriteLine("{0} {1}", "fact", num);
    bool var_ifCondition_0 = num == 0;
    if (var_ifCondition_0)
    {
        return 1;
    }

    int addTemp_10 = num - 1;
    long invocationTemp_0 = FactorialRecursive_ref_op2_in1(addTemp_10);
    long mulTemp_5 = num * invocationTemp_0;
    return mulTemp_5;
}

//                [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
public static long FactorialRecursive_ref_op3_in1(int num)
{
    int c = 0;
    int a = 20;
    int b = 10;
    int d = 5;
    int e = 2;
    double sum = 1.0 + 0.0;
    string result = "FactorialRecursive_ref_op3_in1";
    sum = sum + 1 + num;
    double addTemp_0 = sum + a + b;
    result = result + addTemp_0 + c;
    int parTemp_0 = c - d;
    int mulTemp_0 = (a - b) * parTemp_0;
    int addTemp_1 = mulTemp_0 + a;
    sum = sum + addTemp_1 + d;
    result = result + sum;
    int mulTemp_1 = a * b;
    int mulTemp_2 = c / d;
    int mulTemp_3 = mulTemp_2 * e;
    int mulTemp_4 = 7 % 3;
    int addTemp_2 = mulTemp_1 + mulTemp_3 + 2;
    int addTemp_3 = addTemp_2 + mulTemp_4 + num;
    sum = sum + addTemp_3;
    result = result + sum;
    Console.WriteLine("{0} {1}", "result", result);
    Console.WriteLine("{0} {1}", "fact", num);
    bool var_ifCondition_0 = num == 0;
    if (var_ifCondition_0)
    {
        return 1;
    }

    long invocationTemp_0 = FactorialRecursive_ref_op3_in1(num - 1);
    long mulTemp_5 = num * invocationTemp_0;
    return mulTemp_5;
}

//                [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
public static long FactorialRecursive_ref_op4_in1(int num)
{
    int c = 0;
    int a = 20;
    int b = 10;
    int d = 5;
    int e = 2;
    double sum = 1.0 + 0.0;
    string result = "FactorialRecursive_ref_op4_in1";
    sum = sum + 1 + num;
    double addTemp_0 = sum + a + b + c;
    result = result + addTemp_0;
    int mulTemp_0 = (a - b) * (c - d);
    int addTemp_1 = mulTemp_0 + a;
    sum = sum + addTemp_1 + d;
    result = result + sum;
    int mulTemp_1 = a * b;
    int mulTemp_2 = c / d;
    int mulTemp_3 = mulTemp_2 * e;
    int mulTemp_4 = 7 % 3;
    int addTemp_2 = mulTemp_1 + mulTemp_3 + 2 + mulTemp_4;
    sum = sum + addTemp_2 + num;
    result = result + sum;
    Console.WriteLine("{0} {1}", "result", result);
    Console.WriteLine("{0} {1}", "fact", num);
    bool var_ifCondition_0 = num == 0;
    if (var_ifCondition_0)
    {
        return 1;
    }

    long invocationTemp_0 = FactorialRecursive_ref_op4_in1(num - 1);
    long mulTemp_5 = num * invocationTemp_0;
    return mulTemp_5;
}

        #endregion

        #region OBFUSCATED
//                [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
public static long FactorialRecursive_obf_op2_in1(int num)
{
    //Virtualization variables
    int[] code = new int[100781];
    object[] data = new object[4266];
    int vpc = 73;

    //Data init
    data[3021]=num; //num 
    data[331]=0; //0 constant
    data[2333]=20; //20 constant
    data[2989]=10; //10 constant
    data[688]=5; //5 constant
    data[723]=2; //2 constant
    data[1868]=(double)1.0; //1.0 constant
    data[1813]=(double)0.0; //0.0 constant
    data[2053]="FactorialRecursive_obf_op2_in1"; //"FactorialRecursive_obf_op2_in1" constant
    data[1275]=1 ; //1 constant
    data[1689]=7 ; //7 constant
    data[3292]=3; //3 constant
    data[3806]="{0} {1}"; //"{0} {1}" constant
    data[2678]="result"; //"result" constant
    data[3261]="fact"; //"fact" constant
    data[2223]=(long)1; //1 constant
    data[1490]=40; //c 
    data[2472]=560; //a 
    data[517]=-520; //b 
    data[2102]=-432; //d 
    data[2787]=-289; //e 
    data[1673]=(double)0.855914969861468; //sum 
    data[2432]=1917935028; //result 
    data[3826]=412; //addTemp_0 
    data[2506]=(double)0.323075956815423; //addTemp_1 
    data[2555]=(double)0.984736048609361; //addTemp_2 
    data[1867]=(double)0.564394400717874; //addTemp_3 
    data[3937]=-941; //parTemp_0 
    data[3657]=468; //parTemp_1 
    data[1738]=254; //mulTemp_0 
    data[3748]=-98; //addTemp_4 
    data[1437]=-925; //addTemp_5 
    data[3001]=-758; //mulTemp_1 
    data[3008]=712; //mulTemp_2 
    data[494]=557; //mulTemp_3 
    data[3201]=-148; //mulTemp_4 
    data[803]=-755; //addTemp_6 
    data[92]=-589; //addTemp_7 
    data[1662]=-536; //addTemp_8 
    data[2203]=317; //addTemp_9 
    data[2669]=false; //var_ifCondition_0 
    data[1542]=-844; //addTemp_10 
    data[3906]=(long)209L; //invocationTemp_0 
    data[2299]=(long)46L; //mulTemp_5 
    data[2884]=866; //jmpDestinationName_2884 constant
    data[985]=59; //if_GoTo_True_985 constant
    data[1098]=175; //if_GoTo_False_1098 constant
    data[3409]=0; //if_FalseBlockSize_Skip_3409 constant

    //Code init

    code[73]=4093; //ExpressionStatement_0 # ExpressionStatement_0
    code[101]=1490; //c
    code[100]=331; //0

    code[133]=4093; //ExpressionStatement_0 # ExpressionStatement_1
    code[161]=2472; //a
    code[160]=2333; //20

    code[193]=4093; //ExpressionStatement_0 # ExpressionStatement_2
    code[221]=517; //b
    code[220]=2989; //10

    code[253]=4093; //ExpressionStatement_0 # ExpressionStatement_3
    code[281]=2102; //d
    code[280]=688; //5

    code[313]=4093; //ExpressionStatement_0 # ExpressionStatement_4
    code[341]=2787; //e
    code[340]=723; //2

    code[373]=6640; //ExpressionStatement_5 # ExpressionStatement_5
    code[379]=1673; //sum
    code[388]=1868; //1.0
    code[377]=1813; //0.0

    code[428]=4093; //ExpressionStatement_0 # ExpressionStatement_6
    code[456]=2432; //result
    code[455]=2053; //"FactorialRecursive_obf_op2_in1"

    code[488]=4432; //ExpressionStatement_7 # ExpressionStatement_7
    code[471]=3826; //addTemp_0
    code[477]=1275; //1
    code[495]=3021; //num

    code[542]=4195; //ExpressionStatement_8 # ExpressionStatement_8
    code[532]=1673; //sum
    code[550]=1673; //sum
    code[564]=3826; //addTemp_0

    code[601]=4195; //ExpressionStatement_8 # ExpressionStatement_9
    code[591]=2506; //addTemp_1
    code[609]=1673; //sum
    code[623]=2472; //a

    code[660]=4195; //ExpressionStatement_8 # ExpressionStatement_10
    code[650]=2555; //addTemp_2
    code[668]=2506; //addTemp_1
    code[682]=517; //b

    code[719]=4195; //ExpressionStatement_8 # ExpressionStatement_11
    code[709]=1867; //addTemp_3
    code[727]=2555; //addTemp_2
    code[741]=1490; //c

    code[778]=8598; //ExpressionStatement_12 # ExpressionStatement_12
    code[764]=2432; //result
    code[786]=2432; //result
    code[804]=1867; //addTemp_3

    code[838]=9800; //ExpressionStatement_13 # ExpressionStatement_13
    code[847]=3937; //parTemp_0
    code[821]=2472; //a
    code[857]=517; //b

    code[903]=9800; //ExpressionStatement_13 # ExpressionStatement_14
    code[912]=3657; //parTemp_1
    code[886]=1490; //c
    code[922]=2102; //d

    code[968]=9120; //ExpressionStatement_15 # ExpressionStatement_15
    code[989]=1738; //mulTemp_0
    code[957]=3937; //parTemp_0
    code[990]=3657; //parTemp_1

    code[1038]=4432; //ExpressionStatement_7 # ExpressionStatement_16
    code[1021]=3748; //addTemp_4
    code[1027]=1738; //mulTemp_0
    code[1045]=2472; //a

    code[1092]=4432; //ExpressionStatement_7 # ExpressionStatement_17
    code[1075]=1437; //addTemp_5
    code[1081]=3748; //addTemp_4
    code[1099]=2102; //d

    code[1146]=4195; //ExpressionStatement_8 # ExpressionStatement_18
    code[1136]=1673; //sum
    code[1154]=1673; //sum
    code[1168]=1437; //addTemp_5

    code[1205]=8598; //ExpressionStatement_12 # ExpressionStatement_19
    code[1191]=2432; //result
    code[1213]=2432; //result
    code[1231]=1673; //sum

    code[1265]=9120; //ExpressionStatement_15 # ExpressionStatement_20
    code[1286]=3001; //mulTemp_1
    code[1254]=2472; //a
    code[1287]=517; //b

    code[1335]=4574; //ExpressionStatement_21 # ExpressionStatement_21
    code[1317]=3008; //mulTemp_2
    code[1352]=1490; //c
    code[1323]=2102; //d

    code[1400]=9120; //ExpressionStatement_15 # ExpressionStatement_22
    code[1421]=494; //mulTemp_3
    code[1389]=3008; //mulTemp_2
    code[1422]=2787; //e

    code[1470]=9059; //ExpressionStatement_23 # ExpressionStatement_23
    code[1460]=3201; //mulTemp_4
    code[1463]=1689; //7
    code[1458]=3292; //3

    code[1531]=4432; //ExpressionStatement_7 # ExpressionStatement_24
    code[1514]=803; //addTemp_6
    code[1520]=3001; //mulTemp_1
    code[1538]=494; //mulTemp_3

    code[1585]=4432; //ExpressionStatement_7 # ExpressionStatement_25
    code[1568]=92; //addTemp_7
    code[1574]=803; //addTemp_6
    code[1592]=723; //2

    code[1639]=4432; //ExpressionStatement_7 # ExpressionStatement_26
    code[1622]=1662; //addTemp_8
    code[1628]=92; //addTemp_7
    code[1646]=3201; //mulTemp_4

    code[1693]=4432; //ExpressionStatement_7 # ExpressionStatement_27
    code[1676]=2203; //addTemp_9
    code[1682]=1662; //addTemp_8
    code[1700]=3021; //num

    code[1747]=4195; //ExpressionStatement_8 # ExpressionStatement_28
    code[1737]=1673; //sum
    code[1755]=1673; //sum
    code[1769]=2203; //addTemp_9

    code[1806]=8598; //ExpressionStatement_12 # ExpressionStatement_29
    code[1792]=2432; //result
    code[1814]=2432; //result
    code[1832]=1673; //sum

    code[1866]=2161; //ExpressionStatement_30 # ExpressionStatement_30
    code[1880]=3806; //"{0} {1}"
    code[1885]=2678; //"result"
    code[1868]=2432; //result

    code[1934]=7673; //ExpressionStatement_31 # ExpressionStatement_31
    code[1937]=3806; //"{0} {1}"
    code[1941]=3261; //"fact"
    code[1955]=3021; //num

    code[2000]=2211; //ExpressionStatement_32 # ExpressionStatement_32
    code[1996]=2669; //var_ifCondition_0
    code[1988]=3021; //num
    code[1995]=331; //0

    code[2059]=4975; //IfStatementSyntax_33 # IfStatementSyntax_33
    code[2083]=2884; //jmpDestinationName_2884
    code[2074]=2669; //var_ifCondition_0
    code[2057]=985; //if_GoTo_True_985
    code[2070]=1098; //if_GoTo_False_1098

    code[2118]=8109; //ReturnStatement_34 # ReturnStatement_34
    code[2109]=2223; //1

    code[2169]=1339; //ExpressionStatement_35 # ExpressionStatement_35
    code[2191]=3409; //if_FalseBlockSize_Skip_3409

    code[2234]=9800; //ExpressionStatement_13 # ExpressionStatement_36
    code[2243]=1542; //addTemp_10
    code[2217]=3021; //num
    code[2253]=1275; //1

    code[2299]=6636; //ExpressionStatement_37 # ExpressionStatement_37
    code[2296]=3906; //invocationTemp_0
    code[2309]=1542; //addTemp_10

    code[2369]=2274; //ExpressionStatement_38 # ExpressionStatement_38
    code[2362]=2299; //mulTemp_5
    code[2385]=3021; //num
    code[2363]=3906; //invocationTemp_0

    code[2439]=8109; //ReturnStatement_34 # ReturnStatement_39
    code[2430]=2299; //mulTemp_5

    return (long)ClassInterpreterVirtualization_BasicOperations_op2(vpc, data, code);

}

//                [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
public static long FactorialRecursive_obf_op3_in1(int num)
{
    //Virtualization variables
    int[] code = new int[100552];
    object[] data = new object[4415];
    int vpc = 33;

    //Data init
    data[1552]=num; //num 
    data[3414]=0; //0 constant
    data[262]=20; //20 constant
    data[3093]=10; //10 constant
    data[3828]=5; //5 constant
    data[1193]=2; //2 constant
    data[542]=(double)1.0; //1.0 constant
    data[682]=(double)0.0; //0.0 constant
    data[304]="FactorialRecursive_obf_op3_in1"; //"FactorialRecursive_obf_op3_in1" constant
    data[2644]=1 ; //1 constant
    data[436]=7 ; //7 constant
    data[137]=3; //3 constant
    data[1883]="{0} {1}"; //"{0} {1}" constant
    data[3037]="result"; //"result" constant
    data[30]="fact"; //"fact" constant
    data[986]=(long)1; //1 constant
    data[857]=250; //c 
    data[995]=674; //a 
    data[1030]=-887; //b 
    data[3211]=-60; //d 
    data[3549]=-877; //e 
    data[3567]=(double)0.8642980916725; //sum 
    data[135]=1819131924; //result 
    data[1067]=(double)0.850555147440431; //addTemp_0 
    data[1006]=941; //parTemp_0 
    data[3242]=204; //mulTemp_0 
    data[3577]=829; //addTemp_1 
    data[3428]=726; //mulTemp_1 
    data[1973]=-160; //mulTemp_2 
    data[2101]=-676; //mulTemp_3 
    data[2972]=-660; //mulTemp_4 
    data[3357]=-761; //addTemp_2 
    data[3292]=-923; //addTemp_3 
    data[744]=false; //var_ifCondition_0 
    data[907]=(long)-67L; //invocationTemp_0 
    data[3429]=(long)-893L; //mulTemp_5 
    data[3358]=-496; //jmpDestinationName_3358 constant
    data[2980]=73; //if_GoTo_True_2980 constant
    data[1218]=201; //if_GoTo_False_1218 constant
    data[95]=0; //if_FalseBlockSize_Skip_95 constant

    //Code init

    code[33]=6731; //ExpressionStatement_0 # ExpressionStatement_0
    code[61]=857; //c
    code[30]=3414; //0

    code[85]=6731; //ExpressionStatement_0 # ExpressionStatement_1
    code[113]=995; //a
    code[82]=262; //20

    code[137]=6731; //ExpressionStatement_0 # ExpressionStatement_2
    code[165]=1030; //b
    code[134]=3093; //10

    code[189]=6731; //ExpressionStatement_0 # ExpressionStatement_3
    code[217]=3211; //d
    code[186]=3828; //5

    code[241]=6731; //ExpressionStatement_0 # ExpressionStatement_4
    code[269]=3549; //e
    code[238]=1193; //2

    code[293]=8675; //ExpressionStatement_5 # ExpressionStatement_5
    code[283]=3567; //sum
    code[303]=542; //1.0
    code[315]=682; //0.0

    code[358]=6731; //ExpressionStatement_0 # ExpressionStatement_6
    code[386]=135; //result
    code[355]=304; //"FactorialRecursive_obf_op3_in1"

    code[410]=5465; //ExpressionStatement_7 # ExpressionStatement_7
    code[429]=3567; //sum
    code[416]=3567; //sum
    code[397]=2644; //1
    code[403]=1552; //num

    code[480]=5955; //ExpressionStatement_8 # ExpressionStatement_8
    code[473]=1067; //addTemp_0
    code[470]=3567; //sum
    code[474]=995; //a
    code[486]=1030; //b

    code[552]=1986; //ExpressionStatement_9 # ExpressionStatement_9
    code[573]=135; //result
    code[563]=135; //result
    code[572]=1067; //addTemp_0
    code[577]=857; //c

    code[619]=3735; //ExpressionStatement_10 # ExpressionStatement_10
    code[626]=1006; //parTemp_0
    code[629]=857; //c
    code[599]=3211; //d

    code[690]=3838; //ExpressionStatement_11 # ExpressionStatement_11
    code[719]=3242; //mulTemp_0
    code[679]=995; //a
    code[686]=1030; //b
    code[706]=1006; //parTemp_0

    code[746]=4045; //ExpressionStatement_12 # ExpressionStatement_12
    code[739]=3577; //addTemp_1
    code[737]=3242; //mulTemp_0
    code[762]=995; //a

    code[799]=5465; //ExpressionStatement_7 # ExpressionStatement_13
    code[818]=3567; //sum
    code[805]=3567; //sum
    code[786]=3577; //addTemp_1
    code[792]=3211; //d

    code[869]=8307; //ExpressionStatement_14 # ExpressionStatement_14
    code[873]=135; //result
    code[894]=135; //result
    code[886]=3567; //sum

    code[923]=5526; //ExpressionStatement_15 # ExpressionStatement_15
    code[942]=3428; //mulTemp_1
    code[914]=995; //a
    code[944]=1030; //b

    code[986]=9542; //ExpressionStatement_16 # ExpressionStatement_16
    code[1009]=1973; //mulTemp_2
    code[1014]=857; //c
    code[992]=3211; //d

    code[1049]=5526; //ExpressionStatement_15 # ExpressionStatement_17
    code[1068]=2101; //mulTemp_3
    code[1040]=1973; //mulTemp_2
    code[1070]=3549; //e

    code[1112]=8164; //ExpressionStatement_18 # ExpressionStatement_18
    code[1131]=2972; //mulTemp_4
    code[1105]=436; //7
    code[1092]=137; //3

    code[1169]=8215; //ExpressionStatement_19 # ExpressionStatement_19
    code[1187]=3357; //addTemp_2
    code[1180]=3428; //mulTemp_1
    code[1177]=2101; //mulTemp_3
    code[1168]=1193; //2

    code[1225]=8215; //ExpressionStatement_19 # ExpressionStatement_20
    code[1243]=3292; //addTemp_3
    code[1236]=3357; //addTemp_2
    code[1233]=2972; //mulTemp_4
    code[1224]=1552; //num

    code[1281]=7772; //ExpressionStatement_21 # ExpressionStatement_21
    code[1303]=3567; //sum
    code[1263]=3567; //sum
    code[1296]=3292; //addTemp_3

    code[1343]=8307; //ExpressionStatement_14 # ExpressionStatement_22
    code[1347]=135; //result
    code[1368]=135; //result
    code[1360]=3567; //sum

    code[1397]=4401; //ExpressionStatement_23 # ExpressionStatement_23
    code[1393]=1883; //"{0} {1}"
    code[1415]=3037; //"result"
    code[1395]=135; //result

    code[1465]=8032; //ExpressionStatement_24 # ExpressionStatement_24
    code[1468]=1883; //"{0} {1}"
    code[1447]=30; //"fact"
    code[1481]=1552; //num

    code[1528]=5039; //ExpressionStatement_25 # ExpressionStatement_25
    code[1535]=744; //var_ifCondition_0
    code[1508]=1552; //num
    code[1547]=3414; //0

    code[1590]=9620; //IfStatementSyntax_26 # IfStatementSyntax_26
    code[1606]=3358; //jmpDestinationName_3358
    code[1599]=744; //var_ifCondition_0
    code[1615]=2980; //if_GoTo_True_2980
    code[1581]=1218; //if_GoTo_False_1218

    code[1663]=1127; //ReturnStatement_27 # ReturnStatement_27
    code[1684]=986; //1

    code[1732]=9748; //ExpressionStatement_28 # ExpressionStatement_28
    code[1735]=95; //if_FalseBlockSize_Skip_95

    code[1791]=6789; //ExpressionStatement_29 # ExpressionStatement_29
    code[1772]=907; //invocationTemp_0
    code[1800]=1552; //num
    code[1786]=2644; //1

    code[1855]=8442; //ExpressionStatement_30 # ExpressionStatement_30
    code[1866]=3429; //mulTemp_5
    code[1841]=1552; //num
    code[1844]=907; //invocationTemp_0

    code[1927]=1127; //ReturnStatement_27 # ReturnStatement_31
    code[1948]=3429; //mulTemp_5

    return (long)ClassInterpreterVirtualization_BasicOperations_op3(vpc, data, code);

}

//                [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
public static long FactorialRecursive_obf_op4_in1(int num)
{
    //Virtualization variables
    int[] code = new int[100625];
    object[] data = new object[4282];
    int vpc = 21;

    //Data init
    data[3204]=num; //num 
    data[932]=0; //0 constant
    data[180]=20; //20 constant
    data[1804]=10; //10 constant
    data[3735]=5; //5 constant
    data[3032]=2; //2 constant
    data[2364]=(double)1.0; //1.0 constant
    data[2197]=(double)0.0; //0.0 constant
    data[66]="FactorialRecursive_obf_op4_in1"; //"FactorialRecursive_obf_op4_in1" constant
    data[957]=1 ; //1 constant
    data[3166]=7 ; //7 constant
    data[3173]=3; //3 constant
    data[3601]="{0} {1}"; //"{0} {1}" constant
    data[3665]="result"; //"result" constant
    data[866]="fact"; //"fact" constant
    data[1801]=(long)1; //1 constant
    data[3091]=-866; //c 
    data[2163]=-717; //a 
    data[1682]=602; //b 
    data[267]=-534; //d 
    data[614]=-910; //e 
    data[922]=(double)0.451301903208393; //sum 
    data[2104]=2006145115; //result 
    data[3156]=(double)0.758254800344936; //addTemp_0 
    data[65]=182; //mulTemp_0 
    data[1863]=98; //addTemp_1 
    data[843]=-967; //mulTemp_1 
    data[2849]=-522; //mulTemp_2 
    data[506]=583; //mulTemp_3 
    data[2611]=587; //mulTemp_4 
    data[3269]=801; //addTemp_2 
    data[1786]=false; //var_ifCondition_0 
    data[156]=(long)833L; //invocationTemp_0 
    data[3311]=(long)-567L; //mulTemp_5 
    data[3878]=-99; //jmpDestinationName_3878 constant
    data[3142]=70; //if_GoTo_True_3142 constant
    data[1980]=186; //if_GoTo_False_1980 constant
    data[1050]=0; //if_FalseBlockSize_Skip_1050 constant

    //Code init

    code[21]=2646; //ExpressionStatement_0 # ExpressionStatement_0
    code[10]=3091; //c
    code[8]=932; //0

    code[85]=2646; //ExpressionStatement_0 # ExpressionStatement_1
    code[74]=2163; //a
    code[72]=180; //20

    code[149]=2646; //ExpressionStatement_0 # ExpressionStatement_2
    code[138]=1682; //b
    code[136]=1804; //10

    code[213]=2646; //ExpressionStatement_0 # ExpressionStatement_3
    code[202]=267; //d
    code[200]=3735; //5

    code[277]=2646; //ExpressionStatement_0 # ExpressionStatement_4
    code[266]=614; //e
    code[264]=3032; //2

    code[341]=9801; //ExpressionStatement_5 # ExpressionStatement_5
    code[344]=922; //sum
    code[354]=2364; //1.0
    code[356]=2197; //0.0

    code[395]=2646; //ExpressionStatement_0 # ExpressionStatement_6
    code[384]=2104; //result
    code[382]=66; //"FactorialRecursive_obf_op4_in1"

    code[459]=1000; //ExpressionStatement_7 # ExpressionStatement_7
    code[467]=922; //sum
    code[474]=922; //sum
    code[451]=957; //1
    code[460]=3204; //num

    code[532]=5924; //ExpressionStatement_8 # ExpressionStatement_8
    code[533]=3156; //addTemp_0
    code[530]=922; //sum
    code[529]=2163; //a
    code[549]=1682; //b
    code[515]=3091; //c

    code[604]=6309; //ExpressionStatement_9 # ExpressionStatement_9
    code[613]=2104; //result
    code[630]=2104; //result
    code[595]=3156; //addTemp_0

    code[660]=5204; //ExpressionStatement_10 # ExpressionStatement_10
    code[668]=65; //mulTemp_0
    code[676]=2163; //a
    code[644]=1682; //b
    code[664]=3091; //c
    code[648]=267; //d

    code[716]=5193; //ExpressionStatement_11 # ExpressionStatement_11
    code[744]=1863; //addTemp_1
    code[742]=65; //mulTemp_0
    code[697]=2163; //a

    code[787]=1000; //ExpressionStatement_7 # ExpressionStatement_12
    code[795]=922; //sum
    code[802]=922; //sum
    code[779]=1863; //addTemp_1
    code[788]=267; //d

    code[860]=6309; //ExpressionStatement_9 # ExpressionStatement_13
    code[869]=2104; //result
    code[886]=2104; //result
    code[851]=922; //sum

    code[916]=1246; //ExpressionStatement_14 # ExpressionStatement_14
    code[903]=843; //mulTemp_1
    code[928]=2163; //a
    code[909]=1682; //b

    code[983]=7943; //ExpressionStatement_15 # ExpressionStatement_15
    code[999]=2849; //mulTemp_2
    code[971]=3091; //c
    code[1008]=267; //d

    code[1046]=1246; //ExpressionStatement_14 # ExpressionStatement_16
    code[1033]=506; //mulTemp_3
    code[1058]=2849; //mulTemp_2
    code[1039]=614; //e

    code[1113]=5438; //ExpressionStatement_17 # ExpressionStatement_17
    code[1139]=2611; //mulTemp_4
    code[1107]=3166; //7
    code[1097]=3173; //3

    code[1168]=5271; //ExpressionStatement_18 # ExpressionStatement_18
    code[1174]=3269; //addTemp_2
    code[1164]=843; //mulTemp_1
    code[1197]=506; //mulTemp_3
    code[1167]=3032; //2
    code[1180]=2611; //mulTemp_4

    code[1225]=1000; //ExpressionStatement_7 # ExpressionStatement_19
    code[1233]=922; //sum
    code[1240]=922; //sum
    code[1217]=3269; //addTemp_2
    code[1226]=3204; //num

    code[1298]=6309; //ExpressionStatement_9 # ExpressionStatement_20
    code[1307]=2104; //result
    code[1324]=2104; //result
    code[1289]=922; //sum

    code[1354]=4697; //ExpressionStatement_21 # ExpressionStatement_21
    code[1345]=3601; //"{0} {1}"
    code[1356]=3665; //"result"
    code[1367]=2104; //result

    code[1421]=8578; //ExpressionStatement_22 # ExpressionStatement_22
    code[1429]=3601; //"{0} {1}"
    code[1432]=866; //"fact"
    code[1411]=3204; //num

    code[1489]=1370; //ExpressionStatement_23 # ExpressionStatement_23
    code[1515]=1786; //var_ifCondition_0
    code[1498]=3204; //num
    code[1469]=932; //0

    code[1542]=9754; //IfStatementSyntax_24 # IfStatementSyntax_24
    code[1554]=3878; //jmpDestinationName_3878
    code[1524]=1786; //var_ifCondition_0
    code[1569]=3142; //if_GoTo_True_3142
    code[1537]=1980; //if_GoTo_False_1980

    code[1612]=6719; //ReturnStatement_25 # ReturnStatement_25
    code[1609]=1801; //1

    code[1669]=3788; //ExpressionStatement_26 # ExpressionStatement_26
    code[1682]=1050; //if_FalseBlockSize_Skip_1050

    code[1728]=4177; //ExpressionStatement_27 # ExpressionStatement_27
    code[1714]=156; //invocationTemp_0
    code[1743]=3204; //num
    code[1730]=957; //1

    code[1786]=2353; //ExpressionStatement_28 # ExpressionStatement_28
    code[1792]=3311; //mulTemp_5
    code[1785]=3204; //num
    code[1784]=156; //invocationTemp_0

    code[1840]=6719; //ReturnStatement_25 # ReturnStatement_29
    code[1837]=3311; //mulTemp_5

    return (long)ClassInterpreterVirtualization_BasicOperations_op4(vpc, data, code);

}

private static object ClassInterpreterVirtualization_BasicOperations_op4(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 1370:  //frequency 1 ExpressionStatement_23
                data[code[vpc + (26)]] = (int)data[code[vpc + (9)]] == (int)data[code[vpc + (-20)]];
                vpc += 53;
                break;
            case 4177:  //frequency 1 ExpressionStatement_27
                data[code[vpc + (-14)]] = FactorialRecursive_obf_op4_in1((int)data[code[vpc + (15)]] - (int)data[code[vpc + (2)]]);
                vpc += 58;
                break;
            case 2353:  //frequency 1 ExpressionStatement_28
                data[code[vpc + (6)]] = (int)data[code[vpc + (-1)]] * (long)data[code[vpc + (-2)]];
                vpc += 54;
                break;
            case 5204:  //frequency 1 ExpressionStatement_10
                data[code[vpc + (8)]] = ((int)data[code[vpc + (16)]] - (int)data[code[vpc + (-16)]]) * ((int)data[code[vpc + (4)]] - (int)data[code[vpc + (-12)]]);
                vpc += 56;
                break;
            case 2646:  //frequency 6 ExpressionStatement_0
                data[code[vpc + (-11)]] = data[code[vpc + (-13)]];
                vpc += 64;
                break;
            case 6309:  //frequency 3 ExpressionStatement_9
                data[code[vpc + (9)]] = (string)data[code[vpc + (26)]] + (double)data[code[vpc + (-9)]];
                vpc += 56;
                break;
            case 3788:  //frequency 1 ExpressionStatement_26
                vpc += (int)data[code[vpc + (13)]];
                vpc += 59;
                break;
            case 5193:  //frequency 1 ExpressionStatement_11
                data[code[vpc + (28)]] = (int)data[code[vpc + (26)]] + (int)data[code[vpc + (-19)]];
                vpc += 71;
                break;
            case 5924:  //frequency 1 ExpressionStatement_8
                data[code[vpc + (1)]] = (double)data[code[vpc + (-2)]] + (int)data[code[vpc + (-3)]] + (int)data[code[vpc + (17)]] + (int)data[code[vpc + (-17)]];
                vpc += 72;
                break;
            case 5438:  //frequency 1 ExpressionStatement_17
                data[code[vpc + (26)]] = (int)data[code[vpc + (-6)]] % (int)data[code[vpc + (-16)]];
                vpc += 55;
                break;
            case 5271:  //frequency 1 ExpressionStatement_18
                data[code[vpc + (6)]] = (int)data[code[vpc + (-4)]] + (int)data[code[vpc + (29)]] + (int)data[code[vpc + (-1)]] + (int)data[code[vpc + (12)]];
                vpc += 57;
                break;
            case 4697:  //frequency 1 ExpressionStatement_21
                Console.WriteLine((string)data[code[vpc + (-9)]], (string)data[code[vpc + (2)]], (string)data[code[vpc + (13)]]);
                vpc += 67;
                break;
            case 9754:  //frequency 1 IfStatementSyntax_24
                data[code[vpc + (12)]] = (bool)data[code[vpc + (-18)]] ? (int)data[code[vpc + (27)]] : (int)data[code[vpc + (-5)]];
                vpc += (int)data[code[vpc + (12)]];
                break;
            case 9801:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (3)]] = (double)data[code[vpc + (13)]] + (double)data[code[vpc + (15)]];
                vpc += 54;
                break;
            case 1246:  //frequency 2 ExpressionStatement_14
                data[code[vpc + (-13)]] = (int)data[code[vpc + (12)]] * (int)data[code[vpc + (-7)]];
                vpc += 67;
                break;
            case 6719:  //frequency 2 ReturnStatement_25
                return (long)data[code[vpc + (-3)]];
                vpc += 57;
            default:  //frequency 0 
                break;
            case 7943:  //frequency 1 ExpressionStatement_15
                data[code[vpc + (16)]] = (int)data[code[vpc + (-12)]] / (int)data[code[vpc + (25)]];
                vpc += 63;
                break;
            case 1000:  //frequency 3 ExpressionStatement_7
                data[code[vpc + (8)]] = (double)data[code[vpc + (15)]] + (int)data[code[vpc + (-8)]] + (int)data[code[vpc + (1)]];
                vpc += 73;
                break;
            case 8578:  //frequency 1 ExpressionStatement_22
                Console.WriteLine((string)data[code[vpc + (8)]], (string)data[code[vpc + (11)]], (int)data[code[vpc + (-10)]]);
                vpc += 68;
                break;
        }
    }

    return null;
}

private static object ClassInterpreterVirtualization_BasicOperations_op3(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 8164:  //frequency 1 ExpressionStatement_18
                data[code[vpc + (19)]] = (int)data[code[vpc + (-7)]] % (int)data[code[vpc + (-20)]];
                vpc += 57;
                break;
            case 5039:  //frequency 1 ExpressionStatement_25
                data[code[vpc + (7)]] = (int)data[code[vpc + (-20)]] == (int)data[code[vpc + (19)]];
                vpc += 62;
                break;
            case 5465:  //frequency 2 ExpressionStatement_7
                data[code[vpc + (19)]] = (double)data[code[vpc + (6)]] + (int)data[code[vpc + (-13)]] + (int)data[code[vpc + (-7)]];
                vpc += 70;
                break;
            case 8307:  //frequency 2 ExpressionStatement_14
                data[code[vpc + (4)]] = (string)data[code[vpc + (25)]] + (double)data[code[vpc + (17)]];
                vpc += 54;
                break;
            case 5526:  //frequency 2 ExpressionStatement_15
                data[code[vpc + (19)]] = (int)data[code[vpc + (-9)]] * (int)data[code[vpc + (21)]];
                vpc += 63;
                break;
            case 9542:  //frequency 1 ExpressionStatement_16
                data[code[vpc + (23)]] = (int)data[code[vpc + (28)]] / (int)data[code[vpc + (6)]];
                vpc += 63;
                break;
            case 3838:  //frequency 1 ExpressionStatement_11
                data[code[vpc + (29)]] = ((int)data[code[vpc + (-11)]] - (int)data[code[vpc + (-4)]]) * (int)data[code[vpc + (16)]];
                vpc += 56;
                break;
            case 8442:  //frequency 1 ExpressionStatement_30
                data[code[vpc + (11)]] = (int)data[code[vpc + (-14)]] * (long)data[code[vpc + (-11)]];
                vpc += 72;
                break;
            case 5955:  //frequency 1 ExpressionStatement_8
                data[code[vpc + (-7)]] = (double)data[code[vpc + (-10)]] + (int)data[code[vpc + (-6)]] + (int)data[code[vpc + (6)]];
                vpc += 72;
                break;
            case 3735:  //frequency 1 ExpressionStatement_10
                data[code[vpc + (7)]] = (int)data[code[vpc + (10)]] - (int)data[code[vpc + (-20)]];
                vpc += 71;
                break;
            case 9620:  //frequency 1 IfStatementSyntax_26
                data[code[vpc + (16)]] = (bool)data[code[vpc + (9)]] ? (int)data[code[vpc + (25)]] : (int)data[code[vpc + (-9)]];
                vpc += (int)data[code[vpc + (16)]];
                break;
            case 9748:  //frequency 1 ExpressionStatement_28
                vpc += (int)data[code[vpc + (3)]];
                vpc += 59;
                break;
            case 4045:  //frequency 1 ExpressionStatement_12
                data[code[vpc + (-7)]] = (int)data[code[vpc + (-9)]] + (int)data[code[vpc + (16)]];
                vpc += 53;
                break;
            case 8032:  //frequency 1 ExpressionStatement_24
                Console.WriteLine((string)data[code[vpc + (3)]], (string)data[code[vpc + (-18)]], (int)data[code[vpc + (16)]]);
                vpc += 63;
                break;
            case 4401:  //frequency 1 ExpressionStatement_23
                Console.WriteLine((string)data[code[vpc + (-4)]], (string)data[code[vpc + (18)]], (string)data[code[vpc + (-2)]]);
                vpc += 68;
                break;
            default:  //frequency 0 
                break;
            case 7772:  //frequency 1 ExpressionStatement_21
                data[code[vpc + (22)]] = (double)data[code[vpc + (-18)]] + (int)data[code[vpc + (15)]];
                vpc += 62;
                break;
            case 6789:  //frequency 1 ExpressionStatement_29
                data[code[vpc + (-19)]] = FactorialRecursive_obf_op3_in1((int)data[code[vpc + (9)]] - (int)data[code[vpc + (-5)]]);
                vpc += 64;
                break;
            case 1127:  //frequency 2 ReturnStatement_27
                return (long)data[code[vpc + (21)]];
                vpc += 69;
            case 1986:  //frequency 1 ExpressionStatement_9
                data[code[vpc + (21)]] = (string)data[code[vpc + (11)]] + (double)data[code[vpc + (20)]] + (int)data[code[vpc + (25)]];
                vpc += 67;
                break;
            case 8675:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (-10)]] = (double)data[code[vpc + (10)]] + (double)data[code[vpc + (22)]];
                vpc += 65;
                break;
            case 6731:  //frequency 6 ExpressionStatement_0
                data[code[vpc + (28)]] = data[code[vpc + (-3)]];
                vpc += 52;
                break;
            case 8215:  //frequency 2 ExpressionStatement_19
                data[code[vpc + (18)]] = (int)data[code[vpc + (11)]] + (int)data[code[vpc + (8)]] + (int)data[code[vpc + (-1)]];
                vpc += 56;
                break;
        }
    }

    return null;
}

private static object ClassInterpreterVirtualization_BasicOperations_op2(int vpc, object[] data, int[] code)
{
    while (true)
    {
        switch (code[vpc])
        {
            case 8109:  //frequency 2 ReturnStatement_34
                return (long)data[code[vpc + (-9)]];
                vpc += 51;
            case 1339:  //frequency 1 ExpressionStatement_35
                vpc += (int)data[code[vpc + (22)]];
                vpc += 65;
                break;
            case 9800:  //frequency 3 ExpressionStatement_13
                data[code[vpc + (9)]] = (int)data[code[vpc + (-17)]] - (int)data[code[vpc + (19)]];
                vpc += 65;
                break;
            case 6636:  //frequency 1 ExpressionStatement_37
                data[code[vpc + (-3)]] = FactorialRecursive_obf_op2_in1((int)data[code[vpc + (10)]]);
                vpc += 70;
                break;
            case 4093:  //frequency 6 ExpressionStatement_0
                data[code[vpc + (28)]] = data[code[vpc + (27)]];
                vpc += 60;
                break;
            case 2161:  //frequency 1 ExpressionStatement_30
                Console.WriteLine((string)data[code[vpc + (14)]], (string)data[code[vpc + (19)]], (string)data[code[vpc + (2)]]);
                vpc += 68;
                break;
            case 8598:  //frequency 3 ExpressionStatement_12
                data[code[vpc + (-14)]] = (string)data[code[vpc + (8)]] + (double)data[code[vpc + (26)]];
                vpc += 60;
                break;
            case 2274:  //frequency 1 ExpressionStatement_38
                data[code[vpc + (-7)]] = (int)data[code[vpc + (16)]] * (long)data[code[vpc + (-6)]];
                vpc += 70;
                break;
            case 4975:  //frequency 1 IfStatementSyntax_33
                data[code[vpc + (24)]] = (bool)data[code[vpc + (15)]] ? (int)data[code[vpc + (-2)]] : (int)data[code[vpc + (11)]];
                vpc += (int)data[code[vpc + (24)]];
                break;
            case 7673:  //frequency 1 ExpressionStatement_31
                Console.WriteLine((string)data[code[vpc + (3)]], (string)data[code[vpc + (7)]], (int)data[code[vpc + (21)]]);
                vpc += 66;
                break;
            case 9120:  //frequency 3 ExpressionStatement_15
                data[code[vpc + (21)]] = (int)data[code[vpc + (-11)]] * (int)data[code[vpc + (22)]];
                vpc += 70;
                break;
            case 4432:  //frequency 7 ExpressionStatement_7
                data[code[vpc + (-17)]] = (int)data[code[vpc + (-11)]] + (int)data[code[vpc + (7)]];
                vpc += 54;
                break;
            case 2211:  //frequency 1 ExpressionStatement_32
                data[code[vpc + (-4)]] = (int)data[code[vpc + (-12)]] == (int)data[code[vpc + (-5)]];
                vpc += 59;
                break;
            default:  //frequency 0 
                break;
            case 4195:  //frequency 6 ExpressionStatement_8
                data[code[vpc + (-10)]] = (double)data[code[vpc + (8)]] + (int)data[code[vpc + (22)]];
                vpc += 59;
                break;
            case 6640:  //frequency 1 ExpressionStatement_5
                data[code[vpc + (6)]] = (double)data[code[vpc + (15)]] + (double)data[code[vpc + (4)]];
                vpc += 55;
                break;
            case 9059:  //frequency 1 ExpressionStatement_23
                data[code[vpc + (-10)]] = (int)data[code[vpc + (-7)]] % (int)data[code[vpc + (-12)]];
                vpc += 61;
                break;
            case 4574:  //frequency 1 ExpressionStatement_21
                data[code[vpc + (-18)]] = (int)data[code[vpc + (17)]] / (int)data[code[vpc + (-12)]];
                vpc += 65;
                break;
        }
    }

    return null;
}

                

        #endregion

    }
}
