﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.HR.XZGL_FFJLZDService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HR.XZGL_FFJLZDService.WS_HR_XZGL_FFJLZDSoap")]
    public interface WS_HR_XZGL_FFJLZDSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN INSERT(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN UPDATE(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD model, int LB, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_SELECT SELECT(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GS_FORMULA_VERIFY", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN GS_FORMULA_VERIFY(string FORMULA, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_YYTABLE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLE_SELECT SELECT_YYTABLE(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLE model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_YYTABLEZD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLEZD_SELECT SELECT_YYTABLEZD(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLEZD model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_YYTABLEZD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN INSERT_YYTABLEZD(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLEZD model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_YYTABLEZD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN UPDATE_YYTABLEZD(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLEZD model, int LB, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_FFJLZD : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int zDIDField;
        
        private string fFJLZDNAMEField;
        
        private string fFJLZDMSField;
        
        private int iSACTIONField;
        
        private int iSHAVEGSField;
        
        private string fORMULAField;
        
        private int iSQTYYField;
        
        private string qTYYTABLEField;
        
        private string qTYYZDField;
        
        private int zDLBField;
        
        private string zDLBNAMEField;
        
        private int iSDELETEField;
        
        private int mXIDField;
        
        private int jSLEVELField;
        
        private int iSJJXField;
        
        private int jSORDERField;
        
        private int iSGDZDField;
        
        private int sORTNOField;
        
        private int xSBLGZField;
        
        private int yXXSWField;
        
        private string xSBLGZNAMEField;
        
        private string mYPWField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int ZDID {
            get {
                return this.zDIDField;
            }
            set {
                this.zDIDField = value;
                this.RaisePropertyChanged("ZDID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string FFJLZDNAME {
            get {
                return this.fFJLZDNAMEField;
            }
            set {
                this.fFJLZDNAMEField = value;
                this.RaisePropertyChanged("FFJLZDNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string FFJLZDMS {
            get {
                return this.fFJLZDMSField;
            }
            set {
                this.fFJLZDMSField = value;
                this.RaisePropertyChanged("FFJLZDMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int ISACTION {
            get {
                return this.iSACTIONField;
            }
            set {
                this.iSACTIONField = value;
                this.RaisePropertyChanged("ISACTION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int ISHAVEGS {
            get {
                return this.iSHAVEGSField;
            }
            set {
                this.iSHAVEGSField = value;
                this.RaisePropertyChanged("ISHAVEGS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string FORMULA {
            get {
                return this.fORMULAField;
            }
            set {
                this.fORMULAField = value;
                this.RaisePropertyChanged("FORMULA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int ISQTYY {
            get {
                return this.iSQTYYField;
            }
            set {
                this.iSQTYYField = value;
                this.RaisePropertyChanged("ISQTYY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string QTYYTABLE {
            get {
                return this.qTYYTABLEField;
            }
            set {
                this.qTYYTABLEField = value;
                this.RaisePropertyChanged("QTYYTABLE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string QTYYZD {
            get {
                return this.qTYYZDField;
            }
            set {
                this.qTYYZDField = value;
                this.RaisePropertyChanged("QTYYZD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int ZDLB {
            get {
                return this.zDLBField;
            }
            set {
                this.zDLBField = value;
                this.RaisePropertyChanged("ZDLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string ZDLBNAME {
            get {
                return this.zDLBNAMEField;
            }
            set {
                this.zDLBNAMEField = value;
                this.RaisePropertyChanged("ZDLBNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int ISDELETE {
            get {
                return this.iSDELETEField;
            }
            set {
                this.iSDELETEField = value;
                this.RaisePropertyChanged("ISDELETE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int MXID {
            get {
                return this.mXIDField;
            }
            set {
                this.mXIDField = value;
                this.RaisePropertyChanged("MXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public int JSLEVEL {
            get {
                return this.jSLEVELField;
            }
            set {
                this.jSLEVELField = value;
                this.RaisePropertyChanged("JSLEVEL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public int ISJJX {
            get {
                return this.iSJJXField;
            }
            set {
                this.iSJJXField = value;
                this.RaisePropertyChanged("ISJJX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public int JSORDER {
            get {
                return this.jSORDERField;
            }
            set {
                this.jSORDERField = value;
                this.RaisePropertyChanged("JSORDER");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public int ISGDZD {
            get {
                return this.iSGDZDField;
            }
            set {
                this.iSGDZDField = value;
                this.RaisePropertyChanged("ISGDZD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int SORTNO {
            get {
                return this.sORTNOField;
            }
            set {
                this.sORTNOField = value;
                this.RaisePropertyChanged("SORTNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public int XSBLGZ {
            get {
                return this.xSBLGZField;
            }
            set {
                this.xSBLGZField = value;
                this.RaisePropertyChanged("XSBLGZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public int YXXSW {
            get {
                return this.yXXSWField;
            }
            set {
                this.yXXSWField = value;
                this.RaisePropertyChanged("YXXSW");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string XSBLGZNAME {
            get {
                return this.xSBLGZNAMEField;
            }
            set {
                this.xSBLGZNAMEField = value;
                this.RaisePropertyChanged("XSBLGZNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string MYPW {
            get {
                return this.mYPWField;
            }
            set {
                this.mYPWField = value;
                this.RaisePropertyChanged("MYPW");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_FFJLZD_YYTABLEZD_LIST : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string tABLENAMEField;
        
        private string zDNAMEField;
        
        private string zDMSField;
        
        private decimal zDVALUEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string TABLENAME {
            get {
                return this.tABLENAMEField;
            }
            set {
                this.tABLENAMEField = value;
                this.RaisePropertyChanged("TABLENAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ZDNAME {
            get {
                return this.zDNAMEField;
            }
            set {
                this.zDNAMEField = value;
                this.RaisePropertyChanged("ZDNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ZDMS {
            get {
                return this.zDMSField;
            }
            set {
                this.zDMSField = value;
                this.RaisePropertyChanged("ZDMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public decimal ZDVALUE {
            get {
                return this.zDVALUEField;
            }
            set {
                this.zDVALUEField = value;
                this.RaisePropertyChanged("ZDVALUE");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_FFJLZD_YYTABLEZD_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private HR_XZGL_FFJLZD_YYTABLEZD_LIST[] hR_XZGL_FFJLZD_YYTABLEZD_LISTField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public HR_XZGL_FFJLZD_YYTABLEZD_LIST[] HR_XZGL_FFJLZD_YYTABLEZD_LIST {
            get {
                return this.hR_XZGL_FFJLZD_YYTABLEZD_LISTField;
            }
            set {
                this.hR_XZGL_FFJLZD_YYTABLEZD_LISTField = value;
                this.RaisePropertyChanged("HR_XZGL_FFJLZD_YYTABLEZD_LIST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public MES_RETURN MES_RETURN {
            get {
                return this.mES_RETURNField;
            }
            set {
                this.mES_RETURNField = value;
                this.RaisePropertyChanged("MES_RETURN");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_FFJLZD_YYTABLEZD : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string tABLENAMEField;
        
        private string zDMSField;
        
        private decimal zDVALUEField;
        
        private int mXIDField;
        
        private string zDNAMEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string TABLENAME {
            get {
                return this.tABLENAMEField;
            }
            set {
                this.tABLENAMEField = value;
                this.RaisePropertyChanged("TABLENAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ZDMS {
            get {
                return this.zDMSField;
            }
            set {
                this.zDMSField = value;
                this.RaisePropertyChanged("ZDMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public decimal ZDVALUE {
            get {
                return this.zDVALUEField;
            }
            set {
                this.zDVALUEField = value;
                this.RaisePropertyChanged("ZDVALUE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int MXID {
            get {
                return this.mXIDField;
            }
            set {
                this.mXIDField = value;
                this.RaisePropertyChanged("MXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string ZDNAME {
            get {
                return this.zDNAMEField;
            }
            set {
                this.zDNAMEField = value;
                this.RaisePropertyChanged("ZDNAME");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_FFJLZD_YYTABLE_LIST : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string tABLENAMEField;
        
        private string tABLEMSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string TABLENAME {
            get {
                return this.tABLENAMEField;
            }
            set {
                this.tABLENAMEField = value;
                this.RaisePropertyChanged("TABLENAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string TABLEMS {
            get {
                return this.tABLEMSField;
            }
            set {
                this.tABLEMSField = value;
                this.RaisePropertyChanged("TABLEMS");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_FFJLZD_YYTABLE_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private HR_XZGL_FFJLZD_YYTABLE_LIST[] hR_XZGL_FFJLZD_YYTABLE_LISTField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public HR_XZGL_FFJLZD_YYTABLE_LIST[] HR_XZGL_FFJLZD_YYTABLE_LIST {
            get {
                return this.hR_XZGL_FFJLZD_YYTABLE_LISTField;
            }
            set {
                this.hR_XZGL_FFJLZD_YYTABLE_LISTField = value;
                this.RaisePropertyChanged("HR_XZGL_FFJLZD_YYTABLE_LIST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public MES_RETURN MES_RETURN {
            get {
                return this.mES_RETURNField;
            }
            set {
                this.mES_RETURNField = value;
                this.RaisePropertyChanged("MES_RETURN");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_FFJLZD_YYTABLE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int tABLELBField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int TABLELB {
            get {
                return this.tABLELBField;
            }
            set {
                this.tABLELBField = value;
                this.RaisePropertyChanged("TABLELB");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HR_XZGL_FFJLZD_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private HR_XZGL_FFJLZD[] hR_XZGL_FFJLZDField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public HR_XZGL_FFJLZD[] HR_XZGL_FFJLZD {
            get {
                return this.hR_XZGL_FFJLZDField;
            }
            set {
                this.hR_XZGL_FFJLZDField = value;
                this.RaisePropertyChanged("HR_XZGL_FFJLZD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public MES_RETURN MES_RETURN {
            get {
                return this.mES_RETURNField;
            }
            set {
                this.mES_RETURNField = value;
                this.RaisePropertyChanged("MES_RETURN");
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
    public interface WS_HR_XZGL_FFJLZDSoapChannel : Sonluk.UI.Model.HR.XZGL_FFJLZDService.WS_HR_XZGL_FFJLZDSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_HR_XZGL_FFJLZDSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.HR.XZGL_FFJLZDService.WS_HR_XZGL_FFJLZDSoap>, Sonluk.UI.Model.HR.XZGL_FFJLZDService.WS_HR_XZGL_FFJLZDSoap {
        
        public WS_HR_XZGL_FFJLZDSoapClient() {
        }
        
        public WS_HR_XZGL_FFJLZDSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_HR_XZGL_FFJLZDSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_HR_XZGL_FFJLZDSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_HR_XZGL_FFJLZDSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN INSERT(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN UPDATE(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD model, int LB, string ptoken) {
            return base.Channel.UPDATE(model, LB, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_SELECT SELECT(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN GS_FORMULA_VERIFY(string FORMULA, string ptoken) {
            return base.Channel.GS_FORMULA_VERIFY(FORMULA, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLE_SELECT SELECT_YYTABLE(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLE model, string ptoken) {
            return base.Channel.SELECT_YYTABLE(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLEZD_SELECT SELECT_YYTABLEZD(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLEZD model, string ptoken) {
            return base.Channel.SELECT_YYTABLEZD(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN INSERT_YYTABLEZD(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLEZD model, string ptoken) {
            return base.Channel.INSERT_YYTABLEZD(model, ptoken);
        }
        
        public Sonluk.UI.Model.HR.XZGL_FFJLZDService.MES_RETURN UPDATE_YYTABLEZD(Sonluk.UI.Model.HR.XZGL_FFJLZDService.HR_XZGL_FFJLZD_YYTABLEZD model, int LB, string ptoken) {
            return base.Channel.UPDATE_YYTABLEZD(model, LB, ptoken);
        }
    }
}
