﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.HG_TYPEService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.HG_TYPEService.HG_TYPESoap")]
    public interface HG_TYPESoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE[] Read(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int TYPEID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByTypeName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE[] ReadByTypeName(Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_HG_TYPE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int tYPEIDField;
        
        private string tYPENAMEField;
        
        private string tYPEMEMOField;
        
        private bool iSACTIVEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int TYPEID {
            get {
                return this.tYPEIDField;
            }
            set {
                this.tYPEIDField = value;
                this.RaisePropertyChanged("TYPEID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string TYPENAME {
            get {
                return this.tYPENAMEField;
            }
            set {
                this.tYPENAMEField = value;
                this.RaisePropertyChanged("TYPENAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string TYPEMEMO {
            get {
                return this.tYPEMEMOField;
            }
            set {
                this.tYPEMEMOField = value;
                this.RaisePropertyChanged("TYPEMEMO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public bool ISACTIVE {
            get {
                return this.iSACTIVEField;
            }
            set {
                this.iSACTIVEField = value;
                this.RaisePropertyChanged("ISACTIVE");
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
    public interface HG_TYPESoapChannel : Sonluk.UI.Model.CRM.HG_TYPEService.HG_TYPESoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HG_TYPESoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.HG_TYPEService.HG_TYPESoap>, Sonluk.UI.Model.CRM.HG_TYPEService.HG_TYPESoap {
        
        public HG_TYPESoapClient() {
        }
        
        public HG_TYPESoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HG_TYPESoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_TYPESoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_TYPESoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE[] Read(string ptoken) {
            return base.Channel.Read(ptoken);
        }
        
        public int Delete(int TYPEID, string ptoken) {
            return base.Channel.Delete(TYPEID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE[] ReadByTypeName(Sonluk.UI.Model.CRM.HG_TYPEService.CRM_HG_TYPE model, string ptoken) {
            return base.Channel.ReadByTypeName(model, ptoken);
        }
    }
}