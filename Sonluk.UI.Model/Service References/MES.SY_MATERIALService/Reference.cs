﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.SY_MATERIALService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.SY_MATERIALService.SY_MATERIALSoap")]
    public interface SY_MATERIALSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIALService.MES_RETURN INSERT(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIALService.MES_RETURN DELETE(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIALService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_SELECT SELECT(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_BY_GZZX", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_SELECT SELECT_BY_GZZX(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DW_SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_DW_SELECT DW_SELECT(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_DW model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_LB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_SELECT SELECT_LB(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_MATERIAL : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gcField;
        
        private string wLHField;
        
        private string wLMSField;
        
        private int iSACTIONField;
        
        private string wLGROUPField;
        
        private int jLRField;
        
        private string jLRNAMEField;
        
        private string jLTIMEField;
        
        private int uNITSIDField;
        
        private string uNITSNAMEField;
        
        private int dCXHField;
        
        private string dCXHNAMEField;
        
        private int dCDJField;
        
        private string dCDJNAMEField;
        
        private string dJBSField;
        
        private string gZZXBHField;
        
        private int wLLBField;
        
        private string rEMARKField;
        
        private int iSTRACEField;
        
        private int lbField;
        
        private int sTAFFIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string WLH {
            get {
                return this.wLHField;
            }
            set {
                this.wLHField = value;
                this.RaisePropertyChanged("WLH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string WLMS {
            get {
                return this.wLMSField;
            }
            set {
                this.wLMSField = value;
                this.RaisePropertyChanged("WLMS");
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
        public string WLGROUP {
            get {
                return this.wLGROUPField;
            }
            set {
                this.wLGROUPField = value;
                this.RaisePropertyChanged("WLGROUP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int JLR {
            get {
                return this.jLRField;
            }
            set {
                this.jLRField = value;
                this.RaisePropertyChanged("JLR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string JLRNAME {
            get {
                return this.jLRNAMEField;
            }
            set {
                this.jLRNAMEField = value;
                this.RaisePropertyChanged("JLRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int UNITSID {
            get {
                return this.uNITSIDField;
            }
            set {
                this.uNITSIDField = value;
                this.RaisePropertyChanged("UNITSID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string UNITSNAME {
            get {
                return this.uNITSNAMEField;
            }
            set {
                this.uNITSNAMEField = value;
                this.RaisePropertyChanged("UNITSNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int DCXH {
            get {
                return this.dCXHField;
            }
            set {
                this.dCXHField = value;
                this.RaisePropertyChanged("DCXH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string DCXHNAME {
            get {
                return this.dCXHNAMEField;
            }
            set {
                this.dCXHNAMEField = value;
                this.RaisePropertyChanged("DCXHNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int DCDJ {
            get {
                return this.dCDJField;
            }
            set {
                this.dCDJField = value;
                this.RaisePropertyChanged("DCDJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string DCDJNAME {
            get {
                return this.dCDJNAMEField;
            }
            set {
                this.dCDJNAMEField = value;
                this.RaisePropertyChanged("DCDJNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string DJBS {
            get {
                return this.dJBSField;
            }
            set {
                this.dJBSField = value;
                this.RaisePropertyChanged("DJBS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string GZZXBH {
            get {
                return this.gZZXBHField;
            }
            set {
                this.gZZXBHField = value;
                this.RaisePropertyChanged("GZZXBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public int WLLB {
            get {
                return this.wLLBField;
            }
            set {
                this.wLLBField = value;
                this.RaisePropertyChanged("WLLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public int ISTRACE {
            get {
                return this.iSTRACEField;
            }
            set {
                this.iSTRACEField = value;
                this.RaisePropertyChanged("ISTRACE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public int LB {
            get {
                return this.lbField;
            }
            set {
                this.lbField = value;
                this.RaisePropertyChanged("LB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public int STAFFID {
            get {
                return this.sTAFFIDField;
            }
            set {
                this.sTAFFIDField = value;
                this.RaisePropertyChanged("STAFFID");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_MATERIAL_DW_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_RETURN mES_RETURNField;
        
        private MES_SY_MATERIAL_DW[] mES_SY_MATERIAL_DWField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public MES_RETURN MES_RETURN {
            get {
                return this.mES_RETURNField;
            }
            set {
                this.mES_RETURNField = value;
                this.RaisePropertyChanged("MES_RETURN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public MES_SY_MATERIAL_DW[] MES_SY_MATERIAL_DW {
            get {
                return this.mES_SY_MATERIAL_DWField;
            }
            set {
                this.mES_SY_MATERIAL_DWField = value;
                this.RaisePropertyChanged("MES_SY_MATERIAL_DW");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_MATERIAL_DW : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string wLHField;
        
        private string mEINHField;
        
        private int uMREZField;
        
        private int uMRENField;
        
        private int lbField;
        
        private string uNITSNAMEField;
        
        private string wLMSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string WLH {
            get {
                return this.wLHField;
            }
            set {
                this.wLHField = value;
                this.RaisePropertyChanged("WLH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MEINH {
            get {
                return this.mEINHField;
            }
            set {
                this.mEINHField = value;
                this.RaisePropertyChanged("MEINH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int UMREZ {
            get {
                return this.uMREZField;
            }
            set {
                this.uMREZField = value;
                this.RaisePropertyChanged("UMREZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int UMREN {
            get {
                return this.uMRENField;
            }
            set {
                this.uMRENField = value;
                this.RaisePropertyChanged("UMREN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int LB {
            get {
                return this.lbField;
            }
            set {
                this.lbField = value;
                this.RaisePropertyChanged("LB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string UNITSNAME {
            get {
                return this.uNITSNAMEField;
            }
            set {
                this.uNITSNAMEField = value;
                this.RaisePropertyChanged("UNITSNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string WLMS {
            get {
                return this.wLMSField;
            }
            set {
                this.wLMSField = value;
                this.RaisePropertyChanged("WLMS");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_MATERIAL_LIST : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gcField;
        
        private string wLHField;
        
        private string wLMSField;
        
        private int iSACTIONField;
        
        private string wLGROUPField;
        
        private string wLGROUPNAMEField;
        
        private int jLRField;
        
        private string jLRNAMEField;
        
        private string jLTIMEField;
        
        private int uNITSIDField;
        
        private string uNITSNAMEField;
        
        private int dCXHField;
        
        private string dCXHNAMEField;
        
        private int dCDJField;
        
        private string dCDJNAMEField;
        
        private int wLLBField;
        
        private string wLLBNAMEField;
        
        private int iSTRACEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string WLH {
            get {
                return this.wLHField;
            }
            set {
                this.wLHField = value;
                this.RaisePropertyChanged("WLH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string WLMS {
            get {
                return this.wLMSField;
            }
            set {
                this.wLMSField = value;
                this.RaisePropertyChanged("WLMS");
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
        public string WLGROUP {
            get {
                return this.wLGROUPField;
            }
            set {
                this.wLGROUPField = value;
                this.RaisePropertyChanged("WLGROUP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string WLGROUPNAME {
            get {
                return this.wLGROUPNAMEField;
            }
            set {
                this.wLGROUPNAMEField = value;
                this.RaisePropertyChanged("WLGROUPNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int JLR {
            get {
                return this.jLRField;
            }
            set {
                this.jLRField = value;
                this.RaisePropertyChanged("JLR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string JLRNAME {
            get {
                return this.jLRNAMEField;
            }
            set {
                this.jLRNAMEField = value;
                this.RaisePropertyChanged("JLRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int UNITSID {
            get {
                return this.uNITSIDField;
            }
            set {
                this.uNITSIDField = value;
                this.RaisePropertyChanged("UNITSID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string UNITSNAME {
            get {
                return this.uNITSNAMEField;
            }
            set {
                this.uNITSNAMEField = value;
                this.RaisePropertyChanged("UNITSNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int DCXH {
            get {
                return this.dCXHField;
            }
            set {
                this.dCXHField = value;
                this.RaisePropertyChanged("DCXH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string DCXHNAME {
            get {
                return this.dCXHNAMEField;
            }
            set {
                this.dCXHNAMEField = value;
                this.RaisePropertyChanged("DCXHNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public int DCDJ {
            get {
                return this.dCDJField;
            }
            set {
                this.dCDJField = value;
                this.RaisePropertyChanged("DCDJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string DCDJNAME {
            get {
                return this.dCDJNAMEField;
            }
            set {
                this.dCDJNAMEField = value;
                this.RaisePropertyChanged("DCDJNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public int WLLB {
            get {
                return this.wLLBField;
            }
            set {
                this.wLLBField = value;
                this.RaisePropertyChanged("WLLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string WLLBNAME {
            get {
                return this.wLLBNAMEField;
            }
            set {
                this.wLLBNAMEField = value;
                this.RaisePropertyChanged("WLLBNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int ISTRACE {
            get {
                return this.iSTRACEField;
            }
            set {
                this.iSTRACEField = value;
                this.RaisePropertyChanged("ISTRACE");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_MATERIAL_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_SY_MATERIAL_LIST[] mES_SY_MATERIALField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_SY_MATERIAL_LIST[] MES_SY_MATERIAL {
            get {
                return this.mES_SY_MATERIALField;
            }
            set {
                this.mES_SY_MATERIALField = value;
                this.RaisePropertyChanged("MES_SY_MATERIAL");
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
    public interface SY_MATERIALSoapChannel : Sonluk.UI.Model.MES.SY_MATERIALService.SY_MATERIALSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SY_MATERIALSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.SY_MATERIALService.SY_MATERIALSoap>, Sonluk.UI.Model.MES.SY_MATERIALService.SY_MATERIALSoap {
        
        public SY_MATERIALSoapClient() {
        }
        
        public SY_MATERIALSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SY_MATERIALSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_MATERIALSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_MATERIALSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIALService.MES_RETURN INSERT(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIALService.MES_RETURN DELETE(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken) {
            return base.Channel.DELETE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIALService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_SELECT SELECT(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_SELECT SELECT_BY_GZZX(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken) {
            return base.Channel.SELECT_BY_GZZX(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_DW_SELECT DW_SELECT(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_DW model, string ptoken) {
            return base.Channel.DW_SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL_SELECT SELECT_LB(Sonluk.UI.Model.MES.SY_MATERIALService.MES_SY_MATERIAL model, string ptoken) {
            return base.Channel.SELECT_LB(model, ptoken);
        }
    }
}
