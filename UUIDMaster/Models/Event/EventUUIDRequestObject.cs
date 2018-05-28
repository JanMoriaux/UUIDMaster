using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models
{
    public class EventUUIDRequestObject
    {
        [Required]
        public string Name { get; set; }
    }
}
