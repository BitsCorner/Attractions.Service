using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository.Models
{
    public class ListingVideo
    {
        [Key]
        public int ListingVideoId { get; set; }
        public string YouTubeUri { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Locale Locale { get; set; }
        public bool IsDefault { get; set; }
    }
}
