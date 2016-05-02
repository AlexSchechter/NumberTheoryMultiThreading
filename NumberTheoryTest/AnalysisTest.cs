using NumberTheory;
using NUnit.Framework;
using System.Collections.Generic;

namespace NumberTheoryTest
{
    [TestFixture]
    public class AnalysisTest
    {
        private Analysis fAnalysis;

        [Test]
        public void GivenUnsignedLongReturnsFrimeFactors()
        {
            GivenAnalysisClass();
            GivenIntegerCalculatePrimeFactorsReturnsCorrectList();
        }

        private void GivenAnalysisClass()
        {
            fAnalysis = new Analysis();
        }

        private void GivenIntegerCalculatePrimeFactorsReturnsCorrectList()
        {
            List<ulong> correctPrimeFactors = new List<ulong> { 2, 2, 3, 7 };
            var t = fAnalysis.CalculatePrimeFactors(84);
            CollectionAssert.AreEqual(fAnalysis.CalculatePrimeFactors(84), correctPrimeFactors);
        }
    }
}
