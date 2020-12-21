using Catalog;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestProject
{
    public class TestsForTask
    {

        [Test]
        public void GetBooksByAuthorTest()
        {
            var catalog = SetUpCatalogForTestOne();

            Assert.AreEqual(catalog.GetBooksByAuthor(new Author { FirstName = "AAA", LastName = "bbb" }).Count, 3,
                "Catalog shold contain three books by this author.");
        }

        private Catalog.Catalog SetUpCatalogForTestOne()
        {
            var a1 = new Author() { FirstName = "Aaa", LastName = "Bbb" };
            var a2 = new Author() { FirstName = "Ccc", LastName = "Ddd" };
            var a3 = new Author() { FirstName = "Eeeeeeee", LastName = "Ffffff" };
            var a4 = new Author() { FirstName = "Ggggg", LastName = "Bbb" };

            var book1 = new Book
            {
                ISBN = "111-1-11-111111-1",
                BookName = "Abcd",
                PublishDate = new DateTime(2015, 7, 20),
                Authors = new List<Author> { a1, a2 }
            };

            var book2 = new Book
            {
                ISBN = "2222222222222",
                BookName = "Lsldl",
                PublishDate = DateTime.Now,
                Authors = new List<Author> { a1, a2, a3, a4 }
            };

            var book3 = new Book
            {
                ISBN = "3333333333333",
                BookName = "Prosto kniga",
                PublishDate = new DateTime(2021, 8, 20),
                Authors = new List<Author> { a1 }
            };

            var catalog = new Catalog.Catalog();
            catalog.AddBook(book1);
            catalog.AddBook(book2);
            catalog.AddBook(book3);
            catalog.AddBook(book3);

            return catalog;
        }

        [Test]
        public void GetBooksOrderedByDateDescTest()
        {

            var a1 = new Author() { FirstName = "Aaa", LastName = "Bbb" };
            var a2 = new Author() { FirstName = "Ccc", LastName = "Ddd" };
            var a3 = new Author() { FirstName = "Eeeeeeee", LastName = "Ffffff" };
            var a4 = new Author() { FirstName = "Ggggg", LastName = "Bbb" };

            var book1 = new Book
            {
                ISBN = "111-1-11-111111-1",
                BookName = "Abcd",
                PublishDate = new DateTime(2015, 7, 20),
                Authors = new List<Author> { a1, a2 }
            };

            var book2 = new Book
            {
                ISBN = "2222222222222",
                BookName = "Lsldl",
                PublishDate = DateTime.Now,
                Authors = new List<Author> { a1, a2, a3, a4 }
            };

            var book3 = new Book
            {
                ISBN = "3333333333333",
                BookName = "Prosto kniga",
                PublishDate = new DateTime(2021, 8, 20),
                Authors = new List<Author> { a1 }
            };

            var catalog = new Catalog.Catalog();
            catalog.AddBook(book1);
            catalog.AddBook(book2);
            catalog.AddBook(book3);

            var orderedBooks = new List<Book>() { book3, book2, book1 };

            Assert.AreEqual(orderedBooks, catalog.GetBooksOrderedByDateDesc(), "Books in catalog should be ordered by date.");
        }

        [Test]
        public void GetAuthorsWithBookCountsTest()
        {
            var catalog = SetUpCatalogForTestThree();

            Assert.AreEqual(catalog.GetAuthorsWithBookCounts().Count, 4,
                "Catalog should contain books books written by four authors");

        }
        private Catalog.Catalog SetUpCatalogForTestThree()
        {
            var a1 = new Author() { FirstName = "Aaa", LastName = "Bbb" };
            var a2 = new Author() { FirstName = "Ccc", LastName = "Ddd" };
            var a3 = new Author() { FirstName = "Eeeeeeee", LastName = "Ffffff" };
            var a4 = new Author() { FirstName = "Ggggg", LastName = "Bbb" };

            var book1 = new Book
            {
                ISBN = "111-1-11-111111-1",
                BookName = "Abcd",
                PublishDate = new DateTime(2015, 7, 20),
                Authors = new List<Author> { a1, a2 }
            };

            var book2 = new Book
            {
                ISBN = "2222222222222",
                BookName = "Lsldl",
                PublishDate = DateTime.Now,
                Authors = new List<Author> { a1, a2, a3, a4 }
            };

            var book3 = new Book
            {
                ISBN = "3333333333333",
                BookName = "Prosto kniga",
                PublishDate = new DateTime(2021, 8, 20),
                Authors = new List<Author> { a1 }
            };

            var catalog = new Catalog.Catalog();
            catalog.AddBook(book1);
            catalog.AddBook(book2);
            catalog.AddBook(book3);

            return catalog;
        }
    }

}
