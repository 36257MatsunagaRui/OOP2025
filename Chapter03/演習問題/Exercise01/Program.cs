
using Microsoft.Win32.SafeHandles;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 3.1.1
            Exercise1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise4(numbers);
        }

        private static void Exercise1(List<int> numbers) {
            var exist = numbers.Exists(n => n % 8 == 0 || n % 9 == 0);
            if (exist) {
                Console.WriteLine("存在しています");
            } else {
                Console.WriteLine("存在していません");
            }
        }

        //数値を2.0で割って出力する
        private static void Exercise2(List<int> numbers) {
            numbers.ForEach(n => Console.WriteLine(n / 2.0));
        }

        //値が50以上の要素を列挙し出力する
        private static void Exercise3(List<int> numbers) {
            numbers.Where(n => n >= 50).ToList().ForEach(Console.WriteLine);
            /*var selected = numbers.Where(n => n >= 50);
            foreach (var number in selected) {
                Console.WriteLine(number);
            }*/
        }

        //数値を2倍にして出力する
        private static void Exercise4(List<int> numbers) {
            numbers.Select(n => n * 2).ToList().ForEach(Console.WriteLine);
            /*numbers.Select(n => n * 2).ToList().ForEach(Console.WriteLine);
            var doubleNum = numbers.Select(n => n * 2).ToList();
            foreach (var number in doubleNum) {
                Console.WriteLine(number);
            }*/
        }
    }
}
