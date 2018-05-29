using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UUIDMaster.Models;
using UUIDMaster.Models.Repository.Invoice;

namespace UUIDMaster.Controllers
{
    [Produces("application/json")]
    [Route("api/invoice")]
    public class InvoiceUUIDController : Controller
    {
        private readonly IInvoiceUUIDRecordRepository repository;

        public InvoiceUUIDController(IInvoiceUUIDRecordRepository repository)
        {
            this.repository = repository;
        }

        //POST api/invoice/uuid
        [HttpPost("uuid")]
        [ProducesResponseType(201, Type = typeof(UUIDResponseObject))]
        [ProducesResponseType(400)]
        public IActionResult GenerateUUID([FromBody]InvoiceUUIDRequestObject requestObject)
        {
            if (requestObject == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var reservationUUID = requestObject.ReservationUUID;
                //check if reservation already exists in database
                //and create a new Guid if necessary
                string guid;
                var record = repository.GetByReservationUUID(reservationUUID);
                if (record == null)
                {
                    guid = Guid.NewGuid().ToString();
                    //create a new record
                    var newRecord = new InvoiceUUIDRecord()
                    {
                        UUID = guid,
                        ReservationUUID = reservationUUID
                    };
                    repository.Add(newRecord);
                }
                else
                {
                    guid = record.UUID;
                }

                var responseObject = new UUIDResponseObject() { UUID = guid };
                return Ok(responseObject);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}