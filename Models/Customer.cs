using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassroomStart.Models
{
    [Table("customer")]
    public partial class Customer
    {
        public Customer()
        {
            Transactions = new HashSet<Transaction>();
        }
        public Customer(string sFirstName, string sLastName, string sPhoneNumber, string sAddress)
        {
            NameFirst = sFirstName;
            NameLast = sLastName;
            PhoneNumber = sPhoneNumber;
            Address = sAddress;
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("Name(First)")]
        [StringLength(15)]
        public string NameFirst { get; set; } = null!;
        [Column("Name(Last)")]
        [StringLength(30)]
        public string NameLast { get; set; } = null!;
        [StringLength(14)]
        public string PhoneNumber { get; set; } = null!;
        [StringLength(50)]
        public string Address { get; set; } = null!;




        [InverseProperty("Customer")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
