﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.HG_ROLEService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.HG_ROLEService.HG_ROLESoap")]
    public interface HG_ROLESoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int ROLEID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE[] Read(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByParam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE[] ReadByParam(Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE model, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create_STAFFROLE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create_STAFFROLE(int STAFFID, int ROLEID, string ptoken);
        
        // CODEGEN: 参数“Read_STAFFROLEbyROLEIDResult”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read_STAFFROLEbyROLEID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_ROLEService.Read_STAFFROLEbyROLEIDResponse Read_STAFFROLEbyROLEID(Sonluk.UI.Model.CRM.HG_ROLEService.Read_STAFFROLEbyROLEIDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete_STAFFROLE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete_STAFFROLE(int STAFFID, int ROLEID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create_ROLERIGHT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create_ROLERIGHT(int ROLEID, int RIGHTID, string ptoken);
        
        // CODEGEN: 参数“Read_ROLERIGHTByRIGHTIDResult”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read_ROLERIGHTByRIGHTID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_ROLEService.Read_ROLERIGHTByRIGHTIDResponse Read_ROLERIGHTByRIGHTID(Sonluk.UI.Model.CRM.HG_ROLEService.Read_ROLERIGHTByRIGHTIDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete_ROLERIGHT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete_ROLERIGHT(int ROLEID, int RIGHTID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read_STAFFROLEbySTAFFID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_STAFFROLEList[] Read_STAFFROLEbySTAFFID(int STAFFID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete_STAFFROLEByStaffid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete_STAFFROLEByStaffid(int STAFFID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read_ROLERIGHTByROLEID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int[] Read_ROLERIGHTByROLEID(int ROLEID, string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_HG_ROLE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int rOLEIDField;
        
        private string rOLENAMEField;
        
        private string rOLEMEMOField;
        
        private int iSACTIVEField;
        
        private string rIGHTNAMEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int ROLEID {
            get {
                return this.rOLEIDField;
            }
            set {
                this.rOLEIDField = value;
                this.RaisePropertyChanged("ROLEID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ROLENAME {
            get {
                return this.rOLENAMEField;
            }
            set {
                this.rOLENAMEField = value;
                this.RaisePropertyChanged("ROLENAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ROLEMEMO {
            get {
                return this.rOLEMEMOField;
            }
            set {
                this.rOLEMEMOField = value;
                this.RaisePropertyChanged("ROLEMEMO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string RIGHTNAME {
            get {
                return this.rIGHTNAMEField;
            }
            set {
                this.rIGHTNAMEField = value;
                this.RaisePropertyChanged("RIGHTNAME");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_HG_STAFFROLEList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int sTAFFIDField;
        
        private int rOLEIDField;
        
        private string rOLEIDDESField;
        
        private string sTAFFNAMEField;
        
        private string sTAFFNOField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int ROLEID {
            get {
                return this.rOLEIDField;
            }
            set {
                this.rOLEIDField = value;
                this.RaisePropertyChanged("ROLEID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ROLEIDDES {
            get {
                return this.rOLEIDDESField;
            }
            set {
                this.rOLEIDDESField = value;
                this.RaisePropertyChanged("ROLEIDDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string STAFFNAME {
            get {
                return this.sTAFFNAMEField;
            }
            set {
                this.sTAFFNAMEField = value;
                this.RaisePropertyChanged("STAFFNAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string STAFFNO {
            get {
                return this.sTAFFNOField;
            }
            set {
                this.sTAFFNOField = value;
                this.RaisePropertyChanged("STAFFNO");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Read_STAFFROLEbyROLEID", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class Read_STAFFROLEbyROLEIDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int ROLEID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string ptoken;
        
        public Read_STAFFROLEbyROLEIDRequest() {
        }
        
        public Read_STAFFROLEbyROLEIDRequest(int ROLEID, string ptoken) {
            this.ROLEID = ROLEID;
            this.ptoken = ptoken;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Read_STAFFROLEbyROLEIDResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class Read_STAFFROLEbyROLEIDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] Read_STAFFROLEbyROLEIDResult;
        
        public Read_STAFFROLEbyROLEIDResponse() {
        }
        
        public Read_STAFFROLEbyROLEIDResponse(string[][] Read_STAFFROLEbyROLEIDResult) {
            this.Read_STAFFROLEbyROLEIDResult = Read_STAFFROLEbyROLEIDResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Read_ROLERIGHTByRIGHTID", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class Read_ROLERIGHTByRIGHTIDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int RIGHTID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string ptoken;
        
        public Read_ROLERIGHTByRIGHTIDRequest() {
        }
        
        public Read_ROLERIGHTByRIGHTIDRequest(int RIGHTID, string ptoken) {
            this.RIGHTID = RIGHTID;
            this.ptoken = ptoken;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Read_ROLERIGHTByRIGHTIDResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class Read_ROLERIGHTByRIGHTIDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] Read_ROLERIGHTByRIGHTIDResult;
        
        public Read_ROLERIGHTByRIGHTIDResponse() {
        }
        
        public Read_ROLERIGHTByRIGHTIDResponse(string[][] Read_ROLERIGHTByRIGHTIDResult) {
            this.Read_ROLERIGHTByRIGHTIDResult = Read_ROLERIGHTByRIGHTIDResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface HG_ROLESoapChannel : Sonluk.UI.Model.CRM.HG_ROLEService.HG_ROLESoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HG_ROLESoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.HG_ROLEService.HG_ROLESoap>, Sonluk.UI.Model.CRM.HG_ROLEService.HG_ROLESoap {
        
        public HG_ROLESoapClient() {
        }
        
        public HG_ROLESoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HG_ROLESoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_ROLESoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HG_ROLESoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public int Create(Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE model, string ptoken) {
            return base.Channel.Create(model, ptoken);
        }
        
        public int Update(Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE model, string ptoken) {
            return base.Channel.Update(model, ptoken);
        }
        
        public int Delete(int ROLEID, string ptoken) {
            return base.Channel.Delete(ROLEID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE[] Read(string ptoken) {
            return base.Channel.Read(ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE[] ReadByParam(Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_ROLE model, string ptoken) {
            return base.Channel.ReadByParam(model, ptoken);
        }
        
        public int Create_STAFFROLE(int STAFFID, int ROLEID, string ptoken) {
            return base.Channel.Create_STAFFROLE(STAFFID, ROLEID, ptoken);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.UI.Model.CRM.HG_ROLEService.Read_STAFFROLEbyROLEIDResponse Sonluk.UI.Model.CRM.HG_ROLEService.HG_ROLESoap.Read_STAFFROLEbyROLEID(Sonluk.UI.Model.CRM.HG_ROLEService.Read_STAFFROLEbyROLEIDRequest request) {
            return base.Channel.Read_STAFFROLEbyROLEID(request);
        }
        
        public string[][] Read_STAFFROLEbyROLEID(int ROLEID, string ptoken) {
            Sonluk.UI.Model.CRM.HG_ROLEService.Read_STAFFROLEbyROLEIDRequest inValue = new Sonluk.UI.Model.CRM.HG_ROLEService.Read_STAFFROLEbyROLEIDRequest();
            inValue.ROLEID = ROLEID;
            inValue.ptoken = ptoken;
            Sonluk.UI.Model.CRM.HG_ROLEService.Read_STAFFROLEbyROLEIDResponse retVal = ((Sonluk.UI.Model.CRM.HG_ROLEService.HG_ROLESoap)(this)).Read_STAFFROLEbyROLEID(inValue);
            return retVal.Read_STAFFROLEbyROLEIDResult;
        }
        
        public int Delete_STAFFROLE(int STAFFID, int ROLEID, string ptoken) {
            return base.Channel.Delete_STAFFROLE(STAFFID, ROLEID, ptoken);
        }
        
        public int Create_ROLERIGHT(int ROLEID, int RIGHTID, string ptoken) {
            return base.Channel.Create_ROLERIGHT(ROLEID, RIGHTID, ptoken);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.UI.Model.CRM.HG_ROLEService.Read_ROLERIGHTByRIGHTIDResponse Sonluk.UI.Model.CRM.HG_ROLEService.HG_ROLESoap.Read_ROLERIGHTByRIGHTID(Sonluk.UI.Model.CRM.HG_ROLEService.Read_ROLERIGHTByRIGHTIDRequest request) {
            return base.Channel.Read_ROLERIGHTByRIGHTID(request);
        }
        
        public string[][] Read_ROLERIGHTByRIGHTID(int RIGHTID, string ptoken) {
            Sonluk.UI.Model.CRM.HG_ROLEService.Read_ROLERIGHTByRIGHTIDRequest inValue = new Sonluk.UI.Model.CRM.HG_ROLEService.Read_ROLERIGHTByRIGHTIDRequest();
            inValue.RIGHTID = RIGHTID;
            inValue.ptoken = ptoken;
            Sonluk.UI.Model.CRM.HG_ROLEService.Read_ROLERIGHTByRIGHTIDResponse retVal = ((Sonluk.UI.Model.CRM.HG_ROLEService.HG_ROLESoap)(this)).Read_ROLERIGHTByRIGHTID(inValue);
            return retVal.Read_ROLERIGHTByRIGHTIDResult;
        }
        
        public int Delete_ROLERIGHT(int ROLEID, int RIGHTID, string ptoken) {
            return base.Channel.Delete_ROLERIGHT(ROLEID, RIGHTID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.HG_ROLEService.CRM_HG_STAFFROLEList[] Read_STAFFROLEbySTAFFID(int STAFFID, string ptoken) {
            return base.Channel.Read_STAFFROLEbySTAFFID(STAFFID, ptoken);
        }
        
        public int Delete_STAFFROLEByStaffid(int STAFFID, string ptoken) {
            return base.Channel.Delete_STAFFROLEByStaffid(STAFFID, ptoken);
        }
        
        public int[] Read_ROLERIGHTByROLEID(int ROLEID, string ptoken) {
            return base.Channel.Read_ROLERIGHTByROLEID(ROLEID, ptoken);
        }
    }
}