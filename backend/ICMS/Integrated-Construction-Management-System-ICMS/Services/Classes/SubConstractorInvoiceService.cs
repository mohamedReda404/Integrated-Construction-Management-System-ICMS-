using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class SubConstractorInvoiceService
        :GenericService<SubContractor>, ISubConstractorInvoiceService
    {
        public SubConstractorInvoiceService(DbContext context)
            : base(context)
        {
        }
    }
}
