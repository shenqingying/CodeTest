﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.Setting.VersionService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Sonluk.com/API/Setting", ConfigurationName="Setting.VersionService.VersionSoap")]
    public interface VersionSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Sonluk.com/API/Setting/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Read();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Sonluk.com/API/Setting/ReadAll", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] ReadAll();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface VersionSoapChannel : Sonluk.UI.Model.Setting.VersionService.VersionSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VersionSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.Setting.VersionService.VersionSoap>, Sonluk.UI.Model.Setting.VersionService.VersionSoap {
        
        public VersionSoapClient() {
        }
        
        public VersionSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VersionSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VersionSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VersionSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Read() {
            return base.Channel.Read();
        }
        
        public string[] ReadAll() {
            return base.Channel.ReadAll();
        }
    }
}