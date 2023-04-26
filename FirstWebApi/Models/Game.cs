using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebApi.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [NotMapped]
        public ICollection<Review> Reviews { get; set; }
        
    }
}
