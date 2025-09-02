using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            string[] texts = [
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable.",
            ];

            foreach (var line in texts) {
                var matches = Regex.Matches(line, @"\btime\b", RegexOptions.IgnoreCase);
                //var matches = Regex.Matches(line, @"\b(T|t)ime\b");
                foreach (Match m in matches) {
                    Console.WriteLine($"{line.ToString()}:{m.Index}");
                }
            }
        }
    }
}
