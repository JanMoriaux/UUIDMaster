using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository
{
    public interface IReservationUUIDRecordRepository
    {
        ReservationUUIDRecord GetByActivityUUIDAndUserUUID(string activityUUID, string userUUID);
        long Add(ReservationUUIDRecord rur);
    }
}
