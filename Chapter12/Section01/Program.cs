﻿using System.Text.Json;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            /*var novels = new Novel[] {
new Novel {
    Author = "アイザック・アシモフ",
    Title = "われはロボット",
    PublishedYear = 1950,
},
new Novel {
    Author = "ジョージ・オーウェル",
    Title = "一九八四年",
    PublishedYear = 1949,
},
};

var options = new JsonSerializerOptions {
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
    WriteIndented = true
};
string jsonString = JsonSerializer.Serialize(novels, options);
Console.WriteLine(jsonString);*/

            var text = File.ReadAllText("novelists.json");
            var novelist = JsonSerializer.Deserialize<List<Novelist>>(text);
            novelist?.ForEach(Json => Console.WriteLine(Json));
        }
    }

    public class Novel {
        public string Title { get; init; } = String.Empty;

        public string Author { get; init; } = String.Empty;

        public int PublishedYear { get; init; }
    }
}
