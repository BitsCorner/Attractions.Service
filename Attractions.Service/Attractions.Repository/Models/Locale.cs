using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository.Models
{
    public class Locale
    {
        [Key]
        public int LocaleId { get; set; }
        public string LocaleName { get; set; }
    }
}
