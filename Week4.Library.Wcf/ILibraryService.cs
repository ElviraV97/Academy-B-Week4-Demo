using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Core.Model;

namespace Week4.Library.Wcf
{
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        List<Book> GetBooks();

        [OperationContract]
        Book GetBookByISBN(string isbn);

        [OperationContract]
        bool AddNewBook(Book newBook);

        [OperationContract]
        bool EditBook(Book updatedBook);

        [OperationContract]
        bool DeleteBookByISBN(string isbn);
        
    }
}
