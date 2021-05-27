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
            try
            {
                var loan = ctx.Loans.Find(item.Id);

                if (loan != null)
                    ctx.Loans.Remove(loan);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Loan> Fetch()
        {
            try
            {
                return ctx.Loans.ToList();
            }
            catch (Exception)
            {
                return new List<Loan>();
            }
        }

        public Loan GetById(int id)
        {
            try
            {
                var loan = ctx.Loans.Find(id);

                return loan;
            }
            catch (Exception)
            {
                return null;
            }
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
