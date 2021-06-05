using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Business.Interfaces;
using Business.Models;
using Common;
using DAO.Context;

namespace DAO.Services
{
    public class EmployeeDAO : IEmployeeDAO
    {
        private EmployeeContext _employeeContext;

        public EmployeeDAO(EmployeeContext paymentContext)
        {
            this._employeeContext = paymentContext;
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="emp"></param>
        public Employee AddEmployee(Employee emp)
        {
            try
            {
                if(emp.Id != 0)
                {
                    _employeeContext.Employees.Update(emp);
                }
                else
                {
                    _employeeContext.Employees.Add(emp);
                    _employeeContext.SaveChanges();
                }

                return emp;
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
                return _employeeContext.Employees.ToList();
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
        public Employee GetEmployee(int empId)
        {
            try
            {
                return _employeeContext.Employees.FirstOrDefault(i => i.Id == empId);
            }
            catch (Exception ex)
            {
                throw new APIException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// update employee
        /// </summary>
        /// <param name="emp"></param>
        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(int id)
        {
            try
            {
               _employeeContext.Employees.Remove(GetEmployee(id));
                _employeeContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new APIException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
