using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository
{
    public class ActivityUUIDRecordManager : IActivityUUIDRecordRepository
    {
        UUIDContext _ctx;

        public ActivityUUIDRecordManager(UUIDContext ctx)
        {
            _ctx = ctx;
        }

        public long Add(ActivityUUIDRecord aur)
        {
            _ctx.ActivityRecords.Add(aur);
            long id = _ctx.SaveChanges();
            return id;
        }

        public ActivityUUIDRecord GetByNameAndEventUUID(string name, string eventUUID)
        {
            var record = _ctx.ActivityRecords.FirstOrDefault(r => r.Name.ToLower() == name.ToLower() && r.EventUUID.ToLower() == eventUUID.ToLower());
            return record;
        }
    }
}
