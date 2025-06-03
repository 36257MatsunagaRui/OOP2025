using System.Diagnostics.Tracing;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            foreach (var pair in line.Split(';')) {
                var word = pair.Split('=');
                Console.WriteLine($"{ToJapanese(word[0])}:{word[1]}");
            }

            /*for (int i = 0; i < array.Length; i++) {
                    var word = array[i].Split('=');
                    Console.WriteLine($"{ToJapanese(word[0])}:{word[1]}");
            }*/
        }

            /// <summary>
            /// 引数の単語を日本語へ変換します
            /// </summary>
            /// <param name="key">"Novelist","BestWork","Born"</param>
            /// <returns>"「作家」,「代表作」,「誕生年」</returns>
        static string ToJapanese(string key) {
            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => "引数keyは、正しい値ではありません"
            };
        }
    }
}