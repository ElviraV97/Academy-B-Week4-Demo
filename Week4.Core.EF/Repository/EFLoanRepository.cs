using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.Core.Interfaces;
using Week4.Core.Model;

namespace Week4.Core.EF.Repository
{
    public class EFLoanRepository : ILoanRepository
    {
        private readonly LibraryContext ctx;

        public EFLoanRepository() : this(new LibraryContext())
        {

        }

        public EFLoanRepository(LibraryContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Loan item)
        {
            try
            {
                ctx.Loans.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Loan item)
        {
            throw new NotImplementedException();
        }

        public List<Loan> Fetch()
        {
            return ctx.Loans.ToList();
        }

        public Loan GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Loan item)
        {
            try
            {
                ctx.Loans.Update(item);
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
