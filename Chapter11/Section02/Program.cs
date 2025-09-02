using System.Text.RegularExpressions;

namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            /*var text = "private List<string> result = new List<string>();";
            bool isMatch = Regex.IsMatch(text, @"List<\w+>");
            var regex = new Regex(@"List<\w+>");
            bool isMatch = regex.IsMatch(text);
            bool isMatch = IsPatternText(text, @"\(\);$");
            bool isMatch = Regex.IsMatch(text, @"\(\);$");*/

            /*if (isMatch) {
                Console.WriteLine("stringで始まっています");
            } else {
                Console.WriteLine("stringで始まっていません");
            }*/

            var strings = new[] {
                "Microsoft Windows",
                "windows",
                "Windows Server",
                "Windows"
            };

            var regex = new Regex(@"^(W|w)indows$");

            //パターンと完全一致している文字列の個数をカウント
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine($"{count}行と一致");

            //パターンと完全一致している文字列を出力する
            strings.Where(s => regex.IsMatch(s)).ToList().ForEach(Console.WriteLine);

            /*var datas = strings.Where(s => regex.IsMatch(s));
            foreach (var items in datas) {
                Console.WriteLine(items);
            }*/

            /*foreach (var s in strings) {
                if (regex.IsMatch(s)) {
                    Console.WriteLine(s);
                }
            }*/
        }

        //指定したパターンに一致した部分文字列があるか判定するメソッド
        //static bool IsPatternText(string text, string pattern) {
        //    return Regex.IsMatch(text, pattern);
        //}
    }
}
