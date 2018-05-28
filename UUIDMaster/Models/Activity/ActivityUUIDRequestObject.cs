using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UUIDMaster.Validation;

namespace UUIDMaster.Models
{
    public class ActivityUUIDRequestObject
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [GUIDValidationAttribute(ErrorMessage =  "{0} is not a valid UUID")]
        public string EventUUID { get; set; }
    }
}
