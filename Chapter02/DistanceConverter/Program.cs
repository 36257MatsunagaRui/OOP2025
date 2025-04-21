namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {
           //フィートからメートルへの対応表を出力
           for (int feet = 1; feet <= 10; feet++) {
                //double meter = feet * 0.3048;
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }

            //メートルからフィートへの対応表を出力
            for (int meter = 1; meter <= 10; meter++) {
                //double meter = feet * 0.3048;
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }

        //フィートからメートルへの変換
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        //メートルからフィートへの変換
        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }
    }
}
