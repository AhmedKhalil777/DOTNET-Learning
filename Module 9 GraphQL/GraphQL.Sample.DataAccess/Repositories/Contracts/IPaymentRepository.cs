using GraphQL.Sample.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.DataAccess.Repositories.Contracts
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPayments();
        IEnumerable<Payment> GetAllPaymentsOfProperty(int PropertyID, int LastPayments);

    }
}
