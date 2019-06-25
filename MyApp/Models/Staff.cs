using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("staff")]
    public partial class Staff
    {
        public Staff()
        {
            Payment = new HashSet<Payment>();
            Rental = new HashSet<Rental>();
        }

        [Column("staff_id")]
        public byte StaffId { get; set; }
        [Required]
        [Column("first_name", TypeName = "varchar(45)")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name", TypeName = "varchar(45)")]
        public string LastName { get; set; }
        [Column("address_id")]
        public ushort AddressId { get; set; }
        [Column("picture", TypeName = "blob")]
        public byte[] Picture { get; set; }
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column("store_id")]
        public byte StoreId { get; set; }
        [Column("active", TypeName = "tinyint(1)")]
        public sbyte Active { get; set; }
        [Required]
        [Column("username", TypeName = "varchar(16)")]
        public string Username { get; set; }
        [Column("password", TypeName = "varchar(40)")]
        public string Password { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Staff")]
        public virtual Address Address { get; set; }
        [ForeignKey("StoreId")]
        [InverseProperty("Staff")]
        public virtual Store Store { get; set; }
        [InverseProperty("ManagerStaff")]
        public virtual Store StoreNavigation { get; set; }
        [InverseProperty("Staff")]
        public virtual ICollection<Payment> Payment { get; set; }
        [InverseProperty("Staff")]
        public virtual ICollection<Rental> Rental { get; set; }
    }
}
