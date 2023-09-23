using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("PlaylistTrack")]
    public class PlaylistTrack
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        public int PlaylistId { get; set; }
        [Key]
        [Required]
        [Column(Order = 2)]
        public int TrackId { get; set; }

    }
}
