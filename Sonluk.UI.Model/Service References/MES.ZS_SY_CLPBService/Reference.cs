﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.ZS_SY_CLPBService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.ZS_SY_CLPBService.WS_MES_ZS_SY_CLPBSoap")]
    public interface WS_MES_ZS_SY_CLPBSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_RETURN INSERT(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_SELECT SELECT(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_WL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_RETURN INSERT_WL(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_WL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_WL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_RETURN UPDATE_WL(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_WL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_WL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_WL_SELECT SELECT_WL(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_WL model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_SY_CLPB : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int cLPBIDField;
        
        private string gcField;
        
        private int yCLDMIDField;
        
        private int pBDMIDField;
        
        private string yCLPBDMField;
        
        private string rEMARKField;
        
        private int cJRField;
        
        private int xGRField;
        
        private int iSACTIONField;
        
        private string yCLDMNAMEField;
        
        private string yCLDMREMARKField;
        
        private string pBDMNAMEField;
        
        private string pBDMREMARKField;
        
        private int lbField;
        
        private int sTAFFIDField;
        
        private int tMCOUNTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int CLPBID {
            get {
                return this.cLPBIDField;
            }
            set {
                this.cLPBIDField = value;
                this.RaisePropertyChanged("CLPBID");
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
        public int YCLDMID {
            get {
                return this.yCLDMIDField;
            }
            set {
                this.yCLDMIDField = value;
                this.RaisePropertyChanged("YCLDMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int PBDMID {
            get {
                return this.pBDMIDField;
            }
            set {
                this.pBDMIDField = value;
                this.RaisePropertyChanged("PBDMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string YCLPBDM {
            get {
                return this.yCLPBDMField;
            }
            set {
                this.yCLPBDMField = value;
                this.RaisePropertyChanged("YCLPBDM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int XGR {
            get {
                return this.xGRField;
            }
            set {
                this.xGRField = value;
                this.RaisePropertyChanged("XGR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int ISACTION {
            get {
                return this.iSACTIONField;
            }
            set {
                this.iSACTIONField = value;
                this.RaisePropertyChanged("ISACTION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string YCLDMNAME {
            get {
                return this.yCLDMNAMEField;
            }
            set {
                this.yCLDMNAMEField = value;
                this.RaisePropertyChanged("YCLDMNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string YCLDMREMARK {
            get {
                return this.yCLDMREMARKField;
            }
            set {
                this.yCLDMREMARKField = value;
                this.RaisePropertyChanged("YCLDMREMARK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string PBDMNAME {
            get {
                return this.pBDMNAMEField;
            }
            set {
                this.pBDMNAMEField = value;
                this.RaisePropertyChanged("PBDMNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string PBDMREMARK {
            get {
                return this.pBDMREMARKField;
            }
            set {
                this.pBDMREMARKField = value;
                this.RaisePropertyChanged("PBDMREMARK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public int TMCOUNT {
            get {
                return this.tMCOUNTField;
            }
            set {
                this.tMCOUNTField = value;
                this.RaisePropertyChanged("TMCOUNT");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_SY_CLPB_WL_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_RETURN mES_RETURNField;
        
        private MES_ZS_SY_CLPB_WL[] mES_ZS_SY_CLPB_WLField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public MES_RETURN MES_RETURN {
            get {
                return this.mES_RETURNField;
            }
            set {
                this.mES_RETURNField = value;
                this.RaisePropertyChanged("MES_RETURN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public MES_ZS_SY_CLPB_WL[] MES_ZS_SY_CLPB_WL {
            get {
                return this.mES_ZS_SY_CLPB_WLField;
            }
            set {
                this.mES_ZS_SY_CLPB_WLField = value;
                this.RaisePropertyChanged("MES_ZS_SY_CLPB_WL");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_SY_CLPB_WL : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int cLPBMXIDField;
        
        private int cLPBIDField;
        
        private string wLHField;
        
        private int cJRField;
        
        private int xGRField;
        
        private int lbField;
        
        private string gcField;
        
        private string wLMSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int CLPBMXID {
            get {
                return this.cLPBMXIDField;
            }
            set {
                this.cLPBMXIDField = value;
                this.RaisePropertyChanged("CLPBMXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int CLPBID {
            get {
                return this.cLPBIDField;
            }
            set {
                this.cLPBIDField = value;
                this.RaisePropertyChanged("CLPBID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        public int XGR {
            get {
                return this.xGRField;
            }
            set {
                this.xGRField = value;
                this.RaisePropertyChanged("XGR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string WLMS {
            get {
                return this.wLMSField;
            }
            set {
                this.wLMSField = value;
                this.RaisePropertyChanged("WLMS");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_SY_CLPB_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_RETURN mES_RETURNField;
        
        private MES_ZS_SY_CLPB[] mES_ZS_SY_CLPBField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public MES_RETURN MES_RETURN {
            get {
                return this.mES_RETURNField;
            }
            set {
                this.mES_RETURNField = value;
                this.RaisePropertyChanged("MES_RETURN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public MES_ZS_SY_CLPB[] MES_ZS_SY_CLPB {
            get {
                return this.mES_ZS_SY_CLPBField;
            }
            set {
                this.mES_ZS_SY_CLPBField = value;
                this.RaisePropertyChanged("MES_ZS_SY_CLPB");
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
    public interface WS_MES_ZS_SY_CLPBSoapChannel : Sonluk.UI.Model.MES.ZS_SY_CLPBService.WS_MES_ZS_SY_CLPBSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_MES_ZS_SY_CLPBSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.ZS_SY_CLPBService.WS_MES_ZS_SY_CLPBSoap>, Sonluk.UI.Model.MES.ZS_SY_CLPBService.WS_MES_ZS_SY_CLPBSoap {
        
        public WS_MES_ZS_SY_CLPBSoapClient() {
        }
        
        public WS_MES_ZS_SY_CLPBSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_MES_ZS_SY_CLPBSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_MES_ZS_SY_CLPBSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_MES_ZS_SY_CLPBSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_RETURN INSERT(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_SELECT SELECT(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_RETURN INSERT_WL(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_WL model, string ptoken) {
            return base.Channel.INSERT_WL(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_RETURN UPDATE_WL(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_WL model, string ptoken) {
            return base.Channel.UPDATE_WL(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_WL_SELECT SELECT_WL(Sonluk.UI.Model.MES.ZS_SY_CLPBService.MES_ZS_SY_CLPB_WL model, string ptoken) {
            return base.Channel.SELECT_WL(model, ptoken);
        }
    }
}
