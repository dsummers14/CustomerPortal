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

namespace WebApplication1.Controllers
{
    public  class UsersController : ODataController {


        public async Task<IGraphServiceUsersCollectionPage> GetUsers(ODataQueryOptions queryOptions)
        {
            IGraphServiceUsersCollectionPage requestTask = null;
            string filter = queryOptions.Filter == null ? "" : queryOptions.Filter.RawValue;
            string customerIdAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("CustomerNumber");
            string webRoleAttributeName = B2cCustomAttributeHelper.GetCompleteAttributeName("WebRole");

            try
            {
                var graphClient = GraphClient.CreateGraphClient();
                
                requestTask = await graphClient.Users
                .Request()
                .Filter(filter)
                .Select($"id,displayName,identities,{customerIdAttributeName},{webRoleAttributeName}")
                .GetAsync();

            }
            catch (Exception ex)
            {
                // return ex;
            }
            
            return requestTask;
        }
         

        }

     }


           // var Customers = from Cust in iWebService.customers where Cust.number == "10000" select Cust;