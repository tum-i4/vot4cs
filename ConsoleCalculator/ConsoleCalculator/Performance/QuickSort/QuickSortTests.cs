using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.VirtCode;

namespace ConsoleCalculator.Performance.QuickSort
{

    class QuickSortTests
    {
        static int ELEMENTS = (int) (100 * 1000);
        private static int WARMUP = 5;
        private static int ITERATIONS = 1;
        private static int RUNS = 25;

        public static void RunTests()
        {
            
            string[] data = GenerateData(ELEMENTS);
            var int_list = new List<int>();
            foreach (var r in data)
            {
                var value = Int32.Parse(r);
                int_list.Add(value);
            }
            int[] unsorted_obfuscated = int_list.ToArray();
            int[] unsorted_original = int_list.ToArray();

            Stopwatch timer = Stopwatch.StartNew();
            QuickSort_ITERATIVE(int_list);
            
            QuickSort_RECURSIVE(int_list);
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("\n\n>>>>>  QuickSortTests required    {0}    , sec", timespan.TotalSeconds);
            Output(time);
        }

        private static void Output(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        private static void QuickSort_RECURSIVE(List<int> int_list)
        {
            QuickSortRecursive.testData = int_list;
            QuickSortRecursive.ITERATIONS = ITERATIONS;
            QuickSortRecursive.WARMUP = WARMUP;
            QuickSortRecursive.NUMBER_OF_RUNS = RUNS;
            QuickSortRecursive.RunLoopTests();

            QuickSortRecursive_ctrl_flow.testData = int_list;
            QuickSortRecursive_ctrl_flow.ITERATIONS = ITERATIONS;
            QuickSortRecursive_ctrl_flow.WARMUP = WARMUP;
            QuickSortRecursive_ctrl_flow.NUMBER_OF_RUNS = RUNS;
            QuickSortRecursive_ctrl_flow.RunLoopTests();

            //QuickSortRecursive_method.testData = int_list;
            //QuickSortRecursive_method.ITERATIONS = ITERATIONS;
            //QuickSortRecursive_method.WARMUP = WARMUP;
            //QuickSortRecursive_method.NUMBER_OF_RUNS = RUNS;
            //QuickSortRecursive_method.RunLoopTests();

            //            QuickSortRecursive_method_default.testData = int_list;
            //            QuickSortRecursive_method_default.ITERATIONS = ITERATIONS;
            //            QuickSortRecursive_method_default.WARMUP = WARMUP;
            //            QuickSortRecursive_method_default.NUMBER_OF_RUNS = RUNS;
            //            QuickSortRecursive_method_default.RunLoopTests();

            QuickSortRecursive_method_modified.testData = int_list;
            QuickSortRecursive_method_modified.ITERATIONS = ITERATIONS;
            QuickSortRecursive_method_modified.WARMUP = WARMUP;
            QuickSortRecursive_method_modified.NUMBER_OF_RUNS = RUNS;
            QuickSortRecursive_method_modified.RunLoopTests();
            ////
            //            QuickSortRecursive_class.testData = int_list;
            //            QuickSortRecursive_class.ITERATIONS = ITERATIONS;
            //            QuickSortRecursive_class.WARMUP = WARMUP;
            //            QuickSortRecursive_class.NUMBER_OF_RUNS = RUNS;
            //            QuickSortRecursive_class.RunLoopTests();

            //            QuickSortRecursive_class_default.testData = int_list;
            //            QuickSortRecursive_class_default.ITERATIONS = ITERATIONS;
            //            QuickSortRecursive_class_default.WARMUP = WARMUP;
            //            QuickSortRecursive_class_default.NUMBER_OF_RUNS = RUNS;
            //            QuickSortRecursive_class_default.RunLoopTests();
        }

        private static void QuickSort_ITERATIVE(List<int> int_list)
        {
            QuickSortIterative.data = int_list;
            QuickSortIterative.ITERATIONS = ITERATIONS;
            QuickSortIterative.WARMUP = WARMUP;
            QuickSortIterative.NUMBER_OF_RUNS = RUNS;         
            QuickSortIterative.RunLoopTests();

            QuickSortIterative_ctrl_flow.data = int_list;
            QuickSortIterative_ctrl_flow.ITERATIONS = ITERATIONS;
            QuickSortIterative_ctrl_flow.WARMUP = WARMUP;
            QuickSortIterative_ctrl_flow.NUMBER_OF_RUNS = RUNS;
            QuickSortIterative_ctrl_flow.RunLoopTests();

            //QuickSortIterative_method.data = int_list;
            //QuickSortIterative_method.ITERATIONS = ITERATIONS;
            //QuickSortIterative_method.WARMUP = WARMUP;
            //QuickSortIterative_method.NUMBER_OF_RUNS = RUNS;
            //QuickSortIterative_method.RunLoopTests();

            //QuickSortIterative_method_default.data = int_list;
            //QuickSortIterative_method_default.ITERATIONS = ITERATIONS;
            //QuickSortIterative_method_default.WARMUP = WARMUP;
            //QuickSortIterative_method_default.NUMBER_OF_RUNS = RUNS;
            //QuickSortIterative_method_default.RunLoopTests();

            QuickSortIterative_method_modified.data = int_list;
            QuickSortIterative_method_modified.ITERATIONS = ITERATIONS;
            QuickSortIterative_method_modified.WARMUP = WARMUP;
            QuickSortIterative_method_modified.NUMBER_OF_RUNS = RUNS;
            QuickSortIterative_method_modified.RunLoopTests();

            //QuickSortIterative_class.data = int_list;
            //QuickSortIterative_class.ITERATIONS = ITERATIONS;
            //QuickSortIterative_class.WARMUP = WARMUP;
            //QuickSortIterative_class.NUMBER_OF_RUNS = RUNS;
            //QuickSortIterative_class.RunLoopTests();

            //QuickSortIterative_class_default.data = int_list;
            //QuickSortIterative_class_default.ITERATIONS = ITERATIONS;
            //QuickSortIterative_class_default.WARMUP = WARMUP;
            //QuickSortIterative_class_default.NUMBER_OF_RUNS = RUNS;
            //QuickSortIterative_class_default.RunLoopTests();
        }

        private static string[] GenerateData(int elements)
        {
            string[] str = new string[elements];
            Int32[] int1 = new Int32[elements];

            Random rand = new Random();
            for (int i = 0; i < elements; i++)
            {
                string element = "" + rand.Next(-100000, 100000);
                str[i] = element;
            }

            return str;
        }

    }
}
