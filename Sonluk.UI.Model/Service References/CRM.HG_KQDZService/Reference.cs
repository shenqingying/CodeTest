﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.HG_KQDZService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.HG_KQDZService.HG_KQDZSoap")]
    public interface HG_KQDZSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int KQDZID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ[] Read(int KQDZID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadBySTAFFID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ[] ReadBySTAFFID(int STAFFID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadBylikeKQDZ", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ[] ReadBylikeKQDZ(string KQDZ, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Report", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList[] Report(Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList model, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_HG_KQDZ : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int kQDZIDField;
        
        private string kQDZField;
        
        private int gjField;
        
        private int sfField;
        
        private int csField;
        
        private string edField;
        
        private string jdField;
        
        private int kQRCField;
        
        private int iSACTIVEField;
        
        private int sTAFFIDField;
        
        private string cJSJField;
        
        private string dWDZMSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int KQDZID {
            get {
                return this.kQDZIDField;
            }
            set {
                this.kQDZIDField = value;
                this.RaisePropertyChanged("KQDZID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string KQDZ {
            get {
                return this.kQDZField;
            }
            set {
                this.kQDZField = value;
                this.RaisePropertyChanged("KQDZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int GJ {
            get {
                return this.gjField;
            }
            set {
                this.gjField = value;
                this.RaisePropertyChanged("GJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int SF {
            get {
                return this.sfField;
            }
            set {
                this.sfField = value;
                this.RaisePropertyChanged("SF");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int CS {
            get {
                return this.csField;
            }
            set {
                this.csField = value;
                this.RaisePropertyChanged("CS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string ED {
            get {
                return this.edField;
            }
            set {
                this.edField = value;
                this.RaisePropertyChanged("ED");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string JD {
            get {
                return this.jdField;
            }
            set {
                this.jdField = value;
                this.RaisePropertyChanged("JD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int KQRC {
            get {
                return this.kQRCField;
            }
            set {
                this.kQRCField = value;
                this.RaisePropertyChanged("KQRC");
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
        public int STAFFID {
            get {
                return this.sTAFFIDField;
            }
            set {
                this.sTAFFIDField = value;
                this.RaisePropertyChanged("STAFFID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string DWDZMS {
            get {
                return this.dWDZMSField;
            }
            set {
                this.dWDZMSField = value;
                this.RaisePropertyChanged("DWDZMS");
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
    public partial class CRM_HG_KQDZList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string dWDZMSField;
        
        private int kQDZIDField;
        
        private string kQDZField;
        
        private int gjField;
        
        private int sfField;
        
        private int csField;
        
        private string edField;
        
        private string jdField;
        
        private int kQRCField;
        
        private int iSACTIVEField;
        
        private int sTAFFIDField;
        
        private string cJSJField;
        
        private string sTAFFIDDESField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string DWDZMS {
            get {
                return this.dWDZMSField;
            }
            set {
                this.dWDZMSField = value;
                this.RaisePropertyChanged("DWDZMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int KQDZID {
            get {
                return this.kQDZIDField;
            }
            set {
                this.kQDZIDField = value;
                this.RaisePropertyChanged("KQDZID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string KQDZ {
            get {
                return this.kQDZField;
            }
            set {
                this.kQDZField = value;
                this.RaisePropertyChanged("KQDZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int GJ {
            get {
                return this.gjField;
            }
            set {
                this.gjField = value;
                this.RaisePropertyChanged("GJ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int SF {
            get {
                return this.sfField;
            }
            set {
                this.sfField = value;
                this.RaisePropertyChanged("SF");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int CS {
            get {
                return this.csField;
            }
            set {
                this.csField = value;
                this.RaisePropertyChanged("CS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string ED {
            get {
                return this.edField;
            }
            set {
                this.edField = value;
                this.RaisePropertyChanged("ED");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string JD {
            get {
                return this.jdField;
            }
            set {
                this.jdField = value;
                this.RaisePropertyChanged("JD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int KQRC {
            get {
                return this.kQRCField;
            }
            set {
                this.kQRCField = value;
                this.RaisePropertyChanged("KQRC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int STAFFID {
            get {
                return this.sTAFFIDField;
            }
            set {
                this.sTAFFIDField = value;
                this.RaisePropertyChanged("STAFFID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string STAFFIDDES {
            get {
                return this.sTAFFIDDESField;
            }
            set {
                this.sTAFFIDDESField = value;
                this.RaisePropertyChanged("STAFFIDDES");
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
    public interface HG_KQDZSoapChannel : Sonluk.UI.Model.CRM.HG_KQDZService.HG_KQDZSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HG_KQDZSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.HG_KQDZService.HG_KQDZSoap>, Sonluk.UI.Model.CRM.HG_KQDZService.HG_KQDZSoap {
        
        public HG_KQDZSoapClient() {
        }
        
        public HG_KQDZSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HG_KQDZSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_KQDZSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_KQDZSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public int Delete(int KQDZID, string ptoken) {
            return base.Channel.Delete(KQDZID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ[] Read(int KQDZID, string ptoken) {
            return base.Channel.Read(KQDZID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ[] ReadBySTAFFID(int STAFFID, string ptoken) {
            return base.Channel.ReadBySTAFFID(STAFFID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ[] ReadBylikeKQDZ(string KQDZ, string ptoken) {
            return base.Channel.ReadBylikeKQDZ(KQDZ, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList[] Report(Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList model, string ptoken) {
            return base.Channel.Report(model, ptoken);
        }
    }
}
