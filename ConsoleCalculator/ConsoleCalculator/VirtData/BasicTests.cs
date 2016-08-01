using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class BasicTests
    {

        public static void RunBasicTests()
        {
            BasicTests bt = new BasicTests();
            //            bt.LocalVariables_Check();
            //            bt.OutParamTestString_Check();

            //            bt.OutParamSimple_Check();
            //            bt.RefParamSimple_Check();
            //            bt.BasicTypes_Check();
            //            bt.GenericsArray_Check();

            //            bt.StructSimple_Check();

//            Console.WriteLine("#ADDITION obfuscated result: " + bt.addition_obfuscated() + "\n");
//            Console.WriteLine("#ADDITION original result: " + bt.addition_original() + "\n");
        }

//        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string addition_obfuscated()
        {
            int a = 2;
            int b = 5;
            string sum = "" + (b - a);

            Console.WriteLine(sum);

            return sum;
        }

        private string addition_original()
        {
            int a = 2;
            int b = 5;
            string sum = "" + (b - a);

            Console.WriteLine(sum);

            return sum;
        }

        //        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        private string addition_0()
{
    int a = 2;
    int b = 5;
    int parTemp_0 = b - a;
    string sum = "" + parTemp_0;
    Console.WriteLine(sum);
    return sum;
}

        #region BASIC_TYPES
        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        private double BasicTypes(int a, int b)
        {
            /* http://www.tutorialspoint.com/csharp/csharp_data_types.htm */
            short s = 2;
            decimal dec = 0.02M;
            float fl = 0.3f;
            long lg = 9223372036854775L;
            sbyte sb = 123;
            uint ui = 4000000000;
            ulong ul = 120L;
            ushort us = 65000;
            int d = 3, f = 5;    /* initializing d and f. */
            byte z = 22;         /* initializes z. */
            double pi = 3.14159; /* declares an approximation of pi. */
            char x = 'x';        /* the variable x has the value 'x'. */

            bool condition = false;

            if (a > b)
                condition = true;

            int sum = b + a;
            while (true)
            {
                sum = sum - 1;
                if (condition)
                    break;
                if (sum == 0)
                    break;
            }

            pi += s + fl + lg + sb + ui + ul + us + d + z + x;

            if (condition)
                sum += sum;
                        
            return pi + sum;
        }


        private double BasicTypes_0(int a, int b)
        {
            short s = 2;
            decimal dec = 0.02M;
            float fl = 0.3f;
            long lg = 9223372036854775L;
            sbyte sb = 123;
            uint ui = 4000000000;
            ulong ul = 120L;
            ushort us = 65000;
            int d = 3, f = 5;    /* initializing d and f. */
            byte z = 22;         /* initializes z. */
            double pi = 3.14159; /* declares an approximation of pi. */
            char x = 'x';        /* the variable x has the value 'x'. */

            bool condition = false;

            if (a > b)
                condition = true;

            int sum = b + a;
            while (true)
            {
                sum = sum - 1;
                if (condition)
                    break;
                if (sum == 0)
                    break;
            }

            pi += s + fl + lg + sb + ui + ul + us + d + z + x;

            if (condition)
                sum += sum;

            return pi + sum;
        }

        private void BasicTypes_Check()
        {
            string testName = "BasicTypes_Check";
            bool condition = true;
            Program.Start_Check(testName);

            int a = 3;
            int b = 4;
            bool cond1 = BasicTypes(a, b) == BasicTypes_0(a, b);
            bool cond2 = BasicTypes(b, a) == BasicTypes_0(b, a);
            condition = cond1 && cond2;

            Program.End_Check(testName, condition);
        }


        #endregion

        private int getValue(int integerValue)
        {
            return integerValue;
        }

        private double getValue(double doubleValue)
        {
            return doubleValue;
        }

        private static int getStaticValue(int integerValue)
        {
            return integerValue;
        }


        #region REF_PARAM_SIMPLE

        /**
         * Cannot replace ref/out parameters because it is possible that they are not initialized.
         * Additionally, there is not support to create and array of references.
         * http://www.dotnetperls.com/parameter
         * http://stackoverflow.com/questions/7472278/c-sharp-array-of-references
         */

//        [Obfuscation(Exclude = false, Feature = "local virt")]
        private void RefParamSimple(string value, ref int length, ref string text, ref int[] array, ref Car car)
        {
            length = value.Length;
            text = "text";
            array = new[] {123};
            car = new Car("car", 1);
        }

        private void SetValue(int value, ref int dest)
        {
            dest = value;
        }
        private void RefParam_1(string value, ref int length)
        {
            object[] dataObject = new object[10];            
            
            //when virtualized:           
            dataObject[1] = length;

//            SetValue(value.Length, ref  ((int) dataObject[1])); // compiler error.
//            SetValue(value.Length, ref dataObject[1]);          // compiler error.
        }

        private void RefParamSimple_0(string value, ref int length, ref string text, ref int[] array, ref Car car)
        {
            length = value.Length;
            text = "text";
            array = new[] { 123 };
            car = new Car("car", 1);
        }

        private void RefParamSimple_Check()
        {
            Console.WriteLine("\nStart RefParamSimple_Check");
            string input = "abcd";
            
            Car car1 = null;
            Car car2 = new Car("car2", 2);
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 11, 2, 3 };
            int l1 = 0;
            int l2 = 1;
            string s1 = null;
            string s2 = "a";
            RefParamSimple(input, ref l1, ref s1, ref array1, ref car1);
            RefParamSimple_0(input, ref l2, ref s2, ref array2, ref car2);

            bool condition = (l1 == l2) && (s1.Equals(s2)) && (array1[0]==array2[0]) && (car1.Equals(car2));

            if (!condition)
            {
                throw new Exception("RefParamSimple_Check fail");
            }
            Console.WriteLine("RefParamSimple_Check - " + condition);
            Console.WriteLine("---------------");
        }

