﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.WL_TTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.WL_TTService.WL_TTSoap")]
    public interface WL_TTSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.WL_TTService.CRM_WL_TT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.WL_TTService.CRM_WL_TT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.WL_TTService.CRM_WL_TT[] ReadByParam(Sonluk.UI.Model.CRM.WL_TTService.CRM_WL_TT model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int TTID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_WL_TT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int tTIDField;
        
        private string nUMBERField;
        
        private int cJRField;
        
        private string cJSJField;
        
        private int iSACTIVEField;
        
        private string bEIZField;
        
        private string cJSJ_BEGINField;
        
        private string cJSJ_ENDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int TTID {
            get {
                return this.tTIDField;
            }
            set {
                this.tTIDField = value;
                this.RaisePropertyChanged("TTID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string NUMBER {
            get {
                return this.nUMBERField;
            }
            set {
                this.nUMBERField = value;
                this.RaisePropertyChanged("NUMBER");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        public string CJSJ_BEGIN {
            get {
                return this.cJSJ_BEGINField;
            }
            set {
                this.cJSJ_BEGINField = value;
                this.RaisePropertyChanged("CJSJ_BEGIN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CJSJ_END {
            get {
                return this.cJSJ_ENDField;
            }
            set {
                this.cJSJ_ENDField = value;
                this.RaisePropertyChanged("CJSJ_END");
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
    public interface WL_TTSoapChannel : Sonluk.UI.Model.CRM.WL_TTService.WL_TTSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WL_TTSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.WL_TTService.WL_TTSoap>, Sonluk.UI.Model.CRM.WL_TTService.WL_TTSoap {
        
        public WL_TTSoapClient() {
        }
        
        public WL_TTSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WL_TTSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WL_TTSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WL_TTSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.WL_TTService.CRM_WL_TT model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.WL_TTService.CRM_WL_TT model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.WL_TTService.CRM_WL_TT[] ReadByParam(Sonluk.UI.Model.CRM.WL_TTService.CRM_WL_TT model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Delete(int TTID, string ptoken) {
            return base.Channel.Delete(TTID, ptoken);
        }
    }
}
