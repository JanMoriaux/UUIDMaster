using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models
{
    public class ActivityUUIDRecord: BaseUUIDRecord
    {
        public string Name{ get; set; }
        public string EventUUID { get; set; }
    }
}
