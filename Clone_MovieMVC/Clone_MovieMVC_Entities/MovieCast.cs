using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clone_MovieMVC_Entities
{
    [Table("MovieCast")]
    public class MovieCast
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CastId { get; set; }
        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Character { get; set; }
        public Movie Movie { get; set; }//navigation property
        public Cast Cast { get; set; }
    }
}
