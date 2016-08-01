using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.VirtCode;

namespace ConsoleCalculator.Performance.ForLoop
{

    class ForLoop_Tests
    {
        private static int WARMUP = 500;
        private static int ITERATIONS = 250;
        private static int NUMBER_OF_LOOPS = 25;
        private static int NUMBER_OF_TESTS = 25;

        public static void RunTests()
        {
            Stopwatch timer = Stopwatch.StartNew();
            //            
//            StaticOperands_VariableInvocations_Profile();

            VariableOperands_StaticInvocations_Profile();

            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("\n\n>>>>>  ForLoop_Tests required    {0}    , sec", timespan.TotalSeconds);
            Output(time);
        }

        private static void Output(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        private static void VariableOperands_StaticInvocations_Profile()
        {
            ForLoop_op2_in1.NUMBER_OF_TESTS = NUMBER_OF_TESTS;
            ForLoop_op2_in1.NUMBER_OF_LOOPS = NUMBER_OF_LOOPS;
            ForLoop_op2_in1.ITERATIONS = ITERATIONS;
            ForLoop_op2_in1.WARMUP = WARMUP;
            ForLoop_op2_in1.RunLoopTests();
            //

            ForLoop_op3_in1.NUMBER_OF_TESTS = NUMBER_OF_TESTS;
            ForLoop_op3_in1.NUMBER_OF_LOOPS = NUMBER_OF_LOOPS;
            ForLoop_op3_in1.ITERATIONS = ITERATIONS;
            ForLoop_op3_in1.WARMUP = WARMUP;
            ForLoop_op3_in1.RunLoopTests();
            //

            ForLoop_op4_in1_0.NUMBER_OF_TESTS = NUMBER_OF_TESTS;
            ForLoop_op4_in1_0.NUMBER_OF_LOOPS = NUMBER_OF_LOOPS;
            ForLoop_op4_in1_0.ITERATIONS = ITERATIONS;
            ForLoop_op4_in1_0.WARMUP = WARMUP;
            ForLoop_op4_in1_0.RunLoopTests();
            //
        }

        private static void StaticOperands_VariableInvocations_Profile()
        {
            ForLoop_op4_in1.NUMBER_OF_TESTS = NUMBER_OF_TESTS;
            ForLoop_op4_in1.NUMBER_OF_LOOPS = NUMBER_OF_LOOPS;
            ForLoop_op4_in1.ITERATIONS = ITERATIONS;
            ForLoop_op4_in1.WARMUP = WARMUP;
            ForLoop_op4_in1.RunLoopTests();
            //

            ForLoop_op4_in2.NUMBER_OF_TESTS = NUMBER_OF_TESTS;
            ForLoop_op4_in2.NUMBER_OF_LOOPS = NUMBER_OF_LOOPS;
            ForLoop_op4_in2.ITERATIONS = ITERATIONS;
            ForLoop_op4_in2.WARMUP = WARMUP;
            ForLoop_op4_in2.RunLoopTests();
            //

            ForLoop_op4_in3.NUMBER_OF_TESTS = NUMBER_OF_TESTS;
            ForLoop_op4_in3.NUMBER_OF_LOOPS = NUMBER_OF_LOOPS;
            ForLoop_op4_in3.ITERATIONS = ITERATIONS;
            ForLoop_op4_in3.WARMUP = WARMUP;
            ForLoop_op4_in3.RunLoopTests();
            //

            ForLoop_op4_in4.NUMBER_OF_TESTS = NUMBER_OF_TESTS;
            ForLoop_op4_in4.NUMBER_OF_LOOPS = NUMBER_OF_LOOPS;
            ForLoop_op4_in4.ITERATIONS = ITERATIONS;
            ForLoop_op4_in4.WARMUP = WARMUP;
            ForLoop_op4_in4.RunLoopTests();
            //

            ForLoop_op4_in5.NUMBER_OF_TESTS = NUMBER_OF_TESTS;
            ForLoop_op4_in5.NUMBER_OF_LOOPS = NUMBER_OF_LOOPS;
            ForLoop_op4_in5.ITERATIONS = ITERATIONS;
            ForLoop_op4_in5.WARMUP = WARMUP;
            ForLoop_op4_in5.RunLoopTests();
            //
        }






    }
}
