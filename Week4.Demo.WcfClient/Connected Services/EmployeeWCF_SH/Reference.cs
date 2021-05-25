﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Week4.Demo.WcfClient.EmployeeWCF_SH {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultDetails", Namespace="http://schemas.datacontract.org/2004/07/Week4.Demo.WcfService")]
    [System.SerializableAttribute()]
    public partial class FaultDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeWCF_SH.IEmployeeService")]
    public interface IEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetDiagnostic", ReplyAction="http://tempuri.org/IEmployeeService/GetDiagnosticResponse")]
        string GetDiagnostic();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetDiagnostic", ReplyAction="http://tempuri.org/IEmployeeService/GetDiagnosticResponse")]
        System.Threading.Tasks.Task<string> GetDiagnosticAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeService/GetAllEmployeesResponse")]
        System.Collections.Generic.List<Week4.Demo.Lib.Employee> GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeService/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Week4.Demo.Lib.Employee>> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeeById", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Week4.Demo.WcfClient.EmployeeWCF_SH.FaultDetails), Action="http://tempuri.org/IEmployeeService/GetEmployeeByIdFaultDetailsFault", Name="FaultDetails", Namespace="http://schemas.datacontract.org/2004/07/Week4.Demo.WcfService")]
        Week4.Demo.Lib.Employee GetEmployeeById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeeById", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeByIdResponse")]
        System.Threading.Tasks.Task<Week4.Demo.Lib.Employee> GetEmployeeByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeServiceChannel : Week4.Demo.WcfClient.EmployeeWCF_SH.IEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeServiceClient : System.ServiceModel.ClientBase<Week4.Demo.WcfClient.EmployeeWCF_SH.IEmployeeService>, Week4.Demo.WcfClient.EmployeeWCF_SH.IEmployeeService {
        
        public EmployeeServiceClient() {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDiagnostic() {
            return base.Channel.GetDiagnostic();
        }
        
        public System.Threading.Tasks.Task<string> GetDiagnosticAsync() {
            return base.Channel.GetDiagnosticAsync();
        }
        
        public System.Collections.Generic.List<Week4.Demo.Lib.Employee> GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Week4.Demo.Lib.Employee>> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public Week4.Demo.Lib.Employee GetEmployeeById(int id) {
            return base.Channel.GetEmployeeById(id);
        }
        
        public System.Threading.Tasks.Task<Week4.Demo.Lib.Employee> GetEmployeeByIdAsync(int id) {
            return base.Channel.GetEmployeeByIdAsync(id);
        }
    }
}
