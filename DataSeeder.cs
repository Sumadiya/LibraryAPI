using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Data
{
    public static class DataSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (!context.Books.Any())
            {
                var books = new List<Book>
                {
                    new Book { ISBN = "9780747532743", Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", PublishedDate = new DateTime(1997, 6, 26) },
                    new Book { ISBN = "9780747538486", Title = "Harry Potter and the Chamber of Secrets", Author = "J.K. Rowling", PublishedDate = new DateTime(1998, 7, 2) },
                    new Book { ISBN = "9780747542155", Title = "Harry Potter and the Prisoner of Azkaban", Author = "J.K. Rowling", PublishedDate = new DateTime(1999, 7, 8) },
                    new Book { ISBN = "9780736421775", Title = "The Little Mermaid", Author = "Disney", PublishedDate = new DateTime(2003, 12, 23) },
                    new Book { ISBN = "9780736430517", Title = "Frozen", Author = "Disney", PublishedDate = new DateTime(2013, 10, 1) }
                };

                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }
    }
}
