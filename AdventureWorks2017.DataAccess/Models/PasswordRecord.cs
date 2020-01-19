using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct PasswordModelPrimaryKey
    {
        public int BusinessEntityID { get; set; }

    }

    public class PasswordModel
    {
        public int BusinessEntityID { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
