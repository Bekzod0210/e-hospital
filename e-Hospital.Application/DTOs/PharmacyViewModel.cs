﻿using System.ComponentModel.DataAnnotations;

namespace e_Hospital.Application.DTOs
{
    public class PharmacyViewModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}
