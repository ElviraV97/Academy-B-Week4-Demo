using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.Core.BusinessLayer;
using Week4.Core.EF.Repository;
using Week4.Core.Interfaces;
using Week4.Core.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week4.Library.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private ILibraryBL businessLayer;

        public LoanController()
        {
            var bookRepo = new EFBookRepository();
            var loanRepo = new EFLoanRepository();
            this.businessLayer = new LibraryBL(bookRepo, loanRepo);
        }

        // GET: api/<LoanController>
        [HttpGet]
        public ActionResult Get()
        {
            var result = this.businessLayer.FetchLoans();

            return Ok(result);
        }

        // GET api/<LoanController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Loan ID.");

            var loan = this.businessLayer.FetchLoanById(id);

            if (loan == null)
                return NotFound($"Loan with ID = {id} is missing.");

            return Ok(loan);
        }

        // POST api/<LoanController>
        [HttpPost]
        public ActionResult Post([FromBody] Loan newLoan)
        {
            if (newLoan == null)
                return BadRequest("Invalid Book data.");

            this.businessLayer.CreateLoan(newLoan);

            return Created($"/ticket/{newLoan.Id}", newLoan);
        }

        // PUT api/<LoanController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Loan editedLoan)
        {
            if (editedLoan == null)
                return BadRequest("Invalid Book data.");

            if (id != editedLoan.Id)
                return BadRequest("Book ISBNs don't match.");

            this.businessLayer.EditLoan(editedLoan);

            return Ok();
        }

        // DELETE api/<LoanController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Loan ID.");

            var loanToBeDeleted = this.businessLayer.FetchLoanById(id);

            if (loanToBeDeleted != null)
                this.businessLayer.DeleteLoan(loanToBeDeleted);

            return Ok();
        }
    }
}
