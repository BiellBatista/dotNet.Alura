﻿namespace _02_XX_Usuario.API.Models
{
    public class EmailConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }
}