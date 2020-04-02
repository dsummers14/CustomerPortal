using System;
using CustomerPortal.Properties;
using Microsoft.NAV;

public static class ODataWebService
{

    private static string vCompanyID = Settings.Default.CompanyId;
    public static string BuildODataUrl( bool pByCompany = true)
    {
        string iUrl = "";

        if (pByCompany)
        {
            if (string.IsNullOrEmpty(vCompanyID))
            {
                company iCompany = null;
              // iCompany = GetEntityCollection<companies>(string.Format("$filter=name eq '{0}'", Settings.Default.CompanyName), false).value.FirstOrDefault();

                if (iCompany != null)
                    vCompanyID = iCompany.id.ToString();
            }

            iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + Settings.Default.TenantId + "/" + Settings.Default.Environment + "/" + Settings.Default.apiVersion + string.Format("/companies({0})/", vCompanyID);
        }
        else
            iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + Settings.Default.TenantId + "/" + Settings.Default.Environment + "/" + Settings.Default.apiVersion;

        return iUrl;
    }

   public static DateTime EdmDateToDateTime(Microsoft.OData.Edm.Date? pEdmDate)
    {
    

        return DateTime.Parse(pEdmDate.ToString());
    }

    public static System.Net.ICredentials CreateCredentials(string pWSUrl)
    {
        System.Net.NetworkCredential iCredential = new System.Net.NetworkCredential(Settings.Default.Username, Settings.Default.Password);
        System.Net.ICredentials iCredentials = iCredential.GetCredential(new Uri(pWSUrl), "Basic");

        return iCredentials;
    }
}

 //<package id = "Antlr" version="3.5.0.2" targetFramework="net472" />
 // <package id = "bootstrap" version="3.4.1" targetFramework="net472" />
 // <package id = "jQuery" version="3.4.1" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.Mvc" version="5.2.7" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.OData" version="7.3.0" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.Razor" version="3.2.7" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.Web.Optimization" version="1.1.3" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.WebApi" version="5.2.7" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.WebApi.Client" version="5.2.7" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.WebApi.Core" version="5.2.7" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.WebApi.HelpPage" version="5.2.7" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.WebApi.OData" version="5.7.0" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.WebApi.OData.fr" version="5.7.0" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.WebApi.WebHost" version="5.2.7" targetFramework="net472" />
 // <package id = "Microsoft.AspNet.WebPages" version="3.2.7" targetFramework="net472" />
 // <package id = "Microsoft.CodeDom.Providers.DotNetCompilerPlatform" version="2.0.1" targetFramework="net472" />
 // <package id = "Microsoft.Data.Edm" version="5.6.0" targetFramework="net472" />
 // <package id = "Microsoft.Data.OData" version="5.6.0" targetFramework="net472" />
 // <package id = "Microsoft.Extensions.DependencyInjection" version="1.0.0" targetFramework="net472" />
 // <package id = "Microsoft.Extensions.DependencyInjection.Abstractions" version="1.0.0" targetFramework="net472" />
 // <package id = "Microsoft.OData.Client" version="7.6.3" targetFramework="net472" />
 // <package id = "Microsoft.OData.Core" version="7.6.3" targetFramework="net472" />
 // <package id = "Microsoft.OData.Edm" version="7.6.3" targetFramework="net472" />
 // <package id = "Microsoft.Spatial" version="7.6.3" targetFramework="net472" />
 // <package id = "Microsoft.Web.Infrastructure" version="1.0.0.0" targetFramework="net472" />
 // <package id = "Modernizr" version="2.8.3" targetFramework="net472" />
 // <package id = "Newtonsoft.Json" version="12.0.2" targetFramework="net472" />
 // <package id = "System.Collections" version="4.0.11" targetFramework="net472" />
 // <package id = "System.Collections.Concurrent" version="4.0.12" targetFramework="net472" />
 // <package id = "System.ComponentModel" version="4.0.1" targetFramework="net472" />
 // <package id = "System.Diagnostics.Debug" version="4.0.11" targetFramework="net472" />
 // <package id = "System.Globalization" version="4.0.11" targetFramework="net472" />
 // <package id = "System.Linq" version="4.1.0" targetFramework="net472" />
 // <package id = "System.Linq.Expressions" version="4.1.0" targetFramework="net472" />
 // <package id = "System.Reflection" version="4.1.0" targetFramework="net472" />
 // <package id = "System.Resources.ResourceManager" version="4.0.1" targetFramework="net472" />
 // <package id = "System.Runtime.Extensions" version="4.1.0" targetFramework="net472" />
 // <package id = "System.Spatial" version="5.6.0" targetFramework="net472" />
 // <package id = "System.Threading" version="4.0.11" targetFramework="net472" />
 // <package id = "System.Threading.Tasks" version="4.0.11" targetFramework="net472" />
 // <package id = "WebGrease" version="1.6.0" targetFramework="net472" />