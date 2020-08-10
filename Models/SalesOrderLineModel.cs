using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal
{
    public class salesOrderLineModel
    {

        public string id { get; set; } = Guid.Empty.ToString();

        public string documentId { get; set; } = Guid.Empty.ToString();
        public string itemId { get; set; } = Guid.Empty.ToString();
        public string lineType { get; set; } = "";
        public string itemNumber { get; set; } = "";

        public string description { get; set; } = "";
        public string unitOfMeasureId { get; set; } = Guid.Empty.ToString();
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public double discountAmount { get; set; }
        public int discountPercent { get; set; }

        public decimal amountIncludingTax { get; set; }

        public decimal amountExcludingTax { get; set; }

        public salesOrderLineModel()
        {

        }

        public salesOrderLineModel(Microsoft.NAV.salesOrderLine salesOrderLine)
        {
            this.documentId = salesOrderLine.documentId.ToString();
            this.id = salesOrderLine.id;
            this.itemId = salesOrderLine.itemId.ToString();
            this.itemNumber = salesOrderLine.lineDetails.number;
            this.description = salesOrderLine.description;
            this.discountAmount = (double)salesOrderLine.discountAmount;
            this.discountPercent = (int)salesOrderLine.discountPercent;
            this.quantity = (int)salesOrderLine.quantity;
            this.unitPrice = (double)salesOrderLine.unitPrice;
            this.amountIncludingTax = (decimal)salesOrderLine.amountIncludingTax;
            this.amountExcludingTax = (decimal)salesOrderLine.amountExcludingTax;
        }

        public salesOrderLineModel(BCEntities.salesOrderLine salesOrderLine)
        {
            this.documentId = salesOrderLine.documentId.ToString();
            this.id = salesOrderLine.id;
            this.itemId = salesOrderLine.itemId.ToString();
            this.itemNumber = salesOrderLine.lineDetails.number;
            this.description = salesOrderLine.description;
            this.discountAmount = (double)salesOrderLine.discountAmount;
            this.discountPercent = (int)salesOrderLine.discountPercent;
            this.quantity = (int)salesOrderLine.quantity;
            this.unitPrice = (double)salesOrderLine.unitPrice;
            this.amountIncludingTax = (decimal)salesOrderLine.amountIncludingTax;
            this.amountExcludingTax = (decimal)salesOrderLine.amountExcludingTax;
        }

    }
}