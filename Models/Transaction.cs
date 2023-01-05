using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassroomStart.Models
{
    [Table("transactions")]
    [Index("CustomerId", Name = "Customer ID")]
    [Index("ProductCategoryId", Name = "Product Category ID1")]
    [Index("ProductNameId", Name = "Product Name ID")]
    public partial class Transaction
    {
        public Transaction()
        {
            // default constructor
        }

        public Transaction(int iCustomerID, int iProductID, int iProductCategory, int iQtyOrder, 
            decimal dPrice, decimal dTotalPrice)
        {
            CustomerId = iCustomerID;
            ProductNameId = iProductID;
            ProductCategoryId = iProductCategory;
            QuantityOrdered = iQtyOrder;
            IndividualPrice = dPrice;
            TotalPrice = dTotalPrice;
        }

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("Customer ID", TypeName = "int(11)")]
        public int CustomerId { get; set; }
        [Column("Product Category ID", TypeName = "int(11)")]
        public int ProductCategoryId { get; set; }
        [Column("Product Name ID", TypeName = "int(11)")]
        public int ProductNameId { get; set; }
        [Column("Time/Date of Order", TypeName = "datetime")]
        public DateTime TimeDateOfOrder { get; set; }
        [Column("Quantity Ordered", TypeName = "int(11)")]
        public int QuantityOrdered { get; set; }
        [Column("Individual Price")]
        [Precision(10, 2)]
        public decimal IndividualPrice { get; set; }
        [Column("Extended Price")]
        [Precision(10, 2)]
        public decimal ExtendedPrice { get; set; }
        [Column("Total Price")]
        [Precision(10, 2)]
        public decimal TotalPrice { get; set; }









        [ForeignKey("CustomerId")]
        [InverseProperty("Transactions")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey("ProductCategoryId")]
        [InverseProperty("Transactions")]
        public virtual ProductCategory ProductCategory { get; set; } = null!;
        [ForeignKey("ProductNameId")]
        [InverseProperty("Transactions")]
        public virtual Product ProductName { get; set; } = null!;
    }
}
