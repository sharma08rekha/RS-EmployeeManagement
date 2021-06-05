using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.ValidationFilters;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _iEmployeeService;

        /// <summary>
        /// Employee service constructor dependancy injection 
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeeController(IEmployeeService employeeService)
        {
            _iEmployeeService = employeeService;
        }

        /// <summary>
        /// Post employee
        /// </summary>
        /// <param name="employeeRequestUIModel"></param>
        /// <returns></returns>
        [HttpPost]
        [EmployeePostValidationFilter]
        public async Task<IActionResult> Post(EmployeeRequestModel employeeRequestUIModel)
        {
           return Ok(_iEmployeeService.AddEmployee(new Business.Models.Employee()
            {
                Id = employeeRequestUIModel.Id ?? 0,
                FullName = employeeRequestUIModel.FullName,
                Address = employeeRequestUIModel.Address,
                PhoneNumber = employeeRequestUIModel.PhoneNumber,
                Position = employeeRequestUIModel.Position
            }));;
        }


        /// <summary>
        /// Get all employee list
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responseList = _iEmployeeService.GetAllEmployee();

            List<EmployeeResponseModel> resp = new List<EmployeeResponseModel>();
            foreach (var emp in responseList)
            {
                resp.Add(new EmployeeResponseModel()
                {
                    Id = emp.Id,
                    FullName = emp.FullName,
                    Address = emp.Address,
                    PhoneNumber = emp.PhoneNumber,
                    Position = emp.Position
                });
            }
            return Ok(resp);
        }

        /// <summary>
        /// Delete employee 
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        [Route("{Id:int}")]
        public IActionResult Delete(int Id)
        {
            _iEmployeeService.DeleteEmployee(Id);
            return NoContent();
        }
    }
}