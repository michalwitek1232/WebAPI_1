﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbGetController : ControllerBase
    {

        [HttpGet]

        public string str()
        {
            return "Hello World!";
        }

    }
}