using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Demo.Lib;
using Week4.Demo.WcfClient.EmployeeWCF_SH;

namespace Week4.Demo.WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Aspetta il WCF ...");
            Console.ReadLine();

            EmployeeServiceClient client = new EmployeeServiceClient("BasicHttpBinding_IIS_EXPR");

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
