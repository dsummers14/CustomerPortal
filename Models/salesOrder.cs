using System;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.NAV
{
    [MetadataType(typeof(salesOrder.salesOrderMetadata))]
    public partial class salesOrder : global::Microsoft.OData.Client.BaseEntityType
    {
        public DateTime orderDateTime { get; set; }    
        public DateTime requestedDeliveryDateTime { get; set; }
        public DateTime postingDateTime { get; set; }
        
        public class salesOrderMetadata
        {
            [UIHint("CustomerLookup")]
            public string customerNumber { get; set; }

        }
    } 
}
 