using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("customer")]
    public partial class Customer
    {
        public Customer()
        {
            Payment = new HashSet<Payment>();
            Rental = new HashSet<Rental>();
        }

        [Column("customer_id")]
        public ushort CustomerId { get; set; }
        [Column("store_id")]
        public byte StoreId { get; set; }
        [Required]
        [Column("first_name", TypeName = "varchar(45)")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name", TypeName = "varchar(45)")]
        public string LastName { get; set; }
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column("address_id")]
        public ushort AddressId { get; set; }
        [Column("active", TypeName = "tinyint(1)")]
        public sbyte Active { get; set; }
        [Column("create_date", TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTime? LastUpdate { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Customer")]
        public virtual Address Address { get; set; }
        [ForeignKey("StoreId")]
        [InverseProperty("Customer")]
        public virtual Store Store { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Payment> Payment { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Rental> Rental { get; set; }
    }
}
