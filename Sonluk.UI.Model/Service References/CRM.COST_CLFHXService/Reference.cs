﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_CLFHXService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_CLFHXService.COST_CLFHXSoap")]
    public interface COST_CLFHXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_CLFHXService.CRM_COST_CLFHX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_CLFHXService.CRM_COST_CLFHX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_CLFHXService.CRM_COST_CLFHX[] ReadByParam(Sonluk.UI.Model.CRM.COST_CLFHXService.CRM_COST_CLFHX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int CLFHXID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_CLFHX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int cLFHXIDField;
        
        private int sTAFFIDField;
        
        private double hXJEField;
        
        private int fGLDField;
        
        private int sfField;
        
        private int cBZXField;
        
        private string cWHSBHField;
        
        private string bEIZField;
        
        private double jT_JEField;
        
        private double zS_DAYSField;
        
        private double zS_JEField;
        
        private double bT_DAYSField;
        
        private double bT_JEField;
        
        private int qT_ITEMField;
        
        private double qT_JEField;
        
        private string gSNYField;
        
        private int iSACTIVEField;
        
        private int cJRField;
        
        private string cJSJField;
        
        private int xGRField;
        
        private string xGSJField;
        
        private string sFDESField;
        
        private string cJRDESField;
        
        private string xGRDESField;
        
        private string sTAFFNAMEField;
        
        private string cBZXDESField;
        
        private string fGLDDESField;
        
        private string cOSTITEMMCField;
        
        private int bXFSField;
        
        private double pMJGField;
        
        private double pjField;
        
        private int slField;
        
        private double wSJEField;
        
        private string xSSJField;
        
        private string tIME_BEGINField;
        
        private string tIME_ENDField;
        
        private string xSSJ_BEGINField;
        
        private string xSSJ_ENDField;
        
        private double jT_JPJEField;
        
        private int jT_JPSLField;
        
        private double jT_JPWSJEField;
        
        private double jT_HCPJEField;
        
        private int jT_HCPSLField;
        
        private double jT_HCPWSJEField;
        
        private double jT_KCPJEField;
        
        private int jT_KCPSLField;
        
        private double jT_KCPWSJEField;
        
        private double jCJSFField;
        
        private int zS_SLField;
        
        private double zS_WSJEField;
        
        private string cWHSBHDESField;
        
        private int qT_SLField;
        
        private double qT_WSJEField;
        
        private double jT_JPTZJEField;
        
        private double jT_HCPJE2Field;
        
        private int jT_HCPSL2Field;
        
        private double jT_HCPWSJE2Field;
        
        private double jT_KCPJE2Field;
        
        private int jT_KCPSL2Field;
        
        private double jT_KCPWSJE2Field;
        
        private double zS_DAYS2Field;
        
        private double zS_JE2Field;
        
        private int zS_SL2Field;
        
        private double zS_WSJE2Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int CLFHXID {
            get {
                return this.cLFHXIDField;
            }
            set {
                this.cLFHXIDField = value;
                this.RaisePropertyChanged("CLFHXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public double HXJE {
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
        public int FGLD {
            get {
                return this.fGLDField;
            }
            set {
                this.fGLDField = value;
                this.RaisePropertyChanged("FGLD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int SF {
            get {
                return this.sfField;
            }
            set {
                this.sfField = value;
                this.RaisePropertyChanged("SF");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int CBZX {
            get {
                return this.cBZXField;
            }
            set {
                this.cBZXField = value;
                this.RaisePropertyChanged("CBZX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string CWHSBH {
            get {
                return this.cWHSBHField;
            }
            set {
                this.cWHSBHField = value;
                this.RaisePropertyChanged("CWHSBH");
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
        public double JT_JE {
            get {
                return this.jT_JEField;
            }
            set {
                this.jT_JEField = value;
                this.RaisePropertyChanged("JT_JE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public double ZS_DAYS {
            get {
                return this.zS_DAYSField;
            }
            set {
                this.zS_DAYSField = value;
                this.RaisePropertyChanged("ZS_DAYS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public double ZS_JE {
            get {
                return this.zS_JEField;
            }
            set {
                this.zS_JEField = value;
                this.RaisePropertyChanged("ZS_JE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public double BT_DAYS {
            get {
                return this.bT_DAYSField;
            }
            set {
                this.bT_DAYSField = value;
                this.RaisePropertyChanged("BT_DAYS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public double BT_JE {
            get {
                return this.bT_JEField;
            }
            set {
                this.bT_JEField = value;
                this.RaisePropertyChanged("BT_JE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public int QT_ITEM {
            get {
                return this.qT_ITEMField;
            }
            set {
                this.qT_ITEMField = value;
                this.RaisePropertyChanged("QT_ITEM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public double QT_JE {
            get {
                return this.qT_JEField;
            }
            set {
                this.qT_JEField = value;
                this.RaisePropertyChanged("QT_JE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string GSNY {
            get {
                return this.gSNYField;
            }
            set {
                this.gSNYField = value;
                this.RaisePropertyChanged("GSNY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string CBZXDES {
            get {
                return this.cBZXDESField;
            }
            set {
                this.cBZXDESField = value;
                this.RaisePropertyChanged("CBZXDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string FGLDDES {
            get {
                return this.fGLDDESField;
            }
            set {
                this.fGLDDESField = value;
                this.RaisePropertyChanged("FGLDDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public string COSTITEMMC {
            get {
                return this.cOSTITEMMCField;
            }
            set {
                this.cOSTITEMMCField = value;
                this.RaisePropertyChanged("COSTITEMMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        public int BXFS {
            get {
                return this.bXFSField;
            }
            set {
                this.bXFSField = value;
                this.RaisePropertyChanged("BXFS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
        public double PMJG {
            get {
                return this.pMJGField;
            }
            set {
                this.pMJGField = value;
                this.RaisePropertyChanged("PMJG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=30)]
        public double PJ {
            get {
                return this.pjField;
            }
            set {
                this.pjField = value;
                this.RaisePropertyChanged("PJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=31)]
        public int SL {
            get {
                return this.slField;
            }
            set {
                this.slField = value;
                this.RaisePropertyChanged("SL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=32)]
        public double WSJE {
            get {
                return this.wSJEField;
            }
            set {
                this.wSJEField = value;
                this.RaisePropertyChanged("WSJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=33)]
        public string XSSJ {
            get {
                return this.xSSJField;
            }
            set {
                this.xSSJField = value;
                this.RaisePropertyChanged("XSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=34)]
        public string TIME_BEGIN {
            get {
                return this.tIME_BEGINField;
            }
            set {
                this.tIME_BEGINField = value;
                this.RaisePropertyChanged("TIME_BEGIN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=35)]
        public string TIME_END {
            get {
                return this.tIME_ENDField;
            }
            set {
                this.tIME_ENDField = value;
                this.RaisePropertyChanged("TIME_END");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=36)]
        public string XSSJ_BEGIN {
            get {
                return this.xSSJ_BEGINField;
            }
            set {
                this.xSSJ_BEGINField = value;
                this.RaisePropertyChanged("XSSJ_BEGIN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=37)]
        public string XSSJ_END {
            get {
                return this.xSSJ_ENDField;
            }
            set {
                this.xSSJ_ENDField = value;
                this.RaisePropertyChanged("XSSJ_END");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=38)]
        public double JT_JPJE {
            get {
                return this.jT_JPJEField;
            }
            set {
                this.jT_JPJEField = value;
                this.RaisePropertyChanged("JT_JPJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=39)]
        public int JT_JPSL {
            get {
                return this.jT_JPSLField;
            }
            set {
                this.jT_JPSLField = value;
                this.RaisePropertyChanged("JT_JPSL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=40)]
        public double JT_JPWSJE {
            get {
                return this.jT_JPWSJEField;
            }
            set {
                this.jT_JPWSJEField = value;
                this.RaisePropertyChanged("JT_JPWSJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=41)]
        public double JT_HCPJE {
            get {
                return this.jT_HCPJEField;
            }
            set {
                this.jT_HCPJEField = value;
                this.RaisePropertyChanged("JT_HCPJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=42)]
        public int JT_HCPSL {
            get {
                return this.jT_HCPSLField;
            }
            set {
                this.jT_HCPSLField = value;
                this.RaisePropertyChanged("JT_HCPSL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=43)]
        public double JT_HCPWSJE {
            get {
                return this.jT_HCPWSJEField;
            }
            set {
                this.jT_HCPWSJEField = value;
                this.RaisePropertyChanged("JT_HCPWSJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=44)]
        public double JT_KCPJE {
            get {
                return this.jT_KCPJEField;
            }
            set {
                this.jT_KCPJEField = value;
                this.RaisePropertyChanged("JT_KCPJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=45)]
        public int JT_KCPSL {
            get {
                return this.jT_KCPSLField;
            }
            set {
                this.jT_KCPSLField = value;
                this.RaisePropertyChanged("JT_KCPSL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=46)]
        public double JT_KCPWSJE {
            get {
                return this.jT_KCPWSJEField;
            }
            set {
                this.jT_KCPWSJEField = value;
                this.RaisePropertyChanged("JT_KCPWSJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=47)]
        public double JCJSF {
            get {
                return this.jCJSFField;
            }
            set {
                this.jCJSFField = value;
                this.RaisePropertyChanged("JCJSF");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=48)]
        public int ZS_SL {
            get {
                return this.zS_SLField;
            }
            set {
                this.zS_SLField = value;
                this.RaisePropertyChanged("ZS_SL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=49)]
        public double ZS_WSJE {
            get {
                return this.zS_WSJEField;
            }
            set {
                this.zS_WSJEField = value;
                this.RaisePropertyChanged("ZS_WSJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=50)]
        public string CWHSBHDES {
            get {
                return this.cWHSBHDESField;
            }
            set {
                this.cWHSBHDESField = value;
                this.RaisePropertyChanged("CWHSBHDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=51)]
        public int QT_SL {
            get {
                return this.qT_SLField;
            }
            set {
                this.qT_SLField = value;
                this.RaisePropertyChanged("QT_SL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=52)]
        public double QT_WSJE {
            get {
                return this.qT_WSJEField;
            }
            set {
                this.qT_WSJEField = value;
                this.RaisePropertyChanged("QT_WSJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=53)]
        public double JT_JPTZJE {
            get {
                return this.jT_JPTZJEField;
            }
            set {
                this.jT_JPTZJEField = value;
                this.RaisePropertyChanged("JT_JPTZJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=54)]
        public double JT_HCPJE2 {
            get {
                return this.jT_HCPJE2Field;
            }
            set {
                this.jT_HCPJE2Field = value;
                this.RaisePropertyChanged("JT_HCPJE2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=55)]
        public int JT_HCPSL2 {
            get {
                return this.jT_HCPSL2Field;
            }
            set {
                this.jT_HCPSL2Field = value;
                this.RaisePropertyChanged("JT_HCPSL2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=56)]
        public double JT_HCPWSJE2 {
            get {
                return this.jT_HCPWSJE2Field;
            }
            set {
                this.jT_HCPWSJE2Field = value;
                this.RaisePropertyChanged("JT_HCPWSJE2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=57)]
        public double JT_KCPJE2 {
            get {
                return this.jT_KCPJE2Field;
            }
            set {
                this.jT_KCPJE2Field = value;
                this.RaisePropertyChanged("JT_KCPJE2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=58)]
        public int JT_KCPSL2 {
            get {
                return this.jT_KCPSL2Field;
            }
            set {
                this.jT_KCPSL2Field = value;
                this.RaisePropertyChanged("JT_KCPSL2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=59)]
        public double JT_KCPWSJE2 {
            get {
                return this.jT_KCPWSJE2Field;
            }
            set {
                this.jT_KCPWSJE2Field = value;
                this.RaisePropertyChanged("JT_KCPWSJE2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=60)]
        public double ZS_DAYS2 {
            get {
                return this.zS_DAYS2Field;
            }
            set {
                this.zS_DAYS2Field = value;
                this.RaisePropertyChanged("ZS_DAYS2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=61)]
        public double ZS_JE2 {
            get {
                return this.zS_JE2Field;
            }
            set {
                this.zS_JE2Field = value;
                this.RaisePropertyChanged("ZS_JE2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=62)]
        public int ZS_SL2 {
            get {
                return this.zS_SL2Field;
            }
            set {
                this.zS_SL2Field = value;
                this.RaisePropertyChanged("ZS_SL2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=63)]
        public double ZS_WSJE2 {
            get {
                return this.zS_WSJE2Field;
            }
            set {
                this.zS_WSJE2Field = value;
                this.RaisePropertyChanged("ZS_WSJE2");
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
    public interface COST_CLFHXSoapChannel : Sonluk.UI.Model.CRM.COST_CLFHXService.COST_CLFHXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_CLFHXSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_CLFHXService.COST_CLFHXSoap>, Sonluk.UI.Model.CRM.COST_CLFHXService.COST_CLFHXSoap {
        
        public COST_CLFHXSoapClient() {
        }
        
        public COST_CLFHXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_CLFHXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CLFHXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CLFHXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_CLFHXService.CRM_COST_CLFHX model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_CLFHXService.CRM_COST_CLFHX model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_CLFHXService.CRM_COST_CLFHX[] ReadByParam(Sonluk.UI.Model.CRM.COST_CLFHXService.CRM_COST_CLFHX model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int CLFHXID, string ptoken) {
            return base.Channel.Delete(CLFHXID, ptoken);
        }
    }
}
