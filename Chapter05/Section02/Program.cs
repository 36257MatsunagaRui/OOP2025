namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            //var appVer = new AppVersion(5, 1, 12);
            //Console.WriteLine(appVer);

            var appVer1 = new AppVersion(5, 1);
            var appVer2 = new AppVersion(5, 1);

            Console.WriteLine(appVer1);
            /*if (appVer1 == appVer2) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }*/
        }
    }

    //レコード型の利用
    //public record AppVersion(int m, int mi, int b = 0, int r = 0);

    //プライマリーコンストラクタを使ったクラス定義
    public class AppVersion(int m, int mi, int b = 0, int r = 0) {
        public int Major { get; init; } = m;
        public int Minor { get; init; } = mi;
        public int Build { get; init; } = b;
        public int Revision { get; init; } = r;

        /*public override string ToString() =>
        $"{Major}.{Minor}.{Build}.{Revision}";*/
    }

    /*public class AppVersion {
        public int Major { get; init; }
        public int Minor { get; init; }
        public int Build { get; init; }
        public int Revision { get; init; }*/

        /*public AppVersion(int major, int minor)
            : this(major, minor, 0, 0) {  //- 引数4つのコンストラクターを呼び出す
        }

        public AppVersion(int major, int minor, int build)
            : this(major, minor, build, 0) {  //- 引数4つのコンストラクターを呼び出す
        }*/

        /*public AppVersion(int major, int minor, int build = 0, int revision = 0) {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }

        public override string ToString() =>
        $"{Major}.{Minor}.{Build}.{Revision}";
    }*/
}
