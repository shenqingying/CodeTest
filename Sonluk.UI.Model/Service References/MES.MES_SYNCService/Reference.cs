﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.MES_SYNCService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.MES_SYNCService.MES_SYNCSoap")]
    public interface MES_SYNCSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_SYNC_GZZX", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SYNC_GZZX(string GC, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_PFDH_SYNC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool MES_PFDH_SYNC(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_WLGROUP_SYNC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_WLGROUP_SYNC(string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_SYNC_WL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SYNC_WL(string GC, string WLGROUP, string WLH, int JLR, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_SYNC_KCDD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SYNC_KCDD(string GC, string ptoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_SYNC_ALL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SYNC_ALL();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_PFDH_XFPC_SYNC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_PFDH_XFPC_SYNC();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_SY_TPM_SYNC_AUTO", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SY_TPM_SYNC_AUTO();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_SY_TPM_SYNC_AUTO_TIME", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SY_TPM_SYNC_AUTO_TIME(string IV_DATEST, string IV_DATEED);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_PD_GD_SYNC_AUTO", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_PD_GD_SYNC_AUTO();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MES_PD_GD_SYNC_AUTO_TIME", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_PD_GD_SYNC_AUTO_TIME(string LOW, string HIGH);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_RETURN : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string tYPEField;
        
        private string mESSAGEField;
        
        private int tIDField;
        
        private string gcField;
        
        private string tmField;
        
        private string bhField;
        
        private int xhField;
        
        private int tMSXField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string TYPE {
            get {
                return this.tYPEField;
            }
            set {
                this.tYPEField = value;
                this.RaisePropertyChanged("TYPE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int TID {
            get {
                return this.tIDField;
            }
            set {
                this.tIDField = value;
                this.RaisePropertyChanged("TID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string GC {
            get {
                return this.gcField;
            }
            set {
                this.gcField = value;
                this.RaisePropertyChanged("GC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string TM {
            get {
                return this.tmField;
            }
            set {
                this.tmField = value;
                this.RaisePropertyChanged("TM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string BH {
            get {
                return this.bhField;
            }
            set {
                this.bhField = value;
                this.RaisePropertyChanged("BH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int XH {
            get {
                return this.xhField;
            }
            set {
                this.xhField = value;
                this.RaisePropertyChanged("XH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int TMSX {
            get {
                return this.tMSXField;
            }
            set {
                this.tMSXField = value;
                this.RaisePropertyChanged("TMSX");
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
    public interface MES_SYNCSoapChannel : Sonluk.UI.Model.MES.MES_SYNCService.MES_SYNCSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MES_SYNCSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.MES_SYNCService.MES_SYNCSoap>, Sonluk.UI.Model.MES.MES_SYNCService.MES_SYNCSoap {
        
        public MES_SYNCSoapClient() {
        }
        
        public MES_SYNCSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MES_SYNCSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MES_SYNCSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MES_SYNCSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SYNC_GZZX(string GC, string ptoken) {
            return base.Channel.MES_SYNC_GZZX(GC, ptoken);
        }
        
        public bool MES_PFDH_SYNC(string ptoken) {
            return base.Channel.MES_PFDH_SYNC(ptoken);
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_WLGROUP_SYNC(string ptoken) {
            return base.Channel.MES_WLGROUP_SYNC(ptoken);
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SYNC_WL(string GC, string WLGROUP, string WLH, int JLR, string ptoken) {
            return base.Channel.MES_SYNC_WL(GC, WLGROUP, WLH, JLR, ptoken);
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SYNC_KCDD(string GC, string ptoken) {
            return base.Channel.MES_SYNC_KCDD(GC, ptoken);
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SYNC_ALL() {
            return base.Channel.MES_SYNC_ALL();
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_PFDH_XFPC_SYNC() {
            return base.Channel.MES_PFDH_XFPC_SYNC();
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SY_TPM_SYNC_AUTO() {
            return base.Channel.MES_SY_TPM_SYNC_AUTO();
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_SY_TPM_SYNC_AUTO_TIME(string IV_DATEST, string IV_DATEED) {
            return base.Channel.MES_SY_TPM_SYNC_AUTO_TIME(IV_DATEST, IV_DATEED);
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_PD_GD_SYNC_AUTO() {
            return base.Channel.MES_PD_GD_SYNC_AUTO();
        }
        
        public Sonluk.UI.Model.MES.MES_SYNCService.MES_RETURN MES_PD_GD_SYNC_AUTO_TIME(string LOW, string HIGH) {
            return base.Channel.MES_PD_GD_SYNC_AUTO_TIME(LOW, HIGH);
        }
    }
}
