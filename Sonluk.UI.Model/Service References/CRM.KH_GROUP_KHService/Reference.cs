﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.CRM.KH_GROUP_KHService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRM.KH_GROUP_KHService.KH_GROUP_KHSoap")]
    public interface KH_GROUP_KHSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        // CODEGEN: 参数“ReadByKHIDResult”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByKHID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByKHIDResponse ReadByKHID(Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByKHIDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Create(int KHID, int GID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int KHID, int GID, string ptoken);
        
        // CODEGEN: 参数“ReadResult”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadResponse Read(Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadRequest request);
        
        // CODEGEN: 参数“ReadByStaffidResult”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadByStaffid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByStaffidResponse ReadByStaffid(Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByStaffidRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeletebyKHID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeletebyKHID(int KHID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReadStruct", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUP_KHService.CRM_KH_GROUP_KHList[] ReadStruct(int KHID, int GID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(int KHID, int oGID, int nGid, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Report", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUP_KHService.CRM_KH_GROUP_KHList[] Report(string KHMC, int GID, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Report2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.CRM.KH_GROUP_KHService.CRM_KH_GROUP_KHList[] Report2(Sonluk.UI.Model.CRM.KH_GROUP_KHService.CRM_KH_GROUP_KHList model, string ptoken);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReadByKHID", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ReadByKHIDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string ptoken;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int KHID;
        
        public ReadByKHIDRequest() {
        }
        
        public ReadByKHIDRequest(string ptoken, int KHID) {
            this.ptoken = ptoken;
            this.KHID = KHID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReadByKHIDResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ReadByKHIDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] ReadByKHIDResult;
        
        public ReadByKHIDResponse() {
        }
        
        public ReadByKHIDResponse(string[][] ReadByKHIDResult) {
            this.ReadByKHIDResult = ReadByKHIDResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Read", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ReadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string ptoken;
        
        public ReadRequest() {
        }
        
        public ReadRequest(string ptoken) {
            this.ptoken = ptoken;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReadResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ReadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] ReadResult;
        
        public ReadResponse() {
        }
        
        public ReadResponse(string[][] ReadResult) {
            this.ReadResult = ReadResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReadByStaffid", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ReadByStaffidRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int STAFFID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string ptoken;
        
        public ReadByStaffidRequest() {
        }
        
        public ReadByStaffidRequest(int STAFFID, string ptoken) {
            this.STAFFID = STAFFID;
            this.ptoken = ptoken;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReadByStaffidResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ReadByStaffidResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] ReadByStaffidResult;
        
        public ReadByStaffidResponse() {
        }
        
        public ReadByStaffidResponse(string[][] ReadByStaffidResult) {
            this.ReadByStaffidResult = ReadByStaffidResult;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRM_KH_GROUP_KHList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int gIDField;
        
        private int kHIDField;
        
        private string gIDDESField;
        
        private string kHIDDESField;
        
        private string cRMIDField;
        
        private string jXSMCField;
        
        private string jXSCRMIDField;
        
        private string jXSSAPSNField;
        
        private string pKHMCField;
        
        private string pKHCRMIDField;
        
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
        public string GIDDES {
            get {
                return this.gIDDESField;
            }
            set {
                this.gIDDESField = value;
                this.RaisePropertyChanged("GIDDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string KHIDDES {
            get {
                return this.kHIDDESField;
            }
            set {
                this.kHIDDESField = value;
                this.RaisePropertyChanged("KHIDDES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string CRMID {
            get {
                return this.cRMIDField;
            }
            set {
                this.cRMIDField = value;
                this.RaisePropertyChanged("CRMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string JXSMC {
            get {
                return this.jXSMCField;
            }
            set {
                this.jXSMCField = value;
                this.RaisePropertyChanged("JXSMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string JXSCRMID {
            get {
                return this.jXSCRMIDField;
            }
            set {
                this.jXSCRMIDField = value;
                this.RaisePropertyChanged("JXSCRMID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string JXSSAPSN {
            get {
                return this.jXSSAPSNField;
            }
            set {
                this.jXSSAPSNField = value;
                this.RaisePropertyChanged("JXSSAPSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string PKHMC {
            get {
                return this.pKHMCField;
            }
            set {
                this.pKHMCField = value;
                this.RaisePropertyChanged("PKHMC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string PKHCRMID {
            get {
                return this.pKHCRMIDField;
            }
            set {
                this.pKHCRMIDField = value;
                this.RaisePropertyChanged("PKHCRMID");
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
    public interface KH_GROUP_KHSoapChannel : Sonluk.UI.Model.CRM.KH_GROUP_KHService.KH_GROUP_KHSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KH_GROUP_KHSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.CRM.KH_GROUP_KHService.KH_GROUP_KHSoap>, Sonluk.UI.Model.CRM.KH_GROUP_KHService.KH_GROUP_KHSoap {
        
        public KH_GROUP_KHSoapClient() {
        }
        
        public KH_GROUP_KHSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KH_GROUP_KHSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KH_GROUP_KHSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KH_GROUP_KHSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByKHIDResponse Sonluk.UI.Model.CRM.KH_GROUP_KHService.KH_GROUP_KHSoap.ReadByKHID(Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByKHIDRequest request) {
            return base.Channel.ReadByKHID(request);
        }
        
        public string[][] ReadByKHID(string ptoken, int KHID) {
            Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByKHIDRequest inValue = new Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByKHIDRequest();
            inValue.ptoken = ptoken;
            inValue.KHID = KHID;
            Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByKHIDResponse retVal = ((Sonluk.UI.Model.CRM.KH_GROUP_KHService.KH_GROUP_KHSoap)(this)).ReadByKHID(inValue);
            return retVal.ReadByKHIDResult;
        }
        
        public int Create(int KHID, int GID, string ptoken) {
            return base.Channel.Create(KHID, GID, ptoken);
        }
        
        public int Delete(int KHID, int GID, string ptoken) {
            return base.Channel.Delete(KHID, GID, ptoken);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadResponse Sonluk.UI.Model.CRM.KH_GROUP_KHService.KH_GROUP_KHSoap.Read(Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadRequest request) {
            return base.Channel.Read(request);
        }
        
        public string[][] Read(string ptoken) {
            Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadRequest inValue = new Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadRequest();
            inValue.ptoken = ptoken;
            Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadResponse retVal = ((Sonluk.UI.Model.CRM.KH_GROUP_KHService.KH_GROUP_KHSoap)(this)).Read(inValue);
            return retVal.ReadResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByStaffidResponse Sonluk.UI.Model.CRM.KH_GROUP_KHService.KH_GROUP_KHSoap.ReadByStaffid(Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByStaffidRequest request) {
            return base.Channel.ReadByStaffid(request);
        }
        
        public string[][] ReadByStaffid(int STAFFID, string ptoken) {
            Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByStaffidRequest inValue = new Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByStaffidRequest();
            inValue.STAFFID = STAFFID;
            inValue.ptoken = ptoken;
            Sonluk.UI.Model.CRM.KH_GROUP_KHService.ReadByStaffidResponse retVal = ((Sonluk.UI.Model.CRM.KH_GROUP_KHService.KH_GROUP_KHSoap)(this)).ReadByStaffid(inValue);
            return retVal.ReadByStaffidResult;
        }
        
        public int DeletebyKHID(int KHID, string ptoken) {
            return base.Channel.DeletebyKHID(KHID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KH_GROUP_KHService.CRM_KH_GROUP_KHList[] ReadStruct(int KHID, int GID, string ptoken) {
            return base.Channel.ReadStruct(KHID, GID, ptoken);
        }
        
        public int Update(int KHID, int oGID, int nGid, string ptoken) {
            return base.Channel.Update(KHID, oGID, nGid, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KH_GROUP_KHService.CRM_KH_GROUP_KHList[] Report(string KHMC, int GID, string ptoken) {
            return base.Channel.Report(KHMC, GID, ptoken);
        }
        
        public Sonluk.UI.Model.CRM.KH_GROUP_KHService.CRM_KH_GROUP_KHList[] Report2(Sonluk.UI.Model.CRM.KH_GROUP_KHService.CRM_KH_GROUP_KHList model, string ptoken) {
            return base.Channel.Report2(model, ptoken);
        }
    }
}
