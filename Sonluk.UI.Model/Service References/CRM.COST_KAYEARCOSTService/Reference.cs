﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_KAYEARCOSTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_KAYEARCOSTService.COST_KAYEARCOSTSoap")]
    public interface COST_KAYEARCOSTSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateSPJE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int UpdateSPJE(int KAYEARTTID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST[] ReadByParam(Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read_Unconnected", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST[] Read_Unconnected(Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int COSTID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_KAYEARCOST : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int cOSTIDField;
        
        private int kAYEARTTIDField;
        
        private int cOSTITEMIDField;
        
        private string hTTK_LASTField;
        
        private decimal jE_LASTField;
        
        private decimal fYL_LASTField;
        
        private decimal wSJE_LASTField;
        
        private int sL_LASTField;
        
        private string hTTK_THISField;
        
        private decimal jE_THISField;
        
        private decimal jEXG_THISField;
        
        private decimal fYL_THISField;
        
        private decimal wSJE_THISField;
        
        private decimal wSJEXG_THISField;
        
        private int sL_THISField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private int cJRField;
        
        private string cJSJField;
        
        private int xGRField;
        
        private string xGSJField;
        
        private string cOSTITEMIDDESField;
        
        private string cJRNAMEField;
        
        private string xGRNAMEField;
        
        private string tT_HTYEARField;
        
        private int tT_KHIDField;
        
        private decimal yHXJEField;
        
        private string sL_LASTDESField;
        
        private string sL_THISDESField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int COSTID {
            get {
                return this.cOSTIDField;
            }
            set {
                this.cOSTIDField = value;
                this.RaisePropertyChanged("COSTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int KAYEARTTID {
            get {
                return this.kAYEARTTIDField;
            }
            set {
                this.kAYEARTTIDField = value;
                this.RaisePropertyChanged("KAYEARTTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string HTTK_LAST {
            get {
                return this.hTTK_LASTField;
            }
            set {
                this.hTTK_LASTField = value;
                this.RaisePropertyChanged("HTTK_LAST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public decimal JE_LAST {
            get {
                return this.jE_LASTField;
            }
            set {
                this.jE_LASTField = value;
                this.RaisePropertyChanged("JE_LAST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public decimal FYL_LAST {
            get {
                return this.fYL_LASTField;
            }
            set {
                this.fYL_LASTField = value;
                this.RaisePropertyChanged("FYL_LAST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public decimal WSJE_LAST {
            get {
                return this.wSJE_LASTField;
            }
            set {
                this.wSJE_LASTField = value;
                this.RaisePropertyChanged("WSJE_LAST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int SL_LAST {
            get {
                return this.sL_LASTField;
            }
            set {
                this.sL_LASTField = value;
                this.RaisePropertyChanged("SL_LAST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string HTTK_THIS {
            get {
                return this.hTTK_THISField;
            }
            set {
                this.hTTK_THISField = value;
                this.RaisePropertyChanged("HTTK_THIS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public decimal JE_THIS {
            get {
                return this.jE_THISField;
            }
            set {
                this.jE_THISField = value;
                this.RaisePropertyChanged("JE_THIS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public decimal JEXG_THIS {
            get {
                return this.jEXG_THISField;
            }
            set {
                this.jEXG_THISField = value;
                this.RaisePropertyChanged("JEXG_THIS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public decimal FYL_THIS {
            get {
                return this.fYL_THISField;
            }
            set {
                this.fYL_THISField = value;
                this.RaisePropertyChanged("FYL_THIS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public decimal WSJE_THIS {
            get {
                return this.wSJE_THISField;
            }
            set {
                this.wSJE_THISField = value;
                this.RaisePropertyChanged("WSJE_THIS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public decimal WSJEXG_THIS {
            get {
                return this.wSJEXG_THISField;
            }
            set {
                this.wSJEXG_THISField = value;
                this.RaisePropertyChanged("WSJEXG_THIS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public int SL_THIS {
            get {
                return this.sL_THISField;
            }
            set {
                this.sL_THISField = value;
                this.RaisePropertyChanged("SL_THIS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public int TT_KHID {
            get {
                return this.tT_KHIDField;
            }
            set {
                this.tT_KHIDField = value;
                this.RaisePropertyChanged("TT_KHID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public decimal YHXJE {
            get {
                return this.yHXJEField;
            }
            set {
                this.yHXJEField = value;
                this.RaisePropertyChanged("YHXJE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public string SL_LASTDES {
            get {
                return this.sL_LASTDESField;
            }
            set {
                this.sL_LASTDESField = value;
                this.RaisePropertyChanged("SL_LASTDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        public string SL_THISDES {
            get {
                return this.sL_THISDESField;
            }
            set {
                this.sL_THISDESField = value;
                this.RaisePropertyChanged("SL_THISDES");
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
    public interface COST_KAYEARCOSTSoapChannel : Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.COST_KAYEARCOSTSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_KAYEARCOSTSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.COST_KAYEARCOSTSoap>, Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.COST_KAYEARCOSTSoap {
        
        public COST_KAYEARCOSTSoapClient() {
        }
        
        public COST_KAYEARCOSTSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_KAYEARCOSTSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_KAYEARCOSTSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_KAYEARCOSTSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public int UpdateSPJE(int KAYEARTTID, string ptoken) {
            return base.Channel.UpdateSPJE(KAYEARTTID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST[] ReadByParam(Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST[] Read_Unconnected(Sonluk.UI.Model.CRM.COST_KAYEARCOSTService.CRM_COST_KAYEARCOST model, string ptoken) {
            return base.Channel.Read_Unconnected(model, ptoken);
        }
        
        public int Delete(int COSTID, string ptoken) {
            return base.Channel.Delete(COSTID, ptoken);
        }
    }
}