using System;
using System.ComponentModel.DataAnnotations;

namespace e_Hospital.Application.DTOs
{
	public class MedicineViewModel
	{
		[Required]
		public string? Name { get; set; }

		[Required]
		public DateTime? CreateDate { get; set; }

		[Required]
		public DateTime? EndDate { get; set; }
	}
}

