using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.VirtCode
{
    class CodeBasicTests
    {
        public static void RunBasicTests()
        {
            CodeBasicTests cbt = new CodeBasicTests();

//                        cbt.InvocationSplit_Check();
            //            cbt.PreOperation_Check();
            //            cbt.PostOperation_Check();
            //            cbt.LocalVariables_Check();
            //
//                        cbt.OperationOrder_Check();
            //
            //            cbt.FactorialIterative_Check(0);
            //            cbt.FactorialIterative_Check(1);
            //            cbt.FactorialIterative_Check(2);
            //            cbt.FactorialIterative_Check(5);
            //
            //            cbt.FactorialRecursive_Check(0);
            //            cbt.FactorialRecursive_Check(1);
            //            cbt.FactorialRecursive_Check(2);
            //            cbt.FactorialRecursive_Check(5);
        }

        #region INVOCATION_SPLIT

//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        private string InvocationSplit_0(Car c)
        {
            Car car = c;

            string resultVar = "";
            //method calls
            var e1 = car.GetEngine();
            e1.GetPistons();
            resultVar += e1.ToString();
            var p1 = car.GetEngine().GetPistons().First().GetSize();
            //            Console.WriteLine(car);
            resultVar += p1;
            //            car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1);
            resultVar += car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1).ToString();


            //properties call
            var e2 = car.Engine;
            resultVar += e2;
            var typeS = Car.TYPE;
            resultVar += typeS;

            var et = String.Empty.Count();
            resultVar += et;

            var ts = car.GetEngine().TurbineStatus;
            resultVar += ts;
            var idSize = car.Engine.SerialNumber.Length;
            resultVar += idSize;

            //            //static call
            string counter = Car.GetCounter().ToString();
            resultVar += counter;
            bool isCarType = Car.TYPE.Equals("CAR");
            resultVar += isCarType;

            return resultVar;
        }

        private string InvocationSplit_1(Car c)
        {
            Car car = c;

            string resultVar = "";
            //method calls
            var e1 = car.GetEngine();
            e1.GetPistons();
            resultVar += e1.ToString();
            var p1 = car.GetEngine().GetPistons().First().GetSize();
            //            Console.WriteLine(car);
            resultVar += p1;
            //            car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1);
            resultVar += car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1).ToString();


            //properties call
            var e2 = car.Engine;
            resultVar += e2;
            var typeS = Car.TYPE;
            resultVar += typeS;

            var et = String.Empty.Count();
            resultVar += et;

            var ts = car.GetEngine().TurbineStatus;
            resultVar += ts;
            var idSize = car.Engine.SerialNumber.Length;
            resultVar += idSize;

            //            //static call
            string counter = Car.GetCounter().ToString();
            resultVar += counter;
            bool isCarType = Car.TYPE.Equals("CAR");
            resultVar += isCarType;

            return resultVar;
        }

        private void InvocationSplit_Check()
        {
            string testName = "Code#InvocationSplit_";
            Program.Start_Check(testName);
            bool condition = true;
            Car c = new Car("invocation-check-car", 4);
            string virt = InvocationSplit_0(c);
            string oracle = InvocationSplit_1(c);
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }


        [Obfuscation(Exclude = false, Feature = "ctrl flow")]
        private string ConfuserEx_InvocationSplit_0(Car c)
        {
            Car car = c;

            string resultVar = "";
            //method calls
            var e1 = car.GetEngine();
            e1.GetPistons();
            resultVar += e1.ToString();
            var p1 = car.GetEngine().GetPistons().First().GetSize();
            //            Console.WriteLine(car);
            resultVar += p1;
            //            car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1);
            resultVar += car.GetEngine().GetPiston(car.GetEngine().GetPistons().Count - 1).ToString();


            //properties call
            var e2 = car.Engine;
            resultVar += e2;
            var typeS = Car.TYPE;
            resultVar += typeS;

            var et = String.Empty.Count();
            resultVar += et;

            var ts = car.GetEngine().TurbineStatus;
            resultVar += ts;
            var idSize = car.Engine.SerialNumber.Length;
            resultVar += idSize;

            //            //static call
            string counter = Car.GetCounter().ToString();
            resultVar += counter;
            bool isCarType = Car.TYPE.Equals("CAR");
            resultVar += isCarType;

            return resultVar;
        }



        #endregion


        #region OPERATION_ORDER

        //        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        string MaxOperator_0()
        {
            string result = "";

            result = "1" + "2" + "3" + "4" + "5" + "6" + "7" + "8" ;
            var mul = 1 * 2 * 3 * 4 * 5 * 6 * 7 * 8;

            //            result = "1" + "2" + "3" + "4";// + "5" + "6" + "7" ;
            //            result = "1" + "2" + "3" + "4" + "5";// + "6" + "7" ;
            return result;
        }

