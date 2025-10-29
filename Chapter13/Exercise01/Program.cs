
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
                .ThenByDescending(b => b.Price);

            foreach (var book in books) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title}");
            }
        }

        private static void Exercise1_5() {
            var names = Library.Books
                .Where(b => b.PublishedYear == 2022)
                .Join(Library.Categories,
                    book => book.CategoryId,
                    category => category.Id,
                    (book, category) => category.Name)
                .Distinct();

            foreach(var name in names) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise1_6() {
            var groups = Library.Books
                .Join(Library.Categories,
                        b => b.CategoryId,
                        c => c.Id,
                        (b, c) => new {
                            CategoryName = c.Name,
                            b.Title
                        })
                .GroupBy(x => x.CategoryName)
                .OrderBy(x => x.Key);

            foreach (var group in groups) {
                Console.WriteLine($"# {group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"   {book.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var groups = Library.Categories
                .Where(x => x.Name.Equals("Development"))
                .Join(Library.Books,
                        c => c.Id,
                        b => b.CategoryId,
                        (c, book) => new {
                            book.Title,
                            book.PublishedYear
                        })
                .GroupBy(x => x.PublishedYear)
                .OrderBy(x => x.Key);

            foreach (var group in groups) {
                Console.WriteLine($"# {group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"   {book.Title}");
                }
            }
        }

        private static void Exercise1_8() {

        }
    }
}
