using System.Globalization;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("***変換アプリ***");
            Console.WriteLine("1:インチからメートル");
            Console.WriteLine("2:メートルからインチ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("はじめ:");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("おわり:");
            int end = int.Parse(Console.ReadLine());
            if (number == 1) {
                PrintInchToMeterList(start, end);

            } else if (number == 2) {
                PrintMeterToInchList(start, end);
            }
        }

        // インチからメートルへの対応表を出力
        static void PrintInchToMeterList(int start, int end) {
            for (int inch = start; inch <= end; inch++) {
                double meter = InchConverter.ToMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
            }
        }

        // メートルからインチへの対応表を出力
        static void PrintMeterToInchList(int start, int end) {
            for (int meter = start; meter <= end; meter++) {
                double inch = InchConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {inch:0.0000}inch");
            }
        }
    }
}

