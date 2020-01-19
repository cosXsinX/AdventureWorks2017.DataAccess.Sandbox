using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public class JobCandidateModel
    {
        public int JobCandidateID { get; set; }
        public int? BusinessEntityID { get; set; }
        public System.Xml.XmlDocument? Resume { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
