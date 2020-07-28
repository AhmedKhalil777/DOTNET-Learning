using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database;
using GraphQL.Sample.Database.Model;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Sample.DataAccess.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateDbContext _db;
        public PropertyRepository(RealEstateDbContext  db)
        {
            _db = db;
        }

        public Property AddProperty(Property property)
        {
            _db.Properties.Add(property);
            _db.SaveChanges();
            return property;
        }

        public IEnumerable<Property> GetAll() => _db.Properties;

        public Property GetProperty(int PropertyId) => _db.Properties.FirstOrDefault(x => x.Id == PropertyId);
    }
}
