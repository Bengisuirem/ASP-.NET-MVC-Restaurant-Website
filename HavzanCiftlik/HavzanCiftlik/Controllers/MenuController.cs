using HavzanCiftlik.Service.Data;
using HavzanCiftlik.Service.Models;
using HavzanCiftlik.Service.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HavzanCiftlik.Controllers
{
	public class MenuController : ControllerBase
	{

		private readonly MenuService _menuService;
        

        public MenuController(MenuService menuService)
		{
			_menuService = menuService;
		}

       
        public IActionResult Index()
		{


			var models = _menuService.GetAll();
			return View(models);
		}

		public IActionResult Create()
		{
			
			return View();
		}

		public IActionResult Edit(int id)
		{
			var model= _menuService.GetById(id);
			return View(model);
		}

		public IActionResult Save(Menu model)
        {
			if(ModelState==null)
			{

                TempData["error"] = "Hata Oluştu.";

            }
			else
			{			
                _menuService.Save(model);
                TempData["success"] = "Bilgiler Başarıyla Kaydedildi.";
            }

            return RedirectToAction("Index");
        }

		public IActionResult Delete(int id)
		{
			_menuService.Delete(id);

			TempData["success"] = "Bilgiler Silindi";
			return RedirectToAction("Index");
		}


	}
}
