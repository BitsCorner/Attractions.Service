using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository.Models
{
    public class UsageType
    {
        [Key]
        public int UsageTypeId { get; set; }
        public string UsageTypeName { get; set; }
    }
}
