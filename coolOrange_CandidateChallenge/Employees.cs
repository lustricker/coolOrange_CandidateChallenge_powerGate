using System;
using System.Collections.Generic;
using System.Linq;
using powerGateServer.SDK;
using coolOrange.TestData;
using System.Data.Services.Common;

namespace coolOrange_CandidateChallenge
{
    [DataServiceKey("Email")]
    [DataServiceEntity]
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        
        public coolOrange.TestData.Employee toCoolOrangeEmployee()
        {
            return new coolOrange.TestData.Employee()
            {
                Name = this.Name,
                City = this.City,
                Department = this.Department,
                Email = this.Email
            };
        }
    }
    public class Employees : ServiceMethod<Employee>
    {
        public override string Name => "Employees";

        public override IEnumerable<Employee> Query(IExpression<Employee> expression)
        {
            var coolOrangeEmployees = TestData.GetEmployees();
            return coolOrangeEmployees.Select(
                x => new Employee
                {
                    Name = x.Name,
                    City = x.City,
                    Department = x.Department,
                    Email = x.Email
                }
                );
        }

        public override void Update(Employee entity)
        {
            throw new NotImplementedException();
        }

        public override void Create(Employee entity)
        {
            TestData.AddEmployee(entity.toCoolOrangeEmployee());
        }

        public override void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
