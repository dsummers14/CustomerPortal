using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace CustomerPortal
{
    public class salesOrderModel :global::Microsoft.NAV.salesOrder
    {
        [JsonIgnore]
        public DateTime orderDateTime { get; set; }
        [JsonIgnore]
        public DateTime requestedDeliveryDateTime { get; set; }
       
    }
}
 