namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            /*IEnumerable<string> query = cities
                 .Where(s => s.Length <= 5) //条件にあったものを抽出
                 .Select(s => s.ToLower()) //別オブジェクトへ変換(新しい型へ射影する)
                 .Select(s => s.ToUpper());
                 .OrderBy(s => s[0]); //先頭の文字からの場合

            foreach (var s in query ) {
                Console.WriteLine(s);
            }*/

            var query = cities.Where(s => s.Length <= 5);    //- query変数に代入
            /*var query = cities.Where(s => s.Length <= 5).ToList(); //即時実行
            var query = cities.Where(s => s.Length <= 5).ToArray(); //即時実行*/

            foreach (var item in query) {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");

            cities[0] = "Osaka";            //- cities[0]を変更 
            foreach (var item in query) {   //- 再度、queryの内容を取り出す【遅延実行】
                Console.WriteLine(item);
            }
        }
    }
}
