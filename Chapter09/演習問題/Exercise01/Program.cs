using System.Globalization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            //2024/03/09 19:03
            //string Formatを使った例
            var date1 = string.Format($"{dateTime:yyyy/MM/dd HH:mm}");
            Console.WriteLine(date1);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            //2024年03月09日 19時03分09秒
            //DateTime ToStringを使った例
            var date2 = dateTime.ToString($"{dateTime:yyyy年MM月dd日 HH時mm分ss秒}");
            Console.WriteLine(date2);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("jp-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            /*和暦2桁表示(ゼロサプレスなし)
            var str = dateTime.ToString("ggyy年MM月dd日", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            Console.WriteLine(str + dateTime.ToString("(ddd曜日)", culture));*/

            //和暦2桁表示(ゼロサプレスなし)
            var datestr = dateTime.ToString("ggy", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            var str = string.Format($"{datestr}年{dateTime.Month,2}月{dateTime.Day,2}日({dayOfWeek})");
            Console.WriteLine(str);

            //和暦２桁表示（ゼロサプレスあり）
            var cul = dateTime.ToString("gg", culture);
            var year = int.Parse(dateTime.ToString("yy", culture));
            var str2 = string.Format($"{cul}{year,2}年{dateTime.Month,2}月{dateTime.Day,2}日({dayOfWeek})");
            Console.WriteLine(str2);
        }
    }
}
