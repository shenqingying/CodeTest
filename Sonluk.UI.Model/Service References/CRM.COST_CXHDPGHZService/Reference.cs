﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_CXHDPGHZService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_CXHDPGHZService.COST_CXHDPGHZSoap")]
    public interface COST_CXHDPGHZSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ[] ReadByParam(Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int PGHZID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteByCXHDID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteByCXHDID(int CXHDID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetReport", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ[] GetReport(Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AutoUpdate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int AutoUpdate(int CXHDID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_CXHDPGHZ : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int pGHZIDField;
        
        private int cXHDIDField;
        
        private int cPLXIDField;
        
        private int sJHDSLField;
        
        private decimal sJHDXSField;
        
        private int fYZCFSField;
        
        private decimal fYZCField;
        
        private decimal fYZCJEField;
        
        private decimal sJTHLField;
        
        private decimal bsField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private int cJRField;
        
        private string cJSJField;
        
        private int xGRField;
        
        private string xGSJField;
        
        private string cPLXField;
        
        private string fYZCFSDESField;
        
        private string cJRNAMEField;
        
        private string xGRNAMEField;
        
        private string cPFLField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int PGHZID {
            get {
                return this.pGHZIDField;
            }
            set {
                this.pGHZIDField = value;
                this.RaisePropertyChanged("PGHZID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int CXHDID {
            get {
                return this.cXHDIDField;
            }
            set {
                this.cXHDIDField = value;
                this.RaisePropertyChanged("CXHDID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int CPLXID {
            get {
                return this.cPLXIDField;
            }
            set {
                this.cPLXIDField = value;
                this.RaisePropertyChanged("CPLXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int SJHDSL {
            get {
                return this.sJHDSLField;
            }
            set {
                this.sJHDSLField = value;
                this.RaisePropertyChanged("SJHDSL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public decimal SJHDXS {
            get {
                return this.sJHDXSField;
            }
            set {
                this.sJHDXSField = value;
                this.RaisePropertyChanged("SJHDXS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int FYZCFS {
            get {
                return this.fYZCFSField;
            }
            set {
                this.fYZCFSField = value;
                this.RaisePropertyChanged("FYZCFS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public decimal FYZC {
            get {
                return this.fYZCField;
            }
            set {
                this.fYZCField = value;
                this.RaisePropertyChanged("FYZC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public decimal FYZCJE {
            get {
                return this.fYZCJEField;
            }
            set {
                this.fYZCJEField = value;
                this.RaisePropertyChanged("FYZCJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public decimal SJTHL {
            get {
                return this.sJTHLField;
            }
            set {
                this.sJTHLField = value;
                this.RaisePropertyChanged("SJTHL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public decimal BS {
            get {
                return this.bsField;
            }
            set {
                this.bsField = value;
                this.RaisePropertyChanged("BS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
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
        public string CPLX {
            get {
                return this.cPLXField;
            }
            set {
                this.cPLXField = value;
                this.RaisePropertyChanged("CPLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string FYZCFSDES {
            get {
                return this.fYZCFSDESField;
            }
            set {
                this.fYZCFSDESField = value;
                this.RaisePropertyChanged("FYZCFSDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string CJRNAME {
            get {
                return this.cJRNAMEField;
            }
            set {
                this.cJRNAMEField = value;
                this.RaisePropertyChanged("CJRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string XGRNAME {
            get {
                return this.xGRNAMEField;
            }
            set {
                this.xGRNAMEField = value;
                this.RaisePropertyChanged("XGRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string CPFL {
            get {
                return this.cPFLField;
            }
            set {
                this.cPFLField = value;
                this.RaisePropertyChanged("CPFL");
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
    public interface COST_CXHDPGHZSoapChannel : Sonluk.UI.Model.CRM.COST_CXHDPGHZService.COST_CXHDPGHZSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_CXHDPGHZSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_CXHDPGHZService.COST_CXHDPGHZSoap>, Sonluk.UI.Model.CRM.COST_CXHDPGHZService.COST_CXHDPGHZSoap {
        
        public COST_CXHDPGHZSoapClient() {
        }
        
        public COST_CXHDPGHZSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_CXHDPGHZSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CXHDPGHZSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CXHDPGHZSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ[] ReadByParam(Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int PGHZID, string ptoken) {
            return base.Channel.Delete(PGHZID, ptoken);
        }
        
        public int DeleteByCXHDID(int CXHDID, string ptoken) {
            return base.Channel.DeleteByCXHDID(CXHDID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ[] GetReport(Sonluk.UI.Model.CRM.COST_CXHDPGHZService.CRM_COST_CXHDPGHZ model, string ptoken) {
            return base.Channel.GetReport(model, ptoken);
        }
        
        public int AutoUpdate(int CXHDID, string ptoken) {
            return base.Channel.AutoUpdate(CXHDID, ptoken);
        }
    }
}