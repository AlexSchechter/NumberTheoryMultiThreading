using System;
using System.Diagnostics;

namespace NumberTheory
{
    public class MethodTimerWrapper<T>
    {
        private readonly Stopwatch fStopWatch;
        private readonly Func<ulong, T> fMethod;
        private readonly ulong fNumber;

        private TimeSpan fTimeforCalculation;
        

        public MethodTimerWrapper(Func<ulong, T> method, ulong number)
        {
            fStopWatch = new Stopwatch();
            fMethod = method;
            fNumber = number;
        }

        public MethodTimerWrapper()
        {
            fStopWatch = new Stopwatch();
        }

        public TimeSpan MethodExecutionTime
        {
            get { return fTimeforCalculation; }
        }

        public T ExecuteMethod()
        {
            fStopWatch.Start();
            T result = fMethod(fNumber);
            fStopWatch.Stop();
            fTimeforCalculation = fStopWatch.Elapsed;
            return result;
        }

        public T ExecuteMethod(Func<ulong, T> method, ulong number)
        {           
            fStopWatch.Start();
            T result = method(number);
            fStopWatch.Stop();
            fTimeforCalculation = fStopWatch.Elapsed;
            return result;
        }

        public static implicit operator MethodTimerWrapper<T>(MethodTimerWrapper<bool> v)
        {
            throw new NotImplementedException();
        }
    }
}
