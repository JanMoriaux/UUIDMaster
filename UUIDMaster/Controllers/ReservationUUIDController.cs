using System;
using Microsoft.AspNetCore.Mvc;
using UUIDMaster.Models;
using UUIDMaster.Models.Repository;


namespace UUIDMaster.Controllers
{
    [Produces("application/json")]
    [Route("api/reservation")]
    public class ReservationUUIDController : Controller
    {
        private readonly IReservationUUIDRecordRepository _manager;

        public ReservationUUIDController(IReservationUUIDRecordRepository manager)
        {
            _manager = manager;
        }

        //POST api/event/uuid
        [HttpPost("uuid")]
        [ProducesResponseType(201, Type=typeof(UUIDResponseObject))]
        [ProducesResponseType(400)]
        public IActionResult GenerateUUID([FromBody]ReservationUUIDRequestObject requestObject)
        {
            if(requestObject == null)
            {
                return BadRequest();
            }
            
            if (ModelState.IsValid)
            {
                var activityUUID = requestObject.ActivityUUID;
                var userUUID = requestObject.UserUUID;
                //check if name already exists in database
                //and create a new Guid if necessary
                string guid;
                var record = _manager.GetByActivityUUIDAndUserUUID(activityUUID,userUUID);
                if (record == null)
                {
                    guid = Guid.NewGuid().ToString();
                    //create a new record
                    var newRecord = new ReservationUUIDRecord()
                    {
                        UUID = guid,
                        ActivityUUID = activityUUID,
                        UserUUID = userUUID
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