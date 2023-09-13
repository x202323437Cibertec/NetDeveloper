using Models;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        IEnumerable<CustomerInvoice> Customerinvoice(int pInvoiceId, string pCustomerEmail);
    }
}
