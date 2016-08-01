using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleCalculator.Performance.QuickSort
{
   
    class QuickSortRecursive
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> testData;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();


        public static void RunLoopTests()
        {
            QuickSortRecursive lt = new QuickSortRecursive();
            time_warmup.Clear();
            time_run.Clear();

            lt.Profile();
            PrintTimes();

//            lt.QuickSort_Check();
        }

        public static void PrintTimes()
        {
            foreach (var log in time_warmup)
            {
                Output(log);
            }

            foreach (var log in time_run)
            {
                Output(log);
            }

            Output("=============================");
            Output("=============================");
        }

        private void Profile()
        {
            //            lt.ForSimple_Check();
//            int ELEMENTS = 30;
            // Create an unsorted array of string elements
//            string[] unsorted_original = GenerateData(ELEMENTS);
//            string[] unsorted_method = (new List<string>(unsorted_original)).ToArray();
//            string[] unsorted_class = (new List<string>(unsorted_original)).ToArray();
//            string[] unsorted_method_default_junk = (new List<string>(unsorted_original)).ToArray();
//            string[] unsorted_class_default_junk = (new List<string>(unsorted_original)).ToArray();

            string result = "";

            result += "t_original";
            result += "     t_method";
            result += "     t_class";
//            result += " t_method_default";
//            result += " t_class_default";
            result += "     t_method_junk";
            result += "     t_class_junk";
            result += " " + "\n";

            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {
                Console.WriteLine(i + "##############");
                Debug.WriteLine(i + "##############");
                int[] unsorted_original = testData.ToArray();
                string t_original = Time_Operation("QuickSortRecursive_original", i, Quicksort_Recursive, unsorted_original, WARMUP, ITERATIONS);
//                string t_method = Time_Operation(VirtualizationType.METHOD, Quicksort_method, unsorted_method, WARMUP, ITERATIONS);
//                string t_class = Time_Operation(VirtualizationType.CLASS, Quicksort_class, unsorted_class, WARMUP, ITERATIONS);
//                string t_method_default = Time_Operation(VirtualizationType.ORIGINAL, ForSimple_Array_original, for_loop, WARMUP, ITERATIONS);
//                string t_class_default = Time_Operation(VirtualizationType.ORIGINAL, ForSimple_Array_original, for_loop, WARMUP, ITERATIONS);
//                string t_method_junk = Time_Operation(VirtualizationType.METHOD_JUNK, Quicksort_method_default_junk, unsorted_method_default_junk, WARMUP, ITERATIONS);
//                string t_class_junk = Time_Operation(VirtualizationType.CLASS_JUNK, Quicksort_class_default_junk, unsorted_class_default_junk, WARMUP, ITERATIONS);

                result += " " + t_original;
//                result += " " + t_method;
//                result += " " + t_class;
//                result += " " + t_method_default;
//                result += " " + t_class_default;
//                result += " " + t_method_junk;
//                result += " " + t_class_junk;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);
        }


       




//        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


//        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]

        private void QuickSort_Check()
        {
            string testName = "Performance#QuickSortRecursive_original_Check";
            Program.Start_Check(testName);
            bool condition = true;
            

            // Create an unsorted array of string elements
            int[] unsorted_original = GenerateDataInt(15);
            int[] unsorted_obfuscated = (new List<int>(unsorted_original)).ToArray();

            // Print the unsorted array
            for (int i = 0; i < unsorted_original.Length; i++)
            {
                Console.Write(unsorted_original[i] + " ");
            }
            Console.WriteLine();

            // Sort the array
            Quicksort_Recursive(unsorted_original, 0, unsorted_original.Length - 1);
            Quicksort_obfuscated(unsorted_obfuscated, 0, unsorted_obfuscated.Length - 1);

            // Print the sorted array
            string sortedOriginalHash = "";
            string sortedObfuscatedHash = "";
            for (int i = 0; i < unsorted_original.Length; i++)
            {
                sortedOriginalHash += unsorted_original[i] + "_";
                sortedObfuscatedHash += unsorted_obfuscated[i] + "_";
            }

            Console.WriteLine("ori: " + sortedOriginalHash);
            Console.WriteLine("obf: " + sortedObfuscatedHash);

            string virt = sortedObfuscatedHash;
            string oracle = sortedOriginalHash;
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

        private int[] GenerateDataInt(int elements)
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

        private string[] GenerateDataString(int elements)
        {
            string[] str = new string[elements];
            Int32[] int1 = new Int32[elements];

            Random rand = new Random();
            for (int i = 0; i < elements; i++)
            {
                string element = "" + rand.Next(0, 100000);
                str[i] = element;
            }
            
            return str;
        }

private string Quicksort_Recursive(int[] elements, int left, int right)
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
        Quicksort_Recursive(elements, left, j);
    }

    if (i < right)
    {
        Quicksort_Recursive(elements, i, right);
    }

    return "";
}



//        [Obfuscation(Exclude = false, Feature = "virtualization; method")]
        private string Quicksort_obfuscated(int[] elements, int left, int right)
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
                Quicksort_obfuscated(elements, left, j);
            }

            if (i < right)
            {
                Quicksort_obfuscated(elements, i, right);
            }

            return "";
        }

        public static string Time_Operation(string id, int runId, Func<int[], int, int, string> method, int[] elements, int warmup, int iterations)
        {

            int op = 0;
            string log = runId + " warming ... " + warmup + " times X elements " + elements.Length;
            Output(log);

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < warmup && runId < 1; i++)
            {
                int[] unsorted_original = testData.ToArray();
                method(unsorted_original, 0, unsorted_original.Length - 1);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("   {0}    , sec", timespan.TotalSeconds);
            log = id + " " + runId + " warmed up in,     " + time;
            Output(log);
            time_warmup.Add(log);

            log = runId + " running ... " + iterations + " times X elements " + elements.Length;
            Output(log);
            timer = Stopwatch.StartNew();
            for (int j = 0; j < iterations; j++)
            {
                int[] unsorted_original = testData.ToArray();
                method(unsorted_original, 0, unsorted_original.Length - 1);
            }
            timer.Stop();
            timespan = timer.Elapsed;

            time = String.Format("  {0}   , sec", timespan.TotalSeconds);
            log = id + " " + runId + " finished in   , " + time;
            Output(log);
            time_run.Add(log);
            Output("\n");
            return time;
        }

        private static void Output(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }


    }
}