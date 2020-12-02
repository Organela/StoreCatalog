using System;

namespace Storage.Catalog.Domain.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Image { get; set; }
    }
}
