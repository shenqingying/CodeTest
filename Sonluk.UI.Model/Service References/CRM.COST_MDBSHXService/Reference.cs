﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_MDBSHXService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_MDBSHXService.COST_MDBSHXSoap")]
    public interface COST_MDBSHXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX[] ReadByParam(Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX model, int STAFFID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int CPLXID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read_Unconnected", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX[] Read_Unconnected(Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_MDBSHX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int mDBSHXIDField;
        
        private int mDBSIDField;
        
        private decimal hXJEField;
        
        private string fPHMField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private int cJRField;
        
        private string cJSJField;
        
        private int xGRField;
        
        private string xGSJField;
        
        private string cJRNAMEField;
        
        private string xGRNAMEField;
        
        private string hTYEARField;
        
        private string hTMONTHField;
        
        private int cOSTITEMIDField;
        
        private int fYLBField;
        
        private int kHIDField;
        
        private int mDIDField;
        
        private string mcField;
        
        private string cRMIDField;
        
        private string sAPSNField;
        
        private string mDMCField;
        
        private string mDCRMIDField;
        
        private string dISPLAYITEMField;
        
        private string dISPLAYPOSITIONField;
        
        private string bEGINDATEField;
        
        private string eNDDATEField;
        
        private decimal qSYJXSField;
        
        private int hAVECXYField;
        
        private int pAYWAYField;
        
        private int hAVEDDField;
        
        private decimal sJXSField;
        
        private decimal sJFYField;
        
        private decimal sJFBField;
        
        private string pAYWAYDESField;
        
        private string sFDESField;
        
        private string cSDESField;
        
        private string fYCJRNAMEField;
        
        private string fYXGRNAMEField;
        
        private string cOSTITEMIDDESField;
        
        private decimal yHXJEField;
        
        private int hXZTField;
        
        private string tHLField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int MDBSHXID {
            get {
                return this.mDBSHXIDField;
            }
            set {
                this.mDBSHXIDField = value;
                this.RaisePropertyChanged("MDBSHXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int MDBSID {
            get {
                return this.mDBSIDField;
            }
            set {
                this.mDBSIDField = value;
                this.RaisePropertyChanged("MDBSID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public decimal HXJE {
            get {
                return this.hXJEField;
            }
            set {
                this.hXJEField = value;
                this.RaisePropertyChanged("HXJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string FPHM {
            get {
                return this.fPHMField;
            }
            set {
                this.fPHMField = value;
                this.RaisePropertyChanged("FPHM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string DISPLAYITEM {
            get {
                return this.dISPLAYITEMField;
            }
            set {
                this.dISPLAYITEMField = value;
                this.RaisePropertyChanged("DISPLAYITEM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string DISPLAYPOSITION {
            get {
                return this.dISPLAYPOSITIONField;
            }
            set {
                this.dISPLAYPOSITIONField = value;
                this.RaisePropertyChanged("DISPLAYPOSITION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string BEGINDATE {
            get {
                return this.bEGINDATEField;
            }
            set {
                this.bEGINDATEField = value;
                this.RaisePropertyChanged("BEGINDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string ENDDATE {
            get {
                return this.eNDDATEField;
            }
            set {
                this.eNDDATEField = value;
                this.RaisePropertyChanged("ENDDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public decimal QSYJXS {
            get {
                return this.qSYJXSField;
            }
            set {
                this.qSYJXSField = value;
                this.RaisePropertyChanged("QSYJXS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        public int HAVECXY {
            get {
                return this.hAVECXYField;
            }
            set {
                this.hAVECXYField = value;
                this.RaisePropertyChanged("HAVECXY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
        public int PAYWAY {
            get {
                return this.pAYWAYField;
            }
            set {
                this.pAYWAYField = value;
                this.RaisePropertyChanged("PAYWAY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=30)]
        public int HAVEDD {
            get {
                return this.hAVEDDField;
            }
            set {
                this.hAVEDDField = value;
                this.RaisePropertyChanged("HAVEDD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=31)]
        public decimal SJXS {
            get {
                return this.sJXSField;
            }
            set {
                this.sJXSField = value;
                this.RaisePropertyChanged("SJXS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=32)]
        public decimal SJFY {
            get {
                return this.sJFYField;
            }
            set {
                this.sJFYField = value;
                this.RaisePropertyChanged("SJFY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=33)]
        public decimal SJFB {
            get {
                return this.sJFBField;
            }
            set {
                this.sJFBField = value;
                this.RaisePropertyChanged("SJFB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=34)]
        public string PAYWAYDES {
            get {
                return this.pAYWAYDESField;
            }
            set {
                this.pAYWAYDESField = value;
                this.RaisePropertyChanged("PAYWAYDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=35)]
        public string SFDES {
            get {
                return this.sFDESField;
            }
            set {
                this.sFDESField = value;
                this.RaisePropertyChanged("SFDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=36)]
        public string CSDES {
            get {
                return this.cSDESField;
            }
            set {
                this.cSDESField = value;
                this.RaisePropertyChanged("CSDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=37)]
        public string FYCJRNAME {
            get {
                return this.fYCJRNAMEField;
            }
            set {
                this.fYCJRNAMEField = value;
                this.RaisePropertyChanged("FYCJRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=38)]
        public string FYXGRNAME {
            get {
                return this.fYXGRNAMEField;
            }
            set {
                this.fYXGRNAMEField = value;
                this.RaisePropertyChanged("FYXGRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=39)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=40)]
        public decimal YHXJE {
            get {
                return this.yHXJEField;
            }
            set {
                this.yHXJEField = value;
                this.RaisePropertyChanged("YHXJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=41)]
        public int HXZT {
            get {
                return this.hXZTField;
            }
            set {
                this.hXZTField = value;
                this.RaisePropertyChanged("HXZT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=42)]
        public string THL {
            get {
                return this.tHLField;
            }
            set {
                this.tHLField = value;
                this.RaisePropertyChanged("THL");
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
    public interface COST_MDBSHXSoapChannel : Sonluk.UI.Model.CRM.COST_MDBSHXService.COST_MDBSHXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_MDBSHXSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_MDBSHXService.COST_MDBSHXSoap>, Sonluk.UI.Model.CRM.COST_MDBSHXService.COST_MDBSHXSoap {
        
        public COST_MDBSHXSoapClient() {
        }
        
        public COST_MDBSHXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_MDBSHXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_MDBSHXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_MDBSHXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX[] ReadByParam(Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX model, int STAFFID, string ptoken) {
            return base.Channel.ReadByParam(model, STAFFID, ptoken);
        }
        
        public int Delete(int CPLXID, string ptoken) {
            return base.Channel.Delete(CPLXID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX[] Read_Unconnected(Sonluk.UI.Model.CRM.COST_MDBSHXService.CRM_COST_MDBSHX model, string ptoken) {
            return base.Channel.Read_Unconnected(model, ptoken);
        }
    }
}
