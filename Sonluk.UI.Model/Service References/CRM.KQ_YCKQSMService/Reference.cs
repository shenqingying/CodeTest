﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.KQ_YCKQSMService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.KQ_YCKQSMService.KQ_YCKQSMSoap")]
    public interface KQ_YCKQSMSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSM model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSM model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadBySTAFFID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList[] ReadBySTAFFID(int STAFFID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int YCKQID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Report_YC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQList[] Report_YC(int STAFFID, string fromdate, string todate, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList[] ReadByParam(Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int UpdateStatus(int YCKQID, int ISACTIVE, string ptoken);
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CRM_KQ_YCKQSMList))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_KQ_YCKQSM : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int yCKQIDField;
        
        private int sTAFFIDField;
        
        private string sMRField;
        
        private string sMRQField;
        
        private int sMSXBField;
        
        private string sMRBMLDField;
        
        private string sMRBMZGField;
        
        private string sMSXField;
        
        private int iSACTIVEField;
        
        private string bEIZField;
        
        private int kQQDIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int YCKQID {
            get {
                return this.yCKQIDField;
            }
            set {
                this.yCKQIDField = value;
                this.RaisePropertyChanged("YCKQID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int STAFFID {
            get {
                return this.sTAFFIDField;
            }
            set {
                this.sTAFFIDField = value;
                this.RaisePropertyChanged("STAFFID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SMR {
            get {
                return this.sMRField;
            }
            set {
                this.sMRField = value;
                this.RaisePropertyChanged("SMR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SMRQ {
            get {
                return this.sMRQField;
            }
            set {
                this.sMRQField = value;
                this.RaisePropertyChanged("SMRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int SMSXB {
            get {
                return this.sMSXBField;
            }
            set {
                this.sMSXBField = value;
                this.RaisePropertyChanged("SMSXB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string SMRBMLD {
            get {
                return this.sMRBMLDField;
            }
            set {
                this.sMRBMLDField = value;
                this.RaisePropertyChanged("SMRBMLD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string SMRBMZG {
            get {
                return this.sMRBMZGField;
            }
            set {
                this.sMRBMZGField = value;
                this.RaisePropertyChanged("SMRBMZG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string SMSX {
            get {
                return this.sMSXField;
            }
            set {
                this.sMSXField = value;
                this.RaisePropertyChanged("SMSX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int KQQDID {
            get {
                return this.kQQDIDField;
            }
            set {
                this.kQQDIDField = value;
                this.RaisePropertyChanged("KQQDID");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_KQ_YCKQList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string dATEField;
        
        private bool iSAMField;
        
        private bool iSQDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string DATE {
            get {
                return this.dATEField;
            }
            set {
                this.dATEField = value;
                this.RaisePropertyChanged("DATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public bool ISAM {
            get {
                return this.iSAMField;
            }
            set {
                this.iSAMField = value;
                this.RaisePropertyChanged("ISAM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool ISQD {
            get {
                return this.iSQDField;
            }
            set {
                this.iSQDField = value;
                this.RaisePropertyChanged("ISQD");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_KQ_YCKQSMList : CRM_KQ_YCKQSM {
        
        private string qDSJField;
        
        private string qDWZField;
        
        private string kQJLField;
        
        private string sMRQ_BEGINField;
        
        private string sMRQ_ENDField;
        
        private int dEPField;
        
        private string sTAFFNAMEField;
        
        private string sTAFFNOField;
        
        private string sTAFFTYPEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string QDSJ {
            get {
                return this.qDSJField;
            }
            set {
                this.qDSJField = value;
                this.RaisePropertyChanged("QDSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string QDWZ {
            get {
                return this.qDWZField;
            }
            set {
                this.qDWZField = value;
                this.RaisePropertyChanged("QDWZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string KQJL {
            get {
                return this.kQJLField;
            }
            set {
                this.kQJLField = value;
                this.RaisePropertyChanged("KQJL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SMRQ_BEGIN {
            get {
                return this.sMRQ_BEGINField;
            }
            set {
                this.sMRQ_BEGINField = value;
                this.RaisePropertyChanged("SMRQ_BEGIN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string SMRQ_END {
            get {
                return this.sMRQ_ENDField;
            }
            set {
                this.sMRQ_ENDField = value;
                this.RaisePropertyChanged("SMRQ_END");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int DEP {
            get {
                return this.dEPField;
            }
            set {
                this.dEPField = value;
                this.RaisePropertyChanged("DEP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string STAFFNAME {
            get {
                return this.sTAFFNAMEField;
            }
            set {
                this.sTAFFNAMEField = value;
                this.RaisePropertyChanged("STAFFNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string STAFFNO {
            get {
                return this.sTAFFNOField;
            }
            set {
                this.sTAFFNOField = value;
                this.RaisePropertyChanged("STAFFNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string STAFFTYPE {
            get {
                return this.sTAFFTYPEField;
            }
            set {
                this.sTAFFTYPEField = value;
                this.RaisePropertyChanged("STAFFTYPE");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface KQ_YCKQSMSoapChannel : Sonluk.UI.Model.CRM.KQ_YCKQSMService.KQ_YCKQSMSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KQ_YCKQSMSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.KQ_YCKQSMService.KQ_YCKQSMSoap>, Sonluk.UI.Model.CRM.KQ_YCKQSMService.KQ_YCKQSMSoap {
        
        public KQ_YCKQSMSoapClient() {
        }
        
        public KQ_YCKQSMSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KQ_YCKQSMSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KQ_YCKQSMSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KQ_YCKQSMSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSM model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSM model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList[] ReadBySTAFFID(int STAFFID, string ptoken) {
            return base.Channel.ReadBySTAFFID(STAFFID, ptoken);
        }
        
        public int Delete(int YCKQID, string ptoken) {
            return base.Channel.Delete(YCKQID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQList[] Report_YC(int STAFFID, string fromdate, string todate, string ptoken) {
            return base.Channel.Report_YC(STAFFID, fromdate, todate, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList[] ReadByParam(Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int UpdateStatus(int YCKQID, int ISACTIVE, string ptoken) {
            return base.Channel.UpdateStatus(YCKQID, ISACTIVE, ptoken);
        }
    }
}
