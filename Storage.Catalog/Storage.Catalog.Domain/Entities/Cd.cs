using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Catalog.Domain.Entities
{
    public class Cd : Product
    {
        public virtual string Artist { get; set; }
    }
}
