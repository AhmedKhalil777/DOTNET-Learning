using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database;
using GraphQL.Sample.Database.Model;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Sample.DataAccess.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly RealEstateDbContext _db;
        public PaymentRepository(RealEstateDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Payment> GetAllPaymentsProperty(int PropertyID) => _db.Payments.Where(x => x.PropertyId == PropertyID).ToList();

        public IEnumerable<Payment> GetAllPaymentsProperty(int PropertyID, int LastPayments) => _db.Payments
            .Where(x => x.PropertyId == PropertyID)
            .OrderByDescending(x => x.IssueDate)
            .Take(LastPayments)
            .ToList();
    }
}
