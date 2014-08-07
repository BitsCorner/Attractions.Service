using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int LocaleId { get; set; }
        public State State { get; set; }
    }
}
