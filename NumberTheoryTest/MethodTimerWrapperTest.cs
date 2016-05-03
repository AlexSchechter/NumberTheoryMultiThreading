using NUnit.Framework;
using NumberTheory;
using System;
//using static Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo.Create;

namespace NumberTheoryTest
{
    [TestFixture]
    public class MethodTimerWrapperTest
    {
        private MethodTimerWrapper fMethodTimerWrapper;

        [Test]
        public void ExecuteMethodReturnsCorrectResultForGivenMethodAndInput()
        {
            GivenMethodTimerWrapper();
            ReturnsCorrectMethodResult();
        }

        private double TestMethod(ulong number)
        {
            return Math.Sqrt(number);
        }          
             
        private void GivenMethodTimerWrapper()
        {
            fMethodTimerWrapper = new MethodTimerWrapper();
        }

        private void WhenExecuteFunctionIsCalledWith<T>(Func<ulong, T> function, ulong number)
        {
            fMethodTimerWrapper.ExecuteMethod<T>(function, number);
        }

        private void ReturnsCorrectMethodResult()
        {
            Assert.AreEqual(Math.Sqrt(30), fMethodTimerWrapper.ExecuteMethod<double>(TestMethod, 30));
        }
    }
}
