using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct PhoneNumberTypeModelPrimaryKey
    {
        public int PhoneNumberTypeID { get; set; }

    }

    public class PhoneNumberTypeModel
    {
        public int PhoneNumberTypeID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
