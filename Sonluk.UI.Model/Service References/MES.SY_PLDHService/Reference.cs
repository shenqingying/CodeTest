﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.SY_PLDHService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.SY_PLDHService.SY_PLDHSoap")]
    public interface SY_PLDHSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_LIST", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SELECT SELECT_LIST(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SELECT SELECT(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PLDH_SBBH_INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN PLDH_SBBH_INSERT(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SBBH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PLDH_SBBH_UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN PLDH_SBBH_UPDATE(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SBBH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PLDH_SBBH_SELECT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SBBH_SELECT PLDH_SBBH_SELECT(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SBBH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_PLDH_PH", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN INSERT_PLDH_PH(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_PLDH_PH", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH_SELECT SELECT_PLDH_PH(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_PLDH_PH_LB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH_SELECT SELECT_PLDH_PH_LB(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN INSERT(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_PLDH : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gcField;
        
        private string pFDHField;
        
        private int pFLBField;
        
        private string pLDHField;
        
        private int jLRIDField;
        
        private string jLRField;
        
        private string jLTIMEField;
        
        private int iSACTIONField;
        
        private string rEMARKField;
        
        private string uSERDATESField;
        
        private string uSERDATEEField;
        
        private int cXLBField;
        
        private int sTAFFIDField;
        
        private int lbField;
        
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
        public string PFDH {
            get {
                return this.pFDHField;
            }
            set {
                this.pFDHField = value;
                this.RaisePropertyChanged("PFDH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PFLB {
            get {
                return this.pFLBField;
            }
            set {
                this.pFLBField = value;
                this.RaisePropertyChanged("PFLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string PLDH {
            get {
                return this.pLDHField;
            }
            set {
                this.pLDHField = value;
                this.RaisePropertyChanged("PLDH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int JLRID {
            get {
                return this.jLRIDField;
            }
            set {
                this.jLRIDField = value;
                this.RaisePropertyChanged("JLRID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string JLR {
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
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
        public string USERDATES {
            get {
                return this.uSERDATESField;
            }
            set {
                this.uSERDATESField = value;
                this.RaisePropertyChanged("USERDATES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string USERDATEE {
            get {
                return this.uSERDATEEField;
            }
            set {
                this.uSERDATEEField = value;
                this.RaisePropertyChanged("USERDATEE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int CXLB {
            get {
                return this.cXLBField;
            }
            set {
                this.cXLBField = value;
                this.RaisePropertyChanged("CXLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public int LB {
            get {
                return this.lbField;
            }
            set {
                this.lbField = value;
                this.RaisePropertyChanged("LB");
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
    public partial class MES_SY_PLDH_PH_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_SY_PLDH_PH[] mES_SY_PLDH_PHField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_SY_PLDH_PH[] MES_SY_PLDH_PH {
            get {
                return this.mES_SY_PLDH_PHField;
            }
            set {
                this.mES_SY_PLDH_PHField = value;
                this.RaisePropertyChanged("MES_SY_PLDH_PH");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_PLDH_PH : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gcField;
        
        private string pLDHField;
        
        private string wLHField;
        
        private string wLMSField;
        
        private string phField;
        
        private string pFDHField;
        
        private int pFLBField;
        
        private string jYPField;
        
        private int lbField;
        
        private string pFLBNAMEField;
        
        private int sTAFFIDField;
        
        private string uSERDATESField;
        
        private string uSERDATEEField;
        
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
        public string PLDH {
            get {
                return this.pLDHField;
            }
            set {
                this.pLDHField = value;
                this.RaisePropertyChanged("PLDH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string PH {
            get {
                return this.phField;
            }
            set {
                this.phField = value;
                this.RaisePropertyChanged("PH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string PFDH {
            get {
                return this.pFDHField;
            }
            set {
                this.pFDHField = value;
                this.RaisePropertyChanged("PFDH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int PFLB {
            get {
                return this.pFLBField;
            }
            set {
                this.pFLBField = value;
                this.RaisePropertyChanged("PFLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string JYP {
            get {
                return this.jYPField;
            }
            set {
                this.jYPField = value;
                this.RaisePropertyChanged("JYP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string PFLBNAME {
            get {
                return this.pFLBNAMEField;
            }
            set {
                this.pFLBNAMEField = value;
                this.RaisePropertyChanged("PFLBNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string USERDATES {
            get {
                return this.uSERDATESField;
            }
            set {
                this.uSERDATESField = value;
                this.RaisePropertyChanged("USERDATES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string USERDATEE {
            get {
                return this.uSERDATEEField;
            }
            set {
                this.uSERDATEEField = value;
                this.RaisePropertyChanged("USERDATEE");
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
    public partial class MES_SY_PLDH_SBBH_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_SY_PLDH_SBBH[] mES_SY_PLDH_SBBHField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_SY_PLDH_SBBH[] MES_SY_PLDH_SBBH {
            get {
                return this.mES_SY_PLDH_SBBHField;
            }
            set {
                this.mES_SY_PLDH_SBBHField = value;
                this.RaisePropertyChanged("MES_SY_PLDH_SBBH");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_SY_PLDH_SBBH : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int nOIDField;
        
        private string gcField;
        
        private string pLDHField;
        
        private string sBBHField;
        
        private int cJRField;
        
        private int xGRField;
        
        private int lbField;
        
        private string sBMSField;
        
        private string cJRNAMEField;
        
        private string cJTIMEField;
        
        private string xGRNAMEField;
        
        private string xGTIMEField;
        
        private string gZZXBHField;
        
        private string rEMARKField;
        
        private int pFLBField;
        
        private string pFDHField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int NOID {
            get {
                return this.nOIDField;
            }
            set {
                this.nOIDField = value;
                this.RaisePropertyChanged("NOID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string PLDH {
            get {
                return this.pLDHField;
            }
            set {
                this.pLDHField = value;
                this.RaisePropertyChanged("PLDH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SBBH {
            get {
                return this.sBBHField;
            }
            set {
                this.sBBHField = value;
                this.RaisePropertyChanged("SBBH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string SBMS {
            get {
                return this.sBMSField;
            }
            set {
                this.sBMSField = value;
                this.RaisePropertyChanged("SBMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string CJTIME {
            get {
                return this.cJTIMEField;
            }
            set {
                this.cJTIMEField = value;
                this.RaisePropertyChanged("CJTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string XGTIME {
            get {
                return this.xGTIMEField;
            }
            set {
                this.xGTIMEField = value;
                this.RaisePropertyChanged("XGTIME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public int PFLB {
            get {
                return this.pFLBField;
            }
            set {
                this.pFLBField = value;
                this.RaisePropertyChanged("PFLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string PFDH {
            get {
                return this.pFDHField;
            }
            set {
                this.pFDHField = value;
                this.RaisePropertyChanged("PFDH");
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
    public partial class MES_SY_PLDH_SELECT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MES_SY_PLDH[] mES_SY_PLDHField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public MES_SY_PLDH[] MES_SY_PLDH {
            get {
                return this.mES_SY_PLDHField;
            }
            set {
                this.mES_SY_PLDHField = value;
                this.RaisePropertyChanged("MES_SY_PLDH");
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
    public interface SY_PLDHSoapChannel : Sonluk.UI.Model.MES.SY_PLDHService.SY_PLDHSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SY_PLDHSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.SY_PLDHService.SY_PLDHSoap>, Sonluk.UI.Model.MES.SY_PLDHService.SY_PLDHSoap {
        
        public SY_PLDHSoapClient() {
        }
        
        public SY_PLDHSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SY_PLDHSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_PLDHSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SY_PLDHSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SELECT SELECT_LIST(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH model, string ptoken) {
            return base.Channel.SELECT_LIST(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SELECT SELECT(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH model, string ptoken) {
            return base.Channel.SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN PLDH_SBBH_INSERT(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SBBH model, string ptoken) {
            return base.Channel.PLDH_SBBH_INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN PLDH_SBBH_UPDATE(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SBBH model, string ptoken) {
            return base.Channel.PLDH_SBBH_UPDATE(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SBBH_SELECT PLDH_SBBH_SELECT(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_SBBH model, string ptoken) {
            return base.Channel.PLDH_SBBH_SELECT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN INSERT_PLDH_PH(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH model, string ptoken) {
            return base.Channel.INSERT_PLDH_PH(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH_SELECT SELECT_PLDH_PH(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH model, string ptoken) {
            return base.Channel.SELECT_PLDH_PH(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH_SELECT SELECT_PLDH_PH_LB(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH_PH model, string ptoken) {
            return base.Channel.SELECT_PLDH_PH_LB(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN INSERT(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH model, string ptoken) {
            return base.Channel.INSERT(model, ptoken);
        }
        
        public Sonluk.UI.Model.MES.SY_PLDHService.MES_RETURN UPDATE(Sonluk.UI.Model.MES.SY_PLDHService.MES_SY_PLDH model, string ptoken) {
            return base.Channel.UPDATE(model, ptoken);
        }
    }
}
