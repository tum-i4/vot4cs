using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class ExceptionTests
    {

        public static void RunExceptionTests()
        {
            ExceptionTests et = new ExceptionTests();

//            et.TryCatchSimple_Check();

//            et.TryCatchNested_Check();
            
        }

        class ExceptionA : Exception
        {
            protected ExceptionA(string message) : base(message)
            {                
            }

            public ExceptionA() : base("ExceptionA")
            {
            }
        }

        class ExceptionB : ExceptionA
        {
            public ExceptionB() : base("Exception B")
            { }
        }        

        public static void DivideException()
        {
            throw new DivideByZeroException();
        }

        public static void ThrowExceptionA() 
        {
            throw new ExceptionA();
        }

        public static void ThrowExceptionB()
        {
            throw new ExceptionB();
        }

        #region NESTED_TryCatch

//        [Obfuscation(Exclude = false, Feature = "virtualization; refactor; readable")]
        private string TryCatchNested_0(int a, int b)
        {
            string sum = ""+ a + b;
            try
            {                
                sum += b/a;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("divided by zero 0");
                try
                {
                    ThrowExceptionA();
                }
                catch (ExceptionA ea)
                {
                    sum += ea.Message;
                    return sum;
                }
                sum += 0;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("An index was out of range!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some sort of error occured: " + ex.Message);
            }
            finally
            {
                sum += "finally";
            }
            return sum;
        }

        private string TryCatchNested_1(int a, int b)
        {
            string sum = "" + a + b;
            try
            {
                sum += b / a;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("divided by zero 0");
                try
                {
                    ThrowExceptionA();
                }
                catch (ExceptionA ea)
                {
                    sum += ea.Message;
                    return sum;
                }
                sum += 0;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("An index was out of range!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some sort of error occured: " + ex.Message);
            }
            finally
            {
                sum += "finally";
            }
            return sum;
        }

        private void TryCatchNested_Check()
        {
            string testName = "Code#TryCatchNested_Check";
            Program.Start_Check(testName);
            int a = 0;
            int b = 3;
            string virt = TryCatchNested_0(a, b);
            string oracle = TryCatchNested_1(a, b);
            Console.WriteLine("virt {0} = {1} orig", virt, oracle);
            bool condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

        #endregion



        #region SIMPLE_TryCatch

        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; readable")]
        private string TryCatchSimple_0(int a, int b)
        {
            string sum = "" + a + b;
            try
            {
                sum += b / a;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("divided by zero 1");
                sum += "divided by zero 1";
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("An index was out of range!");
                sum += "An index was out of range!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some sort of error occured: " + ex.Message);
                sum += ex.Message;
            }
            finally
            {
                sum += "finally";
            }

            return sum;
        }


        private string TryCatchSimple_1(int a, int b)
        {
            string sum = "" + a + b;
            try
            {
                sum += b / a;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("divided by zero 1");
                
                sum += "divided by zero 1";
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("An index was out of range!");
                sum += "An index was out of range!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some sort of error occured: " + ex.Message);
                sum += ex.Message;
            }
            finally
            {
                sum += "finally";
            }

            object[] data = new object[20];
            int[] code = new int[100];
            int vpc = 0;
            code[0] = 5;
            code[1] = 1;
            code[2] = 10;
            code[3] = 10;
            interpreter(vpc, data, code);
            return sum;
        }


        private object interpreter(int vpc, object[] data, int[] code)
        {

            while (true)
            {
                switch (code[vpc++])
                {
                    case 10:                        
                        DivideException();
                        vpc++;
                        break;                    
                    case 1:
                        try
                        {                            
                            return interpreter(vpc, data, code);
                        }
                        catch (DivideByZeroException ex)
                        {
//                            vpc = code[vpc]
                            data[code[vpc++]] = ex;                         
                            return interpreter(vpc, data, code);
                        }
                        finally
                        {
                            interpreter(vpc, data, code);
                        }
                    case 2:
                        try
                        {
                            return interpreter(vpc, data, code);
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            //                            testData[code[vpc++]] = ex;
                            return interpreter(vpc, data, code);
                        }
                        finally
                        {
                            interpreter(vpc, data, code);
                        }
                    case 3:
                        try
                        {                         
                            return interpreter(vpc, data, code);
                        }
                        catch (Exception ex)
                        {
                            //                            testData[code[vpc++]] = ex;
                            return interpreter(vpc, data, code);
                        }
                        finally
                        {
                            interpreter(vpc, data, code);
                        }
                    case 4: //finally
                        return interpreter(vpc, data, code);
                    case 5: //other operation
                        Console.WriteLine("operation 5");
                        
                        break;
                    case 6: //other operation 2
                        Console.WriteLine("operation 6");
                        break;
                }
//                return null;
            }
        }




        private void TryCatchSimple_Check()
        {
            string testName = "Code#TryCatchSimple_Check";
            Program.Start_Check(testName);
            int a = 0;
            int b = 3;
            string virt = TryCatchSimple_0(a, b);
            string oracle = TryCatchSimple_1(a, b);
            Console.WriteLine("virt {0} = {1} orig", virt, oracle);
            bool condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

        

        #endregion

    }
}