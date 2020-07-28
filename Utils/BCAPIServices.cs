using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CustomerPortal.Properties;

public static class BCAPIServices
{
   // private static string vCompanyID;

    public static TEntity GetEntityById<TEntity>(string pEntityId, string pODataParms = "", bool pByCompany = true)
    {
        TEntity iEntity = default(TEntity);
        var iURl = ODataWebService.BuildODataUrl(pByCompany) + string.Format("{0}s({1})", typeof(TEntity).Name, pEntityId); 

        iEntity = SendRequest<TEntity>(iURl, "GET");

        return iEntity;
    }

    public static TEntityCollection GetEntityCollection<TEntityCollection>(string pODataParms = "", bool pByCompany = true)
    {
        TEntityCollection iEntityCollection = default(TEntityCollection);
        var iURl = ODataWebService.BuildODataUrl(pByCompany) + typeof(TEntityCollection).Name;

        iEntityCollection = SendRequest<TEntityCollection>(iURl, "GET");

        return iEntityCollection;
    }

    public static TEntity CreateEntity<TEntity>(TEntity pDataFields, string pODataParms = "", bool pByCompany = true)
    {
        TEntity iEntity = default(TEntity);
        var iURl = ODataWebService.BuildODataUrl(pByCompany) + typeof(TEntity).Name + "s";

        iEntity = SendRequest<TEntity, TEntity>(iURl, "POST", pDataFields);

        return iEntity; 
    }

    public static TEntity UpdateEntity<TEntity,TData>(string pEntityId, TData pModifiedFields, string pEtag, string pODataParms = "", bool pByCompany = true)
    {
        TEntity iEntity = default(TEntity);
        var iURl = ODataWebService.BuildODataUrl(pByCompany) + string.Format("{0}s({1})", typeof(TEntity).Name, pEntityId);

        iEntity = SendRequest<TData, TEntity>(iURl, "PATCH", pModifiedFields, pEtag);

        return iEntity;
    }

    public static TResult DeleteEntity<TEntity, TResult>(string pEntityId, string pEtag, bool pByCompany = true)
    {
        var iEntityUrl = typeof(TEntity).Name + "s";
        var iURl = ODataWebService.BuildODataUrl(pByCompany);

        var iResult = SendRequest<TResult>(iURl, "DELETE", pEtag);

        return iResult;
    }

    // Could not figure this out
    // Public Function GetSingleEntity(Of tEntity, TEntityCollection)(Optional ByVal pODataParms As String = "", Optional ByVal pByCompany As Boolean = True) As tEntity
    // Dim iEntityCollection = GetEntityCollection(Of TEntityCollection)(pODataParms, pByCompany)
    // ' Dim iEntity As tEntity = Nothing

    // If iEntityCollection IsNot Nothing Then
    // Dim iEntity = iEntityCollection.value(0)

    // End If

    // Return iEntity
    // End Function

    //public static string BuildODataUrl(string pCommand, bool pByCompany = true)
    //{
    //    string iUrl = "";

    //    if (pByCompany)
    //    {
    //        if (string.IsNullOrEmpty(vCompanyID))
    //        {
    //            var iCompany = GetEntityCollection<BCEntities.companies>(string.Format("$filter=name eq '{0}'", Settings.Default.CompanyName), false).value.FirstOrDefault();

    //            if (iCompany != null)
    //                vCompanyID = iCompany.id;
    //        }

    //        iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + Settings.Default.TenantId + "/" + Settings.Default.Environment + "/" + Settings.Default.apiVersion + string.Format("/companies({0})/", vCompanyID) + pCommand;
    //    }
    //    else
    //        iUrl = Settings.Default.Transport + Settings.Default.Host + "/V2.0/" + Settings.Default.TenantId + "/" + Settings.Default.Environment + "/" + Settings.Default.apiVersion + "/" + pCommand;

    //    return iUrl;
    //}

    public static TEntity SendRequest<TRequest, TEntity>(string pURL, string pMethod, TRequest pData, string pEtag = "")
    {
        HttpWebRequest iHttpRequest;
        Stream iStream = null;
        TEntity iResult;
        JsonSerializer iJsonSerializer = new JsonSerializer();
        string iJsonData = "";
        byte[] iBytes;

        iHttpRequest = (HttpWebRequest)HttpWebRequest.Create(pURL);
        iHttpRequest.Host = Settings.Default.Host;
        iHttpRequest.ContentType = "application/json";
        iHttpRequest.Accept = "*/*";
        iHttpRequest.Method = pMethod;
        iHttpRequest.Timeout = 900000;

        var iTenantContext = ODataWebService.TenantContext();
        iHttpRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(iTenantContext.UserName + ":" + iTenantContext.Password)));

        if (!string.IsNullOrEmpty(pEtag))
            iHttpRequest.Headers.Add("If-Match", pEtag);

        try
        {
            iStream = iHttpRequest.GetRequestStream();
            iJsonData = JsonConvert.SerializeObject(pData, Formatting.None);
            iBytes = ASCIIEncoding.ASCII.GetBytes(iJsonData);

            iStream.Write(iBytes, 0, iBytes.Length);
            iStream.Close();

            iStream = iHttpRequest.GetResponse().GetResponseStream();
            iResult = iJsonSerializer.Deserialize<TEntity>(new JsonTextReader(new StreamReader(iStream)));
        }
        catch (WebException ex)
        {
            iStream = ex.Response.GetResponseStream();
            iResult = iJsonSerializer.Deserialize<TEntity>(new JsonTextReader(new StreamReader(iStream)));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (iStream != null)
                iStream.Close();
        }

        return iResult;
    }

    public static TEntity SendRequest<TEntity>(string pURL, string pMethod, string pEtag = "")
    {
        HttpWebRequest iHttpRequest;
        Stream iStream = null;
        TEntity iResult;
        JsonSerializer iJsonSerializer = new JsonSerializer();

        iHttpRequest = (HttpWebRequest)HttpWebRequest.Create(pURL);
        iHttpRequest.Host = Settings.Default.Host;
        iHttpRequest.Accept = "*/*";
        iHttpRequest.ContentLength = 0; 
        iHttpRequest.Method = pMethod;
        iHttpRequest.Timeout = 900000;

        var iTenantContext = ODataWebService.TenantContext();
        iHttpRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(iTenantContext.UserName + ":" + iTenantContext.Password)));

        if (!string.IsNullOrEmpty(pEtag))
            iHttpRequest.Headers.Add("If-Match", pEtag);

        try
        {
            iStream = iHttpRequest.GetResponse().GetResponseStream();
            iResult = iJsonSerializer.Deserialize<TEntity>(new JsonTextReader(new StreamReader(iStream)));
        }
        catch (WebException ex)
        {
            iStream = ex.Response.GetResponseStream();
            iResult = iJsonSerializer.Deserialize<TEntity>(new JsonTextReader(new StreamReader(iStream)));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (iStream != null)
                iStream.Close();
        }

        return iResult;
    }
}

// Public Function CreateEntity(Of TEntity)(ByVal pDataFields As Dictionary(Of String, String), Optional ByVal pByCompany As Boolean = True) As TEntity
// Dim iEntity As TEntity = Nothing
// Dim iEntityUrl = GetType(TEntity).Name + "s"
// Dim iURl = BuildODataUrl(String.Format("{0}", iEntityUrl), pByCompany)

// iEntity = SendRequest(Of Dictionary(Of String, String), TEntity)(iURl, "POST", pDataFields)

// Return iEntity
// End Function
