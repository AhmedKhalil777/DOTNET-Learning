using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company1.Data;
using Company1.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _dataContext;
        public EmployeeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateEmpAsync(Employee emp)
        {
             await _dataContext.employees.AddAsync(emp);
            var Created = await _dataContext.SaveChangesAsync();
            return Created > 0;
        }



        public async Task<bool> DeleteEmpAsync(Guid Id)
        {
            
           _dataContext.employees.Remove(  await GetEmployeeAsync(Id));
             var  x = await  _dataContext.SaveChangesAsync();
            return x>0 ;
        }

        public async Task<bool> EmpToUpdateAsync(Employee emp)
        {
          
           _dataContext.employees.Update(emp);
          var x = await _dataContext.SaveChangesAsync();
            return x>0;
        }


        public async Task<Employee> GetEmployeeAsync(Guid Id)
        {
            return await _dataContext.employees.SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _dataContext.employees.ToListAsync();
        }
    }
}
