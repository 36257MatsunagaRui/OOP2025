
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
            var results = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderBy(b => b.Key)
                .Select(b => new {
                    PublishedYear = b.Key,
                    Count = b.Count()
                });

            foreach (var book in results) {
                Console.WriteLine($"{book.PublishedYear}年:{book.Count}");
            }
        }

        private static void Exercise1_4() {
            var books = Library.Books
                .OrderByDescending(b => b.PublishedYear)
                .ThenByDescending(b => b.Price)
                .ThenBy(b => b.Title);

            foreach (var book in books) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title}");
            }
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
