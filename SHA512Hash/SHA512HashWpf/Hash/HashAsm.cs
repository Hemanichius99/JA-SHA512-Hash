using System;
using System.Collections.Generic;
using System.Text;

namespace SHA512HashWpf.Hash
{
    internal class HashAsm : HashStrategy
    {
        public byte[] Hash(byte[] input, int numberOfThreads)
        {
            throw new NotImplementedException("Brak zaimplementowanego algorytmu asemblera.");
        }
    }
}
