﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository.Invoice
{
    public interface IInvoiceUUIDRecordRepository
    {
        InvoiceUUIDRecord GetByReservationUUID(string reservationUUID);
        long Add(InvoiceUUIDRecord invoiceUUIDRecord);
    }
}
