﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _06_03_XX_CasaDoCodigo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/Catalogo");
        }
    }
}