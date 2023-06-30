using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;

namespace HavzanCiftlik.Service.Models
{
	public class Menu
	{
		[Key]
		public int Id { get; set; }

		[DisplayName("Ad")]
		[Required(ErrorMessage = "Ad alanı zorunludur.")]
		public string Name { get; set; }

		[DisplayName("Fiyatı")]
		public string Fiyat { get; set; }

		

	
	}
}
