using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SHA512HashWpf.History
{
    public record AlgoRecord(
        int Lp,
        string Method,
        float TimeInMiliseconds,
        int NumberOfThreads
        )
    {
        private static readonly AtomicInteger algoCounter = new AtomicInteger(0);
        public AlgoRecord(string Method, float TimeInMiliseconds, int NumberOfThreads) : this(algoCounter.IncrementAndGet(), Method, TimeInMiliseconds, NumberOfThreads) { }

    }
}