using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("film")]
    public partial class Film
    {
        public Film()
        {
            FilmActor = new HashSet<FilmActor>();
            FilmCategory = new HashSet<FilmCategory>();
            Inventory = new HashSet<Inventory>();
        }

        [Column("film_id")]
        public ushort FilmId { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column("description", TypeName = "text")]
        public string Description { get; set; }
        [Column("language_id")]
        public byte LanguageId { get; set; }
        [Column("original_language_id")]
        public byte? OriginalLanguageId { get; set; }
        [Column("rental_duration")]
        public byte RentalDuration { get; set; }
        [Column("rental_rate", TypeName = "decimal(4,2)")]
        public decimal RentalRate { get; set; }
        [Column("length")]
        public ushort? Length { get; set; }
        [Column("replacement_cost", TypeName = "decimal(5,2)")]
        public decimal ReplacementCost { get; set; }
        [Column("rating", TypeName = "enum('G','PG','PG-13','R','NC-17')")]
        public string Rating { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey("LanguageId")]
        [InverseProperty("FilmLanguage")]
        public virtual Language Language { get; set; }
        [ForeignKey("OriginalLanguageId")]
        [InverseProperty("FilmOriginalLanguage")]
        public virtual Language OriginalLanguage { get; set; }
        [InverseProperty("Film")]
        public virtual ICollection<FilmActor> FilmActor { get; set; }
        [InverseProperty("Film")]
        public virtual ICollection<FilmCategory> FilmCategory { get; set; }
        [InverseProperty("Film")]
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
