using Grax32.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace ArrayExtensionsUnitTests
{
    public static class Extensions
    {
        public static void LogTime(this Stopwatch timer)
        {
            Console.WriteLine(timer.ElapsedMilliseconds.ToString("#,#"));
        }
    }

#if PERFTEST
    // only include these tests in the perf test build
    [TestClass]
#endif
    public class ArrayExtensionsPerformanceComparisonTests
    {
        [TestMethod]
        public void ArrayFillTestGiantPerfTest()
        {
            var arrayLength = Convert.ToInt64(int.MaxValue - 64);

            var myArray = new byte[arrayLength];
            var fill = (byte)4;

            var timer = Stopwatch.StartNew();

            for (var loopCount = 0; loopCount < 5; loopCount++)
            {
                ArrayExtensions.Fill(myArray, fill);
            }

            Console.WriteLine("Extension:");
            timer.LogTime();
            timer.Restart();

            for (var loopCount = 0; loopCount < 5; loopCount++)
            {
                Array.Fill(myArray, fill);
            }

            Console.WriteLine("Native:");
            timer.LogTime();
            timer.Restart();
        }
    }
}
