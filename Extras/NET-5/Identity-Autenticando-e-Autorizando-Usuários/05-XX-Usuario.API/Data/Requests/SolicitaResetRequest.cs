﻿using System.ComponentModel.DataAnnotations;

namespace _05_XX_Usuario.API.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}