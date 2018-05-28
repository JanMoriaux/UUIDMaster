using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository
{
    public interface IEventUUIDRecordRepository
    {
        EventUUIDRecord GetByName(string name);
        long Add(EventUUIDRecord eur);
    }
}
