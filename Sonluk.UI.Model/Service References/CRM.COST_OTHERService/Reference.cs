﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_OTHERService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_OTHERService.COST_OTHERSoap")]
    public interface COST_OTHERSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER[] ReadByParam(Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER model, int STAFFID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read_Unconnected", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER[] Read_Unconnected(Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int OTHERID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_OTHER : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int oTHERIDField;
        
        private string hTYEARField;
        
        private string hTMONTHField;
        
        private int cOSTITEMIDField;
        
        private int kHIDField;
        
        private int mDIDField;
        
        private int cXYFYLXField;
        
        private decimal sQJEField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private int cJRField;
        
        private string cJSJField;
        
        private int xGRField;
        
        private string xGSJField;
        
        private string mcField;
        
        private string sAPSNField;
        
        private string cRMIDField;
        
        private string mDMCField;
        
        private string mDCRMIDField;
        
        private string cJRNAMEField;
        
        private string xGRNAMEField;
        
        private string cOSTITEMIDDESField;
        
        private string cXYFYLXDESField;
        
        private int fYLBField;
        
        private string fYLBDESField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int OTHERID {
            get {
                return this.oTHERIDField;
            }
            set {
                this.oTHERIDField = value;
                this.RaisePropertyChanged("OTHERID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string HTYEAR {
            get {
                return this.hTYEARField;
            }
            set {
                this.hTYEARField = value;
                this.RaisePropertyChanged("HTYEAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string HTMONTH {
            get {
                return this.hTMONTHField;
            }
            set {
                this.hTMONTHField = value;
                this.RaisePropertyChanged("HTMONTH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int COSTITEMID {
            get {
                return this.cOSTITEMIDField;
            }
            set {
                this.cOSTITEMIDField = value;
                this.RaisePropertyChanged("COSTITEMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int MDID {
            get {
                return this.mDIDField;
            }
            set {
                this.mDIDField = value;
                this.RaisePropertyChanged("MDID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int CXYFYLX {
            get {
                return this.cXYFYLXField;
            }
            set {
                this.cXYFYLXField = value;
                this.RaisePropertyChanged("CXYFYLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public decimal SQJE {
            get {
                return this.sQJEField;
            }
            set {
                this.sQJEField = value;
                this.RaisePropertyChanged("SQJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string MC {
            get {
                return this.mcField;
            }
            set {
                this.mcField = value;
                this.RaisePropertyChanged("MC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string SAPSN {
            get {
                return this.sAPSNField;
            }
            set {
                this.sAPSNField = value;
                this.RaisePropertyChanged("SAPSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string CRMID {
            get {
                return this.cRMIDField;
            }
            set {
                this.cRMIDField = value;
                this.RaisePropertyChanged("CRMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string MDMC {
            get {
                return this.mDMCField;
            }
            set {
                this.mDMCField = value;
                this.RaisePropertyChanged("MDMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string MDCRMID {
            get {
                return this.mDCRMIDField;
            }
            set {
                this.mDCRMIDField = value;
                this.RaisePropertyChanged("MDCRMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string COSTITEMIDDES {
            get {
                return this.cOSTITEMIDDESField;
            }
            set {
                this.cOSTITEMIDDESField = value;
                this.RaisePropertyChanged("COSTITEMIDDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string CXYFYLXDES {
            get {
                return this.cXYFYLXDESField;
            }
            set {
                this.cXYFYLXDESField = value;
                this.RaisePropertyChanged("CXYFYLXDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public int FYLB {
            get {
                return this.fYLBField;
            }
            set {
                this.fYLBField = value;
                this.RaisePropertyChanged("FYLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string FYLBDES {
            get {
                return this.fYLBDESField;
            }
            set {
                this.fYLBDESField = value;
                this.RaisePropertyChanged("FYLBDES");
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
    public interface COST_OTHERSoapChannel : Sonluk.UI.Model.CRM.COST_OTHERService.COST_OTHERSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_OTHERSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_OTHERService.COST_OTHERSoap>, Sonluk.UI.Model.CRM.COST_OTHERService.COST_OTHERSoap {
        
        public COST_OTHERSoapClient() {
        }
        
        public COST_OTHERSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_OTHERSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_OTHERSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_OTHERSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER[] ReadByParam(Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER model, int STAFFID, string ptoken) {
            return base.Channel.ReadByParam(model, STAFFID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER[] Read_Unconnected(Sonluk.UI.Model.CRM.COST_OTHERService.CRM_COST_OTHER model, string ptoken) {
            return base.Channel.Read_Unconnected(model, ptoken);
        }
        
        public int Delete(int OTHERID, string ptoken) {
            return base.Channel.Delete(OTHERID, ptoken);
        }
    }
}