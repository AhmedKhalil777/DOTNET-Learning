using GraphQL.Sample.Database.Model;
using System.Collections.Generic;

namespace GraphQL.Sample.DataAccess.Repositories.Contracts
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPaymentsProperty(int PropertyID);
        IEnumerable<Payment> GetAllPaymentsProperty(int PropertyID, int LastPayments);

    }
}
