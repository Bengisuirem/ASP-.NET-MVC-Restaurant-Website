
using HavzanCiftlik.Service.Core;
using HavzanCiftlik.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HavzanCiftlik.Controllers
{
    public class ControllerBase : Controller
    {

       

        private string _controller;
        private string _action;

        

        public SessionInfo CurrentSession
        {
            get
            {
                var value = HttpContext.Session.GetString("UserSessionInfo");
                return value == null ? default(SessionInfo) :
                    JsonConvert.DeserializeObject<SessionInfo>(value);

                
            }

            set
            {

                HttpContext.Session.SetString("UserSessionInfo", JsonConvert.SerializeObject(value));
                
            }
            
        }

        


        public bool IsSessionAlive
        {
            get { return CurrentSession != null; }

        }

       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           

            if (IsSessionAlive == false)
            {
                filterContext.Result = RedirectToLoginPage();
                return;

            }
            base.OnActionExecuting(filterContext);


            
        



			/*if(Authenticate(filterContext) == false)
            {
                filterContext.Result = RedirectToPrivilagePage();
                return;
            }
            */

			


		}
        protected IActionResult RedirectToLoginPage(string redirectAction = "Index")
        {
            
            return RedirectToAction("Index", "Login", new { redirectAction = redirectAction });
        }

        


        /* private bool Authenticate(ActionExecutingContext filterContext)
         {
             var descriptor = (ControllerActionDescriptor)filterContext.ActionDescriptor;
             _action = descriptor.ActionName;
             if(_action == "SetCulture") return true;
             _controller = descriptor.ControllerName;

             var isAuthorized = CurrentSession.Authorities
         }

         protected IActionResult RedirectToPrivilagePage()
         {
             return View("../Authetication/AuthenticateError");
         }
        */


    }
}


