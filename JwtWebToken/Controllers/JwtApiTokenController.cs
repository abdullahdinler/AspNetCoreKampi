using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtWebToken.dal;
using Microsoft.AspNetCore.Authorization;

namespace JwtWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtApiTokenController : ControllerBase
    {
        [HttpGet("action")]
        public IActionResult Login()
        {
            return Created("", new BuildToken().CreateToken());
        }

        [Authorize]
        [HttpGet("action")]
        public IActionResult PageOne()
        {
            return Ok("Page One");
        }
    }
}
