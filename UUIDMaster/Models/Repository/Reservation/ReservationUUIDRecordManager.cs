using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository
{
    public class ReservationUUIDRecordManager : IReservationUUIDRecordRepository
    {
        UUIDContext _ctx;

        public ReservationUUIDRecordManager(UUIDContext ctx)
        {
            _ctx = ctx;
        }


        public long Add(ReservationUUIDRecord rur)
        {
            _ctx.ReservationRecords.Add(rur);
            long id = _ctx.SaveChanges();
            return id;
        }

        public ReservationUUIDRecord GetByActivityUUIDAndUserUUID(string activityUUID, string userUUID)
        {
            var record = _ctx.ReservationRecords.FirstOrDefault(r => r.ActivityUUID.ToLower() == activityUUID.ToLower() && r.UserUUID.ToLower() == userUUID.ToLower());
            return record;
        }
    }
}
