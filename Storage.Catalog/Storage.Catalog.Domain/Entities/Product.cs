using System;

namespace Storage.Catalog.Domain
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Cover { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
    }
}
