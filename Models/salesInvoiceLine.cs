using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.NAV
{
    public partial class salesInvoiceLine : global::Microsoft.OData.Client.BaseEntityType
    {
        public string shipmentDateString
        {
        get
            {
              return ODataWebService.EdmDateToDateTime(shipmentDate).ToShortDateString();
            }
        }
      
    }
}