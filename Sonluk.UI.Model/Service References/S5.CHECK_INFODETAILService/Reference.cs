﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.S5.CHECK_INFODETAILService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="S5.CHECK_INFODETAILService.CHECK_INFODETAILSoap")]
    public interface CHECK_INFODETAILSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAILList[] Read(Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAIL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.CHECK_INFODETAILService.MES_RETURN Create(Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAIL[] model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.CHECK_INFODETAILService.MES_RETURN UPDATE(Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAIL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.CHECK_INFODETAILService.MES_RETURN DELETE(int ID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class FIVES_CHECK_INFODETAIL : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int dETAILIDField;
        
        private int iNFOIDField;
        
        private int tYPEIDField;
        
        private string tYPEMSField;
        
        private int sCROEIDField;
        
        private string sCROEMSField;
        
        private string jLTIMEField;
        
        private string rEMARKField;
        
        private int aCTIONField;
        
        private bool iSDELETEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int DETAILID {
            get {
                return this.dETAILIDField;
            }
            set {
                this.dETAILIDField = value;
                this.RaisePropertyChanged("DETAILID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int INFOID {
            get {
                return this.iNFOIDField;
            }
            set {
                this.iNFOIDField = value;
                this.RaisePropertyChanged("INFOID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string TYPEMS {
            get {
                return this.tYPEMSField;
            }
            set {
                this.tYPEMSField = value;
                this.RaisePropertyChanged("TYPEMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int SCROEID {
            get {
                return this.sCROEIDField;
            }
            set {
                this.sCROEIDField = value;
                this.RaisePropertyChanged("SCROEID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string SCROEMS {
            get {
                return this.sCROEMSField;
            }
            set {
                this.sCROEMSField = value;
                this.RaisePropertyChanged("SCROEMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string JLTIME {
            get {
                return this.jLTIMEField;
            }
            set {
                this.jLTIMEField = value;
                this.RaisePropertyChanged("JLTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string REMARK {
            get {
                return this.rEMARKField;
            }
            set {
                this.rEMARKField = value;
                this.RaisePropertyChanged("REMARK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int ACTION {
            get {
                return this.aCTIONField;
            }
            set {
                this.aCTIONField = value;
                this.RaisePropertyChanged("ACTION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public bool ISDELETE {
            get {
                return this.iSDELETEField;
            }
            set {
                this.iSDELETEField = value;
                this.RaisePropertyChanged("ISDELETE");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
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
        
        private string mSGNOField;
        
        private int iSCLMSGField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string MSGNO {
            get {
                return this.mSGNOField;
            }
            set {
                this.mSGNOField = value;
                this.RaisePropertyChanged("MSGNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int ISCLMSG {
            get {
                return this.iSCLMSGField;
            }
            set {
                this.iSCLMSGField = value;
                this.RaisePropertyChanged("ISCLMSG");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class FIVES_CHECK_INFODETAILList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int dETAILIDField;
        
        private int iNFOIDField;
        
        private int tYPEIDField;
        
        private string tYPEMSField;
        
        private int sCROEIDField;
        
        private string sCROEMSField;
        
        private string jLTIMEField;
        
        private string rEMARKField;
        
        private int aCTIONField;
        
        private bool iSDELETEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int DETAILID {
            get {
                return this.dETAILIDField;
            }
            set {
                this.dETAILIDField = value;
                this.RaisePropertyChanged("DETAILID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int INFOID {
            get {
                return this.iNFOIDField;
            }
            set {
                this.iNFOIDField = value;
                this.RaisePropertyChanged("INFOID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string TYPEMS {
            get {
                return this.tYPEMSField;
            }
            set {
                this.tYPEMSField = value;
                this.RaisePropertyChanged("TYPEMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int SCROEID {
            get {
                return this.sCROEIDField;
            }
            set {
                this.sCROEIDField = value;
                this.RaisePropertyChanged("SCROEID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string SCROEMS {
            get {
                return this.sCROEMSField;
            }
            set {
                this.sCROEMSField = value;
                this.RaisePropertyChanged("SCROEMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string JLTIME {
            get {
                return this.jLTIMEField;
            }
            set {
                this.jLTIMEField = value;
                this.RaisePropertyChanged("JLTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string REMARK {
            get {
                return this.rEMARKField;
            }
            set {
                this.rEMARKField = value;
                this.RaisePropertyChanged("REMARK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int ACTION {
            get {
                return this.aCTIONField;
            }
            set {
                this.aCTIONField = value;
                this.RaisePropertyChanged("ACTION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public bool ISDELETE {
            get {
                return this.iSDELETEField;
            }
            set {
                this.iSDELETEField = value;
                this.RaisePropertyChanged("ISDELETE");
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
    public interface CHECK_INFODETAILSoapChannel : Sonluk.UI.Model.S5.CHECK_INFODETAILService.CHECK_INFODETAILSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CHECK_INFODETAILSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.S5.CHECK_INFODETAILService.CHECK_INFODETAILSoap>, Sonluk.UI.Model.S5.CHECK_INFODETAILService.CHECK_INFODETAILSoap {
        
        public CHECK_INFODETAILSoapClient() {
        }
        
        public CHECK_INFODETAILSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CHECK_INFODETAILSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CHECK_INFODETAILSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CHECK_INFODETAILSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAILList[] Read(Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAIL model, string ptoken) {
            return base.Channel.Read(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.CHECK_INFODETAILService.MES_RETURN Create(Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAIL[] model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.CHECK_INFODETAILService.MES_RETURN UPDATE(Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAIL model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.CHECK_INFODETAILService.MES_RETURN DELETE(int ID, string ptoken) {
            return base.Channel.DELETE(ID, ptoken);
        }
    }
}
