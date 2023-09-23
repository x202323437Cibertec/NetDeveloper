using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlaylistTrackVM
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
        public string Name { get; set; }
        public string Composer { get; set; }
        public int Duration { get; set; }
    }
}
