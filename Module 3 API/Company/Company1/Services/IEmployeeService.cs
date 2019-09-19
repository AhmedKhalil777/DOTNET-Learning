using Company1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Company1.Services
{
   public interface IEmployeeService
    {
         Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(Guid Id);

        Task<bool> EmpToUpdateAsync(Employee emp);
        Task<bool> DeleteEmpAsync(Guid Id);
        Task<bool> CreateEmpAsync(Employee emp);

    }
}
