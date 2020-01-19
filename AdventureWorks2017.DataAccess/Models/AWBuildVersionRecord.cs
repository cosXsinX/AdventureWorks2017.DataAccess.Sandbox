using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct AWBuildVersionModelPrimaryKey
    {
        public byte SystemInformationID { get; set; }

    }

    public class AWBuildVersionModel
    {
        public byte SystemInformationID { get; set; }
        public string DatabaseVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
