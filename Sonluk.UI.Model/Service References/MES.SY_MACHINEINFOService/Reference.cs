﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.SY_MACHINEINFOService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.SY_MACHINEINFOService.SY_MACHINEINFOSoap")]
    public interface SY_MACHINEINFOSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insert", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO insert(Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO_SELECT SELECT(Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_BBXX", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO_SELECTBBXX SELECT_BBXX(Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO_BBXX model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_MACHINEINFO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string mNUMBERField;
        
        private string wKINFOField;
        
        private bool iSDELETEField;
        
        private string gcField;
        
        private string rEMARKField;
        
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
        public string MNUMBER {
            get {
                return this.mNUMBERField;
            }
            set {
                this.mNUMBERField = value;
                this.RaisePropertyChanged("MNUMBER");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string WKINFO {
            get {
                return this.wKINFOField;
            }
            set {
                this.wKINFOField = value;
                this.RaisePropertyChanged("WKINFO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public bool ISDELETE {
            get {
                return this.iSDELETEField;
            }
            set {
                this.iSDELETEField = value;
                this.RaisePropertyChanged("ISDELETE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
    public partial class MES_SY_MACHINEINFO_SELECTBBXX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_SY_MACHINEINFO_BBXX[] mES_SY_MACHINEINFO_BBXXField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_SY_MACHINEINFO_BBXX[] MES_SY_MACHINEINFO_BBXX {
            get {
                return this.mES_SY_MACHINEINFO_BBXXField;
            }
            set {
                this.mES_SY_MACHINEINFO_BBXXField = value;
                this.RaisePropertyChanged("MES_SY_MACHINEINFO_BBXX");
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
    public partial class MES_SY_MACHINEINFO_BBXX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string mNUMBERField;
        
        private string wKINFOField;
        
        private bool iSDELETEField;
        
        private string gcField;
        
        private string rEMARKField;
        
        private int pBIDField;
        
        private string sYIDField;
        
        private string nEWBBField;
        
        private string lASTNEWBBField;
        
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
        public string MNUMBER {
            get {
                return this.mNUMBERField;
            }
            set {
                this.mNUMBERField = value;
                this.RaisePropertyChanged("MNUMBER");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string WKINFO {
            get {
                return this.wKINFOField;
            }
            set {
                this.wKINFOField = value;
                this.RaisePropertyChanged("WKINFO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public bool ISDELETE {
            get {
                return this.iSDELETEField;
            }
            set {
                this.iSDELETEField = value;
                this.RaisePropertyChanged("ISDELETE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        public int PBID {
            get {
                return this.pBIDField;
            }
            set {
                this.pBIDField = value;
                this.RaisePropertyChanged("PBID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string SYID {
            get {
                return this.sYIDField;
            }
            set {
                this.sYIDField = value;
                this.RaisePropertyChanged("SYID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string NEWBB {
            get {
                return this.nEWBBField;
            }
            set {
                this.nEWBBField = value;
                this.RaisePropertyChanged("NEWBB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string LASTNEWBB {
            get {
                return this.lASTNEWBBField;
            }
            set {
                this.lASTNEWBBField = value;
                this.RaisePropertyChanged("LASTNEWBB");
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
    public partial class MES_SY_MACHINEINFO_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_SY_MACHINEINFO[] mES_SY_MACHINEINFOField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_SY_MACHINEINFO[] MES_SY_MACHINEINFO {
            get {
                return this.mES_SY_MACHINEINFOField;
            }
            set {
                this.mES_SY_MACHINEINFOField = value;
                this.RaisePropertyChanged("MES_SY_MACHINEINFO");
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
    public interface SY_MACHINEINFOSoapChannel : Sonluk.UI.Model.MES.SY_MACHINEINFOService.SY_MACHINEINFOSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SY_MACHINEINFOSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.SY_MACHINEINFOService.SY_MACHINEINFOSoap>, Sonluk.UI.Model.MES.SY_MACHINEINFOService.SY_MACHINEINFOSoap {
        
        public SY_MACHINEINFOSoapClient() {
        }
        
        public SY_MACHINEINFOSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SY_MACHINEINFOSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_MACHINEINFOSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_MACHINEINFOSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO insert(Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO model, string ptoken) {
            return base.Channel.insert(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO_SELECT SELECT(Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO_SELECTBBXX SELECT_BBXX(Sonluk.UI.Model.MES.SY_MACHINEINFOService.MES_SY_MACHINEINFO_BBXX model, string ptoken) {
            return base.Channel.SELECT_BBXX(model, ptoken);
        }
    }
}
