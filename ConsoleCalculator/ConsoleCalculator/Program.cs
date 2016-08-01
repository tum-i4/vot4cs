using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.Performance;
using ConsoleCalculator.Tracing;
using ConsoleCalculator.VirtCode;
using ConsoleCalculator.VirtData;

//ConfuserEx
//[assembly: Obfuscation(Exclude = false, Feature = "preset(minimum);+ctrl flow;-anti debug;+rename(mode=letters,flatten=false);")]
//[assembly: Obfuscation(Exclude = false, Feature = "rename(mode=debug)")]
namespace ConsoleCalculator
{
    //[assembly: Obfuscation(Exclude = true, Feature = "control flow protection: true")]
    ///
    /// In the case of objects I doubt the usefulness of adding them to the testData array.
    /// When used, I have to cast them. So the type of object immediately becomes visible again.
    /// One idea is to use local variables for the initialization.
    /// 
    /// !! An object is different than constants! The initialization of an object depends on the scope of its parameters.
    /// One could create an object only at a specific moment in the algorithm when some parameters have some specific value.
    /// It is impossible to extract that specific value out of that context.
    /// If the value could be extracted, this means that there is the possibility of static analysis.
    /// But the ctrl flow obfuscations prevents exactly against this possibility.
    /// Therefore it is not possible to extract local variables outside their specific context.

    //////
    //TODO: assign field
    //TODO: test struct
    //TODO: test enum
    //TODO: test final
    //TODO: test class constants
    //TODO: test linq statements
    //TODO: test threading
    //TODO: test scope, closures
    //TODO: test UI elements
    //Eazfuscator options
    //Disabling class and its members renaming
    //[System.Reflection.ObfuscationAttribute(Feature = "renaming", ApplyToMembers = true)]
    partial class Program
    {
        public static string[] args_in;

        public static int TEST_ID = 0;
        public static int TEST_FAILED = 0;
        //[assembly: Obfuscation(Exclude = true, Feature = "control flow protection: true")]
        public static void Main(string[] args)
        {
            args_in = args;

            Program p = new Program();
            LoopTests.RunLoopTests();
            BasicTests.RunBasicTests();
            ExceptionTests.RunExceptionTests();
            BranchTests.RunBranchTests();
            FieldTests.RunFieldTests();
            ExtensionsTests.RunExtenstionTests();
            LambdaTests.RunLambdaTests();
            DelegatesTests.RunDelegatesTests();
            FileOperations.RunReadFileTests();
            CodeBasicTests.RunBasicTests();
            CodeBranchTests.RunBranchTests();
            CodeLoopTests.RunLoopTests();

            PerformanceTests.RunLoopTests();

            BasicOperations.RunBasicTests();

            TraceLoopTests.RunLoopTests();

            ConditionalExpressionTests.RunBasicTests();

            TestReport();
            Console.ReadKey();
        }

        private static void TestReport()
        {
            string fail = ">>FAILED TESTS: " + TEST_FAILED;
            Console.WriteLine(fail);
            string success = ">>PASSED TESTS: " + (TEST_ID - TEST_FAILED);
            Console.WriteLine(success);
        }

        public static void Start_Check(string testName)
        {
            Console.WriteLine("\n" + Program.TEST_ID++ + " > " + testName);
        }

        public static void End_Check(string testName, bool condition)
        {
            if (!condition)
            {
                Console.Error.WriteLine(">> !!!" + testName + " fail !!!");
                Program.TEST_FAILED++;
            }

            Console.WriteLine(testName + " - " + condition);
            Console.WriteLine("---------------");
        }

    }

    
}