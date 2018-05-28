using System;
using Microsoft.AspNetCore.Mvc;
using UUIDMaster.Models;
using UUIDMaster.Models.Repository;


namespace UUIDMaster.Controllers
{
    [Produces("application/json")]
    [Route("api/event")]
    public class EventUUIDController : Controller
    {
        private readonly IEventUUIDRecordRepository _manager;

        public EventUUIDController(IEventUUIDRecordRepository manager)
        {
            _manager = manager;
        }

        //POST api/event/uuid
        [HttpPost("uuid")]
        [ProducesResponseType(201, Type=typeof(UUIDResponseObject))]
        [ProducesResponseType(400)]
        public IActionResult GenerateUUID([FromBody]EventUUIDRequestObject requestObject)
        {
            if(requestObject == null)
            {
                return BadRequest();
            }
            
            if (ModelState.IsValid)
            {
                var name = requestObject.Name;
                //check if name already exists in database
                //and create a new Guid if necessary
                string guid;
                var record = _manager.GetByName(name);
                if (record == null)
                {
                    guid = Guid.NewGuid().ToString();
                    //create a new record
                    var newRecord = new EventUUIDRecord()
                    {
                        Name = name,
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