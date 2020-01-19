using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public class PersonModel
    {
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Suffix { get; set; }
        public int EmailPromotion { get; set; }
        public System.Xml.XmlDocument? AdditionalContactInfo { get; set; }
        public System.Xml.XmlDocument? Demographics { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
