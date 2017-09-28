using System;
using Microsoft.AspNetCore.Mvc;
using QAware.OSS.DataAccess;
using QAware.OSS.Models;

namespace QAware.OSS.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IBooksRepository booksRepository;
        public BooksController(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return this.Ok(booksRepository.All());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id)
        {
            return this.Ok(booksRepository.Get(id));
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody]Book book)
        {
            book.ID = Guid.NewGuid();
            booksRepository.Add(book);
            return this.Created($"/api/[controller]/{book.ID}", book);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put([FromBody]Book book, Guid id)
        {
            book.ID = id;
            booksRepository.Update(book);

            if (book == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(book.ID);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            Book book = booksRepository.Delete(id);

            if (book == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(book.ID);
            }
        }
    }
}