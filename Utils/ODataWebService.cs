using System;
using CustomerPortal.Properties;
using Microsoft.NAV;
using System.Security.Claims;
using System.Linq;
using CustomerPortal; 

public static class ODataWebService
{
    public static string CompanyId = ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_CompanyId").Select(s => s.Value).FirstOrDefault();
    private static iCeptsWebServicesEntities dbContext = new iCeptsWebServicesEntities();
    public static string TenantId = ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_TenantId").Select(s => s.Value).FirstOrDefault();
    public static string WebRole = ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_WebRole").Select(s => s.Value).FirstOrDefault();
    private static BC365Tenant TenantContext = dbContext.BC365Tenant.Where(t => t.TenantId == TenantId).FirstOrDefault();

    public static string BuildODataUrl(bool pByCompany = true)
    {
        string iUrl = "";

        if (pByCompany)
        {
          
            iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + TenantId + "/" + TenantContext.Environment + "/" + TenantContext.APIVersion + string.Format("/companies({0})/", CompanyId);
        }
        else
            iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + TenantId + "/" + TenantContext.Environment+ "/" + TenantContext.APIVersion;

        return iUrl;
    }

    public static string BuildODataUrl(string CompanyId)
    {
        string iUrl = "";
       
            iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + TenantId + "/" + TenantContext.Environment + "/" + TenantContext.APIVersion + string.Format("/companies({0})/", CompanyId);
        
        return iUrl;
    }


    public static DateTime EdmDateToDateTime(Microsoft.OData.Edm.Date? pEdmDate)
    {
            return DateTime.Parse(pEdmDate.ToString());
    }

    public static System.Net.ICredentials CreateCredentials(string pWSUrl)
    {
        System.Net.NetworkCredential iCredential = new System.Net.NetworkCredential(TenantContext.UserName, TenantContext.Password);
        System.Net.ICredentials iCredentials = iCredential.GetCredential(new Uri(pWSUrl), "Basic");

        return iCredentials;
    }
}
