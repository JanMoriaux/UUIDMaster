using System;
using Microsoft.AspNetCore.Mvc;
using UUIDMaster.Models;
using UUIDMaster.Models.Repository;


namespace UUIDMaster.Controllers
{
    [Produces("application/json")]
    [Route("api/activity")]
    public class ActivityUUIDController : Controller
    {
        private readonly IActivityUUIDRecordRepository _manager;

        public ActivityUUIDController(IActivityUUIDRecordRepository manager)
        {
            _manager = manager;
        }

        //POST api/event/uuid
        [HttpPost("uuid")]
        [ProducesResponseType(201, Type=typeof(UUIDResponseObject))]
        [ProducesResponseType(400)]
        public IActionResult GenerateUUID([FromBody]ActivityUUIDRequestObject requestObject)
        {
            if(requestObject == null)
            {
                return BadRequest();
            }
            
            if (ModelState.IsValid)
            {
                var name = requestObject.Name;
                var eventUUID = requestObject.EventUUID;
                //check if name already exists in database
                //and create a new Guid if necessary
                string guid;
                var record = _manager.GetByNameAndEventUUID(name,eventUUID);
                if (record == null)
                {
                    guid = Guid.NewGuid().ToString();
                    //create a new record
                    var newRecord = new ActivityUUIDRecord()
                    {
                        Name = name,
                        UUID = guid,
                        EventUUID = eventUUID
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