﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_KADTDPService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_KADTDPService.COST_KADTDPSoap")]
    public interface COST_KADTDPSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_KADTDPService.CRM_COST_KADTDP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_KADTDPService.CRM_COST_KADTDP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_KADTDPService.CRM_COST_KADTDP[] ReadByParam(Sonluk.UI.Model.CRM.COST_KADTDPService.CRM_COST_KADTDP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int DPID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_KADTDP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int dPIDField;
        
        private int kADTTTIDField;
        
        private string sAPCPField;
        
        private decimal zCGJField;
        
        private decimal cXGJField;
        
        private decimal zCSJField;
        
        private decimal cXSJField;
        
        private int bHSLField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private int cJRField;
        
        private string cJSJField;
        
        private int xGRField;
        
        private string xGSJField;
        
        private string cPMCField;
        
        private string cJRNAMEField;
        
        private string xGRNAMEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int DPID {
            get {
                return this.dPIDField;
            }
            set {
                this.dPIDField = value;
                this.RaisePropertyChanged("DPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int KADTTTID {
            get {
                return this.kADTTTIDField;
            }
            set {
                this.kADTTTIDField = value;
                this.RaisePropertyChanged("KADTTTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SAPCP {
            get {
                return this.sAPCPField;
            }
            set {
                this.sAPCPField = value;
                this.RaisePropertyChanged("SAPCP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public decimal ZCGJ {
            get {
                return this.zCGJField;
            }
            set {
                this.zCGJField = value;
                this.RaisePropertyChanged("ZCGJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public decimal CXGJ {
            get {
                return this.cXGJField;
            }
            set {
                this.cXGJField = value;
                this.RaisePropertyChanged("CXGJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public decimal ZCSJ {
            get {
                return this.zCSJField;
            }
            set {
                this.zCSJField = value;
                this.RaisePropertyChanged("ZCSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public decimal CXSJ {
            get {
                return this.cXSJField;
            }
            set {
                this.cXSJField = value;
                this.RaisePropertyChanged("CXSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int BHSL {
            get {
                return this.bHSLField;
            }
            set {
                this.bHSLField = value;
                this.RaisePropertyChanged("BHSL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int CJR {
            get {
                return this.cJRField;
            }
            set {
                this.cJRField = value;
                this.RaisePropertyChanged("CJR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string CJSJ {
            get {
                return this.cJSJField;
            }
            set {
                this.cJSJField = value;
                this.RaisePropertyChanged("CJSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int XGR {
            get {
                return this.xGRField;
            }
            set {
                this.xGRField = value;
                this.RaisePropertyChanged("XGR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string XGSJ {
            get {
                return this.xGSJField;
            }
            set {
                this.xGSJField = value;
                this.RaisePropertyChanged("XGSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string CPMC {
            get {
                return this.cPMCField;
            }
            set {
                this.cPMCField = value;
                this.RaisePropertyChanged("CPMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string CJRNAME {
            get {
                return this.cJRNAMEField;
            }
            set {
                this.cJRNAMEField = value;
                this.RaisePropertyChanged("CJRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string XGRNAME {
            get {
                return this.xGRNAMEField;
            }
            set {
                this.xGRNAMEField = value;
                this.RaisePropertyChanged("XGRNAME");
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
    public interface COST_KADTDPSoapChannel : Sonluk.UI.Model.CRM.COST_KADTDPService.COST_KADTDPSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_KADTDPSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_KADTDPService.COST_KADTDPSoap>, Sonluk.UI.Model.CRM.COST_KADTDPService.COST_KADTDPSoap {
        
        public COST_KADTDPSoapClient() {
        }
        
        public COST_KADTDPSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_KADTDPSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_KADTDPSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_KADTDPSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_KADTDPService.CRM_COST_KADTDP model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_KADTDPService.CRM_COST_KADTDP model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_KADTDPService.CRM_COST_KADTDP[] ReadByParam(Sonluk.UI.Model.CRM.COST_KADTDPService.CRM_COST_KADTDP model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int DPID, string ptoken) {
            return base.Channel.Delete(DPID, ptoken);
        }
    }
}
