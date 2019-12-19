using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("country")]
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        [Column("country_id")]
        public ushort CountryId { get; set; }
        [Required]
        [Column("country", TypeName = "varchar(50)")]
        public string Country1 { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTime LastUpdate { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<City> City { get; set; }
    }
}
