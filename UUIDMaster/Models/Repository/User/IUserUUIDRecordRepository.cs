using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository
{
    public interface IUserUUIDRecordRepository
    {
        //IEnumerable<UserUUIDRecord> GetAll();
        UserUUIDRecord GetByEmail(string email);
        long Add(UserUUIDRecord uur);
    }
}
