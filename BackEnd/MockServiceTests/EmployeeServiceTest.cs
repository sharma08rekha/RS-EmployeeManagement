using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MockServiceTests
{
    public class EmployeeServiceTest
    {
        private readonly EmployeeService _employeeService;
        private readonly Mock<IEmployeeDAO> _employeeDAO = new Mock<IEmployeeDAO>();
        public EmployeeServiceTest()
        {
            _employeeService = new EmployeeService(_employeeDAO.Object);
        }

        /// <summary>
        /// Post payment successful test scenario
        /// </summary>
        [Fact]
        public void PostPaymentSuccessTest()
        {
            //Arrage
            var request = new Employee()
            {
                FullName = "John",
                Address = "10 abc, ON",
                PhoneNumber = "23232323",
                Position = 1
            };

            _employeeDAO.Setup(i => i.AddEmployee(request));            

            //Act
           
            //Assert
           
        }
    }
}
