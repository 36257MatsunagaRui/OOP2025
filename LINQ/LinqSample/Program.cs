using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace LinqSample {
    internal class Program {
        static void Main(string[] args) {
            var numbers = Enumerable.Range(1, 100);

            //合計値を出力
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("");

            //平均値を出力
            Console.WriteLine(numbers.Average());
            Console.WriteLine("");

            //偶数値の合計を出力
            Console.WriteLine(numbers.Where(n => n % 2 == 0).Sum());
            Console.WriteLine("");

            //偶数の最大値
            Console.WriteLine(numbers.Where(n => n % 2 == 0).Max());
            Console.WriteLine("");

            //8の倍数の合計
            Console.WriteLine(numbers.Where(n => n % 8 == 0).Sum());
            Console.WriteLine("");

            foreach (var num in numbers) {
                Console.WriteLine(num);
            }
        }
    }
}
