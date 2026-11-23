using System;
using System.Collections.Generic;
using System.Text;

namespace SHA512HashWpf.Generate
{
    public class TextGenerator
    {
        private FileReader _fileReader;

        public TextGenerator(string filePath)
        {
            _fileReader = new FileReader(filePath);
        }

        // Metoda czyta losową linie z pliku tekstowego i zwraca ją jako string.
        public string getSentence()
        {
            Random random = new Random();
            int x = random.Next(0, _fileReader.getNumberOfLines());
            return _fileReader.ReadLine(x) ?? string.Empty;
        }
    }
}