using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct IllustrationModelPrimaryKey
    {
        public int IllustrationID { get; set; }

    }

    public class IllustrationModel
    {
        public int IllustrationID { get; set; }
        public System.Xml.XmlDocument? Diagram { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
