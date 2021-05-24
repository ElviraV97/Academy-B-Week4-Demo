using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Demo.Lib;
using Week4.Demo.WcfClient.EmployeeWcf;

namespace Week4.Demo.WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeServiceClient client = new EmployeeServiceClient();

            string diag = client.GetDiagnostic();

            Console.WriteLine(diag);

            Console.Write("ID: ");
            string id = Console.ReadLine();
            int.TryParse(id, out int empId);

            Employee emp = client.GetEmployeeById(empId);

            Console.WriteLine($"{emp.Id} - {emp.FirstName} {emp.LastName}");

            Console.ReadLine();
        }
    }
}
