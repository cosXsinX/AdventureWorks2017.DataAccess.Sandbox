using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct CultureModelPrimaryKey
    {
        public string CultureID { get; set; }

    }

    public class CultureModel
    {
        public string CultureID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
