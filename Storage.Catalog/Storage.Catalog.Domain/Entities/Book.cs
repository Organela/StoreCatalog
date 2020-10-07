using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Catalog.Domain.Entities
{
    public class Book : Product
    {
        public virtual string Author { get; set;}
        
    }
}
