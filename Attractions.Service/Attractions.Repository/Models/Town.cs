using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository.Models
{
    public class Town
    {
        public int TownId { get; set; }
        public string TownName { get; set; }
        public int LocaleId { get; set; }
        public City City { get; set; }
    }
}
