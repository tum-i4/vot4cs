using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class LoopTests
    {
        public static void RunLoopTests()
        {
            LoopTests lt = new LoopTests();

           
            //
//                        LoopTests.RunMatrixMultiplication_0();
            //            LoopTests.RunMatrixMultiplication_1();

            //TODO: not tested yet
            //            lt.SimpleLoop_check();


            //            lt.ListLoopSimpleCheck();
            //            lt.ListLoopSimpleLINQCheck();
            //            lt.IndexedNames_Check();

        }


        #region MATRIX_MULTIPLICATION

//        public class MatrixMultiplication
//        {
//            [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
		public static void RunMatrixMultiplication_0()
            {
                int rowsInA = 2;
                int columnsInA = 3; //rows in B
                int columnsInB = 3;
                int[][] a = new int[rowsInA][];
                for (int i = 0; i < rowsInA; i++)
                    a[i] = new int[columnsInA];
                int[][] b = new int[columnsInA][];
                for (int i = 0; i < columnsInA; i++)
                    b[i] = new int[columnsInB];

                Console.WriteLine("Enter matrix A");

                Random rand = new Random();
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < a[0].Length; j++)
                    {
                        a[i][j] = rand.Next(1, 20);
                        Console.Write(a[i][j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Enter matrix B");
                for (int i = 0; i < b.Length; i++)
                {
                    for (int j = 0; j < b[0].Length; j++)
                    {
                        b[i][j] = rand.Next(1, 20);
                        Console.Write(b[i][j] + " ");
                    }
                    Console.WriteLine();
                }

                int[][] c = multiply_0(a, b);
                Console.WriteLine("Product of A and B is");
                for (int i = 0; i < c.Length; i++)
                {
                    for (int j = 0; j < c[0].Length; j++)
                    {
                        Console.Write(c[i][j] + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("--------------");
            }

            public static void RunMatrixMultiplication_1()
            {
                int rowsInA = 2;
                int columnsInA = 3; //rows in B
                int columnsInB = 3;
                int[][] a = new int[rowsInA][];
                for (int i = 0; i < rowsInA; i++)
                    a[i] = new int[columnsInA];
                int[][] b = new int[columnsInA][];
                for (int i = 0; i < columnsInA; i++)
                    b[i] = new int[columnsInB];

                Console.WriteLine("Enter matrix A");

                Random rand = new Random();
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < a[0].Length; j++)
                    {
                        a[i][j] = rand.Next(1, 20);
                        Console.Write(a[i][j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Enter matrix B");
                for (int i = 0; i < b.Length; i++)
                {
                    for (int j = 0; j < b[0].Length; j++)
                    {
                        b[i][j] = rand.Next(1, 20);
                        Console.Write(b[i][j] + " ");
                    }
                    Console.WriteLine();
                }

                int[][] c = multiply_0(a, b);
                Console.WriteLine("Product of A and B is");
                for (int i = 0; i < c.Length; i++)
                {
                    for (int j = 0; j < c[0].Length; j++)
                    {
                        Console.Write(c[i][j] + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("--------------");
            }

//            [Obfuscation(Exclude = false, Feature = "virtualization; class")]
    public static int[][] multiply_0(int[][] a, int[][] b)
    {
            int rowsInA = a.Length;
            int columnsInA = a[0].Length; // same as rows in B
            int columnsInB = b[0].Length;
            int[][] c = new int[rowsInA][];

            for (int i = 0; i < rowsInA; i++)
            {
                c[i] = new int[columnsInB];
            }


            for (int i = 0; i < rowsInA; i++)
            {
                for (int j = 0; j < columnsInB; j++)
                {
                    for (int k = 0; k < columnsInA; k++)
                    {
                        c[i][j] = c[i][j] + a[i][k] * b[k][j];
                    }
                }
            }
            return c;
        }

            public static int[][] multiply_1(int[][] a, int[][] b)
            {
                int rowsInA = a.Length;
                int columnsInA = a[0].Length; // same as rows in B
                int columnsInB = b[0].Length;
                int[][] c = new int[rowsInA][];

                for (int i = 0; i < rowsInA; i++)
                {
                    c[i] = new int[columnsInB];
                }


                for (int i = 0; i < rowsInA; i++)
                {
                    for (int j = 0; j < columnsInB; j++)
                    {
                        for (int k = 0; k < columnsInA; k++)
                        {
                            c[i][j] = c[i][j] + a[i][k]*b[k][j];
                        }
                    }
                }
                return c;
            }

            
//        }


        #endregion

      

        #region LIST_LOOP

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        private string ListLoopSimple()
        {
            List<String> myList = new List<string>();
            myList.Add("a");
            myList.Add("b");
            myList.Add("c");
            myList.Add("d");
            string result = "";
            foreach (var element in myList)
            {
                result += element;
            }

            return result;
            //return myList.Aggregate("", (current, element) => current + element);
        }

        private string ListLoopSimple_0()
        {
            int[] data = new[]
            {
                1, 2
            }

                ;
            List<String> myList = new List<string>();
            myList.Add("a");
            myList.Add("b");
            myList.Add("c");
            myList.Add("d");
            string result = "";
            foreach (var element in myList)
            {
                result += element;
            }

            //            result = "";
            return result;
        }

        private void ListLoopSimpleCheck()
        {
            Console.WriteLine("\nStart ListLoopSimpleCheck");
            string virt = ListLoopSimple();
            string oracle = ListLoopSimple_0();
            bool condition = virt.Equals(oracle);
            if (!condition)
            {
                throw new Exception("ListLoopSimple fail");
            }

            Console.WriteLine("ListLoopSimpleCheck - " + condition);
            Console.WriteLine("---------------");
        }

        #endregion

        #region LIST_LOOP_LINQ

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        private string ListLoopSimpleLINQ()
        {
            List<String> myList = new List<string>();
            myList.Add("a");
            myList.Add("b");
            myList.Add("c");
            myList.Add("d");
            string result = "";
            foreach (var element in myList)
            {
                result += element;
            }

            return myList.Aggregate("", (current, element) => current + element);
        }

        private string ListLoopSimpleLINQ_0()
        {
            int[] data = new[]
            {
                1, 2
            }

                ;
            List<String> myList = new List<string>();
            myList.Add("a");
            myList.Add("b");
            myList.Add("c");
            myList.Add("d");
            string result = "";
            foreach (var element in myList)
            {
                result += element;
            }

            return myList.Aggregate("", (current, element) => current + element);
        }

        private void ListLoopSimpleLINQCheck()
        {
            Console.WriteLine("\nStart ListLoopSimpleLINQCheck");
            string virt = ListLoopSimpleLINQ();
            string oracle = ListLoopSimpleLINQ_0();
            bool condition = virt.Equals(oracle);
            if (!condition)
            {
                throw new Exception("ListLoopSimpleLINQ fail");
            }

            Console.WriteLine("ListLoopSimpleLINQCheck - " + condition);
            Console.WriteLine("---------------");
        }

        #endregion


        #region INDEXER

        private class IndexedNames
        {
            private string[] namelist = new string[size];
            public static int size = 10;

            public IndexedNames()
            {
                for (int i = 0; i < size; i++)
                {
                    namelist[i] = "N. A.";
                }
            }

            //            [Obfuscation(Exclude = false, Feature = "local virt")]
            public string this[int index]
            {
                get
                {
                    string tmp;
                    if (index >= 0 && index <= size - 1)
                    {
                        tmp = namelist[index];
                    }
                    else
                    {
                        tmp = "";
                    }

                    return (tmp);
                }

                set
                {
                    if (index >= 0 && index <= size - 1)
                    {
                        namelist[index] = value;
                    }
                }
            }

            //            [Obfuscation(Exclude = false, Feature = "local virt")]
            public int this[string name]
            {
                get
                {
                    int index = 0;
                    while (index < size)
                    {
                        if (namelist[index] == name)
                        {
                            return index;
                        }

                        index++;
                    }

                    return index;
                }
            }

        }

        private class IndexedNames_0
        {
            private string[] namelist = new string[size];
            public static int size = 10;

            public IndexedNames_0()
            {
                for (int i = 0; i < size; i++)
                {
                    namelist[i] = "N. A.";
                }
            }

            public string this[int index]
            {
                get
                {
                    string tmp;
                    if (index >= 0 && index <= size - 1)
                    {
                        tmp = namelist[index];
                    }
                    else
                    {
                        tmp = "";
                    }

                    return (tmp);
                }

                set
                {
                    if (index >= 0 && index <= size - 1)
                    {
                        namelist[index] = value;
                    }
                }
            }

            public int this[string name]
            {
                get
                {
                    int index = 0;
                    while (index < size)
                    {
                        if (namelist[index] == name)
                        {
                            return index;
                        }

                        index++;
                    }

                    return index;
                }
            }

        }

        private void IndexedNames_Check()
        {
            string testName = "IndexedNames_Check";
            Program.Start_Check(testName);
            IndexedNames names = new IndexedNames();
            names[0] = "Zara";
            names[1] = "Riz";
            names[2] = "Nuha";
            names[3] = "Asif";
            names[4] = "Davinder";
            names[5] = "Sunil";
            names[6] = "Rubic";
            IndexedNames_0 names_0 = new IndexedNames_0();
            names_0[0] = "Zara";
            names_0[1] = "Riz";
            names_0[2] = "Nuha";
            names_0[3] = "Asif";
            names_0[4] = "Davinder";
            names_0[5] = "Sunil";
            names_0[6] = "Rubic";
            bool condition = true;
            //using the first indexer with int parameter
            for (int i = 0; i < IndexedNames.size; i++)
            {
                if (!names[0].Equals(names_0[0]))
                {
                    condition = false;
                }
            }

            Program.End_Check(testName, condition);
        }



        #endregion


    }
}