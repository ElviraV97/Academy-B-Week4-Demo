using System;
using System.Collections.Generic;
using System.Text;
using Week4.Core.Model;

namespace Week4.Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetByISBN(string isbn);
    }
}
