﻿using System.ComponentModel.DataAnnotations;

namespace _04_XX_Usuario.API.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}