﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.PRODUCT_WARNService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.PRODUCT_WARNService.PRODUCT_WARNSoap")]
    public interface PRODUCT_WARNSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int PROWARNID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN ReadByID(int PROWARNID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN[] ReadByParam(Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByKHIDandPRODUCTID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN[] ReadByKHIDandPRODUCTID(int KHID, int PRODUCTID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_PRODUCT_WARN : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int pROWARNIDField;
        
        private int kHIDField;
        
        private int pRODUCTIDField;
        
        private double jCSJField;
        
        private double yJXSField;
        
        private int yJSLField;
        
        private int sYSLField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private int cJRField;
        
        private string cJSJField;
        
        private string tBSJField;
        
        private int xGRField;
        
        private string cJRDESField;
        
        private string xGRDESField;
        
        private string xGSJField;
        
        private string kHMCField;
        
        private int cPLXField;
        
        private int cPXLField;
        
        private int cPXHField;
        
        private string cPLXDESField;
        
        private string cPXLDESField;
        
        private string cPXHDESField;
        
        private string cPPHField;
        
        private string cPMCField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int PROWARNID {
            get {
                return this.pROWARNIDField;
            }
            set {
                this.pROWARNIDField = value;
                this.RaisePropertyChanged("PROWARNID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PRODUCTID {
            get {
                return this.pRODUCTIDField;
            }
            set {
                this.pRODUCTIDField = value;
                this.RaisePropertyChanged("PRODUCTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public double JCSJ {
            get {
                return this.jCSJField;
            }
            set {
                this.jCSJField = value;
                this.RaisePropertyChanged("JCSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public double YJXS {
            get {
                return this.yJXSField;
            }
            set {
                this.yJXSField = value;
                this.RaisePropertyChanged("YJXS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int YJSL {
            get {
                return this.yJSLField;
            }
            set {
                this.yJSLField = value;
                this.RaisePropertyChanged("YJSL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int SYSL {
            get {
                return this.sYSLField;
            }
            set {
                this.sYSLField = value;
                this.RaisePropertyChanged("SYSL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string BEIZ {
            get {
                return this.bEIZField;
            }
            set {
                this.bEIZField = value;
                this.RaisePropertyChanged("BEIZ");
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string CJSJ {
            get {
                return this.cJSJField;
            }
            set {
                this.cJSJField = value;
                this.RaisePropertyChanged("CJSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string TBSJ {
            get {
                return this.tBSJField;
            }
            set {
                this.tBSJField = value;
                this.RaisePropertyChanged("TBSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string CJRDES {
            get {
                return this.cJRDESField;
            }
            set {
                this.cJRDESField = value;
                this.RaisePropertyChanged("CJRDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string XGRDES {
            get {
                return this.xGRDESField;
            }
            set {
                this.xGRDESField = value;
                this.RaisePropertyChanged("XGRDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string XGSJ {
            get {
                return this.xGSJField;
            }
            set {
                this.xGSJField = value;
                this.RaisePropertyChanged("XGSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string KHMC {
            get {
                return this.kHMCField;
            }
            set {
                this.kHMCField = value;
                this.RaisePropertyChanged("KHMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int CPLX {
            get {
                return this.cPLXField;
            }
            set {
                this.cPLXField = value;
                this.RaisePropertyChanged("CPLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public int CPXL {
            get {
                return this.cPXLField;
            }
            set {
                this.cPXLField = value;
                this.RaisePropertyChanged("CPXL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public int CPXH {
            get {
                return this.cPXHField;
            }
            set {
                this.cPXHField = value;
                this.RaisePropertyChanged("CPXH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string CPLXDES {
            get {
                return this.cPLXDESField;
            }
            set {
                this.cPLXDESField = value;
                this.RaisePropertyChanged("CPLXDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string CPXLDES {
            get {
                return this.cPXLDESField;
            }
            set {
                this.cPXLDESField = value;
                this.RaisePropertyChanged("CPXLDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string CPXHDES {
            get {
                return this.cPXHDESField;
            }
            set {
                this.cPXHDESField = value;
                this.RaisePropertyChanged("CPXHDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string CPPH {
            get {
                return this.cPPHField;
            }
            set {
                this.cPPHField = value;
                this.RaisePropertyChanged("CPPH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string CPMC {
            get {
                return this.cPMCField;
            }
            set {
                this.cPMCField = value;
                this.RaisePropertyChanged("CPMC");
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
    public interface PRODUCT_WARNSoapChannel : Sonluk.UI.Model.CRM.PRODUCT_WARNService.PRODUCT_WARNSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PRODUCT_WARNSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.PRODUCT_WARNService.PRODUCT_WARNSoap>, Sonluk.UI.Model.CRM.PRODUCT_WARNService.PRODUCT_WARNSoap {
        
        public PRODUCT_WARNSoapClient() {
        }
        
        public PRODUCT_WARNSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PRODUCT_WARNSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PRODUCT_WARNSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PRODUCT_WARNSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public int Delete(int PROWARNID, string ptoken) {
            return base.Channel.Delete(PROWARNID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN ReadByID(int PROWARNID, string ptoken) {
            return base.Channel.ReadByID(PROWARNID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN[] ReadByParam(Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.PRODUCT_WARNService.CRM_PRODUCT_WARN[] ReadByKHIDandPRODUCTID(int KHID, int PRODUCTID, string ptoken) {
            return base.Channel.ReadByKHIDandPRODUCTID(KHID, PRODUCTID, ptoken);
        }
    }
}