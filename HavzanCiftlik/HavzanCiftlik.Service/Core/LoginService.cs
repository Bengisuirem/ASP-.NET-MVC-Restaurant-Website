using HavzanCiftlik.Service.Data;
using HavzanCiftlik.Service.Models;
using HavzanCiftlik.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavzanCiftlik.Service.Core
{
	public class LoginService
    {
		private readonly AppDbContext _db;

		public LoginService(AppDbContext db)
		{
			_db = db;
		}

		public human CheckUser(LoginViewModel viewModel)
		{
			var human = _db.human.FirstOrDefault(p => p.UserName==viewModel.UserName && p.Password==viewModel.Password);
			return human;
		}

        public object CheckUser(object viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
