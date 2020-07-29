using BookStore.Graph.API.Queries;
using BookStore.Graph.API.Schemas;
using BookStore.Graph.DataAccess.Repositories;
using BookStore.Graph.DataAccess.Repositories.Contracts;
using BookStore.Graph.Types.QueryTypes;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Graph.API.Installers
{
    public class RepositoriesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPostService, PostService>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddScoped<BookStoreQuery>();
            services.AddScoped<PostType>();
            services.AddScoped<CommentType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new BookStoreSchema(new FuncDependencyResolver(type => sp.GetService(type))));

        }
    }
}
