using Bogus;
using Learning.OData.Models;
using Learning.OData.Persistence;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>();
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Order>();
modelBuilder.EntityType<Resource>();
modelBuilder.EntitySet<Customer>("Customers");
modelBuilder.EntitySet<Catalog>("Catalogs");

builder.Services.AddControllers().AddOData(o =>
            o.Select().Filter().OrderBy()
            .Expand().Count().SetMaxTop(null).AddRouteComponents("odata", modelBuilder.GetEdmModel()));
var app = builder.Build();
app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.MapControllers();


var scope = builder.Services.BuildServiceProvider().CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

if (dbContext.Database.EnsureCreated())
{
    var catalogFaker = new Faker<Catalog>()
        .RuleFor(x => x.Name, x => x.Commerce.ProductName())
        .RuleFor(x => x.Price, x => x.Commerce.Price())
        .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
        .RuleFor(x => x.StockCount, x => x.Random.Int(0, 100))
        .RuleFor(x => x.Images, x => Enumerable.Range(0, x.Random.Int(1, 10)).Select(y => new Resource
        {
            Path = x.Image.PlaceImgUrl()
            
        }).ToList());

    var catalogs = catalogFaker.Generate(200);

    dbContext.AddRangeAsync(catalogs).Wait();
    dbContext.SaveChanges();
}


app.Run();
