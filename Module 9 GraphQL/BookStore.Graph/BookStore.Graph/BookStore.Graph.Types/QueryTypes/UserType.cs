using BookStore.Graph.Database.Domain;
using BookStore.Graph.Database.Domain.Contracts;
using GraphQL.Types;


namespace BookStore.Graph.Types.QueryTypes
{
    public class UserType : ObjectGraphType<AppGraphUser>
    {
        public UserType()
        {
            //Field<StringGraphType>("Id",
            //    resolve: context => context.Source.Id.ToString()
            //    );
            Field(x => x.UserName).Description("Username");
            //Field(x => x.Email);
            //Field(x => x.Image);
            //Field(x => x.PhoneNumber);
            //Field(x => x.City);
            //Field(x => x.street);
        }
    }
}
