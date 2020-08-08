using GraphQL.Sample.Database.Model;
using System.Collections.Generic;

namespace GraphQL.Sample.DataAccess.Repositories.Contracts
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        Property GetProperty(int PropertyId);

        Property AddProperty(Property property);
    }
}
