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
    public class BookController : ControllerBase
    {
        private ILibraryBL businessLayer;

        public BookController()
        {
            var bookRepo = new EFBookRepository();
            var loanRepo = new EFLoanRepository();
            this.businessLayer = new LibraryBL(bookRepo, loanRepo);
        }

        // GET: api/<BookController>
        [HttpGet]
        public ActionResult Get()
        {
            var result = this.businessLayer.FetchBooks();

            return Ok(result);
        }

        // GET api/<BookController>/5
        [HttpGet("{isbn}")]
        public ActionResult Get(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                return BadRequest("Invalid Book ISBN.");

            var book = this.businessLayer.FetchBookByISBN(isbn);

            if (book == null)
                return NotFound($"Ticket with ISBN = {isbn} is missing.");

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult Post([FromBody] Book newBook)
        {
            if (newBook == null)
                return BadRequest("Invalid Book data.");

            this.businessLayer.CreateBook(newBook);

            return Created($"/ticket/{newBook.ISBN}", newBook);
        }

        // PUT api/<BookController>/5
        [HttpPut("{isbn}")]
        public ActionResult Put(string isbn, [FromBody] Book editedBook)
        {
            if (editedBook == null)
                return BadRequest("Invalid Book data.");

            if (isbn != editedBook.ISBN)
                return BadRequest("Book ISBNs don't match.");

            this.businessLayer.EditBook(editedBook);

            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{isbn}")]
        public ActionResult Delete(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                return BadRequest("Invalid Book ISBN.");

            var bookToBeDeleted = this.businessLayer.FetchBookByISBN(isbn);

            if (bookToBeDeleted != null)
                this.businessLayer.DeleteBook(bookToBeDeleted);

            return Ok();
        }

        #region Pragmatic REST

        [HttpPost("{isbn}/loan/{requestor}")]
        public ActionResult LoanBook(string isbn, string requestor)
        {
            var result = this.businessLayer.LoanBook(isbn, requestor);

            if (!result)
                return BadRequest($"Cannot loan the book with ISBN = {isbn} to {requestor}.");

            return Ok($"Book with ISBN = {isbn} loaned to {requestor}.");
        }

        [HttpPost("{isbn}/return")]
        public ActionResult ReturnBook(string isbn)
        {
            var result = this.businessLayer.ReturnBook(isbn);

            if (!result)
                return BadRequest($"Error processing the return of book with ISBN = {isbn}.");

            return Ok($"Book with ISBN = {isbn} has been successfully returned.");
        }

        #endregion
    }
}
