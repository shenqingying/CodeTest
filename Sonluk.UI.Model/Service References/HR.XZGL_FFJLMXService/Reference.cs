﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.HR.XZGL_FFJLMXService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HR.XZGL_FFJLMXService.WS_HR_XZGL_FFJLMXSoap")]
    public interface WS_HR_XZGL_FFJLMXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN INSERT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN UPDATE(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FORMULA_JS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN FORMULA_JS(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FORMULA_JS_TZ", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN FORMULA_JS_TZ(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AUTO_ADD_TO_FFJLMX_OTHER", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN AUTO_ADD_TO_FFJLMX_OTHER(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_GSREPORT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_GSREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_FFMXREPORT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_FFMXREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_GZXJSDREPORT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_GZXJSDREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_FFMXGZDREPORT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZDREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_FFMXGZHZREPORT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZHZREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_FFMXTXFREPORT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_FFMXTXFREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_GUOSHUIREPORT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_GUOSHUIREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_FFJLMX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int fFJLIDField;
        
        private int rYIDField;
        
        private int fFJLMXIDField;
        
        private string fFJLZDNAMEField;
        
        private decimal zDVALUEField;
        
        private string mYPWField;
        
        private string kSMONTHField;
        
        private string jSMONTHField;
        
        private string gsField;
        
        private string sEARCHINFOField;
        
        private string sXDATEField;
        
        private string ghField;
        
        private int sTAFFIDField;
        
        private string dEPTNAMEField;
        
        private int mBIDField;
        
        private string yGTYPENAMEField;
        
        private int fFLYField;
        
        private int zHLBField;
        
        private System.Data.DataTable rYLISTField;
        
        private int iSJSSEField;
        
        private int gSLBField;
        
        private int jSFSField;
        
        private System.Data.DataTable fFJLMXLISTField;
        
        private int pXLBField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int FFJLID {
            get {
                return this.fFJLIDField;
            }
            set {
                this.fFJLIDField = value;
                this.RaisePropertyChanged("FFJLID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int RYID {
            get {
                return this.rYIDField;
            }
            set {
                this.rYIDField = value;
                this.RaisePropertyChanged("RYID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int FFJLMXID {
            get {
                return this.fFJLMXIDField;
            }
            set {
                this.fFJLMXIDField = value;
                this.RaisePropertyChanged("FFJLMXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string FFJLZDNAME {
            get {
                return this.fFJLZDNAMEField;
            }
            set {
                this.fFJLZDNAMEField = value;
                this.RaisePropertyChanged("FFJLZDNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public decimal ZDVALUE {
            get {
                return this.zDVALUEField;
            }
            set {
                this.zDVALUEField = value;
                this.RaisePropertyChanged("ZDVALUE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string MYPW {
            get {
                return this.mYPWField;
            }
            set {
                this.mYPWField = value;
                this.RaisePropertyChanged("MYPW");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string KSMONTH {
            get {
                return this.kSMONTHField;
            }
            set {
                this.kSMONTHField = value;
                this.RaisePropertyChanged("KSMONTH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string JSMONTH {
            get {
                return this.jSMONTHField;
            }
            set {
                this.jSMONTHField = value;
                this.RaisePropertyChanged("JSMONTH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string GS {
            get {
                return this.gsField;
            }
            set {
                this.gsField = value;
                this.RaisePropertyChanged("GS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string SEARCHINFO {
            get {
                return this.sEARCHINFOField;
            }
            set {
                this.sEARCHINFOField = value;
                this.RaisePropertyChanged("SEARCHINFO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string SXDATE {
            get {
                return this.sXDATEField;
            }
            set {
                this.sXDATEField = value;
                this.RaisePropertyChanged("SXDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string GH {
            get {
                return this.ghField;
            }
            set {
                this.ghField = value;
                this.RaisePropertyChanged("GH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string DEPTNAME {
            get {
                return this.dEPTNAMEField;
            }
            set {
                this.dEPTNAMEField = value;
                this.RaisePropertyChanged("DEPTNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public int MBID {
            get {
                return this.mBIDField;
            }
            set {
                this.mBIDField = value;
                this.RaisePropertyChanged("MBID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string YGTYPENAME {
            get {
                return this.yGTYPENAMEField;
            }
            set {
                this.yGTYPENAMEField = value;
                this.RaisePropertyChanged("YGTYPENAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public int FFLY {
            get {
                return this.fFLYField;
            }
            set {
                this.fFLYField = value;
                this.RaisePropertyChanged("FFLY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int ZHLB {
            get {
                return this.zHLBField;
            }
            set {
                this.zHLBField = value;
                this.RaisePropertyChanged("ZHLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public System.Data.DataTable RYLIST {
            get {
                return this.rYLISTField;
            }
            set {
                this.rYLISTField = value;
                this.RaisePropertyChanged("RYLIST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public int ISJSSE {
            get {
                return this.iSJSSEField;
            }
            set {
                this.iSJSSEField = value;
                this.RaisePropertyChanged("ISJSSE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public int GSLB {
            get {
                return this.gSLBField;
            }
            set {
                this.gSLBField = value;
                this.RaisePropertyChanged("GSLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public int JSFS {
            get {
                return this.jSFSField;
            }
            set {
                this.jSFSField = value;
                this.RaisePropertyChanged("JSFS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public System.Data.DataTable FFJLMXLIST {
            get {
                return this.fFJLMXLISTField;
            }
            set {
                this.fFJLMXLISTField = value;
                this.RaisePropertyChanged("FFJLMXLIST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public int PXLB {
            get {
                return this.pXLBField;
            }
            set {
                this.pXLBField = value;
                this.RaisePropertyChanged("PXLB");
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
    public partial class HR_XZGL_FFJLMX_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Data.DataTable dATALISTField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.Data.DataTable DATALIST {
            get {
                return this.dATALISTField;
            }
            set {
                this.dATALISTField = value;
                this.RaisePropertyChanged("DATALIST");
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
    public interface WS_HR_XZGL_FFJLMXSoapChannel : Sonluk.UI.Model.HR.XZGL_FFJLMXService.WS_HR_XZGL_FFJLMXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_HR_XZGL_FFJLMXSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.HR.XZGL_FFJLMXService.WS_HR_XZGL_FFJLMXSoap>, Sonluk.UI.Model.HR.XZGL_FFJLMXService.WS_HR_XZGL_FFJLMXSoap {
        
        public WS_HR_XZGL_FFJLMXSoapClient() {
        }
        
        public WS_HR_XZGL_FFJLMXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_HR_XZGL_FFJLMXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_HR_XZGL_FFJLMXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_HR_XZGL_FFJLMXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN INSERT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN UPDATE(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken) {
            return base.Channel.UPDATE(model, LB, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken) {
            return base.Channel.SELECT(model, LB, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN FORMULA_JS(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken) {
            return base.Channel.FORMULA_JS(model, LB, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN FORMULA_JS_TZ(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken) {
            return base.Channel.FORMULA_JS_TZ(model, LB, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.MES_RETURN AUTO_ADD_TO_FFJLMX_OTHER(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken) {
            return base.Channel.AUTO_ADD_TO_FFJLMX_OTHER(model, LB, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_GSREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken) {
            return base.Channel.SELECT_GSREPORT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_FFMXREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken) {
            return base.Channel.SELECT_FFMXREPORT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_GZXJSDREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken) {
            return base.Channel.SELECT_GZXJSDREPORT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZDREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken) {
            return base.Channel.SELECT_FFMXGZDREPORT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZHZREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken) {
            return base.Channel.SELECT_FFMXGZHZREPORT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_FFMXTXFREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, int LB, string ptoken) {
            return base.Channel.SELECT_FFMXTXFREPORT(model, LB, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX_SELECT SELECT_GUOSHUIREPORT(Sonluk.UI.Model.HR.XZGL_FFJLMXService.HR_XZGL_FFJLMX model, string ptoken) {
            return base.Channel.SELECT_GUOSHUIREPORT(model, ptoken);
        }
    }
}
