using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace july_2021.Test
{
    class Testsource
    {
        [TestCaseSource(nameof(SumTestdata))]
        public void sum(int num1, int num2, int sum)
        {
            Assert.AreEqual(num1+ num2,sum);
        }

        static object[] SumTestdata =
        {
        new object[] { 12, 3, 15 },
        new object[] { 12, 2, 14 },
        new object[] { 12, 4, 16 }
    };
        
    }
}

