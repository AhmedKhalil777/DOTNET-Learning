using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("payment")]
    public partial class Payment
    {
        [Column("payment_id")]
        public ushort PaymentId { get; set; }
        [Column("customer_id")]
        public ushort CustomerId { get; set; }
        [Column("staff_id")]
        public byte StaffId { get; set; }
        [Column("rental_id", TypeName = "int(11)")]
        public int? RentalId { get; set; }
        [Column("amount", TypeName = "decimal(5,2)")]
        public decimal Amount { get; set; }
        [Column("payment_date", TypeName = "datetime")]
        public DateTime PaymentDate { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTime? LastUpdate { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Payment")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("RentalId")]
        [InverseProperty("Payment")]
        public virtual Rental Rental { get; set; }
        [ForeignKey("StaffId")]
        [InverseProperty("Payment")]
        public virtual Staff Staff { get; set; }
    }
}
