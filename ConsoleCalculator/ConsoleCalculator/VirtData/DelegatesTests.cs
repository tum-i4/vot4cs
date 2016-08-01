using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

delegate int NumberChanger(int n);
namespace ConsoleCalculator
{
    internal class DelegatesTests
    {
        #region DELEGATE_SIMPLE

        private static int num = 10;

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int getNum()
        {
            return num;
        }

        private NumberChanger ncField = delegate(int x)
        {
            int lnc = 155;
            lnc += x;
            return lnc;
        }

            ;

        //        [Obfuscation(Exclude = false, Feature = "local virt")]
        private int DelegateSimple()
        {
            int localVar = 33;
            //create delegate instances
            NumberChanger nc = delegate(int x)
            {
                int lnc = 12;
                lnc += x;
                lnc += num;
                lnc += localVar;
                localVar = 22;
                return lnc;
            }

                ;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            nc += nc1;
            nc += nc2;
            nc += ncField;
            //calling the methods using the delegate objects
            nc1(25);
            int r1 = getNum();
            nc2(5);
            int r2 = getNum();
            nc(5);
            int r3 = getNum();
            return r1 + r2 + r3 + localVar;
        }

        private int DelegateSimple_0()
        {
            //create delegate instances
            int localVar = 33;
            //create delegate instances
            NumberChanger nc = delegate(int x)
            {
                int lnc = 12;
                lnc += x;
                lnc += num;
                lnc += localVar;
                localVar = 22;
                return lnc;
            }

                ;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            nc += nc1;
            nc += nc2;
            nc += ncField;
            //calling the methods using the delegate objects
            nc1(25);
            int r1 = getNum();
            nc2(5);
            int r2 = getNum();
            nc(5);
            int r3 = getNum();
            return r1 + r2 + r3 + localVar;
        }

        private void DelegateSimple_Check()
        {
            string testName = "DelegateSimple_Check";
            Program.Start_Check(testName);
            DelegatesTests.num = 10;
            int r1 = DelegateSimple();
            DelegatesTests.num = 10;
            int r2 = DelegateSimple_0();
            bool condition = r1 == r2;
            Program.End_Check(testName, condition);
        }

        #endregion

        public static void RunDelegatesTests()
        {
            DelegatesTests dt = new DelegatesTests();
            //            dt.DelegateSimple_Check();
        }
    }
}