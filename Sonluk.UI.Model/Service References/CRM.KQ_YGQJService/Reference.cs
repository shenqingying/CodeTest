﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.KQ_YGQJService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.KQ_YGQJService.KQ_YGQJSoap")]
    public interface KQ_YGQJSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int YGQJID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadBySTAFFID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] ReadBySTAFFID(int STAFFID, int STATUS, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Verify_QJ", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Verify_QJ(string beginTime, string endTime, int STAFFID, int YGQJID, int CCID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByYGQJID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ ReadByYGQJID(int YGQJID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByDepartRight", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] ReadByDepartRight(Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] Read(Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3130.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_KQ_YGQJ : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool iSDELETEField;
        
        private int yGQJIDField;
        
        private int sTAFFIDField;
        
        private string sTAFFNOField;
        
        private string sTAFFNAMEField;
        
        private string sTAFFSEXField;
        
        private int dEPNAMEField;
        
        private int qJLBField;
        
        private string qWHCField;
        
        private string jHQJKSSJField;
        
        private string jHQJJSSJField;
        
        private double qJTSField;
        
        private string zzField;
        
        private string bMLDField;
        
        private string zGLDField;
        
        private string zZBField;
        
        private string sJQJKSSJField;
        
        private string sJJSKSSJField;
        
        private double sJQJTSField;
        
        private string xJRQField;
        
        private string xJZZField;
        
        private string qJRField;
        
        private string qJRQField;
        
        private int iSACTIVEField;
        
        private string bzField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int YGQJID {
            get {
                return this.yGQJIDField;
            }
            set {
                this.yGQJIDField = value;
                this.RaisePropertyChanged("YGQJID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string STAFFNO {
            get {
                return this.sTAFFNOField;
            }
            set {
                this.sTAFFNOField = value;
                this.RaisePropertyChanged("STAFFNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string STAFFSEX {
            get {
                return this.sTAFFSEXField;
            }
            set {
                this.sTAFFSEXField = value;
                this.RaisePropertyChanged("STAFFSEX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int DEPNAME {
            get {
                return this.dEPNAMEField;
            }
            set {
                this.dEPNAMEField = value;
                this.RaisePropertyChanged("DEPNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int QJLB {
            get {
                return this.qJLBField;
            }
            set {
                this.qJLBField = value;
                this.RaisePropertyChanged("QJLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string QWHC {
            get {
                return this.qWHCField;
            }
            set {
                this.qWHCField = value;
                this.RaisePropertyChanged("QWHC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string JHQJKSSJ {
            get {
                return this.jHQJKSSJField;
            }
            set {
                this.jHQJKSSJField = value;
                this.RaisePropertyChanged("JHQJKSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string JHQJJSSJ {
            get {
                return this.jHQJJSSJField;
            }
            set {
                this.jHQJJSSJField = value;
                this.RaisePropertyChanged("JHQJJSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public double QJTS {
            get {
                return this.qJTSField;
            }
            set {
                this.qJTSField = value;
                this.RaisePropertyChanged("QJTS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string ZZ {
            get {
                return this.zzField;
            }
            set {
                this.zzField = value;
                this.RaisePropertyChanged("ZZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string BMLD {
            get {
                return this.bMLDField;
            }
            set {
                this.bMLDField = value;
                this.RaisePropertyChanged("BMLD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string ZGLD {
            get {
                return this.zGLDField;
            }
            set {
                this.zGLDField = value;
                this.RaisePropertyChanged("ZGLD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string ZZB {
            get {
                return this.zZBField;
            }
            set {
                this.zZBField = value;
                this.RaisePropertyChanged("ZZB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string SJQJKSSJ {
            get {
                return this.sJQJKSSJField;
            }
            set {
                this.sJQJKSSJField = value;
                this.RaisePropertyChanged("SJQJKSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string SJJSKSSJ {
            get {
                return this.sJJSKSSJField;
            }
            set {
                this.sJJSKSSJField = value;
                this.RaisePropertyChanged("SJJSKSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public double SJQJTS {
            get {
                return this.sJQJTSField;
            }
            set {
                this.sJQJTSField = value;
                this.RaisePropertyChanged("SJQJTS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string XJRQ {
            get {
                return this.xJRQField;
            }
            set {
                this.xJRQField = value;
                this.RaisePropertyChanged("XJRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string XJZZ {
            get {
                return this.xJZZField;
            }
            set {
                this.xJZZField = value;
                this.RaisePropertyChanged("XJZZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string QJR {
            get {
                return this.qJRField;
            }
            set {
                this.qJRField = value;
                this.RaisePropertyChanged("QJR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string QJRQ {
            get {
                return this.qJRQField;
            }
            set {
                this.qJRQField = value;
                this.RaisePropertyChanged("QJRQ");
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
        public string BZ {
            get {
                return this.bzField;
            }
            set {
                this.bzField = value;
                this.RaisePropertyChanged("BZ");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3130.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_KQ_YGQJList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string dEPNAMEDESField;
        
        private string qJLBDESField;
        
        private bool iSDELETEField;
        
        private int yGQJIDField;
        
        private int sTAFFIDField;
        
        private string sTAFFNOField;
        
        private string sTAFFNAMEField;
        
        private string sTAFFSEXField;
        
        private int dEPNAMEField;
        
        private int qJLBField;
        
        private string qWHCField;
        
        private string jHQJKSSJField;
        
        private string jHQJJSSJField;
        
        private double qJTSField;
        
        private string zzField;
        
        private string bMLDField;
        
        private string zGLDField;
        
        private string zZBField;
        
        private string sJQJKSSJField;
        
        private string sJJSKSSJField;
        
        private double sJQJTSField;
        
        private string xJRQField;
        
        private string xJZZField;
        
        private string qJRField;
        
        private string qJRQField;
        
        private int iSACTIVEField;
        
        private string bzField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string DEPNAMEDES {
            get {
                return this.dEPNAMEDESField;
            }
            set {
                this.dEPNAMEDESField = value;
                this.RaisePropertyChanged("DEPNAMEDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string QJLBDES {
            get {
                return this.qJLBDESField;
            }
            set {
                this.qJLBDESField = value;
                this.RaisePropertyChanged("QJLBDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int YGQJID {
            get {
                return this.yGQJIDField;
            }
            set {
                this.yGQJIDField = value;
                this.RaisePropertyChanged("YGQJID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string STAFFNO {
            get {
                return this.sTAFFNOField;
            }
            set {
                this.sTAFFNOField = value;
                this.RaisePropertyChanged("STAFFNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string STAFFSEX {
            get {
                return this.sTAFFSEXField;
            }
            set {
                this.sTAFFSEXField = value;
                this.RaisePropertyChanged("STAFFSEX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int DEPNAME {
            get {
                return this.dEPNAMEField;
            }
            set {
                this.dEPNAMEField = value;
                this.RaisePropertyChanged("DEPNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int QJLB {
            get {
                return this.qJLBField;
            }
            set {
                this.qJLBField = value;
                this.RaisePropertyChanged("QJLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string QWHC {
            get {
                return this.qWHCField;
            }
            set {
                this.qWHCField = value;
                this.RaisePropertyChanged("QWHC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string JHQJKSSJ {
            get {
                return this.jHQJKSSJField;
            }
            set {
                this.jHQJKSSJField = value;
                this.RaisePropertyChanged("JHQJKSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string JHQJJSSJ {
            get {
                return this.jHQJJSSJField;
            }
            set {
                this.jHQJJSSJField = value;
                this.RaisePropertyChanged("JHQJJSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public double QJTS {
            get {
                return this.qJTSField;
            }
            set {
                this.qJTSField = value;
                this.RaisePropertyChanged("QJTS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string ZZ {
            get {
                return this.zzField;
            }
            set {
                this.zzField = value;
                this.RaisePropertyChanged("ZZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string BMLD {
            get {
                return this.bMLDField;
            }
            set {
                this.bMLDField = value;
                this.RaisePropertyChanged("BMLD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string ZGLD {
            get {
                return this.zGLDField;
            }
            set {
                this.zGLDField = value;
                this.RaisePropertyChanged("ZGLD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string ZZB {
            get {
                return this.zZBField;
            }
            set {
                this.zZBField = value;
                this.RaisePropertyChanged("ZZB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string SJQJKSSJ {
            get {
                return this.sJQJKSSJField;
            }
            set {
                this.sJQJKSSJField = value;
                this.RaisePropertyChanged("SJQJKSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string SJJSKSSJ {
            get {
                return this.sJJSKSSJField;
            }
            set {
                this.sJJSKSSJField = value;
                this.RaisePropertyChanged("SJJSKSSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public double SJQJTS {
            get {
                return this.sJQJTSField;
            }
            set {
                this.sJQJTSField = value;
                this.RaisePropertyChanged("SJQJTS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string XJRQ {
            get {
                return this.xJRQField;
            }
            set {
                this.xJRQField = value;
                this.RaisePropertyChanged("XJRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string XJZZ {
            get {
                return this.xJZZField;
            }
            set {
                this.xJZZField = value;
                this.RaisePropertyChanged("XJZZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string QJR {
            get {
                return this.qJRField;
            }
            set {
                this.qJRField = value;
                this.RaisePropertyChanged("QJR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string QJRQ {
            get {
                return this.qJRQField;
            }
            set {
                this.qJRQField = value;
                this.RaisePropertyChanged("QJRQ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string BZ {
            get {
                return this.bzField;
            }
            set {
                this.bzField = value;
                this.RaisePropertyChanged("BZ");
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
    public interface KQ_YGQJSoapChannel : Sonluk.UI.Model.CRM.KQ_YGQJService.KQ_YGQJSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KQ_YGQJSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.KQ_YGQJService.KQ_YGQJSoap>, Sonluk.UI.Model.CRM.KQ_YGQJService.KQ_YGQJSoap {
        
        public KQ_YGQJSoapClient() {
        }
        
        public KQ_YGQJSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KQ_YGQJSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KQ_YGQJSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KQ_YGQJSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public int Delete(int YGQJID, string ptoken) {
            return base.Channel.Delete(YGQJID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] ReadBySTAFFID(int STAFFID, int STATUS, string ptoken) {
            return base.Channel.ReadBySTAFFID(STAFFID, STATUS, ptoken);
        }
        
        public int Verify_QJ(string beginTime, string endTime, int STAFFID, int YGQJID, int CCID, string ptoken) {
            return base.Channel.Verify_QJ(beginTime, endTime, STAFFID, YGQJID, CCID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ ReadByYGQJID(int YGQJID, string ptoken) {
            return base.Channel.ReadByYGQJID(YGQJID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] ReadByDepartRight(Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ model, string ptoken) {
            return base.Channel.ReadByDepartRight(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] Read(Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJ model, string ptoken) {
            return base.Channel.Read(model, ptoken);
        }
    }
}
