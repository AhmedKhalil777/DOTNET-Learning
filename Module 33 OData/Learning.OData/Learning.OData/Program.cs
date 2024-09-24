using Learning.OData.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Order>();
modelBuilder.EntitySet<Customer>("Customers");
builder.Services.AddControllers().AddOData(o =>
            o.Select().Filter().OrderBy()
            .Expand().Count().SetMaxTop(null).AddRouteComponents("odata", modelBuilder.GetEdmModel()));
var app = builder.Build();
app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
