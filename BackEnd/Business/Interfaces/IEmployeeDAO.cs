using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IEmployeeDAO
    {
        // Add employee
        Employee AddEmployee(Employee emp);

        // Get all employee list
        List<Employee> GetAllEmployee();

        // Update employee
        void UpdateEmployee(Employee emp);

        // Get employee Id
        Employee GetEmployee(int empId);

        // Delete employee
        void DeleteEmployee(int id);
    }
}
