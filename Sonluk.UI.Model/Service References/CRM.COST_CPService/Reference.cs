﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_CPService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_CPService.COST_CPSoap")]
    public interface COST_CPSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP[] ReadByParam(Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int CPID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReportYEARData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP_YEARDATA ReportYEARData(int LKAYEARTTID, int ISACTIVE, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/JXSReport", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP_JXSReport[] JXSReport(Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP_JXSReport model, int STAFFID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_CP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int cPIDField;
        
        private int lKAYEARTTIDField;
        
        private string sAPCPField;
        
        private string cPFLField;
        
        private double mCSJGJField;
        
        private double mCSJSJField;
        
        private int lASTYEARSJXLField;
        
        private int tHISYEARSLYGField;
        
        private double lASTYEARXSSJField;
        
        private double tHISYEARXSYGField;
        
        private decimal lASTYEARXSSJ_SJField;
        
        private decimal tHISYEARXSYG_SJField;
        
        private double cCJXSField;
        
        private double mLXJField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private string cPMCField;
        
        private int bZNUMField;
        
        private double pRICE_OUTField;
        
        private double pRICE_INField;
        
        private double pROFIT_OUTField;
        
        private double pROFIT_INField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int CPID {
            get {
                return this.cPIDField;
            }
            set {
                this.cPIDField = value;
                this.RaisePropertyChanged("CPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int LKAYEARTTID {
            get {
                return this.lKAYEARTTIDField;
            }
            set {
                this.lKAYEARTTIDField = value;
                this.RaisePropertyChanged("LKAYEARTTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SAPCP {
            get {
                return this.sAPCPField;
            }
            set {
                this.sAPCPField = value;
                this.RaisePropertyChanged("SAPCP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CPFL {
            get {
                return this.cPFLField;
            }
            set {
                this.cPFLField = value;
                this.RaisePropertyChanged("CPFL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public double MCSJGJ {
            get {
                return this.mCSJGJField;
            }
            set {
                this.mCSJGJField = value;
                this.RaisePropertyChanged("MCSJGJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public double MCSJSJ {
            get {
                return this.mCSJSJField;
            }
            set {
                this.mCSJSJField = value;
                this.RaisePropertyChanged("MCSJSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int LASTYEARSJXL {
            get {
                return this.lASTYEARSJXLField;
            }
            set {
                this.lASTYEARSJXLField = value;
                this.RaisePropertyChanged("LASTYEARSJXL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int THISYEARSLYG {
            get {
                return this.tHISYEARSLYGField;
            }
            set {
                this.tHISYEARSLYGField = value;
                this.RaisePropertyChanged("THISYEARSLYG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public double LASTYEARXSSJ {
            get {
                return this.lASTYEARXSSJField;
            }
            set {
                this.lASTYEARXSSJField = value;
                this.RaisePropertyChanged("LASTYEARXSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public double THISYEARXSYG {
            get {
                return this.tHISYEARXSYGField;
            }
            set {
                this.tHISYEARXSYGField = value;
                this.RaisePropertyChanged("THISYEARXSYG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public decimal LASTYEARXSSJ_SJ {
            get {
                return this.lASTYEARXSSJ_SJField;
            }
            set {
                this.lASTYEARXSSJ_SJField = value;
                this.RaisePropertyChanged("LASTYEARXSSJ_SJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public decimal THISYEARXSYG_SJ {
            get {
                return this.tHISYEARXSYG_SJField;
            }
            set {
                this.tHISYEARXSYG_SJField = value;
                this.RaisePropertyChanged("THISYEARXSYG_SJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public double CCJXS {
            get {
                return this.cCJXSField;
            }
            set {
                this.cCJXSField = value;
                this.RaisePropertyChanged("CCJXS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public double MLXJ {
            get {
                return this.mLXJField;
            }
            set {
                this.mLXJField = value;
                this.RaisePropertyChanged("MLXJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string CPMC {
            get {
                return this.cPMCField;
            }
            set {
                this.cPMCField = value;
                this.RaisePropertyChanged("CPMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int BZNUM {
            get {
                return this.bZNUMField;
            }
            set {
                this.bZNUMField = value;
                this.RaisePropertyChanged("BZNUM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public double PRICE_OUT {
            get {
                return this.pRICE_OUTField;
            }
            set {
                this.pRICE_OUTField = value;
                this.RaisePropertyChanged("PRICE_OUT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public double PRICE_IN {
            get {
                return this.pRICE_INField;
            }
            set {
                this.pRICE_INField = value;
                this.RaisePropertyChanged("PRICE_IN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public double PROFIT_OUT {
            get {
                return this.pROFIT_OUTField;
            }
            set {
                this.pROFIT_OUTField = value;
                this.RaisePropertyChanged("PROFIT_OUT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public double PROFIT_IN {
            get {
                return this.pROFIT_INField;
            }
            set {
                this.pROFIT_INField = value;
                this.RaisePropertyChanged("PROFIT_IN");
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
    public partial class CRM_COST_CP_JXSReport : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string kPSLField;
        
        private string kPJEField;
        
        private string tHISYEARXLYGField;
        
        private string cCJXSField;
        
        private string cPFLField;
        
        private string cPMCField;
        
        private string sAPCPField;
        
        private string hTYEARField;
        
        private string jXSSAPSNField;
        
        private string jXSNAMEField;
        
        private int jXSIDField;
        
        private string yWYNAMEField;
        
        private string kPSL_LAST2YEARField;
        
        private string kPJE_LAST2YEARField;
        
        private string kPSL_LASTYEARField;
        
        private string kPJE_LASTYEARField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string KPSL {
            get {
                return this.kPSLField;
            }
            set {
                this.kPSLField = value;
                this.RaisePropertyChanged("KPSL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string KPJE {
            get {
                return this.kPJEField;
            }
            set {
                this.kPJEField = value;
                this.RaisePropertyChanged("KPJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string THISYEARXLYG {
            get {
                return this.tHISYEARXLYGField;
            }
            set {
                this.tHISYEARXLYGField = value;
                this.RaisePropertyChanged("THISYEARXLYG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CCJXS {
            get {
                return this.cCJXSField;
            }
            set {
                this.cCJXSField = value;
                this.RaisePropertyChanged("CCJXS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string CPFL {
            get {
                return this.cPFLField;
            }
            set {
                this.cPFLField = value;
                this.RaisePropertyChanged("CPFL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string CPMC {
            get {
                return this.cPMCField;
            }
            set {
                this.cPMCField = value;
                this.RaisePropertyChanged("CPMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string SAPCP {
            get {
                return this.sAPCPField;
            }
            set {
                this.sAPCPField = value;
                this.RaisePropertyChanged("SAPCP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string JXSSAPSN {
            get {
                return this.jXSSAPSNField;
            }
            set {
                this.jXSSAPSNField = value;
                this.RaisePropertyChanged("JXSSAPSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string JXSNAME {
            get {
                return this.jXSNAMEField;
            }
            set {
                this.jXSNAMEField = value;
                this.RaisePropertyChanged("JXSNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int JXSID {
            get {
                return this.jXSIDField;
            }
            set {
                this.jXSIDField = value;
                this.RaisePropertyChanged("JXSID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string YWYNAME {
            get {
                return this.yWYNAMEField;
            }
            set {
                this.yWYNAMEField = value;
                this.RaisePropertyChanged("YWYNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string KPSL_LAST2YEAR {
            get {
                return this.kPSL_LAST2YEARField;
            }
            set {
                this.kPSL_LAST2YEARField = value;
                this.RaisePropertyChanged("KPSL_LAST2YEAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string KPJE_LAST2YEAR {
            get {
                return this.kPJE_LAST2YEARField;
            }
            set {
                this.kPJE_LAST2YEARField = value;
                this.RaisePropertyChanged("KPJE_LAST2YEAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string KPSL_LASTYEAR {
            get {
                return this.kPSL_LASTYEARField;
            }
            set {
                this.kPSL_LASTYEARField = value;
                this.RaisePropertyChanged("KPSL_LASTYEAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string KPJE_LASTYEAR {
            get {
                return this.kPJE_LASTYEARField;
            }
            set {
                this.kPJE_LASTYEARField = value;
                this.RaisePropertyChanged("KPJE_LASTYEAR");
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
    public partial class CRM_COST_CP_YEARDATA : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double a_XSField;
        
        private double a_ZBField;
        
        private double b_XSField;
        
        private double b_ZBField;
        
        private double c_XSField;
        
        private double c_ZBField;
        
        private double mCXS_LSField;
        
        private double mCXS_GJField;
        
        private double mLXJField;
        
        private double mLLField;
        
        private double gSSJLRField;
        
        private double cCJXS_HTField;
        
        private double cCJXS_GSField;
        
        private double gSZCFY_HTField;
        
        private double gSZCFY_GSField;
        
        private double cXZFYField;
        
        private double xSRWField;
        
        private double xSJDField;
        
        private double a_XSRWField;
        
        private double a_XSJDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public double A_XS {
            get {
                return this.a_XSField;
            }
            set {
                this.a_XSField = value;
                this.RaisePropertyChanged("A_XS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public double A_ZB {
            get {
                return this.a_ZBField;
            }
            set {
                this.a_ZBField = value;
                this.RaisePropertyChanged("A_ZB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public double B_XS {
            get {
                return this.b_XSField;
            }
            set {
                this.b_XSField = value;
                this.RaisePropertyChanged("B_XS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public double B_ZB {
            get {
                return this.b_ZBField;
            }
            set {
                this.b_ZBField = value;
                this.RaisePropertyChanged("B_ZB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public double C_XS {
            get {
                return this.c_XSField;
            }
            set {
                this.c_XSField = value;
                this.RaisePropertyChanged("C_XS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public double C_ZB {
            get {
                return this.c_ZBField;
            }
            set {
                this.c_ZBField = value;
                this.RaisePropertyChanged("C_ZB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public double MCXS_LS {
            get {
                return this.mCXS_LSField;
            }
            set {
                this.mCXS_LSField = value;
                this.RaisePropertyChanged("MCXS_LS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public double MCXS_GJ {
            get {
                return this.mCXS_GJField;
            }
            set {
                this.mCXS_GJField = value;
                this.RaisePropertyChanged("MCXS_GJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public double MLXJ {
            get {
                return this.mLXJField;
            }
            set {
                this.mLXJField = value;
                this.RaisePropertyChanged("MLXJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public double MLL {
            get {
                return this.mLLField;
            }
            set {
                this.mLLField = value;
                this.RaisePropertyChanged("MLL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public double GSSJLR {
            get {
                return this.gSSJLRField;
            }
            set {
                this.gSSJLRField = value;
                this.RaisePropertyChanged("GSSJLR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public double CCJXS_HT {
            get {
                return this.cCJXS_HTField;
            }
            set {
                this.cCJXS_HTField = value;
                this.RaisePropertyChanged("CCJXS_HT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public double CCJXS_GS {
            get {
                return this.cCJXS_GSField;
            }
            set {
                this.cCJXS_GSField = value;
                this.RaisePropertyChanged("CCJXS_GS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public double GSZCFY_HT {
            get {
                return this.gSZCFY_HTField;
            }
            set {
                this.gSZCFY_HTField = value;
                this.RaisePropertyChanged("GSZCFY_HT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public double GSZCFY_GS {
            get {
                return this.gSZCFY_GSField;
            }
            set {
                this.gSZCFY_GSField = value;
                this.RaisePropertyChanged("GSZCFY_GS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public double CXZFY {
            get {
                return this.cXZFYField;
            }
            set {
                this.cXZFYField = value;
                this.RaisePropertyChanged("CXZFY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public double XSRW {
            get {
                return this.xSRWField;
            }
            set {
                this.xSRWField = value;
                this.RaisePropertyChanged("XSRW");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public double XSJD {
            get {
                return this.xSJDField;
            }
            set {
                this.xSJDField = value;
                this.RaisePropertyChanged("XSJD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public double A_XSRW {
            get {
                return this.a_XSRWField;
            }
            set {
                this.a_XSRWField = value;
                this.RaisePropertyChanged("A_XSRW");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public double A_XSJD {
            get {
                return this.a_XSJDField;
            }
            set {
                this.a_XSJDField = value;
                this.RaisePropertyChanged("A_XSJD");
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
    public interface COST_CPSoapChannel : Sonluk.UI.Model.CRM.COST_CPService.COST_CPSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_CPSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_CPService.COST_CPSoap>, Sonluk.UI.Model.CRM.COST_CPService.COST_CPSoap {
        
        public COST_CPSoapClient() {
        }
        
        public COST_CPSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_CPSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CPSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CPSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP[] ReadByParam(Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int CPID, string ptoken) {
            return base.Channel.Delete(CPID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP_YEARDATA ReportYEARData(int LKAYEARTTID, int ISACTIVE, string ptoken) {
            return base.Channel.ReportYEARData(LKAYEARTTID, ISACTIVE, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP_JXSReport[] JXSReport(Sonluk.UI.Model.CRM.COST_CPService.CRM_COST_CP_JXSReport model, int STAFFID, string ptoken) {
            return base.Channel.JXSReport(model, STAFFID, ptoken);
        }
    }
}
