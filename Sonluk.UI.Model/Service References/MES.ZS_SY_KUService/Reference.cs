﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.ZS_SY_KUService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.ZS_SY_KUService.WS_MES_ZS_SY_KUSoap")]
    public interface WS_MES_ZS_SY_KUSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_SY_KUService.MES_RETURN INSERT(Sonluk.UI.Model.MES.ZS_SY_KUService.MES_ZS_SY_KU model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_SY_KUService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.ZS_SY_KUService.MES_ZS_SY_KU model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.ZS_SY_KUService.MES_ZS_SY_KU_SELECT SELECT(Sonluk.UI.Model.MES.ZS_SY_KUService.MES_ZS_SY_KU model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_ZS_SY_KU : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int kHIDField;
        
        private string kHMSField;
        
        private string rEMARKField;
        
        private string kHNOField;
        
        private int cJRField;
        
        private int xGRField;
        
        private int gSTYPEField;
        
        private string gSTYPENAMEField;
        
        private int iSACTIONField;
        
        private int lbField;
        
        private string gcField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int KHID {
            get {
                return this.kHIDField;
            }
            set {
                this.kHIDField = value;
                this.RaisePropertyChanged("KHID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string KHMS {
            get {
                return this.kHMSField;
            }
            set {
                this.kHMSField = value;
                this.RaisePropertyChanged("KHMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string KHNO {
            get {
                return this.kHNOField;
            }
            set {
                this.kHNOField = value;
                this.RaisePropertyChanged("KHNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int GSTYPE {
            get {
                return this.gSTYPEField;
            }
            set {
                this.gSTYPEField = value;
                this.RaisePropertyChanged("GSTYPE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string GSTYPENAME {
            get {
                return this.gSTYPENAMEField;
            }
            set {
                this.gSTYPENAMEField = value;
                this.RaisePropertyChanged("GSTYPENAME");
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string GC {
            get {
                return this.gcField;
            }
            set {
                this.gcField = value;
                this.RaisePropertyChanged("GC");
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
    public partial class MES_ZS_SY_KU_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_ZS_SY_KU[] mES_ZS_SY_KUField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_ZS_SY_KU[] MES_ZS_SY_KU {
            get {
                return this.mES_ZS_SY_KUField;
            }
            set {
                this.mES_ZS_SY_KUField = value;
                this.RaisePropertyChanged("MES_ZS_SY_KU");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WS_MES_ZS_SY_KUSoapChannel : Sonluk.UI.Model.MES.ZS_SY_KUService.WS_MES_ZS_SY_KUSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_MES_ZS_SY_KUSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.ZS_SY_KUService.WS_MES_ZS_SY_KUSoap>, Sonluk.UI.Model.MES.ZS_SY_KUService.WS_MES_ZS_SY_KUSoap {
        
        public WS_MES_ZS_SY_KUSoapClient() {
        }
        
        public WS_MES_ZS_SY_KUSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_MES_ZS_SY_KUSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_MES_ZS_SY_KUSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_MES_ZS_SY_KUSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.ZS_SY_KUService.MES_RETURN INSERT(Sonluk.UI.Model.MES.ZS_SY_KUService.MES_ZS_SY_KU model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_SY_KUService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.ZS_SY_KUService.MES_ZS_SY_KU model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.ZS_SY_KUService.MES_ZS_SY_KU_SELECT SELECT(Sonluk.UI.Model.MES.ZS_SY_KUService.MES_ZS_SY_KU model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
    }
}
