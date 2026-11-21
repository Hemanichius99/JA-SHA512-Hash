using System;
using System.Collections.Generic;
using System.Text;

namespace SHA512HashWpf.Hash
{
    internal interface HashStrategy
    {
        public string Hash(string input, int numberOfThreads);
    }
}
