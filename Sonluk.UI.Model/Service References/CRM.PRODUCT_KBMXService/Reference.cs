﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.PRODUCT_KBMXService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.PRODUCT_KBMXService.PRODUCT_KBMXSoap")]
    public interface PRODUCT_KBMXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.PRODUCT_KBMXService.CRM_PRODUCT_KBMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.PRODUCT_KBMXService.CRM_PRODUCT_KBMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.PRODUCT_KBMXService.CRM_PRODUCT_KBMX[] ReadByParam(Sonluk.UI.Model.CRM.PRODUCT_KBMXService.CRM_PRODUCT_KBMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int KBMXID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteByKBID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteByKBID(int KBID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_PRODUCT_KBMX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int kBMXIDField;
        
        private int kBIDField;
        
        private string cPHHField;
        
        private string wLBMField;
        
        private string dDDWField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private string kBMCField;
        
        private int orderSrcField;
        
        private string wLMSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int KBMXID {
            get {
                return this.kBMXIDField;
            }
            set {
                this.kBMXIDField = value;
                this.RaisePropertyChanged("KBMXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int KBID {
            get {
                return this.kBIDField;
            }
            set {
                this.kBIDField = value;
                this.RaisePropertyChanged("KBID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CPHH {
            get {
                return this.cPHHField;
            }
            set {
                this.cPHHField = value;
                this.RaisePropertyChanged("CPHH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string WLBM {
            get {
                return this.wLBMField;
            }
            set {
                this.wLBMField = value;
                this.RaisePropertyChanged("WLBM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string DDDW {
            get {
                return this.dDDWField;
            }
            set {
                this.dDDWField = value;
                this.RaisePropertyChanged("DDDW");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string BEIZ {
            get {
                return this.bEIZField;
            }
            set {
                this.bEIZField = value;
                this.RaisePropertyChanged("BEIZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int ISACTIVE {
            get {
                return this.iSACTIVEField;
            }
            set {
                this.iSACTIVEField = value;
                this.RaisePropertyChanged("ISACTIVE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string KBMC {
            get {
                return this.kBMCField;
            }
            set {
                this.kBMCField = value;
                this.RaisePropertyChanged("KBMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int OrderSrc {
            get {
                return this.orderSrcField;
            }
            set {
                this.orderSrcField = value;
                this.RaisePropertyChanged("OrderSrc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string WLMS {
            get {
                return this.wLMSField;
            }
            set {
                this.wLMSField = value;
                this.RaisePropertyChanged("WLMS");
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
    public interface PRODUCT_KBMXSoapChannel : Sonluk.UI.Model.CRM.PRODUCT_KBMXService.PRODUCT_KBMXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PRODUCT_KBMXSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.PRODUCT_KBMXService.PRODUCT_KBMXSoap>, Sonluk.UI.Model.CRM.PRODUCT_KBMXService.PRODUCT_KBMXSoap {
        
        public PRODUCT_KBMXSoapClient() {
        }
        
        public PRODUCT_KBMXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PRODUCT_KBMXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PRODUCT_KBMXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PRODUCT_KBMXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.PRODUCT_KBMXService.CRM_PRODUCT_KBMX model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.PRODUCT_KBMXService.CRM_PRODUCT_KBMX model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.PRODUCT_KBMXService.CRM_PRODUCT_KBMX[] ReadByParam(Sonluk.UI.Model.CRM.PRODUCT_KBMXService.CRM_PRODUCT_KBMX model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int KBMXID, string ptoken) {
            return base.Channel.Delete(KBMXID, ptoken);
        }
        
        public int DeleteByKBID(int KBID, string ptoken) {
            return base.Channel.DeleteByKBID(KBID, ptoken);
        }
    }
}