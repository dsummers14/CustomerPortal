﻿using System;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            var newUser = new b2c_ms_graph.UserModel();
            newUser.extension_39d2bd21d67b480891ffa985c6eb1398_TenantId = ODataWebService.TenantId();
            newUser.extension_39d2bd21d67b480891ffa985c6eb1398_CompanyId = ODataWebService.CompanyId();
            newUser.extension_39d2bd21d67b480891ffa985c6eb1398_WebRole = int.Parse(ODataWebService.WebRole()) + 1;
            newUser.DisplayAccountEnabled = true;
            
            return View(newUser);
        }

        [HttpPost()]
        public async  Task<ActionResult> CreateUser(b2c_ms_graph.UserModel userModel, FormCollection formCollection)
        {
            User newUser = new User();

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(userModel.newPassword))
                {
                    if (userModel.newPassword == userModel.confirmPassword)
                    {
                        try
                        {
                            IDictionary<string, object> extensionInstance = new Dictionary<string, object>();
                            extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("WebRole"), userModel.extension_39d2bd21d67b480891ffa985c6eb1398_WebRole);
                            extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("TenantId"), ODataWebService.TenantId());
                            extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("CompanyId"), userModel.extension_39d2bd21d67b480891ffa985c6eb1398_CompanyId);
                            extensionInstance.Add(B2cCustomAttributeHelper.GetCompleteAttributeName("CustomerNumber"),  userModel.extension_39d2bd21d67b480891ffa985c6eb1398_CustomerNumber);
                            newUser.AdditionalData = extensionInstance;

                            newUser.DisplayName = userModel.DisplayName;
                            newUser.AccountEnabled = userModel.DisplayAccountEnabled;
                            newUser.PasswordProfile = new PasswordProfile { Password = userModel.newPassword,
                                                                           ForceChangePasswordNextSignIn = userModel.forcePasswordChange};
                            newUser.PasswordPolicies = "DisablePasswordExpiration";
                            newUser.Identities = new List<ObjectIdentity> {
                                new ObjectIdentity
                                {
                                    SignInType = "emailAddress",
                                    Issuer = "ICPCustomerPortal1.onmicrosoft.com",
                                    IssuerAssignedId = userModel.DisplayEmailName
                                }};
                       
                            GraphServiceClient graphClient = GraphClient.CreateGraphClient();
                             
                            await graphClient.Users
                               .Request()
                               .AddAsync(newUser);

                            RedirectToAction("Index", "User");                        
                        }
                        catch
                        {
                            Exception ex;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "New Password and confirm password do not match.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "New Password is required.");
                }
                
            }

            
            
            //if there was an error
            return View(userModel);
        }

        public async Task<ActionResult> DeleteUser(DataSourceRequest request, string Id)
        {
          //  List<b2c_ms_graph.UserModel> iResult = new List<b2c_ms_graph.UserModel>() { userModel };
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
                    }
                    catch (Exception ex)
                    {
                        iModelState.AddModelError("DeleteError", ex.Message);
                    }
                }
            }
            else
                iModelState = ModelState;

            return View(iModelState);
        }


    }
}