﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_ZZFMXService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_ZZFMXService.COST_ZZFMXSoap")]
    public interface COST_ZZFMXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_ZZFMXService.CRM_COST_ZZFMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_ZZFMXService.CRM_COST_ZZFMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_ZZFMXService.CRM_COST_ZZFMX[] ReadByParam(Sonluk.UI.Model.CRM.COST_ZZFMXService.CRM_COST_ZZFMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int MXID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_ZZFMX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int mXIDField;
        
        private int tTIDField;
        
        private int gGXMIDField;
        
        private double pRICEField;
        
        private double qUANTITYField;
        
        private double aMOUNTField;
        
        private string bEIZField;
        
        private string gGXMIDDESField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int MXID {
            get {
                return this.mXIDField;
            }
            set {
                this.mXIDField = value;
                this.RaisePropertyChanged("MXID");
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int GGXMID {
            get {
                return this.gGXMIDField;
            }
            set {
                this.gGXMIDField = value;
                this.RaisePropertyChanged("GGXMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public double PRICE {
            get {
                return this.pRICEField;
            }
            set {
                this.pRICEField = value;
                this.RaisePropertyChanged("PRICE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public double QUANTITY {
            get {
                return this.qUANTITYField;
            }
            set {
                this.qUANTITYField = value;
                this.RaisePropertyChanged("QUANTITY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public double AMOUNT {
            get {
                return this.aMOUNTField;
            }
            set {
                this.aMOUNTField = value;
                this.RaisePropertyChanged("AMOUNT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string GGXMIDDES {
            get {
                return this.gGXMIDDESField;
            }
            set {
                this.gGXMIDDESField = value;
                this.RaisePropertyChanged("GGXMIDDES");
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
    public interface COST_ZZFMXSoapChannel : Sonluk.UI.Model.CRM.COST_ZZFMXService.COST_ZZFMXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_ZZFMXSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_ZZFMXService.COST_ZZFMXSoap>, Sonluk.UI.Model.CRM.COST_ZZFMXService.COST_ZZFMXSoap {
        
        public COST_ZZFMXSoapClient() {
        }
        
        public COST_ZZFMXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_ZZFMXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_ZZFMXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_ZZFMXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_ZZFMXService.CRM_COST_ZZFMX model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_ZZFMXService.CRM_COST_ZZFMX model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_ZZFMXService.CRM_COST_ZZFMX[] ReadByParam(Sonluk.UI.Model.CRM.COST_ZZFMXService.CRM_COST_ZZFMX model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int MXID, string ptoken) {
            return base.Channel.Delete(MXID, ptoken);
        }
    }
}
