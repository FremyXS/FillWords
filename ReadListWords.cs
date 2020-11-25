using System;
using System.Collections.Generic;
using System.IO;

namespace ReadFile
{
    public class ReadListWords
    {
        private string text = File.ReadAllText(@"filesystem\word_rus.txt");
        public List<string> Words = new List<string>();

        public object Dictionary()
        {
            Words.AddRange(text.Split('\n'));

            return Words;
        }
    }
}
