using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using System.Linq;
using Microsoft.OData.Edm;
using b2c_ms_graph;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Kendo.Mvc.Extensions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Resources;
using CustomerPortal.Properties;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public  class UsersController : ODataController 
    {

      GraphServiceClient graphClient = GraphClient.CreateGraphClient();
      string customerNumberAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("CustomerNumber");
      string webRoleAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("WebRole");
      string TenantIdAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("TenantId");
      string CompanyIdAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("CompanyId");


        public async Task<IGraphServiceUsersCollectionPage> GetUsers(ODataQueryOptions queryOptions)
        {
            IGraphServiceUsersCollectionPage requestTask = null;
            string filter = queryOptions.Filter == null ? "" : queryOptions.Filter.RawValue;
          
            try
            {
                requestTask = await graphClient.Users
                                               .Request()
                                               .Filter(filter)
                                               .Select($"id,displayName,identities,{customerNumberAttributeName},{webRoleAttributeName},{ TenantIdAttributeName},{ CompanyIdAttributeName}")
                                               .GetAsync();

            }
            catch (Exception ex)
            {
                // return ex;
            }
            
            return requestTask;
        }

        public async Task<User> GetUser(string userId)
        {
            User UserTask = null;

            try
            {
               UserTask = await graphClient.Users[userId]
                                           .Request()
                                           .Select($"id,displayName,identities,{customerNumberAttributeName},{webRoleAttributeName},{ TenantIdAttributeName},{ CompanyIdAttributeName}")
                                           .GetAsync();
            }
            catch (Exception ex)
            {
                //return ex
            }

            return UserTask;
        }

        public async Task<User> PostUser([FromBody] User user)
        {
            User UserTask = null;
          
            try
            {

                var newUser = new User
                {
                    AccountEnabled = true,
                    DisplayName = user.DisplayName,
                    MailNickname = user.MailNickname,
                    UserPrincipalName = user.UserPrincipalName,
                    AdditionalData = user.AdditionalData,
                    PasswordProfile = new PasswordProfile
                    {
                        ForceChangePasswordNextSignIn = true,
                        Password = user.PasswordProfile.Password
                    }
                };


                UserTask = await graphClient.Users
                                            .Request()
                                            .AddAsync(newUser);
            }
            catch (Exception ex)
            {
                //return ex
            }

            return UserTask;
        }
        public async Task<User> PutUser([FromBody] User user)
        {
            var newUser = new User();
            User UserTask = null;

            try
            {

               newUser.AdditionalData = user.AdditionalData;
                newUser.DisplayName = user.DisplayName;

                UserTask = await graphClient.Users[user.Id]
                                            .Request()
                                            .UpdateAsync(newUser);
            }
            catch (Exception ex)
            {
                //return ex
            }

            return UserTask;
        }

        public async void DeleteUser([FromODataUri] string  userId)
        {
            try
            {
                await graphClient.Users[userId]
                                 .Request()
                                 .DeleteAsync();
            }
            catch (Exception ex)
            {
                //return ex
            }
        }

      
    }
}
     

