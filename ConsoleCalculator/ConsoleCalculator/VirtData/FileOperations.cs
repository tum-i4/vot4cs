using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class FileOperations
    {
        #region READ_FILE

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        private static string ReadFile()
        {
            string fileLines = "";
            string fileName = "Values1.txt";
            try
            {
                StreamReader myReader = new StreamReader(fileName);
                string line = "";
                while (line != null)
                {
                    line = myReader.ReadLine();
                    if (line != null)
                    {
                        //Console.WriteLine(line);
                        fileLines += line;
                    }
                }

                myReader.Close();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Couldn't fine the file.  Are you sure the DIRECTORY exists?");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Couldn't find the file.  Are you sure you're looking for the correct file? " + e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something didn't quite work correctly: {0}", e.Message);
            }
            finally
            {
                // Perform any cleanup to roll back the testData or close connections
                // to files, database, network, etc.
            }

            return fileLines;
        }

        private static string ReadFile_0()
        {
            string fileLines = "";
            string fileName = "Values1.txt";
            try
            {
                StreamReader myReader = new StreamReader(fileName);
                string line = "";
                while (line != null)
                {
                    line = myReader.ReadLine();
                    if (line != null)
                    {
                        //Console.WriteLine(line);
                        fileLines += line;
                    }
                }

                myReader.Close();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Couldn't fine the file.  Are you sure the DIRECTORY exists?");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Couldn't find the file.  Are you sure you're looking for the correct file?");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something didn't quite work correctly: {0}", e.Message);
            }
            finally
            {
                // Perform any cleanup to roll back the testData or close connections
                // to files, database, network, etc.
            }

            return fileLines;
        }

        private static void ReadFile_Check()
        {
            string testName = "ReadFile_Check";
            bool condition = false;
            Program.Start_Check(testName);
            string file1 = ReadFile();
            string file2 = ReadFile_0();
            condition = file1.Equals(file2);
            Program.End_Check(testName, condition);
        }

        #endregion

        public static void RunReadFileTests()
        {
            //            ReadFile_Check();
        }
   }
}