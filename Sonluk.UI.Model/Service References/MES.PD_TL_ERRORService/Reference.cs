﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.PD_TL_ERRORService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.PD_TL_ERRORService.PD_TL_ERRORSoap")]
    public interface PD_TL_ERRORSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.PD_TL_ERRORService.MES_PD_TL_ERROR_SELECT SELECT(Sonluk.UI.Model.MES.PD_TL_ERRORService.MES_PD_TL_ERROR model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_PD_TL_ERROR : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string rWBHField;
        
        private string tmField;
        
        private int jLRField;
        
        private string jLSJField;
        
        private string jLSJ_KSField;
        
        private string jLSJ_JSField;
        
        private string eRRORINFOField;
        
        private string gcField;
        
        private string gZZXBHField;
        
        private string sBBHField;
        
        private string sCDATEField;
        
        private int wLLBField;
        
        private int tLLBField;
        
        private string sCDATESField;
        
        private string sCDATEEField;
        
        private int sTAFFIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string RWBH {
            get {
                return this.rWBHField;
            }
            set {
                this.rWBHField = value;
                this.RaisePropertyChanged("RWBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string JLSJ {
            get {
                return this.jLSJField;
            }
            set {
                this.jLSJField = value;
                this.RaisePropertyChanged("JLSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string JLSJ_KS {
            get {
                return this.jLSJ_KSField;
            }
            set {
                this.jLSJ_KSField = value;
                this.RaisePropertyChanged("JLSJ_KS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string JLSJ_JS {
            get {
                return this.jLSJ_JSField;
            }
            set {
                this.jLSJ_JSField = value;
                this.RaisePropertyChanged("JLSJ_JS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string SCDATE {
            get {
                return this.sCDATEField;
            }
            set {
                this.sCDATEField = value;
                this.RaisePropertyChanged("SCDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int WLLB {
            get {
                return this.wLLBField;
            }
            set {
                this.wLLBField = value;
                this.RaisePropertyChanged("WLLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public int TLLB {
            get {
                return this.tLLBField;
            }
            set {
                this.tLLBField = value;
                this.RaisePropertyChanged("TLLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string SCDATES {
            get {
                return this.sCDATESField;
            }
            set {
                this.sCDATESField = value;
                this.RaisePropertyChanged("SCDATES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string SCDATEE {
            get {
                return this.sCDATEEField;
            }
            set {
                this.sCDATEEField = value;
                this.RaisePropertyChanged("SCDATEE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public int STAFFID {
            get {
                return this.sTAFFIDField;
            }
            set {
                this.sTAFFIDField = value;
                this.RaisePropertyChanged("STAFFID");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_PD_TL_ERROR_LIST : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gcField;
        
        private string gCNAMEField;
        
        private string rWBHField;
        
        private string wLHField;
        
        private string wLMSField;
        
        private string wLLBNAMEField;
        
        private string gZZXBHField;
        
        private string gZZXNAMEField;
        
        private string sBNAMEField;
        
        private string zPRQField;
        
        private string eRRORTMField;
        
        private string eRRORWLHField;
        
        private string eRRORWLNAMEField;
        
        private string eRRORINFOField;
        
        private string eRRORPCField;
        
        private string eRRORJLSJField;
        
        private string eRRORJLRField;
        
        private int tLLBField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string GCNAME {
            get {
                return this.gCNAMEField;
            }
            set {
                this.gCNAMEField = value;
                this.RaisePropertyChanged("GCNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string RWBH {
            get {
                return this.rWBHField;
            }
            set {
                this.rWBHField = value;
                this.RaisePropertyChanged("RWBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string WLLBNAME {
            get {
                return this.wLLBNAMEField;
            }
            set {
                this.wLLBNAMEField = value;
                this.RaisePropertyChanged("WLLBNAME");
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
        public string GZZXNAME {
            get {
                return this.gZZXNAMEField;
            }
            set {
                this.gZZXNAMEField = value;
                this.RaisePropertyChanged("GZZXNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string SBNAME {
            get {
                return this.sBNAMEField;
            }
            set {
                this.sBNAMEField = value;
                this.RaisePropertyChanged("SBNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string ZPRQ {
            get {
                return this.zPRQField;
            }
            set {
                this.zPRQField = value;
                this.RaisePropertyChanged("ZPRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string ERRORWLH {
            get {
                return this.eRRORWLHField;
            }
            set {
                this.eRRORWLHField = value;
                this.RaisePropertyChanged("ERRORWLH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string ERRORWLNAME {
            get {
                return this.eRRORWLNAMEField;
            }
            set {
                this.eRRORWLNAMEField = value;
                this.RaisePropertyChanged("ERRORWLNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string ERRORPC {
            get {
                return this.eRRORPCField;
            }
            set {
                this.eRRORPCField = value;
                this.RaisePropertyChanged("ERRORPC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string ERRORJLSJ {
            get {
                return this.eRRORJLSJField;
            }
            set {
                this.eRRORJLSJField = value;
                this.RaisePropertyChanged("ERRORJLSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string ERRORJLR {
            get {
                return this.eRRORJLRField;
            }
            set {
                this.eRRORJLRField = value;
                this.RaisePropertyChanged("ERRORJLR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int TLLB {
            get {
                return this.tLLBField;
            }
            set {
                this.tLLBField = value;
                this.RaisePropertyChanged("TLLB");
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
    public partial class MES_PD_TL_ERROR_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_PD_TL_ERROR_LIST[] mES_PD_TL_ERROR_LISTField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_PD_TL_ERROR_LIST[] MES_PD_TL_ERROR_LIST {
            get {
                return this.mES_PD_TL_ERROR_LISTField;
            }
            set {
                this.mES_PD_TL_ERROR_LISTField = value;
                this.RaisePropertyChanged("MES_PD_TL_ERROR_LIST");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PD_TL_ERRORSoapChannel : Sonluk.UI.Model.MES.PD_TL_ERRORService.PD_TL_ERRORSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PD_TL_ERRORSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.PD_TL_ERRORService.PD_TL_ERRORSoap>, Sonluk.UI.Model.MES.PD_TL_ERRORService.PD_TL_ERRORSoap {
        
        public PD_TL_ERRORSoapClient() {
        }
        
        public PD_TL_ERRORSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PD_TL_ERRORSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PD_TL_ERRORSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PD_TL_ERRORSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.PD_TL_ERRORService.MES_PD_TL_ERROR_SELECT SELECT(Sonluk.UI.Model.MES.PD_TL_ERRORService.MES_PD_TL_ERROR model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
    }
}