using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models.Repository.Invoice
{
    public class InvoiceUUIDRecordRepository : IInvoiceUUIDRecordRepository
    {
        private UUIDContext context;

        public InvoiceUUIDRecordRepository(UUIDContext context)
        {
            this.context = context;
        }

        public long Add(InvoiceUUIDRecord invoiceUUIDRecord)
        {
            context.InvoiceRecords.Add(invoiceUUIDRecord);
            long id = context.SaveChanges();
            return id;
        }

        public InvoiceUUIDRecord GetByReservationUUID(string reservationUUID)
        {
            var record = context.InvoiceRecords.FirstOrDefault(x => x.ReservationUUID == reservationUUID);
            return record;
        }
    }
}
