﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.DEV.TableService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Sonluk.com/API/DEV/", ConfigurationName="DEV.TableService.TableSoap")]
    public interface TableSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Sonluk.com/API/DEV/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Read(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TableSoapChannel : Sonluk.UI.Model.DEV.TableService.TableSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TableSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.DEV.TableService.TableSoap>, Sonluk.UI.Model.DEV.TableService.TableSoap {
        
        public TableSoapClient() {
        }
        
        public TableSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TableSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TableSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TableSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Read(string name) {
            return base.Channel.Read(name);
        }
    }
}
