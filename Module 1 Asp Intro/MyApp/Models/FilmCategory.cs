using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("film_category")]
    public partial class FilmCategory
    {
        [Column("film_id")]
        public ushort FilmId { get; set; }
        [Column("category_id")]
        public byte CategoryId { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("FilmCategory")]
        public virtual Category Category { get; set; }
        [ForeignKey("FilmId")]
        [InverseProperty("FilmCategory")]
        public virtual Film Film { get; set; }
    }
}
