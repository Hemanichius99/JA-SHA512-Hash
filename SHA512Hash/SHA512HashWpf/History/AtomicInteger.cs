using System;
using System.Collections.Generic;
using System.Text;

namespace SHA512HashWpf.History
{
    internal class AtomicInteger
    {
        private int _value;

        public AtomicInteger(int initialValue = 0)
        {
            _value = initialValue;
        }

        public int IncrementAndGet()
        {
            return System.Threading.Interlocked.Increment(ref _value);
        }
    }
}
