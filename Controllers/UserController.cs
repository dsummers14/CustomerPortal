using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.NAV;
using Microsoft.Graph;
using b2c_ms_graph;
using System.Threading.Tasks;
using CustomerPortal.Properties;

namespace CustomerPortal.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        string customerNumberAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("CustomerNumber");
        string webRoleAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("WebRole");
        string TenantIdAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("TenantId");
        string CompanyIdAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("CompanyId");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {

            return View(newUser());
        }

        public UserModel newUser()
        {
            var newUser = new b2c_ms_graph.UserModel();
            newUser.extension_39d2bd21d67b480891ffa985c6eb1398_TenantId = ODataWebService.TenantId();
            newUser.extension_39d2bd21d67b480891ffa985c6eb1398_CompanyId = ODataWebService.CompanyId();
            newUser.extension_39d2bd21d67b480891ffa985c6eb1398_WebRole = int.Parse(ODataWebService.WebRole()) + 1;
            newUser.forcePasswordChange = false;
            newUser.DisplayAccountEnabled = true;

            return newUser;
        }


        [HttpPost()]
        public async Task<ActionResult> CreateUser(b2c_ms_graph.UserModel userModel, FormCollection formCollection)
        {
            if (string.IsNullOrEmpty(userModel.newPassword))
                ModelState.AddModelError("", "New Password is required.");

            if (userModel.newPassword != userModel.confirmPassword)
                ModelState.AddModelError("", "New Password and confirm password do not match.");

            if (ModelState.IsValid)
            {
                try
                {
                    User newUser = new User();
                    IDictionary<string, object> extensionInstance = new Dictionary<string, object>();
                    extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("WebRole"), int.Parse(ODataWebService.WebRole()) + 1);
                    extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("TenantId"), ODataWebService.TenantId());
                    extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("CompanyId"), userModel.extension_39d2bd21d67b480891ffa985c6eb1398_CompanyId);
                    extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("CustomerNumber"), userModel.extension_39d2bd21d67b480891ffa985c6eb1398_CustomerNumber);
                    newUser.AdditionalData = extensionInstance;

                    newUser.DisplayName = userModel.DisplayName;
                    newUser.AccountEnabled = userModel.DisplayAccountEnabled;
                    newUser.PasswordProfile = new PasswordProfile
                    {
                        Password = userModel.newPassword,
                        ForceChangePasswordNextSignIn = userModel.forcePasswordChange
                    };

                    newUser.PasswordPolicies = "DisablePasswordExpiration";
                    newUser.Identities = new List<ObjectIdentity>
               {
                 new ObjectIdentity
                 {
                   SignInType = "emailAddress",
                   Issuer = "ICPCustomerPortal1.onmicrosoft.com",
                   IssuerAssignedId = userModel.DisplayEmailName
                 }
               };

                    GraphServiceClient graphClient = GraphClient.CreateGraphClient();

                    await graphClient.Users
                                     .Request()
                                     .AddAsync(newUser);

                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                };
            }

            return View(userModel);
        }



        public async Task<ActionResult> DeleteUser(DataSourceRequest request, string Id)
        {
            ModelStateDictionary iModelState = new ModelStateDictionary();

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    try
                    {
                        GraphServiceClient graphClient = GraphClient.CreateGraphClient();

                        await graphClient.Users[Id]
                         .Request()
                         .DeleteAsync();

                        return View("Index");
                    }
                    catch (Exception ex)
                    {
                        iModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }
            else
                iModelState = ModelState;

            return View(iModelState);
        }


        public async Task<ActionResult> UpdateUser(DataSourceRequest request, string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                try
                {
                    GraphServiceClient graphClient = GraphClient.CreateGraphClient();

                    var user = await graphClient.Users[Id]
                                                .Request()
                                                .Select($"id,displayName,identities,{customerNumberAttributeName},{webRoleAttributeName},{ TenantIdAttributeName},{ CompanyIdAttributeName}")
                                                .GetAsync();

                    var updateUser = new b2c_ms_graph.UserModel();
                    updateUser.Id = user.Id;
                    updateUser.extension_39d2bd21d67b480891ffa985c6eb1398_TenantId = GetAdditionalData(user,TenantIdAttributeName);
                    updateUser.extension_39d2bd21d67b480891ffa985c6eb1398_CompanyId = GetAdditionalData(user, CompanyIdAttributeName);
                    updateUser.extension_39d2bd21d67b480891ffa985c6eb1398_WebRole = int.Parse(GetAdditionalData(user, webRoleAttributeName));
                    updateUser.extension_39d2bd21d67b480891ffa985c6eb1398_CustomerNumber = GetAdditionalData(user, customerNumberAttributeName);
                    //updateUser.newPassword = user.PasswordProfile.Password;
                    //updateUser.confirmPassword = user.PasswordProfile.Password;
                    updateUser.DisplayAccountEnabled = true;
                    updateUser.DisplayEmailName = user.Identities.Where(i => i.SignInType == "emailAddress").Select(s => s.IssuerAssignedId).FirstOrDefault();
                    updateUser.DisplayName = user.DisplayName;

                    return View(updateUser);
                }
                catch (Exception ex)
                {
                }
            }

            return RedirectToAction("Index");
        }

        public string GetAdditionalData(User user, string attributeName)
        {
            string value = "";

            if (user.AdditionalData.ContainsKey(attributeName))
                value = user.AdditionalData[attributeName].ToString();

            return value; 
        }

        [HttpPost()]
        public async Task<ActionResult> UpdateUser(b2c_ms_graph.UserModel userModel, FormCollection formCollection)
        {

            if (userModel.newPassword != userModel.confirmPassword)
                ModelState.AddModelError("confirmPassword", "New Password and confirm password do not match.");

            if (ModelState.IsValid)
            {
                try
                {
                    GraphServiceClient graphClient = GraphClient.CreateGraphClient();
                    User updateUser = new User();
                    IDictionary<string, object> extensionInstance = new Dictionary<string, object>();
                    extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("CompanyId"), userModel.extension_39d2bd21d67b480891ffa985c6eb1398_CompanyId);
                    extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("CustomerNumber"), userModel.extension_39d2bd21d67b480891ffa985c6eb1398_CustomerNumber);
                    updateUser.AdditionalData = extensionInstance;

                    updateUser.DisplayName = userModel.DisplayName;
                    updateUser.AccountEnabled = userModel.DisplayAccountEnabled;

                    await graphClient.Users[userModel.Id]
                                     .Request()
                                     .UpdateAsync(updateUser);

                    return RedirectToAction("Index");
               }

                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                };
            }

            return View(userModel);
        }

    }
}