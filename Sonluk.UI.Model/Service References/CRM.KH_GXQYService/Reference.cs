﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.KH_GXQYService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.KH_GXQYService.KH_GXQYSoap")]
    public interface KH_GXQYSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQYList[] Read(int KHID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int GXQYID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteByKHID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteByKHID(int KHID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_KH_GXQY : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int gXQYIDField;
        
        private int kHIDField;
        
        private int gXQYLXField;
        
        private int gXQYMCField;
        
        private int iSACTIVEField;
        
        private string bEIZField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int GXQYID {
            get {
                return this.gXQYIDField;
            }
            set {
                this.gXQYIDField = value;
                this.RaisePropertyChanged("GXQYID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int GXQYLX {
            get {
                return this.gXQYLXField;
            }
            set {
                this.gXQYLXField = value;
                this.RaisePropertyChanged("GXQYLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int GXQYMC {
            get {
                return this.gXQYMCField;
            }
            set {
                this.gXQYMCField = value;
                this.RaisePropertyChanged("GXQYMC");
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
    public partial class CRM_KH_GXQYList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int fIDField;
        
        private int gXQYIDField;
        
        private int kHIDField;
        
        private int gXQYLXField;
        
        private int gXQYMCField;
        
        private int iSACTIVEField;
        
        private string bEIZField;
        
        private string gXQYMCDESField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int FID {
            get {
                return this.fIDField;
            }
            set {
                this.fIDField = value;
                this.RaisePropertyChanged("FID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int GXQYID {
            get {
                return this.gXQYIDField;
            }
            set {
                this.gXQYIDField = value;
                this.RaisePropertyChanged("GXQYID");
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
        public int GXQYLX {
            get {
                return this.gXQYLXField;
            }
            set {
                this.gXQYLXField = value;
                this.RaisePropertyChanged("GXQYLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int GXQYMC {
            get {
                return this.gXQYMCField;
            }
            set {
                this.gXQYMCField = value;
                this.RaisePropertyChanged("GXQYMC");
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
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string GXQYMCDES {
            get {
                return this.gXQYMCDESField;
            }
            set {
                this.gXQYMCDESField = value;
                this.RaisePropertyChanged("GXQYMCDES");
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
    public interface KH_GXQYSoapChannel : Sonluk.UI.Model.CRM.KH_GXQYService.KH_GXQYSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KH_GXQYSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.KH_GXQYService.KH_GXQYSoap>, Sonluk.UI.Model.CRM.KH_GXQYService.KH_GXQYSoap {
        
        public KH_GXQYSoapClient() {
        }
        
        public KH_GXQYSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KH_GXQYSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KH_GXQYSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KH_GXQYSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQYList[] Read(int KHID, string ptoken) {
            return base.Channel.Read(KHID, ptoken);
        }
        
        public int Delete(int GXQYID, string ptoken) {
            return base.Channel.Delete(GXQYID, ptoken);
        }
        
        public int DeleteByKHID(int KHID, string ptoken) {
            return base.Channel.DeleteByKHID(KHID, ptoken);
        }
    }
}
