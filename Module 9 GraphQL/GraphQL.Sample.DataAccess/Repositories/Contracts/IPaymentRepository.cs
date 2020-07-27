using GraphQL.Sample.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.DataAccess.Repositories.Contracts
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPaymentsProperty(int PropertyID);
        IEnumerable<Payment> GetAllPaymentsProperty(int PropertyID, int LastPayments);

    }
}
