using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

            EmployeeServiceClient client = new EmployeeServiceClient("BasicHttpBinding_SH");

            string diag = client.GetDiagnostic();

            Console.WriteLine(diag);

            Employee emp;

            try
            {
                Console.Write("ID: ");
                string id = Console.ReadLine();
                int.TryParse(id, out int empId);

                emp = client.GetEmployeeById(empId);

                Console.WriteLine($"{emp.Id} - {emp.FirstName} {emp.LastName}");
            }
            catch(FaultException<FaultDetails> soapEx)
            {
                Console.WriteLine($"Errore: {soapEx.Detail.Message}");
                emp = client.GetEmployeeById(1);    // recupero dalla condizione di errore, il canale resta aperto
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}"); // non posso recuperare, canale chiuso
            }

            Console.ReadLine();
        }
    }
}
