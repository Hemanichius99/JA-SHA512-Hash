using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SHA512HashWpf.History
{
    public record AlgoRecord(
        int lp,
        string method,
        float timeInMiliseconds
        )
    {
        private static readonly AtomicInteger algoCounter = new AtomicInteger(0);
        public AlgoRecord(string method, float timeInMiliseconds) : this(algoCounter.IncrementAndGet(), method, timeInMiliseconds) { }
        
    }
}