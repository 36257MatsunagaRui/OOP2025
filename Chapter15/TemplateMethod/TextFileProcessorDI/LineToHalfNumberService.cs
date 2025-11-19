using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    //問題15.1
    internal class LineToHalfNumberService : ITextFileService {
        public void Initialize(string fname) {

        }

        public void Execute(string line) {
            var convertedNumbers = line.Select(c => {
                if (c >= '０' && c <= '９') {
                    return (char)(c - '０' + '0');
                }
                return c;
            });

            string replacedLine = string.Concat(convertedNumbers);

            Console.WriteLine(replacedLine);

            string result = new string(
                line.Select(c => ('０' <= c && c <= '９') ? (char)(c - '０' + '0') : c).ToArray()
            );
            Console.WriteLine(result);
        }


        public void Terminate() {

        }
    }
}
