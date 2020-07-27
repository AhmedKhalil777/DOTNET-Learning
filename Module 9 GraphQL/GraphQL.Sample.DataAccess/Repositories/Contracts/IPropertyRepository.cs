using GraphQL.Sample.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.DataAccess.Repositories.Contracts
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
    }
}
