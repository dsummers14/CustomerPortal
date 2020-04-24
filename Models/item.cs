using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.NAV
{
    public partial class item : global::Microsoft.OData.Client.BaseEntityType
    {
        public DateTime lastDateTimeModified
        {
        get
            {
              return DateTime.Parse(lastModifiedDateTime.ToString());
            }
        }
      
    }
}