﻿namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            /*var price = Library.Books
                .Where(b => b.CategoryId == 1)
                .Max(b => b.Price);
            Console.WriteLine(price);

            Console.WriteLine();

            var book = Library.Books
                .Where(x => x.PublishedYear >= 2021)
                .MinBy(x => x.Price);
            Console.WriteLine(book);

            Console.WriteLine();

            var average = Library.Books.Average(x => x.Price);
            var aboves = Library.Books.Where(b => b.Price > average);
            foreach (var book1 in aboves) {
                Console.WriteLine(book1);
            }*/

            var selected = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(group => group.MaxBy(b => b.Price))
                .OrderBy(b => b!.PublishedYear);

            foreach (var book in selected) {
                Console.WriteLine($"{book!.PublishedYear}年 {book!.Title} ({book!.Price})");
            }
        }
    }
}
