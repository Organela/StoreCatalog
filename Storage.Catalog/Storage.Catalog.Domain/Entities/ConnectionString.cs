using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Catalog.Domain.Entities
{
    public class ConnectionString
    {
        public virtual string DefaultConnection { get; set; }
        public virtual string AzureStorageAccount { get; set; }
    }
}
