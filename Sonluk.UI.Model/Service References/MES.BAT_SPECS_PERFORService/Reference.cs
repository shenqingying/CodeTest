﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.BAT_SPECS_PERFORService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.BAT_SPECS_PERFORService.BAT_SPECS_PERFORSoap")]
    public interface BAT_SPECS_PERFORSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/COVER_LIST", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN COVER_LIST(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ_SELECT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MCOVER_LIST", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN MCOVER_LIST(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ_SELECT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/COVER", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN COVER(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ_SELECT SELECT(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ_SEARCH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN INSERT(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN DELETE(int RI, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_DCDXNSZ_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_DCDXNSZ[] mES_DCDXNSZField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_DCDXNSZ[] MES_DCDXNSZ {
            get {
                return this.mES_DCDXNSZField;
            }
            set {
                this.mES_DCDXNSZField = value;
                this.RaisePropertyChanged("MES_DCDXNSZ");
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
    public partial class MES_DCDXNSZ : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int riField;
        
        private string dCXHField;
        
        private int dCXHRIField;
        
        private string sCXField;
        
        private int sCXIDField;
        
        private string sDDJField;
        
        private int sDDJRIField;
        
        private string rqField;
        
        private string szField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int RI {
            get {
                return this.riField;
            }
            set {
                this.riField = value;
                this.RaisePropertyChanged("RI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string DCXH {
            get {
                return this.dCXHField;
            }
            set {
                this.dCXHField = value;
                this.RaisePropertyChanged("DCXH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int DCXHRI {
            get {
                return this.dCXHRIField;
            }
            set {
                this.dCXHRIField = value;
                this.RaisePropertyChanged("DCXHRI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SCX {
            get {
                return this.sCXField;
            }
            set {
                this.sCXField = value;
                this.RaisePropertyChanged("SCX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int SCXID {
            get {
                return this.sCXIDField;
            }
            set {
                this.sCXIDField = value;
                this.RaisePropertyChanged("SCXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string SDDJ {
            get {
                return this.sDDJField;
            }
            set {
                this.sDDJField = value;
                this.RaisePropertyChanged("SDDJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int SDDJRI {
            get {
                return this.sDDJRIField;
            }
            set {
                this.sDDJRIField = value;
                this.RaisePropertyChanged("SDDJRI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string RQ {
            get {
                return this.rqField;
            }
            set {
                this.rqField = value;
                this.RaisePropertyChanged("RQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string SZ {
            get {
                return this.szField;
            }
            set {
                this.szField = value;
                this.RaisePropertyChanged("SZ");
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
    public partial class MES_DCDXNSZ_SEARCH : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int riField;
        
        private string dCXHField;
        
        private string sCXField;
        
        private string sDDJField;
        
        private string dATESField;
        
        private string dATEEField;
        
        private string dATEMField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int RI {
            get {
                return this.riField;
            }
            set {
                this.riField = value;
                this.RaisePropertyChanged("RI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string DCXH {
            get {
                return this.dCXHField;
            }
            set {
                this.dCXHField = value;
                this.RaisePropertyChanged("DCXH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SCX {
            get {
                return this.sCXField;
            }
            set {
                this.sCXField = value;
                this.RaisePropertyChanged("SCX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SDDJ {
            get {
                return this.sDDJField;
            }
            set {
                this.sDDJField = value;
                this.RaisePropertyChanged("SDDJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string DATES {
            get {
                return this.dATESField;
            }
            set {
                this.dATESField = value;
                this.RaisePropertyChanged("DATES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string DATEE {
            get {
                return this.dATEEField;
            }
            set {
                this.dATEEField = value;
                this.RaisePropertyChanged("DATEE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string DATEM {
            get {
                return this.dATEMField;
            }
            set {
                this.dATEMField = value;
                this.RaisePropertyChanged("DATEM");
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
    public interface BAT_SPECS_PERFORSoapChannel : Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.BAT_SPECS_PERFORSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BAT_SPECS_PERFORSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.BAT_SPECS_PERFORSoap>, Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.BAT_SPECS_PERFORSoap {
        
        public BAT_SPECS_PERFORSoapClient() {
        }
        
        public BAT_SPECS_PERFORSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BAT_SPECS_PERFORSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BAT_SPECS_PERFORSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BAT_SPECS_PERFORSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN COVER_LIST(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ_SELECT model, string ptoken) {
            return base.Channel.COVER_LIST(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN MCOVER_LIST(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ_SELECT model, string ptoken) {
            return base.Channel.MCOVER_LIST(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN COVER(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ model, string ptoken) {
            return base.Channel.COVER(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ_SELECT SELECT(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ_SEARCH model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN INSERT(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_DCDXNSZ model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECS_PERFORService.MES_RETURN DELETE(int RI, string ptoken) {
            return base.Channel.DELETE(RI, ptoken);
        }
    }
}
