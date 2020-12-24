using Catalog;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestProject
{
    public class TestsForTask
    {
        private Catalog.Catalog _catalog;
        private Book _book1;
        private Book _book2;
        private Book _book3;

        [SetUp]
        public void AfterTests()
        {
            var a1 = new Author("Aaa", "Bbb");
            var a2 = new Author("Ccc", "Ddd");
            var a3 = new Author("Eeeeeeee", "Ffffff");
            var a4 = new Author("Ggggg", "Bbb");

            _book1 = new Book("111-1-11-111111-1", "Abcd", new DateTime(2015, 7, 20), new List<Author> { a1, a2 });
            _book2 = new Book("2222222222222", "Lsldl", DateTime.Now, new List<Author> { a1, a2, a3, a4 });
            _book3 = new Book("3333333333333", "Prosto kniga", new DateTime(2021, 8, 20), new List<Author> { a1 });

            _catalog = new Catalog.Catalog();
            _catalog.Add(_book1);
            _catalog.Add(_book2);
            _catalog.Add(_book3);
            _catalog.Add(_book3);
        }


        [Test]
        public void GetBooksByAuthorTest()
        {
            Assert.AreEqual(_catalog.GetBooksByAuthor(new Author("AAA", "bbb")).Count, 3,
                "Catalog shold contain three books by this author.");
        }

        [Test]
        public void GetBooksOrderedByDateDescTest()
        {
            var orderedBooks = new List<Book>(){ _book3, _book2, _book1 };

            Assert.AreEqual(orderedBooks, _catalog.GetBooksOrderedByDateDesc(), "Books in catalog should be ordered by date.");
        }

        [Test]
        public void GetAuthorsWithBookCountsTest()
        { 
            Assert.AreEqual(_catalog.GetAuthorsWithBookCounts().Count, 4,
                "Catalog should contain books books written by four authors");
        }
    }
}
