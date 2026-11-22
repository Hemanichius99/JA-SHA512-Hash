using System;
using System.Collections.Generic;
using System.Text;

namespace SHA512HashWpf.Hash
{
    internal interface HashStrategy
    {
        public byte[] Hash(byte[] input, int numberOfThreads);
    }
}
