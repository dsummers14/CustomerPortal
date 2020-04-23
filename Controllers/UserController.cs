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

namespace WebApplication1.Controllers
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
            
            return View(newUser);
        }

        [HttpPost()]
        public async  Task<ActionResult> CreateUser(b2c_ms_graph.UserModel userModel, FormCollection formCollection)
        {
            var iModel = userModel;

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(userModel.newPassword))
                {
                    if (userModel.newPassword == userModel.confirmPassword)
                    {
                        try
                        {
                            GraphServiceClient graphClient = GraphClient.CreateGraphClient();
                             
                            await graphClient.Users
                               .Request()
                               .AddAsync(iModel);
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
            return View(iModel);
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