using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository
{
    public class EventUUIDRecordManager : IEventUUIDRecordRepository
    {
        UUIDContext _ctx;

        public EventUUIDRecordManager(UUIDContext ctx)
        {
            _ctx = ctx;
        }

        public long Add(EventUUIDRecord eur)
        {
            _ctx.EventRecords.Add(eur);
            long id = _ctx.SaveChanges();
            return id;
        }

        public EventUUIDRecord GetByName(string name)
        {
            var record = _ctx.EventRecords.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
            return record;
        }
    }
}
