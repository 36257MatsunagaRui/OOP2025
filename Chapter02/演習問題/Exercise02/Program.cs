using System.Globalization;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("***変換アプリ***");
            Console.WriteLine("1:ヤードからメートル");
            Console.WriteLine("2:メートルからヤード");
            Console.Write(">");
            int number = int.Parse(Console.ReadLine());
            Console.Write("はじめ:");
            int start = int.Parse(Console.ReadLine());
            Console.Write("おわり:");
            int end = int.Parse(Console.ReadLine());
            if (number == 1) {
                PrintYardToMeterList(start, end);

            } else if (number == 2) {
                PrintMeterToYardList(start, end);
            }
        }

        // ヤードからメートルへの対応表を出力
        static void PrintYardToMeterList(int start, int end) {
            for (int yard = start; yard <= end; yard++) {
                double meter = YdConverter.ToMeter(yard);
                Console.WriteLine($"{yard}yd = {meter:0.0000}m");
            }
        }

        // メートルからヤードへの対応表を出力
        static void PrintMeterToYardList(int start, int end) {
            for (int meter = start; meter <= end; meter++) {
                double yard = YdConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {yard:0.0000}yd");
            }
        }
    }
}

