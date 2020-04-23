using Kendo.Mvc.UI.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.NAV
{
    public partial class salesQuote : global::Microsoft.OData.Client.BaseEntityType
    {
        public string orderDateString
        {
        get
            {
              return ODataWebService.EdmDateToDateTime(documentDate).ToShortDateString();
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