//        private void RefParamSimple1(string value, ref int length, ref string text)
//        {
//            uint[] array = new uint[210];
//            array[0] = 211u;
//            object[] array2 = new object[52];
//            int num = -1;
//            num++;
//            array2[1] = "text";
//            array2[0] = value;
//            array2[2] = text;
//            length = ((string)array2[0]).Length;
//            text = (string)array2[1];
//            //array2[2] = (string)array2[1]; //cannot do this!!
//        }


        #endregion

        #region OUT_PARAM_SIMPLE
//        [Obfuscation(Exclude = false, Feature = "local virt")]
        private void OutParamSimple(string value, out int length, out string text, out int[] array, out Car car)
        {            
            length = value.Length;
            text = "text";
            array = new[] { 123 };
            car = new Car("car", 1);
        }

        private void OutParamSimple_0(string value, out int length, out string text, out int[] array, out Car car)
        {
            length = value.Length;
            text = "text";
            array = new[] { 123 };
            car = new Car("car", 1);
        }

        private void OutParamSimple_Check()
        {
            Console.WriteLine("\nStart OutParamSimple_Check");
            string input = "abcd";
            Car car1 ;
            Car car2 ;
            int[] array1 ;
            int[] array2 ;
            int l1;
            string s1;
            int l2;
            string s2;
            OutParamSimple(input, out l1, out s1, out array1, out car1);
            OutParamSimple_0(input, out l2, out s2, out array2, out car2);

            bool condition = (l1 == l2) && (s1.Equals(s2)) && (array1[0] == array2[0]) && (car1.Equals(car2));

            if (!condition)
            {
                throw new Exception("OutParamSimple_Check fail");
            }
            Console.WriteLine("OutParamSimple_Check - " + condition);
            Console.WriteLine("---------------");
        }

        // ConsoleCalculator.BasicTests
//        private void OutParamSimple1(string value, out int length, out string text)
//        {
//            uint[] array = new uint[210];
//            array[0] = 211u;
//            object[] array2 = new object[52];
//            int num = -1;
//            num++;
//            array2[1] = "text";
//            array2[0] = value;
//            array2[2] = text; //cannot do this - param not initialized!!
//            length = ((string)array2[0]).Length;
//            text = (string)array2[1];
//        }


        #endregion

        #region OUT_PARAM
        //TODO: test out param - done
