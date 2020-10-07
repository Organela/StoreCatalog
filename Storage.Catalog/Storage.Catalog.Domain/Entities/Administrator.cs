using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Catalog.Domain.Entities
{
    public class Administrator
    {
        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual bool IsLogged { get; set; }
    }
}
