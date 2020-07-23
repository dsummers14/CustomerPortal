using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerPortal
{
    public class salesOrderModel :global::Microsoft.NAV.salesOrder
    {
        public DateTime orderDateTime { get; set; }
        public DateTime requestedDeliveryDateTime { get; set; }
       
    }
}
 