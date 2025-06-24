using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var ToDay = DateTime.Today; //日付
            var today = new DateTime(2024,7,12); //日付
            var now = DateTime.Now; //日付と時刻

            Console.WriteLine($"TODAY:{ToDay}");
            Console.WriteLine($"Today:{today.Month}");
            Console.WriteLine($"Now:{now}");

            //①自分の生年月日は何曜日かをプログラムを書いて調べる
            Console.Write("西暦:");
            var year = int.Parse(Console.ReadLine());

            Console.Write("月:");
            var month = int.Parse(Console.ReadLine());

            Console.Write("日:");
            var day = int.Parse(Console.ReadLine());

            var birthDay = new DateTime(year, month, day);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birthDay.ToString("ggyy年M月d日", culture);

            //曜日
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birthDay.DayOfWeek);
            Console.WriteLine($"生年月日:{str + dayOfWeek}");

            Console.WriteLine($"生年月日:{ str + birthDay.ToString("ddd曜日", culture)}");

            //②閏年の判定プログラムを作成する
            Console.Write("Year:");
            var getYear = Console.Read();
            var isLeapYear = DateTime.IsLeapYear(getYear);
            if (isLeapYear) {
                Console.WriteLine("閏年です");
            } else {
                Console.WriteLine("閏年ではありません");
            }

            //③生まれてから○○〇〇日目です
            TimeSpan diff = ToDay - birthDay;
            Console.WriteLine($"生まれてから{ diff.Days}日目です");

            //生まれてからの経過秒数
            Console.WriteLine($"\r{diff.TotalSeconds}秒");

            //④あなたは○○歳です
            var age = GetAge(birthDay, DateTime.Today);
            Console.WriteLine($"年齢:{age}歳");

            //⑤1月1日から何日目か?
            var toDay = DateTime.Today;
            int dayOfYear = toDay.DayOfYear;
            Console.WriteLine($"1月1日から{dayOfYear}日目です");
        }

        //④年齢を求めるメソッド
        static int GetAge(DateTime birthDay, DateTime targetDay) {
            var age = targetDay.Year - birthDay.Year;
            if (targetDay < birthDay.AddYears(age)) {
                age--;
            }
            return age;
        }
    }
}
