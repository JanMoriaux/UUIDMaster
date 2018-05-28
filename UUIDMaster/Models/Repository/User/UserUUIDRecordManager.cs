using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository
{
    public class UserUUIDRecordManager : IUserUUIDRecordRepository
    {
        UUIDContext _ctx;

        public UserUUIDRecordManager(UUIDContext ctx)
        {
            _ctx = ctx;
        }

        public long Add(UserUUIDRecord uur)
        {
            _ctx.UserRecords.Add(uur);
            long id = _ctx.SaveChanges();
            return id;
        }

        //public IEnumerable<UserUUIDRecord> GetAll()
        //{
        //    var records = _ctx.UserRecords.ToList();
        //    return records;
        //}

        public UserUUIDRecord GetByEmail(string email)
        {
            var record = _ctx.UserRecords.FirstOrDefault(r => r.Email.ToLower() == email.ToLower());
            return record;
        }
    }
}
