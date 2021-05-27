using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.Core.EF;
using Week4.Core.Interfaces;
using Week4.Core.Model;

namespace Week4.Core.EF.Repository
{
    public class EFBookRepository : IBookRepository
    {
        private readonly LibraryContext ctx;

        public EFBookRepository() : this(new LibraryContext())
        {
            
        }

        public EFBookRepository(LibraryContext ctx)
        {
            this.ctx = ctx;
        }   
        
        public bool Add(Book newBook)
        {
            try
            {
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Book item)
        {
            try
            {
                var book = ctx.Books.Find(item.ISBN);

                if (book != null)
                    ctx.Books.Remove(book);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Book> Fetch()
        {
            try
            {
                return ctx.Books.ToList();
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Book GetByISBN(string isbn)
        {
            try
            {
                var book = ctx.Books.Include(b => b.Loans)
                    .FirstOrDefault(b => b.ISBN == isbn);

                return book;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Book updatedBook)
        {
            try
            {
                ctx.Books.Update(updatedBook);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