//        [Obfuscation(Exclude = false, Feature = "local virt")]
        private void OutParamTestString(string value, out bool period, out bool comma, out bool semicolon)
        {
            // Assign all out parameters to false.
            period = comma = semicolon = false;

            for (int i = 0; i < value.Length; i++)
            {
                switch (value[i])
                {
                    case '.':
                        {
                            period = true; // Set out parameter.
                            break;
                        }
                    case ',':
                        {
                            comma = true; // Set out parameter.
                            break;
                        }
                    case ';':
                        {
                            semicolon = true; // Set out parameter.
                            break;
                        }
                }
            }
        }

        private void OutParamTestString_0(string value, out bool period, out bool comma, out bool semicolon)
        {
            // Assign all out parameters to false.
            period = comma = semicolon = false;

            for (int i = 0; i < value.Length; i++)
            {
                switch (value[i])
                {
                    case '.':
                        {
                            period = true; // Set out parameter.
                            break;
                        }
                    case ',':
                        {
                            comma = true; // Set out parameter.
                            break;
                        }
                    case ';':
                        {
                            semicolon = true; // Set out parameter.
                            break;
                        }
                }
            }
        }

        /** http://www.dotnetperls.com/out */
        private void OutParamTestString_Check()
        {
            Console.WriteLine("\nStart OutParamTestString_Check");
            const string value = "has period, comma."; // Used as input string.
            bool period; // Used as out parameter.
            bool comma;
            bool semicolon;            
            OutParamTestString(value, out period, out comma, out semicolon);
            bool period0;
            bool comma0;
            bool semicolon0;
            OutParamTestString_0(value, out period0, out comma0, out semicolon0);
            bool condition = (period == period0) && (comma == comma0) && (semicolon == semicolon0);

            if (!condition)
            {
                throw new Exception("OutParamTestString_Check fail");
            }
            Console.WriteLine("OutParamTestString_Check - " + condition);
            Console.WriteLine("---------------");
        }

        #endregion


        #region LOCAL_VAR
        //TODO: test this - done
        //TODO: test load int - done
        //TODO: test load string - done
        //TODO: test static method - done

