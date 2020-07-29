using GraphQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Graph.Utilities
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public Inputs Variables { get; set; }
    }
}
