using System;
using System.IO;
using System.Threading.Tasks;

namespace Exercise01_Console {
    internal class Program {
        static async Task Main(string[] args) {

            Console.WriteLine("ファイルを読み込み中");
            Console.WriteLine("----------------------");
            Console.WriteLine("");

            string filePath = "C://Users//infosys//source//repos//OOP2025//Chapter14//演習問題//Exercise01_Form//走れメロス.txt";

            try {
                string fileContent = "";

                using (StreamReader reader = new StreamReader(filePath)) {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null) {
                        fileContent += line + Environment.NewLine;
                    }
                }

                Console.WriteLine(fileContent);
                Console.WriteLine("----------------------");

                Console.WriteLine("ファイルの読み込み完了");
            }
            catch (FileNotFoundException) {
                Console.WriteLine("指定されたファイルが見つかりませんでした");
            }
            catch (Exception ex) {
                Console.WriteLine("ファイルの読み込み中にエラーが発生しました");
            }
            Console.ReadKey();
        }
    }
}
