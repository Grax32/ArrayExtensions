using Grax.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ArrayExtensionsUnitTests
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        [TestMethod]
        public void ArrayFillTest()
        {
            var myArray = new int[12000];
            var filler = new int[] { 1, 2, 3, 4, 5 };

            myArray.Fill(filler);

            Assert.AreEqual(5, myArray.Last());
        }

        [TestMethod]
        public void ArrayFillExactDoubleTest()
        {
            var myArray = new int[16384];

            myArray.Fill(7);

            Assert.AreEqual(7, myArray.Last());
        }

        [TestMethod]
        public void ArrayFillTestUnevens()
        {
            for (var i = 0; i < 5; i++)
            {
                var myArray = new int[12001 + i];
                var filler = new int[] { 0, 1, 2, 3, 4, 5 };

                myArray.Fill(filler);

                Assert.AreEqual(i, myArray.Last());
            }
        }

        [TestMethod]
        public void ArrayFillTestGiant()
        {
            for (var loopCount = 0; loopCount < 5; loopCount++)
            {
                var arrayLength = 2000000000 - 4 + loopCount;
                var myArray = new byte[arrayLength];
                var filler = new byte[] { 0, 1, 2, 3, 4 };

                myArray.Fill(filler);

                var lastValue = myArray[arrayLength - 1];
                Assert.AreEqual(loopCount, lastValue);
            }
        }
    }
}
