﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.SSO.UserTokenService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SSO.UserTokenService.UserTokenSoap")]
    public interface UserTokenSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Token", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.SSO.UserTokenService.TokenInfo Token(string name, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Menu", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.SSO.UserTokenService.MenuInfo Menu(string ptoken, string parent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AcceptToken", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.SSO.UserTokenService.AccountInfo AcceptToken(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidateToken", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool ValidateToken(string ptoken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class TokenInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string access_tokenField;
        
        private string expires_inField;
        
        private string mSGField;
        
        private string mESSAGEField;
        
        private int sTAFFIDField;
        
        private string tOKENIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string access_token {
            get {
                return this.access_tokenField;
            }
            set {
                this.access_tokenField = value;
                this.RaisePropertyChanged("access_token");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string expires_in {
            get {
                return this.expires_inField;
            }
            set {
                this.expires_inField = value;
                this.RaisePropertyChanged("expires_in");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string MSG {
            get {
                return this.mSGField;
            }
            set {
                this.mSGField = value;
                this.RaisePropertyChanged("MSG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string MESSAGE {
            get {
                return this.mESSAGEField;
            }
            set {
                this.mESSAGEField = value;
                this.RaisePropertyChanged("MESSAGE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string TOKENID {
            get {
                return this.tOKENIDField;
            }
            set {
                this.tOKENIDField = value;
                this.RaisePropertyChanged("TOKENID");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class RouteInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string areaField;
        
        private string controllerField;
        
        private string actionField;
        
        private string authField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Area {
            get {
                return this.areaField;
            }
            set {
                this.areaField = value;
                this.RaisePropertyChanged("Area");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Controller {
            get {
                return this.controllerField;
            }
            set {
                this.controllerField = value;
                this.RaisePropertyChanged("Controller");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Action {
            get {
                return this.actionField;
            }
            set {
                this.actionField = value;
                this.RaisePropertyChanged("Action");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Auth {
            get {
                return this.authField;
            }
            set {
                this.authField = value;
                this.RaisePropertyChanged("Auth");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class AuthorizationInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string purchasingGroupField;
        
        private string releaseGroupField;
        
        private string releaseCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string PurchasingGroup {
            get {
                return this.purchasingGroupField;
            }
            set {
                this.purchasingGroupField = value;
                this.RaisePropertyChanged("PurchasingGroup");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ReleaseGroup {
            get {
                return this.releaseGroupField;
            }
            set {
                this.releaseGroupField = value;
                this.RaisePropertyChanged("ReleaseGroup");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ReleaseCode {
            get {
                return this.releaseCodeField;
            }
            set {
                this.releaseCodeField = value;
                this.RaisePropertyChanged("ReleaseCode");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class AccountInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int snField;
        
        private string idField;
        
        private string nameField;
        
        private bool signInField;
        
        private int typeField;
        
        private string menuField;
        
        private string eMailField;
        
        private string telphoneField;
        
        private int externalSignInField;
        
        private int statusField;
        
        private string messageField;
        
        private int groupField;
        
        private string purGroupField;
        
        private string messageDetailsField;
        
        private AuthorizationInfo sAPAuthorizationField;
        
        private RouteInfo routeField;
        
        private string[] authorizationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int SN {
            get {
                return this.snField;
            }
            set {
                this.snField = value;
                this.RaisePropertyChanged("SN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public bool SignIn {
            get {
                return this.signInField;
            }
            set {
                this.signInField = value;
                this.RaisePropertyChanged("SignIn");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Menu {
            get {
                return this.menuField;
            }
            set {
                this.menuField = value;
                this.RaisePropertyChanged("Menu");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string EMail {
            get {
                return this.eMailField;
            }
            set {
                this.eMailField = value;
                this.RaisePropertyChanged("EMail");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Telphone {
            get {
                return this.telphoneField;
            }
            set {
                this.telphoneField = value;
                this.RaisePropertyChanged("Telphone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int ExternalSignIn {
            get {
                return this.externalSignInField;
            }
            set {
                this.externalSignInField = value;
                this.RaisePropertyChanged("ExternalSignIn");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("Status");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("Message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int Group {
            get {
                return this.groupField;
            }
            set {
                this.groupField = value;
                this.RaisePropertyChanged("Group");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string PurGroup {
            get {
                return this.purGroupField;
            }
            set {
                this.purGroupField = value;
                this.RaisePropertyChanged("PurGroup");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string MessageDetails {
            get {
                return this.messageDetailsField;
            }
            set {
                this.messageDetailsField = value;
                this.RaisePropertyChanged("MessageDetails");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public AuthorizationInfo SAPAuthorization {
            get {
                return this.sAPAuthorizationField;
            }
            set {
                this.sAPAuthorizationField = value;
                this.RaisePropertyChanged("SAPAuthorization");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public RouteInfo Route {
            get {
                return this.routeField;
            }
            set {
                this.routeField = value;
                this.RaisePropertyChanged("Route");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=16)]
        public string[] Authorization {
            get {
                return this.authorizationField;
            }
            set {
                this.authorizationField = value;
                this.RaisePropertyChanged("Authorization");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MenuInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string nodeField;
        
        private string uriField;
        
        private MenuInfo[] childrenField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Node {
            get {
                return this.nodeField;
            }
            set {
                this.nodeField = value;
                this.RaisePropertyChanged("Node");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Uri {
            get {
                return this.uriField;
            }
            set {
                this.uriField = value;
                this.RaisePropertyChanged("Uri");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        public MenuInfo[] Children {
            get {
                return this.childrenField;
            }
            set {
                this.childrenField = value;
                this.RaisePropertyChanged("Children");
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
    public interface UserTokenSoapChannel : Sonluk.UI.Model.SSO.UserTokenService.UserTokenSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserTokenSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.SSO.UserTokenService.UserTokenSoap>, Sonluk.UI.Model.SSO.UserTokenService.UserTokenSoap {
        
        public UserTokenSoapClient() {
        }
        
        public UserTokenSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserTokenSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserTokenSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserTokenSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.SSO.UserTokenService.TokenInfo Token(string name, string password) {
            return base.Channel.Token(name, password);
        }
        
        public Sonluk.UI.Model.SSO.UserTokenService.MenuInfo Menu(string ptoken, string parent) {
            return base.Channel.Menu(ptoken, parent);
        }
        
        public Sonluk.UI.Model.SSO.UserTokenService.AccountInfo AcceptToken(string ptoken) {
            return base.Channel.AcceptToken(ptoken);
        }
        
        public bool ValidateToken(string ptoken) {
            return base.Channel.ValidateToken(ptoken);
        }
    }
}
