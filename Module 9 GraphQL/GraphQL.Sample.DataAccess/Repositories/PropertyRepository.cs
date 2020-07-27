using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database;
using GraphQL.Sample.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.DataAccess.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateDbContext _db;
        public PropertyRepository(RealEstateDbContext  db)
        {
            _db = db;
        }
        public IEnumerable<Property> GetAll() => _db.Properties;
       
    }
}
