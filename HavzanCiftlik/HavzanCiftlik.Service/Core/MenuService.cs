using HavzanCiftlik.Service.Data;
using HavzanCiftlik.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HavzanCiftlik.Service.Core
{
	public class MenuService
	{
		private readonly AppDbContext _db;
       

        public MenuService(AppDbContext db)
		{
			_db = db;
		}

		public Menu GetById(int id)
		{
			return _db.Menu.First(x => x.Id == id);
		}

		public List<Menu> GetAll() {

			var models=_db.Menu.ToList();
			return models;
		
		}

		public void Save(Menu model)
		{

			if (model.Id == 0)
			{
				_db.Menu.Add(model);
			}
			else
			{
				_db.Menu.Update(model);
			}

			_db.SaveChanges();

		}
        

        public void Delete(int id)
		{
			var model = _db.Menu.Find(id);
			_db.Menu.Remove(model);
			_db.SaveChanges();
		}





	}
}
