using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal static class ExtensionsTests
    {
        ///
        /// http://www.dotnetperls.com/explode

        //////
        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        public static string[] Explode(this string value, int size)
        {
            // Number of segments exploded to except last.
            int count = value.Length/size;
            // Determine if we need to store a final segment.
            // ... Sometimes we have a partial segment.
            bool final = false;
            if ((size*count) < value.Length)
            {
                final = true;
            }

            // Allocate the array to return.
            // ... The size varies depending on if there is a final fragment.
            string[] result;
            if (final)
            {
                result = new string[count + 1];
            }
            else
            {
                result = new string[count];
            }

            // Loop through each index and take a substring.
            // ... The starting index is computed with multiplication.
            for (int i = 0; i < count; i++)
            {
                result[i] = value.Substring((i*size), size);
            }

            // Sometimes we need to set the final string fragment.
            if (final)
            {
                result[result.Length - 1] = value.Substring(count*size);
            }

            return result;
        }

        public static string[] Explode_0(this string value, int size)
        {
            // Number of segments exploded to except last.
            int count = value.Length/size;
            // Determine if we need to store a final segment.
            // ... Sometimes we have a partial segment.
            bool final = false;
            if ((size*count) < value.Length)
            {
                final = true;
            }

            // Allocate the array to return.
            // ... The size varies depending on if there is a final fragment.
            string[] result;
            if (final)
            {
                result = new string[count + 1];
            }
            else
            {
                result = new string[count];
            }

            // Loop through each index and take a substring.
            // ... The starting index is computed with multiplication.
            for (int i = 0; i < count; i++)
            {
                result[i] = value.Substring((i*size), size);
            }

            // Sometimes we need to set the final string fragment.
            if (final)
            {
                result[result.Length - 1] = value.Substring(count*size);
            }

            return result;
        }

        private static void Explode_Check()
        {
            Console.WriteLine("\nStart PrivateField_Check");
            const string input = "carrot chicken salad tomato";
            string[] explode1 = input.Explode(2);
            string[] explode2 = input.Explode_0(2);
            bool cond1 = explode1.Count() == explode2.Count();
            explode1 = input.Explode(3);
            explode2 = input.Explode_0(3);
            bool cond2 = explode1.Count() == explode2.Count();
            explode1 = input.Explode(4);
            explode2 = input.Explode_0(4);
            bool cond3 = explode1.Count() == explode2.Count();
            explode1 = input.Explode(103);
            explode2 = input.Explode_0(103);
            bool cond4 = explode1.Count() == explode2.Count();
            bool condition = cond1 && cond2 && cond3 && cond4;
            if (!condition)
            {
                throw new Exception("Explode_Check fail");
            }

            Console.WriteLine("Explode_Check - " + condition);
            Console.WriteLine("---------------");
        }

        public static void RunExtenstionTests()
        {
            //            ExtensionsTests.Explode_Check();
        }
    }
}