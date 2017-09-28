using System;
using System.Collections.Generic;
using QAware.OSS.Models;

namespace QAware.OSS.DataAccess
{
    public interface IBooksRepository
    {
        Book Add(Book Book);
        Book Update(Book Book);
        Book Get(Guid id);
        Book Delete(Guid id);
        ICollection<Book> All();
    }
}