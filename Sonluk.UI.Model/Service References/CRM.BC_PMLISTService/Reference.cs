﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.BC_PMLISTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.BC_PMLISTService.BC_PMLISTSoap")]
    public interface BC_PMLISTSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectByModel", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST[] SelectByModel(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectGD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList[] SelectGD(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectByGD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList[] SelectByGD(string AUFNR, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectByGDandParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList[] SelectByGDandParam(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectByDXM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList SelectByDXM(string DXM, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectOtherBigByDXM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList[] SelectOtherBigByDXM(string DXM, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int PMID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteByGD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteByGD(string AUFNR, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdatePM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int UpdatePM(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectMATNRbyCHARGandPM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST[] SelectMATNRbyCHARGandPM(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectMATNRbyCHARGandPM2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST[] SelectMATNRbyCHARGandPM2(string charg, string pm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectKHbyMCP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_KH[] SelectKHbyMCP(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectKHbyMCP2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_KH[] SelectKHbyMCP2(string charg, string pm, string matnr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectKHbyDXM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_KH[] SelectKHbyDXM(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectKHbyNHM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_KH[] SelectKHbyNHM(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_CHMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create_WLM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create_WLM(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_WLM_TEMP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete_WLM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete_WLM(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Modify_WLM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Modify_WLM(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetNewWLM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_WebMSG GetNewWLM();
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CRM_BC_PMLISTList))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_BC_PMLIST : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int pMIDField;
        
        private int pMTYPEField;
        
        private string aUFNRField;
        
        private string mATNRField;
        
        private string mAKTXField;
        
        private string cHARGField;
        
        private int zBONField;
        
        private int zPKSField;
        
        private string dXMField;
        
        private string tPMField;
        
        private string pmField;
        
        private int iSACTIVEField;
        
        private string bEIZField;
        
        private int cJRField;
        
        private string cJRQField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int PMID {
            get {
                return this.pMIDField;
            }
            set {
                this.pMIDField = value;
                this.RaisePropertyChanged("PMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int PMTYPE {
            get {
                return this.pMTYPEField;
            }
            set {
                this.pMTYPEField = value;
                this.RaisePropertyChanged("PMTYPE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string AUFNR {
            get {
                return this.aUFNRField;
            }
            set {
                this.aUFNRField = value;
                this.RaisePropertyChanged("AUFNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
                this.RaisePropertyChanged("MATNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string MAKTX {
            get {
                return this.mAKTXField;
            }
            set {
                this.mAKTXField = value;
                this.RaisePropertyChanged("MAKTX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string CHARG {
            get {
                return this.cHARGField;
            }
            set {
                this.cHARGField = value;
                this.RaisePropertyChanged("CHARG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int ZBON {
            get {
                return this.zBONField;
            }
            set {
                this.zBONField = value;
                this.RaisePropertyChanged("ZBON");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int ZPKS {
            get {
                return this.zPKSField;
            }
            set {
                this.zPKSField = value;
                this.RaisePropertyChanged("ZPKS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string DXM {
            get {
                return this.dXMField;
            }
            set {
                this.dXMField = value;
                this.RaisePropertyChanged("DXM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string TPM {
            get {
                return this.tPMField;
            }
            set {
                this.tPMField = value;
                this.RaisePropertyChanged("TPM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string PM {
            get {
                return this.pmField;
            }
            set {
                this.pmField = value;
                this.RaisePropertyChanged("PM");
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
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string CJRQ {
            get {
                return this.cJRQField;
            }
            set {
                this.cJRQField = value;
                this.RaisePropertyChanged("CJRQ");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_WebMSG : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool sUCCESSField;
        
        private string mSGField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool SUCCESS {
            get {
                return this.sUCCESSField;
            }
            set {
                this.sUCCESSField = value;
                this.RaisePropertyChanged("SUCCESS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MSG {
            get {
                return this.mSGField;
            }
            set {
                this.mSGField = value;
                this.RaisePropertyChanged("MSG");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_BC_WLM_TEMP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mANDTField;
        
        private string tGWLMField;
        
        private string sRWLMField;
        
        private string cJRQField;
        
        private string cJSJField;
        
        private string cJRField;
        
        private string xGRQField;
        
        private string xGSJField;
        
        private string xGRField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MANDT {
            get {
                return this.mANDTField;
            }
            set {
                this.mANDTField = value;
                this.RaisePropertyChanged("MANDT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string TGWLM {
            get {
                return this.tGWLMField;
            }
            set {
                this.tGWLMField = value;
                this.RaisePropertyChanged("TGWLM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SRWLM {
            get {
                return this.sRWLMField;
            }
            set {
                this.sRWLMField = value;
                this.RaisePropertyChanged("SRWLM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CJRQ {
            get {
                return this.cJRQField;
            }
            set {
                this.cJRQField = value;
                this.RaisePropertyChanged("CJRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string XGRQ {
            get {
                return this.xGRQField;
            }
            set {
                this.xGRQField = value;
                this.RaisePropertyChanged("XGRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string XGR {
            get {
                return this.xGRField;
            }
            set {
                this.xGRField = value;
                this.RaisePropertyChanged("XGR");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_BC_CHMX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int pMCHMXIDField;
        
        private int pMCHTTIDField;
        
        private string vBELNField;
        
        private string pOSNRField;
        
        private string tPMField;
        
        private string dXMField;
        
        private string nHMField;
        
        private string cHARGField;
        
        private string lWEDTField;
        
        private string qXBSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int PMCHMXID {
            get {
                return this.pMCHMXIDField;
            }
            set {
                this.pMCHMXIDField = value;
                this.RaisePropertyChanged("PMCHMXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int PMCHTTID {
            get {
                return this.pMCHTTIDField;
            }
            set {
                this.pMCHTTIDField = value;
                this.RaisePropertyChanged("PMCHTTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string VBELN {
            get {
                return this.vBELNField;
            }
            set {
                this.vBELNField = value;
                this.RaisePropertyChanged("VBELN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string POSNR {
            get {
                return this.pOSNRField;
            }
            set {
                this.pOSNRField = value;
                this.RaisePropertyChanged("POSNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string TPM {
            get {
                return this.tPMField;
            }
            set {
                this.tPMField = value;
                this.RaisePropertyChanged("TPM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string DXM {
            get {
                return this.dXMField;
            }
            set {
                this.dXMField = value;
                this.RaisePropertyChanged("DXM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string NHM {
            get {
                return this.nHMField;
            }
            set {
                this.nHMField = value;
                this.RaisePropertyChanged("NHM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CHARG {
            get {
                return this.cHARGField;
            }
            set {
                this.cHARGField = value;
                this.RaisePropertyChanged("CHARG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string LWEDT {
            get {
                return this.lWEDTField;
            }
            set {
                this.lWEDTField = value;
                this.RaisePropertyChanged("LWEDT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string QXBS {
            get {
                return this.qXBSField;
            }
            set {
                this.qXBSField = value;
                this.RaisePropertyChanged("QXBS");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_BC_KH : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int kHIDField;
        
        private string cRMIDField;
        
        private string sAPSNField;
        
        private string mcField;
        
        private string dXMField;
        
        private string vBELNField;
        
        private string wADAT_ISTField;
        
        private string aREAField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string DXM {
            get {
                return this.dXMField;
            }
            set {
                this.dXMField = value;
                this.RaisePropertyChanged("DXM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string VBELN {
            get {
                return this.vBELNField;
            }
            set {
                this.vBELNField = value;
                this.RaisePropertyChanged("VBELN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string WADAT_IST {
            get {
                return this.wADAT_ISTField;
            }
            set {
                this.wADAT_ISTField = value;
                this.RaisePropertyChanged("WADAT_IST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string AREA {
            get {
                return this.aREAField;
            }
            set {
                this.aREAField = value;
                this.RaisePropertyChanged("AREA");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_BC_PMLISTList : CRM_BC_PMLIST {
        
        private string cJRDESField;
        
        private int sUOSHUField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int SUOSHU {
            get {
                return this.sUOSHUField;
            }
            set {
                this.sUOSHUField = value;
                this.RaisePropertyChanged("SUOSHU");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BC_PMLISTSoapChannel : Sonluk.UI.Model.CRM.BC_PMLISTService.BC_PMLISTSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BC_PMLISTSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.BC_PMLISTService.BC_PMLISTSoap>, Sonluk.UI.Model.CRM.BC_PMLISTService.BC_PMLISTSoap {
        
        public BC_PMLISTSoapClient() {
        }
        
        public BC_PMLISTSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BC_PMLISTSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BC_PMLISTSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BC_PMLISTSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST[] SelectByModel(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken) {
            return base.Channel.SelectByModel(model, BEGIN_DATE, END_DATE, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList[] SelectGD(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken) {
            return base.Channel.SelectGD(model, BEGIN_DATE, END_DATE, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList[] SelectByGD(string AUFNR, string ptoken) {
            return base.Channel.SelectByGD(AUFNR, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList[] SelectByGDandParam(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken) {
            return base.Channel.SelectByGDandParam(model, BEGIN_DATE, END_DATE, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList SelectByDXM(string DXM, string ptoken) {
            return base.Channel.SelectByDXM(DXM, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLISTList[] SelectOtherBigByDXM(string DXM, string ptoken) {
            return base.Channel.SelectOtherBigByDXM(DXM, ptoken);
        }
        
        public int Delete(int PMID, string ptoken) {
            return base.Channel.Delete(PMID, ptoken);
        }
        
        public int DeleteByGD(string AUFNR, string ptoken) {
            return base.Channel.DeleteByGD(AUFNR, ptoken);
        }
        
        public int UpdatePM(string ptoken) {
            return base.Channel.UpdatePM(ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST[] SelectMATNRbyCHARGandPM(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string ptoken) {
            return base.Channel.SelectMATNRbyCHARGandPM(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST[] SelectMATNRbyCHARGandPM2(string charg, string pm) {
            return base.Channel.SelectMATNRbyCHARGandPM2(charg, pm);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_KH[] SelectKHbyMCP(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string ptoken) {
            return base.Channel.SelectKHbyMCP(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_KH[] SelectKHbyMCP2(string charg, string pm, string matnr) {
            return base.Channel.SelectKHbyMCP2(charg, pm, matnr);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_KH[] SelectKHbyDXM(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_PMLIST model, string ptoken) {
            return base.Channel.SelectKHbyDXM(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_KH[] SelectKHbyNHM(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_CHMX model, string ptoken) {
            return base.Channel.SelectKHbyNHM(model, ptoken);
        }
        
        public int Create_WLM(Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_WLM_TEMP model, string ptoken) {
            return base.Channel.Create_WLM(model, ptoken);
        }
        
        public int Delete_WLM(string ptoken) {
            return base.Channel.Delete_WLM(ptoken);
        }
        
        public int Modify_WLM(string ptoken) {
            return base.Channel.Modify_WLM(ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_WebMSG GetNewWLM() {
            return base.Channel.GetNewWLM();
        }
    }
}