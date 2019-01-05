﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simple_benefits_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace simple_benefits_api.Controllers
{
    [Route("api/[controller]")]
    public class BenefitsCalcController : Controller
    {
        // POST api/values
        [HttpPost]
        public decimal Post([FromBody]BenefitsCalcParameters parameters)
        {
            var calculator = new HealthBenefitsCalculator();

            return calculator.CalculateHealthCareBenefit(parameters);

        }


    }
}
