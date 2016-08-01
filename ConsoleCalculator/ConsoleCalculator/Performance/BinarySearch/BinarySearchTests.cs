using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Performance.BinarySearch
{
    class BinarySearchTests
    {
        static int ELEMENTS = (int) (4 * 1000000);
        private static int WARMUP = 10;
        private static int ITERATIONS = 100;
        private static int RUNS = 25;


        public static void RunTests()
        {
            int[] values = GenerateDataInt(ELEMENTS);

            List<int> data = new List<int>(values);
            List<int> keys = new List<int>();
            keys.Add(-1);
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int element = rand.Next(-1000000, 1000000);
                keys.Add(element);
            }
            keys.Add(values[ELEMENTS / 2]);
            keys.Add(values[ELEMENTS - 50]);
            keys.Add(values[ELEMENTS / 5]);
            keys.Add(values[ELEMENTS - 10]);
            keys.Add(values[ELEMENTS / 15]);
            keys.Add(values[ELEMENTS - 1000]);
            keys.Add(values[ELEMENTS / 25]);
            keys.Add(values[ELEMENTS - 10000]);
            keys.Add(values[ELEMENTS / 35]);
            keys.Add(values[ELEMENTS / 45]);
            keys.Add(values[ELEMENTS / 55]);
            keys.Add(values[ELEMENTS / 65]);
            keys.Add(values[ELEMENTS / 21]);
            keys.Add(values[ELEMENTS - 501]);
            keys.Add(values[ELEMENTS / 52]);
            keys.Add(values[ELEMENTS - 102]);
            keys.Add(values[ELEMENTS / 153]);
            keys.Add(values[ELEMENTS - 10001]);
            keys.Add(values[ELEMENTS / 252]);
//            keys.Add(values[ELEMENTS - 100001]);
            keys.Add(values[ELEMENTS / 325]);
            keys.Add(values[ELEMENTS / 453]);
            keys.Add(values[ELEMENTS / 525]);
            keys.Add(values[ELEMENTS / 651]);
            keys.Add(values[ELEMENTS / 2512]);
//            keys.Add(values[ELEMENTS - 1002001]);
            keys.Add(values[ELEMENTS / 3225]);
            keys.Add(values[ELEMENTS / 4353]);
            keys.Add(values[ELEMENTS / 5225]);
            keys.Add(values[ELEMENTS / 6151]);
            bool testsEnabled = true;
//           bool testsEnabled = false;

            if (testsEnabled)
            {
                Stopwatch timer = Stopwatch.StartNew();
                BinarySearch_ITERATIVE(data, keys);
                BinarySearch_RECURSIVE(data, keys);
                timer.Stop();
                TimeSpan timespan = timer.Elapsed;
                string time = String.Format("\n\n>>>>>  BinarySearch_Tests required    {0}    , sec",
                    timespan.TotalSeconds);
                Output(time);
            }
            else
            {
                IterativeCheck();
                RecursiveCheck();
            }
//


        }

        private static void Output(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        private static void BinarySearch_ITERATIVE(List<int> data, List<int> keys)
        {           
            BinarySearch_Iterative.testData = data;
            BinarySearch_Iterative.keys = keys;
            BinarySearch_Iterative.ITERATIONS = ITERATIONS;
            BinarySearch_Iterative.WARMUP = WARMUP;
            BinarySearch_Iterative.NUMBER_OF_RUNS = RUNS;
            BinarySearch_Iterative.RunTests();


            BinarySearch_Iterative_ctrl_flow.testData = data;
            BinarySearch_Iterative_ctrl_flow.keys = keys;
            BinarySearch_Iterative_ctrl_flow.ITERATIONS = ITERATIONS;
            BinarySearch_Iterative_ctrl_flow.WARMUP = WARMUP;
            BinarySearch_Iterative_ctrl_flow.NUMBER_OF_RUNS = RUNS;
            BinarySearch_Iterative_ctrl_flow.RunTests();

            //BinarySearch_Iterative_method.testData = data;
            //BinarySearch_Iterative_method.keys = keys;
            //BinarySearch_Iterative_method.ITERATIONS = ITERATIONS;
            //BinarySearch_Iterative_method.WARMUP = WARMUP;
            //BinarySearch_Iterative_method.NUMBER_OF_RUNS = RUNS;
            //BinarySearch_Iterative_method.RunTests();

            //BinarySearch_Iterative_method_default.testData = data;
            //BinarySearch_Iterative_method_default.keys = keys;
            //BinarySearch_Iterative_method_default.ITERATIONS = ITERATIONS;
            //BinarySearch_Iterative_method_default.WARMUP = WARMUP;
            //BinarySearch_Iterative_method_default.NUMBER_OF_RUNS = RUNS;
            //BinarySearch_Iterative_method_default.RunTests();

            BinarySearch_Iterative_method_modified.testData = data;
            BinarySearch_Iterative_method_modified.keys = keys;
            BinarySearch_Iterative_method_modified.ITERATIONS = ITERATIONS;
            BinarySearch_Iterative_method_modified.WARMUP = WARMUP;
            BinarySearch_Iterative_method_modified.NUMBER_OF_RUNS = RUNS;
            BinarySearch_Iterative_method_modified.RunTests();

            //BinarySearch_Iterative_class.testData = data;
            //BinarySearch_Iterative_class.keys = keys;
            //BinarySearch_Iterative_class.ITERATIONS = ITERATIONS;
            //BinarySearch_Iterative_class.WARMUP = WARMUP;
            //BinarySearch_Iterative_class.NUMBER_OF_RUNS = RUNS;
            //BinarySearch_Iterative_class.RunTests();

            //BinarySearch_Iterative_class_default.testData = data;
            //BinarySearch_Iterative_class_default.keys = keys;
            //BinarySearch_Iterative_class_default.ITERATIONS = ITERATIONS;
            //BinarySearch_Iterative_class_default.WARMUP = WARMUP;
            //BinarySearch_Iterative_class_default.NUMBER_OF_RUNS = RUNS;
            //BinarySearch_Iterative_class_default.RunTests();
        }

        private static void BinarySearch_RECURSIVE(List<int> data, List<int> keys)
        {
            BinarySearch_Recursive.testData = data;
            BinarySearch_Recursive.keys = keys;
            BinarySearch_Recursive.ITERATIONS = ITERATIONS;
            BinarySearch_Recursive.WARMUP = WARMUP;
            BinarySearch_Recursive.NUMBER_OF_RUNS = RUNS;
            BinarySearch_Recursive.RunTests();

            BinarySearch_Recursive_ctrl_flow.testData = data;
            BinarySearch_Recursive_ctrl_flow.keys = keys;
            BinarySearch_Recursive_ctrl_flow.ITERATIONS = ITERATIONS;
            BinarySearch_Recursive_ctrl_flow.WARMUP = WARMUP;
            BinarySearch_Recursive_ctrl_flow.NUMBER_OF_RUNS = RUNS;
            BinarySearch_Recursive_ctrl_flow.RunTests();

            //BinarySearch_Recursive_method.testData = data;
            //BinarySearch_Recursive_method.keys = keys;
            //BinarySearch_Recursive_method.ITERATIONS = ITERATIONS;
            //BinarySearch_Recursive_method.WARMUP = WARMUP;
            //BinarySearch_Recursive_method.NUMBER_OF_RUNS = RUNS;
            //BinarySearch_Recursive_method.RunTests();

            //BinarySearch_Recursive_method_default.testData = data;
            //BinarySearch_Recursive_method_default.keys = keys;
            //BinarySearch_Recursive_method_default.ITERATIONS = ITERATIONS;
            //BinarySearch_Recursive_method_default.WARMUP = WARMUP;
            //BinarySearch_Recursive_method_default.NUMBER_OF_RUNS = RUNS;
            //BinarySearch_Recursive_method_default.RunTests();

            BinarySearch_Recursive_method_modified.testData = data;
            BinarySearch_Recursive_method_modified.keys = keys;
            BinarySearch_Recursive_method_modified.ITERATIONS = ITERATIONS;
            BinarySearch_Recursive_method_modified.WARMUP = WARMUP;
            BinarySearch_Recursive_method_modified.NUMBER_OF_RUNS = RUNS;
            BinarySearch_Recursive_method_modified.RunTests();
                         
            //BinarySearch_Recursive_class.testData = data;
            //BinarySearch_Recursive_class.keys = keys;
            //BinarySearch_Recursive_class.ITERATIONS = ITERATIONS;
            //BinarySearch_Recursive_class.WARMUP = WARMUP;
            //BinarySearch_Recursive_class.NUMBER_OF_RUNS = RUNS;
            //BinarySearch_Recursive_class.RunTests();
                         
            //BinarySearch_Recursive_class_default.testData = data;
            //BinarySearch_Recursive_class_default.keys = keys;
            //BinarySearch_Recursive_class_default.ITERATIONS = ITERATIONS;
            //BinarySearch_Recursive_class_default.WARMUP = WARMUP;
            //BinarySearch_Recursive_class_default.NUMBER_OF_RUNS = RUNS;
            //BinarySearch_Recursive_class_default.RunTests();
        }

        private static void IterativeCheck()
        {
            BinarySearch_Iterative bs = new BinarySearch_Iterative();
            bs.BinarySearch_Check();

            BinarySearch_Iterative_ctrl_flow bs_ctrl = new BinarySearch_Iterative_ctrl_flow();
            bs_ctrl.BinarySearch_Check();

            //BinarySearch_Iterative_method bs_method = new BinarySearch_Iterative_method();
            //bs_method.BinarySearch_Check();

            //            BinarySearch_Iterative_method_default bs_method_default = new BinarySearch_Iterative_method_default();
            //            bs_method_default.BinarySearch_Check();
            //
            //
            BinarySearch_Iterative_method_modified bs_method_modified = new BinarySearch_Iterative_method_modified();
            bs_method_modified.BinarySearch_Check();

            //
            //            BinarySearch_Iterative_class bs_class = new BinarySearch_Iterative_class();
            //            bs_class.BinarySearch_Check();
            //
            //
            //            BinarySearch_Iterative_class_default bs_class_default = new BinarySearch_Iterative_class_default();
            //            bs_class_default.BinarySearch_Check();
        }


        private static void RecursiveCheck()
        {
            BinarySearch_Recursive bs = new BinarySearch_Recursive();
            bs.BinarySearch_Check();

            BinarySearch_Recursive_ctrl_flow bs_ctrl = new BinarySearch_Recursive_ctrl_flow();
            bs_ctrl.BinarySearch_Check();

            //BinarySearch_Recursive_method bs_method = new BinarySearch_Recursive_method();
            //bs_method.BinarySearch_Check();

            //            BinarySearch_Recursive_method_default bs_method_default = new BinarySearch_Recursive_method_default();
            //            bs_method_default.BinarySearch_Check();
            //
            //
            BinarySearch_Recursive_method_modified bs_method_modified = new BinarySearch_Recursive_method_modified();
            bs_method_modified.BinarySearch_Check();
            //
            ////
            //            BinarySearch_Recursive_class bs_class = new BinarySearch_Recursive_class();
            //            bs_class.BinarySearch_Check();
            ////
            ////
            //            BinarySearch_Recursive_class_default bs_class_default = new BinarySearch_Recursive_class_default();
            //            bs_class_default.BinarySearch_Check();
        }

        private static int[] GenerateDataInt(int elements)
        {
            string[] str = new string[elements];
            int[] int1 = new int[elements];

            Random rand = new Random();
            for (int i = 0; i < elements; i++)
            {
                int element = rand.Next(-1000000, 1000000);
                int1[i] = element;
            }

            return int1;
        }


        private string Quicksort_original(int[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i] < pivot)
                {
                    i++;
                }

                while (elements[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort_original(elements, left, j);
            }

            if (i < right)
            {
                Quicksort_original(elements, i, right);
            }

            return "";
        }
    }
}
