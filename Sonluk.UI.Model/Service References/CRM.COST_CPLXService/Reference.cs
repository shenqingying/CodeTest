﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.COST_CPLXService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.COST_CPLXService.COST_CPLXSoap")]
    public interface COST_CPLXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.COST_CPLXService.CRM_COST_CPLX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.COST_CPLXService.CRM_COST_CPLX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.COST_CPLXService.CRM_COST_CPLX[] ReadByParam(Sonluk.UI.Model.CRM.COST_CPLXService.CRM_COST_CPLX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int CPLXID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_COST_CPLX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int cPLXIDField;
        
        private string cPLXField;
        
        private string cPFLField;
        
        private int fYZCFSField;
        
        private decimal fYZCField;
        
        private string bEIZField;
        
        private int iSACTIVEField;
        
        private int cZRField;
        
        private string cZSJField;
        
        private string fYZCFSDESField;
        
        private string cZRNAMEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int CPLXID {
            get {
                return this.cPLXIDField;
            }
            set {
                this.cPLXIDField = value;
                this.RaisePropertyChanged("CPLXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CPLX {
            get {
                return this.cPLXField;
            }
            set {
                this.cPLXField = value;
                this.RaisePropertyChanged("CPLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int FYZCFS {
            get {
                return this.fYZCFSField;
            }
            set {
                this.fYZCFSField = value;
                this.RaisePropertyChanged("FYZCFS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public decimal FYZC {
            get {
                return this.fYZCField;
            }
            set {
                this.fYZCField = value;
                this.RaisePropertyChanged("FYZC");
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int CZR {
            get {
                return this.cZRField;
            }
            set {
                this.cZRField = value;
                this.RaisePropertyChanged("CZR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string CZSJ {
            get {
                return this.cZSJField;
            }
            set {
                this.cZSJField = value;
                this.RaisePropertyChanged("CZSJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string FYZCFSDES {
            get {
                return this.fYZCFSDESField;
            }
            set {
                this.fYZCFSDESField = value;
                this.RaisePropertyChanged("FYZCFSDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string CZRNAME {
            get {
                return this.cZRNAMEField;
            }
            set {
                this.cZRNAMEField = value;
                this.RaisePropertyChanged("CZRNAME");
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
    public interface COST_CPLXSoapChannel : Sonluk.UI.Model.CRM.COST_CPLXService.COST_CPLXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class COST_CPLXSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.COST_CPLXService.COST_CPLXSoap>, Sonluk.UI.Model.CRM.COST_CPLXService.COST_CPLXSoap {
        
        public COST_CPLXSoapClient() {
        }
        
        public COST_CPLXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public COST_CPLXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CPLXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public COST_CPLXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.COST_CPLXService.CRM_COST_CPLX model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.COST_CPLXService.CRM_COST_CPLX model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.COST_CPLXService.CRM_COST_CPLX[] ReadByParam(Sonluk.UI.Model.CRM.COST_CPLXService.CRM_COST_CPLX model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int CPLXID, string ptoken) {
            return base.Channel.Delete(CPLXID, ptoken);
        }
    }
}