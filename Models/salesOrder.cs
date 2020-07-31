using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.NAV
{
    public partial class salesOrder : global::Microsoft.OData.Client.BaseEntityType
    {
        public string orderDateString
        {
        get
            {
              return ODataWebService.EdmDateToDateTime(orderDate).ToShortDateString();
            }
        }
        public string requestedDeliveryDateString
        {
            get
            {
                return ODataWebService.EdmDateToDateTime(requestedDeliveryDate).ToShortDateString();
            }
        }
        public string postingDateString
        {
            get
            {
                return ODataWebService.EdmDateToDateTime(postingDate).ToShortDateString();
            }
        }

    }
}