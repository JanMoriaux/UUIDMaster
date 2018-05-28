using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models
{
    public class ReservationUUIDRecord: BaseUUIDRecord
    {
        public string ActivityUUID { get; set; }
        public string UserUUID { get; set; }
    }
}