//        [Obfuscation(Exclude = false, Feature = "local virt")]
        private string LocalVariables(string a, string b)
        {
            string local1 = a;
            string local2 = b;
//            int local3 = getValue(11);
//            int local4 = getStaticValue(12);

            string sum = "";

            int comp = sum.Length > 10 ? 20 - (a.ToLower().Equals(b)?1:b.Length) : a.Length + 5;

//            if (sum.Length > comp)
//            {
//                local1 = local1 + 1;
//            }
//                
//            else
//            {
//                local2 = local1;
//            }

            sum = sum + local1 + local2 + comp;
//            sum -= local3 + local4;
            Console.WriteLine("virt- "+sum);
            return sum;
        }

        private string LocalVariables_1(string a, string b)
        {
            string local1 = a;
            string local2 = b;
            //            int local3 = getValue(11);
            //            int local4 = getStaticValue(12);

            string sum = "";
            int comp = sum.Length > 10 ? 20 - (a.ToLower().Equals(b) ? 1 : b.Length) : a.Length + 5;
//            if (sum.Length > comp)
//            {
//                local1 = local1 + 1;
//            }
//
//            else
//            {
//                local2 = local1;
//            }

            sum = sum + local1 + local2 + comp;

            Console.WriteLine("virt- " + sum);
            return sum;
        }

        private string LocalVariables_0(string a, string b)
        {
            uint[] code = new uint[15];            
            object[] data = new object[62];
//            object[] data2 = new object[62];  
            int vpc = -1;
            vpc++;

            data[0] = a;
            data[1] = b;
            

//            data2[0] = a;
//            data2[1] = b;
            string local1 = a;
            string local2 = b;
//            int local3 = getValue(11);
//            int local4 = getStaticValue(12);

            code[0] = 2; //destionation
            code[1] = 0; //source 1
            code[2] = 1; //source 2
            code[3] = 2; //result

            code[4] = 1;
            code[5] = 0;
            
            Console.WriteLine();
//            int x = 0;
//
//            Console.WriteLine(x);           
//
//            Console.WriteLine(testData[x++]);
//            Console.WriteLine(x);
//            Console.WriteLine(testData[x++]);
//            Console.WriteLine(x);
//
//            int c = vpc;
//            Console.WriteLine("vpc init: "+ vpc);
            //int sum = local1 + local2 + a;
//            int v1 = (int) testData[code[vpc++]];
//            int v2 = (int) testData[code[vpc++]];
//            Console.WriteLine(v1);
//            Console.WriteLine(v2);
//            testData[code[vpc++]] = v1 + v2+ a;
            Console.WriteLine("testData: " + String.Join(",", new List<object>(data).ConvertAll(i => i == null ? " " : i.ToString()).ToArray()));
            data[code[vpc++]] = (string)data[code[vpc++]] + (string)data[code[vpc++]] + b + a;
            Console.WriteLine("testData: " + String.Join(",", new List<object>(data).ConvertAll(i => i == null ? " " : i.ToString()).ToArray()));
//            testData[code[vpc++]] = (string)testData[code[vpc++]] + (string)testData[code[vpc++]];
//            Console.WriteLine("testData: " + String.Join(",", new List<object>(testData).ConvertAll(i => i == null ? " " : i.ToString()).ToArray()));

//            Console.WriteLine();
            Console.WriteLine();
//            Console.WriteLine("vpc: "+ vpc + " - "+ testData[code[vpc]] );
//            Console.WriteLine("testData: " + String.Join(",", new List<object>(testData).ConvertAll(i => i==null?"":i.ToString()).ToArray()));
            Console.WriteLine("code: " + String.Join(",", new List<uint>(code).ConvertAll(i => i==0?" ":i.ToString()).ToArray()));


//            testData[code[c++]] = (int)testData[code[c++]] + (int)testData[code[c++]] + a;
//            Console.WriteLine("data2: " + String.Join(",", new List<object>(data2).ConvertAll(i => i == null ? "" : i.ToString()).ToArray()));
//            int v1 = (int) data2[code[c++]];
//            int v2 = (int) data2[code[c++]];
//            Console.WriteLine(v1);
//            Console.WriteLine(v2);
////            testData[code[c++]] = (int)testData[code[c++]] + (int)testData[code[c++]] + a;
//            data2[code[c++]] = v1 + v2 + a;
//            Console.WriteLine("data2: " + String.Join(",", new List<object>(data2).ConvertAll(i => i == null ? "" : i.ToString()).ToArray()));
//            Console.WriteLine("c: "+ data2[code[c]]);

//            if (sum > 9)
//            {
//                local1 = local1 + 1;
//            }
//
//            else
//            {
//                local2 = local1;
//            }
//
//            sum = sum - local1 - local2;
//            sum -= local3 + local4;

//            int sum = (int) testData[code[vpc++]];
//            Console.WriteLine("0- " + sum);
//            return sum;
            Console.WriteLine("0- " + data[code[vpc]]);
            return (string)data[code[vpc++]];
        }

        private void LocalVariables_Check()
        {
            string testName = "LocalVariables_Check";
            bool condition = true;
            Program.Start_Check(testName);
            string a = "a";
            string b = "b";
            string virt = LocalVariables(a,b);
            string oracle = LocalVariables_1(a,b);
            condition = virt.Equals(oracle);
            Program.End_Check(testName,condition);
        }


       

        #endregion


        #region GENERICS
        
        public class MyGenericArray<T>
        {
            private T[] array;
            
            public MyGenericArray(int size)
            {
                array = new T[size + 1];
            }

//            [Obfuscation(Exclude = false, Feature = "local virt")]
            public T getItem(int index)
            {
                var in2 = index + 1;
                in2 = index - in2;
                index = index + 1 - in2 - 1;
                return array[index];
            }


            public T getItem1(int index)
            {
                uint[] array = new uint[225];
                array[0] = 226u;
                object[] array2 = new object[54];
                int num = -1;
                num++;
                array2[1] = 1;
                array2[0] = index;
                array2[3] = this;
                int num2 = 0;
                array2[2] = num2;
                object obj = (int)array2[0] + (int)array2[1];
                array2[2] = obj;
                obj = (int)array2[0] - (int)array2[2];
                array2[2] = obj;
                obj = (int)array2[0] + (int)array2[1] - (int)array2[2] - (int)array2[1];
                array2[0] = obj;
                return ((BasicTests.MyGenericArray<T>)array2[3]).array[(int)array2[0]];
            }

//            [Obfuscation(Exclude = false, Feature = "local virt")]
            public void setItem(int index, T value)
            {
                array[index] = value;
            }
    }

        public class MyGenericArray_0<T>
        {
            private T[] array;

            public MyGenericArray_0(int size)
            {
                array = new T[size + 1];
            }
            
            public T getItem(int index)
            {
                var in2 = index + 1;
                in2 = index - in2;
                index = index + 1 - in2 - 1;
                return array[index];
            }

            public void setItem(int index, T value)
            {
                array[index] = value;
            }
   }

