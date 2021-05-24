using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Demo.Lib;

namespace Week4.Demo.WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetAllEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Mario", LastName = "Rossi" },
                new Employee { Id = 2, FirstName = "Paolo", LastName = "Bianchi" },
                new Employee { Id = 3, FirstName = "Luigi", LastName = "Verdi" }
            };
        }

        public string GetDiagnostic()
        {
            return "Welcome to Employee WCF Service v1.0.0";
        }

        public Employee GetEmployeeById(int id)
        {
            return new Employee
            {
                Id = id,
                FirstName = "Mario",
                LastName = "Rossi"
            };
        }
    }
}
