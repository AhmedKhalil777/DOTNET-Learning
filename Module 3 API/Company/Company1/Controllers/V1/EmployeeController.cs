using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company1.Contracts.V1;
using Company1.Contracts.V1.Requests;
using Company1.Contracts.V1.Responses;
using Company1.Domain;
using Company1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company1.Controllers.v1
{

    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private   IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #region Getall 
        [HttpGet(ApiRoutes.Employee.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await _employeeService.GetEmployeesAsync());
        }
        #endregion


        #region Get
        [HttpGet(ApiRoutes.Employee.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {
            var employee =await _employeeService.GetEmployeeAsync(Id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        #endregion

        #region Update
        [HttpPut(ApiRoutes.Employee.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid Id ,[FromBody] UpdateEmp updateEmp )
        {
            var newEmp = new Employee { Id = Id, Name = updateEmp.Name };
            var TrueTransaction=_employeeService.EmpToUpdateAsync(newEmp);
            if ( await TrueTransaction)
                return Ok(newEmp);

            return NotFound();
        }
        #endregion

        #region Create
        [HttpPost(ApiRoutes.Employee.Create)]
        public async Task<IActionResult> Create([FromBody] CreateAnEmployee RequestedEmployee)
        {
            var employee = new Employee {   Name = RequestedEmployee .Name};
            if (string.IsNullOrEmpty(employee.Id.ToString()))
            {
                employee.Id = Guid.NewGuid();
            }
              await _employeeService.CreateEmpAsync(employee);
            
            var Location = $"{HttpContext.Request.Scheme} :// {HttpContext.Request.Host.ToUriComponent()} " +
                $"/ {ApiRoutes.Employee.Get.Replace("{EmpId}" , employee.Id.ToString())}";

            return Created(Location , employee);
        }
        #endregion

        #region Delete

        [HttpDelete(ApiRoutes.Employee.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid Id)
        {
            var IsDeleted=_employeeService.DeleteEmpAsync(Id);
            if (await IsDeleted)
                return NoContent();
            return NotFound();
        }
        #endregion
    }
}