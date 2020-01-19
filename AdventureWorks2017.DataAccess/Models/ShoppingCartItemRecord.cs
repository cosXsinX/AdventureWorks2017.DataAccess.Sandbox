using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ShoppingCartItemModelPrimaryKey
    {
        public int ShoppingCartItemID { get; set; }

    }

    public class ShoppingCartItemModel
    {
        public int ShoppingCartItemID { get; set; }
        public string ShoppingCartID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
