﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.HG_DEPTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.HG_DEPTService.HG_DEPTSoap")]
    public interface HG_DEPTSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int DEPID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT[] Read(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByDEPID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPTList ReadByDEPID(int DEPID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT ReadByName(string DEPNAME, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByStaffid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT[] ReadByStaffid(int STAFFID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_HG_DEPT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int dEPIDField;
        
        private string dEPNAMEField;
        
        private int pDEPIDField;
        
        private string dLEVELField;
        
        private string dEPADDRESSField;
        
        private string dEPMEMOField;
        
        private int iSACTIVEField;
        
        private string bEIZField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int DEPID {
            get {
                return this.dEPIDField;
            }
            set {
                this.dEPIDField = value;
                this.RaisePropertyChanged("DEPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string DEPNAME {
            get {
                return this.dEPNAMEField;
            }
            set {
                this.dEPNAMEField = value;
                this.RaisePropertyChanged("DEPNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PDEPID {
            get {
                return this.pDEPIDField;
            }
            set {
                this.pDEPIDField = value;
                this.RaisePropertyChanged("PDEPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string DLEVEL {
            get {
                return this.dLEVELField;
            }
            set {
                this.dLEVELField = value;
                this.RaisePropertyChanged("DLEVEL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string DEPADDRESS {
            get {
                return this.dEPADDRESSField;
            }
            set {
                this.dEPADDRESSField = value;
                this.RaisePropertyChanged("DEPADDRESS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string DEPMEMO {
            get {
                return this.dEPMEMOField;
            }
            set {
                this.dEPMEMOField = value;
                this.RaisePropertyChanged("DEPMEMO");
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
        public string BEIZ {
            get {
                return this.bEIZField;
            }
            set {
                this.bEIZField = value;
                this.RaisePropertyChanged("BEIZ");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_HG_DEPTList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int dEPIDField;
        
        private string dEPNAMEField;
        
        private int pDEPIDField;
        
        private string pDEPIDNAMEField;
        
        private string dLEVELField;
        
        private string dEPADDRESSField;
        
        private string dEPMEMOField;
        
        private int iSACTIVEField;
        
        private string bEIZField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int DEPID {
            get {
                return this.dEPIDField;
            }
            set {
                this.dEPIDField = value;
                this.RaisePropertyChanged("DEPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string DEPNAME {
            get {
                return this.dEPNAMEField;
            }
            set {
                this.dEPNAMEField = value;
                this.RaisePropertyChanged("DEPNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PDEPID {
            get {
                return this.pDEPIDField;
            }
            set {
                this.pDEPIDField = value;
                this.RaisePropertyChanged("PDEPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string PDEPIDNAME {
            get {
                return this.pDEPIDNAMEField;
            }
            set {
                this.pDEPIDNAMEField = value;
                this.RaisePropertyChanged("PDEPIDNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string DLEVEL {
            get {
                return this.dLEVELField;
            }
            set {
                this.dLEVELField = value;
                this.RaisePropertyChanged("DLEVEL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string DEPADDRESS {
            get {
                return this.dEPADDRESSField;
            }
            set {
                this.dEPADDRESSField = value;
                this.RaisePropertyChanged("DEPADDRESS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string DEPMEMO {
            get {
                return this.dEPMEMOField;
            }
            set {
                this.dEPMEMOField = value;
                this.RaisePropertyChanged("DEPMEMO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string BEIZ {
            get {
                return this.bEIZField;
            }
            set {
                this.bEIZField = value;
                this.RaisePropertyChanged("BEIZ");
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
    public interface HG_DEPTSoapChannel : Sonluk.UI.Model.CRM.HG_DEPTService.HG_DEPTSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HG_DEPTSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.HG_DEPTService.HG_DEPTSoap>, Sonluk.UI.Model.CRM.HG_DEPTService.HG_DEPTSoap {
        
        public HG_DEPTSoapClient() {
        }
        
        public HG_DEPTSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HG_DEPTSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_DEPTSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_DEPTSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public int Delete(int DEPID, string ptoken) {
            return base.Channel.Delete(DEPID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT[] Read(string ptoken) {
            return base.Channel.Read(ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPTList ReadByDEPID(int DEPID, string ptoken) {
            return base.Channel.ReadByDEPID(DEPID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT ReadByName(string DEPNAME, string ptoken) {
            return base.Channel.ReadByName(DEPNAME, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_DEPTService.CRM_HG_DEPT[] ReadByStaffid(int STAFFID, string ptoken) {
            return base.Channel.ReadByStaffid(STAFFID, ptoken);
        }
    }
}
