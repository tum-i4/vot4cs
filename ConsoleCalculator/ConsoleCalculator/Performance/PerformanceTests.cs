using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.Performance.QuickSort;
using ConsoleCalculator.VirtCode;

namespace ConsoleCalculator.Performance
{
    enum VirtualizationType
    {
        ORIGINAL,
        METHOD,
        METHOD_DEFAULT,
        METHOD_JUNK,
        CLASS,
        CLASS_DEFAULT,
        CLASS_JUNK
    }

    class PerformanceTests
    {

        public static void RunLoopTests()
        {

            //            FactorialTests.RunTests();

            QuickSortTests.RunTests();

            //BinarySearch.BinarySearchTests.RunTests();

            //            ForLoop.ForLoop_Tests.RunTests();
        }

       

    }
}
