﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.SY_MATERIAL_GROUPService.SY_MATERIAL_GROUPSoap")]
    public interface SY_MATERIAL_GROUPSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_RETURN INSERT(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP_SELECT SELECT(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_RETURN DELETE(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_LB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP_SELECT SELECT_LB(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_MATERIAL_GROUP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string wLGROUPField;
        
        private string wLGROUPNAMEField;
        
        private int wLLBField;
        
        private string wLLBNAMEField;
        
        private string gcField;
        
        private int iSACTIONField;
        
        private string cJDATEField;
        
        private int cJRIDField;
        
        private string cJRField;
        
        private string xGDATEField;
        
        private int xGRIDField;
        
        private string xGRField;
        
        private string gZZXBHField;
        
        private int lbField;
        
        private int sTAFFIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string WLGROUP {
            get {
                return this.wLGROUPField;
            }
            set {
                this.wLGROUPField = value;
                this.RaisePropertyChanged("WLGROUP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string WLGROUPNAME {
            get {
                return this.wLGROUPNAMEField;
            }
            set {
                this.wLGROUPNAMEField = value;
                this.RaisePropertyChanged("WLGROUPNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string CJDATE {
            get {
                return this.cJDATEField;
            }
            set {
                this.cJDATEField = value;
                this.RaisePropertyChanged("CJDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int CJRID {
            get {
                return this.cJRIDField;
            }
            set {
                this.cJRIDField = value;
                this.RaisePropertyChanged("CJRID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string CJR {
            get {
                return this.cJRField;
            }
            set {
                this.cJRField = value;
                this.RaisePropertyChanged("CJR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string XGDATE {
            get {
                return this.xGDATEField;
            }
            set {
                this.xGDATEField = value;
                this.RaisePropertyChanged("XGDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int XGRID {
            get {
                return this.xGRIDField;
            }
            set {
                this.xGRIDField = value;
                this.RaisePropertyChanged("XGRID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string XGR {
            get {
                return this.xGRField;
            }
            set {
                this.xGRField = value;
                this.RaisePropertyChanged("XGR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
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
    public partial class MES_SY_MATERIAL_GROUP_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_SY_MATERIAL_GROUP[] mES_SY_MATERIAL_GROUPField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_SY_MATERIAL_GROUP[] MES_SY_MATERIAL_GROUP {
            get {
                return this.mES_SY_MATERIAL_GROUPField;
            }
            set {
                this.mES_SY_MATERIAL_GROUPField = value;
                this.RaisePropertyChanged("MES_SY_MATERIAL_GROUP");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SY_MATERIAL_GROUPSoapChannel : Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.SY_MATERIAL_GROUPSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SY_MATERIAL_GROUPSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.SY_MATERIAL_GROUPSoap>, Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.SY_MATERIAL_GROUPSoap {
        
        public SY_MATERIAL_GROUPSoapClient() {
        }
        
        public SY_MATERIAL_GROUPSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SY_MATERIAL_GROUPSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_MATERIAL_GROUPSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_MATERIAL_GROUPSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_RETURN INSERT(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP_SELECT SELECT(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_RETURN DELETE(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken) {
            return base.Channel.DELETE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP_SELECT SELECT_LB(Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService.MES_SY_MATERIAL_GROUP model, string ptoken) {
            return base.Channel.SELECT_LB(model, ptoken);
        }
    }
}
