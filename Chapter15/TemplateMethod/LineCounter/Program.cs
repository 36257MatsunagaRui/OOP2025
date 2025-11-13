using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("ファイルパスの指定:");
            string path = Console.ReadLine();
            TextProcessor.Run<LineCounterProcessor>(path);
        }
    }
}
