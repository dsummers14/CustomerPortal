using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
//using Microsoft.OData.Edm;


namespace Microsoft.NAV
{

    [MetadataType(typeof(salesInvoice.salesInvoiceMetadata))]
    public partial class salesInvoice : global::Microsoft.OData.Client.BaseEntityType
    {

        public string invoiceDateString
        {
            get
            {
                return ODataWebService.EdmDateToDateTime(invoiceDate).ToShortDateString();
            }
        }
        public string dueDateString
        {
            get
            {
                return ODataWebService.EdmDateToDateTime(dueDate).ToShortDateString();
            }
        }
        public string postingDateString
        {
            get
            {
                return ODataWebService.EdmDateToDateTime(postingDate).ToShortDateString();
            }
        }



        public class salesInvoiceMetadata
        {
            
            public Microsoft.OData.Edm.Date invoiceDate { get; set; }
        }
    }
}