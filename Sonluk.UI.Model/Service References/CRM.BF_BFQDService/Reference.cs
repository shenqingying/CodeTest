﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.BF_BFQDService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.BF_BFQDService.BF_BFQDSoap")]
    public interface BF_BFQDSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.BF_BFQDService.CRM_BF_BFQD model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByBFDJID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BF_BFQDService.CRM_BF_BFQDLIST[] ReadByBFDJID(int BFDJID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int BFQDID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_BF_BFQD : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int bFQDIDField;
        
        private int bFDJIDField;
        
        private int qDIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int BFQDID {
            get {
                return this.bFQDIDField;
            }
            set {
                this.bFQDIDField = value;
                this.RaisePropertyChanged("BFQDID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int BFDJID {
            get {
                return this.bFDJIDField;
            }
            set {
                this.bFDJIDField = value;
                this.RaisePropertyChanged("BFDJID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int QDID {
            get {
                return this.qDIDField;
            }
            set {
                this.qDIDField = value;
                this.RaisePropertyChanged("QDID");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_BF_BFQDLIST : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int bFQDIDField;
        
        private int bFDJIDField;
        
        private int qDIDField;
        
        private string qDIDDESField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int BFQDID {
            get {
                return this.bFQDIDField;
            }
            set {
                this.bFQDIDField = value;
                this.RaisePropertyChanged("BFQDID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int BFDJID {
            get {
                return this.bFDJIDField;
            }
            set {
                this.bFDJIDField = value;
                this.RaisePropertyChanged("BFDJID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int QDID {
            get {
                return this.qDIDField;
            }
            set {
                this.qDIDField = value;
                this.RaisePropertyChanged("QDID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string QDIDDES {
            get {
                return this.qDIDDESField;
            }
            set {
                this.qDIDDESField = value;
                this.RaisePropertyChanged("QDIDDES");
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
    public interface BF_BFQDSoapChannel : Sonluk.UI.Model.CRM.BF_BFQDService.BF_BFQDSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BF_BFQDSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.BF_BFQDService.BF_BFQDSoap>, Sonluk.UI.Model.CRM.BF_BFQDService.BF_BFQDSoap {
        
        public BF_BFQDSoapClient() {
        }
        
        public BF_BFQDSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BF_BFQDSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BF_BFQDSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BF_BFQDSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.BF_BFQDService.CRM_BF_BFQD model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BF_BFQDService.CRM_BF_BFQDLIST[] ReadByBFDJID(int BFDJID, string ptoken) {
            return base.Channel.ReadByBFDJID(BFDJID, ptoken);
        }
        
        public int Delete(int BFQDID, string ptoken) {
            return base.Channel.Delete(BFQDID, ptoken);
        }
    }
}