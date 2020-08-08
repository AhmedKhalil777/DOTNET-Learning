using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IEnumerableIQueriable.Demo.Data
{
    public class EmployeesDbContextFactory : IDesignTimeDbContextFactory<EmployeesDbContext>
    {
        public EmployeesDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EmployeesDbContext>();
            builder.UseSqlServer("Data Source=DESKTOP-KVVKP5M\\AHMED;Initial Catalog=Employee;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new EmployeesDbContext(builder.Options);
        }
    }
}
