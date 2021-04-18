using System;
using System.Collections.Generic;
using System.Linq;

namespace BankOcr
{
    public class DocumentParser
    {
        public readonly INumberRecognizer NumberRecognizer;

        public DocumentParser(INumberRecognizer numberRecognizer)
        {
            NumberRecognizer = numberRecognizer;
        }


        public List<string> GetEntryByPosition(IEnumerable<string> lines, int entryNumber)
        {
            return lines.Skip(entryNumber * 4).Take(4).ToList();
        }

        public int GetDigitByPosition(string[] entryLines, int positionNumber)
        {
            var offset = positionNumber * 3;
            var parsedNumber = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                parsedNumber += entryLines[i].Substring(offset, 3);
            }

            var digit = NumberRecognizer.RecognizeNumber(parsedNumber);

            return digit;
        }

        public string ParseEntry(string[] entryLines)
        {
            var parsedEntry = string.Empty;

            for(int i = 0; i < 9; i++)
            {
                parsedEntry += GetDigitByPosition(entryLines, i);
            }

            return parsedEntry;
        }

        public List<string> ReadFileContent(string fullPath)
        {
            var results = new List<string>();
            var lines = System.IO.File.ReadAllLines(fullPath);

            var numberEntries = lines.Length / 4;


            for(int i = 0; i < numberEntries; i++)
            {
                var entryLines = GetEntryByPosition(lines, i);
                var result = ParseEntry(entryLines.ToArray());
                results.Add(result);
            }
            return results;
        }

    }
}
