using System;

namespace Site.Models
{
    public class BlogEntry
    {
        public virtual int Id { get; private set; }
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime PublicationDate { get; set; }
    }
}