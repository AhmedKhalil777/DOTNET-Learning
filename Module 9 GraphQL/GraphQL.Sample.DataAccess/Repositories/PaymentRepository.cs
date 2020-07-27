using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database.Model;
using System.Collections.Generic;

namespace GraphQL.Sample.DataAccess.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public IEnumerable<Payment> GetAllPayments()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Payment> GetAllPaymentsOfProperty(int PropertyID, int LastPayments)
        {
            throw new System.NotImplementedException();
        }
    }
}
