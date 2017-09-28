using System;
using System.Linq;
using System.Collections.Generic;
using QAware.OSS.Models;

namespace QAware.OSS.DataAccess
{
    public class MemoryBooksRepository : IBooksRepository
    {
        private ICollection<Book> books;

        public MemoryBooksRepository()
        {
            books = new List<Book>();
            Add(new Book(Guid.NewGuid(), "Docker, Docker, Docker"));
        }

        public Book Add(Book book)
        {
            books.Add(book);
            return book;
        }

        public ICollection<Book> All()
        {
            return books;
        }

        public Book Delete(Guid id)
        {
            var book = Get(id);

            if (book != null)
            {
                books.Remove(book);
            }

            return book;
        }

        public Book Get(Guid id)
        {
            return books.Where(b => b.ID == id).FirstOrDefault();
        }

        public Book Update(Book book)
        {
            Delete(book.ID);
            return Add(book);
        }
    }
}