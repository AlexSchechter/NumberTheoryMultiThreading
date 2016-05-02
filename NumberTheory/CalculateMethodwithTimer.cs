using System;
using System.Diagnostics;

namespace NumberTheory
{
    public class MethodTimerWrapper
    {
        private readonly Stopwatch fStopWatch;
        private TimeSpan fTimeforCalculation;

        public MethodTimerWrapper()
        {
            fStopWatch = new Stopwatch();
        }
      
        public TimeSpan MethodExecutionTime
        {
            get { return fTimeforCalculation; }
        }

        public T ExecuteMethod<T>(Func<ulong, T> method, ulong number)
        {           
            fStopWatch.Start();
            T result = method(number);
            fStopWatch.Stop();
            fTimeforCalculation = fStopWatch.Elapsed;
            return result;
        }
    }
}
