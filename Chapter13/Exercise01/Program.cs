
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var book = Library.Books
                .MaxBy(x => x.Price);
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var selected = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(b => new {
                    PublishedYear = b.Key,
                    Count = b.Count()
                });

            foreach (var book in selected) {
                Console.WriteLine($"{book.PublishedYear}年:{book.Count}");
            }
        }

        private static void Exercise1_4() {

        }

        private static void Exercise1_5() {

        }

        private static void Exercise1_6() {

        }

        private static void Exercise1_7() {

        }

        private static void Exercise1_8() {

        }
    }
}
