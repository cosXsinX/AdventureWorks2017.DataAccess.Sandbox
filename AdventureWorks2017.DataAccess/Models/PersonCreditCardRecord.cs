using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct PersonCreditCardModelPrimaryKey
    {
        public int BusinessEntityID { get; set; }
        public int CreditCardID { get; set; }

    }

    public class PersonCreditCardModel
    {
        public int BusinessEntityID { get; set; }
        public int CreditCardID { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
