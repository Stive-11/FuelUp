﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FuelUp.Controllers
{
    public class HomeController : Controller
    {
        [Route("", Order = 1)]
        [Route("{*pathInfo}", Order = 1000)]
        public IActionResult Index()
        {
            return View();
        }

    }
}
