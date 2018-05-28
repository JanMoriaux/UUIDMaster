using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository
{
    public interface IActivityUUIDRecordRepository
    {
        ActivityUUIDRecord GetByNameAndEventUUID(string name,string eventUUID);
        long Add(ActivityUUIDRecord eur);
    }
}
