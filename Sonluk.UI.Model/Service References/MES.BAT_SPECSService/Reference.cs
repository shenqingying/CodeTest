﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.BAT_SPECSService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.BAT_SPECSService.BAT_SPECSSoap")]
    public interface BAT_SPECSSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_SPECS_FULL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_SPECS_FULL(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_LIST", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_LIST(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_LIST_LEFT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_LIST_LEFT(string DCXH, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_FULL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN INSERT_FULL(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN DELETE(string DCXH, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_SPECS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_SPECS(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_PERFOR", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_PERFOR(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_SPECS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN INSERT_SPECS(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_PERFOR", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN INSERT_PERFOR(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_DCBZ : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int riField;
        
        private string dCXHField;
        
        private int dCXHRIField;
        
        private MES_DCCCBZ[] mES_DCCCBZField;
        
        private MES_DCDXN[] mES_DCDXNField;
        
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
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        public MES_DCCCBZ[] MES_DCCCBZ {
            get {
                return this.mES_DCCCBZField;
            }
            set {
                this.mES_DCCCBZField = value;
                this.RaisePropertyChanged("MES_DCCCBZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=4)]
        public MES_DCDXN[] MES_DCDXN {
            get {
                return this.mES_DCDXNField;
            }
            set {
                this.mES_DCDXNField = value;
                this.RaisePropertyChanged("MES_DCDXN");
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
    public partial class MES_DCCCBZ : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int riField;
        
        private string dCBZField;
        
        private int dCBZRIField;
        
        private string dCMAXField;
        
        private string dCMINField;
        
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
        public string DCBZ {
            get {
                return this.dCBZField;
            }
            set {
                this.dCBZField = value;
                this.RaisePropertyChanged("DCBZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int DCBZRI {
            get {
                return this.dCBZRIField;
            }
            set {
                this.dCBZRIField = value;
                this.RaisePropertyChanged("DCBZRI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string DCMAX {
            get {
                return this.dCMAXField;
            }
            set {
                this.dCMAXField = value;
                this.RaisePropertyChanged("DCMAX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string DCMIN {
            get {
                return this.dCMINField;
            }
            set {
                this.dCMINField = value;
                this.RaisePropertyChanged("DCMIN");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_DCBZ_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_DCBZ[] mES_DCBZField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_DCBZ[] MES_DCBZ {
            get {
                return this.mES_DCBZField;
            }
            set {
                this.mES_DCBZField = value;
                this.RaisePropertyChanged("MES_DCBZ");
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
    public partial class MES_DCDXN : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int riField;
        
        private string dCBZField;
        
        private int dCBZRIField;
        
        private string dCFDFSField;
        
        private string dCMADField;
        
        private string sDLXField;
        
        private string sDLXRIField;
        
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
        public string DCBZ {
            get {
                return this.dCBZField;
            }
            set {
                this.dCBZField = value;
                this.RaisePropertyChanged("DCBZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int DCBZRI {
            get {
                return this.dCBZRIField;
            }
            set {
                this.dCBZRIField = value;
                this.RaisePropertyChanged("DCBZRI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string DCFDFS {
            get {
                return this.dCFDFSField;
            }
            set {
                this.dCFDFSField = value;
                this.RaisePropertyChanged("DCFDFS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string DCMAD {
            get {
                return this.dCMADField;
            }
            set {
                this.dCMADField = value;
                this.RaisePropertyChanged("DCMAD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string SDLX {
            get {
                return this.sDLXField;
            }
            set {
                this.sDLXField = value;
                this.RaisePropertyChanged("SDLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string SDLXRI {
            get {
                return this.sDLXRIField;
            }
            set {
                this.sDLXRIField = value;
                this.RaisePropertyChanged("SDLXRI");
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
    public interface BAT_SPECSSoapChannel : Sonluk.UI.Model.MES.BAT_SPECSService.BAT_SPECSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BAT_SPECSSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.BAT_SPECSService.BAT_SPECSSoap>, Sonluk.UI.Model.MES.BAT_SPECSService.BAT_SPECSSoap {
        
        public BAT_SPECSSoapClient() {
        }
        
        public BAT_SPECSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BAT_SPECSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BAT_SPECSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BAT_SPECSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_SPECS_FULL(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken) {
            return base.Channel.SELECT_SPECS_FULL(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_LIST(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken) {
            return base.Channel.SELECT_LIST(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_LIST_LEFT(string DCXH, string ptoken) {
            return base.Channel.SELECT_LIST_LEFT(DCXH, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN INSERT_FULL(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken) {
            return base.Channel.INSERT_FULL(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN DELETE(string DCXH, string ptoken) {
            return base.Channel.DELETE(DCXH, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_SPECS(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken) {
            return base.Channel.SELECT_SPECS(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ_SELECT SELECT_PERFOR(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken) {
            return base.Channel.SELECT_PERFOR(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN INSERT_SPECS(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken) {
            return base.Channel.INSERT_SPECS(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.BAT_SPECSService.MES_RETURN INSERT_PERFOR(Sonluk.UI.Model.MES.BAT_SPECSService.MES_DCBZ model, string ptoken) {
            return base.Channel.INSERT_PERFOR(model, ptoken);
        }
    }
}
