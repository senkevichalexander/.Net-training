using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Catalog
{
    public class Catalog : IEnumerable<Book>
    {
        public Dictionary<ISBN, Book> BookCatalog { get; private set; }
        public int Size { get; }

        public Catalog()
        {
            BookCatalog = new Dictionary<ISBN, Book>();
        }

        public void Add(Book book)
        {
            if (!BookCatalog.Keys.Any(item => item.Equals(book.ISBN)
                 || item.GetHashCode() == book.GetHashCode()))
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
            var books = GetBooks();

            return books.OrderByDescending(x => x.PublishDate).ToList();
        }

        public List<Book> GetBooksByAuthor(Author author)
        {
            var books = GetBooks();

            return books.Where(b => DoesAuthorExist(b, author)).ToList();
        }

        private bool DoesAuthorExist(Book book, Author author)
        {
            return book.Authors.Any(x => x.FirstName.ToLower() == author.FirstName.ToLower()
                  && x.LastName.ToLower() == author.LastName.ToLower());
        }

        private List<Book> GetBooks()
        {
            return BookCatalog.Select(kvp => kvp.Value).ToList();
        }

        public List<Tuple<Author, int>> GetAuthorsWithBookCounts()
        {
            var books = GetBooks();
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
