﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_LKAYEARLISTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_LKAYEARLISTService.COST_LKAYEARLISTSoap")]
    public interface COST_LKAYEARLISTSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST[] ReadByParam(Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int LISTID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateByTTID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int UpdateByTTID(int LKAYEARTTID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteByTTID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteByTTID(int LKAYEARTTID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadListByKHID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST[] ReadListByKHID(int KHID, string YEAR, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_LKAYEARLIST : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int lISTIDField;
        
        private int lKAYEARTTIDField;
        
        private int kHIDField;
        
        private double lAST2YEAR_HTField;
        
        private double lAST2YEAR_GSField;
        
        private double lASTYEAR_HTField;
        
        private double lASTYEAR_GSField;
        
        private double tHISYEAR_HTField;
        
        private double tHISYEAR_GSField;
        
        private double cCJ_HTField;
        
        private double cCJ_GSField;
        
        private string bEIZField;
        
        private string kHMCField;
        
        private string cRMIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int LISTID {
            get {
                return this.lISTIDField;
            }
            set {
                this.lISTIDField = value;
                this.RaisePropertyChanged("LISTID");
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public double LAST2YEAR_HT {
            get {
                return this.lAST2YEAR_HTField;
            }
            set {
                this.lAST2YEAR_HTField = value;
                this.RaisePropertyChanged("LAST2YEAR_HT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public double LAST2YEAR_GS {
            get {
                return this.lAST2YEAR_GSField;
            }
            set {
                this.lAST2YEAR_GSField = value;
                this.RaisePropertyChanged("LAST2YEAR_GS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public double LASTYEAR_HT {
            get {
                return this.lASTYEAR_HTField;
            }
            set {
                this.lASTYEAR_HTField = value;
                this.RaisePropertyChanged("LASTYEAR_HT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public double LASTYEAR_GS {
            get {
                return this.lASTYEAR_GSField;
            }
            set {
                this.lASTYEAR_GSField = value;
                this.RaisePropertyChanged("LASTYEAR_GS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public double THISYEAR_HT {
            get {
                return this.tHISYEAR_HTField;
            }
            set {
                this.tHISYEAR_HTField = value;
                this.RaisePropertyChanged("THISYEAR_HT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public double THISYEAR_GS {
            get {
                return this.tHISYEAR_GSField;
            }
            set {
                this.tHISYEAR_GSField = value;
                this.RaisePropertyChanged("THISYEAR_GS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public double CCJ_HT {
            get {
                return this.cCJ_HTField;
            }
            set {
                this.cCJ_HTField = value;
                this.RaisePropertyChanged("CCJ_HT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public double CCJ_GS {
            get {
                return this.cCJ_GSField;
            }
            set {
                this.cCJ_GSField = value;
                this.RaisePropertyChanged("CCJ_GS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string KHMC {
            get {
                return this.kHMCField;
            }
            set {
                this.kHMCField = value;
                this.RaisePropertyChanged("KHMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string CRMID {
            get {
                return this.cRMIDField;
            }
            set {
                this.cRMIDField = value;
                this.RaisePropertyChanged("CRMID");
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
    public interface COST_LKAYEARLISTSoapChannel : Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.COST_LKAYEARLISTSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_LKAYEARLISTSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.COST_LKAYEARLISTSoap>, Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.COST_LKAYEARLISTSoap {
        
        public COST_LKAYEARLISTSoapClient() {
        }
        
        public COST_LKAYEARLISTSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_LKAYEARLISTSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_LKAYEARLISTSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_LKAYEARLISTSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST[] ReadByParam(Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int LISTID, string ptoken) {
            return base.Channel.Delete(LISTID, ptoken);
        }
        
        public int UpdateByTTID(int LKAYEARTTID, string ptoken) {
            return base.Channel.UpdateByTTID(LKAYEARTTID, ptoken);
        }
        
        public int DeleteByTTID(int LKAYEARTTID, string ptoken) {
            return base.Channel.DeleteByTTID(LKAYEARTTID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_LKAYEARLISTService.CRM_COST_LKAYEARLIST[] ReadListByKHID(int KHID, string YEAR, string ptoken) {
            return base.Channel.ReadListByKHID(KHID, YEAR, ptoken);
        }
    }
}