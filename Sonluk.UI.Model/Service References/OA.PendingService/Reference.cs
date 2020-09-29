﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.OA.PendingService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Sonluk.com/API/OA/", ConfigurationName="OA.PendingService.PendingSoap")]
    public interface PendingSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Sonluk.com/API/OA/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.OA.PendingService.PendingInfo[] Read(string ticketId, int firstNum, int pageSize, string address);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Sonluk.com/API/OA/")]
    public partial class PendingInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string subjectField;
        
        private string applicationCategoryField;
        
        private string creatorField;
        
        private string distinctField;
        
        private string bodyTypeField;
        
        private string idField;
        
        private string objectIDField;
        
        private string hasAttachmentsField;
        
        private string createDateField;
        
        private string subObjectIDField;
        
        private string importantLevelField;
        
        private string linkField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Subject {
            get {
                return this.subjectField;
            }
            set {
                this.subjectField = value;
                this.RaisePropertyChanged("Subject");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ApplicationCategory {
            get {
                return this.applicationCategoryField;
            }
            set {
                this.applicationCategoryField = value;
                this.RaisePropertyChanged("ApplicationCategory");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Creator {
            get {
                return this.creatorField;
            }
            set {
                this.creatorField = value;
                this.RaisePropertyChanged("Creator");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Distinct {
            get {
                return this.distinctField;
            }
            set {
                this.distinctField = value;
                this.RaisePropertyChanged("Distinct");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string BodyType {
            get {
                return this.bodyTypeField;
            }
            set {
                this.bodyTypeField = value;
                this.RaisePropertyChanged("BodyType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string ObjectID {
            get {
                return this.objectIDField;
            }
            set {
                this.objectIDField = value;
                this.RaisePropertyChanged("ObjectID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string HasAttachments {
            get {
                return this.hasAttachmentsField;
            }
            set {
                this.hasAttachmentsField = value;
                this.RaisePropertyChanged("HasAttachments");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
                this.RaisePropertyChanged("CreateDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string SubObjectID {
            get {
                return this.subObjectIDField;
            }
            set {
                this.subObjectIDField = value;
                this.RaisePropertyChanged("SubObjectID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string ImportantLevel {
            get {
                return this.importantLevelField;
            }
            set {
                this.importantLevelField = value;
                this.RaisePropertyChanged("ImportantLevel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string Link {
            get {
                return this.linkField;
            }
            set {
                this.linkField = value;
                this.RaisePropertyChanged("Link");
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
    public interface PendingSoapChannel : Sonluk.UI.Model.OA.PendingService.PendingSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PendingSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.OA.PendingService.PendingSoap>, Sonluk.UI.Model.OA.PendingService.PendingSoap {
        
        public PendingSoapClient() {
        }
        
        public PendingSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PendingSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PendingSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PendingSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.OA.PendingService.PendingInfo[] Read(string ticketId, int firstNum, int pageSize, string address) {
            return base.Channel.Read(ticketId, firstNum, pageSize, address);
        }
    }
}
