﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_ZZFTT_KAHXDJMXService.COST_ZZFTT_KAHXDJMXSoap")]
    public interface COST_ZZFTT_KAHXDJMXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService.CRM_COST_ZZFTT_KAHXDJMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService.CRM_COST_ZZFTT_KAHXDJMX[] ReadByParam(Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService.CRM_COST_ZZFTT_KAHXDJMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int HXDJMXID, int TTID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteByHXDJMXID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteByHXDJMXID(int HXDJMXID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_ZZFTT_KAHXDJMX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int hXDJMXIDField;
        
        private int tTIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int HXDJMXID {
            get {
                return this.hXDJMXIDField;
            }
            set {
                this.hXDJMXIDField = value;
                this.RaisePropertyChanged("HXDJMXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int TTID {
            get {
                return this.tTIDField;
            }
            set {
                this.tTIDField = value;
                this.RaisePropertyChanged("TTID");
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
    public interface COST_ZZFTT_KAHXDJMXSoapChannel : Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService.COST_ZZFTT_KAHXDJMXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_ZZFTT_KAHXDJMXSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService.COST_ZZFTT_KAHXDJMXSoap>, Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService.COST_ZZFTT_KAHXDJMXSoap {
        
        public COST_ZZFTT_KAHXDJMXSoapClient() {
        }
        
        public COST_ZZFTT_KAHXDJMXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_ZZFTT_KAHXDJMXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_ZZFTT_KAHXDJMXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_ZZFTT_KAHXDJMXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService.CRM_COST_ZZFTT_KAHXDJMX model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService.CRM_COST_ZZFTT_KAHXDJMX[] ReadByParam(Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService.CRM_COST_ZZFTT_KAHXDJMX model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int HXDJMXID, int TTID, string ptoken) {
            return base.Channel.Delete(HXDJMXID, TTID, ptoken);
        }
        
        public int DeleteByHXDJMXID(int HXDJMXID, string ptoken) {
            return base.Channel.DeleteByHXDJMXID(HXDJMXID, ptoken);
        }
    }
}
