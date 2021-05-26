using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Core.AdoNet;
using Week4.Core.BusinessLayer;
using Week4.Core.EF.Repository;
using Week4.Core.Interfaces;
using Week4.Core.Model;

namespace Week4.Library.Wcf
{
    public class LibraryService : ILibraryService
    {
        ILibraryBL bl;

        public LibraryService()
        {
            //var bookRepo = new AdoNetBookRepository();
            //var loanRepo = new AdoNetLoanRepository();

            var bookRepo = new EFBookRepository();
            var loanRepo = new EFLoanRepository();

            bl = new LibraryBL(bookRepo, loanRepo);
        }

        public bool AddNewBook(Book newBook)
        {
            try
            {
                return bl.CreateBook(newBook);
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool DeleteBookByISBN(string isbn)
        {
            try
            {
                var book = GetBookByISBN(isbn);

                return bl.DeleteBook(book);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditBook(Book updatedBook)
        {
            try
            {
                return bl.EditBook(updatedBook);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Book GetBookByISBN(string isbn)
        {  
            try
            {
                return bl.FetchBookByISBN(isbn);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Book> GetBooks()
        {
            try
            {
                return bl.FetchBooks().ToList();
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }

        public bool LoanBook(string isbn, string requestor)
        {
            try
            {
                return bl.LoanBook(isbn, requestor);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ReturnBook(string isbn)
        {
            try
            {
                return bl.ReturnBook(isbn);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
