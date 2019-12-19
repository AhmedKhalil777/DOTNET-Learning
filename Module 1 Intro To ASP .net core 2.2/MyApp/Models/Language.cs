using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("language")]
    public partial class Language
    {
        public Language()
        {
            FilmLanguage = new HashSet<Film>();
            FilmOriginalLanguage = new HashSet<Film>();
        }

        [Column("language_id")]
        public byte LanguageId { get; set; }
        [Required]
        [Column("name", TypeName = "char(20)")]
        public string Name { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTime LastUpdate { get; set; }

        [InverseProperty("Language")]
        public virtual ICollection<Film> FilmLanguage { get; set; }
        [InverseProperty("OriginalLanguage")]
        public virtual ICollection<Film> FilmOriginalLanguage { get; set; }
    }
}
