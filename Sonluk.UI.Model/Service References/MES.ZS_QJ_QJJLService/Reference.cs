﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.ZS_QJ_QJJLService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.ZS_QJ_QJJLService.WS_MES_ZS_QJ_QJJLSoap")]
    public interface WS_MES_ZS_QJ_QJJLSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_RETURN INSERT(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_QJJL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_QJSB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_RETURN INSERT_QJSB(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_QJSB model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_QJSB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_QJSB_SELECT SELECT_QJSB(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_QJSB model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_ERRORJL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_RETURN INSERT_ERRORJL(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_ERRORJL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_ERRORJL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_ERRORJL_SELECT SELECT_ERRORJL(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_ERRORJL model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_QJ_QJJL : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string tmField;
        
        private string cZRGHField;
        
        private string cZRNAMEField;
        
        private string qJJSBBHField;
        
        private string qJJSBMSField;
        
        private int cJRField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CZRGH {
            get {
                return this.cZRGHField;
            }
            set {
                this.cZRGHField = value;
                this.RaisePropertyChanged("CZRGH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CZRNAME {
            get {
                return this.cZRNAMEField;
            }
            set {
                this.cZRNAMEField = value;
                this.RaisePropertyChanged("CZRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string QJJSBBH {
            get {
                return this.qJJSBBHField;
            }
            set {
                this.qJJSBBHField = value;
                this.RaisePropertyChanged("QJJSBBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string QJJSBMS {
            get {
                return this.qJJSBMSField;
            }
            set {
                this.qJJSBMSField = value;
                this.RaisePropertyChanged("QJJSBMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int CJR {
            get {
                return this.cJRField;
            }
            set {
                this.cJRField = value;
                this.RaisePropertyChanged("CJR");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_QJ_ERRORJL_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_ZS_QJ_ERRORJL[] mES_ZS_QJ_ERRORJLField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_ZS_QJ_ERRORJL[] MES_ZS_QJ_ERRORJL {
            get {
                return this.mES_ZS_QJ_ERRORJLField;
            }
            set {
                this.mES_ZS_QJ_ERRORJLField = value;
                this.RaisePropertyChanged("MES_ZS_QJ_ERRORJL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public MES_RETURN MES_RETURN {
            get {
                return this.mES_RETURNField;
            }
            set {
                this.mES_RETURNField = value;
                this.RaisePropertyChanged("MES_RETURN");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_QJ_ERRORJL : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string eRRORTMField;
        
        private string eRRORSBBHField;
        
        private string eRRORINFOField;
        
        private int cJRField;
        
        private string cJRNAMEField;
        
        private string gcField;
        
        private string gZZXBHField;
        
        private string sBMSField;
        
        private int lbField;
        
        private string kSTIMEField;
        
        private string jSTIMEField;
        
        private int sTAFFIDField;
        
        private string cJTIMEField;
        
        private string cZRGHField;
        
        private string cZRNAMEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ERRORTM {
            get {
                return this.eRRORTMField;
            }
            set {
                this.eRRORTMField = value;
                this.RaisePropertyChanged("ERRORTM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ERRORSBBH {
            get {
                return this.eRRORSBBHField;
            }
            set {
                this.eRRORSBBHField = value;
                this.RaisePropertyChanged("ERRORSBBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ERRORINFO {
            get {
                return this.eRRORINFOField;
            }
            set {
                this.eRRORINFOField = value;
                this.RaisePropertyChanged("ERRORINFO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string GZZXBH {
            get {
                return this.gZZXBHField;
            }
            set {
                this.gZZXBHField = value;
                this.RaisePropertyChanged("GZZXBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string SBMS {
            get {
                return this.sBMSField;
            }
            set {
                this.sBMSField = value;
                this.RaisePropertyChanged("SBMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int LB {
            get {
                return this.lbField;
            }
            set {
                this.lbField = value;
                this.RaisePropertyChanged("LB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string KSTIME {
            get {
                return this.kSTIMEField;
            }
            set {
                this.kSTIMEField = value;
                this.RaisePropertyChanged("KSTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string JSTIME {
            get {
                return this.jSTIMEField;
            }
            set {
                this.jSTIMEField = value;
                this.RaisePropertyChanged("JSTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string CJTIME {
            get {
                return this.cJTIMEField;
            }
            set {
                this.cJTIMEField = value;
                this.RaisePropertyChanged("CJTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string CZRGH {
            get {
                return this.cZRGHField;
            }
            set {
                this.cZRGHField = value;
                this.RaisePropertyChanged("CZRGH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string CZRNAME {
            get {
                return this.cZRNAMEField;
            }
            set {
                this.cZRNAMEField = value;
                this.RaisePropertyChanged("CZRNAME");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_QJ_QJSB_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_ZS_QJ_QJSB[] mES_ZS_QJ_QJSBField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_ZS_QJ_QJSB[] MES_ZS_QJ_QJSB {
            get {
                return this.mES_ZS_QJ_QJSBField;
            }
            set {
                this.mES_ZS_QJ_QJSBField = value;
                this.RaisePropertyChanged("MES_ZS_QJ_QJSB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public MES_RETURN MES_RETURN {
            get {
                return this.mES_RETURNField;
            }
            set {
                this.mES_RETURNField = value;
                this.RaisePropertyChanged("MES_RETURN");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_QJ_QJSB : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string sBBHField;
        
        private string gcField;
        
        private string gZZXBHField;
        
        private int iSFREEField;
        
        private string sCSMTMField;
        
        private string kSTIMEField;
        
        private string cZRGHField;
        
        private string cZRNAMEField;
        
        private int lbField;
        
        private string mOULDField;
        
        private string wLHField;
        
        private string wLMSField;
        
        private string tMKSTIMEField;
        
        private string tMJSTIMEField;
        
        private string sBMSField;
        
        private int jLRField;
        
        private string sBFLNAMEField;
        
        private int cZLBField;
        
        private string tMSTRField;
        
        private int qJZTField;
        
        private int jLMXIDField;
        
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string GZZXBH {
            get {
                return this.gZZXBHField;
            }
            set {
                this.gZZXBHField = value;
                this.RaisePropertyChanged("GZZXBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int ISFREE {
            get {
                return this.iSFREEField;
            }
            set {
                this.iSFREEField = value;
                this.RaisePropertyChanged("ISFREE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string SCSMTM {
            get {
                return this.sCSMTMField;
            }
            set {
                this.sCSMTMField = value;
                this.RaisePropertyChanged("SCSMTM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string KSTIME {
            get {
                return this.kSTIMEField;
            }
            set {
                this.kSTIMEField = value;
                this.RaisePropertyChanged("KSTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string CZRGH {
            get {
                return this.cZRGHField;
            }
            set {
                this.cZRGHField = value;
                this.RaisePropertyChanged("CZRGH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CZRNAME {
            get {
                return this.cZRNAMEField;
            }
            set {
                this.cZRNAMEField = value;
                this.RaisePropertyChanged("CZRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int LB {
            get {
                return this.lbField;
            }
            set {
                this.lbField = value;
                this.RaisePropertyChanged("LB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string MOULD {
            get {
                return this.mOULDField;
            }
            set {
                this.mOULDField = value;
                this.RaisePropertyChanged("MOULD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string WLH {
            get {
                return this.wLHField;
            }
            set {
                this.wLHField = value;
                this.RaisePropertyChanged("WLH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string WLMS {
            get {
                return this.wLMSField;
            }
            set {
                this.wLMSField = value;
                this.RaisePropertyChanged("WLMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string TMKSTIME {
            get {
                return this.tMKSTIMEField;
            }
            set {
                this.tMKSTIMEField = value;
                this.RaisePropertyChanged("TMKSTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string TMJSTIME {
            get {
                return this.tMJSTIMEField;
            }
            set {
                this.tMJSTIMEField = value;
                this.RaisePropertyChanged("TMJSTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string SBMS {
            get {
                return this.sBMSField;
            }
            set {
                this.sBMSField = value;
                this.RaisePropertyChanged("SBMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public int JLR {
            get {
                return this.jLRField;
            }
            set {
                this.jLRField = value;
                this.RaisePropertyChanged("JLR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string SBFLNAME {
            get {
                return this.sBFLNAMEField;
            }
            set {
                this.sBFLNAMEField = value;
                this.RaisePropertyChanged("SBFLNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int CZLB {
            get {
                return this.cZLBField;
            }
            set {
                this.cZLBField = value;
                this.RaisePropertyChanged("CZLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string TMSTR {
            get {
                return this.tMSTRField;
            }
            set {
                this.tMSTRField = value;
                this.RaisePropertyChanged("TMSTR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public int QJZT {
            get {
                return this.qJZTField;
            }
            set {
                this.qJZTField = value;
                this.RaisePropertyChanged("QJZT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public int JLMXID {
            get {
                return this.jLMXIDField;
            }
            set {
                this.jLMXIDField = value;
                this.RaisePropertyChanged("JLMXID");
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
    public interface WS_MES_ZS_QJ_QJJLSoapChannel : Sonluk.UI.Model.MES.ZS_QJ_QJJLService.WS_MES_ZS_QJ_QJJLSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_MES_ZS_QJ_QJJLSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.ZS_QJ_QJJLService.WS_MES_ZS_QJ_QJJLSoap>, Sonluk.UI.Model.MES.ZS_QJ_QJJLService.WS_MES_ZS_QJ_QJJLSoap {
        
        public WS_MES_ZS_QJ_QJJLSoapClient() {
        }
        
        public WS_MES_ZS_QJ_QJJLSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_MES_ZS_QJ_QJJLSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_MES_ZS_QJ_QJJLSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_MES_ZS_QJ_QJJLSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_RETURN INSERT(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_QJJL model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_RETURN INSERT_QJSB(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_QJSB model, string ptoken) {
            return base.Channel.INSERT_QJSB(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_QJSB_SELECT SELECT_QJSB(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_QJSB model, string ptoken) {
            return base.Channel.SELECT_QJSB(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_RETURN INSERT_ERRORJL(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_ERRORJL model, string ptoken) {
            return base.Channel.INSERT_ERRORJL(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_ERRORJL_SELECT SELECT_ERRORJL(Sonluk.UI.Model.MES.ZS_QJ_QJJLService.MES_ZS_QJ_ERRORJL model, string ptoken) {
            return base.Channel.SELECT_ERRORJL(model, ptoken);
        }
    }
}
