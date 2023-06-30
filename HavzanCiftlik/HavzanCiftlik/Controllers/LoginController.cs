using Microsoft.AspNetCore.Mvc;
using HavzanCiftlik.Service.Models;
using HavzanCiftlik.Service.Core;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace HavzanCiftlik.Controllers
{
	public class LoginController : Controller
	{

		private LoginService _loginService;
        private object redirectAction;

        public LoginController(LoginService loginService) {

            _loginService = loginService;

		}

		public SessionInfo UserSession
		{
			get
			{
				var value = HttpContext.Session.GetString("UserSessionInfo");
				return value == null ? default(SessionInfo) :
					JsonConvert.DeserializeObject<SessionInfo>(value);
			}

			set
			{
				JsonSerializerSettings jss = new JsonSerializerSettings();
				var jsonString = JsonConvert.SerializeObject(value);
				HttpContext.Session.SetString("UserSessionInfo", jsonString);

			}
		}

		




		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Login(LoginViewModel viewModel)
        {
			
			var user= _loginService.CheckUser(viewModel);
			if (user == null) 
			{
                TempData["error"] = "Hata Oluştu.";
                return RedirectToAction("Index");
            }

			else { TempData["success"] = "Giriş Başarılı."; }


			UserSession = new SessionInfo
			{
				UserId = user.Id,
				UserFullName = user.Name,
				
			};
			ViewBag.UserSession = UserSession;
			
			TempData["user"] = user.Name;
			return RedirectToAction("Index", "Menu");



            //ViewBag.User = user;

        }
        

    }
}