//        [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
string OperationOrder_2()
{
    //Virtualization variables
    int[] code = new int[4682];
    object[] data = new object[4818];
    int vpc = 0;

    //Data init
    data[1603]=20; //20 constant
    data[22]=10; //10 constant
    data[2467]=15; //15 constant
    data[1717]=5; //5 constant
    data[2816]=2; //2 constant
    data[1178]=3 ; //3 constant
    data[3518]=(float)0F; //0F constant
    data[662]=(double)1.0; //1.0 constant
    data[287]=(double)0.0; //0.0 constant
    data[2715]=""; //"" constant
    data[2604]=1; //1 constant
    data[2770]=7 ; //7 constant
    data[2682]=215; //a 
    data[3831]=447; //b 
    data[2914]=771; //c 
    data[2469]=-586; //d 
    data[2933]=-222; //e 
    data[620]=(float)0.5379585F; //f 
    data[2437]=(double)0.42513591583126; //sum 
    data[3281]=1761066966; //result 
    data[2386]=471; //parTemp_0 
    data[1428]=393; //parTemp_1 
    data[2911]=-755; //mulTemp_0 
    data[3674]=-221; //addTemp_0 
    data[2929]=926; //addTemp_1 
    data[1237]=-7; //mulTemp_1 
    data[2971]=-660; //mulTemp_2 
    data[2188]=-349; //mulTemp_3 
    data[2133]=-932; //mulTemp_4 
    data[1297]=835; //addTemp_2 
    data[1732]=-721; //addTemp_3 
    data[2555]=926; //addTemp_4 
    data[688]=205; //parTemp_2 
    data[810]=1; //mulTemp_5 
    data[2981]=-737; //mulTemp_6 
    data[2095]=195; //parTemp_3 
    data[58]=-604; //parTemp_4 
    data[2493]=133; //mulTemp_7 
    data[1974]=258; //parTemp_5 
    data[3701]=207; //mulTemp_8 
    data[1154]=772; //addTemp_5 

    //Code init
    code[0]=3711; //ExpressionStatement_0
    code[1]=2682; //a
    code[2]=1603; //20
    code[3]=3711; //ExpressionStatement_0
    code[4]=3831; //b
    code[5]=22; //10
    code[6]=3711; //ExpressionStatement_0
    code[7]=2914; //c
    code[8]=2467; //15
    code[9]=3711; //ExpressionStatement_0
    code[10]=2469; //d
    code[11]=1717; //5
    code[12]=3711; //ExpressionStatement_0
    code[13]=2933; //e
    code[14]=2816; //2
    code[15]=1434; //ExpressionStatement_1
    code[16]=620; //f
    code[17]=1178; //3
    code[18]=3518; //0F
    code[19]=9095; //ExpressionStatement_2
    code[20]=2437; //sum
    code[21]=662; //1.0
    code[22]=287; //0.0
    code[23]=3711; //ExpressionStatement_0
    code[24]=3281; //result
    code[25]=2715; //""
    code[26]=1532; //ExpressionStatement_3
    code[27]=2437; //sum
    code[28]=2437; //sum
    code[29]=2604; //1
    code[30]=6505; //ExpressionStatement_4
    code[31]=3281; //result
    code[32]=3281; //result
    code[33]=2437; //sum
    code[34]=7835; //ExpressionStatement_5
    code[35]=2386; //parTemp_0
    code[36]=2682; //a
    code[37]=3831; //b
    code[38]=7835; //ExpressionStatement_5
    code[39]=1428; //parTemp_1
    code[40]=2914; //c
    code[41]=2469; //d
    code[42]=4753; //ExpressionStatement_6
    code[43]=2911; //mulTemp_0
    code[44]=2386; //parTemp_0
    code[45]=1428; //parTemp_1
    code[46]=1392; //ExpressionStatement_7
    code[47]=3674; //addTemp_0
    code[48]=2911; //mulTemp_0
    code[49]=2682; //a
    code[50]=3498; //ExpressionStatement_7
    code[51]=2929; //addTemp_1
    code[52]=3674; //addTemp_0
    code[53]=2469; //d
    code[54]=1532; //ExpressionStatement_3
    code[55]=2437; //sum
    code[56]=2437; //sum
    code[57]=2929; //addTemp_1
    code[58]=6505; //ExpressionStatement_4
    code[59]=3281; //result
    code[60]=3281; //result
    code[61]=2437; //sum
    code[62]=4753; //ExpressionStatement_6
    code[63]=1237; //mulTemp_1
    code[64]=2682; //a
    code[65]=3831; //b
    code[66]=4580; //ExpressionStatement_8
    code[67]=2971; //mulTemp_2
    code[68]=2914; //c
    code[69]=2469; //d
    code[70]=4753; //ExpressionStatement_6
    code[71]=2188; //mulTemp_3
    code[72]=2971; //mulTemp_2
    code[73]=2933; //e
    code[74]=9553; //ExpressionStatement_9
    code[75]=2133; //mulTemp_4
    code[76]=2770; //7
    code[77]=1178; //3
    code[78]=7281; //ExpressionStatement_7
    code[79]=1297; //addTemp_2
    code[80]=1237; //mulTemp_1
    code[81]=2188; //mulTemp_3
    code[82]=7271; //ExpressionStatement_7
    code[83]=1732; //addTemp_3
    code[84]=1297; //addTemp_2
    code[85]=2816; //2
    code[86]=4552; //ExpressionStatement_7
    code[87]=2555; //addTemp_4
    code[88]=1732; //addTemp_3
    code[89]=2133; //mulTemp_4
    code[90]=1532; //ExpressionStatement_3
    code[91]=2437; //sum
    code[92]=2437; //sum
    code[93]=2555; //addTemp_4
    code[94]=6505; //ExpressionStatement_4
    code[95]=3281; //result
    code[96]=3281; //result
    code[97]=2437; //sum
    code[98]=5964; //ExpressionStatement_7
    code[99]=688; //parTemp_2
    code[100]=2682; //a
    code[101]=3831; //b
    code[102]=4753; //ExpressionStatement_6
    code[103]=810; //mulTemp_5
    code[104]=688; //parTemp_2
    code[105]=2914; //c
    code[106]=4580; //ExpressionStatement_8
    code[107]=2981; //mulTemp_6
    code[108]=810; //mulTemp_5
    code[109]=2469; //d
    code[110]=3992; //ExpressionStatement_7
    code[111]=2933; //e
    code[112]=2933; //e
    code[113]=2981; //mulTemp_6
    code[114]=9556; //ExpressionStatement_10
    code[115]=3281; //result
    code[116]=3281; //result
    code[117]=2933; //e
    code[118]=6690; //ExpressionStatement_7
    code[119]=2095; //parTemp_3
    code[120]=2682; //a
    code[121]=3831; //b
    code[122]=4753; //ExpressionStatement_6
    code[123]=58; //parTemp_4
    code[124]=2095; //parTemp_3
    code[125]=2914; //c
    code[126]=4580; //ExpressionStatement_8
    code[127]=2493; //mulTemp_7
    code[128]=58; //parTemp_4
    code[129]=2469; //d
    code[130]=7726; //ExpressionStatement_7
    code[131]=2933; //e
    code[132]=2933; //e
    code[133]=2493; //mulTemp_7
    code[134]=9556; //ExpressionStatement_10
    code[135]=3281; //result
    code[136]=3281; //result
    code[137]=2933; //e
    code[138]=4753; //ExpressionStatement_6
    code[139]=1974; //parTemp_5
    code[140]=3831; //b
    code[141]=2914; //c
    code[142]=4580; //ExpressionStatement_8
    code[143]=3701; //mulTemp_8
    code[144]=1974; //parTemp_5
    code[145]=2469; //d
    code[146]=3211; //ExpressionStatement_7
    code[147]=1154; //addTemp_5
    code[148]=2682; //a
    code[149]=3701; //mulTemp_8
    code[150]=1110; //ExpressionStatement_7
    code[151]=2933; //e
    code[152]=2933; //e
    code[153]=1154; //addTemp_5
    code[154]=9556; //ExpressionStatement_10
    code[155]=3281; //result
    code[156]=3281; //result
    code[157]=2933; //e
    code[158]=7530; //ReturnStatement_11
    code[159]=3281; //result


    Func<object[], int[], int, object> func = (data1, code1, vpc1) => { 

                while (true)
                {
    	            switch(code1[vpc1++])
    	            {
    		            case 1532: //frequency 3 ExpressionStatement_3
                            data1[code1[vpc1++]] = (double)data1[code1[vpc1++]] + (int)data1[code1[vpc1++]];
                            
    			            break;
    		            case 7530: //frequency 1 ReturnStatement_11
    			            return (string)data1[code1[vpc1++]];
    		            case 3711: //frequency 6 ExpressionStatement_0
    			            data1[code1[vpc1++]] = data1[code1[vpc1++]];
    			            break;
    		            case 1434: //frequency 1 ExpressionStatement_1
    			            data1[code1[vpc1++]] = (int)data1[code1[vpc1++]] + (float)data1[code1[vpc1++]];
    			            break;
    		            case 4753: //frequency 6 ExpressionStatement_6
    			            data1[code1[vpc1++]] = (int)data1[code1[vpc1++]] * (int)data1[code1[vpc1++]];
    			            break;
    		            case 9553: //frequency 1 ExpressionStatement_9
    			            data1[code1[vpc1++]] = (int)data1[code1[vpc1++]] % (int)data1[code1[vpc1++]];
    			            break;
    		            case 4580: //frequency 4 ExpressionStatement_8
    			            data1[code1[vpc1++]] = (int)data1[code1[vpc1++]] / (int)data1[code1[vpc1++]];
    			            break;
    		            default: //frequency 11 ExpressionStatement_7
    			            data1[code1[vpc1++]] = (int)data1[code1[vpc1++]] + (int)data1[code1[vpc1++]];
    			            break;
    		            case 6505: //frequency 3 ExpressionStatement_4
    			            data1[code1[vpc1++]] = (string)data1[code1[vpc1++]] + (double)data1[code1[vpc1++]];
    			            break;
    		            case 9095: //frequency 1 ExpressionStatement_2
    			            data1[code1[vpc1++]] = (double)data1[code1[vpc1++]] + (double)data1[code1[vpc1++]];
    			            break;
    		            case 7835: //frequency 2 ExpressionStatement_5
    			            data1[code1[vpc1++]] = (int)data1[code1[vpc1++]] - (int)data1[code1[vpc1++]];
    			            break;
    		            case 9556: //frequency 3 ExpressionStatement_10
    			            data1[code1[vpc1++]] = (string)data1[code1[vpc1++]] + (int)data1[code1[vpc1++]];
    			            break;
    	            }
                }

        return null;
    };

            Expression<Predicate<int>> expression = Expression.Lambda<Predicate<int>>(                            
                             Expression.LessThan(
                                      Expression.Parameter(typeof(int), "n"),
                                      Expression.Constant(10)
                            ),
                           Expression.Parameter(typeof(int), "n")
               );
            Predicate<int> predicate = expression.Compile();

            BinaryFormatter f = new BinaryFormatter();
            MemoryStream m = new MemoryStream();
            f.Serialize(m, func);
            

            Func<object[], int[], int, object> fun2  = (Func < object[], int[], int, object>) f.Deserialize(m);

            return (string) fun2(data, code, vpc);
        }


