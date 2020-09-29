﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.UI.Model.LE.OutboundDeliveryService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Sonluk.com/API/LE/", ConfigurationName="LE.OutboundDeliveryService.OutboundDeliverySoap")]
    public interface OutboundDeliverySoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Sonluk.com/API/LE/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.LE.OutboundDeliveryService.DeliveryInfo[] Read(Sonluk.UI.Model.LE.OutboundDeliveryService.DeliveryInfo keyowrds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Sonluk.com/API/LE/ItemRead", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.LE.OutboundDeliveryService.DeliveryItemInfo[] ItemRead(string serialNumber);
        
        // CODEGEN: 参数“ExportResult”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://Sonluk.com/API/LE/Export", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Sonluk.UI.Model.LE.OutboundDeliveryService.ExportResponse Export(Sonluk.UI.Model.LE.OutboundDeliveryService.ExportRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Sonluk.com/API/LE/UnLoad", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int UnLoad(int minSales, string deliveryNumberSet, string salesRange);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Sonluk.com/API/LE/")]
    public partial class DeliveryInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string serialNumberField;
        
        private string dateField;
        
        private double conditionValueField;
        
        private string salesOrganizationField;
        
        private string salesDistrField;
        
        private string salesOrderField;
        
        private string customerField;
        
        private string customerNameField;
        
        private string shipToPartyField;
        
        private string shipToPartyNameField;
        
        private string cityField;
        
        private string telephoneField;
        
        private string addressField;
        
        private string remarkField;
        
        private string unitField;
        
        private string typeField;
        
        private decimal totalWeightField;
        
        private decimal netWeightField;
        
        private string deliveryDateField;
        
        private string deliveryDateEndField;
        
        private string pickingDateField;
        
        private string pickingDateEndField;
        
        private string creatorField;
        
        private string createDateField;
        
        private string createDateEndField;
        
        private string createTimeField;
        
        private string statusField;
        
        private string consignmentNoteField;
        
        private string billOfLoadingField;
        
        private string storeLocationField;
        
        private string contactField;
        
        private string contactTelephoneField;
        
        private string[] serialNumberSetField;
        
        private DeliveryItemInfo[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SerialNumber {
            get {
                return this.serialNumberField;
            }
            set {
                this.serialNumberField = value;
                this.RaisePropertyChanged("SerialNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
                this.RaisePropertyChanged("Date");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public double ConditionValue {
            get {
                return this.conditionValueField;
            }
            set {
                this.conditionValueField = value;
                this.RaisePropertyChanged("ConditionValue");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SalesOrganization {
            get {
                return this.salesOrganizationField;
            }
            set {
                this.salesOrganizationField = value;
                this.RaisePropertyChanged("SalesOrganization");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string SalesDistr {
            get {
                return this.salesDistrField;
            }
            set {
                this.salesDistrField = value;
                this.RaisePropertyChanged("SalesDistr");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string SalesOrder {
            get {
                return this.salesOrderField;
            }
            set {
                this.salesOrderField = value;
                this.RaisePropertyChanged("SalesOrder");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Customer {
            get {
                return this.customerField;
            }
            set {
                this.customerField = value;
                this.RaisePropertyChanged("Customer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CustomerName {
            get {
                return this.customerNameField;
            }
            set {
                this.customerNameField = value;
                this.RaisePropertyChanged("CustomerName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string ShipToParty {
            get {
                return this.shipToPartyField;
            }
            set {
                this.shipToPartyField = value;
                this.RaisePropertyChanged("ShipToParty");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string ShipToPartyName {
            get {
                return this.shipToPartyNameField;
            }
            set {
                this.shipToPartyNameField = value;
                this.RaisePropertyChanged("ShipToPartyName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
                this.RaisePropertyChanged("City");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string Telephone {
            get {
                return this.telephoneField;
            }
            set {
                this.telephoneField = value;
                this.RaisePropertyChanged("Telephone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
                this.RaisePropertyChanged("Address");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string Remark {
            get {
                return this.remarkField;
            }
            set {
                this.remarkField = value;
                this.RaisePropertyChanged("Remark");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string Unit {
            get {
                return this.unitField;
            }
            set {
                this.unitField = value;
                this.RaisePropertyChanged("Unit");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public decimal TotalWeight {
            get {
                return this.totalWeightField;
            }
            set {
                this.totalWeightField = value;
                this.RaisePropertyChanged("TotalWeight");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public decimal NetWeight {
            get {
                return this.netWeightField;
            }
            set {
                this.netWeightField = value;
                this.RaisePropertyChanged("NetWeight");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string DeliveryDate {
            get {
                return this.deliveryDateField;
            }
            set {
                this.deliveryDateField = value;
                this.RaisePropertyChanged("DeliveryDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string DeliveryDateEnd {
            get {
                return this.deliveryDateEndField;
            }
            set {
                this.deliveryDateEndField = value;
                this.RaisePropertyChanged("DeliveryDateEnd");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string PickingDate {
            get {
                return this.pickingDateField;
            }
            set {
                this.pickingDateField = value;
                this.RaisePropertyChanged("PickingDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string PickingDateEnd {
            get {
                return this.pickingDateEndField;
            }
            set {
                this.pickingDateEndField = value;
                this.RaisePropertyChanged("PickingDateEnd");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string CreateDateEnd {
            get {
                return this.createDateEndField;
            }
            set {
                this.createDateEndField = value;
                this.RaisePropertyChanged("CreateDateEnd");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string CreateTime {
            get {
                return this.createTimeField;
            }
            set {
                this.createTimeField = value;
                this.RaisePropertyChanged("CreateTime");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("Status");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public string ConsignmentNote {
            get {
                return this.consignmentNoteField;
            }
            set {
                this.consignmentNoteField = value;
                this.RaisePropertyChanged("ConsignmentNote");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        public string BillOfLoading {
            get {
                return this.billOfLoadingField;
            }
            set {
                this.billOfLoadingField = value;
                this.RaisePropertyChanged("BillOfLoading");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
        public string StoreLocation {
            get {
                return this.storeLocationField;
            }
            set {
                this.storeLocationField = value;
                this.RaisePropertyChanged("StoreLocation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=30)]
        public string Contact {
            get {
                return this.contactField;
            }
            set {
                this.contactField = value;
                this.RaisePropertyChanged("Contact");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=31)]
        public string ContactTelephone {
            get {
                return this.contactTelephoneField;
            }
            set {
                this.contactTelephoneField = value;
                this.RaisePropertyChanged("ContactTelephone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=32)]
        public string[] SerialNumberSet {
            get {
                return this.serialNumberSetField;
            }
            set {
                this.serialNumberSetField = value;
                this.RaisePropertyChanged("SerialNumberSet");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=33)]
        public DeliveryItemInfo[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
                this.RaisePropertyChanged("Items");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Sonluk.com/API/LE/")]
    public partial class DeliveryItemInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string serialNumberField;
        
        private int numberField;
        
        private string materialField;
        
        private string matlDescriptionField;
        
        private decimal quantityField;
        
        private string unitField;
        
        private int wholeField;
        
        private int oddField;
        
        private decimal grossWeightField;
        
        private decimal netWeightField;
        
        private string weightUnitField;
        
        private string referenceDocumentField;
        
        private int referenceDocumentItemField;
        
        private string stgeLocField;
        
        private string customerMatlDescField;
        
        private string batchField;
        
        private decimal singleQtyField;
        
        private decimal singleWeightField;
        
        private decimal singleVolumeField;
        
        private string plantField;
        
        private string matlGroupField;
        
        private string typeField;
        
        private string creatorField;
        
        private string createDateField;
        
        private string createTimeField;
        
        private int batchSplitField;
        
        private string statusField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SerialNumber {
            get {
                return this.serialNumberField;
            }
            set {
                this.serialNumberField = value;
                this.RaisePropertyChanged("SerialNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
                this.RaisePropertyChanged("Number");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Material {
            get {
                return this.materialField;
            }
            set {
                this.materialField = value;
                this.RaisePropertyChanged("Material");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string MatlDescription {
            get {
                return this.matlDescriptionField;
            }
            set {
                this.matlDescriptionField = value;
                this.RaisePropertyChanged("MatlDescription");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public decimal Quantity {
            get {
                return this.quantityField;
            }
            set {
                this.quantityField = value;
                this.RaisePropertyChanged("Quantity");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Unit {
            get {
                return this.unitField;
            }
            set {
                this.unitField = value;
                this.RaisePropertyChanged("Unit");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int Whole {
            get {
                return this.wholeField;
            }
            set {
                this.wholeField = value;
                this.RaisePropertyChanged("Whole");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int Odd {
            get {
                return this.oddField;
            }
            set {
                this.oddField = value;
                this.RaisePropertyChanged("Odd");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public decimal GrossWeight {
            get {
                return this.grossWeightField;
            }
            set {
                this.grossWeightField = value;
                this.RaisePropertyChanged("GrossWeight");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public decimal NetWeight {
            get {
                return this.netWeightField;
            }
            set {
                this.netWeightField = value;
                this.RaisePropertyChanged("NetWeight");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string WeightUnit {
            get {
                return this.weightUnitField;
            }
            set {
                this.weightUnitField = value;
                this.RaisePropertyChanged("WeightUnit");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string ReferenceDocument {
            get {
                return this.referenceDocumentField;
            }
            set {
                this.referenceDocumentField = value;
                this.RaisePropertyChanged("ReferenceDocument");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int ReferenceDocumentItem {
            get {
                return this.referenceDocumentItemField;
            }
            set {
                this.referenceDocumentItemField = value;
                this.RaisePropertyChanged("ReferenceDocumentItem");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string StgeLoc {
            get {
                return this.stgeLocField;
            }
            set {
                this.stgeLocField = value;
                this.RaisePropertyChanged("StgeLoc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string CustomerMatlDesc {
            get {
                return this.customerMatlDescField;
            }
            set {
                this.customerMatlDescField = value;
                this.RaisePropertyChanged("CustomerMatlDesc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string Batch {
            get {
                return this.batchField;
            }
            set {
                this.batchField = value;
                this.RaisePropertyChanged("Batch");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public decimal SingleQty {
            get {
                return this.singleQtyField;
            }
            set {
                this.singleQtyField = value;
                this.RaisePropertyChanged("SingleQty");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public decimal SingleWeight {
            get {
                return this.singleWeightField;
            }
            set {
                this.singleWeightField = value;
                this.RaisePropertyChanged("SingleWeight");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public decimal SingleVolume {
            get {
                return this.singleVolumeField;
            }
            set {
                this.singleVolumeField = value;
                this.RaisePropertyChanged("SingleVolume");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string Plant {
            get {
                return this.plantField;
            }
            set {
                this.plantField = value;
                this.RaisePropertyChanged("Plant");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string MatlGroup {
            get {
                return this.matlGroupField;
            }
            set {
                this.matlGroupField = value;
                this.RaisePropertyChanged("MatlGroup");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string CreateTime {
            get {
                return this.createTimeField;
            }
            set {
                this.createTimeField = value;
                this.RaisePropertyChanged("CreateTime");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public int BatchSplit {
            get {
                return this.batchSplitField;
            }
            set {
                this.batchSplitField = value;
                this.RaisePropertyChanged("BatchSplit");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("Status");
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
    [System.ServiceModel.MessageContractAttribute(WrapperName="Export", WrapperNamespace="http://Sonluk.com/API/LE/", IsWrapped=true)]
    public partial class ExportRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Sonluk.com/API/LE/", Order=0)]
        public Sonluk.UI.Model.LE.OutboundDeliveryService.DeliveryInfo[] nodes;
        
        public ExportRequest() {
        }
        
        public ExportRequest(Sonluk.UI.Model.LE.OutboundDeliveryService.DeliveryInfo[] nodes) {
            this.nodes = nodes;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExportResponse", WrapperNamespace="http://Sonluk.com/API/LE/", IsWrapped=true)]
    public partial class ExportResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Sonluk.com/API/LE/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] ExportResult;
        
        public ExportResponse() {
        }
        
        public ExportResponse(byte[] ExportResult) {
            this.ExportResult = ExportResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OutboundDeliverySoapChannel : Sonluk.UI.Model.LE.OutboundDeliveryService.OutboundDeliverySoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OutboundDeliverySoapClient : System.ServiceModel.ClientBase<Sonluk.UI.Model.LE.OutboundDeliveryService.OutboundDeliverySoap>, Sonluk.UI.Model.LE.OutboundDeliveryService.OutboundDeliverySoap {
        
        public OutboundDeliverySoapClient() {
        }
        
        public OutboundDeliverySoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OutboundDeliverySoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OutboundDeliverySoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OutboundDeliverySoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sonluk.UI.Model.LE.OutboundDeliveryService.DeliveryInfo[] Read(Sonluk.UI.Model.LE.OutboundDeliveryService.DeliveryInfo keyowrds) {
            return base.Channel.Read(keyowrds);
        }
        
        public Sonluk.UI.Model.LE.OutboundDeliveryService.DeliveryItemInfo[] ItemRead(string serialNumber) {
            return base.Channel.ItemRead(serialNumber);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.UI.Model.LE.OutboundDeliveryService.ExportResponse Sonluk.UI.Model.LE.OutboundDeliveryService.OutboundDeliverySoap.Export(Sonluk.UI.Model.LE.OutboundDeliveryService.ExportRequest request) {
            return base.Channel.Export(request);
        }
        
        public byte[] Export(Sonluk.UI.Model.LE.OutboundDeliveryService.DeliveryInfo[] nodes) {
            Sonluk.UI.Model.LE.OutboundDeliveryService.ExportRequest inValue = new Sonluk.UI.Model.LE.OutboundDeliveryService.ExportRequest();
            inValue.nodes = nodes;
            Sonluk.UI.Model.LE.OutboundDeliveryService.ExportResponse retVal = ((Sonluk.UI.Model.LE.OutboundDeliveryService.OutboundDeliverySoap)(this)).Export(inValue);
            return retVal.ExportResult;
        }
        
        public int UnLoad(int minSales, string deliveryNumberSet, string salesRange) {
            return base.Channel.UnLoad(minSales, deliveryNumberSet, salesRange);
        }
    }
}