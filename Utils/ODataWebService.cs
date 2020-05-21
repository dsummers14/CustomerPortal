using System;
using CustomerPortal.Properties;
using Microsoft.NAV;
using System.Security.Claims;
using System.Linq;
using CustomerPortal; 

public static class ODataWebService
{
  

    public static string BuildODataUrl(bool pByCompany = true)
    {
        string iUrl = "";
        BC365Tenant iTenantContext = TenantContext();
        
        if (pByCompany)
        {
          
            iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + TenantId() + "/" + iTenantContext.Environment + "/" + 
                   iTenantContext.APIVersion + string.Format("/companies({0})/", CompanyId());
        }
        else
            iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + TenantId() + "/" + iTenantContext.Environment + "/" + 
                       iTenantContext.APIVersion;

        return iUrl;
    }

    public static string BuildODataUrl(string CompanyId)
    {
        string iUrl = "";
        BC365Tenant iTenantContext = TenantContext();

        iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + TenantId() + "/" + iTenantContext.Environment + "/" + 
            iTenantContext.APIVersion + string.Format("/companies({0})/", CompanyId);
        
        return iUrl;
    }

    public static string TenantId()
    {
        return ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_TenantId").Select(s => s.Value).FirstOrDefault();
    }

    public static BC365Tenant TenantContext()
    {
        CustomerPortal.CutomerPortalEntities dbContext = new CutomerPortalEntities();
        var iTenantId = TenantId();
       
        return dbContext.BC365Tenant.Where(t => t.TenantId == iTenantId).FirstOrDefault();
    }

    public static string CompanyId()
    {
        return ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_CompanyId").Select(s => s.Value).FirstOrDefault();
    }

    public static string WebRole()
    {
        return ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_WebRole").Select(s => s.Value).FirstOrDefault();
    }

    public static DateTime EdmDateToDateTime(Microsoft.OData.Edm.Date? pEdmDate)
    {
        return DateTime.Parse(pEdmDate.ToString());
    }

    public static System.Net.ICredentials CreateCredentials(string pWSUrl)
    {
        var iTenantContext = TenantContext();

        System.Net.NetworkCredential iCredential = new System.Net.NetworkCredential(iTenantContext.UserName, iTenantContext.Password);
        System.Net.ICredentials iCredentials = iCredential.GetCredential(new Uri(pWSUrl), "Basic");

        return iCredentials;
    }
}
