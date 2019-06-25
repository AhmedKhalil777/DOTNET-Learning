using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("film_text")]
    public partial class FilmText
    {
        [Column("film_id", TypeName = "smallint(6)")]
        public short FilmId { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column("description", TypeName = "text")]
        public string Description { get; set; }
    }
}
