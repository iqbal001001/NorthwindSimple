using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using Northwind.WebApp.Controllers;
using Northwind.WebApp.Models;
using Rhino.Mocks;
using ModelStateDictionary = System.Web.ModelBinding.ModelStateDictionary;

namespace NorthwindSimple.WebApp.Tests.Unit
{
    /// <summary>
    /// Summary description for EmployerControllerTest
    /// </summary>
    [TestClass]
    public class EmployerControllerTest
    {
        //private Mock<IContactManagerRepository> _mockRepository;
        //private ModelStateDictionary _modelState;
        //private IContactManagerService _service

        protected NORTHWNDdbContext MockContext;

        protected IQueryable<Employee> MockData;

        protected IDbSet<Employee> MockSet;
        
        private Controller _Controller   ;

        // reference: http://www.arrangeactassert.com/how-to-unit-test-asp-net-mvc-controllers/
        
        private void setup()
        {

            MockContext = MockRepository.GenerateStub<NORTHWNDdbContext>();
            MockSet = MockRepository.GenerateMock<IDbSet<Employee>, IQueryable>();
            MockData = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 119,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    BirthDate = new DateTime(1981, 1, 1)
                },

                new Employee
                {
                    EmployeeID = 120,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    BirthDate = new DateTime(1981, 1, 1)
                },

                new Employee
                {
                    EmployeeID = 118,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    BirthDate = new DateTime(1971, 10, 10)
                }

            }.AsQueryable();

            MockSet.Stub(m => m.AsQueryable().Provider).Return(MockData.Provider);

            MockSet.Stub(m => m.AsQueryable().Expression).Return(MockData.Expression);

            MockSet.Stub(m => m.AsQueryable().ElementType).Return(MockData.ElementType);

            MockSet.Stub(m => m.AsQueryable().GetEnumerator()).Return(MockData.GetEnumerator());

            MockContext.Stub(x => x.Employees).PropertyBehavior(); 

            MockContext.Employees = MockSet;

        }

        [TestMethod]
        public void Default_Action_Returns_Index_View()
        {
            // Arrange   
            setup();
            const string expectedViewName = "Index";
            //var mockContext = MockRepository.GenerateStub<NORTHWNDdbContext>();
            var employeesController = new EmployeesController()
            {
                db = MockContext
            };
            //employeesController.db = MockContext;

            //employerService.Stub(x => x.Employees).Return(MockSet);
            //MockSet.Stub(m => m.AsQueryable().GetEnumerator()).Return(MockData.GetEnumerator());
            //mockContext.Employees = MockSet;
            // Act
            var result = employeesController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Should have returned a ViewResult");
            Assert.AreEqual(expectedViewName, result.ViewName, "View name should have been {0}", expectedViewName);
        }
/*
        [TestMethod]
        public void Default_Action_Returns_Index_View_Using_MvcContrib_TestHelper()
        {
            // Arrange              
            var employeesController = new EmployeesController();

            // Act
            var result = employeesController.Index();

            // Assert
            result.AssertViewRendered().ForView("Index");
        }

        [TestMethod]
        public void The_Add_Customer_Action_Returns_RedirectToRouteResult_When_The_Customer_Model_Is_Valid()
        {
            // Arrange  
            const string expectedRouteName = "EmployeeCreated";
            var employee = new Employee();
            //employee.Stub(x=> x.);
            var employeesController = new EmployeesController();
            employeesController.ModelState.Clear(); 

            // Act
            var result = employeesController.Create(employee,null) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result, "Should have returned a RedirectToRouteResult");
            Assert.AreEqual(expectedRouteName, result.RouteName, "Route name should have been {0}", expectedRouteName);

        }

        [TestMethod]
        public void The_Add_Customer_Action_Returns_ViewResult_When_The_Customer_Model_Is_Invalid()
        {
            // Arrange           
            const string expectedViewName = "Create";
            var employee = new Employee();
            var employerService = MockRepository.GenerateStub<NORTHWNDdbContext>();
            var employeesController = new EmployeesController();

            employeesController.ModelState.AddModelError("A Error", "Message");

            // Set up result for customers service
            //employerService.Stub(c => c.Get(null, null))
            //    .IgnoreArguments()
            //    .Return(new List<Employee>());


            // Act
            var result = employeesController.Create(employee,null) as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Should have returned a ViewResult");
            Assert.AreEqual(expectedViewName, result.ViewName, "View name should have been {0}", expectedViewName);
        }

        [TestMethod]
        public void The_Add_Customer_Action_Returns_ViewResult_When_The_Customer_Model_Is_Invalid_Using_MvcContrib_TestHelper()
        {
            // Arrange                  
            var employee = new Employee();
            //var customerService = MockRepository.GenerateStub<ICustomerService>();
            var employeesController = new EmployeesController();
            employeesController.ModelState.AddModelError("A Error", "Message");

            // Act
            var result = employeesController.Create(employee,null);

            // Assert
            result.AssertViewRendered().ViewName.ShouldBe("Create");
        }


        */



    }
}
