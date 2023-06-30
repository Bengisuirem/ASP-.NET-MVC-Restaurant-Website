using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavzanCiftlik.Service.Models
{
	public class Kasa
	{
		[Key]
		public int Id { get; set; }
		public int KasadakiPara { get; set; }
	}
}
