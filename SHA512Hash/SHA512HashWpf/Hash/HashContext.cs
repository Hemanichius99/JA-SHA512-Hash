using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace SHA512HashWpf.Hash
{
    internal class HashContext
    {
        private HashStrategy _hashStrategy = new HashCsharp(); // defaultowo ustawiona strategia na HashCsharp

        public void setStrategy(HashStrategy hashStrategy)
        {
            _hashStrategy = hashStrategy;
        }

        public HashResult Hash(string input, int numberOfThreads)
        {
            byte[] inputAsBytes = Encoding.UTF8.GetBytes(input); // string -> byte[]

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            byte[] hashResult = _hashStrategy.Hash(inputAsBytes, numberOfThreads); // Haszowanie, tego mierzymy czas

            stopwatch.Stop();

            float elapsedTime = (float)stopwatch.Elapsed.TotalMilliseconds; // czas w milisekundach

            string outputAsString = Convert.ToHexString(hashResult); // byte[] -> string

            return new HashResult(outputAsString, elapsedTime);
        }

        public string getMethod() { 
            if (_hashStrategy is HashCsharp)
            {
                return "C#";
            }
            else if (_hashStrategy is HashAsm)
            {
                return "ASM DLL";
            }
            else
            {
                return "Unknown";
            }
        }
    }
}
