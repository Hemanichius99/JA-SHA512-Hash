using System;
using System.Collections.Generic;
using System.Text;

namespace SHA512HashWpf.Hash
{
    internal class HashContext
    {
        private HashStrategy _hashStrategy = new HashCsharp(); // defaultowo ustawiona strategia na HashCsharp

        public void setStrategy(HashStrategy hashStrategy)
        {
            _hashStrategy = hashStrategy;
        }

        public string Hash(string input, int numberOfThreads)
        {
            var inputAsBytes = Encoding.UTF8.GetBytes(input);

            var outputAsString = Convert.ToHexString(_hashStrategy.Hash(inputAsBytes, numberOfThreads));

            return outputAsString;
        }
    }
}
