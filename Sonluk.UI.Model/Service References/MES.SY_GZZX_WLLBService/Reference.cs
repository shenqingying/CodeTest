﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.SY_GZZX_WLLBService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.SY_GZZX_WLLBService.SY_GZZX_WLLBSoap")]
    public interface SY_GZZX_WLLBSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_RETURN INSERT(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_RETURN DELETE(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB_SELECT SELECT(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_LIST", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_RETURN INSERT_LIST(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB[] model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_LAY", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB_SELECT_LAY SELECT_LAY(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_GZZX_WLLB : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gcField;
        
        private string gZZXBHField;
        
        private int wLLBIDField;
        
        private string wLLBNAMEField;
        
        private string gZZXMSField;
        
        private int rIGHTIDField;
        
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int WLLBID {
            get {
                return this.wLLBIDField;
            }
            set {
                this.wLLBIDField = value;
                this.RaisePropertyChanged("WLLBID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string GZZXMS {
            get {
                return this.gZZXMSField;
            }
            set {
                this.gZZXMSField = value;
                this.RaisePropertyChanged("GZZXMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int RIGHTID {
            get {
                return this.rIGHTIDField;
            }
            set {
                this.rIGHTIDField = value;
                this.RaisePropertyChanged("RIGHTID");
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
    public partial class MES_SY_GZZX_WLLB_LAY : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gcField;
        
        private string gZZXBHField;
        
        private int wLLBIDField;
        
        private string wLLBNAMEField;
        
        private string gZZXMSField;
        
        private bool lAY_CHECKEDField;
        
        private int rIGHTIDField;
        
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int WLLBID {
            get {
                return this.wLLBIDField;
            }
            set {
                this.wLLBIDField = value;
                this.RaisePropertyChanged("WLLBID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string GZZXMS {
            get {
                return this.gZZXMSField;
            }
            set {
                this.gZZXMSField = value;
                this.RaisePropertyChanged("GZZXMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int RIGHTID {
            get {
                return this.rIGHTIDField;
            }
            set {
                this.rIGHTIDField = value;
                this.RaisePropertyChanged("RIGHTID");
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
    public partial class MES_SY_GZZX_WLLB_SELECT_LAY : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_SY_GZZX_WLLB_LAY[] mES_SY_GZZX_WLLB_LAYField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_SY_GZZX_WLLB_LAY[] MES_SY_GZZX_WLLB_LAY {
            get {
                return this.mES_SY_GZZX_WLLB_LAYField;
            }
            set {
                this.mES_SY_GZZX_WLLB_LAYField = value;
                this.RaisePropertyChanged("MES_SY_GZZX_WLLB_LAY");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_GZZX_WLLB_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_SY_GZZX_WLLB[] mES_SY_GZZX_WLLBField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_SY_GZZX_WLLB[] MES_SY_GZZX_WLLB {
            get {
                return this.mES_SY_GZZX_WLLBField;
            }
            set {
                this.mES_SY_GZZX_WLLBField = value;
                this.RaisePropertyChanged("MES_SY_GZZX_WLLB");
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
    public interface SY_GZZX_WLLBSoapChannel : Sonluk.UI.Model.MES.SY_GZZX_WLLBService.SY_GZZX_WLLBSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SY_GZZX_WLLBSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.SY_GZZX_WLLBService.SY_GZZX_WLLBSoap>, Sonluk.UI.Model.MES.SY_GZZX_WLLBService.SY_GZZX_WLLBSoap {
        
        public SY_GZZX_WLLBSoapClient() {
        }
        
        public SY_GZZX_WLLBSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SY_GZZX_WLLBSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_GZZX_WLLBSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_GZZX_WLLBSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_RETURN INSERT(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_RETURN DELETE(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB model, string ptoken) {
            return base.Channel.DELETE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB_SELECT SELECT(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_RETURN INSERT_LIST(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB[] model, string ptoken) {
            return base.Channel.INSERT_LIST(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB_SELECT_LAY SELECT_LAY(Sonluk.UI.Model.MES.SY_GZZX_WLLBService.MES_SY_GZZX_WLLB model, string ptoken) {
            return base.Channel.SELECT_LAY(model, ptoken);
        }
    }
}
