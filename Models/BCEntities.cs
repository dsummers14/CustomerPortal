using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

public class BCEntities
{
    public class company
    {
        [JsonProperty("@odata.etag")]
        public string etag { get; set; }
        public string id { get; set; }
        public string systemVersion { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string businessProfileId { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class companies
    {
        public List<company> value { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string countryLetterCode { get; set; }
        public string postalCode { get; set; }
    }

    public class customer
    {
        [JsonProperty("@odata.etag")]
        public string etag { get; set; }
        public string id { get; set; }
        public string number { get; set; }
        public string displayName { get; set; }
        public string type { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public bool taxLiable { get; set; }
        public string taxAreaId { get; set; }
        public string taxAreaDisplayName { get; set; }
        public string taxRegistrationNumber { get; set; }
        public string currencyId { get; set; }
        public string currencyCode { get; set; }
        public string paymentTermsId { get; set; }
        public string shipmentMethodId { get; set; }
        public string paymentMethodId { get; set; }
        public string blocked { get; set; }
        public double balance { get; set; }
        public double overdueAmount { get; set; }
        public double totalSalesExcludingTax { get; set; }
        public string lastModifiedDateTime { get; set; }
        public address address { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class customers
    {
        public List<customer> value { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class item
    {
        [JsonProperty("@odata.etag")]
        public string etag { get; set; }
        public string id { get; set; }
        public string number { get; set; }
        public string displayName { get; set; }
        public string type { get; set; }
        public string itemCategoryId { get; set; }
        public string itemCategoryCode { get; set; }
        public bool blocked { get; set; }
        public string baseUnitOfMeasureId { get; set; }
        public string gtin { get; set; }
        public int inventory { get; set; }
        public double unitPrice { get; set; }
        public bool priceIncludesTax { get; set; }
        public double unitCost { get; set; }
        public string taxGroupId { get; set; }
        public string taxGroupCode { get; set; }
        public string lastModifiedDateTime { get; set; }
        public unitOfMeasure baseUnitOfMeasure { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class items
    {
        public List<item> value { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class PostalAddress
    {
        public string street { get; set; } = "";
        public string city { get; set; } = "";
        public string state { get; set; } = "";
        public string countryLetterCode { get; set; } = "";
        public string postalCode { get; set; } = "";
    }

    public class lineDetails
    {
        public string number { get; set; } = "";
        public string displayName { get; set; } = "";
    }

    public class unitOfMeasure
    {
        public string code { get; set; }
        public string displayName { get; set; }
        public object symbol { get; set; }
        public object unitConversion { get; set; }
    }

    public class salesOrderLine
    {
        [JsonProperty("@odata.etag")]
        public string etag { get; set; } = "";
        public string id { get; set; } = Guid.Empty.ToString();
        public string documentId { get; set; } = Guid.Empty.ToString();
        public int sequence { get; set; }
        public string itemId { get; set; } = Guid.Empty.ToString();
        public string accountId { get; set; } = Guid.Empty.ToString();
        public string lineType { get; set; } = "";
        public string description { get; set; } = "";
        public string unitOfMeasureId { get; set; } = Guid.Empty.ToString();
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public double discountAmount { get; set; }
        public int discountPercent { get; set; }
        public bool discountAppliedBeforeTax { get; set; }
        public double amountExcludingTax { get; set; }
        public string taxCode { get; set; } = "";
        public double taxPercent { get; set; }
        public double totalTaxAmount { get; set; }
        public double amountIncludingTax { get; set; }
        public int invoiceDiscountAllocation { get; set; }
        public double netAmount { get; set; }
        public double netTaxAmount { get; set; }
        public double netAmountIncludingTax { get; set; }
        public string shipmentDate { get; set; } = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        public int shippedQuantity { get; set; }
        public int invoicedQuantity { get; set; }
        public int invoiceQuantity { get; set; }
        public int shipQuantity { get; set; }
        public lineDetails lineDetails { get; set; } = new lineDetails();
        public unitOfMeasure unitOfMeasure { get; set; } = new unitOfMeasure();
        private bool IsNew { get; set; } = false;
        public ErrorResponse error { get; set; }

        public bool ShouldSerializeTag()
        {
            return !IsNew;
        }

        public bool ShouldSerializedocumentId()
        {
            return !IsNew;
        }

        public bool ShouldSerializeerror()
        {
            return !IsNew;
        }

        public salesOrderLine()
        {
        }

        public salesOrderLine(bool pNew)
        {
            this.IsNew = pNew;
        }
    }


    public class salesOrderLineUpdate
    {
        public string itemId { get; set; } = Guid.Empty.ToString();
        public string description { get; set; } = "";
        public string unitOfMeasureId { get; set; } = Guid.Empty.ToString();
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public lineDetails lineDetails { get; set; } = new lineDetails();
       
        public salesOrderLineUpdate()
        {
        }

        public salesOrderLineUpdate(CustomerPortal.salesOrderLineModel salesOrderLine)
        {
            this.itemId = salesOrderLine.itemId.ToString();
            this.lineDetails.number = salesOrderLine.itemNumber;
            this.description = salesOrderLine.itemDescription;
            this.lineDetails.displayName = salesOrderLine.itemDescription;
            this.quantity = (int)salesOrderLine.quantity;
            this.unitPrice = (double)salesOrderLine.unitPrice;

        }


    }


    public class salesOrder
    {
        [JsonProperty("@odata.etag")]
        public string etag { get; set; } = "";
        public Guid id { get; set; } = Guid.Empty;
        public string number { get; set; } = "";
        public string externalDocumentNumber { get; set; } = "";
        public string orderDate { get; set; } = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        public string customerId { get; set; } = Guid.Empty.ToString();
        public string contactId { get; set; } = Guid.Empty.ToString();
        public string customerNumber { get; set; } = "";
        public string customerName { get; set; } = "";
        public string shipToContact { get; set; } = "";
        public string shipToName { get; set; } = "";
        public string currencyId { get; set; } = Guid.Empty.ToString();
        public string currencyCode { get; set; } = "";
        public bool pricesIncludeTax { get; set; } = false;
        public string paymentTermsId { get; set; } = Guid.Empty.ToString();
        public string salesperson { get; set; } = "";
        public bool partialShipping { get; set; } = false;
        public string requestedDeliveryDate { get; set; } = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        public decimal discountAmount { get; set; } = 0;
        public bool discountAppliedBeforeTax { get; set; } = false;
        public double totalAmountExcludingTax { get; set; } = 0;
        public double totalTaxAmount { get; set; } = 0;
        public double totalAmountIncludingTax { get; set; } = 0;
        public bool fullyShipped { get; set; } = false;
        public string status { get; set; } = "";
        public string lastModifiedDateTime { get; set; } = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        public string phoneNumber { get; set; } = "";
        public string email { get; set; } = "";
        public PostalAddress billingPostalAddress { get; set; } = new PostalAddress();
        public PostalAddress sellingPostalAddress { get; set; } = new PostalAddress();
        public PostalAddress shippingPostalAddress { get; set; } = new PostalAddress();
        public List<salesOrderLine> salesOrderLines { get; set; } = new List<salesOrderLine>();
        private bool IsNew { get; set; } = false;
        public ErrorResponse error { get; set; }

        public bool ShouldSerializeeTag()
        {
            return !IsNew;
        }

        public bool ShouldSerializeId()
        {
            return !IsNew;
        }

        public bool ShouldSerializebillingPostalAddress()
        {
            return !IsNew;
        }

        public bool ShouldSerializestatus()
        {
            return !IsNew;
        }

        public bool ShouldSerializelastModifiedDateTime()
        {
            return !IsNew;
        }

        public bool ShouldSerializeerror()
        {
            return !IsNew;
        }

        public salesOrder()
        {
        }

        public salesOrder(bool pNew)
        {
            this.IsNew = pNew;
        }
    }

    public class salesOrderUpdate
    {
        public string externalDocumentNumber { get; set; } = "";
        public string orderDate { get; set; } = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        public string shipToContact { get; set; } = "";
        public string shipToName { get; set; } = "";
        public string salesperson { get; set; } = "";
        public bool partialShipping { get; set; } = false;
        public string requestedDeliveryDate { get; set; } = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        public decimal discountAmount { get; set; } = 0;
        public string phoneNumber { get; set; } = "";
        public string email { get; set; } = "";
        public Microsoft.NAV.postalAddressType shippingPostalAddress { get; set; } = new Microsoft.NAV.postalAddressType();
        public List<salesOrderLine> salesOrderLines { get; set; } = new List<salesOrderLine>();
        private bool IsNew { get; set; } = false;

        [JsonIgnore]
        public ErrorResponse error { get; set; }
      
    }
    public class salesOrders
    {
        public List<salesOrder> value { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class salesOrderLines
    {
        public List<salesOrderLine> value { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class subscription
    {
        [JsonProperty("@odata.etag")]
        public string etag { get; set; }
        public string subscriptionId { get; set; }
        public string notificationUrl { get; set; }
        public string resource { get; set; }
        public string userId { get; set; }
        public string lastModifiedDateTime { get; set; }
        public string clientState { get; set; }
        public string expirationDateTime { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class subscriptions
    {
        public List<subscription> value { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class ErrorResponse
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}
