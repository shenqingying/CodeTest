﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.MES.BAT_REPORTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MES.BAT_REPORTService.BAT_REPORTSoap")]
    public interface BAT_REPORTSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEARCH", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.MES.BAT_REPORTService.MES_BAT_REPORT SEARCH(Sonluk.UI.Model.MES.BAT_REPORTService.MES_BAT_REPORT_SEARCH model, string ptoken, int STAFFID);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_BAT_REPORT_SEARCH : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string eRPNOField;
        
        private string xSNOBILLField;
        
        private string xSNOBILLMXField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ERPNO {
            get {
                return this.eRPNOField;
            }
            set {
                this.eRPNOField = value;
                this.RaisePropertyChanged("ERPNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string XSNOBILL {
            get {
                return this.xSNOBILLField;
            }
            set {
                this.xSNOBILLField = value;
                this.RaisePropertyChanged("XSNOBILL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string XSNOBILLMX {
            get {
                return this.xSNOBILLMXField;
            }
            set {
                this.xSNOBILLMXField = value;
                this.RaisePropertyChanged("XSNOBILLMX");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MES_BAT_REPORT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gcField;
        
        private string eRPNOField;
        
        private string xSNOBILLField;
        
        private string xSNOBILLMXField;
        
        private string wLHField;
        
        private string wLMSField;
        
        private int cOUNTZField;
        
        private string sCXField;
        
        private string dATEField;
        
        private string jSDATEField;
        
        private string dCXHField;
        
        private string dCBZKField;
        
        private string dCMAXKField;
        
        private string dCMINKField;
        
        private string dCBZAField;
        
        private string dCMAXAField;
        
        private string dCMINAField;
        
        private string dCBZBField;
        
        private string dCMAXBField;
        
        private string dCMINBField;
        
        private string dCBZCField;
        
        private string dCMAXCField;
        
        private string dCMINCField;
        
        private string sDLXField;
        
        private string dCFDFSField;
        
        private string dCMADField;
        
        private string sZAField;
        
        private string sZBField;
        
        private string sZCField;
        
        private string sZKField;
        
        private string sZDXNField;
        
        private string gDDHField;
        
        private string cOUNTXField;
        
        private string cODOWORDField;
        
        private string sNINFOField;
        
        private string wORDSPACEField;
        
        private string cXSField;
        
        private string wgField;
        
        private string kPRQMField;
        
        private int sAMP1Field;
        
        private int sAMP2Field;
        
        private int sAMP3Field;
        
        private int sAMP4Field;
        
        private int pACKOPENField;
        
        private string fileField;
        
        private MES_RETURN mES_RETURNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ERPNO {
            get {
                return this.eRPNOField;
            }
            set {
                this.eRPNOField = value;
                this.RaisePropertyChanged("ERPNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string XSNOBILL {
            get {
                return this.xSNOBILLField;
            }
            set {
                this.xSNOBILLField = value;
                this.RaisePropertyChanged("XSNOBILL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string XSNOBILLMX {
            get {
                return this.xSNOBILLMXField;
            }
            set {
                this.xSNOBILLMXField = value;
                this.RaisePropertyChanged("XSNOBILLMX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string WLH {
            get {
                return this.wLHField;
            }
            set {
                this.wLHField = value;
                this.RaisePropertyChanged("WLH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string WLMS {
            get {
                return this.wLMSField;
            }
            set {
                this.wLMSField = value;
                this.RaisePropertyChanged("WLMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int COUNTZ {
            get {
                return this.cOUNTZField;
            }
            set {
                this.cOUNTZField = value;
                this.RaisePropertyChanged("COUNTZ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string SCX {
            get {
                return this.sCXField;
            }
            set {
                this.sCXField = value;
                this.RaisePropertyChanged("SCX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string DATE {
            get {
                return this.dATEField;
            }
            set {
                this.dATEField = value;
                this.RaisePropertyChanged("DATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string JSDATE {
            get {
                return this.jSDATEField;
            }
            set {
                this.jSDATEField = value;
                this.RaisePropertyChanged("JSDATE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string DCXH {
            get {
                return this.dCXHField;
            }
            set {
                this.dCXHField = value;
                this.RaisePropertyChanged("DCXH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string DCBZK {
            get {
                return this.dCBZKField;
            }
            set {
                this.dCBZKField = value;
                this.RaisePropertyChanged("DCBZK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string DCMAXK {
            get {
                return this.dCMAXKField;
            }
            set {
                this.dCMAXKField = value;
                this.RaisePropertyChanged("DCMAXK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string DCMINK {
            get {
                return this.dCMINKField;
            }
            set {
                this.dCMINKField = value;
                this.RaisePropertyChanged("DCMINK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string DCBZA {
            get {
                return this.dCBZAField;
            }
            set {
                this.dCBZAField = value;
                this.RaisePropertyChanged("DCBZA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string DCMAXA {
            get {
                return this.dCMAXAField;
            }
            set {
                this.dCMAXAField = value;
                this.RaisePropertyChanged("DCMAXA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string DCMINA {
            get {
                return this.dCMINAField;
            }
            set {
                this.dCMINAField = value;
                this.RaisePropertyChanged("DCMINA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string DCBZB {
            get {
                return this.dCBZBField;
            }
            set {
                this.dCBZBField = value;
                this.RaisePropertyChanged("DCBZB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string DCMAXB {
            get {
                return this.dCMAXBField;
            }
            set {
                this.dCMAXBField = value;
                this.RaisePropertyChanged("DCMAXB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string DCMINB {
            get {
                return this.dCMINBField;
            }
            set {
                this.dCMINBField = value;
                this.RaisePropertyChanged("DCMINB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string DCBZC {
            get {
                return this.dCBZCField;
            }
            set {
                this.dCBZCField = value;
                this.RaisePropertyChanged("DCBZC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string DCMAXC {
            get {
                return this.dCMAXCField;
            }
            set {
                this.dCMAXCField = value;
                this.RaisePropertyChanged("DCMAXC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string DCMINC {
            get {
                return this.dCMINCField;
            }
            set {
                this.dCMINCField = value;
                this.RaisePropertyChanged("DCMINC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string SDLX {
            get {
                return this.sDLXField;
            }
            set {
                this.sDLXField = value;
                this.RaisePropertyChanged("SDLX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string DCFDFS {
            get {
                return this.dCFDFSField;
            }
            set {
                this.dCFDFSField = value;
                this.RaisePropertyChanged("DCFDFS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string DCMAD {
            get {
                return this.dCMADField;
            }
            set {
                this.dCMADField = value;
                this.RaisePropertyChanged("DCMAD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string SZA {
            get {
                return this.sZAField;
            }
            set {
                this.sZAField = value;
                this.RaisePropertyChanged("SZA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public string SZB {
            get {
                return this.sZBField;
            }
            set {
                this.sZBField = value;
                this.RaisePropertyChanged("SZB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        public string SZC {
            get {
                return this.sZCField;
            }
            set {
                this.sZCField = value;
                this.RaisePropertyChanged("SZC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
        public string SZK {
            get {
                return this.sZKField;
            }
            set {
                this.sZKField = value;
                this.RaisePropertyChanged("SZK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=30)]
        public string SZDXN {
            get {
                return this.sZDXNField;
            }
            set {
                this.sZDXNField = value;
                this.RaisePropertyChanged("SZDXN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=31)]
        public string GDDH {
            get {
                return this.gDDHField;
            }
            set {
                this.gDDHField = value;
                this.RaisePropertyChanged("GDDH");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=32)]
        public string COUNTX {
            get {
                return this.cOUNTXField;
            }
            set {
                this.cOUNTXField = value;
                this.RaisePropertyChanged("COUNTX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=33)]
        public string CODOWORD {
            get {
                return this.cODOWORDField;
            }
            set {
                this.cODOWORDField = value;
                this.RaisePropertyChanged("CODOWORD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=34)]
        public string SNINFO {
            get {
                return this.sNINFOField;
            }
            set {
                this.sNINFOField = value;
                this.RaisePropertyChanged("SNINFO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=35)]
        public string WORDSPACE {
            get {
                return this.wORDSPACEField;
            }
            set {
                this.wORDSPACEField = value;
                this.RaisePropertyChanged("WORDSPACE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=36)]
        public string CXS {
            get {
                return this.cXSField;
            }
            set {
                this.cXSField = value;
                this.RaisePropertyChanged("CXS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=37)]
        public string WG {
            get {
                return this.wgField;
            }
            set {
                this.wgField = value;
                this.RaisePropertyChanged("WG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=38)]
        public string KPRQM {
            get {
                return this.kPRQMField;
            }
            set {
                this.kPRQMField = value;
                this.RaisePropertyChanged("KPRQM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=39)]
        public int SAMP1 {
            get {
                return this.sAMP1Field;
            }
            set {
                this.sAMP1Field = value;
                this.RaisePropertyChanged("SAMP1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=40)]
        public int SAMP2 {
            get {
                return this.sAMP2Field;
            }
            set {
                this.sAMP2Field = value;
                this.RaisePropertyChanged("SAMP2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=41)]
        public int SAMP3 {
            get {
                return this.sAMP3Field;
            }
            set {
                this.sAMP3Field = value;
                this.RaisePropertyChanged("SAMP3");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=42)]
        public int SAMP4 {
            get {
                return this.sAMP4Field;
            }
            set {
                this.sAMP4Field = value;
                this.RaisePropertyChanged("SAMP4");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=43)]
        public int PACKOPEN {
            get {
                return this.pACKOPENField;
            }
            set {
                this.pACKOPENField = value;
                this.RaisePropertyChanged("PACKOPEN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=44)]
        public string File {
            get {
                return this.fileField;
            }
            set {
                this.fileField = value;
                this.RaisePropertyChanged("File");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=45)]
        public MES_RETURN MES_RETURN {
            get {
                return this.mES_RETURNField;
            }
            set {
                this.mES_RETURNField = value;
                this.RaisePropertyChanged("MES_RETURN");
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
    public interface BAT_REPORTSoapChannel : Sonluk.UI.Model.MES.BAT_REPORTService.BAT_REPORTSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BAT_REPORTSoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.MES.BAT_REPORTService.BAT_REPORTSoap>, Sonluk.UI.Model.MES.BAT_REPORTService.BAT_REPORTSoap {
        
        public BAT_REPORTSoapClient() {
        }
        
        public BAT_REPORTSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BAT_REPORTSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BAT_REPORTSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BAT_REPORTSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.MES.BAT_REPORTService.MES_BAT_REPORT SEARCH(Sonluk.UI.Model.MES.BAT_REPORTService.MES_BAT_REPORT_SEARCH model, string ptoken, int STAFFID) {
            return base.Channel.SEARCH(model, ptoken, STAFFID);
        }
    }
}
