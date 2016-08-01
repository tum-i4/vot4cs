using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class FieldTests
    {
        #region PRIVATE_FIELD

        private static int intS = 0;
        private int intI = 1;
        private static string stringS = "text";
        private string stringI = "instance";
        private static Car carS = new Car("static-car", 10);
        private Car carI = new Car("instance-car", 20);
        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        private void PrivateField(int doors, string id)
        {
            intS = doors*2;
            intI = 15;
            stringS = "static-" + id;
            stringI = stringS + id;
        }

        private void PrivateField_0(int doors, string id)
        {
            intS = doors*2;
            intI = 15;
            stringS = "static-" + id;
            stringI = stringS + id;
        }

        private void PrivateField_Check()
        {
            string testName = "PrivateField_Check";
            bool condition = false;
            int doors = 3;
            string id = "private-field";
            PrivateField(doors, id);
            int aux1 = intS;
            int aux2 = intI;
            string sAux1 = stringS;
            string sAux2 = stringI;
            PrivateField_0(doors, id);
            condition = (aux1 == intS) && (aux2 == intI) && (sAux1.Equals(stringS) && (sAux2.Equals(stringI)));
            Program.End_Check(testName, condition);
        }

        #endregion

        #region PROPERTY_INT

        private int _number;

        public int Number
        {
            get { return this._number; }

            set { this._number = value; }
        }

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        private int IntProperty(int value)
        {
            FieldTests example = new FieldTests();
            example.Number = value;
            return example.Number;
        }

        private int IntProperty_0(int value)
        {
            FieldTests example = new FieldTests();
            example.Number = value;
            return example.Number;
        }

        private void IntProperty_Check()
        {
            string testName = "IntProperty_Check";
            bool condition = false;
            Program.Start_Check(testName);
            int value = 12;
            int r1 = IntProperty(value);
            int r2 = IntProperty_0(value);
            condition = r1 == r2;
            Program.End_Check(testName, condition);
        }

        #endregion

        #region PROPERTY_ENUM

        private DayOfWeek _day;

        public DayOfWeek Day
        {
            get
            {
                // We don't allow this to be used on Friday.
                if (this._day == DayOfWeek.Friday)
                {
                    throw new Exception("Invalid access");
                }

                return this._day;
            }

            set { this._day = value; }
        }

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        private static DayOfWeek EnumProperty(DayOfWeek d)
        {
            FieldTests example = new FieldTests();
            example.Day = DayOfWeek.Monday;
            try
            {
                example.Day = d;
                Console.WriteLine(example.Day);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                example.Day = DayOfWeek.Wednesday;
            }

            return example.Day;
        }

        private static DayOfWeek EnumProperty_0(DayOfWeek d)
        {
            FieldTests example = new FieldTests();
            example.Day = DayOfWeek.Monday;
            try
            {
                example.Day = d;
                Console.WriteLine(example.Day);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                example.Day = DayOfWeek.Wednesday;
            }

            return example.Day;
        }

        private void EnumProperty_Check()
        {
            string testName = "EnumProperty_Check";
            bool condition = false;
            Program.Start_Check(testName);
            DayOfWeek value = DayOfWeek.Friday;
            DayOfWeek r1 = EnumProperty(value);
            DayOfWeek r2 = EnumProperty_0(value);
            condition = r1.Equals(r2);
            Program.End_Check(testName, condition);
        }

        private static DayOfWeek EnumProperty_1(DayOfWeek d)
        {
            uint[] array = new uint[230];
            array[0] = 231u;
            object[] array2 = new object[55];
            int num = -1;
            num++;
            array2[1] = 1;
            array2[4] = 3;
            array2[2] = d;
            FieldTests fieldTests = null;
            array2[0] = fieldTests;
            Exception ex = null;
            array2[3] = ex;
            object obj = new FieldTests();
            array2[0] = obj;
            ((FieldTests) array2[0]).Day = (DayOfWeek) ((int) array2[1]);
            try
            {
                ((FieldTests) array2[0]).Day = (DayOfWeek) array2[2];
                Console.WriteLine(((FieldTests) array2[0]).Day);
            }
            catch (Exception e)
            {
                array2[3] = e;
                Console.WriteLine((Exception) array2[3]);
            }
            finally
            {
                ((FieldTests) array2[0]).Day = (DayOfWeek) ((int) array2[4]);
            }

            return ((FieldTests) array2[0]).Day;
        }

        #endregion

        public static void RunFieldTests()
        {
            FieldTests ft = new FieldTests();
            //            ft.PrivateField_Check();
            //            ft.IntProperty_Check();
            //            ft.EnumProperty_Check();
        }
    }
}