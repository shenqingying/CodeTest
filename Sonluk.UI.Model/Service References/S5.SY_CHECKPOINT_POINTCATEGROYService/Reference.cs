﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="S5.SY_CHECKPOINT_POINTCATEGROYService.SY_CHECKPOINT_POINTCATEGROYSoap")]
    public interface SY_CHECKPOINT_POINTCATEGROYSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROYList[] Read(Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROY model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.MES_RETURN Create(Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROY model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.MES_RETURN UPDATE(Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROY model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.MES_RETURN DELETE(Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROY model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class FIVES_SY_CHECKPOINT_POINTCATEGROY : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int pOINTIDField;
        
        private int cATEGROYIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int POINTID {
            get {
                return this.pOINTIDField;
            }
            set {
                this.pOINTIDField = value;
                this.RaisePropertyChanged("POINTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int CATEGROYID {
            get {
                return this.cATEGROYIDField;
            }
            set {
                this.cATEGROYIDField = value;
                this.RaisePropertyChanged("CATEGROYID");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class FIVES_SY_CHECKPOINT_POINTCATEGROYList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int pOINTIDField;
        
        private int cATEGROYIDField;
        
        private string pNAMEField;
        
        private string cNAMEField;
        
        private string lNAMEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int POINTID {
            get {
                return this.pOINTIDField;
            }
            set {
                this.pOINTIDField = value;
                this.RaisePropertyChanged("POINTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int CATEGROYID {
            get {
                return this.cATEGROYIDField;
            }
            set {
                this.cATEGROYIDField = value;
                this.RaisePropertyChanged("CATEGROYID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string PNAME {
            get {
                return this.pNAMEField;
            }
            set {
                this.pNAMEField = value;
                this.RaisePropertyChanged("PNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CNAME {
            get {
                return this.cNAMEField;
            }
            set {
                this.cNAMEField = value;
                this.RaisePropertyChanged("CNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string LNAME {
            get {
                return this.lNAMEField;
            }
            set {
                this.lNAMEField = value;
                this.RaisePropertyChanged("LNAME");
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
    public interface SY_CHECKPOINT_POINTCATEGROYSoapChannel : Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.SY_CHECKPOINT_POINTCATEGROYSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SY_CHECKPOINT_POINTCATEGROYSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.SY_CHECKPOINT_POINTCATEGROYSoap>, Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.SY_CHECKPOINT_POINTCATEGROYSoap {
        
        public SY_CHECKPOINT_POINTCATEGROYSoapClient() {
        }
        
        public SY_CHECKPOINT_POINTCATEGROYSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SY_CHECKPOINT_POINTCATEGROYSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_CHECKPOINT_POINTCATEGROYSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_CHECKPOINT_POINTCATEGROYSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROYList[] Read(Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROY model, string ptoken) {
            return base.Channel.Read(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.MES_RETURN Create(Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROY model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.MES_RETURN UPDATE(Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROY model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.MES_RETURN DELETE(Sonluk.UI.Model.S5.SY_CHECKPOINT_POINTCATEGROYService.FIVES_SY_CHECKPOINT_POINTCATEGROY model, string ptoken) {
            return base.Channel.DELETE(model, ptoken);
        }
    }
}
