using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Demo.Lib;

namespace Week4.Demo.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        string GetDiagnostic();

        [OperationContract]
        List<Employee> GetAllEmployees();

        [OperationContract]
        [FaultContract(typeof(FaultDetails))]
        Employee GetEmployeeById(int id);
    }
}
