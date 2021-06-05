using Business.Models;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IEmployeeService
    {
        // Add employee
        Employee AddEmployee(Employee emp);

        //Get all employee list
        List<Employee> GetAllEmployee();

        //update employee
        void UpdateEmployee(Employee emp);

        //delete employee
        void DeleteEmployee(int id);
    }
}
