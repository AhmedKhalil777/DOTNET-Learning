using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("city")]
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        [Column("city_id")]
        public ushort CityId { get; set; }
        [Required]
        [Column("city", TypeName = "varchar(50)")]
        public string City1 { get; set; }
        [Column("country_id")]
        public ushort CountryId { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey("CountryId")]
        [InverseProperty("City")]
        public virtual Country Country { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Address> Address { get; set; }
    }
}
