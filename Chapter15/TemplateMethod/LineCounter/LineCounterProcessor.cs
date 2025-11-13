using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {

        private string _targetWord;

        private int _count = 0;

        protected override void Initialize(string fname) {
            _count = 0;

            Console.Write("単語の入力:");
            _targetWord = Console.ReadLine();
        }

        protected override void Execute(string line) {
            if (string.IsNullOrEmpty(_targetWord)) return;
            _count += line.Split(
                new[] { _targetWord },
                StringSplitOptions.None
            ).Length - 1;
        }

        protected override void Terminate() {
            Console.WriteLine($"検索単語:{_targetWord}");
            Console.WriteLine($"カウント:{_count}");
        }
    }
}