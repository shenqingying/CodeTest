﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.HG_RIGHTGROUPService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.HG_RIGHTGROUPService.HG_RIGHTGROUPSoap")]
    public interface HG_RIGHTGROUPSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.HG_RIGHTGROUPService.CRM_HG_RIGHTGROUP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.HG_RIGHTGROUPService.CRM_HG_RIGHTGROUP model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int RGROUPID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_RIGHTGROUPService.CRM_HG_RIGHTGROUP[] Read(string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_HG_RIGHTGROUP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int rGROUPIDField;
        
        private string rGROUPNAMEField;
        
        private int pRGROUPIDField;
        
        private int pRIGHTNOField;
        
        private string rGROUPMEMOField;
        
        private int iSACTIVEField;
        
        private string iMAGELJField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int RGROUPID {
            get {
                return this.rGROUPIDField;
            }
            set {
                this.rGROUPIDField = value;
                this.RaisePropertyChanged("RGROUPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string RGROUPNAME {
            get {
                return this.rGROUPNAMEField;
            }
            set {
                this.rGROUPNAMEField = value;
                this.RaisePropertyChanged("RGROUPNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PRGROUPID {
            get {
                return this.pRGROUPIDField;
            }
            set {
                this.pRGROUPIDField = value;
                this.RaisePropertyChanged("PRGROUPID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int PRIGHTNO {
            get {
                return this.pRIGHTNOField;
            }
            set {
                this.pRIGHTNOField = value;
                this.RaisePropertyChanged("PRIGHTNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string RGROUPMEMO {
            get {
                return this.rGROUPMEMOField;
            }
            set {
                this.rGROUPMEMOField = value;
                this.RaisePropertyChanged("RGROUPMEMO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string IMAGELJ {
            get {
                return this.iMAGELJField;
            }
            set {
                this.iMAGELJField = value;
                this.RaisePropertyChanged("IMAGELJ");
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
    public interface HG_RIGHTGROUPSoapChannel : Sonluk.UI.Model.CRM.HG_RIGHTGROUPService.HG_RIGHTGROUPSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HG_RIGHTGROUPSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.HG_RIGHTGROUPService.HG_RIGHTGROUPSoap>, Sonluk.UI.Model.CRM.HG_RIGHTGROUPService.HG_RIGHTGROUPSoap {
        
        public HG_RIGHTGROUPSoapClient() {
        }
        
        public HG_RIGHTGROUPSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HG_RIGHTGROUPSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_RIGHTGROUPSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_RIGHTGROUPSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.HG_RIGHTGROUPService.CRM_HG_RIGHTGROUP model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.HG_RIGHTGROUPService.CRM_HG_RIGHTGROUP model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public int Delete(int RGROUPID, string ptoken) {
            return base.Channel.Delete(RGROUPID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_RIGHTGROUPService.CRM_HG_RIGHTGROUP[] Read(string ptoken) {
            return base.Channel.Read(ptoken);
        }
    }
}