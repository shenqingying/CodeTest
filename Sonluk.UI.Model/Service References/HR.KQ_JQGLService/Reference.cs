﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.HR.KQ_JQGLService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HR.KQ_JQGLService.WS_HR_KQ_JQGLSoap")]
    public interface WS_HR_KQ_JQGLSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.KQ_JQGLService.MES_RETURN INSERT(Sonluk.UI.Model.HR.KQ_JQGLService.HR_KQ_JQGL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.KQ_JQGLService.MES_RETURN UPDATE(Sonluk.UI.Model.HR.KQ_JQGLService.HR_KQ_JQGL model, int LB, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.KQ_JQGLService.HR_KQ_JQGL_SELECT SELECT(Sonluk.UI.Model.HR.KQ_JQGLService.HR_KQ_JQGL model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_KQ_JQGL : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int jQGLIDField;
        
        private string kQYEARField;
        
        private string kQMONTHField;
        
        private int iSCLField;
        
        private string cLRQField;
        
        private string kQZQKSField;
        
        private string kQZQJSField;
        
        private string kQNAMEField;
        
        private string gsField;
        
        private int sTAFFIDField;
        
        private int cJRField;
        
        private int xGRField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int JQGLID {
            get {
                return this.jQGLIDField;
            }
            set {
                this.jQGLIDField = value;
                this.RaisePropertyChanged("JQGLID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string KQYEAR {
            get {
                return this.kQYEARField;
            }
            set {
                this.kQYEARField = value;
                this.RaisePropertyChanged("KQYEAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string KQMONTH {
            get {
                return this.kQMONTHField;
            }
            set {
                this.kQMONTHField = value;
                this.RaisePropertyChanged("KQMONTH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int ISCL {
            get {
                return this.iSCLField;
            }
            set {
                this.iSCLField = value;
                this.RaisePropertyChanged("ISCL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string CLRQ {
            get {
                return this.cLRQField;
            }
            set {
                this.cLRQField = value;
                this.RaisePropertyChanged("CLRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string KQZQKS {
            get {
                return this.kQZQKSField;
            }
            set {
                this.kQZQKSField = value;
                this.RaisePropertyChanged("KQZQKS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string KQZQJS {
            get {
                return this.kQZQJSField;
            }
            set {
                this.kQZQJSField = value;
                this.RaisePropertyChanged("KQZQJS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string KQNAME {
            get {
                return this.kQNAMEField;
            }
            set {
                this.kQNAMEField = value;
                this.RaisePropertyChanged("KQNAME");
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
        public int XGR {
            get {
                return this.xGRField;
            }
            set {
                this.xGRField = value;
                this.RaisePropertyChanged("XGR");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_KQ_JQGL_LIST : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int jQGLIDField;
        
        private string kQYEARField;
        
        private string kQMONTHField;
        
        private int iSCLField;
        
        private string cLRQField;
        
        private string kQZQKSField;
        
        private string kQZQJSField;
        
        private string kQNAMEField;
        
        private string gsField;
        
        private string gSNAMEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int JQGLID {
            get {
                return this.jQGLIDField;
            }
            set {
                this.jQGLIDField = value;
                this.RaisePropertyChanged("JQGLID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string KQYEAR {
            get {
                return this.kQYEARField;
            }
            set {
                this.kQYEARField = value;
                this.RaisePropertyChanged("KQYEAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string KQMONTH {
            get {
                return this.kQMONTHField;
            }
            set {
                this.kQMONTHField = value;
                this.RaisePropertyChanged("KQMONTH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int ISCL {
            get {
                return this.iSCLField;
            }
            set {
                this.iSCLField = value;
                this.RaisePropertyChanged("ISCL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string CLRQ {
            get {
                return this.cLRQField;
            }
            set {
                this.cLRQField = value;
                this.RaisePropertyChanged("CLRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string KQZQKS {
            get {
                return this.kQZQKSField;
            }
            set {
                this.kQZQKSField = value;
                this.RaisePropertyChanged("KQZQKS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string KQZQJS {
            get {
                return this.kQZQJSField;
            }
            set {
                this.kQZQJSField = value;
                this.RaisePropertyChanged("KQZQJS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string KQNAME {
            get {
                return this.kQNAMEField;
            }
            set {
                this.kQNAMEField = value;
                this.RaisePropertyChanged("KQNAME");
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
        public string GSNAME {
            get {
                return this.gSNAMEField;
            }
            set {
                this.gSNAMEField = value;
                this.RaisePropertyChanged("GSNAME");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_KQ_JQGL_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private HR_KQ_JQGL_LIST[] hR_KQ_JQGL_LISTField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public HR_KQ_JQGL_LIST[] HR_KQ_JQGL_LIST {
            get {
                return this.hR_KQ_JQGL_LISTField;
            }
            set {
                this.hR_KQ_JQGL_LISTField = value;
                this.RaisePropertyChanged("HR_KQ_JQGL_LIST");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
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
    public interface WS_HR_KQ_JQGLSoapChannel : Sonluk.UI.Model.HR.KQ_JQGLService.WS_HR_KQ_JQGLSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_HR_KQ_JQGLSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.HR.KQ_JQGLService.WS_HR_KQ_JQGLSoap>, Sonluk.UI.Model.HR.KQ_JQGLService.WS_HR_KQ_JQGLSoap {
        
        public WS_HR_KQ_JQGLSoapClient() {
        }
        
        public WS_HR_KQ_JQGLSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_HR_KQ_JQGLSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_HR_KQ_JQGLSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_HR_KQ_JQGLSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.HR.KQ_JQGLService.MES_RETURN INSERT(Sonluk.UI.Model.HR.KQ_JQGLService.HR_KQ_JQGL model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.KQ_JQGLService.MES_RETURN UPDATE(Sonluk.UI.Model.HR.KQ_JQGLService.HR_KQ_JQGL model, int LB, string ptoken) {
            return base.Channel.UPDATE(model, LB, ptoken);
        }
        
        public Sonluk.UI.Model.HR.KQ_JQGLService.HR_KQ_JQGL_SELECT SELECT(Sonluk.UI.Model.HR.KQ_JQGLService.HR_KQ_JQGL model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
    }
}
