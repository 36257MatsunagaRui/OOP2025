
using System.Runtime.CompilerServices;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            //ディクショナリインスタンスの生成
            var dict = new Dictionary<char, int>();

            //1文字取り出す→大文字に変換
            foreach (var ch in text.ToUpper().OrderBy(c => c)) {
                if ('A' <= ch && ch <= 'Z') {
                    if (dict.ContainsKey(ch)) {
                        dict[ch]++;
                    }else {
                        dict[ch] = 1;
                    }
                }     
            }

            foreach (var (key, value) in dict) {
                Console.WriteLine($"'{key}':{value}");
            }
        }

        private static void Exercise2(string text) {
            //ディクショナリインスタンスの生成
            var dict = new SortedDictionary<char, int>();

            //1文字取り出す→大文字に変換
            foreach (var ch in text.ToUpper()) {
                if ('A' <= ch && ch <= 'Z') {
                    if (dict.ContainsKey(ch)) {
                        dict[ch]++;
                    } else {
                        dict[ch] = 1;
                    }
                }
            }

            foreach (var (TKey, TValue) in dict) {
                Console.WriteLine($"'{TKey}':{TValue}");
            }
        }
    }
}
