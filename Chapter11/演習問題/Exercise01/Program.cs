
using System.Text.RegularExpressions;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(IsPhoneNumber("070-7333-1234")); //True
            Console.WriteLine(IsPhoneNumber("080-9111-1234")); //True
            Console.WriteLine(IsPhoneNumber("090-8222-1234")); //True
            Console.WriteLine(IsPhoneNumber("060-1234-5678"));
            Console.WriteLine(IsPhoneNumber("070-A111-B222"));
            Console.WriteLine(IsPhoneNumber("180-1234-5678"));
            Console.WriteLine(IsPhoneNumber("090-12345-6789"));
            Console.WriteLine(IsPhoneNumber("090-123-456789"));
        }

        private static bool IsPhoneNumber(string telName) {
            return Regex.IsMatch(telName, @"^0[7-9]0-\d{4}-\d{4}$");
        }
    }
}
