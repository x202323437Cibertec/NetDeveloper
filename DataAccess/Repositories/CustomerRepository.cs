using Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ChinookContext pContext) : base(pContext)
        {

        }

        public IEnumerable<CustomerInvoice> Customerinvoice(int pInvoiceId, string pCustomerEmail)
        {
            var oSqlParInvoiceId = new SqlParameter("@PI_InvoiceId", pInvoiceId);
            var oSqlParEmail = new SqlParameter("@PI_Email", pCustomerEmail);
            return chinookContext.Database.SqlQuery<CustomerInvoice>("dbo.CustomerInvoice @PI_InvoiceId, @PI_Email", oSqlParInvoiceId, oSqlParEmail);
        }

        public ChinookContext chinookContext
        {
            get { return Context as ChinookContext; }
        }
    }
}
