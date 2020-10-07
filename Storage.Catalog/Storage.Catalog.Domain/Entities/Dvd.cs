using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Catalog.Domain.Entities
{
    public class Dvd : Product
    {
        public virtual string Synopsis { get; set; }
    }
}

