﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.MES_LoginService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.MES_LoginService.MES_LoginSoap")]
    public interface MES_LoginSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_LoginService.MES_LoginINFO Login(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login_language", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_LoginService.MES_LoginINFO Login_language(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID, int LANGUAGEID);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_LoginINFO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private TokenInfo tokenInfoField;
        
        private CRM_JURISDICTION_GROUP[] jURISDICTION_GROUPField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public TokenInfo TokenInfo {
            get {
                return this.tokenInfoField;
            }
            set {
                this.tokenInfoField = value;
                this.RaisePropertyChanged("TokenInfo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public CRM_JURISDICTION_GROUP[] JURISDICTION_GROUP {
            get {
                return this.jURISDICTION_GROUPField;
            }
            set {
                this.jURISDICTION_GROUPField = value;
                this.RaisePropertyChanged("JURISDICTION_GROUP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
    public partial class TokenInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string access_tokenField;
        
        private string expires_inField;
        
        private string mSGField;
        
        private string mESSAGEField;
        
        private int sTAFFIDField;
        
        private string tOKENIDField;
        
        private int lANGUAGEIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string access_token {
            get {
                return this.access_tokenField;
            }
            set {
                this.access_tokenField = value;
                this.RaisePropertyChanged("access_token");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string expires_in {
            get {
                return this.expires_inField;
            }
            set {
                this.expires_inField = value;
                this.RaisePropertyChanged("expires_in");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string MSG {
            get {
                return this.mSGField;
            }
            set {
                this.mSGField = value;
                this.RaisePropertyChanged("MSG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string TOKENID {
            get {
                return this.tOKENIDField;
            }
            set {
                this.tOKENIDField = value;
                this.RaisePropertyChanged("TOKENID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int LANGUAGEID {
            get {
                return this.lANGUAGEIDField;
            }
            set {
                this.lANGUAGEIDField = value;
                this.RaisePropertyChanged("LANGUAGEID");
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
    public partial class CRM_HG_RIGHT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int wxField;
        
        private int pcField;
        
        private int rIGHTIDField;
        
        private int rGROUPIDField;
        
        private string rIGHTNAMEField;
        
        private int rIGHTNOField;
        
        private string rIGHTADDField;
        
        private string rIGHTMEMOField;
        
        private int iSACTIVEField;
        
        private string iMAGELJField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int WX {
            get {
                return this.wxField;
            }
            set {
                this.wxField = value;
                this.RaisePropertyChanged("WX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int PC {
            get {
                return this.pcField;
            }
            set {
                this.pcField = value;
                this.RaisePropertyChanged("PC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int RIGHTID {
            get {
                return this.rIGHTIDField;
            }
            set {
                this.rIGHTIDField = value;
                this.RaisePropertyChanged("RIGHTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int RGROUPID {
            get {
                return this.rGROUPIDField;
            }
            set {
                this.rGROUPIDField = value;
                this.RaisePropertyChanged("RGROUPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string RIGHTNAME {
            get {
                return this.rIGHTNAMEField;
            }
            set {
                this.rIGHTNAMEField = value;
                this.RaisePropertyChanged("RIGHTNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int RIGHTNO {
            get {
                return this.rIGHTNOField;
            }
            set {
                this.rIGHTNOField = value;
                this.RaisePropertyChanged("RIGHTNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string RIGHTADD {
            get {
                return this.rIGHTADDField;
            }
            set {
                this.rIGHTADDField = value;
                this.RaisePropertyChanged("RIGHTADD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string RIGHTMEMO {
            get {
                return this.rIGHTMEMOField;
            }
            set {
                this.rIGHTMEMOField = value;
                this.RaisePropertyChanged("RIGHTMEMO");
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
        public string IMAGELJ {
            get {
                return this.iMAGELJField;
            }
            set {
                this.iMAGELJField = value;
                this.RaisePropertyChanged("IMAGELJ");
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
    public partial class CRM_HG_RIGHTGROUP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int rGROUPIDField;
        
        private string rGROUPNAMEField;
        
        private int pRGROUPIDField;
        
        private int pRIGHTNOField;
        
        private string rGROUPMEMOField;
        
        private int iSACTIVEField;
        
        private string iMAGELJField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int RGROUPID {
            get {
                return this.rGROUPIDField;
            }
            set {
                this.rGROUPIDField = value;
                this.RaisePropertyChanged("RGROUPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string RGROUPNAME {
            get {
                return this.rGROUPNAMEField;
            }
            set {
                this.rGROUPNAMEField = value;
                this.RaisePropertyChanged("RGROUPNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PRGROUPID {
            get {
                return this.pRGROUPIDField;
            }
            set {
                this.pRGROUPIDField = value;
                this.RaisePropertyChanged("PRGROUPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int PRIGHTNO {
            get {
                return this.pRIGHTNOField;
            }
            set {
                this.pRIGHTNOField = value;
                this.RaisePropertyChanged("PRIGHTNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string RGROUPMEMO {
            get {
                return this.rGROUPMEMOField;
            }
            set {
                this.rGROUPMEMOField = value;
                this.RaisePropertyChanged("RGROUPMEMO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string IMAGELJ {
            get {
                return this.iMAGELJField;
            }
            set {
                this.iMAGELJField = value;
                this.RaisePropertyChanged("IMAGELJ");
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
    public partial class CRM_JURISDICTION_GROUP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private CRM_HG_RIGHTGROUP cRM_HG_RIGHTGROUPField;
        
        private CRM_HG_RIGHT[] cRM_HG_RIGHTListField;
        
        private int sTAFFIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public CRM_HG_RIGHTGROUP CRM_HG_RIGHTGROUP {
            get {
                return this.cRM_HG_RIGHTGROUPField;
            }
            set {
                this.cRM_HG_RIGHTGROUPField = value;
                this.RaisePropertyChanged("CRM_HG_RIGHTGROUP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public CRM_HG_RIGHT[] CRM_HG_RIGHTList {
            get {
                return this.cRM_HG_RIGHTListField;
            }
            set {
                this.cRM_HG_RIGHTListField = value;
                this.RaisePropertyChanged("CRM_HG_RIGHTList");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MES_LoginSoapChannel : Sonluk.UI.Model.MES.MES_LoginService.MES_LoginSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MES_LoginSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.MES_LoginService.MES_LoginSoap>, Sonluk.UI.Model.MES.MES_LoginService.MES_LoginSoap {
        
        public MES_LoginSoapClient() {
        }
        
        public MES_LoginSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MES_LoginSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MES_LoginSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MES_LoginSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.MES_LoginService.MES_LoginINFO Login(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID) {
            return base.Channel.Login(name, password, OPENID, WXDLCS, PC, WX, GCID);
        }
        
        public Sonluk.UI.Model.MES.MES_LoginService.MES_LoginINFO Login_language(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID, int LANGUAGEID) {
            return base.Channel.Login_language(name, password, OPENID, WXDLCS, PC, WX, GCID, LANGUAGEID);
        }
    }
}
