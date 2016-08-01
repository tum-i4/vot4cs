using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.VirtData
{
    internal class ConditionalExpressionTests
    {

        public enum CreditCardCompany
        {
            MasterCard,
            Visa,
            Amex,
            DinersClub,
            Unknown
        }

        public static void RunBasicTests()
        {
//            new ConditionalExpressionTests().checkConditional();

//            new ConditionalExpressionTests().checkEnum();
        }

        
        private string Conditional_original()
        {
            string value = CreditCardCompany.Amex + "";

            if (value.Length > 0)
            {
                value += " ";
                value += CreditCardCompany.MasterCard;
                value += " ";
            }

            return value;
        }

        [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
        private string Conditional_obfuscated()
        {
            string value = CreditCardCompany.Amex + "";

            if (value.Length > 0)
            {
                value += " ";
                value += CreditCardCompany.MasterCard;
                value += " ";
            }

            return value;
        }

        public void checkConditional()
        {
            string testName = "Code#Conditional_Check";
            bool condition = true;
            Program.Start_Check(testName);

            string virt = Conditional_obfuscated();
            string oracle = Conditional_original();
            Console.WriteLine(testName + " => " + virt + " vs " + oracle);
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }




        private string Enum_original()
        {
            int value = 3 + 2;

            string data = "a" + (value > 2 ? "t" : "f");

            return data;
        }

        //        [Obfuscation(Exclude = false, Feature = "virtualization; method; readable")]
        private string Enum_obfuscated()
        {
            int value = 3 + 2;

            string data = "a" + (value > 2 ? "t" : "f");

            return data;
        }

        public void checkEnum()
        {
            string testName = "Code#Enum_Check";
            bool condition = true;
            Program.Start_Check(testName);

            string virt = Conditional_obfuscated();
            string oracle = Conditional_original();
            Console.WriteLine(testName + " => " + virt + " vs " + oracle);
            condition = virt.Equals(oracle);
            Program.End_Check(testName, condition);
        }
    }
}
