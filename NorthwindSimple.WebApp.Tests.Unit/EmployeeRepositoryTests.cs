using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.WebApp.Models;
using Rhino.Mocks;

    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

namespace NorthwindSimple.WebApp.Tests.Unit
{
    public class Employeex

    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }

    public class ExampleContext : DbContext
    {
        public ExampleContext()
            : base("ExampleConnectionStringName")
        {
        }

        public virtual IDbSet<Employee> Employees { get; set; }
    }

//    public class ExampleContext : DbContext
//    {
//        public NORTHWNDdbContext()
//            : base("name=NORTHWNDdbContext")
//        {
//        }
//        public ExampleContext() : base(“ExampleConnectionStringName”)

//    {

//    }

//      public virtual IDbSet<Customer> Customers { get; set; }

//}


    public class CustomerRepositoryTests

    {

        protected ExampleContext MockContext;

        protected IQueryable<Employee> MockData;

        protected DbSet<Employee> MockSet;

        // [SetUp]


        public void SetUp()

        {

            MockContext = MockRepository.GenerateMock<ExampleContext>();

            MockSet = MockRepository.GenerateMock<DbSet<Employee>, IQueryable>();

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

            // These were hard to find

            MockSet.Stub(m => m.AsQueryable().Provider).Return(MockData.Provider);

            MockSet.Stub(m => m.AsQueryable().Expression).Return(MockData.Expression);

            MockSet.Stub(m => m.AsQueryable().ElementType).Return(MockData.ElementType);

            MockSet.Stub(m => m.AsQueryable().GetEnumerator()).Return(MockData.GetEnumerator());

            MockContext.Stub(x => x.Employees).PropertyBehavior();

            MockContext.Employees = MockSet;

        }
    }
}
