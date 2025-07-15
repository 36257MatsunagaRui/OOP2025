using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //問題12.1.1
            var emp = new Employee {
                Id = 123,
                Name = "山田太郎",
                HireDate = new DateTime(2018, 10, 1)
            };
            var jsonString = Serialize(emp);
            Console.WriteLine(jsonString);
            var obj = Deserialize(jsonString);
            Console.WriteLine(obj);

            //問題12.1.2
            Employee[] employees = [
                new () {
                    Id = 123,
                    Name = "山田太郎",
                    HireDate = new DateTime(2018, 10, 1),
                },
                new () {
                    Id = 198,
                    Name = "田中花子",
                    HireDate = new DateTime(2020, 4, 1),
                },
            ];
            Serialize("employees.json", employees);

            //問題12.1.3
            var empdata = Deserialize_f("employees.json");
            foreach (var empd in empdata)
                Console.WriteLine(empd);
        }

        //問題12.1.1
        static string Serialize(Employee emp) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(emp, options);
            return jsonString;
        }

        static Employee? Deserialize(string text) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            return JsonSerializer.Deserialize<Employee>(text, options);
        }

        //問題12.1.2
        //シリアル化してファイルへ出力する
        static void Serialize(string filepath, IEnumerable<Employee> employees) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            //string jsonString = JsonSerializer.Serialize(employees, options);
            //File.WriteAllText(filepath, jsonString);
            byte[] utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(employees, options);
            File.WriteAllBytes(filepath, utf8Bytes);
        }

        //問題12.1.3
        //逆シリアル化して返す
        static Employee[] Deserialize_f(string filepath) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            var text = File.ReadAllText(filepath);
            var employees = JsonSerializer.Deserialize<Employee[]>(text, options);
            return employees ?? [];
        }
    }

    public record Employee {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
    }
}
