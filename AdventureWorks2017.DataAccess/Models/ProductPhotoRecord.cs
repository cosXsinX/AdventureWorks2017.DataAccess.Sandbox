using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductPhotoModelPrimaryKey
    {
        public int ProductPhotoID { get; set; }

    }

    public class ProductPhotoModel
    {
        public int ProductPhotoID { get; set; }
        public byte[]? ThumbNailPhoto { get; set; }
        public string? ThumbnailPhotoFileName { get; set; }
        public byte[]? LargePhoto { get; set; }
        public string? LargePhotoFileName { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
