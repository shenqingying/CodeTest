﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.HD_NKAXTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.HD_NKAXTService.HD_NKAXTSoap")]
    public interface HD_NKAXTSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create_TT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create_TT(Sonluk.UI.Model.CRM.HD_NKAXTService.CRM_HD_NKAXTTT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update_TT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update_TT(Sonluk.UI.Model.CRM.HD_NKAXTService.CRM_HD_NKAXTTT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete_TT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete_TT(int NKAXTID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create_MX", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create_MX(Sonluk.UI.Model.CRM.HD_NKAXTService.CRM_HD_NKAXTMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update_MX", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update_MX(Sonluk.UI.Model.CRM.HD_NKAXTService.CRM_HD_NKAXTMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete_MX", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete_MX(int NKAXTMXID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_HD_NKAXTTT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int nKAXTIDField;
        
        private int sQRIDField;
        
        private string sQRQField;
        
        private int iSACTIVEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int NKAXTID {
            get {
                return this.nKAXTIDField;
            }
            set {
                this.nKAXTIDField = value;
                this.RaisePropertyChanged("NKAXTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int SQRID {
            get {
                return this.sQRIDField;
            }
            set {
                this.sQRIDField = value;
                this.RaisePropertyChanged("SQRID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SQRQ {
            get {
                return this.sQRQField;
            }
            set {
                this.sQRQField = value;
                this.RaisePropertyChanged("SQRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int ISACTIVE {
            get {
                return this.iSACTIVEField;
            }
            set {
                this.iSACTIVEField = value;
                this.RaisePropertyChanged("ISACTIVE");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_HD_NKAXTMX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int nKAXTMXIDField;
        
        private int nKAXTIDField;
        
        private int sTAFFIDField;
        
        private string xKHKFField;
        
        private string zXXMField;
        
        private string zQCXDQField;
        
        private string kDZCCLField;
        
        private string tSCLXMField;
        
        private string lSZBField;
        
        private string gGXCField;
        
        private string qTBHField;
        
        private int iSACTIVEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int NKAXTMXID {
            get {
                return this.nKAXTMXIDField;
            }
            set {
                this.nKAXTMXIDField = value;
                this.RaisePropertyChanged("NKAXTMXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int NKAXTID {
            get {
                return this.nKAXTIDField;
            }
            set {
                this.nKAXTIDField = value;
                this.RaisePropertyChanged("NKAXTID");
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string XKHKF {
            get {
                return this.xKHKFField;
            }
            set {
                this.xKHKFField = value;
                this.RaisePropertyChanged("XKHKF");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string ZXXM {
            get {
                return this.zXXMField;
            }
            set {
                this.zXXMField = value;
                this.RaisePropertyChanged("ZXXM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string ZQCXDQ {
            get {
                return this.zQCXDQField;
            }
            set {
                this.zQCXDQField = value;
                this.RaisePropertyChanged("ZQCXDQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string KDZCCL {
            get {
                return this.kDZCCLField;
            }
            set {
                this.kDZCCLField = value;
                this.RaisePropertyChanged("KDZCCL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string TSCLXM {
            get {
                return this.tSCLXMField;
            }
            set {
                this.tSCLXMField = value;
                this.RaisePropertyChanged("TSCLXM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string LSZB {
            get {
                return this.lSZBField;
            }
            set {
                this.lSZBField = value;
                this.RaisePropertyChanged("LSZB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string GGXC {
            get {
                return this.gGXCField;
            }
            set {
                this.gGXCField = value;
                this.RaisePropertyChanged("GGXC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string QTBH {
            get {
                return this.qTBHField;
            }
            set {
                this.qTBHField = value;
                this.RaisePropertyChanged("QTBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int ISACTIVE {
            get {
                return this.iSACTIVEField;
            }
            set {
                this.iSACTIVEField = value;
                this.RaisePropertyChanged("ISACTIVE");
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
    public interface HD_NKAXTSoapChannel : Sonluk.UI.Model.CRM.HD_NKAXTService.HD_NKAXTSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HD_NKAXTSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.HD_NKAXTService.HD_NKAXTSoap>, Sonluk.UI.Model.CRM.HD_NKAXTService.HD_NKAXTSoap {
        
        public HD_NKAXTSoapClient() {
        }
        
        public HD_NKAXTSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HD_NKAXTSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HD_NKAXTSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HD_NKAXTSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create_TT(Sonluk.UI.Model.CRM.HD_NKAXTService.CRM_HD_NKAXTTT model, string ptoken) {
            return base.Channel.Create_TT(model, ptoken);
        }
        
        public int Update_TT(Sonluk.UI.Model.CRM.HD_NKAXTService.CRM_HD_NKAXTTT model, string ptoken) {
            return base.Channel.Update_TT(model, ptoken);
        }
        
        public int Delete_TT(int NKAXTID, string ptoken) {
            return base.Channel.Delete_TT(NKAXTID, ptoken);
        }
        
        public int Create_MX(Sonluk.UI.Model.CRM.HD_NKAXTService.CRM_HD_NKAXTMX model, string ptoken) {
            return base.Channel.Create_MX(model, ptoken);
        }
        
        public int Update_MX(Sonluk.UI.Model.CRM.HD_NKAXTService.CRM_HD_NKAXTMX model, string ptoken) {
            return base.Channel.Update_MX(model, ptoken);
        }
        
        public int Delete_MX(int NKAXTMXID, string ptoken) {
            return base.Channel.Delete_MX(NKAXTMXID, ptoken);
        }
    }
}
