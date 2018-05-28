using System;
using Microsoft.AspNetCore.Mvc;
using UUIDMaster.Models;
using UUIDMaster.Models.Repository;


namespace UUIDMaster.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserUUIDController : Controller
    {
        private readonly IUserUUIDRecordRepository _manager;

        public UserUUIDController(IUserUUIDRecordRepository manager)
        {
            _manager = manager;
        }

        //POST api/user/uuid
        [HttpPost("uuid")]
        [ProducesResponseType(201, Type=typeof(UUIDResponseObject))]
        [ProducesResponseType(400)]
        public IActionResult GenerateUUID([FromBody]UserUUIDRequestObject requestObject)
        {
            if(requestObject == null)
            {
                return BadRequest();
            }
            
            if (ModelState.IsValid)
            {
                var email = requestObject.Email;
                //check if email already exists in database
                //and create a new Guid if necessary
                string guid;
                var record = _manager.GetByEmail(email);
                if (record == null)
                {
                    guid = Guid.NewGuid().ToString();
                    //create a new record
                    var newRecord = new UserUUIDRecord()
                    {
                        Email = email,
                        UUID = guid
                    };
                    _manager.Add(newRecord);
                }
                else
                {
                    guid = record.UUID;
                }

                var responseObject = new UUIDResponseObject() { UUID = guid};
                return Ok(responseObject);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}