using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Catalog
{
    public class Catalog : IEnumerable<Book>
    {
        public Dictionary<string, Book> BookCatalog { get; private set; }

        public void AddBook(Book book)
        {
            if(BookCatalog == null)
            {
                BookCatalog = new Dictionary<string, Book>();
            }

            var results = new List<ValidationResult>();
            var context = new ValidationContext(book);

            if (!BookCatalog.Keys.Any(x => x == book.ISBN.Trim('-')) 
                && Validator.TryValidateObject(book, context, results, true))
            {
                BookCatalog.Add(book.ISBN, book);
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return ((IEnumerable<Book>)BookCatalog).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return BookCatalog.OrderBy(x => x.Value.BookName).GetEnumerator();
        }

        public List<Book> GetBooksOrderedByDateDesc()
        {
            var books = BookCatalog.Select(kvp => kvp.Value);

            return books.OrderByDescending(x => x.PublishDate).ToList();
        }

        public List<Book> GetBooksByAuthor(Author author)
        {
            var books = BookCatalog.Select(kvp => kvp.Value);

            return books.Where(b => b.Authors.Any(x => x.FirstName.ToLower() == author.FirstName.ToLower()
                  && x.LastName.ToLower() == author.LastName.ToLower())).ToList();
        } 


        public List<Tuple<Author, int>> GetAuthorsWithBookCounts()
        {
            var books = BookCatalog.Select(kvp => kvp.Value).ToList();
            var authors = new List<Author>();

            foreach (var book in books)
            {
                authors.AddRange(book.Authors);
            }

            return authors.GroupBy(p => p)
                .Select(g => new Tuple<Author, int>(g.Key, g.Count()))
                .ToList();
        }
    }
}
