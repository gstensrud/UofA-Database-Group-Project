using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassroomStart.Models
{
    [Table("product category")]
    public partial class ProductCategory
    {

        public ProductCategory()
        {
            Products = new HashSet<Product>();
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("Category Name")]
        [StringLength(15)]
        public string CategoryName { get; set; } = null!;

        [InverseProperty("ProductCategory")]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty("ProductCategory")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
