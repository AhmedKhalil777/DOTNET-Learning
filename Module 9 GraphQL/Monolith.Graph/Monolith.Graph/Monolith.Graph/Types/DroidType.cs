using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.Graph.Types
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType()
        {
            Field(x => x.Id).Description("The Id of the Droid.");
            Field(x => x.Name, nullable: true).Description("The name of the Droid.");
        }
    }

    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            // Field(x => x.FirstName).Resolve((x) => {
            //     return "Hello!";
            // }).Description("Perso's First Name");

            Field(x => x.Id).Description("Peron's Id");
            Field(x => x.Name).Description("Person's name");
            Field(x => x.Age).Resolve(x => {
                return 25;
            }).Description("A person's age");
        }
    }
}
