using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clone_MovieMVC_Entities
{
    [Table("Movie")]
    public class Movie
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "This column should not be empty!!")]
        [StringLength(256)]
        public string Title { get; set; }
        public string Overview { get; set; }
        [StringLength(512)]
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        [StringLength(2084)]
        public string ImdbUrl { get; set; }
        [StringLength(2084)]
        public string TmdbUrl { get; set; }
        [StringLength(2084)]
        public string PosterUrl { get; set; }
        [StringLength(2084)]
        public string BackdropUrl { get; set; }
        [StringLength(64)]
        public string OriginalLanguage { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]

        //[JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        //[JsonIgnore]
        public string CreatedBy { get; set; }
        //[JsonIgnore]
        public ICollection<Genre> Genres { get; set; }
        //[JsonIgnore]
        public ICollection<Review> Reviews { get; set; }
        //[JsonIgnore]
        public ICollection<MovieCast> MovieCasts { get; set; }
        //[JsonIgnore]
        public ICollection<MovieCrew> MovieCrews { get; set; }
        //[JsonIgnore]
        public ICollection<Favorite> Favorites { get; set; }
        //[JsonIgnore]
        public ICollection<Purchase> Purchases { get; set; }

        [NotMapped]
        public decimal? AvgRating { get; set; }
        [NotMapped]
        public decimal? AvgPurchase { get; set; }

        
    }
}
