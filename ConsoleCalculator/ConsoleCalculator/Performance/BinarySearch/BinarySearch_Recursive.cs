using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleCalculator.Performance.BinarySearch
{
   
    class BinarySearch_Recursive
    {

        public static int WARMUP;
        public static int ITERATIONS;
        public static List<int> testData;
        public static List<int> keys;
        public static int NUMBER_OF_RUNS;

        public static List<string> time_warmup = new List<string>();
        public static List<string> time_run = new List<string>();



        public static void RunTests()
        {
            BinarySearch_Recursive bs = new BinarySearch_Recursive();
            time_warmup.Clear();
            time_run.Clear();

            bs.Profile();
            

//            bs.BinarySearch_Check();
            
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

            string result = "";

            result += "t_original";
//            result += "     t_method";
//            result += "     t_class";
//            result += " t_method_default";
//            result += " t_class_default";
//            result += "     t_method_junk";
//            result += "     t_class_junk";
            result += " " + "\n";


            int[] unsorted_original = testData.ToArray();
            for (int i = 0; i < NUMBER_OF_RUNS; i++)
            {                
                Console.WriteLine(i+ " ##############");
                Debug.WriteLine(i+ " ##############");
                string t_original = Time_Operation(i+ " BinarySearch_Recursive_original", BinarySearchRecursive_obfuscated);

                result += " " + t_original;
                result += " " + "\n";
            }

            Console.WriteLine("############");
            Console.WriteLine(result);

            Debug.WriteLine("############");
            Debug.WriteLine(result);

            PrintTimes();
        }



        private static int BinarySearchIterative_original(int[] inputArray, int key, int min, int max)
        {
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        private static int BinarySearchRecursive_obfuscated(int[] inputArray, int key, int min, int max)
        {
            if (min > max)
            {
                return -1;
            }
            else
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return mid;
                }
                else if (key < inputArray[mid])
                {
                    return BinarySearchRecursive_obfuscated(inputArray, key, min, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive_obfuscated(inputArray, key, mid + 1, max);
                }
            }
        }

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method")]


        //        [Obfuscation(Exclude = false, Feature = "virtualization; class; ")]

        public void BinarySearch_Check()
        {
            string testName = "Performance#BinarySearch_Recursive_original";
            Program.Start_Check(testName);
            bool condition = true;


            // Create an unsorted array of string elements
            //            int[] testData = GenerateDataStatic();
            int[] data = GenerateDataInt(360);
            var int_list = new List<int>(data);
            
            int[] unsorted_original = int_list.ToArray();

            // Sort the array
            Quicksort_original(unsorted_original, 0, unsorted_original.Length - 1);

            int key1 = unsorted_original[20];
            int key2 = unsorted_original[300];
            int key3 = unsorted_original[160];
            int key4 = -1;

            int res1 = BinarySearchIterative_original(unsorted_original, key1, 0, unsorted_original.Length - 1);
            int res2 = BinarySearchIterative_original(unsorted_original, key2, 0, unsorted_original.Length - 1);
            int res3 = BinarySearchIterative_original(unsorted_original, key3, 0, unsorted_original.Length - 1);
            int res4 = BinarySearchIterative_original(unsorted_original, key4, 0, unsorted_original.Length - 1);

            int res11 = BinarySearchRecursive_obfuscated(unsorted_original, key1, 0, unsorted_original.Length - 1);
            int res22 = BinarySearchRecursive_obfuscated(unsorted_original, key2, 0, unsorted_original.Length - 1);
            int res33 = BinarySearchRecursive_obfuscated(unsorted_original, key3, 0, unsorted_original.Length - 1);
            int res44 = BinarySearchRecursive_obfuscated(unsorted_original, key4, 0, unsorted_original.Length - 1);

            // Print the sorted array
            string sortedOriginalHash = res1 + "_" + res2 + "_" + res3 + "_" + res4;
            string sortedObfuscatedHash = res11 + "_" + res22 + "_" + res33 + "_" + res44;
           
            Console.WriteLine("ori: " + sortedOriginalHash);
            Console.WriteLine("obf: " + sortedObfuscatedHash);

            string virt = sortedObfuscatedHash;
            string oracle = sortedOriginalHash;
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }

       


        private int[] GenerateDataStatic()
        {
            int[] arr = {4, 3, 5, 2, 1, 3, 2, 3, 89201, 45932, 56552, 58302, 3768, 99875, 26543, 44898, 93328, 35746, 23265, 86042, 69630, 45843, 64590, 69515, 58230, 99227, 87729, 13089, 33472, 30304, 79972,23975, 45058, 35066, 81533, 81112, 79368, 17658, 79228, 30577, 67501, 45700, 94125, 30606, 21605, 54404, 96450, 29349, 94577, 81012, 87055, 50237, 86788, 6366,69903, 64801, 13172, 53670, 62243, 43631, 71885, 86104, 1582, 58896, 65960, 32577, 13243, 68702, 18341, 45430, 65530, 75669, 56518, 92687, 18541, 23930, 51718,33983, 47910, 3826, 2777, 58379, 18511, 52459, 43249, 29735, 37186, 38692, 65163, 16732, 67940, 25698, 55414, 35596, 58691, 
    75028, 47371, 69363, 36976, 31863, 36015,  23};

            return arr;
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

        


        public static string Time_Operation(string id,  Func<int[], int, int, int, int> method)
        {

            int op = 0;
            string log = id + " warming ... " + WARMUP + " times X elements " + testData.Count + " keys " + keys.Count;
            Output(log);
            int[] unsorted_original = testData.ToArray();
            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < WARMUP; i++)
            {
                foreach(var key in keys)
                    method(unsorted_original, key, 0, unsorted_original.Length-1);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            string time = String.Format("{0}    , sec", timespan.TotalSeconds);
            log = id + " " + " warmed up in,    " + time;
            Output(log);
            time_warmup.Add(log);

            log = id + " running ... " + ITERATIONS + " times X elements " + testData.Count + " keys " + keys.Count;
            Output(log);
            timer = Stopwatch.StartNew();
            for (int j = 0; j < ITERATIONS; j++)
            {
                foreach (var key in keys)
                    method(unsorted_original, key, 0, unsorted_original.Length - 1);
            }
            timer.Stop();
            timespan = timer.Elapsed;

            time = String.Format("{0}   , sec", timespan.TotalSeconds);
            log = id + " " + " finished in,     " + time;
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