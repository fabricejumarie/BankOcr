using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOcr.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var documentParser = new DocumentParser(new NumberRecognizer());
            var parsedEntries = documentParser.ReadFileContent(@".\FilesTest\FaxTest.txt");

            foreach (var parsedEntry in parsedEntries)
            {
                Console.WriteLine(parsedEntry);
            }

            Console.ReadKey();
        }
    }
}
