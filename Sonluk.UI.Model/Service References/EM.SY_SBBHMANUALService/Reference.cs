﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.EM.SY_SBBHMANUALService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EM.SY_SBBHMANUALService.SY_SBBHMANUALSoap")]
    public interface SY_SBBHMANUALSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL[] Read(Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.EM.SY_SBBHMANUALService.MES_RETURN Create(Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.EM.SY_SBBHMANUALService.MES_RETURN UPDATE(Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.EM.SY_SBBHMANUALService.MES_RETURN DELETE(Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class EM_SY_SBBHMANUAL : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string sBBHField;
        
        private int mANUALIDField;
        
        private int xhField;
        
        private string sBBHMSField;
        
        private string mANUALMSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SBBH {
            get {
                return this.sBBHField;
            }
            set {
                this.sBBHField = value;
                this.RaisePropertyChanged("SBBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int MANUALID {
            get {
                return this.mANUALIDField;
            }
            set {
                this.mANUALIDField = value;
                this.RaisePropertyChanged("MANUALID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int XH {
            get {
                return this.xhField;
            }
            set {
                this.xhField = value;
                this.RaisePropertyChanged("XH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SBBHMS {
            get {
                return this.sBBHMSField;
            }
            set {
                this.sBBHMSField = value;
                this.RaisePropertyChanged("SBBHMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string MANUALMS {
            get {
                return this.mANUALMSField;
            }
            set {
                this.mANUALMSField = value;
                this.RaisePropertyChanged("MANUALMS");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_RETURN : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string tYPEField;
        
        private string mESSAGEField;
        
        private int tIDField;
        
        private string gcField;
        
        private string tmField;
        
        private string bhField;
        
        private int xhField;
        
        private int tMSXField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string TYPE {
            get {
                return this.tYPEField;
            }
            set {
                this.tYPEField = value;
                this.RaisePropertyChanged("TYPE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MESSAGE {
            get {
                return this.mESSAGEField;
            }
            set {
                this.mESSAGEField = value;
                this.RaisePropertyChanged("MESSAGE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int TID {
            get {
                return this.tIDField;
            }
            set {
                this.tIDField = value;
                this.RaisePropertyChanged("TID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string GC {
            get {
                return this.gcField;
            }
            set {
                this.gcField = value;
                this.RaisePropertyChanged("GC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string TM {
            get {
                return this.tmField;
            }
            set {
                this.tmField = value;
                this.RaisePropertyChanged("TM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string BH {
            get {
                return this.bhField;
            }
            set {
                this.bhField = value;
                this.RaisePropertyChanged("BH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int XH {
            get {
                return this.xhField;
            }
            set {
                this.xhField = value;
                this.RaisePropertyChanged("XH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int TMSX {
            get {
                return this.tMSXField;
            }
            set {
                this.tMSXField = value;
                this.RaisePropertyChanged("TMSX");
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
    public interface SY_SBBHMANUALSoapChannel : Sonluk.UI.Model.EM.SY_SBBHMANUALService.SY_SBBHMANUALSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SY_SBBHMANUALSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.EM.SY_SBBHMANUALService.SY_SBBHMANUALSoap>, Sonluk.UI.Model.EM.SY_SBBHMANUALService.SY_SBBHMANUALSoap {
        
        public SY_SBBHMANUALSoapClient() {
        }
        
        public SY_SBBHMANUALSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SY_SBBHMANUALSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_SBBHMANUALSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_SBBHMANUALSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL[] Read(Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL model, string ptoken) {
            return base.Channel.Read(model, ptoken);
        }
        
        public Sonluk.UI.Model.EM.SY_SBBHMANUALService.MES_RETURN Create(Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public Sonluk.UI.Model.EM.SY_SBBHMANUALService.MES_RETURN UPDATE(Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.EM.SY_SBBHMANUALService.MES_RETURN DELETE(Sonluk.UI.Model.EM.SY_SBBHMANUALService.EM_SY_SBBHMANUAL model, string ptoken) {
            return base.Channel.DELETE(model, ptoken);
        }
    }
}
