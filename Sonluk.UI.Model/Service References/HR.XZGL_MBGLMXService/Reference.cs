﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.HR.XZGL_MBGLMXService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HR.XZGL_MBGLMXService.WS_HR_XZGL_MBGLMXSoap")]
    public interface WS_HR_XZGL_MBGLMXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_MBGLMXService.MES_RETURN INSERT(Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_MBGLMXService.MES_RETURN UPDATE(Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX model, int LB, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX_SELECT SELECT(Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_LAY", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX_SELECT SELECT_LAY(Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_MBGLMX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool lAY_CHECKEDField;
        
        private int mBIDField;
        
        private int zDIDField;
        
        private int pXMField;
        
        private string fFJLZDMSField;
        
        private string fFJLZDNAMEField;
        
        private int iSHAVEGSField;
        
        private int mXIDField;
        
        private string fORMULAField;
        
        private int jSLEVELField;
        
        private int jSORDERField;
        
        private int xSBLGZField;
        
        private int yXXSWField;
        
        private int mBMXIDField;
        
        private string xSBLGZNAMEField;
        
        private int iSGDZDField;
        
        private int pRINTCDField;
        
        private int iSFIXEDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool LAY_CHECKED {
            get {
                return this.lAY_CHECKEDField;
            }
            set {
                this.lAY_CHECKEDField = value;
                this.RaisePropertyChanged("LAY_CHECKED");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int ZDID {
            get {
                return this.zDIDField;
            }
            set {
                this.zDIDField = value;
                this.RaisePropertyChanged("ZDID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int PXM {
            get {
                return this.pXMField;
            }
            set {
                this.pXMField = value;
                this.RaisePropertyChanged("PXM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string FFJLZDMS {
            get {
                return this.fFJLZDMSField;
            }
            set {
                this.fFJLZDMSField = value;
                this.RaisePropertyChanged("FFJLZDMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int ISHAVEGS {
            get {
                return this.iSHAVEGSField;
            }
            set {
                this.iSHAVEGSField = value;
                this.RaisePropertyChanged("ISHAVEGS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string FORMULA {
            get {
                return this.fORMULAField;
            }
            set {
                this.fORMULAField = value;
                this.RaisePropertyChanged("FORMULA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int JSLEVEL {
            get {
                return this.jSLEVELField;
            }
            set {
                this.jSLEVELField = value;
                this.RaisePropertyChanged("JSLEVEL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int JSORDER {
            get {
                return this.jSORDERField;
            }
            set {
                this.jSORDERField = value;
                this.RaisePropertyChanged("JSORDER");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int XSBLGZ {
            get {
                return this.xSBLGZField;
            }
            set {
                this.xSBLGZField = value;
                this.RaisePropertyChanged("XSBLGZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int YXXSW {
            get {
                return this.yXXSWField;
            }
            set {
                this.yXXSWField = value;
                this.RaisePropertyChanged("YXXSW");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public int MBMXID {
            get {
                return this.mBMXIDField;
            }
            set {
                this.mBMXIDField = value;
                this.RaisePropertyChanged("MBMXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string XSBLGZNAME {
            get {
                return this.xSBLGZNAMEField;
            }
            set {
                this.xSBLGZNAMEField = value;
                this.RaisePropertyChanged("XSBLGZNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public int ISGDZD {
            get {
                return this.iSGDZDField;
            }
            set {
                this.iSGDZDField = value;
                this.RaisePropertyChanged("ISGDZD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public int PRINTCD {
            get {
                return this.pRINTCDField;
            }
            set {
                this.pRINTCDField = value;
                this.RaisePropertyChanged("PRINTCD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int ISFIXED {
            get {
                return this.iSFIXEDField;
            }
            set {
                this.iSFIXEDField = value;
                this.RaisePropertyChanged("ISFIXED");
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
    public partial class HR_XZGL_MBGLMX_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private HR_XZGL_MBGLMX[] hR_XZGL_MBGLMXField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public HR_XZGL_MBGLMX[] HR_XZGL_MBGLMX {
            get {
                return this.hR_XZGL_MBGLMXField;
            }
            set {
                this.hR_XZGL_MBGLMXField = value;
                this.RaisePropertyChanged("HR_XZGL_MBGLMX");
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
    public interface WS_HR_XZGL_MBGLMXSoapChannel : Sonluk.UI.Model.HR.XZGL_MBGLMXService.WS_HR_XZGL_MBGLMXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_HR_XZGL_MBGLMXSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.HR.XZGL_MBGLMXService.WS_HR_XZGL_MBGLMXSoap>, Sonluk.UI.Model.HR.XZGL_MBGLMXService.WS_HR_XZGL_MBGLMXSoap {
        
        public WS_HR_XZGL_MBGLMXSoapClient() {
        }
        
        public WS_HR_XZGL_MBGLMXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_HR_XZGL_MBGLMXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_HR_XZGL_MBGLMXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_HR_XZGL_MBGLMXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.HR.XZGL_MBGLMXService.MES_RETURN INSERT(Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_MBGLMXService.MES_RETURN UPDATE(Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX model, int LB, string ptoken) {
            return base.Channel.UPDATE(model, LB, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX_SELECT SELECT(Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX_SELECT SELECT_LAY(Sonluk.UI.Model.HR.XZGL_MBGLMXService.HR_XZGL_MBGLMX model, string ptoken) {
            return base.Channel.SELECT_LAY(model, ptoken);
        }
    }
}
