using System;
using System.Collections.Generic;
using System.Text;
using Week4.Core.Model;

namespace Week4.Core.Interfaces
{
    public interface ILibraryBL
    {
        #region Book
        IEnumerable<Book> FetchBooks(Func<Book, bool> filter = null);
        bool CreateBook(Book newBook);
        bool EditBook(Book editedBook);
        bool DeleteBook(Book bookToBeDeleted);
        Book FetchBookByISBN(string isbn);

        #endregion

        #region Loan

        bool LoanBook(string isbn, string requestor);
        bool ReturnBook(string isbn);

        #endregion
    }
}
