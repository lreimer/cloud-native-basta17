using System;

namespace QAware.OSS.Models
{
    public class Book
    {
        public Book()
        {
        }

        public Book(Guid guid, string name)
        {
            this.ID = guid;
            this.Name = name;
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}