﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_LKAFYMXDTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_LKAFYMXDTService.COST_LKAFYMXDTSoap")]
    public interface COST_LKAFYMXDTSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT[] ReadByParam(Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int LKADTMXID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read_Unconnected", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT[] Read_Unconnected(Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_LKAFYMXDT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int lKADTMXIDField;
        
        private int lKAFYTTIDField;
        
        private int cXLXField;
        
        private int cOSTITEMIDField;
        
        private double cXFYField;
        
        private string bEIZField;
        
        private int xGRField;
        
        private string xGSJField;
        
        private int iSACTIVEField;
        
        private int hXRField;
        
        private string hXSJField;
        
        private string cXLXDESField;
        
        private string xGRNAMEField;
        
        private string hXRNAMEField;
        
        private string tT_HTYEARField;
        
        private int tT_LKAIDField;
        
        private int tT_COSTITEMIDField;
        
        private string cOSTITEMIDDESField;
        
        private int tT_FYLBField;
        
        private int cJHDMDSLField;
        
        private string hDBEGINDATEField;
        
        private string hDENDDATEField;
        
        private string kHTHBEGINDATEField;
        
        private string kHTHENDDATEField;
        
        private string dP1Field;
        
        private string dP2Field;
        
        private double cCJField;
        
        private double zCGJField;
        
        private double cXGJField;
        
        private double zCSJField;
        
        private double cXSJField;
        
        private double dPYJXSField;
        
        private double yJHDQJXSField;
        
        private double yJFBField;
        
        private string hDFASMField;
        
        private double sQZJEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int LKADTMXID {
            get {
                return this.lKADTMXIDField;
            }
            set {
                this.lKADTMXIDField = value;
                this.RaisePropertyChanged("LKADTMXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int LKAFYTTID {
            get {
                return this.lKAFYTTIDField;
            }
            set {
                this.lKAFYTTIDField = value;
                this.RaisePropertyChanged("LKAFYTTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int CXLX {
            get {
                return this.cXLXField;
            }
            set {
                this.cXLXField = value;
                this.RaisePropertyChanged("CXLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public double CXFY {
            get {
                return this.cXFYField;
            }
            set {
                this.cXFYField = value;
                this.RaisePropertyChanged("CXFY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int HXR {
            get {
                return this.hXRField;
            }
            set {
                this.hXRField = value;
                this.RaisePropertyChanged("HXR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string HXSJ {
            get {
                return this.hXSJField;
            }
            set {
                this.hXSJField = value;
                this.RaisePropertyChanged("HXSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string CXLXDES {
            get {
                return this.cXLXDESField;
            }
            set {
                this.cXLXDESField = value;
                this.RaisePropertyChanged("CXLXDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string HXRNAME {
            get {
                return this.hXRNAMEField;
            }
            set {
                this.hXRNAMEField = value;
                this.RaisePropertyChanged("HXRNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string TT_HTYEAR {
            get {
                return this.tT_HTYEARField;
            }
            set {
                this.tT_HTYEARField = value;
                this.RaisePropertyChanged("TT_HTYEAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public int TT_LKAID {
            get {
                return this.tT_LKAIDField;
            }
            set {
                this.tT_LKAIDField = value;
                this.RaisePropertyChanged("TT_LKAID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public int TT_COSTITEMID {
            get {
                return this.tT_COSTITEMIDField;
            }
            set {
                this.tT_COSTITEMIDField = value;
                this.RaisePropertyChanged("TT_COSTITEMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public int TT_FYLB {
            get {
                return this.tT_FYLBField;
            }
            set {
                this.tT_FYLBField = value;
                this.RaisePropertyChanged("TT_FYLB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public int CJHDMDSL {
            get {
                return this.cJHDMDSLField;
            }
            set {
                this.cJHDMDSLField = value;
                this.RaisePropertyChanged("CJHDMDSL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string HDBEGINDATE {
            get {
                return this.hDBEGINDATEField;
            }
            set {
                this.hDBEGINDATEField = value;
                this.RaisePropertyChanged("HDBEGINDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string HDENDDATE {
            get {
                return this.hDENDDATEField;
            }
            set {
                this.hDENDDATEField = value;
                this.RaisePropertyChanged("HDENDDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string KHTHBEGINDATE {
            get {
                return this.kHTHBEGINDATEField;
            }
            set {
                this.kHTHBEGINDATEField = value;
                this.RaisePropertyChanged("KHTHBEGINDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string KHTHENDDATE {
            get {
                return this.kHTHENDDATEField;
            }
            set {
                this.kHTHENDDATEField = value;
                this.RaisePropertyChanged("KHTHENDDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string DP1 {
            get {
                return this.dP1Field;
            }
            set {
                this.dP1Field = value;
                this.RaisePropertyChanged("DP1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string DP2 {
            get {
                return this.dP2Field;
            }
            set {
                this.dP2Field = value;
                this.RaisePropertyChanged("DP2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public double CCJ {
            get {
                return this.cCJField;
            }
            set {
                this.cCJField = value;
                this.RaisePropertyChanged("CCJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public double ZCGJ {
            get {
                return this.zCGJField;
            }
            set {
                this.zCGJField = value;
                this.RaisePropertyChanged("ZCGJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        public double CXGJ {
            get {
                return this.cXGJField;
            }
            set {
                this.cXGJField = value;
                this.RaisePropertyChanged("CXGJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
        public double ZCSJ {
            get {
                return this.zCSJField;
            }
            set {
                this.zCSJField = value;
                this.RaisePropertyChanged("ZCSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=30)]
        public double CXSJ {
            get {
                return this.cXSJField;
            }
            set {
                this.cXSJField = value;
                this.RaisePropertyChanged("CXSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=31)]
        public double DPYJXS {
            get {
                return this.dPYJXSField;
            }
            set {
                this.dPYJXSField = value;
                this.RaisePropertyChanged("DPYJXS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=32)]
        public double YJHDQJXS {
            get {
                return this.yJHDQJXSField;
            }
            set {
                this.yJHDQJXSField = value;
                this.RaisePropertyChanged("YJHDQJXS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=33)]
        public double YJFB {
            get {
                return this.yJFBField;
            }
            set {
                this.yJFBField = value;
                this.RaisePropertyChanged("YJFB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=34)]
        public string HDFASM {
            get {
                return this.hDFASMField;
            }
            set {
                this.hDFASMField = value;
                this.RaisePropertyChanged("HDFASM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=35)]
        public double SQZJE {
            get {
                return this.sQZJEField;
            }
            set {
                this.sQZJEField = value;
                this.RaisePropertyChanged("SQZJE");
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
    public interface COST_LKAFYMXDTSoapChannel : Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.COST_LKAFYMXDTSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_LKAFYMXDTSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.COST_LKAFYMXDTSoap>, Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.COST_LKAFYMXDTSoap {
        
        public COST_LKAFYMXDTSoapClient() {
        }
        
        public COST_LKAFYMXDTSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_LKAFYMXDTSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_LKAFYMXDTSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_LKAFYMXDTSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT[] ReadByParam(Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int LKADTMXID, string ptoken) {
            return base.Channel.Delete(LKADTMXID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT[] Read_Unconnected(Sonluk.UI.Model.CRM.COST_LKAFYMXDTService.CRM_COST_LKAFYMXDT model, string ptoken) {
            return base.Channel.Read_Unconnected(model, ptoken);
        }
    }
}
