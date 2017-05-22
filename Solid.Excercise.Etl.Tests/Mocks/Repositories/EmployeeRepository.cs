using System.Collections.Generic;
using Solid.Excercise.Etl.Entities;
using Solid.Excercise.Etl.Interfaces;

namespace Solid.Excercise.Etl.Tests.Mocks.Repositories
{
    class EmployeeRepository : IGetRepository<string, Employee>
    {
        public IEnumerable<Employee> GetAll(string connectionString)
        {
            var employees = new List<Employee>
            {
                new Employee{ FirstName = "Jacob",LastName = "Eapen",SubordinatesCount = 0},
                new Employee{ FirstName = "Eapen",LastName = "Kochekkan",SubordinatesCount = 100},
            };

            return employees;
        }
    }
}
