﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_CXYService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_CXYService.COST_CXYSoap")]
    public interface COST_CXYSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY[] ReadByParam(Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY model, int STAFFID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByGZ", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY[] ReadByGZ(Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int CXYID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_CXY : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int cXYIDField;
        
        private int kHIDField;
        
        private int mDIDField;
        
        private int fZRField;
        
        private double lAST3Field;
        
        private double lAST2Field;
        
        private double lAST1Field;
        
        private double xSZEField;
        
        private string zYZCField;
        
        private int gwField;
        
        private int iSCHANGEField;
        
        private double bASEField;
        
        private double yGXSEField;
        
        private string nAMEField;
        
        private int sEXField;
        
        private int zZZTField;
        
        private string cODEField;
        
        private string tELField;
        
        private string sGRQField;
        
        private string bANKField;
        
        private string cARDNUMField;
        
        private string qZCSField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private int cJRField;
        
        private string cJSJField;
        
        private int xGRField;
        
        private string xGSJField;
        
        private string sFDESField;
        
        private string cSDESField;
        
        private string mcField;
        
        private string cRMIDField;
        
        private string sAPSNField;
        
        private double gWGZField;
        
        private string pKHIDDESField;
        
        private int cOSTITEMIDField;
        
        private int cXYCOUNTField;
        
        private string gWDESField;
        
        private string cJRDESField;
        
        private string mDMCField;
        
        private string xTMCField;
        
        private string zZZTDESField;
        
        private string sALARY_YEARField;
        
        private string sALARY_MONTHField;
        
        private int sTAFFIDField;
        
        private string lZSJField;
        
        private int sALARYField;
        
        private int cOEFFICIENTField;
        
        private string sELECT_LZSJField;
        
        private string jcField;
        
        private string pJCField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int CXYID {
            get {
                return this.cXYIDField;
            }
            set {
                this.cXYIDField = value;
                this.RaisePropertyChanged("CXYID");
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int FZR {
            get {
                return this.fZRField;
            }
            set {
                this.fZRField = value;
                this.RaisePropertyChanged("FZR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public double LAST3 {
            get {
                return this.lAST3Field;
            }
            set {
                this.lAST3Field = value;
                this.RaisePropertyChanged("LAST3");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public double LAST2 {
            get {
                return this.lAST2Field;
            }
            set {
                this.lAST2Field = value;
                this.RaisePropertyChanged("LAST2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public double LAST1 {
            get {
                return this.lAST1Field;
            }
            set {
                this.lAST1Field = value;
                this.RaisePropertyChanged("LAST1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public double XSZE {
            get {
                return this.xSZEField;
            }
            set {
                this.xSZEField = value;
                this.RaisePropertyChanged("XSZE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string ZYZC {
            get {
                return this.zYZCField;
            }
            set {
                this.zYZCField = value;
                this.RaisePropertyChanged("ZYZC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int GW {
            get {
                return this.gwField;
            }
            set {
                this.gwField = value;
                this.RaisePropertyChanged("GW");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int ISCHANGE {
            get {
                return this.iSCHANGEField;
            }
            set {
                this.iSCHANGEField = value;
                this.RaisePropertyChanged("ISCHANGE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public double BASE {
            get {
                return this.bASEField;
            }
            set {
                this.bASEField = value;
                this.RaisePropertyChanged("BASE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public double YGXSE {
            get {
                return this.yGXSEField;
            }
            set {
                this.yGXSEField = value;
                this.RaisePropertyChanged("YGXSE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string NAME {
            get {
                return this.nAMEField;
            }
            set {
                this.nAMEField = value;
                this.RaisePropertyChanged("NAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public int SEX {
            get {
                return this.sEXField;
            }
            set {
                this.sEXField = value;
                this.RaisePropertyChanged("SEX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public int ZZZT {
            get {
                return this.zZZTField;
            }
            set {
                this.zZZTField = value;
                this.RaisePropertyChanged("ZZZT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string CODE {
            get {
                return this.cODEField;
            }
            set {
                this.cODEField = value;
                this.RaisePropertyChanged("CODE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string TEL {
            get {
                return this.tELField;
            }
            set {
                this.tELField = value;
                this.RaisePropertyChanged("TEL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string SGRQ {
            get {
                return this.sGRQField;
            }
            set {
                this.sGRQField = value;
                this.RaisePropertyChanged("SGRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string BANK {
            get {
                return this.bANKField;
            }
            set {
                this.bANKField = value;
                this.RaisePropertyChanged("BANK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string CARDNUM {
            get {
                return this.cARDNUMField;
            }
            set {
                this.cARDNUMField = value;
                this.RaisePropertyChanged("CARDNUM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string QZCS {
            get {
                return this.qZCSField;
            }
            set {
                this.qZCSField = value;
                this.RaisePropertyChanged("QZCS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=30)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=31)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=32)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=33)]
        public double GWGZ {
            get {
                return this.gWGZField;
            }
            set {
                this.gWGZField = value;
                this.RaisePropertyChanged("GWGZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=34)]
        public string PKHIDDES {
            get {
                return this.pKHIDDESField;
            }
            set {
                this.pKHIDDESField = value;
                this.RaisePropertyChanged("PKHIDDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=35)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=36)]
        public int CXYCOUNT {
            get {
                return this.cXYCOUNTField;
            }
            set {
                this.cXYCOUNTField = value;
                this.RaisePropertyChanged("CXYCOUNT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=37)]
        public string GWDES {
            get {
                return this.gWDESField;
            }
            set {
                this.gWDESField = value;
                this.RaisePropertyChanged("GWDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=38)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=39)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=40)]
        public string XTMC {
            get {
                return this.xTMCField;
            }
            set {
                this.xTMCField = value;
                this.RaisePropertyChanged("XTMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=41)]
        public string ZZZTDES {
            get {
                return this.zZZTDESField;
            }
            set {
                this.zZZTDESField = value;
                this.RaisePropertyChanged("ZZZTDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=42)]
        public string SALARY_YEAR {
            get {
                return this.sALARY_YEARField;
            }
            set {
                this.sALARY_YEARField = value;
                this.RaisePropertyChanged("SALARY_YEAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=43)]
        public string SALARY_MONTH {
            get {
                return this.sALARY_MONTHField;
            }
            set {
                this.sALARY_MONTHField = value;
                this.RaisePropertyChanged("SALARY_MONTH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=44)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=45)]
        public string LZSJ {
            get {
                return this.lZSJField;
            }
            set {
                this.lZSJField = value;
                this.RaisePropertyChanged("LZSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=46)]
        public int SALARY {
            get {
                return this.sALARYField;
            }
            set {
                this.sALARYField = value;
                this.RaisePropertyChanged("SALARY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=47)]
        public int COEFFICIENT {
            get {
                return this.cOEFFICIENTField;
            }
            set {
                this.cOEFFICIENTField = value;
                this.RaisePropertyChanged("COEFFICIENT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=48)]
        public string SELECT_LZSJ {
            get {
                return this.sELECT_LZSJField;
            }
            set {
                this.sELECT_LZSJField = value;
                this.RaisePropertyChanged("SELECT_LZSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=49)]
        public string JC {
            get {
                return this.jcField;
            }
            set {
                this.jcField = value;
                this.RaisePropertyChanged("JC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=50)]
        public string PJC {
            get {
                return this.pJCField;
            }
            set {
                this.pJCField = value;
                this.RaisePropertyChanged("PJC");
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
    public interface COST_CXYSoapChannel : Sonluk.UI.Model.CRM.COST_CXYService.COST_CXYSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_CXYSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_CXYService.COST_CXYSoap>, Sonluk.UI.Model.CRM.COST_CXYService.COST_CXYSoap {
        
        public COST_CXYSoapClient() {
        }
        
        public COST_CXYSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_CXYSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CXYSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CXYSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY[] ReadByParam(Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY model, int STAFFID, string ptoken) {
            return base.Channel.ReadByParam(model, STAFFID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY[] ReadByGZ(Sonluk.UI.Model.CRM.COST_CXYService.CRM_COST_CXY model, string ptoken) {
            return base.Channel.ReadByGZ(model, ptoken);
        }
        
        public int Delete(int CXYID, string ptoken) {
            return base.Channel.Delete(CXYID, ptoken);
        }
    }
}
