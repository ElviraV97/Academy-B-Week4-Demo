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
        private readonly ILoanRepository loanRepo;

        public LibraryBL(
            IBookRepository bookRepo,
            ILoanRepository loanRepo
            )
        {
            this.bookRepo = bookRepo;
            this.loanRepo = loanRepo;
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

        #region Loan

        public bool LoanBook(string isbn, string requestor)
        {
            return loanRepo.Add(new Loan { 
                BookISBN = isbn,
                User = requestor,
                LoanDate = DateTime.Now,
                ReturnDate = null
            });
        }

        public bool ReturnBook(string isbn)
        {
            var loanRecord = loanRepo.Fetch().FirstOrDefault(l => l.BookISBN == isbn && l.ReturnDate == null);

            if(loanRecord != null)
            {
                loanRecord.ReturnDate = DateTime.Now;

                return loanRepo.Update(loanRecord);
            }

            return true;
        }

        #endregion
    }
}
