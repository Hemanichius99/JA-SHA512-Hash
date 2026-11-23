using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SHA512HashWpf.Generate
{
    internal class FileReader
    {
        private readonly string[] _lines;

        public FileReader(string filePath)
        {
            _lines = File.ReadAllLines(filePath);
        }

        public string? ReadLine(int lineNumber)
        {
            if (lineNumber < 0 || lineNumber >= _lines.Length)
                return null;

            return _lines[lineNumber];
        }

        public int getNumberOfLines() => _lines.Length;
    }
}
