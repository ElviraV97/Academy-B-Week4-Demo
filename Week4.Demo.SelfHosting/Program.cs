using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Week4.Demo.WcfService;

namespace Week4.Demo.SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = 
                new ServiceHost(typeof(EmployeeService)))
            {
                host.Open();
                Console.WriteLine("Press any key to stop ...");
                Console.ReadLine();
            }
        }
    }
}
