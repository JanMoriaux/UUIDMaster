using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UUIDMaster.Validation;

namespace UUIDMaster.Models
{
    public class ReservationUUIDRequestObject
    {
        [Required]
        [GUIDValidationAttribute(ErrorMessage = "{0} is not a valid UUID")]
        public string ActivityUUID { get; set; }
        [Required]
        [GUIDValidationAttribute(ErrorMessage = "{0} is not a valid UUID")]
        public string UserUUID { get; set; }
    }
}