//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        string OperationOrder_0()
        {
            int a = 20;
            int b = 10;
            int c = 15;
            int d = 5;
            int e = 2;
            float f = 3;
            double sum = 1.0;
            string result = "";

            sum += 1;
            result += sum;
            sum += (a - b) * (c - d) + a + d;
            result += sum;
            sum += a * b + c / d * e + 2 + 7 % 3;
            result += sum;
            e += (a + b) * c / d;
            result += e;
            e += ((a + b) * c) / d;
            result += e;
            e += a + (b * c) / d;
            result += e;

            return result;
        }

        string OperationOrder_1()
        {
            int a = 20;
            int b = 10;
            int c = 15;
            int d = 5;
            int e = 2;
            float f = 3;
            double sum = 1.0;
            string result = "";

            sum += 1;
            result += sum;
            sum += (a - b) * (c - d) + a + d;
            result += sum;
            sum += a * b + c / d * e + 2 + 7 % 3;
            result += sum;
            e += (a + b) * c / d;
            result += e;
            e += ((a + b) * c) / d;
            result += e;
            e += a + (b * c) / d;
            result += e;

            return result;
        }
       
        private void OperationOrder_Check()
        {
            string testName = "Code#OperationOrder_Check";
            bool condition = true;
            Program.Start_Check(testName);
            
            string virt = OperationOrder_0();            
            string oracle = OperationOrder_1();
            Console.WriteLine("virt: " + virt + " # " + oracle + " check");
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

        #endregion


        #region PRE_OPERARTIONS
//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        string PreOperation_0()
        {
            string result = "";
            int a = 0;
            int x = 100;
            int b = 0;
            int c = 0;
            
            ++a;
            --x;
            result += a;
            result += x;

            b = ++a;
            result += b;
            result += a;
            b = --x;
            result += b;
            result += x;

            c = ++a + ++a;
            result += c;
            result += a;
            c = --x + --x;
            result += c;
            result += x;

            return result;
        }

        string PreOperation_1()
        {
            string result = "";
            int a = 0;
            int x = 100;
            int b = 0;
            int c = 0;

            ++a;
            --x;
            result += a;
            result += x;

            b = ++a;
            result += b;
            result += a;
            b = --x;
            result += b;
            result += x;

            c = ++a + ++a;
            result += c;
            result += a;
            c = --x + --x;
            result += c;
            result += x;

            return result;
        }

        private void PreOperation_Check()
        {
            string testName = "Code#PreOperation_Check";
            bool condition = true;
            Program.Start_Check(testName);
            string virt = PreOperation_0();
            string oracle = PreOperation_1();
            Console.WriteLine("virt: {0} # {1} oracle", virt, oracle);
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

        #endregion

        #region POST_OPERARTIONS
//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        string PostOperation_0()
        {
            string result = "";
            int a = 0;
            int x = 100;
            int b = 0;
            int c = 0;

            int[] ar = new int[] { 0, 1, 2, 3, 4, 5, 6 };

            int a1 = 1;
            int a2 = 2;
            int a3 = 3;

            ar[a1++] = ar[a2++] + ar[a3++];
            result += a1 + a2 + a3;

            a++;
            x--;
            result += a;
            result += x;

            b = a++;
            result += b;
            b = x--;
            result += b;

            c = a++ + a++;
            result += c;
            result += a;
            c = x-- + x--;
            result += c;
            result += x;

            return result;
        }

        string PostOperation_1()
        {
            string result = "";
            int a = 0;
            int x = 100;
            int b = 0;
            int c = 0;

            int[] ar = new int[] { 0, 1, 2, 3, 4, 5, 6 };

            int a1 = 1;
            int a2 = 2;
            int a3 = 3;

            ar[a1++] = ar[a2++] + ar[a3++];
            result += a1 + a2 + a3;

            a++;
            x--;
            result += a;
            result += x;

            b = a++;
            result += b;
            b = x--;
            result += b;

            c = a++ + a++;
            result += c;
            result += a;
            c = x-- + x--;
            result += c;
            result += x;

            return result;
        }

        private void PostOperation_Check()
        {
            string testName = "Code#PostOperation_Check";
            bool condition = true;
            Program.Start_Check(testName);
            string virt = PostOperation_0();
            string oracle = PostOperation_1();
            Console.WriteLine("virt: {0} # {1} oracle", virt, oracle);
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

        #endregion


        #region LOCAL_VAR



        //        [Obfuscation(Exclude = false, Feature = "virtualization-class")]
        private string LocalVariables_a(string a, string b)
        {
            string local1 = a;
            string local2 = b;
            string local3 = "1";
            string local4 = "c";
            string sum = "";
            string v;
            int i1 = 11;
            int i2 = 13;
            sum = local1;
            local2 = sum;
            local3 = local2 + local1;
            local2 = local4 + local1;
            local3 = local3 + local2;
            local1 = "s1" + i1 + "s2" + i2;
            sum = "" + a + local3;
            int cc = 3 + 4 + 5;
            sum += sum + local1 + local2; // + b + a;
            Console.WriteLine("LocalVariables_b- " + sum);
            Console.WriteLine("LocalVariables_b- " + sum + 3);
            return sum;
        }


        private string LocalVariables_b(string a, string b)
        {
            string local1 = a;
            string local2 = b;
            string local3 = "1";
            string local4 = "c";
            string sum = "";
            string v;
            int i1 = 11;
            int i2 = 13;
            sum = local1;
            local2 = sum;
            local3 = local2 + local1;
            local2 = local4 + local1;
            local3 = local3 + local2;
            local1 = "s1" + i1 + "s2" + i2;
            sum = "" + a + local3;
            int cc = 3 + 4 + 5;
            sum += sum + local1 + local2; // + b + a;
            Console.WriteLine("LocalVariables_b- " + sum);
            Console.WriteLine("LocalVariables_b- " + sum + 3);
            return sum;
        }

        private void LocalVariables_Check()
        {
            string testName = "Code#LocalVariables_Check";
            bool condition = true;
            Program.Start_Check(testName);
            string a = "a";
            string b = "b";
            string virt = LocalVariables_a(a, b);
            string oracle = LocalVariables_b(a, b);
            bool debug = true;
            //            string r1 = LocalVariables_data(a, b);
            //            string r2 = LocalVariables_m(a, b);
            //            debug = r1.Equals(r2);
            //            LocalVariables_virtual(a, b);
            condition = virt.Equals(oracle) && debug;
            Program.End_Check(testName, condition);
        }

        #endregion


        #region FACTORIAL_ITERATIVE
//        [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
public long FactorialIterative_0(int num)
{
    long result = 1;
    if (num == 0)
    {
        return 1;
    }
    else
    {
        for (int i = 2; i <= num; i++)
        {
            result *= i;
        }
        return result;
    }
}

//                [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
public long FactorialIterative_junk(int num)
{
    //Virtualization variables
    int[] code = new int[100216];
    object[] data = new object[4490];
    int vpc = 30;

    //Data init
    data[2830]=num; //num 
    data[926]=1 ; //1 constant
    data[3104]=(long)0L; //0L constant
    data[2356]=0; //0 constant
    data[3189]=(long)1; //1 constant
    data[2449]=2; //2 constant
    data[2593]=(long)406L; //result 
    data[2788]=false; //var_ifCondition_0 
    data[3826]=-585; //var_forIndex_0 
    data[2780]=false; //var_whileCondition_0 
    data[406]=-248; //fake-406 
    data[2285]=696; //fake-2285 
    data[1510]=544; //fake-1510 
    data[2979]=360; //fake-2979 
    data[304]=374; //fake-304 
    data[1816]=-671; //fake-1816 
    data[3639]=-33; //fake-3639 
    data[1043]=-743; //fake-1043 
    data[770]=591; //fake-770 
    data[3500]=794; //fake-3500 
    data[2553]=-159; //jmpDestinationName_2553 constant
    data[1437]=68; //if_GoTo_True_1437 constant
    data[3590]=184; //if_GoTo_False_3590 constant
    data[1567]=504; //if_FalseBlockSize_Skip_1567 constant
    data[3753]=-312; //fake-3753 
    data[3527]=-619; //fake-3527 
    data[2202]=711; //fake-2202 
    data[2254]=541; //fake-2254 
    data[116]=-301; //fake-116 
    data[2171]=-448; //fake-2171 
    data[974]=615; //fake-974 
    data[3423]=-945; //fake-3423 
    data[863]=-12; //fake-863 
    data[3643]=-8; //fake-3643 
    data[2552]=862; //fake-2552 
    data[270]=-983; //fake-270 
    data[2181]=-360; //jmpWhileDestinationName_2181 constant
    data[3604]=68; //while_GoTo_True_3604 constant
    data[3138]=310; //while_GoTo_False_3138 constant
    data[2413]=-310; //while_FalseBlockSkip_2413 constant
    data[3585]=-379; //fake-3585 
    data[2526]=558; //fake-2526 
    data[3247]=964; //fake-3247 
    data[2786]=994; //fake-2786 
    data[2687]=193; //fake-2687 
    data[3224]=86; //fake-3224 
    data[1678]=-429; //fake-1678 
    data[3578]=-83; //fake-3578 
    data[459]=-349; //fake-459 
    data[83]=-824; //fake-83 
    data[2695]=133; //fake-2695 
    data[1052]=161; //fake-1052 
    data[2634]=-492; //fake-2634 
    data[3227]=356; //fake-3227 
    data[2700]=929; //fake-2700 
    data[2828]=-677; //fake-2828 
    data[2886]=454; //fake-2886 
    data[548]=-93; //fake-548 

    //Code init

    code[30]=5457; //ExpressionStatement_0 # ExpressionStatement_0
    code[16]=2593; //result
    code[31]=926; //1
    code[50]=3104; //0L
    code[22]=3554; //fake-ExpressionStatement_0_3554_-8
    code[42]=1526; //fake-ExpressionStatement_0_1526_12
    code[17]=123; //fake-ExpressionStatement_0_123_-13
    code[35]=2724; //fake-ExpressionStatement_0_2724_5
    code[57]=1817; //fake-ExpressionStatement_0_1817_27

    code[97]=5941; //ExpressionStatement_1 # ExpressionStatement_1
    code[124]=2788; //var_ifCondition_0
    code[112]=2830; //num
    code[119]=2356; //0
    code[102]=3881; //fake-ExpressionStatement_1_3881_5
    code[100]=853; //fake-ExpressionStatement_1_853_3
    code[107]=2475; //fake-ExpressionStatement_1_2475_10
    code[88]=3723; //fake-ExpressionStatement_1_3723_-9
    code[105]=2179; //fake-ExpressionStatement_1_2179_8

    code[169]=3110; //IfStatementSyntax_2 # IfStatementSyntax_2
    code[163]=2553; //jmpDestinationName_2553
    code[179]=2788; //var_ifCondition_0
    code[158]=1437; //if_GoTo_True_1437
    code[167]=3590; //if_GoTo_False_3590
    code[185]=95; //fake-fake-ifVirtualOperation_95_16
    code[149]=526; //fake-fake-ifVirtualOperation_526_-20

    code[237]=2162; //ReturnStatement_3 # ReturnStatement_3
    code[251]=3189; //1
    code[259]=3861; //fake-ReturnStatement_3_3861_22
    code[231]=3638; //fake-ReturnStatement_3_3638_-6
    code[226]=1126; //fake-ReturnStatement_3_1126_-11

    code[295]=9456; //ExpressionStatement_4 # ExpressionStatement_4
    code[293]=1567; //if_FalseBlockSize_Skip_1567
    code[323]=521; //fake-ExpressionStatement_4_521_28
    code[317]=3014; //fake-ExpressionStatement_4_3014_22

    code[353]=3044; //ExpressionStatement_5 # ExpressionStatement_5
    code[363]=3826; //var_forIndex_0
    code[366]=2449; //2
    code[374]=521; //fake-ExpressionStatement_5_521_21
    code[364]=366; //fake-ExpressionStatement_5_366_11
    code[359]=12; //fake-ExpressionStatement_5_12_6

    code[420]=2464; //ExpressionStatement_6 # ExpressionStatement_6
    code[421]=2780; //var_whileCondition_0
    code[415]=3826; //var_forIndex_0
    code[405]=2830; //num
    code[439]=3637; //fake-ExpressionStatement_6_3637_19
    code[417]=643; //fake-ExpressionStatement_6_643_-3

    code[489]=7435; //IfStatementSyntax_2 # WhileStatementSyntax_7
    code[483]=2181; //jmpWhileDestinationName_2181
    code[499]=2780; //var_whileCondition_0
    code[478]=3604; //while_GoTo_True_3604
    code[487]=3138; //while_GoTo_False_3138
    code[476]=2057; //fake-fake-whileVirtualOperation_2057_-13
    code[494]=3210; //fake-fake-whileVirtualOperation_3210_5

    code[557]=8145; //ExpressionStatement_8 # ExpressionStatement_8
    code[537]=2593; //result
    code[558]=2593; //result
    code[581]=3826; //var_forIndex_0
    code[556]=3223; //fake-ExpressionStatement_8_3223_-1
    code[546]=82; //fake-ExpressionStatement_8_82_-11
    code[545]=3874; //fake-ExpressionStatement_8_3874_-12
    code[577]=433; //fake-ExpressionStatement_8_433_20
    code[579]=1307; //fake-ExpressionStatement_8_1307_22

    code[619]=3322; //ExpressionStatement_9 # ExpressionStatement_9
    code[603]=3826; //var_forIndex_0
    code[614]=3826; //var_forIndex_0
    code[644]=926; //1
    code[604]=3683; //fake-ExpressionStatement_9_3683_-15
    code[599]=1569; //fake-ExpressionStatement_9_1569_-20
    code[624]=576; //fake-ExpressionStatement_9_576_5

    code[672]=2464; //ExpressionStatement_6 # ExpressionStatement_10
    code[673]=2780; //var_whileCondition_0
    code[667]=3826; //var_forIndex_0
    code[657]=2830; //num
    code[687]=3857; //fake-ExpressionStatement_6_3857_15

    code[741]=9456; //ExpressionStatement_4 # ExpressionStatement_11
    code[739]=2413; //while_FalseBlockSkip_2413
    code[768]=357; //fake-ExpressionStatement_4_357_27
    code[749]=388; //fake-ExpressionStatement_4_388_8
    code[740]=3001; //fake-ExpressionStatement_4_3001_-1
    code[750]=1230; //fake-ExpressionStatement_4_1230_9

    code[799]=2162; //ReturnStatement_3 # ReturnStatement_12
    code[813]=2593; //result
    code[809]=1045; //fake-ReturnStatement_3_1045_10
    code[825]=573; //fake-ReturnStatement_3_573_26
    code[821]=3864; //fake-ReturnStatement_3_3864_22

    while(true)
    {
    	switch(code[vpc])
    	{
    		case 5941: //frequency 1 ExpressionStatement_1
    			data[code[vpc+(27)]]= (int)data[code[vpc+(15)]]== (int)data[code[vpc+(22)]];
    			vpc+=72;
    			break;
    		case 3322: //frequency 1 ExpressionStatement_9
    			data[code[vpc+(-16)]]= (int)data[code[vpc+(-5)]]+ (int)data[code[vpc+(25)]];
    			vpc+=53;
    			break;
    		case 2464: //frequency 2 ExpressionStatement_6
    			data[code[vpc+(1)]]= (int)data[code[vpc+(-5)]]<= (int)data[code[vpc+(-15)]];
    			vpc+=69;
    			break;
    		case 8145: //frequency 1 ExpressionStatement_8
    			data[code[vpc+(-20)]]= (long)data[code[vpc+(1)]]* (int)data[code[vpc+(24)]];
    			vpc+=62;
    			break;
    		case 9456: //frequency 2 ExpressionStatement_4
    			vpc += (int)data[code[vpc+(-2)]];
    			vpc+=58;
    			break;
    		case 3044: //frequency 1 ExpressionStatement_5
    			data[code[vpc+(10)]]= data[code[vpc+(13)]];
    			vpc+=67;
    			break;
    		case 2162: //frequency 2 ReturnStatement_3
    			return (long)data[code[vpc+(14)]];
    			vpc+=58;
    		default: //frequency 2 IfStatementSyntax_2
    			data[code[vpc+(-6)]]=(bool)data[code[vpc+(10)]]?(int)data[code[vpc+(-11)]]:(int)data[code[vpc+(-2)]];
    			vpc+=(int)data[code[vpc+(-6)]];
    			break;
    		case 5457: //frequency 1 ExpressionStatement_0
    			data[code[vpc+(-14)]]= (int)data[code[vpc+(1)]]+ (long)data[code[vpc+(20)]];
    			vpc+=67;
    			break;
    	}
    }

    return 0;
}

        //       [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
        public long FactorialIterative_method_1(int num)
{
    //Virtualization variables
    int[] code = new int[100306];
    object[] data = new object[4820];
    int vpc = 99;

    //Data init
    data[741]=num; //num 
    data[824]=1 ; //1 constant
    data[213]=(long)0L; //0L constant
    data[53]=0; //0 constant
    data[2830]=(long)1; //1 constant
    data[1193]=2; //2 constant
    data[2807]=(long)-91L; //result 
    data[1341]=false; //var_ifCondition_0 
    data[2033]=15; //var_forIndex_0 
    data[2084]=false; //var_whileCondition_0 
    data[1492]=708; //jmpDestinationName_1492 constant
    data[1520]=70; //if_GoTo_True_1520 constant
    data[296]=184; //if_GoTo_False_296 constant
    data[659]=512; //if_FalseBlockSize_Skip_659 constant
    data[410]=645; //jmpWhileDestinationName_410 constant
    data[3635]=70; //while_GoTo_True_3635 constant
    data[1131]=317; //while_GoTo_False_1131 constant
    data[2991]=-317; //while_FalseBlockSkip_2991 constant

    //Code init

    code[99]=9336; //ExpressionStatement_0 # ExpressionStatement_0
    code[96]=2807; //result
    code[90]=824; //1
    code[118]=213; //0L

    code[161]=5420; //ExpressionStatement_1 # ExpressionStatement_1
    code[174]=1341; //var_ifCondition_0
    code[184]=741; //num
    code[188]=53; //0

    code[221]=4823; //IfStatementSyntax_2 # IfStatementSyntax_2
    code[209]=1492; //jmpDestinationName_1492
    code[248]=1341; //var_ifCondition_0
    code[244]=1520; //if_GoTo_True_1520
    code[242]=296; //if_GoTo_False_296

    code[291]=2635; //ReturnStatement_3 # ReturnStatement_3
    code[303]=2830; //1

    code[353]=2429; //ExpressionStatement_4 # ExpressionStatement_4
    code[379]=659; //if_FalseBlockSize_Skip_659

    code[405]=1931; //ExpressionStatement_5 # ExpressionStatement_5
    code[398]=2033; //var_forIndex_0
    code[401]=1193; //2

    code[468]=3747; //ExpressionStatement_6 # ExpressionStatement_6
    code[486]=2084; //var_whileCondition_0
    code[449]=2033; //var_forIndex_0
    code[474]=741; //num

    code[538]=4823; //IfStatementSyntax_2 # WhileStatementSyntax_7
    code[526]=410; //jmpWhileDestinationName_410
    code[565]=2084; //var_whileCondition_0
    code[561]=3635; //while_GoTo_True_3635
    code[559]=1131; //while_GoTo_False_1131

    code[608]=2478; //ExpressionStatement_8 # ExpressionStatement_8
    code[622]=2807; //result
    code[609]=2807; //result
    code[634]=2033; //var_forIndex_0

    code[673]=1920; //ExpressionStatement_9 # ExpressionStatement_9
    code[662]=2033; //var_forIndex_0
    code[655]=2033; //var_forIndex_0
    code[692]=824; //1

    code[733]=3747; //ExpressionStatement_6 # ExpressionStatement_10
    code[751]=2084; //var_whileCondition_0
    code[714]=2033; //var_forIndex_0
    code[739]=741; //num

    code[803]=2429; //ExpressionStatement_4 # ExpressionStatement_11
    code[829]=2991; //while_FalseBlockSkip_2991

    code[855]=2635; //ReturnStatement_3 # ReturnStatement_12
    code[867]=2807; //result

    while(true)
    {
    	switch(code[vpc])
    	{
    		case 4823: //frequency 2 IfStatementSyntax_2
    			data[code[vpc+(-12)]]=(bool)data[code[vpc+(27)]]?(int)data[code[vpc+(23)]]:(int)data[code[vpc+(21)]];
    			vpc+=(int)data[code[vpc+(-12)]];
    			break;
    		case 1920: //frequency 1 ExpressionStatement_9
    			data[code[vpc+(-11)]]= (int)data[code[vpc+(-18)]]+ (int)data[code[vpc+(19)]];
    			vpc+=60;
    			break;
    		case 1931: //frequency 1 ExpressionStatement_5
    			data[code[vpc+(-7)]]= data[code[vpc+(-4)]];
    			vpc+=63;
    			break;
    		case 2429: //frequency 2 ExpressionStatement_4
    			vpc += (int)data[code[vpc+(26)]];
    			vpc+=52;
    			break;
    		default: //frequency 0 
    			break;
    		case 9336: //frequency 1 ExpressionStatement_0
    			data[code[vpc+(-3)]]= (int)data[code[vpc+(-9)]]+ (long)data[code[vpc+(19)]];
    			vpc+=62;
    			break;
    		case 2478: //frequency 1 ExpressionStatement_8
    			data[code[vpc+(14)]]= (long)data[code[vpc+(1)]]* (int)data[code[vpc+(26)]];
    			vpc+=65;
    			break;
    		case 3747: //frequency 2 ExpressionStatement_6
    			data[code[vpc+(18)]]= (int)data[code[vpc+(-19)]]<= (int)data[code[vpc+(6)]];
    			vpc+=70;
    			break;
    		case 5420: //frequency 1 ExpressionStatement_1
    			data[code[vpc+(13)]]= (int)data[code[vpc+(23)]]== (int)data[code[vpc+(27)]];
    			vpc+=60;
    			break;
    		case 2635: //frequency 2 ReturnStatement_3
    			return (long)data[code[vpc+(12)]];
    			vpc+=62;
    	}
    }

    return 0;
}

        //        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        public long FactorialIterative_refactored(int num)
{
    long result = 1 + 0L;
    bool var_ifCondition_0 = num == 0;
    if (var_ifCondition_0)
    {
        return 1;
    }
    else
    {
        int var_forIndex_0 = 2;
        bool var_whileCondition_0 = var_forIndex_0 <= num;
        while (var_whileCondition_0)
        {
            result = result * var_forIndex_0;
            var_forIndex_0 = var_forIndex_0 + 1;
            var_whileCondition_0 = var_forIndex_0 <= num;
        }

        return result;
    }
}

        public long FactorialIterative_1(int num)
        {
            long result = 12343L;

            if (num == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 2; i <= num; i++)
                {
                    result *= i;
                }
                return result;
            }
        }

        private void FactorialIterative_Check(int arg)
        {
            string testName = "Code#FactorialIterative_Check_"+arg;
            bool condition = true;
            Program.Start_Check(testName);
            
            long virt = FactorialIterative_0(arg);
            long oracle = FactorialIterative_1(arg);
            Console.WriteLine(testName + " => " + virt);
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

        #endregion

        #region FACTORIAL_RECURSIVE

//        [Obfuscation(Exclude = false, Feature = "virtualization-class")]
        public static long FactorialRecursive_0(int num)
        {
            int c = 0;
            
            if (num == 0)
            {
                return 1;
            }
           
            return num * FactorialRecursive_0(num - 1);
        }

        public long FactorialRecursive_1(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                return num * FactorialRecursive_1(num - 1);
            }
        }


        private void FactorialRecursive_Check(int arg)
        {
            string testName = "Code#FactorialRecursive_Check_" + arg;
            bool condition = true;
            Program.Start_Check(testName);

            long virt = FactorialRecursive_0(arg);
            long oracle = FactorialRecursive_1(arg);
            Console.WriteLine(testName + " => " + virt);
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

        #endregion


       


    }
}