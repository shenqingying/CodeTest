﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.KH_GROUPService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.KH_GROUPService.KH_GROUPSoap")]
    public interface KH_GROUPSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList[] Read(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList[] ReadByParam(Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delect", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delect(int GID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadbyGId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList ReadbyGId(int GID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadBySTAFFID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList[] ReadBySTAFFID(int STAFFID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadGidByGNAME", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ReadGidByGNAME(string gname, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_KH_GROUP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int gIDField;
        
        private int xSQYIDField;
        
        private int pGIDField;
        
        private string gNAMEField;
        
        private int kHJLIDField;
        
        private string gMEMOField;
        
        private int fGLDIDField;
        
        private int cPLXField;
        
        private int sORTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int GID {
            get {
                return this.gIDField;
            }
            set {
                this.gIDField = value;
                this.RaisePropertyChanged("GID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int XSQYID {
            get {
                return this.xSQYIDField;
            }
            set {
                this.xSQYIDField = value;
                this.RaisePropertyChanged("XSQYID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PGID {
            get {
                return this.pGIDField;
            }
            set {
                this.pGIDField = value;
                this.RaisePropertyChanged("PGID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string GNAME {
            get {
                return this.gNAMEField;
            }
            set {
                this.gNAMEField = value;
                this.RaisePropertyChanged("GNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int KHJLID {
            get {
                return this.kHJLIDField;
            }
            set {
                this.kHJLIDField = value;
                this.RaisePropertyChanged("KHJLID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string GMEMO {
            get {
                return this.gMEMOField;
            }
            set {
                this.gMEMOField = value;
                this.RaisePropertyChanged("GMEMO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int FGLDID {
            get {
                return this.fGLDIDField;
            }
            set {
                this.fGLDIDField = value;
                this.RaisePropertyChanged("FGLDID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int CPLX {
            get {
                return this.cPLXField;
            }
            set {
                this.cPLXField = value;
                this.RaisePropertyChanged("CPLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int SORT {
            get {
                return this.sORTField;
            }
            set {
                this.sORTField = value;
                this.RaisePropertyChanged("SORT");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_KH_GROUPList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int gIDField;
        
        private int xSQYIDField;
        
        private int pGIDField;
        
        private string gNAMEField;
        
        private int kHJLIDField;
        
        private string gMEMOField;
        
        private int fGLDIDField;
        
        private int cPLXField;
        
        private int sORTField;
        
        private string pGNAMEField;
        
        private string nAME1Field;
        
        private string cPLXDESField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int GID {
            get {
                return this.gIDField;
            }
            set {
                this.gIDField = value;
                this.RaisePropertyChanged("GID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int XSQYID {
            get {
                return this.xSQYIDField;
            }
            set {
                this.xSQYIDField = value;
                this.RaisePropertyChanged("XSQYID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PGID {
            get {
                return this.pGIDField;
            }
            set {
                this.pGIDField = value;
                this.RaisePropertyChanged("PGID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string GNAME {
            get {
                return this.gNAMEField;
            }
            set {
                this.gNAMEField = value;
                this.RaisePropertyChanged("GNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int KHJLID {
            get {
                return this.kHJLIDField;
            }
            set {
                this.kHJLIDField = value;
                this.RaisePropertyChanged("KHJLID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string GMEMO {
            get {
                return this.gMEMOField;
            }
            set {
                this.gMEMOField = value;
                this.RaisePropertyChanged("GMEMO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int FGLDID {
            get {
                return this.fGLDIDField;
            }
            set {
                this.fGLDIDField = value;
                this.RaisePropertyChanged("FGLDID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int CPLX {
            get {
                return this.cPLXField;
            }
            set {
                this.cPLXField = value;
                this.RaisePropertyChanged("CPLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int SORT {
            get {
                return this.sORTField;
            }
            set {
                this.sORTField = value;
                this.RaisePropertyChanged("SORT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string PGNAME {
            get {
                return this.pGNAMEField;
            }
            set {
                this.pGNAMEField = value;
                this.RaisePropertyChanged("PGNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string NAME1 {
            get {
                return this.nAME1Field;
            }
            set {
                this.nAME1Field = value;
                this.RaisePropertyChanged("NAME1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string CPLXDES {
            get {
                return this.cPLXDESField;
            }
            set {
                this.cPLXDESField = value;
                this.RaisePropertyChanged("CPLXDES");
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
    public interface KH_GROUPSoapChannel : Sonluk.UI.Model.CRM.KH_GROUPService.KH_GROUPSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KH_GROUPSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.KH_GROUPService.KH_GROUPSoap>, Sonluk.UI.Model.CRM.KH_GROUPService.KH_GROUPSoap {
        
        public KH_GROUPSoapClient() {
        }
        
        public KH_GROUPSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KH_GROUPSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KH_GROUPSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KH_GROUPSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUP model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUP model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList[] Read(string ptoken) {
            return base.Channel.Read(ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList[] ReadByParam(Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delect(int GID, string ptoken) {
            return base.Channel.Delect(GID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList ReadbyGId(int GID, string ptoken) {
            return base.Channel.ReadbyGId(GID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KH_GROUPService.CRM_KH_GROUPList[] ReadBySTAFFID(int STAFFID, string ptoken) {
            return base.Channel.ReadBySTAFFID(STAFFID, ptoken);
        }
        
        public int ReadGidByGNAME(string gname, string ptoken) {
            return base.Channel.ReadGidByGNAME(gname, ptoken);
        }
    }
}
