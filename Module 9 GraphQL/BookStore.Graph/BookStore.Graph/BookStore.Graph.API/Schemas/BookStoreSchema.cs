using BookStore.Graph.API.Queries;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Graph.API.Schemas
{
    public class BookStoreSchema : GraphQL.Types.Schema
    {
        public BookStoreSchema(IDependencyResolver resolver)
          : base(resolver)
        {
            Query = resolver.Resolve<BookStoreQuery>();
        }
    }

}

