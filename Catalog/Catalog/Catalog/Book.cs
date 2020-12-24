using System;
using System.Collections.Generic;

namespace Catalog
{
    public class Book
    {
        public ISBN ISBN { get; private set; }

        public string BookName { get; private set; }
        
        public DateTime? PublishDate { get; private set; }

        public List<Author> Authors { get; private set; }

        public Book(string isbn, string bookName, DateTime? publishDate, List<Author> authors)
        {
            if(bookName.Length > 1000 || string.IsNullOrEmpty(bookName))
            {
                throw new ArgumentException();
            }

            ISBN = new ISBN(isbn);
            BookName = bookName;
            PublishDate = publishDate;
            Authors = authors;
        }

        public Book(string isbn, string bookName) : this(isbn, bookName, null, new List<Author>())
        {
        }
    }
}
