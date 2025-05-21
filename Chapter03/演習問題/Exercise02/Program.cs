
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Console.WriteLine("小文字の'o'が含まれている都市名");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();
        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了。");

            /*while (true){
                Console.Write("都市名:");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) {
                    Console.WriteLine("終了");
                    break;
                } else {
                    int index = names.FindIndex(s => s == name);
                    Console.WriteLine(index);
                }
            }*/

            do {
                Console.Write("都市名:");
                var name = Console.ReadLine(); //入力処理
                if (string.IsNullOrEmpty(name))
                    break;
                int index = names.FindIndex(s => s == name);
                Console.WriteLine(index);
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            //names.Count(ここにラムダ式を記述する
            var count = names.Count(s => s.Contains('o'));
            Console.WriteLine("小文字の'o'が含まれている都市名:" + count);
        }

        private static void Exercise2_3(List<string> names) {
            var selected = names.Where(s => s.Contains('o')).ToArray();
            foreach (var name in selected) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise2_4(List<string> names) {
            var selected = names.Where(s => s.StartsWith('B'))
                .Select(s => s.Length);
            var obj = names.Where(s => s.StartsWith('B'))
                .Select(s => new { s, s.Length });

            foreach (var len in selected) {
                Console.WriteLine("'B'で始まる都市名の文字数:" + len);
            }

            foreach (var date in obj) {
                Console.WriteLine(date.s + ":" + date.Length + "文字");
            }
        }
    }
}
