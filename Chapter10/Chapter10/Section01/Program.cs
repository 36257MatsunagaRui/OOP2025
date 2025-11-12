using System.IO;
using System.Text;
namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var filePath = "./Greeting.txt";

            //コード10.1
            /*if (File.Exists(filePath)) {
                using var reader = new StreamReader(filePath, Encoding.UTF8);
                while (!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    Console.WriteLine();
                }
            }*/

            //コード10.2
            /*var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            foreach (var line in lines) {
                Console.WriteLine(line);
            }*/

            //コード10.3
            /*var lines = File.ReadLines(filePath);
            foreach (var line in lines) {
                Console.WriteLine(line);
            }*/

            //コード10.4
            /*var lines = File.ReadLines(filePath)
                .Take(10)
                .ToArray();*/

            //コード10.5
            /*var count = File.ReadLines(filePath)
                .Count(s => s.Contains("C#"));*/

            //コード10.6
            /*var lines = File.ReadLines(filePath)
                .Where(s => !String.IsNullOrWhiteSpace(s))
                .ToArray();*/

            //コード10.7
            /*var exists = File.ReadLines(filePath)
                .Where(s => !String.IsNullOrEmpty(s))
                .Any(s => s.All(c => char.IsAsciiDigit(c)));*/

            //コード10.8
            /*var lines = File.ReadLines(filePath)
                .Distinct()
                .OrderBy(s => s.Length)
                .ToArray();*/

            //コード10.9
            /*var lines = File.ReadLines(filePath)
                .Select((s, ix) => $"{ix + 1,4}: {s}");
            foreach (var line in lines) {
                Console.WriteLine(line);
            }*/

            //var filePath = "./Example/いろは歌.txt";

            //コード10.10
            /*using (var writer = new StreamWriter(filePath)) {
                writer.WriteLine("色はにほへど　散りぬるを");
                writer.WriteLine("我が世たれぞ　常ならむ");
                writer.WriteLine("有為の奥山　今日越えて");
                writer.WriteLine("浅き夢見じ　酔ひもせず");
            }*/

            //コード10.11
            /*var lines = new[] { "====", "京の歌", "大阪の夢", };
            using (var writer = new StreamWriter(filePath, append: true)) {
                foreach (var line in lines) {
                    writer.WriteLine(line);
                }
            }*/

            //var filePath = "./Example/Cities.txt";

            //コード10.12
            /*var lines = new[] { "Tokyo", "New Delhi", "Bangkok", "London", "Paris" };
            File.WriteAllLines(filePath, lines );*/

            //コード10.13
            /*var names = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "HongKong",
            };
            File.WriteAllLines(filePath, names.Where(s => s.Length > 5));*/

            //コード10.14
            var filePath = "./Example/いろは歌.txt";

            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            using var reader = new StreamReader(stream);
            using var writer = new StreamWriter(stream);

            string texts = reader.ReadToEnd();
            stream.Position = 0;
            writer.WriteLine("挿入する新しい行1");
            writer.WriteLine("挿入する新しい行2");
            writer.Write(texts);

            //コード10.15
            if (File.Exists("./Example/Greeting.txt")) {
                Console.WriteLine("すでに存在しています。");
            }

            //コード10.16
            /*var fi = new FileInfo("./Example/Greeting.txt");
            if (fi.Exists) {
                Console.WriteLine("すでに存在しています。");
            }*/

            //コード10.17
            File.Delete("./Example/Greeting.txt");

            //コード10.18
            /*var fi = new FileInfo("./Example/Greeting.txt");
            fi.Delete();*/

            //コード10.19
            File.Copy("./Example/src/Greeting.txt", "./Example/dest/Greeting.txt");

            File.Copy("./Example/src/Greeting.txt", "./Example/dest/Greeting.txt", overwrite: true);

            //コード10.20
            /*var fi = new FileInfo("./Example/src/Greeting.txt");
            FileInfo dup = fi.CopyTo("./Example/dest/Greeting.txt", overwrite: true);*/

            //コード10.21
            File.Move("./Example/src/Greeting.txt", "./Example/dest/Greeting.txt");

            //コード10.22
            /*var fi = new FileInfo("./Example/src/Greeting.txt");
            fi.MoveTo("./Example/dest/Greeting.txt");*/

            //コード10.23
            File.Move("./ Example/oldfile.txt", "./Example/newfile.txt");

            //コード10.24
            /*var fi = new FileInfo("./ Example/oldfile.txt");
            fi.MoveTo("./Example/newfile.txt");*/

            //コード10.25
            /*var lastWriteTime = File.GetLastWriteTime("./Example/Greeting.txt");*/

            //コード10.26
            File.SetLastWriteTime("./Example/Greeting.txt", DateTime.Now);

            //コード10.27
            var fi = new FileInfo("./Example/Greeting.txt");
            DateTime lastWriteTime = fi.LastWriteTime;

            //コード10.28
            fi.LastWriteTime = DateTime.Now;

            //コード10.29
            var finfo = new FileInfo("./Example/Greeting.txt");
            DateTime lastCreationTime = finfo.CreationTime;

            //コード10.30
            long size = fi.Length;

            //コード10.31
            if (fi.Length == 0) {
                fi.Delete();
            }

            //コード10.32
            if (Directory.Exists("./Example")) {
                Console.WriteLine("存在しています");
            } else {
                Console.WriteLine("存在していません");
            }

            //コード10.33
            /*DirectoryInfo di = Directory.CreateDirectory("./Example");*/

            //コード10.34
            /*DirectoryInfo di = Directory.CreateDirectory("./Example/temp");*/

            //コード10.35
            /*var di = new DirectoryInfo("./Example");
            di.Create();

            DirectoryInfo di = Directory.CreateDirectory("./Example");
            DirectoryInfo sdi = di.CreateSubdirectory("temp");*/

            //コード10.36
            Directory.Delete("./Example/temp");

            //コード10.37
            Directory.Delete("./Example/temp", recursive: true);

            //コード10.38
            /*var di = new DirectoryInfo("./Example/temp");
            di.Delete(recursive: true);*/

            //コード10.39
            Directory.Move("./Example/temp", "./MyWork");

            //コード10.40
            /*var di = new DirectoryInfo("./Example/temp");
            di.MoveTo("./MyWork");*/

            //コード10.41
            Directory.Move("./Example/temp", "./Example/save");

            //コード10.42
            /*var di = new DirectoryInfo("./Example/temp");
            di.MoveTo("./Example/save");*/

            //コード10.43
            var di = new DirectoryInfo("./Example");
            /*var files = di.EnumerateFiles("*");
            foreach (var file in files) {
                Console.WriteLine($"{file.Name} {file.CreationTime}");
            }

            var files = di.EnumerateFiles("*.txt")
                .Where(x => x.Name.Contains("temp"))
                .Take(20);

            var files = di.EnumerateFiles("*", SearchOption.AllDirectories);*/

            //コード10.44
            /*var directories = di.EnumerateDirectories();
            foreach (var dir in directories) {
                Console.WriteLine($"{dir.FullName} {dir.CreationTime}");
            }
            
             var directories = di.EnumerateDirectories("*", SearchOption.AllDirectories);*/

            //コード10.45
            /*var fileSystems = di.EnumerateFileSystemInfos();
            foreach (var item in fileSystems) {
                if (item.Attributes.HasFlag(FileAttributes.Directory)) {
                    Console.WriteLine($"ディレクトリ:{item.Name} {item.CreationTime}");
                } else {
                    Console.WriteLine($"ファイル:{item.Name} {item.CreationTime}");
                }
            }*/

            //コード10.46
            /*var now = DateTime.Now;
            FileSystemInfo[] fileSystems = di.GetFileSystemInfos();
            foreach (var item in fileSystems) {
                item.LastWriteTime = now;
            }

            //コード10.47
            var path = @"C:\Program Files\Microsoft Office\Office16\EXCEL.EXE";
            var directoryName = Path.GetDirectoryName(path);
            var fileName = Path.GetFileName(path);
            var extension = Path.GetExtension(path);
            var filenameWithoutExtension = Path.GetFileNameWithoutExtension(path);

            Console.WriteLine($"DirectoryName : {directoryName}");
            Console.WriteLine($"FileName : {fileName}");
            Console.WriteLine($"Extension : {extension}");
            Console.WriteLine($"FilenameWithoutExtension : {filenameWithoutExtension}");*/

            //コード10.48
            var fullPath = Path.GetFullPath(@"../Greeting.txt");

            //コード10.49
            /*var dir = "./Example/Temp";
            var fname = "Greeting.txt";
            var path = Path.Combine(dir, fname);*/

            //コード10.50
            var topdir = "./Example/";
            var subdir = "Temp";
            var fname = "Greeting.txt";
            var path = Path.Combine(topdir, subdir, fname);

            //コード10.51
            var tempFileName = Path.GetTempFileName();

            //コード10.52
            var tempPath = Path.GetTempPath();

            //コード10.53
            //UserProfileフォルダーの取得
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Console.WriteLine($"UserProfile {userProfile}");

            //デスクトップフォルダーの取得
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine($"DesktopPath {desktopPath}");

            //マイドキュメントフォルダーの取得
            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine($"MyDocumentsPath {myDocumentsPath}");

            //プログラムファイルフォルダーの取得
            var programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            Console.WriteLine($"ProgramFilesPath {programFilesPath}");

            //システムフォルダーの取得
            var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            Console.WriteLine($"SystemPath {systemPath}");
        }
    }
}
