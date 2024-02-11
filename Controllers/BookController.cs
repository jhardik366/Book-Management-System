using BookManagement.Interface;
using BookManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [Authorize]
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _book;

        public BookController(IBook book)
        {
            _book = book;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await Task.FromResult(_book.GetBookDetails());
        }

        // GET api/book/{guid}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(Guid id)
        {
            var book = await Task.FromResult(_book.GetBookDetails(id));
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        // POST api/book
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            _book.AddBook(book);
            return await Task.FromResult(book);
        }

        // PUT api/book/{guid}
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(Guid id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }
            try
            {
                _book.UpdateBook(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsBookExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(book);
        }

        // DELETE api/book/{guid}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(Guid id)
        {
            var book = _book.DeleteBook(id);
            return await Task.FromResult(book);
        }

        private bool IsBookExist(Guid id)
        {
            return _book.IsBookExist(id);
        }
    }
}
