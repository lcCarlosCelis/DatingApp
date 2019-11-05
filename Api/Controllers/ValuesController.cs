using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories.Values;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesRepo valuesRepo;
        public ValuesController(IValuesRepo valuesRepo)
        {
            this.valuesRepo = valuesRepo;
        }
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = valuesRepo.GetValues();
            return Ok(values);
        }
    }
}