//         [Obfuscation(Exclude = false, Feature = "local virt")]
        private int GenericsArray()
         {           
            int result = 0;
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);
            for (int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c * 5);
            }            
            for (int c = 0; c < 5; c++)
            {
                result += intArray.getItem1(c);
            }
                        
            MyGenericArray<char> charArray = new MyGenericArray<char>(5);
            for (int c = 0; c < 5; c++)
            {
                charArray.setItem(c, (char)(c + 97));
            }
            for (int c = 0; c < 5; c++)
            {
                result += charArray.getItem1(c);
            }
            
            return result;
        }

        private int GenericsArray_0()
        {
            int result = 0;
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);
            for (int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c * 5);
            }
            for (int c = 0; c < 5; c++)
            {
                result += intArray.getItem(c);
            }

            MyGenericArray<char> charArray = new MyGenericArray<char>(5);
            for (int c = 0; c < 5; c++)
            {
                charArray.setItem(c, (char)(c + 97));
            }
            for (int c = 0; c < 5; c++)
            {
                result += charArray.getItem(c);
            }

            return result;
        }

        private void GenericsArray_Check()
        {
            string testName = "GenericsArray_Check";
            Program.Start_Check(testName);
            bool condition = false;

            int r1 = GenericsArray();
            int r2 = GenericsArray_0();
            condition = r1 == r2;
            Program.End_Check(testName,condition);
        }


        #endregion

        #region STRUCT

        struct Data
        {            
            public double LastValue;
        };

        struct Simple
        {
            public int Position;
            public bool Exists;
            public double LastValue;
            
            int _x;
            public int X
            {
                get { return _x; }
                set
                {
                    if (value < 10)
                    {
                        _x = value;
                    }                    
                }
            }
        };

        //TODO: not working for structures
//        [Obfuscation(Exclude = false, Feature = "virtualization; method; ")]
        static double StructSimple()
        {
            double result = 0;
            Data d;
            d.LastValue = 115;
            Simple s = new Simple();
            s.Position = 1;
            s.Exists = false;
            s.LastValue = 5.5;
            s.X = 20;

            result += s.Position + s.LastValue + s.X;
            s.X = 4;
            result += s.X + d.LastValue;

            return result;
        }

        static double StructSimple_0()
        {
            double result = 0;

            Data d;
            d.LastValue = 115;

            Simple s = new Simple();
            s.Position = 1;
            s.Exists = false;
            s.LastValue = 5.5;
            s.X = 20;

            result += s.Position +  s.LastValue + s.X;
            s.X = 4;
            result += s.X + d.LastValue;

            return result;
        }
      
        private void StructSimple_Check()
        {
            string testName = "StructSimple_Check";
            bool condition = true;
            Program.Start_Check(testName);

            double virt = StructSimple();
            double oracle = StructSimple_0();
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }


        #endregion


       

    }
}
