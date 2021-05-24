using System;
using System.Collections.Generic;
using System.Linq;
using Week4.Core.Interfaces;
using Week4.Core.Model;

namespace Week4.Core.BusinessLayer
{
    public class LibraryBL : ILibraryBL
    {
        private readonly IBookRepository bookRepo;

        public LibraryBL(
            IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        #region Book

        public bool CreateBook(Book newBook)
        {
            return bookRepo.Add(newBook);
        }
        public bool EditBook(Book editedBook)
        {
            return bookRepo.Update(editedBook);
        }
        public bool DeleteBook(Book bookToBeDeleted)
        {
            return bookRepo.Delete(bookToBeDeleted);
        }

        public IEnumerable<Book> FetchBooks(Func<Book, bool> filter = null)
        {
            return bookRepo.Fetch();
        }

        public Book FetchBookByISBN(string isbn)
        {
            return bookRepo.Fetch().FirstOrDefault(b => b.ISBN == isbn);
        }

        #endregion
    }
}
