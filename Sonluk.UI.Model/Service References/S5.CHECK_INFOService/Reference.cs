﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.S5.CHECK_INFOService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="S5.CHECK_INFOService.CHECK_INFOSoap")]
    public interface CHECK_INFOSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFOList[] Read(Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFOList model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read_HZINFO", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFOList[] Read_HZINFO(Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFOList model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.CHECK_INFOService.MES_RETURN Create(Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFO model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.CHECK_INFOService.MES_RETURN UPDATE(Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFO model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.S5.CHECK_INFOService.MES_RETURN DELETE(int ID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class FIVES_CHECK_INFOList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int iNFOIDField;
        
        private int tYPEIDField;
        
        private string tYPEMSField;
        
        private int sCOREIDField;
        
        private string sCOREMSField;
        
        private string jLTIMEField;
        
        private int sTAFFIDField;
        
        private string sTAFFNAMEField;
        
        private string rEMARKField;
        
        private string gcField;
        
        private int dEPARTIDField;
        
        private string dEPARTMSField;
        
        private int oPINTIDField;
        
        private string oPINTMSField;
        
        private int wORKSHOPIDField;
        
        private string wORKSHOPMSField;
        
        private int aCTIONField;
        
        private bool iSDELETEField;
        
        private string oPINTLOCATIONField;
        
        private string kSTIMEField;
        
        private string jSTIMEField;
        
        private int hgField;
        
        private string hGMSField;
        
        private int cHECKCOUNTField;
        
        private int bHGCOUNTField;
        
        private string sHOWTIMEField;
        
        private int sHOWNAMEField;
        
        private string sHOWNAMEMSField;
        
        private string pOSITIONField;
        
        private string fREQUENCYNAMEField;
        
        private int iSREPORTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int INFOID {
            get {
                return this.iNFOIDField;
            }
            set {
                this.iNFOIDField = value;
                this.RaisePropertyChanged("INFOID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int TYPEID {
            get {
                return this.tYPEIDField;
            }
            set {
                this.tYPEIDField = value;
                this.RaisePropertyChanged("TYPEID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string TYPEMS {
            get {
                return this.tYPEMSField;
            }
            set {
                this.tYPEMSField = value;
                this.RaisePropertyChanged("TYPEMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int SCOREID {
            get {
                return this.sCOREIDField;
            }
            set {
                this.sCOREIDField = value;
                this.RaisePropertyChanged("SCOREID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string SCOREMS {
            get {
                return this.sCOREMSField;
            }
            set {
                this.sCOREMSField = value;
                this.RaisePropertyChanged("SCOREMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string JLTIME {
            get {
                return this.jLTIMEField;
            }
            set {
                this.jLTIMEField = value;
                this.RaisePropertyChanged("JLTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string STAFFNAME {
            get {
                return this.sTAFFNAMEField;
            }
            set {
                this.sTAFFNAMEField = value;
                this.RaisePropertyChanged("STAFFNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string REMARK {
            get {
                return this.rEMARKField;
            }
            set {
                this.rEMARKField = value;
                this.RaisePropertyChanged("REMARK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int DEPARTID {
            get {
                return this.dEPARTIDField;
            }
            set {
                this.dEPARTIDField = value;
                this.RaisePropertyChanged("DEPARTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string DEPARTMS {
            get {
                return this.dEPARTMSField;
            }
            set {
                this.dEPARTMSField = value;
                this.RaisePropertyChanged("DEPARTMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int OPINTID {
            get {
                return this.oPINTIDField;
            }
            set {
                this.oPINTIDField = value;
                this.RaisePropertyChanged("OPINTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string OPINTMS {
            get {
                return this.oPINTMSField;
            }
            set {
                this.oPINTMSField = value;
                this.RaisePropertyChanged("OPINTMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public int WORKSHOPID {
            get {
                return this.wORKSHOPIDField;
            }
            set {
                this.wORKSHOPIDField = value;
                this.RaisePropertyChanged("WORKSHOPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string WORKSHOPMS {
            get {
                return this.wORKSHOPMSField;
            }
            set {
                this.wORKSHOPMSField = value;
                this.RaisePropertyChanged("WORKSHOPMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public int ACTION {
            get {
                return this.aCTIONField;
            }
            set {
                this.aCTIONField = value;
                this.RaisePropertyChanged("ACTION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public bool ISDELETE {
            get {
                return this.iSDELETEField;
            }
            set {
                this.iSDELETEField = value;
                this.RaisePropertyChanged("ISDELETE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string OPINTLOCATION {
            get {
                return this.oPINTLOCATIONField;
            }
            set {
                this.oPINTLOCATIONField = value;
                this.RaisePropertyChanged("OPINTLOCATION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string KSTIME {
            get {
                return this.kSTIMEField;
            }
            set {
                this.kSTIMEField = value;
                this.RaisePropertyChanged("KSTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string JSTIME {
            get {
                return this.jSTIMEField;
            }
            set {
                this.jSTIMEField = value;
                this.RaisePropertyChanged("JSTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public int HG {
            get {
                return this.hgField;
            }
            set {
                this.hgField = value;
                this.RaisePropertyChanged("HG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string HGMS {
            get {
                return this.hGMSField;
            }
            set {
                this.hGMSField = value;
                this.RaisePropertyChanged("HGMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public int CHECKCOUNT {
            get {
                return this.cHECKCOUNTField;
            }
            set {
                this.cHECKCOUNTField = value;
                this.RaisePropertyChanged("CHECKCOUNT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public int BHGCOUNT {
            get {
                return this.bHGCOUNTField;
            }
            set {
                this.bHGCOUNTField = value;
                this.RaisePropertyChanged("BHGCOUNT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string SHOWTIME {
            get {
                return this.sHOWTIMEField;
            }
            set {
                this.sHOWTIMEField = value;
                this.RaisePropertyChanged("SHOWTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public int SHOWNAME {
            get {
                return this.sHOWNAMEField;
            }
            set {
                this.sHOWNAMEField = value;
                this.RaisePropertyChanged("SHOWNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public string SHOWNAMEMS {
            get {
                return this.sHOWNAMEMSField;
            }
            set {
                this.sHOWNAMEMSField = value;
                this.RaisePropertyChanged("SHOWNAMEMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        public string POSITION {
            get {
                return this.pOSITIONField;
            }
            set {
                this.pOSITIONField = value;
                this.RaisePropertyChanged("POSITION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
        public string FREQUENCYNAME {
            get {
                return this.fREQUENCYNAMEField;
            }
            set {
                this.fREQUENCYNAMEField = value;
                this.RaisePropertyChanged("FREQUENCYNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=30)]
        public int ISREPORT {
            get {
                return this.iSREPORTField;
            }
            set {
                this.iSREPORTField = value;
                this.RaisePropertyChanged("ISREPORT");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
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
        
        private string mSGNOField;
        
        private int iSCLMSGField;
        
        private string cODEField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string MSGNO {
            get {
                return this.mSGNOField;
            }
            set {
                this.mSGNOField = value;
                this.RaisePropertyChanged("MSGNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int ISCLMSG {
            get {
                return this.iSCLMSGField;
            }
            set {
                this.iSCLMSGField = value;
                this.RaisePropertyChanged("ISCLMSG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string CODE {
            get {
                return this.cODEField;
            }
            set {
                this.cODEField = value;
                this.RaisePropertyChanged("CODE");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class FIVES_CHECK_INFO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int iNFOIDField;
        
        private int tYPEIDField;
        
        private string tYPEMSField;
        
        private int sCOREIDField;
        
        private string sCOREMSField;
        
        private string jLTIMEField;
        
        private int sTAFFIDField;
        
        private string sTAFFNAMEField;
        
        private string rEMARKField;
        
        private string gcField;
        
        private int dEPARTIDField;
        
        private string dEPARTMSField;
        
        private int oPINTIDField;
        
        private string oPINTMSField;
        
        private int wORKSHOPIDField;
        
        private string wORKSHOPMSField;
        
        private int aCTIONField;
        
        private bool iSDELETEField;
        
        private string oPINTLOCATIONField;
        
        private int hgField;
        
        private string sHOWTIMEField;
        
        private int sHOWNAMEField;
        
        private string sHOWNAMEMSField;
        
        private string pOSITIONField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int INFOID {
            get {
                return this.iNFOIDField;
            }
            set {
                this.iNFOIDField = value;
                this.RaisePropertyChanged("INFOID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int TYPEID {
            get {
                return this.tYPEIDField;
            }
            set {
                this.tYPEIDField = value;
                this.RaisePropertyChanged("TYPEID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string TYPEMS {
            get {
                return this.tYPEMSField;
            }
            set {
                this.tYPEMSField = value;
                this.RaisePropertyChanged("TYPEMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int SCOREID {
            get {
                return this.sCOREIDField;
            }
            set {
                this.sCOREIDField = value;
                this.RaisePropertyChanged("SCOREID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string SCOREMS {
            get {
                return this.sCOREMSField;
            }
            set {
                this.sCOREMSField = value;
                this.RaisePropertyChanged("SCOREMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string JLTIME {
            get {
                return this.jLTIMEField;
            }
            set {
                this.jLTIMEField = value;
                this.RaisePropertyChanged("JLTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string STAFFNAME {
            get {
                return this.sTAFFNAMEField;
            }
            set {
                this.sTAFFNAMEField = value;
                this.RaisePropertyChanged("STAFFNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string REMARK {
            get {
                return this.rEMARKField;
            }
            set {
                this.rEMARKField = value;
                this.RaisePropertyChanged("REMARK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int DEPARTID {
            get {
                return this.dEPARTIDField;
            }
            set {
                this.dEPARTIDField = value;
                this.RaisePropertyChanged("DEPARTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string DEPARTMS {
            get {
                return this.dEPARTMSField;
            }
            set {
                this.dEPARTMSField = value;
                this.RaisePropertyChanged("DEPARTMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int OPINTID {
            get {
                return this.oPINTIDField;
            }
            set {
                this.oPINTIDField = value;
                this.RaisePropertyChanged("OPINTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string OPINTMS {
            get {
                return this.oPINTMSField;
            }
            set {
                this.oPINTMSField = value;
                this.RaisePropertyChanged("OPINTMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public int WORKSHOPID {
            get {
                return this.wORKSHOPIDField;
            }
            set {
                this.wORKSHOPIDField = value;
                this.RaisePropertyChanged("WORKSHOPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string WORKSHOPMS {
            get {
                return this.wORKSHOPMSField;
            }
            set {
                this.wORKSHOPMSField = value;
                this.RaisePropertyChanged("WORKSHOPMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public int ACTION {
            get {
                return this.aCTIONField;
            }
            set {
                this.aCTIONField = value;
                this.RaisePropertyChanged("ACTION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public bool ISDELETE {
            get {
                return this.iSDELETEField;
            }
            set {
                this.iSDELETEField = value;
                this.RaisePropertyChanged("ISDELETE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string OPINTLOCATION {
            get {
                return this.oPINTLOCATIONField;
            }
            set {
                this.oPINTLOCATIONField = value;
                this.RaisePropertyChanged("OPINTLOCATION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public int HG {
            get {
                return this.hgField;
            }
            set {
                this.hgField = value;
                this.RaisePropertyChanged("HG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string SHOWTIME {
            get {
                return this.sHOWTIMEField;
            }
            set {
                this.sHOWTIMEField = value;
                this.RaisePropertyChanged("SHOWTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public int SHOWNAME {
            get {
                return this.sHOWNAMEField;
            }
            set {
                this.sHOWNAMEField = value;
                this.RaisePropertyChanged("SHOWNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string SHOWNAMEMS {
            get {
                return this.sHOWNAMEMSField;
            }
            set {
                this.sHOWNAMEMSField = value;
                this.RaisePropertyChanged("SHOWNAMEMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string POSITION {
            get {
                return this.pOSITIONField;
            }
            set {
                this.pOSITIONField = value;
                this.RaisePropertyChanged("POSITION");
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
    public interface CHECK_INFOSoapChannel : Sonluk.UI.Model.S5.CHECK_INFOService.CHECK_INFOSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CHECK_INFOSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.S5.CHECK_INFOService.CHECK_INFOSoap>, Sonluk.UI.Model.S5.CHECK_INFOService.CHECK_INFOSoap {
        
        public CHECK_INFOSoapClient() {
        }
        
        public CHECK_INFOSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CHECK_INFOSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CHECK_INFOSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CHECK_INFOSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFOList[] Read(Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFOList model, string ptoken) {
            return base.Channel.Read(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFOList[] Read_HZINFO(Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFOList model, string ptoken) {
            return base.Channel.Read_HZINFO(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.CHECK_INFOService.MES_RETURN Create(Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFO model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.CHECK_INFOService.MES_RETURN UPDATE(Sonluk.UI.Model.S5.CHECK_INFOService.FIVES_CHECK_INFO model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.S5.CHECK_INFOService.MES_RETURN DELETE(int ID, string ptoken) {
            return base.Channel.DELETE(ID, ptoken);
        }
    }
}
