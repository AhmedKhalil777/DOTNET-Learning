using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    [Table("film_actor")]
    public partial class FilmActor
    {
        [Column("actor_id")]
        public ushort ActorId { get; set; }
        [Column("film_id")]
        public ushort FilmId { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey("ActorId")]
        [InverseProperty("FilmActor")]
        public virtual Actor Actor { get; set; }
        [ForeignKey("FilmId")]
        [InverseProperty("FilmActor")]
        public virtual Film Film { get; set; }
    }
}
