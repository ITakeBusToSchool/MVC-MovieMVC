using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clone_MovieMVC_Entities
{
    [Table("Crew")]
    public class Crew
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        [Required]
        [StringLength(2084)]
        public string ProfilePath { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
