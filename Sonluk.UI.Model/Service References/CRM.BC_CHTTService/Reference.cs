﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.BC_CHTTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.BC_CHTTService.BC_CHTTSoap")]
    public interface BC_CHTTSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Modify", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Modify(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectMXIDbyDXM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int SelectMXIDbyDXM(string DXM, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectKUNAGbyTTID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SelectKUNAGbyTTID(int PMCHTTID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TongBuSAP_CH", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_WebMSG TongBuSAP_CH();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectCHMXbyDXM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] SelectCHMXbyDXM(string DXM, string TPM, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadMXbyParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] ReadMXbyParam(Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadDXMbyTPM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] ReadDXMbyTPM(string TPM, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_WebMSG : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool sUCCESSField;
        
        private string mSGField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool SUCCESS {
            get {
                return this.sUCCESSField;
            }
            set {
                this.sUCCESSField = value;
                this.RaisePropertyChanged("SUCCESS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MSG {
            get {
                return this.mSGField;
            }
            set {
                this.mSGField = value;
                this.RaisePropertyChanged("MSG");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_BC_CHMX : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int pMCHMXIDField;
        
        private int pMCHTTIDField;
        
        private string vBELNField;
        
        private string pOSNRField;
        
        private string tPMField;
        
        private string dXMField;
        
        private string nHMField;
        
        private string cHARGField;
        
        private string lWEDTField;
        
        private string qXBSField;
        
        private string kUNAGField;
        
        private string mATNRField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int PMCHMXID {
            get {
                return this.pMCHMXIDField;
            }
            set {
                this.pMCHMXIDField = value;
                this.RaisePropertyChanged("PMCHMXID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int PMCHTTID {
            get {
                return this.pMCHTTIDField;
            }
            set {
                this.pMCHTTIDField = value;
                this.RaisePropertyChanged("PMCHTTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string VBELN {
            get {
                return this.vBELNField;
            }
            set {
                this.vBELNField = value;
                this.RaisePropertyChanged("VBELN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string POSNR {
            get {
                return this.pOSNRField;
            }
            set {
                this.pOSNRField = value;
                this.RaisePropertyChanged("POSNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string TPM {
            get {
                return this.tPMField;
            }
            set {
                this.tPMField = value;
                this.RaisePropertyChanged("TPM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string DXM {
            get {
                return this.dXMField;
            }
            set {
                this.dXMField = value;
                this.RaisePropertyChanged("DXM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string NHM {
            get {
                return this.nHMField;
            }
            set {
                this.nHMField = value;
                this.RaisePropertyChanged("NHM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CHARG {
            get {
                return this.cHARGField;
            }
            set {
                this.cHARGField = value;
                this.RaisePropertyChanged("CHARG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string LWEDT {
            get {
                return this.lWEDTField;
            }
            set {
                this.lWEDTField = value;
                this.RaisePropertyChanged("LWEDT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string QXBS {
            get {
                return this.qXBSField;
            }
            set {
                this.qXBSField = value;
                this.RaisePropertyChanged("QXBS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string KUNAG {
            get {
                return this.kUNAGField;
            }
            set {
                this.kUNAGField = value;
                this.RaisePropertyChanged("KUNAG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
                this.RaisePropertyChanged("MATNR");
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
    public interface BC_CHTTSoapChannel : Sonluk.UI.Model.CRM.BC_CHTTService.BC_CHTTSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BC_CHTTSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.BC_CHTTService.BC_CHTTSoap>, Sonluk.UI.Model.CRM.BC_CHTTService.BC_CHTTSoap {
        
        public BC_CHTTSoapClient() {
        }
        
        public BC_CHTTSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BC_CHTTSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BC_CHTTSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BC_CHTTSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Modify(string ptoken) {
            return base.Channel.Modify(ptoken);
        }
        
        public int SelectMXIDbyDXM(string DXM, string ptoken) {
            return base.Channel.SelectMXIDbyDXM(DXM, ptoken);
        }
        
        public string SelectKUNAGbyTTID(int PMCHTTID, string ptoken) {
            return base.Channel.SelectKUNAGbyTTID(PMCHTTID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_CHTTService.CRM_WebMSG TongBuSAP_CH() {
            return base.Channel.TongBuSAP_CH();
        }
        
        public Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] SelectCHMXbyDXM(string DXM, string TPM, string ptoken) {
            return base.Channel.SelectCHMXbyDXM(DXM, TPM, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] ReadMXbyParam(Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model, string ptoken) {
            return base.Channel.ReadMXbyParam(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] ReadDXMbyTPM(string TPM, string ptoken) {
            return base.Channel.ReadDXMbyTPM(TPM, ptoken);
        }
    }
}
