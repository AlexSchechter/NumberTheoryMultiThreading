using System;

namespace NumberTheory
{
    public class MethodTimerWrapper<T>
    {
        public MethodTimerWrapper(Func<ulong, T> method, ulong number)
        {
            MethodResult = method(number);
        }

        public T MethodResult { get; set; }
    }
}
