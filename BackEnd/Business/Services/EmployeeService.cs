using Business.Interfaces;
using Business.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Net;

namespace Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeDAO _iEmployeeDAO;

        public EmployeeService(IEmployeeDAO employeeDAO)
        {
            _iEmployeeDAO = employeeDAO;
        }

        /// <summary>
        /// Add employee service 
        /// </summary>
        /// <param name="emp"></param>
        public Employee AddEmployee(Employee emp)
        {
            try
            {
               return _iEmployeeDAO.AddEmployee(emp);
            }
            catch (Exception ex)
            {
                throw new APIException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Get all employee list
        /// </summary>
        /// <returns>List<Employee></returns>
        public List<Employee> GetAllEmployee()
        {
            try
            {
                return _iEmployeeDAO.GetAllEmployee();
            }
            catch (Exception ex)
            {
                throw new APIException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// update employee info
        /// </summary>
        /// <param name="emp"></param>
        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// delete employee
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(int id)
        {
            try
            {
                _iEmployeeDAO.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw new APIException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
